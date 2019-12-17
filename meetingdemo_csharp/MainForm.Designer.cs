namespace meetingdemo_csharp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.main_right_panel = new System.Windows.Forms.Panel();
            this.users_datagridview = new System.Windows.Forms.DataGridView();
            this.msg_textbox = new System.Windows.Forms.RichTextBox();
            this.left_right_split_label = new System.Windows.Forms.Label();
            this.send_msg_split_label = new System.Windows.Forms.Label();
            this.msg_split_label = new System.Windows.Forms.Label();
            this.user_msg_split_label = new System.Windows.Forms.Label();
            this.send_msg_btn = new System.Windows.Forms.Button();
            this.users_combobox = new System.Windows.Forms.ComboBox();
            this.send_msg_textbox = new System.Windows.Forms.TextBox();
            this.toolbar_panel = new System.Windows.Forms.Panel();
            this.toolbar_record_btn = new System.Windows.Forms.Button();
            this.toolbar_setting_btn = new System.Windows.Forms.Button();
            this.toolbar_invite_btn = new System.Windows.Forms.Button();
            this.toolbar_vnc_btn = new System.Windows.Forms.Button();
            this.toolbar_cam_btn = new System.Windows.Forms.Button();
            this.toolbar_speaker_btn = new System.Windows.Forms.Button();
            this.toolbar_mic_btn = new System.Windows.Forms.Button();
            this.tab_panel = new System.Windows.Forms.Panel();
            this.group_label = new System.Windows.Forms.Label();
            this.video_panel = new System.Windows.Forms.Panel();
            this.main_right_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.users_datagridview)).BeginInit();
            this.toolbar_panel.SuspendLayout();
            this.tab_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_right_panel
            // 
            this.main_right_panel.BackColor = System.Drawing.Color.White;
            this.main_right_panel.Controls.Add(this.users_datagridview);
            this.main_right_panel.Controls.Add(this.msg_textbox);
            this.main_right_panel.Controls.Add(this.left_right_split_label);
            this.main_right_panel.Controls.Add(this.send_msg_split_label);
            this.main_right_panel.Controls.Add(this.msg_split_label);
            this.main_right_panel.Controls.Add(this.user_msg_split_label);
            this.main_right_panel.Controls.Add(this.send_msg_btn);
            this.main_right_panel.Controls.Add(this.users_combobox);
            this.main_right_panel.Controls.Add(this.send_msg_textbox);
            this.main_right_panel.Location = new System.Drawing.Point(900, 36);
            this.main_right_panel.Name = "main_right_panel";
            this.main_right_panel.Size = new System.Drawing.Size(300, 639);
            this.main_right_panel.TabIndex = 2;
            // 
            // users_datagridview
            // 
            this.users_datagridview.AllowUserToAddRows = false;
            this.users_datagridview.AllowUserToDeleteRows = false;
            this.users_datagridview.AllowUserToResizeColumns = false;
            this.users_datagridview.AllowUserToResizeRows = false;
            this.users_datagridview.BackgroundColor = System.Drawing.Color.White;
            this.users_datagridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.users_datagridview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.users_datagridview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.users_datagridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.users_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.users_datagridview.ColumnHeadersVisible = false;
            this.users_datagridview.Enabled = false;
            this.users_datagridview.Location = new System.Drawing.Point(4, 4);
            this.users_datagridview.MultiSelect = false;
            this.users_datagridview.Name = "users_datagridview";
            this.users_datagridview.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.users_datagridview.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.users_datagridview.RowHeadersVisible = false;
            this.users_datagridview.RowTemplate.Height = 23;
            this.users_datagridview.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.users_datagridview.ShowCellErrors = false;
            this.users_datagridview.ShowCellToolTips = false;
            this.users_datagridview.ShowEditingIcon = false;
            this.users_datagridview.ShowRowErrors = false;
            this.users_datagridview.Size = new System.Drawing.Size(292, 242);
            this.users_datagridview.TabIndex = 9;
            // 
            // msg_textbox
            // 
            this.msg_textbox.BackColor = System.Drawing.Color.White;
            this.msg_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.msg_textbox.Location = new System.Drawing.Point(4, 254);
            this.msg_textbox.Name = "msg_textbox";
            this.msg_textbox.ReadOnly = true;
            this.msg_textbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.msg_textbox.Size = new System.Drawing.Size(292, 268);
            this.msg_textbox.TabIndex = 8;
            this.msg_textbox.TabStop = false;
            this.msg_textbox.Text = "";
            // 
            // left_right_split_label
            // 
            this.left_right_split_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.left_right_split_label.Location = new System.Drawing.Point(0, 0);
            this.left_right_split_label.Name = "left_right_split_label";
            this.left_right_split_label.Size = new System.Drawing.Size(2, 639);
            this.left_right_split_label.TabIndex = 0;
            this.left_right_split_label.Text = "label5";
            // 
            // send_msg_split_label
            // 
            this.send_msg_split_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.send_msg_split_label.Location = new System.Drawing.Point(0, 587);
            this.send_msg_split_label.Name = "send_msg_split_label";
            this.send_msg_split_label.Size = new System.Drawing.Size(300, 2);
            this.send_msg_split_label.TabIndex = 7;
            this.send_msg_split_label.Text = "label4";
            // 
            // msg_split_label
            // 
            this.msg_split_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.msg_split_label.Location = new System.Drawing.Point(0, 524);
            this.msg_split_label.Name = "msg_split_label";
            this.msg_split_label.Size = new System.Drawing.Size(300, 2);
            this.msg_split_label.TabIndex = 6;
            this.msg_split_label.Text = "label3";
            // 
            // user_msg_split_label
            // 
            this.user_msg_split_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.user_msg_split_label.Location = new System.Drawing.Point(0, 250);
            this.user_msg_split_label.Name = "user_msg_split_label";
            this.user_msg_split_label.Size = new System.Drawing.Size(300, 2);
            this.user_msg_split_label.TabIndex = 5;
            this.user_msg_split_label.Text = "label2";
            // 
            // send_msg_btn
            // 
            this.send_msg_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(125)))), ((int)(((byte)(254)))));
            this.send_msg_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.send_msg_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.send_msg_btn.ForeColor = System.Drawing.Color.White;
            this.send_msg_btn.Location = new System.Drawing.Point(219, 597);
            this.send_msg_btn.Name = "send_msg_btn";
            this.send_msg_btn.Size = new System.Drawing.Size(65, 32);
            this.send_msg_btn.TabIndex = 4;
            this.send_msg_btn.Text = "发 送";
            this.send_msg_btn.UseVisualStyleBackColor = false;
            this.send_msg_btn.Click += new System.EventHandler(this.send_msg_btn_Click);
            // 
            // users_combobox
            // 
            this.users_combobox.BackColor = System.Drawing.Color.White;
            this.users_combobox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.users_combobox.FormattingEnabled = true;
            this.users_combobox.ItemHeight = 20;
            this.users_combobox.Location = new System.Drawing.Point(11, 599);
            this.users_combobox.Name = "users_combobox";
            this.users_combobox.Size = new System.Drawing.Size(160, 28);
            this.users_combobox.TabIndex = 3;
            // 
            // send_msg_textbox
            // 
            this.send_msg_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.send_msg_textbox.Location = new System.Drawing.Point(4, 528);
            this.send_msg_textbox.Multiline = true;
            this.send_msg_textbox.Name = "send_msg_textbox";
            this.send_msg_textbox.Size = new System.Drawing.Size(292, 55);
            this.send_msg_textbox.TabIndex = 2;
            // 
            // toolbar_panel
            // 
            this.toolbar_panel.BackColor = System.Drawing.Color.White;
            this.toolbar_panel.Controls.Add(this.toolbar_record_btn);
            this.toolbar_panel.Controls.Add(this.toolbar_setting_btn);
            this.toolbar_panel.Controls.Add(this.toolbar_invite_btn);
            this.toolbar_panel.Controls.Add(this.toolbar_vnc_btn);
            this.toolbar_panel.Controls.Add(this.toolbar_cam_btn);
            this.toolbar_panel.Controls.Add(this.toolbar_speaker_btn);
            this.toolbar_panel.Controls.Add(this.toolbar_mic_btn);
            this.toolbar_panel.Location = new System.Drawing.Point(0, 612);
            this.toolbar_panel.Name = "toolbar_panel";
            this.toolbar_panel.Size = new System.Drawing.Size(900, 63);
            this.toolbar_panel.TabIndex = 3;
            // 
            // toolbar_record_btn
            // 
            this.toolbar_record_btn.BackColor = System.Drawing.Color.Transparent;
            this.toolbar_record_btn.BackgroundImage = global::meetingdemo_csharp.Properties.Resources.record_normal;
            this.toolbar_record_btn.FlatAppearance.BorderSize = 0;
            this.toolbar_record_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.toolbar_record_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.toolbar_record_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolbar_record_btn.Location = new System.Drawing.Point(488, 0);
            this.toolbar_record_btn.Name = "toolbar_record_btn";
            this.toolbar_record_btn.Size = new System.Drawing.Size(80, 63);
            this.toolbar_record_btn.TabIndex = 6;
            this.toolbar_record_btn.UseVisualStyleBackColor = false;
            this.toolbar_record_btn.Click += new System.EventHandler(this.toolbar_record_btn_Click);
            this.toolbar_record_btn.MouseLeave += new System.EventHandler(this.toolbar_record_btn_MouseLeave);
            this.toolbar_record_btn.MouseHover += new System.EventHandler(this.toolbar_record_btn_MouseHover);
            // 
            // toolbar_setting_btn
            // 
            this.toolbar_setting_btn.BackColor = System.Drawing.Color.Transparent;
            this.toolbar_setting_btn.BackgroundImage = global::meetingdemo_csharp.Properties.Resources.setting_normal;
            this.toolbar_setting_btn.FlatAppearance.BorderSize = 0;
            this.toolbar_setting_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.toolbar_setting_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.toolbar_setting_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolbar_setting_btn.Location = new System.Drawing.Point(648, 0);
            this.toolbar_setting_btn.Name = "toolbar_setting_btn";
            this.toolbar_setting_btn.Size = new System.Drawing.Size(80, 63);
            this.toolbar_setting_btn.TabIndex = 5;
            this.toolbar_setting_btn.UseVisualStyleBackColor = false;
            this.toolbar_setting_btn.Click += new System.EventHandler(this.toolbar_setting_btn_Click);
            this.toolbar_setting_btn.MouseLeave += new System.EventHandler(this.toolbar_setting_btn_MouseLeave);
            this.toolbar_setting_btn.MouseHover += new System.EventHandler(this.toolbar_setting_btn_MouseHover);
            // 
            // toolbar_invite_btn
            // 
            this.toolbar_invite_btn.BackColor = System.Drawing.Color.Transparent;
            this.toolbar_invite_btn.BackgroundImage = global::meetingdemo_csharp.Properties.Resources.invite_normal;
            this.toolbar_invite_btn.FlatAppearance.BorderSize = 0;
            this.toolbar_invite_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.toolbar_invite_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.toolbar_invite_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolbar_invite_btn.Location = new System.Drawing.Point(568, 0);
            this.toolbar_invite_btn.Name = "toolbar_invite_btn";
            this.toolbar_invite_btn.Size = new System.Drawing.Size(80, 63);
            this.toolbar_invite_btn.TabIndex = 4;
            this.toolbar_invite_btn.UseVisualStyleBackColor = false;
            this.toolbar_invite_btn.Click += new System.EventHandler(this.toolbar_invite_btn_Click);
            this.toolbar_invite_btn.MouseLeave += new System.EventHandler(this.toolbar_invite_btn_MouseLeave);
            this.toolbar_invite_btn.MouseHover += new System.EventHandler(this.toolbar_invite_btn_MouseHover);
            // 
            // toolbar_vnc_btn
            // 
            this.toolbar_vnc_btn.BackColor = System.Drawing.Color.Transparent;
            this.toolbar_vnc_btn.BackgroundImage = global::meetingdemo_csharp.Properties.Resources.share_normal;
            this.toolbar_vnc_btn.FlatAppearance.BorderSize = 0;
            this.toolbar_vnc_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.toolbar_vnc_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.toolbar_vnc_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolbar_vnc_btn.Location = new System.Drawing.Point(408, 0);
            this.toolbar_vnc_btn.Name = "toolbar_vnc_btn";
            this.toolbar_vnc_btn.Size = new System.Drawing.Size(80, 63);
            this.toolbar_vnc_btn.TabIndex = 3;
            this.toolbar_vnc_btn.UseVisualStyleBackColor = false;
            this.toolbar_vnc_btn.Click += new System.EventHandler(this.toolbar_vnc_btn_Click);
            this.toolbar_vnc_btn.MouseLeave += new System.EventHandler(this.toolbar_vnc_btn_MouseLeave);
            this.toolbar_vnc_btn.MouseHover += new System.EventHandler(this.toolbar_vnc_btn_MouseHover);
            // 
            // toolbar_cam_btn
            // 
            this.toolbar_cam_btn.BackColor = System.Drawing.Color.Transparent;
            this.toolbar_cam_btn.BackgroundImage = global::meetingdemo_csharp.Properties.Resources.cam_select;
            this.toolbar_cam_btn.FlatAppearance.BorderSize = 0;
            this.toolbar_cam_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.toolbar_cam_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.toolbar_cam_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolbar_cam_btn.Location = new System.Drawing.Point(328, 0);
            this.toolbar_cam_btn.Name = "toolbar_cam_btn";
            this.toolbar_cam_btn.Size = new System.Drawing.Size(80, 63);
            this.toolbar_cam_btn.TabIndex = 2;
            this.toolbar_cam_btn.UseVisualStyleBackColor = false;
            this.toolbar_cam_btn.Click += new System.EventHandler(this.toolbar_cam_btn_Click);
            this.toolbar_cam_btn.MouseLeave += new System.EventHandler(this.toolbar_cam_btn_MouseLeave);
            this.toolbar_cam_btn.MouseHover += new System.EventHandler(this.toolbar_cam_btn_MouseHover);
            // 
            // toolbar_speaker_btn
            // 
            this.toolbar_speaker_btn.BackColor = System.Drawing.Color.Transparent;
            this.toolbar_speaker_btn.BackgroundImage = global::meetingdemo_csharp.Properties.Resources.spk_normal;
            this.toolbar_speaker_btn.FlatAppearance.BorderSize = 0;
            this.toolbar_speaker_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.toolbar_speaker_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.toolbar_speaker_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolbar_speaker_btn.Location = new System.Drawing.Point(248, 0);
            this.toolbar_speaker_btn.Name = "toolbar_speaker_btn";
            this.toolbar_speaker_btn.Size = new System.Drawing.Size(80, 63);
            this.toolbar_speaker_btn.TabIndex = 1;
            this.toolbar_speaker_btn.UseVisualStyleBackColor = false;
            this.toolbar_speaker_btn.Click += new System.EventHandler(this.toolbar_speaker_btn_Click);
            this.toolbar_speaker_btn.MouseLeave += new System.EventHandler(this.toolbar_speaker_btn_MouseLeave);
            this.toolbar_speaker_btn.MouseHover += new System.EventHandler(this.toolbar_speaker_btn_MouseHover);
            // 
            // toolbar_mic_btn
            // 
            this.toolbar_mic_btn.BackColor = System.Drawing.Color.Transparent;
            this.toolbar_mic_btn.BackgroundImage = global::meetingdemo_csharp.Properties.Resources.mic_normal;
            this.toolbar_mic_btn.FlatAppearance.BorderSize = 0;
            this.toolbar_mic_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.toolbar_mic_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.toolbar_mic_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolbar_mic_btn.Location = new System.Drawing.Point(168, 0);
            this.toolbar_mic_btn.Name = "toolbar_mic_btn";
            this.toolbar_mic_btn.Size = new System.Drawing.Size(80, 63);
            this.toolbar_mic_btn.TabIndex = 0;
            this.toolbar_mic_btn.UseVisualStyleBackColor = false;
            this.toolbar_mic_btn.Click += new System.EventHandler(this.toolbar_mic_btn_Click);
            this.toolbar_mic_btn.MouseLeave += new System.EventHandler(this.toolbar_mic_btn_MouseLeave);
            this.toolbar_mic_btn.MouseHover += new System.EventHandler(this.toolbar_mic_btn_MouseHover);
            // 
            // tab_panel
            // 
            this.tab_panel.BackColor = System.Drawing.Color.White;
            this.tab_panel.Controls.Add(this.group_label);
            this.tab_panel.Location = new System.Drawing.Point(0, 36);
            this.tab_panel.Name = "tab_panel";
            this.tab_panel.Size = new System.Drawing.Size(900, 24);
            this.tab_panel.TabIndex = 4;
            // 
            // group_label
            // 
            this.group_label.Location = new System.Drawing.Point(769, 4);
            this.group_label.Name = "group_label";
            this.group_label.Size = new System.Drawing.Size(120, 16);
            this.group_label.TabIndex = 0;
            this.group_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // video_panel
            // 
            this.video_panel.Location = new System.Drawing.Point(0, 60);
            this.video_panel.Name = "video_panel";
            this.video_panel.Size = new System.Drawing.Size(900, 552);
            this.video_panel.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 675);
            this.Controls.Add(this.video_panel);
            this.Controls.Add(this.tab_panel);
            this.Controls.Add(this.toolbar_panel);
            this.Controls.Add(this.main_right_panel);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.Controls.SetChildIndex(this.main_right_panel, 0);
            this.Controls.SetChildIndex(this.toolbar_panel, 0);
            this.Controls.SetChildIndex(this.tab_panel, 0);
            this.Controls.SetChildIndex(this.video_panel, 0);
            this.main_right_panel.ResumeLayout(false);
            this.main_right_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.users_datagridview)).EndInit();
            this.toolbar_panel.ResumeLayout(false);
            this.tab_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel main_right_panel;
        private System.Windows.Forms.Panel toolbar_panel;
        private System.Windows.Forms.Button send_msg_btn;
        private System.Windows.Forms.ComboBox users_combobox;
        private System.Windows.Forms.TextBox send_msg_textbox;
        private System.Windows.Forms.Button toolbar_mic_btn;
        private System.Windows.Forms.Button toolbar_setting_btn;
        private System.Windows.Forms.Button toolbar_invite_btn;
        private System.Windows.Forms.Button toolbar_vnc_btn;
        private System.Windows.Forms.Button toolbar_cam_btn;
        private System.Windows.Forms.Button toolbar_speaker_btn;
        private System.Windows.Forms.Panel tab_panel;
        private System.Windows.Forms.Label group_label;
        private System.Windows.Forms.Panel video_panel;
        private System.Windows.Forms.Label send_msg_split_label;
        private System.Windows.Forms.Label msg_split_label;
        private System.Windows.Forms.Label user_msg_split_label;
        private System.Windows.Forms.Label left_right_split_label;
        private System.Windows.Forms.RichTextBox msg_textbox;
        private System.Windows.Forms.DataGridView users_datagridview;
        private System.Windows.Forms.Button toolbar_record_btn;
    }
}