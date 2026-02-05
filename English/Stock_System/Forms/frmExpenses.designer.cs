namespace Stock_System.Forms
{
    partial class frmExpenses
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lstExpenseHead = new System.Windows.Forms.ListView();
            this.ExpenseHeadID = new System.Windows.Forms.ColumnHeader();
            this.ExpenseHeadName = new System.Windows.Forms.ColumnHeader();
            this.btnSaveHead = new Telerik.WinControls.UI.RadButton();
            this.txtExpenseHeadName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CustomerTranGrid = new System.Windows.Forms.DataGridView();
            this.TransactionDat1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionType1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionDetail1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionAmount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReciptReport = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new Telerik.WinControls.UI.RadButton();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.ddlExpenseHead = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtExpenseDetail = new System.Windows.Forms.TextBox();
            this.txtExchangeRate = new System.Windows.Forms.TextBox();
            this.txtExpenseAmount = new System.Windows.Forms.TextBox();
            this.cmbPaymentAccount = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlExpHead = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCloseOpeningBalance = new System.Windows.Forms.Button();
            this.btnExpHead = new Telerik.WinControls.UI.RadButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.lib2 = new System.Windows.Forms.Label();
            this.lib1 = new System.Windows.Forms.Label();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTranGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            this.pnlExpHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExpHead)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lstExpenseHead
            // 
            this.lstExpenseHead.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ExpenseHeadID,
            this.ExpenseHeadName});
            this.lstExpenseHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstExpenseHead.FullRowSelect = true;
            this.lstExpenseHead.GridLines = true;
            this.lstExpenseHead.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstExpenseHead.Location = new System.Drawing.Point(16, 125);
            this.lstExpenseHead.Name = "lstExpenseHead";
            this.lstExpenseHead.ShowItemToolTips = true;
            this.lstExpenseHead.Size = new System.Drawing.Size(528, 515);
            this.lstExpenseHead.TabIndex = 1615;
            this.lstExpenseHead.UseCompatibleStateImageBehavior = false;
            this.lstExpenseHead.View = System.Windows.Forms.View.Details;
            this.lstExpenseHead.Click += new System.EventHandler(this.lstExpenseHead_Click);
            // 
            // ExpenseHeadID
            // 
            this.ExpenseHeadID.Text = "Head ID";
            this.ExpenseHeadID.Width = 100;
            // 
            // ExpenseHeadName
            // 
            this.ExpenseHeadName.Text = "Expense Head Name";
            this.ExpenseHeadName.Width = 300;
            // 
            // btnSaveHead
            // 
            this.btnSaveHead.Location = new System.Drawing.Point(439, 85);
            this.btnSaveHead.Name = "btnSaveHead";
            this.btnSaveHead.Size = new System.Drawing.Size(105, 31);
            this.btnSaveHead.TabIndex = 1;
            this.btnSaveHead.Text = "Save";
            this.btnSaveHead.Click += new System.EventHandler(this.btnSaveHead_Click);
            // 
            // txtExpenseHeadName
            // 
            this.txtExpenseHeadName.BackColor = System.Drawing.Color.White;
            this.txtExpenseHeadName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExpenseHeadName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpenseHeadName.ForeColor = System.Drawing.Color.Black;
            this.txtExpenseHeadName.Location = new System.Drawing.Point(172, 85);
            this.txtExpenseHeadName.Name = "txtExpenseHeadName";
            this.txtExpenseHeadName.Size = new System.Drawing.Size(262, 31);
            this.txtExpenseHeadName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 20);
            this.label2.TabIndex = 1613;
            this.label2.Text = "Expense Head Name";
            // 
            // CustomerTranGrid
            // 
            this.CustomerTranGrid.AllowUserToAddRows = false;
            this.CustomerTranGrid.AllowUserToDeleteRows = false;
            this.CustomerTranGrid.AllowUserToResizeColumns = false;
            this.CustomerTranGrid.AllowUserToResizeRows = false;
            this.CustomerTranGrid.ColumnHeadersHeight = 41;
            this.CustomerTranGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransactionDat1,
            this.IDNo,
            this.TransactionType1,
            this.TransactionDetail1,
            this.TransactionAmount1,
            this.Credit,
            this.TBalance,
            this.Account,
            this.ReciptReport,
            this.Delete});
            this.CustomerTranGrid.Location = new System.Drawing.Point(20, 259);
            this.CustomerTranGrid.Name = "CustomerTranGrid";
            this.CustomerTranGrid.ReadOnly = true;
            this.CustomerTranGrid.RowHeadersVisible = false;
            this.CustomerTranGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerTranGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.CustomerTranGrid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.CustomerTranGrid.RowTemplate.Height = 41;
            this.CustomerTranGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CustomerTranGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CustomerTranGrid.Size = new System.Drawing.Size(1864, 637);
            this.CustomerTranGrid.TabIndex = 1625;
            this.CustomerTranGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomerTranGrid_CellContentClick);
            // 
            // TransactionDat1
            // 
            this.TransactionDat1.DataPropertyName = "ExpenseDate";
            this.TransactionDat1.HeaderText = "Date";
            this.TransactionDat1.Name = "TransactionDat1";
            this.TransactionDat1.ReadOnly = true;
            this.TransactionDat1.Width = 150;
            // 
            // IDNo
            // 
            this.IDNo.DataPropertyName = "ID";
            this.IDNo.HeaderText = "Tran#";
            this.IDNo.Name = "IDNo";
            this.IDNo.ReadOnly = true;
            // 
            // TransactionType1
            // 
            this.TransactionType1.DataPropertyName = "ExpenseHeadName";
            this.TransactionType1.HeaderText = "Expense Head";
            this.TransactionType1.Name = "TransactionType1";
            this.TransactionType1.ReadOnly = true;
            this.TransactionType1.Width = 250;
            // 
            // TransactionDetail1
            // 
            this.TransactionDetail1.DataPropertyName = "ExpenseDetail";
            this.TransactionDetail1.HeaderText = "Expense Detail";
            this.TransactionDetail1.Name = "TransactionDetail1";
            this.TransactionDetail1.ReadOnly = true;
            this.TransactionDetail1.Width = 400;
            // 
            // TransactionAmount1
            // 
            this.TransactionAmount1.DataPropertyName = "ExpenseAmount";
            this.TransactionAmount1.HeaderText = "Expense Amount";
            this.TransactionAmount1.Name = "TransactionAmount1";
            this.TransactionAmount1.ReadOnly = true;
            this.TransactionAmount1.Width = 200;
            // 
            // Credit
            // 
            this.Credit.DataPropertyName = "CurrencyName";
            this.Credit.HeaderText = "Currency";
            this.Credit.Name = "Credit";
            this.Credit.ReadOnly = true;
            this.Credit.Width = 150;
            // 
            // TBalance
            // 
            this.TBalance.DataPropertyName = "ExchangeRate";
            this.TBalance.HeaderText = "Exchange Rate";
            this.TBalance.Name = "TBalance";
            this.TBalance.ReadOnly = true;
            this.TBalance.Width = 150;
            // 
            // Account
            // 
            this.Account.DataPropertyName = "AccountName";
            this.Account.HeaderText = "Account Name";
            this.Account.Name = "Account";
            this.Account.ReadOnly = true;
            this.Account.Width = 250;
            // 
            // ReciptReport
            // 
            this.ReciptReport.DataPropertyName = "Report";
            this.ReciptReport.HeaderText = "Report";
            this.ReciptReport.Name = "ReciptReport";
            this.ReciptReport.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.DataPropertyName = "DelRow";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Red;
            this.Delete.DefaultCellStyle = dataGridViewCellStyle1;
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 1623;
            this.label1.Text = "Expense Head";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1681, 22);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(167, 65);
            this.btnClear.TabIndex = 1621;
            this.btnClear.Text = "Clear";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.BackColor = System.Drawing.SystemColors.Highlight;
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCurrency.ForeColor = System.Drawing.Color.Transparent;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(698, 55);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(130, 33);
            this.cmbCurrency.TabIndex = 3;
            this.cmbCurrency.SelectionChangeCommitted += new System.EventHandler(this.cmbCurrency_SelectionChangeCommitted);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1506, 22);
            this.btnSave.Name = "btnSave";
            // 
            // 
            // 
            this.btnSave.RootElement.ForeColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(167, 65);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Text = "Save";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            // 
            // ddlExpenseHead
            // 
            this.ddlExpenseHead.BackColor = System.Drawing.SystemColors.Highlight;
            this.ddlExpenseHead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlExpenseHead.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlExpenseHead.ForeColor = System.Drawing.Color.Transparent;
            this.ddlExpenseHead.FormattingEnabled = true;
            this.ddlExpenseHead.Items.AddRange(new object[] {
            "Received Loan",
            "Cash Payment"});
            this.ddlExpenseHead.Location = new System.Drawing.Point(175, 16);
            this.ddlExpenseHead.Name = "ddlExpenseHead";
            this.ddlExpenseHead.Size = new System.Drawing.Size(335, 33);
            this.ddlExpenseHead.TabIndex = 0;
            this.ddlExpenseHead.SelectionChangeCommitted += new System.EventHandler(this.ddlExpenseHead_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(578, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 20);
            this.label8.TabIndex = 1613;
            this.label8.Text = "Currency";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(578, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 20);
            this.label6.TabIndex = 1617;
            this.label6.Text = "Expense Detail";
            // 
            // txtExpenseDetail
            // 
            this.txtExpenseDetail.BackColor = System.Drawing.Color.White;
            this.txtExpenseDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExpenseDetail.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpenseDetail.ForeColor = System.Drawing.Color.Black;
            this.txtExpenseDetail.Location = new System.Drawing.Point(698, 16);
            this.txtExpenseDetail.Name = "txtExpenseDetail";
            this.txtExpenseDetail.Size = new System.Drawing.Size(718, 32);
            this.txtExpenseDetail.TabIndex = 1;
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExchangeRate.Enabled = false;
            this.txtExchangeRate.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExchangeRate.ForeColor = System.Drawing.Color.Black;
            this.txtExchangeRate.Location = new System.Drawing.Point(834, 55);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Size = new System.Drawing.Size(80, 32);
            this.txtExchangeRate.TabIndex = 174;
            // 
            // txtExpenseAmount
            // 
            this.txtExpenseAmount.BackColor = System.Drawing.Color.White;
            this.txtExpenseAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExpenseAmount.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpenseAmount.ForeColor = System.Drawing.Color.Black;
            this.txtExpenseAmount.Location = new System.Drawing.Point(175, 55);
            this.txtExpenseAmount.Name = "txtExpenseAmount";
            this.txtExpenseAmount.Size = new System.Drawing.Size(378, 32);
            this.txtExpenseAmount.TabIndex = 2;
            // 
            // cmbPaymentAccount
            // 
            this.cmbPaymentAccount.BackColor = System.Drawing.Color.Plum;
            this.cmbPaymentAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentAccount.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentAccount.ForeColor = System.Drawing.Color.Transparent;
            this.cmbPaymentAccount.FormattingEnabled = true;
            this.cmbPaymentAccount.Location = new System.Drawing.Point(1081, 55);
            this.cmbPaymentAccount.Name = "cmbPaymentAccount";
            this.cmbPaymentAccount.Size = new System.Drawing.Size(335, 33);
            this.cmbPaymentAccount.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(920, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(155, 20);
            this.label15.TabIndex = 1615;
            this.label15.Text = "Transaction Account";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 1611;
            this.label3.Text = "Expense Amount";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Orange;
            this.label10.Location = new System.Drawing.Point(30, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(258, 25);
            this.label10.TabIndex = 1635;
            this.label10.Text = "EXPENSE ENTRY FORM";
            // 
            // pnlExpHead
            // 
            this.pnlExpHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(160)))), ((int)(((byte)(134)))));
            this.pnlExpHead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlExpHead.Controls.Add(this.lstExpenseHead);
            this.pnlExpHead.Controls.Add(this.btnSaveHead);
            this.pnlExpHead.Controls.Add(this.label4);
            this.pnlExpHead.Controls.Add(this.txtExpenseHeadName);
            this.pnlExpHead.Controls.Add(this.btnCloseOpeningBalance);
            this.pnlExpHead.Controls.Add(this.label2);
            this.pnlExpHead.ForeColor = System.Drawing.Color.White;
            this.pnlExpHead.Location = new System.Drawing.Point(505, 100);
            this.pnlExpHead.Name = "pnlExpHead";
            this.pnlExpHead.Size = new System.Drawing.Size(565, 654);
            this.pnlExpHead.TabIndex = 1659;
            this.pnlExpHead.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(273, 24);
            this.label4.TabIndex = 1619;
            this.label4.Text = "Expense Head Entry Form";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCloseOpeningBalance
            // 
            this.btnCloseOpeningBalance.BackColor = System.Drawing.Color.Red;
            this.btnCloseOpeningBalance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseOpeningBalance.ForeColor = System.Drawing.Color.White;
            this.btnCloseOpeningBalance.Location = new System.Drawing.Point(509, 3);
            this.btnCloseOpeningBalance.Name = "btnCloseOpeningBalance";
            this.btnCloseOpeningBalance.Size = new System.Drawing.Size(51, 41);
            this.btnCloseOpeningBalance.TabIndex = 1656;
            this.btnCloseOpeningBalance.Text = "X";
            this.btnCloseOpeningBalance.UseVisualStyleBackColor = false;
            this.btnCloseOpeningBalance.Click += new System.EventHandler(this.btnCloseOpeningBalance_Click);
            // 
            // btnExpHead
            // 
            this.btnExpHead.Location = new System.Drawing.Point(517, 16);
            this.btnExpHead.Name = "btnExpHead";
            this.btnExpHead.Size = new System.Drawing.Size(36, 33);
            this.btnExpHead.TabIndex = 1660;
            this.btnExpHead.Text = "+";
            this.btnExpHead.Click += new System.EventHandler(this.btnExpHead_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExpHead);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ddlExpenseHead);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.cmbCurrency);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.cmbPaymentAccount);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtExpenseAmount);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtExchangeRate);
            this.groupBox1.Controls.Add(this.txtExpenseDetail);
            this.groupBox1.Location = new System.Drawing.Point(20, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1864, 96);
            this.groupBox1.TabIndex = 1661;
            this.groupBox1.TabStop = false;
            // 
            // dtto
            // 
            this.dtto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtto.Location = new System.Drawing.Point(358, 24);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(182, 29);
            this.dtto.TabIndex = 52;
            // 
            // lib2
            // 
            this.lib2.AutoSize = true;
            this.lib2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib2.Location = new System.Drawing.Point(286, 28);
            this.lib2.Name = "lib2";
            this.lib2.Size = new System.Drawing.Size(57, 21);
            this.lib2.TabIndex = 54;
            this.lib2.Text = "ToDate";
            // 
            // lib1
            // 
            this.lib1.AutoSize = true;
            this.lib1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib1.Location = new System.Drawing.Point(12, 28);
            this.lib1.Name = "lib1";
            this.lib1.Size = new System.Drawing.Size(83, 21);
            this.lib1.TabIndex = 48;
            this.lib1.Text = "From Date";
            // 
            // dtfrom
            // 
            this.dtfrom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfrom.Location = new System.Drawing.Point(101, 24);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.Size = new System.Drawing.Size(182, 29);
            this.dtfrom.TabIndex = 51;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(647, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(180, 52);
            this.btnSearch.TabIndex = 1662;
            this.btnSearch.Text = "View";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtto);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.dtfrom);
            this.groupBox2.Controls.Add(this.lib2);
            this.groupBox2.Controls.Add(this.lib1);
            this.groupBox2.Location = new System.Drawing.Point(22, 906);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(840, 73);
            this.groupBox2.TabIndex = 1663;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // frmExpenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1940, 1100);
            this.Controls.Add(this.pnlExpHead);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CustomerTranGrid);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmExpenses";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmExpenses";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmExpenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTranGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            this.pnlExpHead.ResumeLayout(false);
            this.pnlExpHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExpHead)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlExpenseHead;
        private Telerik.WinControls.UI.RadButton btnClear;
        private Telerik.WinControls.UI.RadButton btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtExpenseDetail;
        private System.Windows.Forms.TextBox txtExpenseAmount;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.ComboBox cmbPaymentAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtExchangeRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtExpenseHeadName;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadButton btnSaveHead;
        private System.Windows.Forms.ListView lstExpenseHead;
        private System.Windows.Forms.ColumnHeader ExpenseHeadID;
        private System.Windows.Forms.ColumnHeader ExpenseHeadName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView CustomerTranGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionDat1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionType1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionDetail1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionAmount1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account;
        private System.Windows.Forms.DataGridViewButtonColumn ReciptReport;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Panel pnlExpHead;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCloseOpeningBalance;
        private Telerik.WinControls.UI.RadButton btnExpHead;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.Label lib2;
        private System.Windows.Forms.Label lib1;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

