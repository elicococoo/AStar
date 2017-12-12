namespace lab08
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.runButton = new System.Windows.Forms.Button();
            this.setStartButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.setBlockButton = new System.Windows.Forms.Button();
            this.setDesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // runButton
            // 
            this.runButton.BackColor = System.Drawing.Color.LightGray;
            this.runButton.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runButton.Location = new System.Drawing.Point(12, 10);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(223, 80);
            this.runButton.TabIndex = 0;
            this.runButton.Text = "Path!";
            this.runButton.UseVisualStyleBackColor = false;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // setStartButton
            // 
            this.setStartButton.BackColor = System.Drawing.Color.LightGray;
            this.setStartButton.Font = new System.Drawing.Font("Nirmala UI", 12F);
            this.setStartButton.Location = new System.Drawing.Point(282, 10);
            this.setStartButton.Name = "setStartButton";
            this.setStartButton.Size = new System.Drawing.Size(223, 33);
            this.setStartButton.TabIndex = 2;
            this.setStartButton.Text = "Set Start Point : Off";
            this.setStartButton.UseVisualStyleBackColor = false;
            this.setStartButton.Click += new System.EventHandler(this.setStartButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.LightGray;
            this.clearButton.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.ForeColor = System.Drawing.Color.Red;
            this.clearButton.Location = new System.Drawing.Point(551, 57);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(223, 33);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Clear!";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // setBlockButton
            // 
            this.setBlockButton.BackColor = System.Drawing.Color.LightGray;
            this.setBlockButton.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setBlockButton.Location = new System.Drawing.Point(551, 10);
            this.setBlockButton.Name = "setBlockButton";
            this.setBlockButton.Size = new System.Drawing.Size(223, 33);
            this.setBlockButton.TabIndex = 4;
            this.setBlockButton.Text = "Set Blocks : Off";
            this.setBlockButton.UseVisualStyleBackColor = false;
            this.setBlockButton.Click += new System.EventHandler(this.setBlockButton_Click);
            // 
            // setDesButton
            // 
            this.setDesButton.BackColor = System.Drawing.Color.LightGray;
            this.setDesButton.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setDesButton.Location = new System.Drawing.Point(282, 57);
            this.setDesButton.Name = "setDesButton";
            this.setDesButton.Size = new System.Drawing.Size(223, 33);
            this.setDesButton.TabIndex = 5;
            this.setDesButton.Text = "Set Destination : Off";
            this.setDesButton.UseVisualStyleBackColor = false;
            this.setDesButton.Click += new System.EventHandler(this.setDesButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 701);
            this.Controls.Add(this.setDesButton);
            this.Controls.Add(this.setBlockButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.setStartButton);
            this.Controls.Add(this.runButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AStar";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button setStartButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button setBlockButton;
        private System.Windows.Forms.Button setDesButton;
    }
}

