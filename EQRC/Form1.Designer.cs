namespace EQRC
{
    partial class Form1
    {
        /// <summary>
        /// 
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region

        /// <summary>
        /// 
        /// 
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Load = new System.Windows.Forms.PictureBox();
            this.Show = new System.Windows.Forms.PictureBox();
            this.StackButton = new System.Windows.Forms.Button();
            this.first = new System.Windows.Forms.Button();
            this.TwoShow = new System.Windows.Forms.PictureBox();
            this.Stack = new System.Windows.Forms.PictureBox();
            this.TimeBox = new System.Windows.Forms.TextBox();
            this.ReTimeBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Load)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Show)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TwoShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stack)).BeginInit();
            this.SuspendLayout();
            // 
            // Load
            // 
            this.Load.BackColor = System.Drawing.Color.LavenderBlush;
            this.Load.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Load.Location = new System.Drawing.Point(99, 168);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(180, 195);
            this.Load.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Load.TabIndex = 0;
            this.Load.TabStop = false;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // Show
            // 
            this.Show.BackColor = System.Drawing.Color.LavenderBlush;
            this.Show.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Show.Cursor = System.Windows.Forms.Cursors.No;
            this.Show.Location = new System.Drawing.Point(513, 57);
            this.Show.Name = "Show";
            this.Show.Size = new System.Drawing.Size(280, 303);
            this.Show.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Show.TabIndex = 1;
            this.Show.TabStop = false;
            // 
            // StackButton
            // 
            this.StackButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.StackButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StackButton.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StackButton.Location = new System.Drawing.Point(41, 408);
            this.StackButton.Name = "StackButton";
            this.StackButton.Size = new System.Drawing.Size(165, 38);
            this.StackButton.TabIndex = 2;
            this.StackButton.Text = "Split";
            this.StackButton.UseVisualStyleBackColor = false;
            this.StackButton.Click += new System.EventHandler(this.StackButton_Click);
            // 
            // first
            // 
            this.first.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.first.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.first.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.first.Location = new System.Drawing.Point(248, 408);
            this.first.Name = "first";
            this.first.Size = new System.Drawing.Size(165, 38);
            this.first.TabIndex = 3;
            this.first.Text = "Stack";
            this.first.UseVisualStyleBackColor = false;
            this.first.Click += new System.EventHandler(this.Split_Click);
            // 
            // TwoShow
            // 
            this.TwoShow.BackColor = System.Drawing.Color.LavenderBlush;
            this.TwoShow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TwoShow.Cursor = System.Windows.Forms.Cursors.No;
            this.TwoShow.Location = new System.Drawing.Point(857, 57);
            this.TwoShow.Name = "TwoShow";
            this.TwoShow.Size = new System.Drawing.Size(280, 303);
            this.TwoShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TwoShow.TabIndex = 4;
            this.TwoShow.TabStop = false;
            // 
            // Stack
            // 
            this.Stack.BackColor = System.Drawing.Color.LavenderBlush;
            this.Stack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Stack.Cursor = System.Windows.Forms.Cursors.No;
            this.Stack.Location = new System.Drawing.Point(319, 168);
            this.Stack.Name = "Stack";
            this.Stack.Size = new System.Drawing.Size(178, 193);
            this.Stack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Stack.TabIndex = 5;
            this.Stack.TabStop = false;
            this.Stack.Click += new System.EventHandler(this.StackButton_Click);
            // 
            // TimeBox
            // 
            this.TimeBox.Location = new System.Drawing.Point(356, 70);
            this.TimeBox.Name = "TimeBox";
            this.TimeBox.Size = new System.Drawing.Size(100, 20);
            this.TimeBox.TabIndex = 6;
            // 
            // ReTimeBox
            // 
            this.ReTimeBox.Location = new System.Drawing.Point(179, 70);
            this.ReTimeBox.Name = "ReTimeBox";
            this.ReTimeBox.Size = new System.Drawing.Size(100, 20);
            this.ReTimeBox.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1201, 567);
            this.Controls.Add(this.ReTimeBox);
            this.Controls.Add(this.TimeBox);
            this.Controls.Add(this.Stack);
            this.Controls.Add(this.TwoShow);
            this.Controls.Add(this.first);
            this.Controls.Add(this.StackButton);
            this.Controls.Add(this.Show);
            this.Controls.Add(this.Load);
            this.Name = "Form1";
            this.Text = "EQRC-QRFC";
            ((System.ComponentModel.ISupportInitialize)(this.Load)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Show)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TwoShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Load;
        private System.Windows.Forms.PictureBox Show;
        private System.Windows.Forms.OpenFileDialog openPic;
        private System.Windows.Forms.Button StackButton;
        private System.Windows.Forms.Button first;
        private System.Windows.Forms.PictureBox TwoShow;
        private System.Windows.Forms.PictureBox Stack;
        private System.Windows.Forms.TextBox TimeBox;
        private System.Windows.Forms.TextBox ReTimeBox;
    }
}

