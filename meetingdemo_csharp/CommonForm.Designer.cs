namespace meetingdemo_csharp
{
    partial class CommonForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommonForm));
            this.title_panel = new System.Windows.Forms.Panel();
            this.close_picturebox = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.max_picturebox = new System.Windows.Forms.PictureBox();
            this.min_picturebox = new System.Windows.Forms.PictureBox();
            this.title_label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.setting_pictureBox = new System.Windows.Forms.PictureBox();
            this.title_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.close_picturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_picturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_picturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setting_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // title_panel
            // 
            this.title_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(78)))));
            this.title_panel.Controls.Add(this.setting_pictureBox);
            this.title_panel.Controls.Add(this.close_picturebox);
            this.title_panel.Controls.Add(this.pictureBox2);
            this.title_panel.Controls.Add(this.max_picturebox);
            this.title_panel.Controls.Add(this.min_picturebox);
            this.title_panel.Controls.Add(this.title_label);
            this.title_panel.Controls.Add(this.pictureBox1);
            this.title_panel.Location = new System.Drawing.Point(0, 0);
            this.title_panel.Name = "title_panel";
            this.title_panel.Size = new System.Drawing.Size(600, 36);
            this.title_panel.TabIndex = 1;
            this.title_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title_panel_MouseDown);
            this.title_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.title_panel_MouseMove);
            this.title_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.title_panel_MouseUp);
            // 
            // close_picturebox
            // 
            this.close_picturebox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("close_picturebox.BackgroundImage")));
            this.close_picturebox.Location = new System.Drawing.Point(574, 10);
            this.close_picturebox.Name = "close_picturebox";
            this.close_picturebox.Size = new System.Drawing.Size(16, 16);
            this.close_picturebox.TabIndex = 5;
            this.close_picturebox.TabStop = false;
            this.close_picturebox.Click += new System.EventHandler(this.close_picturebox_Click);
            this.close_picturebox.MouseLeave += new System.EventHandler(this.close_picturebox_MouseLeave);
            this.close_picturebox.MouseHover += new System.EventHandler(this.close_picturebox_MouseHover);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(1088, 42);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // max_picturebox
            // 
            this.max_picturebox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("max_picturebox.BackgroundImage")));
            this.max_picturebox.Location = new System.Drawing.Point(542, 12);
            this.max_picturebox.Name = "max_picturebox";
            this.max_picturebox.Size = new System.Drawing.Size(12, 12);
            this.max_picturebox.TabIndex = 3;
            this.max_picturebox.TabStop = false;
            this.max_picturebox.Click += new System.EventHandler(this.main_max_picturebox_Click);
            this.max_picturebox.MouseLeave += new System.EventHandler(this.max_picturebox_MouseLeave);
            this.max_picturebox.MouseHover += new System.EventHandler(this.main_max_picturebox_MouseHover);
            // 
            // min_picturebox
            // 
            this.min_picturebox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("min_picturebox.BackgroundImage")));
            this.min_picturebox.Location = new System.Drawing.Point(506, 10);
            this.min_picturebox.Name = "min_picturebox";
            this.min_picturebox.Size = new System.Drawing.Size(16, 16);
            this.min_picturebox.TabIndex = 2;
            this.min_picturebox.TabStop = false;
            this.min_picturebox.Click += new System.EventHandler(this.main_min_picturebox_Click);
            this.min_picturebox.MouseLeave += new System.EventHandler(this.min_picturebox_MouseLeave);
            this.min_picturebox.MouseHover += new System.EventHandler(this.main_min_picturebox_MouseHover);
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title_label.ForeColor = System.Drawing.Color.White;
            this.title_label.Location = new System.Drawing.Point(37, 8);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(93, 20);
            this.title_label.TabIndex = 1;
            this.title_label.Text = "好视通云通信";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // setting_pictureBox
            // 
            this.setting_pictureBox.BackgroundImage = global::meetingdemo_csharp.Properties.Resources.app_setting;
            this.setting_pictureBox.Location = new System.Drawing.Point(470, 10);
            this.setting_pictureBox.Name = "setting_pictureBox";
            this.setting_pictureBox.Size = new System.Drawing.Size(16, 16);
            this.setting_pictureBox.TabIndex = 6;
            this.setting_pictureBox.TabStop = false;
            this.setting_pictureBox.Click += new System.EventHandler(this.setting_pictureBox_Click);
            // 
            // CommonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.title_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CommonForm";
            this.Text = "CommonForm";
            this.SizeChanged += new System.EventHandler(this.CommonForm_SizeChanged);
            this.title_panel.ResumeLayout(false);
            this.title_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.close_picturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_picturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_picturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setting_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel title_panel;
        private System.Windows.Forms.PictureBox close_picturebox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox max_picturebox;
        private System.Windows.Forms.PictureBox min_picturebox;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox setting_pictureBox;
    }
}