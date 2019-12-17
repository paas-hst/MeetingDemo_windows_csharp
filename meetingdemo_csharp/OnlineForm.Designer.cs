namespace meetingdemo_csharp
{
    partial class OnlineForm
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
            this.group_textbox = new System.Windows.Forms.TextBox();
            this.online_listview = new System.Windows.Forms.ListView();
            this.join_btn = new System.Windows.Forms.Button();
            this.group_textbox_panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // group_textbox
            // 
            this.group_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.group_textbox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.group_textbox.Location = new System.Drawing.Point(25, 71);
            this.group_textbox.Name = "group_textbox";
            this.group_textbox.Size = new System.Drawing.Size(250, 19);
            this.group_textbox.TabIndex = 3;
            this.group_textbox.Enter += new System.EventHandler(this.group_textbox_Enter);
            this.group_textbox.Leave += new System.EventHandler(this.group_textbox_Leave);
            // 
            // online_listview
            // 
            this.online_listview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.online_listview.HideSelection = false;
            this.online_listview.Location = new System.Drawing.Point(20, 122);
            this.online_listview.Name = "online_listview";
            this.online_listview.Size = new System.Drawing.Size(260, 386);
            this.online_listview.TabIndex = 2;
            this.online_listview.UseCompatibleStateImageBehavior = false;
            this.online_listview.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.online_listview_ItemChecked);
            // 
            // join_btn
            // 
            this.join_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(125)))), ((int)(((byte)(254)))));
            this.join_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.join_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.join_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.join_btn.Location = new System.Drawing.Point(20, 534);
            this.join_btn.Name = "join_btn";
            this.join_btn.Size = new System.Drawing.Size(260, 40);
            this.join_btn.TabIndex = 1;
            this.join_btn.Text = "加入分组";
            this.join_btn.UseVisualStyleBackColor = false;
            this.join_btn.Click += new System.EventHandler(this.join_btn_Click);
            // 
            // group_textbox_panel
            // 
            this.group_textbox_panel.BackColor = System.Drawing.Color.White;
            this.group_textbox_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.group_textbox_panel.Location = new System.Drawing.Point(20, 62);
            this.group_textbox_panel.Name = "group_textbox_panel";
            this.group_textbox_panel.Size = new System.Drawing.Size(260, 36);
            this.group_textbox_panel.TabIndex = 4;
            // 
            // OnlineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(300, 600);
            this.Controls.Add(this.group_textbox);
            this.Controls.Add(this.group_textbox_panel);
            this.Controls.Add(this.join_btn);
            this.Controls.Add(this.online_listview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OnlineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Online";
            this.Load += new System.EventHandler(this.OnlineForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox group_textbox;
        private System.Windows.Forms.ListView online_listview;
        private System.Windows.Forms.Button join_btn;
        private System.Windows.Forms.Panel group_textbox_panel;
    }
}