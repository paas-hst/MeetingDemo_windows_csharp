namespace meetingdemo_csharp
{
    partial class AppSettingForm
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
            this.default_app_radio = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.app_id_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.user_app_radio = new System.Windows.Forms.RadioButton();
            this.app_secret_textbox = new System.Windows.Forms.TextBox();
            this.default_app_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.user_server_radio = new System.Windows.Forms.RadioButton();
            this.default_server_radio = new System.Windows.Forms.RadioButton();
            this.server_addr_textbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.app_setting_cancel_btn = new System.Windows.Forms.Button();
            this.app_setting_ok_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.force_login_no_radio = new System.Windows.Forms.RadioButton();
            this.force_login_yes_radio = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // default_app_radio
            // 
            this.default_app_radio.AutoSize = true;
            this.default_app_radio.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.default_app_radio.Location = new System.Drawing.Point(3, 6);
            this.default_app_radio.Name = "default_app_radio";
            this.default_app_radio.Size = new System.Drawing.Size(38, 21);
            this.default_app_radio.TabIndex = 2;
            this.default_app_radio.TabStop = true;
            this.default_app_radio.Text = "是";
            this.default_app_radio.UseVisualStyleBackColor = true;
            this.default_app_radio.Click += new System.EventHandler(this.default_app_radio_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(70, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "App ID";
            // 
            // app_id_textbox
            // 
            this.app_id_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.app_id_textbox.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.app_id_textbox.Location = new System.Drawing.Point(140, 93);
            this.app_id_textbox.Name = "app_id_textbox";
            this.app_id_textbox.Size = new System.Drawing.Size(360, 27);
            this.app_id_textbox.TabIndex = 4;
            this.app_id_textbox.WordWrap = false;
            this.app_id_textbox.TextChanged += new System.EventHandler(this.app_id_textbox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(47, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "App Secret";
            // 
            // user_app_radio
            // 
            this.user_app_radio.AutoSize = true;
            this.user_app_radio.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.user_app_radio.Location = new System.Drawing.Point(64, 6);
            this.user_app_radio.Name = "user_app_radio";
            this.user_app_radio.Size = new System.Drawing.Size(38, 21);
            this.user_app_radio.TabIndex = 6;
            this.user_app_radio.TabStop = true;
            this.user_app_radio.Text = "否";
            this.user_app_radio.UseVisualStyleBackColor = true;
            this.user_app_radio.Click += new System.EventHandler(this.user_app_radio_Click);
            // 
            // app_secret_textbox
            // 
            this.app_secret_textbox.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.app_secret_textbox.Location = new System.Drawing.Point(140, 133);
            this.app_secret_textbox.Name = "app_secret_textbox";
            this.app_secret_textbox.Size = new System.Drawing.Size(360, 27);
            this.app_secret_textbox.TabIndex = 7;
            this.app_secret_textbox.TextChanged += new System.EventHandler(this.app_secret_textbox_TextChanged);
            // 
            // default_app_label
            // 
            this.default_app_label.AutoSize = true;
            this.default_app_label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.default_app_label.Location = new System.Drawing.Point(39, 60);
            this.default_app_label.Name = "default_app_label";
            this.default_app_label.Size = new System.Drawing.Size(80, 17);
            this.default_app_label.TabIndex = 8;
            this.default_app_label.Text = "使用默认应用";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(27, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "使用默认服务器";
            // 
            // user_server_radio
            // 
            this.user_server_radio.AutoSize = true;
            this.user_server_radio.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.user_server_radio.Location = new System.Drawing.Point(67, 6);
            this.user_server_radio.Name = "user_server_radio";
            this.user_server_radio.Size = new System.Drawing.Size(38, 21);
            this.user_server_radio.TabIndex = 10;
            this.user_server_radio.TabStop = true;
            this.user_server_radio.Text = "否";
            this.user_server_radio.UseVisualStyleBackColor = true;
            this.user_server_radio.Click += new System.EventHandler(this.user_server_radio_Click);
            // 
            // default_server_radio
            // 
            this.default_server_radio.AutoSize = true;
            this.default_server_radio.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.default_server_radio.Location = new System.Drawing.Point(3, 6);
            this.default_server_radio.Name = "default_server_radio";
            this.default_server_radio.Size = new System.Drawing.Size(38, 21);
            this.default_server_radio.TabIndex = 9;
            this.default_server_radio.TabStop = true;
            this.default_server_radio.Text = "是";
            this.default_server_radio.UseVisualStyleBackColor = true;
            this.default_server_radio.Click += new System.EventHandler(this.default_server_radio_Click);
            // 
            // server_addr_textbox
            // 
            this.server_addr_textbox.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.server_addr_textbox.Location = new System.Drawing.Point(140, 229);
            this.server_addr_textbox.Name = "server_addr_textbox";
            this.server_addr_textbox.Size = new System.Drawing.Size(360, 27);
            this.server_addr_textbox.TabIndex = 13;
            this.server_addr_textbox.TextChanged += new System.EventHandler(this.server_addr_textbox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(22, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Server Address";
            // 
            // app_setting_cancel_btn
            // 
            this.app_setting_cancel_btn.BackColor = System.Drawing.Color.White;
            this.app_setting_cancel_btn.BackgroundImage = global::meetingdemo_csharp.Properties.Resources.btn_bg;
            this.app_setting_cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.app_setting_cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.app_setting_cancel_btn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.app_setting_cancel_btn.Location = new System.Drawing.Point(190, 323);
            this.app_setting_cancel_btn.Name = "app_setting_cancel_btn";
            this.app_setting_cancel_btn.Size = new System.Drawing.Size(65, 32);
            this.app_setting_cancel_btn.TabIndex = 14;
            this.app_setting_cancel_btn.Text = "取 消";
            this.app_setting_cancel_btn.UseVisualStyleBackColor = false;
            // 
            // app_setting_ok_btn
            // 
            this.app_setting_ok_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(125)))), ((int)(((byte)(254)))));
            this.app_setting_ok_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.app_setting_ok_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.app_setting_ok_btn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.app_setting_ok_btn.ForeColor = System.Drawing.Color.White;
            this.app_setting_ok_btn.Location = new System.Drawing.Point(285, 323);
            this.app_setting_ok_btn.Name = "app_setting_ok_btn";
            this.app_setting_ok_btn.Size = new System.Drawing.Size(65, 32);
            this.app_setting_ok_btn.TabIndex = 15;
            this.app_setting_ok_btn.Text = "确 定";
            this.app_setting_ok_btn.UseVisualStyleBackColor = false;
            this.app_setting_ok_btn.Click += new System.EventHandler(this.app_setting_ok_btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.user_app_radio);
            this.panel1.Controls.Add(this.default_app_radio);
            this.panel1.Location = new System.Drawing.Point(140, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 33);
            this.panel1.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.user_server_radio);
            this.panel2.Controls.Add(this.default_server_radio);
            this.panel2.Location = new System.Drawing.Point(140, 186);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 33);
            this.panel2.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(64, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "强制登录";
            // 
            // force_login_no_radio
            // 
            this.force_login_no_radio.AutoSize = true;
            this.force_login_no_radio.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.force_login_no_radio.Location = new System.Drawing.Point(67, 6);
            this.force_login_no_radio.Name = "force_login_no_radio";
            this.force_login_no_radio.Size = new System.Drawing.Size(38, 21);
            this.force_login_no_radio.TabIndex = 10;
            this.force_login_no_radio.TabStop = true;
            this.force_login_no_radio.Text = "否";
            this.force_login_no_radio.UseVisualStyleBackColor = true;
            this.force_login_no_radio.CheckedChanged += new System.EventHandler(this.force_login_no_radio_CheckedChanged);
            // 
            // force_login_yes_radio
            // 
            this.force_login_yes_radio.AutoSize = true;
            this.force_login_yes_radio.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.force_login_yes_radio.Location = new System.Drawing.Point(3, 6);
            this.force_login_yes_radio.Name = "force_login_yes_radio";
            this.force_login_yes_radio.Size = new System.Drawing.Size(38, 21);
            this.force_login_yes_radio.TabIndex = 9;
            this.force_login_yes_radio.TabStop = true;
            this.force_login_yes_radio.Text = "是";
            this.force_login_yes_radio.UseVisualStyleBackColor = true;
            this.force_login_yes_radio.CheckedChanged += new System.EventHandler(this.force_login_yes_radio_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.force_login_no_radio);
            this.panel3.Controls.Add(this.force_login_yes_radio);
            this.panel3.Location = new System.Drawing.Point(140, 272);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(360, 33);
            this.panel3.TabIndex = 19;
            // 
            // AppSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(540, 370);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.app_setting_ok_btn);
            this.Controls.Add(this.app_setting_cancel_btn);
            this.Controls.Add(this.server_addr_textbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.default_app_label);
            this.Controls.Add(this.app_secret_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.app_id_textbox);
            this.Controls.Add(this.label1);
            this.Name = "AppSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AppSettingForm";
            this.Load += new System.EventHandler(this.AppSettingForm_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.app_id_textbox, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.app_secret_textbox, 0);
            this.Controls.SetChildIndex(this.default_app_label, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.server_addr_textbox, 0);
            this.Controls.SetChildIndex(this.app_setting_cancel_btn, 0);
            this.Controls.SetChildIndex(this.app_setting_ok_btn, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton default_app_radio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox app_id_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton user_app_radio;
        private System.Windows.Forms.TextBox app_secret_textbox;
        private System.Windows.Forms.Label default_app_label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton user_server_radio;
        private System.Windows.Forms.RadioButton default_server_radio;
        private System.Windows.Forms.TextBox server_addr_textbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button app_setting_cancel_btn;
        private System.Windows.Forms.Button app_setting_ok_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton force_login_no_radio;
        private System.Windows.Forms.RadioButton force_login_yes_radio;
        private System.Windows.Forms.Panel panel3;
    }
}