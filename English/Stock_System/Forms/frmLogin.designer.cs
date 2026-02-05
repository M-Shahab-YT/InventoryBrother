namespace Stock_System.Forms
{
    partial class frmLogin
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
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnlogin = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnlogin)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(322, 152);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(371, 39);
            this.txtUserName.TabIndex = 13;
            this.txtUserName.DoubleClick += new System.EventHandler(this.txtUserName_DoubleClick);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(322, 196);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(371, 39);
            this.txtPassword.TabIndex = 14;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(202, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(202, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 23);
            this.label3.TabIndex = 24;
            this.label3.Text = "Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(378, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 32);
            this.label7.TabIndex = 26;
            this.label7.Text = "Login Form";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Stock_System.Properties.Resources.Polaris_Logo1;
            this.pictureBox2.Location = new System.Drawing.Point(12, 355);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(146, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCancel.Location = new System.Drawing.Point(443, 240);
            this.btnCancel.Name = "btnCancel";
            // 
            // 
            // 
            this.btnCancel.RootElement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCancel.Size = new System.Drawing.Size(117, 44);
            this.btnCancel.TabIndex = 1681;
            this.btnCancel.Text = "CLOSE";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnCancel.GetChildAt(0))).Text = "CLOSE";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnCancel.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnCancel.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnCancel.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnCancel.GetChildAt(0).GetChildAt(0))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnCancel.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            // 
            // btnlogin
            // 
            this.btnlogin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.ForeColor = System.Drawing.Color.White;
            this.btnlogin.Location = new System.Drawing.Point(322, 240);
            this.btnlogin.Name = "btnlogin";
            // 
            // 
            // 
            this.btnlogin.RootElement.ForeColor = System.Drawing.Color.White;
            this.btnlogin.Size = new System.Drawing.Size(117, 44);
            this.btnlogin.TabIndex = 1682;
            this.btnlogin.Text = "LOGIN";
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnlogin.GetChildAt(0))).Text = "LOGIN";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnlogin.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnlogin.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnlogin.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnlogin.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(460, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 23);
            this.label1.TabIndex = 1683;
            this.label1.Text = "Powered By : Yakclick Technology Services";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(232, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(427, 27);
            this.label4.TabIndex = 1684;
            this.label4.Text = "INVENTORY MANAGEMENT SYSTEM";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(43, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 55);
            this.button1.TabIndex = 1685;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(836, 414);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Form";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnlogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnlogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}