namespace MeetingDemo
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.micComboBox = new System.Windows.Forms.ComboBox();
            this.micVolumnTrackBar = new System.Windows.Forms.TrackBar();
            this.micEnergyPictureBox = new System.Windows.Forms.PictureBox();
            this.micVolumnLabel = new System.Windows.Forms.Label();
            this.micEnergyLabel = new System.Windows.Forms.Label();
            this.spkComboBox = new System.Windows.Forms.ComboBox();
            this.spkVolumnTrackBar = new System.Windows.Forms.TrackBar();
            this.spkVolumnLabel = new System.Windows.Forms.Label();
            this.spkEnergyLabel = new System.Windows.Forms.Label();
            this.spkEnergyPictureBox = new System.Windows.Forms.PictureBox();
            this.micLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.camComboBox = new System.Windows.Forms.ComboBox();
            this.previewPictureBox = new System.Windows.Forms.PictureBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.framerateTrackBar = new System.Windows.Forms.TrackBar();
            this.framerateLabel = new System.Windows.Forms.Label();
            this.resComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.micVolumnTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.micEnergyPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spkVolumnTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spkEnergyPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.framerateTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // micComboBox
            // 
            this.micComboBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.micComboBox.FormattingEnabled = true;
            this.micComboBox.ItemHeight = 20;
            this.micComboBox.Location = new System.Drawing.Point(60, 70);
            this.micComboBox.Name = "micComboBox";
            this.micComboBox.Size = new System.Drawing.Size(360, 28);
            this.micComboBox.TabIndex = 0;
            // 
            // micVolumnTrackBar
            // 
            this.micVolumnTrackBar.BackColor = System.Drawing.Color.White;
            this.micVolumnTrackBar.Location = new System.Drawing.Point(101, 108);
            this.micVolumnTrackBar.Maximum = 100;
            this.micVolumnTrackBar.Name = "micVolumnTrackBar";
            this.micVolumnTrackBar.Size = new System.Drawing.Size(129, 45);
            this.micVolumnTrackBar.TabIndex = 2;
            this.micVolumnTrackBar.TickFrequency = 5;
            // 
            // micEnergyPictureBox
            // 
            this.micEnergyPictureBox.BackgroundImage = global::MeetingDemo.Properties.Resources.menu_wave_bg;
            this.micEnergyPictureBox.Location = new System.Drawing.Point(291, 118);
            this.micEnergyPictureBox.Name = "micEnergyPictureBox";
            this.micEnergyPictureBox.Size = new System.Drawing.Size(129, 4);
            this.micEnergyPictureBox.TabIndex = 3;
            this.micEnergyPictureBox.TabStop = false;
            // 
            // micVolumnLabel
            // 
            this.micVolumnLabel.AutoSize = true;
            this.micVolumnLabel.BackColor = System.Drawing.Color.White;
            this.micVolumnLabel.Location = new System.Drawing.Point(60, 113);
            this.micVolumnLabel.Name = "micVolumnLabel";
            this.micVolumnLabel.Size = new System.Drawing.Size(41, 12);
            this.micVolumnLabel.TabIndex = 4;
            this.micVolumnLabel.Text = "音量：";
            // 
            // micEnergyLabel
            // 
            this.micEnergyLabel.AutoSize = true;
            this.micEnergyLabel.BackColor = System.Drawing.Color.White;
            this.micEnergyLabel.Location = new System.Drawing.Point(250, 113);
            this.micEnergyLabel.Name = "micEnergyLabel";
            this.micEnergyLabel.Size = new System.Drawing.Size(41, 12);
            this.micEnergyLabel.TabIndex = 5;
            this.micEnergyLabel.Text = "能量：";
            // 
            // spkComboBox
            // 
            this.spkComboBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.spkComboBox.FormattingEnabled = true;
            this.spkComboBox.Location = new System.Drawing.Point(60, 175);
            this.spkComboBox.Name = "spkComboBox";
            this.spkComboBox.Size = new System.Drawing.Size(360, 28);
            this.spkComboBox.TabIndex = 6;
            // 
            // spkVolumnTrackBar
            // 
            this.spkVolumnTrackBar.BackColor = System.Drawing.Color.White;
            this.spkVolumnTrackBar.Location = new System.Drawing.Point(101, 213);
            this.spkVolumnTrackBar.Maximum = 100;
            this.spkVolumnTrackBar.Name = "spkVolumnTrackBar";
            this.spkVolumnTrackBar.Size = new System.Drawing.Size(129, 45);
            this.spkVolumnTrackBar.TabIndex = 7;
            this.spkVolumnTrackBar.TickFrequency = 5;
            // 
            // spkVolumnLabel
            // 
            this.spkVolumnLabel.AutoSize = true;
            this.spkVolumnLabel.BackColor = System.Drawing.Color.White;
            this.spkVolumnLabel.Location = new System.Drawing.Point(60, 216);
            this.spkVolumnLabel.Name = "spkVolumnLabel";
            this.spkVolumnLabel.Size = new System.Drawing.Size(41, 12);
            this.spkVolumnLabel.TabIndex = 8;
            this.spkVolumnLabel.Text = "音量：";
            // 
            // spkEnergyLabel
            // 
            this.spkEnergyLabel.AutoSize = true;
            this.spkEnergyLabel.BackColor = System.Drawing.Color.White;
            this.spkEnergyLabel.Location = new System.Drawing.Point(250, 216);
            this.spkEnergyLabel.Name = "spkEnergyLabel";
            this.spkEnergyLabel.Size = new System.Drawing.Size(41, 12);
            this.spkEnergyLabel.TabIndex = 9;
            this.spkEnergyLabel.Text = "能量：";
            // 
            // spkEnergyPictureBox
            // 
            this.spkEnergyPictureBox.BackgroundImage = global::MeetingDemo.Properties.Resources.menu_wave_bg;
            this.spkEnergyPictureBox.Location = new System.Drawing.Point(291, 221);
            this.spkEnergyPictureBox.Name = "spkEnergyPictureBox";
            this.spkEnergyPictureBox.Size = new System.Drawing.Size(129, 4);
            this.spkEnergyPictureBox.TabIndex = 10;
            this.spkEnergyPictureBox.TabStop = false;
            // 
            // micLabel
            // 
            this.micLabel.AutoSize = true;
            this.micLabel.BackColor = System.Drawing.Color.White;
            this.micLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.micLabel.Location = new System.Drawing.Point(60, 40);
            this.micLabel.Name = "micLabel";
            this.micLabel.Size = new System.Drawing.Size(58, 21);
            this.micLabel.TabIndex = 11;
            this.micLabel.Text = "麦克风";
            this.micLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(60, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "扬声器";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(60, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "摄像头";
            // 
            // camComboBox
            // 
            this.camComboBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.camComboBox.FormattingEnabled = true;
            this.camComboBox.Location = new System.Drawing.Point(124, 359);
            this.camComboBox.Name = "camComboBox";
            this.camComboBox.Size = new System.Drawing.Size(296, 28);
            this.camComboBox.TabIndex = 14;
            // 
            // previewPictureBox
            // 
            this.previewPictureBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.previewPictureBox.Location = new System.Drawing.Point(60, 393);
            this.previewPictureBox.Name = "previewPictureBox";
            this.previewPictureBox.Size = new System.Drawing.Size(360, 157);
            this.previewPictureBox.TabIndex = 15;
            this.previewPictureBox.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.White;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(291, 572);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 30);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(115)))), ((int)(((byte)(220)))));
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.ForeColor = System.Drawing.Color.White;
            this.okButton.Location = new System.Drawing.Point(381, 572);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 30);
            this.okButton.TabIndex = 17;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iconPictureBox.BackgroundImage")));
            this.iconPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.iconPictureBox.Location = new System.Drawing.Point(7, 5);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(24, 21);
            this.iconPictureBox.TabIndex = 18;
            this.iconPictureBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(38, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "设置";
            // 
            // framerateTrackBar
            // 
            this.framerateTrackBar.BackColor = System.Drawing.Color.White;
            this.framerateTrackBar.Location = new System.Drawing.Point(124, 285);
            this.framerateTrackBar.Maximum = 30;
            this.framerateTrackBar.Name = "framerateTrackBar";
            this.framerateTrackBar.Size = new System.Drawing.Size(227, 45);
            this.framerateTrackBar.TabIndex = 20;
            // 
            // framerateLabel
            // 
            this.framerateLabel.AutoSize = true;
            this.framerateLabel.BackColor = System.Drawing.Color.White;
            this.framerateLabel.Location = new System.Drawing.Point(368, 291);
            this.framerateLabel.Name = "framerateLabel";
            this.framerateLabel.Size = new System.Drawing.Size(47, 12);
            this.framerateLabel.TabIndex = 21;
            this.framerateLabel.Text = "0 帧/秒";
            // 
            // resComboBox
            // 
            this.resComboBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resComboBox.FormattingEnabled = true;
            this.resComboBox.Location = new System.Drawing.Point(124, 320);
            this.resComboBox.Name = "resComboBox";
            this.resComboBox.Size = new System.Drawing.Size(296, 28);
            this.resComboBox.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(60, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "帧  率：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(60, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "分辨率：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(60, 368);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "预  览：";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(480, 612);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.resComboBox);
            this.Controls.Add(this.framerateLabel);
            this.Controls.Add(this.framerateTrackBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.iconPictureBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.previewPictureBox);
            this.Controls.Add(this.camComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.micLabel);
            this.Controls.Add(this.spkEnergyPictureBox);
            this.Controls.Add(this.spkEnergyLabel);
            this.Controls.Add(this.spkVolumnLabel);
            this.Controls.Add(this.spkVolumnTrackBar);
            this.Controls.Add(this.spkComboBox);
            this.Controls.Add(this.micEnergyLabel);
            this.Controls.Add(this.micVolumnLabel);
            this.Controls.Add(this.micEnergyPictureBox);
            this.Controls.Add(this.micVolumnTrackBar);
            this.Controls.Add(this.micComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.micVolumnTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.micEnergyPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spkVolumnTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spkEnergyPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.framerateTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox micComboBox;
        private System.Windows.Forms.TrackBar micVolumnTrackBar;
        private System.Windows.Forms.PictureBox micEnergyPictureBox;
        private System.Windows.Forms.Label micVolumnLabel;
        private System.Windows.Forms.Label micEnergyLabel;
        private System.Windows.Forms.ComboBox spkComboBox;
        private System.Windows.Forms.TrackBar spkVolumnTrackBar;
        private System.Windows.Forms.Label spkVolumnLabel;
        private System.Windows.Forms.Label spkEnergyLabel;
        private System.Windows.Forms.PictureBox spkEnergyPictureBox;
        private System.Windows.Forms.Label micLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox camComboBox;
        private System.Windows.Forms.PictureBox previewPictureBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar framerateTrackBar;
        private System.Windows.Forms.Label framerateLabel;
        private System.Windows.Forms.ComboBox resComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}