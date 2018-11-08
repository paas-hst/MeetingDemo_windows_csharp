namespace MeetingDemo
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.settingPictureBox = new System.Windows.Forms.PictureBox();
            this.camPictureBox = new System.Windows.Forms.PictureBox();
            this.micPictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.camPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.micPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.settingPictureBox);
            this.panel1.Controls.Add(this.camPictureBox);
            this.panel1.Controls.Add(this.micPictureBox);
            this.panel1.Location = new System.Drawing.Point(0, 566);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 94);
            this.panel1.TabIndex = 0;
            // 
            // settingPictureBox
            // 
            this.settingPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.settingPictureBox.BackgroundImage = global::MeetingDemo.Properties.Resources.toolbar_settings;
            this.settingPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.settingPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingPictureBox.Location = new System.Drawing.Point(663, 16);
            this.settingPictureBox.Name = "settingPictureBox";
            this.settingPictureBox.Size = new System.Drawing.Size(60, 60);
            this.settingPictureBox.TabIndex = 2;
            this.settingPictureBox.TabStop = false;
            this.settingPictureBox.Click += new System.EventHandler(this.settingPictureBox_Click);
            // 
            // camPictureBox
            // 
            this.camPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.camPictureBox.BackgroundImage = global::MeetingDemo.Properties.Resources.toolbar_cam;
            this.camPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.camPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.camPictureBox.Location = new System.Drawing.Point(563, 16);
            this.camPictureBox.Name = "camPictureBox";
            this.camPictureBox.Size = new System.Drawing.Size(60, 60);
            this.camPictureBox.TabIndex = 1;
            this.camPictureBox.TabStop = false;
            this.camPictureBox.Click += new System.EventHandler(this.camPictureBox_Click);
            // 
            // micPictureBox
            // 
            this.micPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.micPictureBox.BackgroundImage = global::MeetingDemo.Properties.Resources.toolbar_mic;
            this.micPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.micPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.micPictureBox.Location = new System.Drawing.Point(463, 16);
            this.micPictureBox.Name = "micPictureBox";
            this.micPictureBox.Size = new System.Drawing.Size(60, 60);
            this.micPictureBox.TabIndex = 0;
            this.micPictureBox.TabStop = false;
            this.micPictureBox.Click += new System.EventHandler(this.micPictureBox_Click);
            this.micPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.micPictureBox_MouseDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "好视通云通信";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.settingPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.camPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.micPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox settingPictureBox;
        private System.Windows.Forms.PictureBox camPictureBox;
        private System.Windows.Forms.PictureBox micPictureBox;

    }
}