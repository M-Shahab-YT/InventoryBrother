namespace Stock_System.Forms
{
    partial class frmSaleReportUpdate
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
            this.dgAccount = new System.Windows.Forms.DataGridView();
            this.Invoice_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CashirOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrencyName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrencyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.SystemDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalCr = new System.Windows.Forms.Label();
            this.lblTotalDr = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGroupReport = new Telerik.WinControls.UI.RadButton();
            this.btnReport = new Telerik.WinControls.UI.RadButton();
            this.cmbPaymentAccount = new System.Windows.Forms.ComboBox();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.lib1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lib2 = new System.Windows.Forms.Label();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.btnView = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccount)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGroupReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgAccount
            // 
            this.dgAccount.AllowUserToAddRows = false;
            this.dgAccount.AllowUserToDeleteRows = false;
            this.dgAccount.AllowUserToResizeColumns = false;
            this.dgAccount.AllowUserToResizeRows = false;
            this.dgAccount.ColumnHeadersHeight = 41;
            this.dgAccount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Invoice_No,
            this.StoreName,
            this.CashirOB,
            this.CurrencyName1,
            this.ID,
            this.TotalDebit,
            this.TotalCredit,
            this.CurrencyName,
            this.Balance,
            this.StatusB,
            this.UserName,
            this.Column1,
            this.SystemDate});
            this.dgAccount.Location = new System.Drawing.Point(15, 211);
            this.dgAccount.Name = "dgAccount";
            this.dgAccount.ReadOnly = true;
            this.dgAccount.RowHeadersVisible = false;
            this.dgAccount.RowTemplate.Height = 40;
            this.dgAccount.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAccount.Size = new System.Drawing.Size(1891, 659);
            this.dgAccount.TabIndex = 1754;
            // 
            // Invoice_No
            // 
            this.Invoice_No.DataPropertyName = "ID";
            this.Invoice_No.HeaderText = "ID";
            this.Invoice_No.Name = "Invoice_No";
            this.Invoice_No.ReadOnly = true;
            // 
            // StoreName
            // 
            this.StoreName.DataPropertyName = "AccountID";
            this.StoreName.HeaderText = "AccountID";
            this.StoreName.Name = "StoreName";
            this.StoreName.ReadOnly = true;
            this.StoreName.Visible = false;
            this.StoreName.Width = 200;
            // 
            // CashirOB
            // 
            this.CashirOB.DataPropertyName = "AccountName";
            this.CashirOB.HeaderText = "Account Name";
            this.CashirOB.Name = "CashirOB";
            this.CashirOB.ReadOnly = true;
            this.CashirOB.Width = 460;
            // 
            // CurrencyName1
            // 
            this.CurrencyName1.DataPropertyName = "CurrencyName";
            this.CurrencyName1.HeaderText = "Currency";
            this.CurrencyName1.Name = "CurrencyName1";
            this.CurrencyName1.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "Date";
            this.ID.HeaderText = "Date";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // TotalDebit
            // 
            this.TotalDebit.DataPropertyName = "EntryReference";
            this.TotalDebit.HeaderText = "Entry Reference";
            this.TotalDebit.Name = "TotalDebit";
            this.TotalDebit.ReadOnly = true;
            this.TotalDebit.Width = 235;
            // 
            // TotalCredit
            // 
            this.TotalCredit.DataPropertyName = "EntryReferenceNumber";
            this.TotalCredit.HeaderText = "Reference Number";
            this.TotalCredit.Name = "TotalCredit";
            this.TotalCredit.ReadOnly = true;
            this.TotalCredit.Width = 150;
            // 
            // CurrencyName
            // 
            this.CurrencyName.DataPropertyName = "Remarks";
            this.CurrencyName.HeaderText = "Remarks";
            this.CurrencyName.Name = "CurrencyName";
            this.CurrencyName.ReadOnly = true;
            this.CurrencyName.Width = 290;
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "DR";
            this.Balance.HeaderText = "DR";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            // 
            // StatusB
            // 
            this.StatusB.DataPropertyName = "CR";
            this.StatusB.HeaderText = "CR";
            this.StatusB.Name = "StatusB";
            this.StatusB.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "User Name";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 145;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Detail";
            this.Column1.HeaderText = "Detail";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // SystemDate
            // 
            this.SystemDate.DataPropertyName = "SystemDate";
            this.SystemDate.HeaderText = "SystemDate";
            this.SystemDate.Name = "SystemDate";
            this.SystemDate.ReadOnly = true;
            this.SystemDate.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Orange;
            this.label14.Location = new System.Drawing.Point(12, 167);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(134, 24);
            this.label14.TabIndex = 1757;
            this.label14.Text = "CASH FLOW";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(1501, 911);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 17);
            this.label7.TabIndex = 1763;
            this.label7.Text = "Total:";
            // 
            // lblTotalCr
            // 
            this.lblTotalCr.AutoSize = true;
            this.lblTotalCr.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCr.ForeColor = System.Drawing.Color.Red;
            this.lblTotalCr.Location = new System.Drawing.Point(1734, 911);
            this.lblTotalCr.Name = "lblTotalCr";
            this.lblTotalCr.Size = new System.Drawing.Size(15, 17);
            this.lblTotalCr.TabIndex = 1762;
            this.lblTotalCr.Text = "0";
            // 
            // lblTotalDr
            // 
            this.lblTotalDr.AutoSize = true;
            this.lblTotalDr.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDr.ForeColor = System.Drawing.Color.Red;
            this.lblTotalDr.Location = new System.Drawing.Point(1629, 911);
            this.lblTotalDr.Name = "lblTotalDr";
            this.lblTotalDr.Size = new System.Drawing.Size(15, 17);
            this.lblTotalDr.TabIndex = 1761;
            this.lblTotalDr.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGroupReport);
            this.groupBox1.Controls.Add(this.btnReport);
            this.groupBox1.Controls.Add(this.cmbPaymentAccount);
            this.groupBox1.Controls.Add(this.dtfrom);
            this.groupBox1.Controls.Add(this.lib1);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.lib2);
            this.groupBox1.Controls.Add(this.dtto);
            this.groupBox1.Controls.Add(this.btnView);
            this.groupBox1.Location = new System.Drawing.Point(16, 889);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1462, 57);
            this.groupBox1.TabIndex = 1760;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By Date";
            // 
            // btnGroupReport
            // 
            this.btnGroupReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroupReport.ForeColor = System.Drawing.Color.White;
            this.btnGroupReport.Location = new System.Drawing.Point(1291, 15);
            this.btnGroupReport.Name = "btnGroupReport";
            // 
            // 
            // 
            this.btnGroupReport.RootElement.ForeColor = System.Drawing.Color.White;
            this.btnGroupReport.Size = new System.Drawing.Size(164, 36);
            this.btnGroupReport.TabIndex = 3255;
            this.btnGroupReport.Text = "Group Report";
            this.btnGroupReport.Click += new System.EventHandler(this.btnGroupReport_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnGroupReport.GetChildAt(0))).Text = "Group Report";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnGroupReport.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnGroupReport.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnGroupReport.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnGroupReport.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Location = new System.Drawing.Point(1170, 15);
            this.btnReport.Name = "btnReport";
            // 
            // 
            // 
            this.btnReport.RootElement.ForeColor = System.Drawing.Color.White;
            this.btnReport.Size = new System.Drawing.Size(118, 36);
            this.btnReport.TabIndex = 1756;
            this.btnReport.Text = "Report";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnReport.GetChildAt(0))).Text = "Report";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnReport.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnReport.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnReport.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnReport.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            // 
            // cmbPaymentAccount
            // 
            this.cmbPaymentAccount.BackColor = System.Drawing.Color.Plum;
            this.cmbPaymentAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentAccount.FormattingEnabled = true;
            this.cmbPaymentAccount.Location = new System.Drawing.Point(117, 16);
            this.cmbPaymentAccount.Name = "cmbPaymentAccount";
            this.cmbPaymentAccount.Size = new System.Drawing.Size(287, 32);
            this.cmbPaymentAccount.TabIndex = 1752;
            // 
            // dtfrom
            // 
            this.dtfrom.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dtfrom.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtfrom.Location = new System.Drawing.Point(520, 16);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.Size = new System.Drawing.Size(223, 33);
            this.dtfrom.TabIndex = 51;
            // 
            // lib1
            // 
            this.lib1.AutoSize = true;
            this.lib1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib1.Location = new System.Drawing.Point(419, 22);
            this.lib1.Name = "lib1";
            this.lib1.Size = new System.Drawing.Size(86, 21);
            this.lib1.TabIndex = 48;
            this.lib1.Text = "From Date:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(9, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 21);
            this.label15.TabIndex = 1753;
            this.label15.Text = "Cash Account:";
            // 
            // lib2
            // 
            this.lib2.AutoSize = true;
            this.lib2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib2.Location = new System.Drawing.Point(749, 22);
            this.lib2.Name = "lib2";
            this.lib2.Size = new System.Drawing.Size(64, 21);
            this.lib2.TabIndex = 54;
            this.lib2.Text = "To Date:";
            // 
            // dtto
            // 
            this.dtto.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dtto.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtto.Location = new System.Drawing.Point(819, 16);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(223, 33);
            this.dtto.TabIndex = 52;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Bahij Helvetica Neue 75 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(1048, 15);
            this.btnView.Name = "btnView";
            // 
            // 
            // 
            this.btnView.RootElement.ForeColor = System.Drawing.Color.White;
            this.btnView.Size = new System.Drawing.Size(118, 36);
            this.btnView.TabIndex = 1751;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnView.GetChildAt(0))).Text = "View";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnView.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnView.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnView.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnView.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            // 
            // frmSaleReportUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTotalCr);
            this.Controls.Add(this.lblTotalDr);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dgAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSaleReportUpdate";
            this.Text = "Sale Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSaleReportUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAccount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGroupReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invoice_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashirOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrencyName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrencyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusB;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SystemDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalCr;
        private System.Windows.Forms.Label lblTotalDr;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadButton btnGroupReport;
        private Telerik.WinControls.UI.RadButton btnReport;
        private System.Windows.Forms.ComboBox cmbPaymentAccount;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private System.Windows.Forms.Label lib1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lib2;
        private System.Windows.Forms.DateTimePicker dtto;
        private Telerik.WinControls.UI.RadButton btnView;
    }
}