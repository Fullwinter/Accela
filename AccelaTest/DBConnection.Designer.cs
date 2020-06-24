namespace AccelaTest
{
    partial class DBConnection
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
            this.bCancel = new System.Windows.Forms.Button();
            this.bAccept = new System.Windows.Forms.Button();
            this.cBWindowsCredentials = new System.Windows.Forms.CheckBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbDB = new System.Windows.Forms.TextBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.lpass = new System.Windows.Forms.Label();
            this.luser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(122, 137);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 21;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bAccept
            // 
            this.bAccept.Location = new System.Drawing.Point(12, 137);
            this.bAccept.Name = "bAccept";
            this.bAccept.Size = new System.Drawing.Size(64, 23);
            this.bAccept.TabIndex = 20;
            this.bAccept.Text = "Accept";
            this.bAccept.UseVisualStyleBackColor = true;
            this.bAccept.Click += new System.EventHandler(this.bAccept_Click);
            // 
            // cBWindowsCredentials
            // 
            this.cBWindowsCredentials.AutoSize = true;
            this.cBWindowsCredentials.Checked = true;
            this.cBWindowsCredentials.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBWindowsCredentials.Location = new System.Drawing.Point(53, 61);
            this.cBWindowsCredentials.Name = "cBWindowsCredentials";
            this.cBWindowsCredentials.Size = new System.Drawing.Size(125, 17);
            this.cBWindowsCredentials.TabIndex = 19;
            this.cBWindowsCredentials.Text = "Windows Credentials";
            this.cBWindowsCredentials.UseVisualStyleBackColor = true;
            this.cBWindowsCredentials.CheckedChanged += new System.EventHandler(this.cBWindowsCredentials_CheckedChanged);
            // 
            // tbPassword
            // 
            this.tbPassword.Enabled = false;
            this.tbPassword.Location = new System.Drawing.Point(97, 111);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(100, 20);
            this.tbPassword.TabIndex = 18;
            // 
            // tbUsername
            // 
            this.tbUsername.Enabled = false;
            this.tbUsername.Location = new System.Drawing.Point(97, 85);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(100, 20);
            this.tbUsername.TabIndex = 17;
            // 
            // tbDB
            // 
            this.tbDB.Location = new System.Drawing.Point(97, 32);
            this.tbDB.Name = "tbDB";
            this.tbDB.Size = new System.Drawing.Size(100, 20);
            this.tbDB.TabIndex = 16;
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(97, 6);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(100, 20);
            this.tbIP.TabIndex = 15;
            // 
            // lpass
            // 
            this.lpass.AutoSize = true;
            this.lpass.Location = new System.Drawing.Point(12, 114);
            this.lpass.Name = "lpass";
            this.lpass.Size = new System.Drawing.Size(53, 13);
            this.lpass.TabIndex = 14;
            this.lpass.Text = "Password";
            // 
            // luser
            // 
            this.luser.AutoSize = true;
            this.luser.Location = new System.Drawing.Point(12, 86);
            this.luser.Name = "luser";
            this.luser.Size = new System.Drawing.Size(55, 13);
            this.luser.TabIndex = 13;
            this.luser.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Database Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Sql Server IP";
            // 
            // DBConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 168);
            this.ControlBox = false;
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bAccept);
            this.Controls.Add(this.cBWindowsCredentials);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.tbDB);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.lpass);
            this.Controls.Add(this.luser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "DBConnection";
            this.Text = "Connect to the DB";
            this.Load += new System.EventHandler(this.DBConnection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bAccept;
        private System.Windows.Forms.CheckBox cBWindowsCredentials;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbDB;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Label lpass;
        private System.Windows.Forms.Label luser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

