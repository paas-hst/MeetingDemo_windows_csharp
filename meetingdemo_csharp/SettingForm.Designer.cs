namespace meetingdemo_csharp
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
            this.setting_tabcontrol = new meetingdemo_csharp.FullTabControl();
            this.audio_setting_tabpage = new System.Windows.Forms.TabPage();
            this.spk_energy_progressbar = new System.Windows.Forms.ProgressBar();
            this.spk_volumn_trackbar = new System.Windows.Forms.TrackBar();
            this.mic_energy_progressbar = new System.Windows.Forms.ProgressBar();
            this.spk_combobox = new System.Windows.Forms.ComboBox();
            this.mic_volumn_trackbar = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.mic_combobox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.video_seeting_tabpage = new System.Windows.Forms.TabPage();
            this.cam_framerate_label = new System.Windows.Forms.Label();
            this.cam_preview_picturebox = new System.Windows.Forms.PictureBox();
            this.cam_framerate_trackbar = new System.Windows.Forms.TrackBar();
            this.label16 = new System.Windows.Forms.Label();
            this.cam_combobox = new System.Windows.Forms.ComboBox();
            this.cam_resolve_combobox = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.vnc_setting_tabpage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.desktop_radio = new System.Windows.Forms.RadioButton();
            this.region_radio = new System.Windows.Forms.RadioButton();
            this.label24 = new System.Windows.Forms.Label();
            this.left_textbox = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.top_textbox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.bottom_textbox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.right_textbox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fluent_radio = new System.Windows.Forms.RadioButton();
            this.quality_radio = new System.Windows.Forms.RadioButton();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.record_seeting_tabpage = new System.Windows.Forms.TabPage();
            this.select_path_btn = new System.Windows.Forms.Button();
            this.record_path_textbox = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.setting_cancel_btn = new System.Windows.Forms.Button();
            this.setting_ok_btn = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.setting_tabcontrol.SuspendLayout();
            this.audio_setting_tabpage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spk_volumn_trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mic_volumn_trackbar)).BeginInit();
            this.video_seeting_tabpage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cam_preview_picturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cam_framerate_trackbar)).BeginInit();
            this.vnc_setting_tabpage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.record_seeting_tabpage.SuspendLayout();
            this.SuspendLayout();
            // 
            // setting_tabcontrol
            // 
            this.setting_tabcontrol.Controls.Add(this.audio_setting_tabpage);
            this.setting_tabcontrol.Controls.Add(this.video_seeting_tabpage);
            this.setting_tabcontrol.Controls.Add(this.vnc_setting_tabpage);
            this.setting_tabcontrol.Controls.Add(this.record_seeting_tabpage);
            this.setting_tabcontrol.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.setting_tabcontrol.ItemSize = new System.Drawing.Size(80, 48);
            this.setting_tabcontrol.Location = new System.Drawing.Point(0, 34);
            this.setting_tabcontrol.Name = "setting_tabcontrol";
            this.setting_tabcontrol.SelectedIndex = 0;
            this.setting_tabcontrol.Size = new System.Drawing.Size(480, 497);
            this.setting_tabcontrol.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.setting_tabcontrol.TabIndex = 1;
            // 
            // audio_setting_tabpage
            // 
            this.audio_setting_tabpage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.audio_setting_tabpage.Controls.Add(this.spk_energy_progressbar);
            this.audio_setting_tabpage.Controls.Add(this.spk_volumn_trackbar);
            this.audio_setting_tabpage.Controls.Add(this.mic_energy_progressbar);
            this.audio_setting_tabpage.Controls.Add(this.spk_combobox);
            this.audio_setting_tabpage.Controls.Add(this.mic_volumn_trackbar);
            this.audio_setting_tabpage.Controls.Add(this.label11);
            this.audio_setting_tabpage.Controls.Add(this.mic_combobox);
            this.audio_setting_tabpage.Controls.Add(this.label10);
            this.audio_setting_tabpage.Controls.Add(this.label6);
            this.audio_setting_tabpage.Controls.Add(this.label9);
            this.audio_setting_tabpage.Controls.Add(this.label5);
            this.audio_setting_tabpage.Controls.Add(this.label4);
            this.audio_setting_tabpage.Controls.Add(this.label8);
            this.audio_setting_tabpage.Controls.Add(this.label3);
            this.audio_setting_tabpage.Controls.Add(this.label7);
            this.audio_setting_tabpage.Controls.Add(this.label2);
            this.audio_setting_tabpage.Location = new System.Drawing.Point(0, 48);
            this.audio_setting_tabpage.Name = "audio_setting_tabpage";
            this.audio_setting_tabpage.Padding = new System.Windows.Forms.Padding(3);
            this.audio_setting_tabpage.Size = new System.Drawing.Size(480, 449);
            this.audio_setting_tabpage.TabIndex = 0;
            this.audio_setting_tabpage.Text = "音频";
            // 
            // spk_energy_progressbar
            // 
            this.spk_energy_progressbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.spk_energy_progressbar.Location = new System.Drawing.Point(93, 379);
            this.spk_energy_progressbar.Name = "spk_energy_progressbar";
            this.spk_energy_progressbar.Size = new System.Drawing.Size(347, 8);
            this.spk_energy_progressbar.TabIndex = 7;
            this.spk_energy_progressbar.Value = 50;
            // 
            // spk_volumn_trackbar
            // 
            this.spk_volumn_trackbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.spk_volumn_trackbar.Location = new System.Drawing.Point(84, 325);
            this.spk_volumn_trackbar.Maximum = 100;
            this.spk_volumn_trackbar.Name = "spk_volumn_trackbar";
            this.spk_volumn_trackbar.Size = new System.Drawing.Size(358, 45);
            this.spk_volumn_trackbar.TabIndex = 6;
            // 
            // mic_energy_progressbar
            // 
            this.mic_energy_progressbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.mic_energy_progressbar.Location = new System.Drawing.Point(84, 179);
            this.mic_energy_progressbar.MarqueeAnimationSpeed = 0;
            this.mic_energy_progressbar.Name = "mic_energy_progressbar";
            this.mic_energy_progressbar.Size = new System.Drawing.Size(347, 8);
            this.mic_energy_progressbar.Step = 100;
            this.mic_energy_progressbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.mic_energy_progressbar.TabIndex = 7;
            this.mic_energy_progressbar.Value = 50;
            // 
            // spk_combobox
            // 
            this.spk_combobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.spk_combobox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.spk_combobox.FormattingEnabled = true;
            this.spk_combobox.Location = new System.Drawing.Point(92, 272);
            this.spk_combobox.Name = "spk_combobox";
            this.spk_combobox.Size = new System.Drawing.Size(350, 28);
            this.spk_combobox.TabIndex = 5;
            // 
            // mic_volumn_trackbar
            // 
            this.mic_volumn_trackbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.mic_volumn_trackbar.Location = new System.Drawing.Point(75, 125);
            this.mic_volumn_trackbar.Maximum = 100;
            this.mic_volumn_trackbar.Name = "mic_volumn_trackbar";
            this.mic_volumn_trackbar.Size = new System.Drawing.Size(358, 45);
            this.mic_volumn_trackbar.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(47, 378);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "能量：";
            // 
            // mic_combobox
            // 
            this.mic_combobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.mic_combobox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mic_combobox.FormattingEnabled = true;
            this.mic_combobox.Location = new System.Drawing.Point(83, 73);
            this.mic_combobox.Name = "mic_combobox";
            this.mic_combobox.Size = new System.Drawing.Size(350, 28);
            this.mic_combobox.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 331);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "音量：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "能量：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 280);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "设备：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "音量：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "设备：";
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(16, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(440, 2);
            this.label8.TabIndex = 1;
            this.label8.Text = "label3";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(16, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(440, 2);
            this.label3.TabIndex = 1;
            this.label3.Text = "label3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(19, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "扬声器";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(19, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "麦克风";
            // 
            // video_seeting_tabpage
            // 
            this.video_seeting_tabpage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.video_seeting_tabpage.Controls.Add(this.cam_framerate_label);
            this.video_seeting_tabpage.Controls.Add(this.cam_preview_picturebox);
            this.video_seeting_tabpage.Controls.Add(this.cam_framerate_trackbar);
            this.video_seeting_tabpage.Controls.Add(this.label16);
            this.video_seeting_tabpage.Controls.Add(this.cam_combobox);
            this.video_seeting_tabpage.Controls.Add(this.cam_resolve_combobox);
            this.video_seeting_tabpage.Controls.Add(this.label15);
            this.video_seeting_tabpage.Controls.Add(this.label14);
            this.video_seeting_tabpage.Controls.Add(this.label12);
            this.video_seeting_tabpage.Controls.Add(this.label13);
            this.video_seeting_tabpage.Location = new System.Drawing.Point(0, 48);
            this.video_seeting_tabpage.Name = "video_seeting_tabpage";
            this.video_seeting_tabpage.Padding = new System.Windows.Forms.Padding(3);
            this.video_seeting_tabpage.Size = new System.Drawing.Size(480, 449);
            this.video_seeting_tabpage.TabIndex = 1;
            this.video_seeting_tabpage.Text = "视频";
            // 
            // cam_framerate_label
            // 
            this.cam_framerate_label.AutoSize = true;
            this.cam_framerate_label.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cam_framerate_label.Location = new System.Drawing.Point(353, 82);
            this.cam_framerate_label.Name = "cam_framerate_label";
            this.cam_framerate_label.Size = new System.Drawing.Size(43, 20);
            this.cam_framerate_label.TabIndex = 10;
            this.cam_framerate_label.Text = "帧/秒";
            // 
            // cam_preview_picturebox
            // 
            this.cam_preview_picturebox.Location = new System.Drawing.Point(82, 223);
            this.cam_preview_picturebox.Name = "cam_preview_picturebox";
            this.cam_preview_picturebox.Size = new System.Drawing.Size(340, 201);
            this.cam_preview_picturebox.TabIndex = 9;
            this.cam_preview_picturebox.TabStop = false;
            // 
            // cam_framerate_trackbar
            // 
            this.cam_framerate_trackbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.cam_framerate_trackbar.Location = new System.Drawing.Point(76, 75);
            this.cam_framerate_trackbar.Maximum = 30;
            this.cam_framerate_trackbar.Name = "cam_framerate_trackbar";
            this.cam_framerate_trackbar.Size = new System.Drawing.Size(266, 45);
            this.cam_framerate_trackbar.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(36, 180);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 7;
            this.label16.Text = "设备：";
            // 
            // cam_combobox
            // 
            this.cam_combobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.cam_combobox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cam_combobox.FormattingEnabled = true;
            this.cam_combobox.ItemHeight = 20;
            this.cam_combobox.Location = new System.Drawing.Point(82, 173);
            this.cam_combobox.Name = "cam_combobox";
            this.cam_combobox.Size = new System.Drawing.Size(340, 28);
            this.cam_combobox.TabIndex = 6;
            // 
            // cam_resolve_combobox
            // 
            this.cam_resolve_combobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.cam_resolve_combobox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cam_resolve_combobox.FormattingEnabled = true;
            this.cam_resolve_combobox.ItemHeight = 20;
            this.cam_resolve_combobox.Location = new System.Drawing.Point(82, 123);
            this.cam_resolve_combobox.Name = "cam_resolve_combobox";
            this.cam_resolve_combobox.Size = new System.Drawing.Size(340, 28);
            this.cam_resolve_combobox.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(25, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 5;
            this.label15.Text = "分辨率：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(36, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 4;
            this.label14.Text = "帧率：";
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(20, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(440, 2);
            this.label12.TabIndex = 3;
            this.label12.Text = "label12";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(20, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 21);
            this.label13.TabIndex = 2;
            this.label13.Text = "摄像头";
            // 
            // vnc_setting_tabpage
            // 
            this.vnc_setting_tabpage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.vnc_setting_tabpage.Controls.Add(this.panel2);
            this.vnc_setting_tabpage.Controls.Add(this.panel1);
            this.vnc_setting_tabpage.Controls.Add(this.label19);
            this.vnc_setting_tabpage.Controls.Add(this.label20);
            this.vnc_setting_tabpage.Controls.Add(this.label1);
            this.vnc_setting_tabpage.Controls.Add(this.label18);
            this.vnc_setting_tabpage.Location = new System.Drawing.Point(0, 48);
            this.vnc_setting_tabpage.Name = "vnc_setting_tabpage";
            this.vnc_setting_tabpage.Padding = new System.Windows.Forms.Padding(3);
            this.vnc_setting_tabpage.Size = new System.Drawing.Size(480, 449);
            this.vnc_setting_tabpage.TabIndex = 2;
            this.vnc_setting_tabpage.Text = "屏幕共享";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.desktop_radio);
            this.panel2.Controls.Add(this.region_radio);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.left_textbox);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.top_textbox);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.bottom_textbox);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.right_textbox);
            this.panel2.Location = new System.Drawing.Point(35, 204);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(433, 108);
            this.panel2.TabIndex = 21;
            // 
            // desktop_radio
            // 
            this.desktop_radio.AutoSize = true;
            this.desktop_radio.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.desktop_radio.Location = new System.Drawing.Point(0, 18);
            this.desktop_radio.Name = "desktop_radio";
            this.desktop_radio.Size = new System.Drawing.Size(83, 24);
            this.desktop_radio.TabIndex = 10;
            this.desktop_radio.TabStop = true;
            this.desktop_radio.Text = "共享桌面";
            this.desktop_radio.UseVisualStyleBackColor = true;
            // 
            // region_radio
            // 
            this.region_radio.AutoSize = true;
            this.region_radio.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.region_radio.Location = new System.Drawing.Point(0, 70);
            this.region_radio.Name = "region_radio";
            this.region_radio.Size = new System.Drawing.Size(83, 24);
            this.region_radio.TabIndex = 11;
            this.region_radio.TabStop = true;
            this.region_radio.Text = "共享区域";
            this.region_radio.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(327, 78);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(17, 12);
            this.label24.TabIndex = 19;
            this.label24.Text = "B:";
            // 
            // left_textbox
            // 
            this.left_textbox.Location = new System.Drawing.Point(108, 73);
            this.left_textbox.Name = "left_textbox";
            this.left_textbox.Size = new System.Drawing.Size(56, 21);
            this.left_textbox.TabIndex = 12;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(247, 78);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 12);
            this.label23.TabIndex = 18;
            this.label23.Text = "R:";
            // 
            // top_textbox
            // 
            this.top_textbox.Location = new System.Drawing.Point(185, 73);
            this.top_textbox.Name = "top_textbox";
            this.top_textbox.Size = new System.Drawing.Size(56, 21);
            this.top_textbox.TabIndex = 13;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(167, 78);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(17, 12);
            this.label22.TabIndex = 17;
            this.label22.Text = "T:";
            // 
            // bottom_textbox
            // 
            this.bottom_textbox.Location = new System.Drawing.Point(348, 73);
            this.bottom_textbox.Name = "bottom_textbox";
            this.bottom_textbox.Size = new System.Drawing.Size(56, 21);
            this.bottom_textbox.TabIndex = 14;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(90, 77);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 12);
            this.label21.TabIndex = 16;
            this.label21.Text = "L:";
            // 
            // right_textbox
            // 
            this.right_textbox.Location = new System.Drawing.Point(265, 73);
            this.right_textbox.Name = "right_textbox";
            this.right_textbox.Size = new System.Drawing.Size(56, 21);
            this.right_textbox.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fluent_radio);
            this.panel1.Controls.Add(this.quality_radio);
            this.panel1.Location = new System.Drawing.Point(35, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 62);
            this.panel1.TabIndex = 20;
            // 
            // fluent_radio
            // 
            this.fluent_radio.AutoSize = true;
            this.fluent_radio.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fluent_radio.Location = new System.Drawing.Point(0, 17);
            this.fluent_radio.Name = "fluent_radio";
            this.fluent_radio.Size = new System.Drawing.Size(83, 24);
            this.fluent_radio.TabIndex = 6;
            this.fluent_radio.TabStop = true;
            this.fluent_radio.Text = "流畅优先";
            this.fluent_radio.UseVisualStyleBackColor = true;
            // 
            // quality_radio
            // 
            this.quality_radio.AutoSize = true;
            this.quality_radio.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.quality_radio.Location = new System.Drawing.Point(131, 17);
            this.quality_radio.Name = "quality_radio";
            this.quality_radio.Size = new System.Drawing.Size(83, 24);
            this.quality_radio.TabIndex = 7;
            this.quality_radio.TabStop = true;
            this.quality_radio.Text = "质量优先";
            this.quality_radio.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label19.Location = new System.Drawing.Point(20, 188);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(440, 2);
            this.label19.TabIndex = 9;
            this.label19.Text = "label19";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(20, 152);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(74, 21);
            this.label20.TabIndex = 8;
            this.label20.Text = "共享模式";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(20, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(440, 2);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(20, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 21);
            this.label18.TabIndex = 4;
            this.label18.Text = "QoS策略";
            // 
            // record_seeting_tabpage
            // 
            this.record_seeting_tabpage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.record_seeting_tabpage.Controls.Add(this.select_path_btn);
            this.record_seeting_tabpage.Controls.Add(this.record_path_textbox);
            this.record_seeting_tabpage.Controls.Add(this.label25);
            this.record_seeting_tabpage.Location = new System.Drawing.Point(0, 48);
            this.record_seeting_tabpage.Name = "record_seeting_tabpage";
            this.record_seeting_tabpage.Padding = new System.Windows.Forms.Padding(3);
            this.record_seeting_tabpage.Size = new System.Drawing.Size(480, 449);
            this.record_seeting_tabpage.TabIndex = 3;
            this.record_seeting_tabpage.Text = "本地录制";
            // 
            // select_path_btn
            // 
            this.select_path_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.select_path_btn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.select_path_btn.Location = new System.Drawing.Point(393, 27);
            this.select_path_btn.Name = "select_path_btn";
            this.select_path_btn.Size = new System.Drawing.Size(60, 26);
            this.select_path_btn.TabIndex = 2;
            this.select_path_btn.Text = "浏览";
            this.select_path_btn.UseVisualStyleBackColor = true;
            this.select_path_btn.Click += new System.EventHandler(this.select_path_btn_Click);
            // 
            // record_path_textbox
            // 
            this.record_path_textbox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.record_path_textbox.Location = new System.Drawing.Point(90, 27);
            this.record_path_textbox.Name = "record_path_textbox";
            this.record_path_textbox.Size = new System.Drawing.Size(297, 26);
            this.record_path_textbox.TabIndex = 1;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(20, 30);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 20);
            this.label25.TabIndex = 0;
            this.label25.Text = "保存路径:";
            // 
            // setting_cancel_btn
            // 
            this.setting_cancel_btn.BackColor = System.Drawing.Color.White;
            this.setting_cancel_btn.BackgroundImage = global::meetingdemo_csharp.Properties.Resources.btn_bg;
            this.setting_cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.setting_cancel_btn.FlatAppearance.BorderSize = 0;
            this.setting_cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setting_cancel_btn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setting_cancel_btn.Location = new System.Drawing.Point(306, 550);
            this.setting_cancel_btn.Name = "setting_cancel_btn";
            this.setting_cancel_btn.Size = new System.Drawing.Size(65, 32);
            this.setting_cancel_btn.TabIndex = 2;
            this.setting_cancel_btn.Text = "取 消";
            this.setting_cancel_btn.UseVisualStyleBackColor = false;
            // 
            // setting_ok_btn
            // 
            this.setting_ok_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(125)))), ((int)(((byte)(254)))));
            this.setting_ok_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.setting_ok_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setting_ok_btn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setting_ok_btn.ForeColor = System.Drawing.Color.White;
            this.setting_ok_btn.Location = new System.Drawing.Point(379, 550);
            this.setting_ok_btn.Name = "setting_ok_btn";
            this.setting_ok_btn.Size = new System.Drawing.Size(65, 32);
            this.setting_ok_btn.TabIndex = 3;
            this.setting_ok_btn.Text = "确 定";
            this.setting_ok_btn.UseVisualStyleBackColor = false;
            this.setting_ok_btn.Click += new System.EventHandler(this.setting_ok_btn_Click);
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Location = new System.Drawing.Point(0, 533);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(480, 2);
            this.label17.TabIndex = 8;
            this.label17.Text = "label17";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(480, 600);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.setting_ok_btn);
            this.Controls.Add(this.setting_cancel_btn);
            this.Controls.Add(this.setting_tabcontrol);
            this.Name = "SettingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "setting";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.Controls.SetChildIndex(this.setting_tabcontrol, 0);
            this.Controls.SetChildIndex(this.setting_cancel_btn, 0);
            this.Controls.SetChildIndex(this.setting_ok_btn, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.setting_tabcontrol.ResumeLayout(false);
            this.audio_setting_tabpage.ResumeLayout(false);
            this.audio_setting_tabpage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spk_volumn_trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mic_volumn_trackbar)).EndInit();
            this.video_seeting_tabpage.ResumeLayout(false);
            this.video_seeting_tabpage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cam_preview_picturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cam_framerate_trackbar)).EndInit();
            this.vnc_setting_tabpage.ResumeLayout(false);
            this.vnc_setting_tabpage.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.record_seeting_tabpage.ResumeLayout(false);
            this.record_seeting_tabpage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private FullTabControl setting_tabcontrol;
        private System.Windows.Forms.TabPage audio_setting_tabpage;
        private System.Windows.Forms.TabPage video_seeting_tabpage;
        private System.Windows.Forms.TabPage vnc_setting_tabpage;
        private System.Windows.Forms.TabPage record_seeting_tabpage;
        private System.Windows.Forms.Button setting_cancel_btn;
        private System.Windows.Forms.Button setting_ok_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar spk_energy_progressbar;
        private System.Windows.Forms.TrackBar spk_volumn_trackbar;
        private System.Windows.Forms.ProgressBar mic_energy_progressbar;
        private System.Windows.Forms.ComboBox spk_combobox;
        private System.Windows.Forms.TrackBar mic_volumn_trackbar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox mic_combobox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox cam_preview_picturebox;
        private System.Windows.Forms.TrackBar cam_framerate_trackbar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cam_combobox;
        private System.Windows.Forms.ComboBox cam_resolve_combobox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label cam_framerate_label;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RadioButton quality_radio;
        private System.Windows.Forms.RadioButton fluent_radio;
        private System.Windows.Forms.RadioButton desktop_radio;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox right_textbox;
        private System.Windows.Forms.TextBox bottom_textbox;
        private System.Windows.Forms.TextBox top_textbox;
        private System.Windows.Forms.TextBox left_textbox;
        private System.Windows.Forms.RadioButton region_radio;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox record_path_textbox;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button select_path_btn;
    }
}