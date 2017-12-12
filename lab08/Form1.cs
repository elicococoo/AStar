using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lab08
{
    public partial class Form1 : Form
    {
        class Node : IComparable
        {
            public Point now;
            public int total, dist, id, father;
            public int CompareTo(object obj)
            {
                Node other = obj as Node;
                if (this.total > other.total) return 1;
                else if (this.total == other.total) {
                    if (this.id > other.id) return 1;
                    else if (this.id == other.id) return 0;
                    else return -1;
                }
                else return -1;
            }
            public Node(){}
            public Node(Point a, int dis, int tot)
            {
                now = a;
                dist = dis;
                total = tot;
            }
            public Node(Point a, int dis, int tot, int d, int e)
            {
                now = a;
                dist = dis;
                total = tot;
                id = d;
                father = e;
            }
            public int Compare(object x, object y)
            {
                Node p1 = x as Node;
                Node p2 = y as Node;
                if (p1.total > p2.total) return 1;
                else if (p1.total == p2.total) return 0;
                else return -1;
            }
        };
        
        Timer timer = new Timer();
        int HEIGHT = 100;
        const int height = 20, width = 20;
        const int row = 30, col = 40;
        bool[,] myRect = new bool[30, 40];
        int[,] vis = new int[30, 40];
        List<Node> search = new List<Node>(), path = new List<Node>();
       // PriorityQueue<Node> pq = new PriorityQueue<Node>();
        SortedSet<Node> pq = new System.Collections.Generic.SortedSet<Node>();
        Point now, mouse, pre, des;
        Point[] move = new Point[8];
        bool setBlock, setStart, isMouseDown, setDes, found;
        public Form1()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            InitializeComponent();
        }
        void drawFillRect(Rectangle rect, Color color, PaintEventArgs e){
            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(color), rect);
        }
        void drawLine(Point p1, Point p2, Color color, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(new Pen(color), p1, p2);
        }
        void Init()
        {
            Array.Clear(myRect, 0, myRect.Length);
            Array.Clear(vis, 0, vis.Length);
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    vis[i, j] = int.MaxValue;
            search.Clear();
            now.X = now.Y = -1;
            des.X = des.Y = -1;
            setBlock = setStart = setDes = false;
            found = false;
            pq.Clear();
            path.Clear();
            this.runButton.Text = "Path!";
            this.runButton.BackColor = Color.LightGray;
            timer.Enabled = false;

            this.setBlockButton.Text = "Set Blocks : Off";
            this.setBlockButton.BackColor = Color.LightGray;

            this.setStartButton.Text = "Set Start Point : Off";
            this.setStartButton.BackColor = Color.LightGray;

            this.setDesButton.Text = "Set Destination : Off";
            this.setDesButton.BackColor = Color.LightGray;

            isMouseDown = false;

            mouse.X = mouse.Y = -1;
            pre.X = pre.Y = -1;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Rectangle rect = new Rectangle(j * width, HEIGHT + i * height, width, height);
                    drawFillRect(rect, myRect[i, j] ? Color.LightGreen : Color.White, e);
                }
            }

            foreach (Node i in search)
            {
                Rectangle rect = new Rectangle(i.now.Y * width, HEIGHT + i.now.X * height, width, height);
                if(myRect[i.now.X, i.now.Y] == false)
                    drawFillRect(rect, Color.LightPink, e);
            }
            foreach (Node i in path)
            {
                Rectangle rect = new Rectangle(i.now.Y * width, HEIGHT + i.now.X * height, width, height);
                if (myRect[i.now.X, i.now.Y] == false)
                    drawFillRect(rect, Color.DeepSkyBlue, e);
            }
            if (now.X != -1)
            {
                Rectangle rect = new Rectangle(now.Y * width, HEIGHT + now.X * height, width, height);
                drawFillRect(rect, Color.Tomato, e);
            }
            if (des.X != -1)
            {
                Rectangle rect = new Rectangle(des.Y * width, HEIGHT + des.X * height, width, height);
                drawFillRect(rect, Color.DarkSlateBlue, e);
            }
            for (int i = 0; i <= row; i++)
                drawLine(new Point(0, HEIGHT + i * height), new Point(col * width, HEIGHT + i * height), Color.LightGray, e);
            for (int i = 0; i <= col; i++)
                drawLine(new Point(i * width, HEIGHT), new Point(i * width, HEIGHT + row * height), Color.LightGray, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
            move[0] = new Point(0, 1);
            move[1] = new Point(1, 0);
            move[2] = new Point(-1, 0);
            move[3] = new Point(0, -1);
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            if (des.X != -1 && now.X != -1)
            {
                found = false;
                search.Clear();
                path.Clear();
                for (int i = 0; i < row; i++)
                    for (int j = 0; j < col; j++)
                        vis[i, j] = int.MaxValue;
                pq.Clear();
                Node node = new Node(now, 0, Math.Abs(des.X - now.X) + Math.Abs(des.Y - now.Y), 0, -1);
                search.Add(node);
                //  pq.Push(node);
                pq.Add(node);
                astar();
                this.Invalidate();
            }
        }

        private void astar()
        {
            List<Node> l = new List<Node>();
            if (found) return;
            Node node = new Node();
            if(pq.Count == 0) return ;
            while(pq.Count > 0)
            {
              //  node = pq.Pop();
                node = pq.Min;
                pq.Remove(node);
                l.Add(node);
                if (node.total >= vis[node.now.X, node.now.Y]) continue;
                else vis[node.now.X, node.now.Y] = node.total;
                for (int i = 0; i < 4; i++ )
                {
                    Node tmp = new Node(new Point(node.now.X + move[i].X, node.now.Y + move[i].Y), node.dist + 1, 0, search.Count, node.id);
                    if (tmp.now.X >= row || tmp.now.Y >= col || tmp.now.X < 0 || tmp.now.Y < 0 || myRect[tmp.now.X, tmp.now.Y] == true) continue;
                    tmp.total = tmp.dist + Math.Abs(des.X - tmp.now.X) + Math.Abs(des.Y - tmp.now.Y);
                    if (tmp.total >= vis[tmp.now.X, tmp.now.Y]) continue;
                    if (tmp.now.X == des.X && tmp.now.Y == des.Y)
                    {
                        found = true;
                    }
                    search.Add(tmp);
                    if (found)
                    {
                        pq.Clear();
                        while (pq.Count > 0)
                        {
                            //  node = pq.Pop();
                            node = pq.Min;
                            l.Add(node);

                        }
                        break;
                    }
                    //   pq.Push(tmp);
                    pq.Add(tmp);
                }
                if (found) break;
            }
            int a = l.Count;
            getPath();
        }
        private void getPath()
        {
            Node node = search[search.Count - 1];
            path.Add(node);
            while (node.father != -1)
            {
                node = search[node.father];
                path.Add(node);
            }
        }
        private void setStartButton_Click(object sender, EventArgs e)
        {
            if (setStart == false)
            {
                setStart = true;
                this.setStartButton.Text = "Set Start Point : On";
                this.setStartButton.BackColor = Color.Tomato;

                if (setDes)
                {
                    setDes = false;
                    this.setDesButton.Text = "Set Destination : Off";
                    this.setDesButton.BackColor = Color.LightGray;
                }
                if (setBlock)
                {
                    setBlock = false;
                    this.setBlockButton.Text = "Set Blocks : Off";
                    this.setBlockButton.BackColor = Color.LightGray;
                }
            }
            else
            {
                setStart = false;
                this.setStartButton.Text = "Set Start Point : Off";
                this.setStartButton.BackColor = Color.LightGray;
            }
        }

        private void setBlockButton_Click(object sender, EventArgs e)
        {
            if (setBlock == false)
            {
                setBlock = true;
                this.setBlockButton.Text = "Set Blocks : On";
                this.setBlockButton.BackColor = Color.LightGreen;
                if (setStart)
                {
                    setStart = false;
                    this.setStartButton.Text = "Set Start Point : Off";
                    this.setStartButton.BackColor = Color.LightGray;
                }
                if (setDes)
                {
                    setDes = false;
                    this.setDesButton.Text = "Set Destination : Off";
                    this.setDesButton.BackColor = Color.LightGray;
                }
            }
            else
            {
                setBlock = false;
                this.setBlockButton.Text = "Set Blocks : Off";
                this.setBlockButton.BackColor = Color.LightGray;
            }
        }

        private void setDesButton_Click(object sender, EventArgs e)
        {
            if (setDes == false)
            {
                setDes = true;
                this.setDesButton.Text = "Set Destination : On";
                this.setDesButton.BackColor = Color.LightBlue;

                if (setStart)
                {
                    setStart = false;
                    this.setStartButton.Text = "Set Start Point : Off";
                    this.setStartButton.BackColor = Color.LightGray;
                }
                if (setBlock)
                {
                    setBlock = false;
                    this.setBlockButton.Text = "Set Blocks : Off";
                    this.setBlockButton.BackColor = Color.LightGray;
                }
            }
            else
            {
                setDes = false;
                this.setDesButton.Text = "Set Destination : Off";
                this.setDesButton.BackColor = Color.LightGray;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Init();
            this.Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y > HEIGHT && e.Y < HEIGHT + row * height && e.X > 0 && e.X < col * width)
            {
                isMouseDown = true;
                if (setBlock == true && e.Y > HEIGHT)
                {
                    Point tmp = new Point((e.Y - HEIGHT) / height, e.X / width);
                    if (pre != tmp)
                    {
                        myRect[tmp.X, tmp.Y] = !myRect[tmp.X, tmp.Y];
                        pre = tmp;
                    }
                    this.Invalidate();
                }
                if (setStart == true)
                {
                    path.Clear();
                    search.Clear();
                    now = new Point((e.Y - HEIGHT) / height, e.X / width);
                    myRect[now.X, now.Y] = false;
                    this.Invalidate();
                }
                if (setDes == true)
                {
                    path.Clear();
                    search.Clear();
                    des = new Point((e.Y - HEIGHT) / height, e.X / width);
                    myRect[des.X, des.Y] = false;
                    this.Invalidate();
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            pre.X = pre.Y = -1;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                if (setBlock == true && e.Y > HEIGHT)
                {
                    if (e.Y > HEIGHT && e.Y < HEIGHT + row * height && e.X > 0 && e.X < col * width)
                    {
                        Point tmp = new Point((e.Y - HEIGHT) / height, e.X / width);
                        if (pre != tmp)
                        {
                            myRect[tmp.X, tmp.Y] = !myRect[tmp.X, tmp.Y];
                            pre = tmp;
                        }
                        this.Invalidate();
                    }
                }
            }
        }



    }
}
