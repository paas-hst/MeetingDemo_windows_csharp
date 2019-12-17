namespace meetingdemo_csharp
{
    partial class LoginForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.user_textbox = new System.Windows.Forms.TextBox();
            this.login_btn = new System.Windows.Forms.Button();
            this.label_login = new System.Windows.Forms.Label();
            this.user_textbox_panel = new System.Windows.Forms.Panel();
            this.user_textbox_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // user_textbox
            // 
            this.user_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.user_textbox.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.user_textbox.Location = new System.Drawing.Point(4, 11);
            this.user_textbox.Name = "user_textbox";
            this.user_textbox.Size = new System.Drawing.Size(470, 27);
            this.user_textbox.TabIndex = 0;
            this.user_textbox.Enter += new System.EventHandler(this.user_textbox_Enter);
            this.user_textbox.Leave += new System.EventHandler(this.user_textbox_Leave);
            // 
            // login_btn
            // 
            this.login_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(125)))), ((int)(((byte)(254)))));
            this.login_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_btn.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.login_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.login_btn.Location = new System.Drawing.Point(120, 296);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(480, 50);
            this.login_btn.TabIndex = 1;
            this.login_btn.Text = "登录";
            this.login_btn.UseVisualStyleBackColor = false;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_login.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_login.Location = new System.Drawing.Point(315, 95);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(90, 46);
            this.label_login.TabIndex = 2;
            this.label_login.Text = "登录";
            // 
            // user_textbox_panel
            // 
            this.user_textbox_panel.BackColor = System.Drawing.Color.White;
            this.user_textbox_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.user_textbox_panel.Controls.Add(this.user_textbox);
            this.user_textbox_panel.Location = new System.Drawing.Point(120, 206);
            this.user_textbox_panel.Name = "user_textbox_panel";
            this.user_textbox_panel.Size = new System.Drawing.Size(480, 50);
            this.user_textbox_panel.TabIndex = 3;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(78)))));
            this.ClientSize = new System.Drawing.Size(720, 480);
            this.ControlBox = false;
            this.Controls.Add(this.user_textbox_panel);
            this.Controls.Add(this.label_login);
            this.Controls.Add(this.login_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.user_textbox_panel.ResumeLayout(false);
            this.user_textbox_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox user_textbox;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.Panel user_textbox_panel;
    }
}

