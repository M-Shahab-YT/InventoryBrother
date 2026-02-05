namespace Stock_System.Forms
{
    partial class frmPrinterSetting
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
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStore = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTerminalPrinterName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLaserPrinterName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkPPreview = new System.Windows.Forms.CheckBox();
            this.lstPrinterList = new System.Windows.Forms.ListView();
            this.ID = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSave.Location = new System.Drawing.Point(251, 305);
            this.btnSave.Name = "btnSave";
            // 
            // 
            // 
            this.btnSave.RootElement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSave.Size = new System.Drawing.Size(96, 42);
            this.btnSave.TabIndex = 1623;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Text = "Save";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label2.Location = new System.Drawing.Point(47, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 18);
            this.label2.TabIndex = 1622;
            this.label2.Text = "Store/Branch:";
            // 
            // cmbStore
            // 
            this.cmbStore.BackColor = System.Drawing.SystemColors.Highlight;
            this.cmbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.cmbStore.FormattingEnabled = true;
            this.cmbStore.Items.AddRange(new object[] {
            "Cash",
            "Loan",
            "Cash and Loan",
            "Bank"});
            this.cmbStore.Location = new System.Drawing.Point(251, 159);
            this.cmbStore.Name = "cmbStore";
            this.cmbStore.Size = new System.Drawing.Size(289, 32);
            this.cmbStore.TabIndex = 1621;
            this.cmbStore.SelectionChangeCommitted += new System.EventHandler(this.cmbStore_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label1.Location = new System.Drawing.Point(47, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 18);
            this.label1.TabIndex = 1620;
            this.label1.Text = "Terminal Printer Name";
            // 
            // txtTerminalPrinterName
            // 
            this.txtTerminalPrinterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTerminalPrinterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTerminalPrinterName.ForeColor = System.Drawing.Color.YellowGreen;
            this.txtTerminalPrinterName.Location = new System.Drawing.Point(251, 270);
            this.txtTerminalPrinterName.Name = "txtTerminalPrinterName";
            this.txtTerminalPrinterName.Size = new System.Drawing.Size(288, 29);
            this.txtTerminalPrinterName.TabIndex = 1619;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label6.Location = new System.Drawing.Point(47, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 18);
            this.label6.TabIndex = 1618;
            this.label6.Text = "Laser Printer Name";
            // 
            // txtLaserPrinterName
            // 
            this.txtLaserPrinterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLaserPrinterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLaserPrinterName.ForeColor = System.Drawing.Color.YellowGreen;
            this.txtLaserPrinterName.Location = new System.Drawing.Point(251, 235);
            this.txtLaserPrinterName.Name = "txtLaserPrinterName";
            this.txtLaserPrinterName.Size = new System.Drawing.Size(288, 29);
            this.txtLaserPrinterName.TabIndex = 1617;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label12.Location = new System.Drawing.Point(47, 204);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 18);
            this.label12.TabIndex = 1616;
            this.label12.Text = "User:";
            // 
            // cmbUser
            // 
            this.cmbUser.BackColor = System.Drawing.SystemColors.Highlight;
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Items.AddRange(new object[] {
            "Cash",
            "Loan",
            "Cash and Loan",
            "Bank"});
            this.cmbUser.Location = new System.Drawing.Point(251, 197);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(289, 32);
            this.cmbUser.TabIndex = 1615;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            this.label14.Location = new System.Drawing.Point(39, 102);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(202, 37);
            this.label14.TabIndex = 1614;
            this.label14.Text = "PRINTER SETUP";
            // 
            // chkPPreview
            // 
            this.chkPPreview.AutoSize = true;
            this.chkPPreview.Location = new System.Drawing.Point(421, 305);
            this.chkPPreview.Name = "chkPPreview";
            this.chkPPreview.Size = new System.Drawing.Size(118, 17);
            this.chkPPreview.TabIndex = 1624;
            this.chkPPreview.Text = "Show Print Preview";
            this.chkPPreview.UseVisualStyleBackColor = true;
            // 
            // lstPrinterList
            // 
            this.lstPrinterList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader17,
            this.columnHeader1});
            this.lstPrinterList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPrinterList.FullRowSelect = true;
            this.lstPrinterList.GridLines = true;
            this.lstPrinterList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstPrinterList.Location = new System.Drawing.Point(46, 353);
            this.lstPrinterList.Name = "lstPrinterList";
            this.lstPrinterList.ShowItemToolTips = true;
            this.lstPrinterList.Size = new System.Drawing.Size(1000, 319);
            this.lstPrinterList.TabIndex = 1625;
            this.lstPrinterList.UseCompatibleStateImageBehavior = false;
            this.lstPrinterList.View = System.Windows.Forms.View.Details;
            this.lstPrinterList.DoubleClick += new System.EventHandler(this.lstPrinterList_DoubleClick);
            // 
            // ID
            // 
            this.ID.Text = "No";
            this.ID.Width = 0;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Store";
            this.columnHeader9.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "User";
            this.columnHeader10.Width = 150;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Laser Printer Name";
            this.columnHeader11.Width = 300;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Terminal Printer Name";
            this.columnHeader17.Width = 200;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Show Print Preview";
            this.columnHeader1.Width = 150;
            // 
            // frmPrinterSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1128, 902);
            this.Controls.Add(this.lstPrinterList);
            this.Controls.Add(this.chkPPreview);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbStore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTerminalPrinterName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLaserPrinterName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.label14);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPrinterSetting";
            this.Text = "frmPrinterSetting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrinterSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTerminalPrinterName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLaserPrinterName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkPPreview;
        private System.Windows.Forms.ListView lstPrinterList;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}