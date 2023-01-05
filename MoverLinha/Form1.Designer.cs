namespace MoverLinha
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LineMover = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_line = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LineMover)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LineMover
            // 
            this.LineMover.BackColor = System.Drawing.Color.White;
            this.LineMover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LineMover.Location = new System.Drawing.Point(0, 0);
            this.LineMover.Name = "LineMover";
            this.LineMover.Size = new System.Drawing.Size(800, 450);
            this.LineMover.TabIndex = 0;
            this.LineMover.TabStop = false;
            this.LineMover.Click += new System.EventHandler(this.LineMover_Click);
            this.LineMover.Paint += new System.Windows.Forms.PaintEventHandler(this.LineMover_Paint_1);
            this.LineMover.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LineMover_MouseDown_1);
            this.LineMover.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LineMover_MouseMove_1);
            this.LineMover.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LineMover_MouseUp_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.btn_line);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(691, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(109, 450);
            this.panel1.TabIndex = 2;
            // 
            // btn_line
            // 
            this.btn_line.Location = new System.Drawing.Point(17, 73);
            this.btn_line.Name = "btn_line";
            this.btn_line.Size = new System.Drawing.Size(80, 23);
            this.btn_line.TabIndex = 0;
            this.btn_line.Text = "Line";
            this.btn_line.UseVisualStyleBackColor = true;
            this.btn_line.Click += new System.EventHandler(this.btn_line_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LineMover);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.LineMover)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox LineMover;
        private Panel panel1;
        private Button btn_line;
    }
}