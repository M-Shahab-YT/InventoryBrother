namespace Stock_System.Forms
{
    partial class frmSalesManStatement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgSalesmanStatement = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLinkColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Paid = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalBalance = new System.Windows.Forms.TextBox();
            this.pnlTransaction = new System.Windows.Forms.Panel();
            this.label36 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CustomerTranGrid = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new Telerik.WinControls.UI.RadButton();
            this.cmbTransactionType = new System.Windows.Forms.ComboBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.btnSavePaidLoan = new Telerik.WinControls.UI.RadButton();
            this.txtAmountToPay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbPaymentAccount = new System.Windows.Forms.ComboBox();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.TransactionDat1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionType1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionDetail1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionAmount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReciptReport = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSalesmanStatement)).BeginInit();
            this.pnlTransaction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTranGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSavePaidLoan)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSearchValue);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbSearchType);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(24, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1176, 80);
            this.groupBox1.TabIndex = 1681;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search here..";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(1016, 20);
            this.btnSearch.Name = "btnSearch";
            // 
            // 
            // 
            this.btnSearch.RootElement.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Size = new System.Drawing.Size(145, 50);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSearch.GetChildAt(0))).Text = "Search";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSearch.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSearch.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSearch.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSearch.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.BackColor = System.Drawing.Color.White;
            this.txtSearchValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchValue.ForeColor = System.Drawing.Color.Black;
            this.txtSearchValue.Location = new System.Drawing.Point(609, 26);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(396, 38);
            this.txtSearchValue.TabIndex = 1640;
            this.txtSearchValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchValue_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 1639;
            this.label2.Text = "Search Type:";
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.BackColor = System.Drawing.Color.White;
            this.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchType.ForeColor = System.Drawing.Color.Black;
            this.cmbSearchType.FormattingEnabled = true;
            this.cmbSearchType.Items.AddRange(new object[] {
            "Search By Salesman Name",
            "All Salesman"});
            this.cmbSearchType.Location = new System.Drawing.Point(119, 26);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(381, 39);
            this.cmbSearchType.TabIndex = 0;
            this.cmbSearchType.SelectionChangeCommitted += new System.EventHandler(this.cmbSearchType_SelectionChangeCommitted);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Indigo;
            this.label12.Location = new System.Drawing.Point(506, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 16);
            this.label12.TabIndex = 1622;
            this.label12.Text = "Search Value:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgSalesmanStatement);
            this.groupBox2.Location = new System.Drawing.Point(24, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1886, 655);
            this.groupBox2.TabIndex = 1684;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Salesman\'s Statement Summary";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // dgSalesmanStatement
            // 
            this.dgSalesmanStatement.AllowUserToAddRows = false;
            this.dgSalesmanStatement.AllowUserToDeleteRows = false;
            this.dgSalesmanStatement.AllowUserToResizeColumns = false;
            this.dgSalesmanStatement.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSalesmanStatement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgSalesmanStatement.ColumnHeadersHeight = 41;
            this.dgSalesmanStatement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerID,
            this.CustomerName,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewLinkColumn1,
            this.Paid});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSalesmanStatement.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgSalesmanStatement.Location = new System.Drawing.Point(7, 17);
            this.dgSalesmanStatement.Name = "dgSalesmanStatement";
            this.dgSalesmanStatement.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSalesmanStatement.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgSalesmanStatement.RowHeadersVisible = false;
            this.dgSalesmanStatement.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgSalesmanStatement.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.dgSalesmanStatement.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgSalesmanStatement.RowTemplate.Height = 41;
            this.dgSalesmanStatement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSalesmanStatement.Size = new System.Drawing.Size(1872, 628);
            this.dgSalesmanStatement.TabIndex = 1;
            this.dgSalesmanStatement.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSalesmanStatement_CellContentClick);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.Orange;
            this.label14.Location = new System.Drawing.Point(34, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(276, 25);
            this.label14.TabIndex = 1685;
            this.label14.Text = "SALESMAN\'S STATMENT";
            // 
            // CustomerID
            // 
            this.CustomerID.DataPropertyName = "SaleManID";
            this.CustomerID.HeaderText = "Salesman ID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.ReadOnly = true;
            this.CustomerID.Width = 250;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "SaleManName";
            this.CustomerName.HeaderText = "Salesman Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 600;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TotalDebit";
            this.dataGridViewTextBoxColumn4.HeaderText = "Total Debit";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TotalCredit";
            this.dataGridViewTextBoxColumn5.HeaderText = "Total Credit";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Balance";
            this.dataGridViewTextBoxColumn6.HeaderText = "Balance";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewLinkColumn1
            // 
            this.dataGridViewLinkColumn1.DataPropertyName = "Statement";
            this.dataGridViewLinkColumn1.HeaderText = "Statement";
            this.dataGridViewLinkColumn1.Name = "dataGridViewLinkColumn1";
            this.dataGridViewLinkColumn1.ReadOnly = true;
            this.dataGridViewLinkColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLinkColumn1.Width = 200;
            // 
            // Paid
            // 
            this.Paid.DataPropertyName = "NewTransaction";
            this.Paid.HeaderText = "Transaction";
            this.Paid.Name = "Paid";
            this.Paid.ReadOnly = true;
            this.Paid.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1494, 905);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 1686;
            this.label1.Text = "TOTAL BALANCE:";
            // 
            // txtTotalBalance
            // 
            this.txtTotalBalance.BackColor = System.Drawing.Color.White;
            this.txtTotalBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalBalance.Enabled = false;
            this.txtTotalBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBalance.ForeColor = System.Drawing.Color.Black;
            this.txtTotalBalance.Location = new System.Drawing.Point(1642, 896);
            this.txtTotalBalance.Name = "txtTotalBalance";
            this.txtTotalBalance.Size = new System.Drawing.Size(261, 38);
            this.txtTotalBalance.TabIndex = 1687;
            this.txtTotalBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlTransaction
            // 
            this.pnlTransaction.BackColor = System.Drawing.Color.DarkBlue;
            this.pnlTransaction.Controls.Add(this.label36);
            this.pnlTransaction.Controls.Add(this.label4);
            this.pnlTransaction.Controls.Add(this.CustomerTranGrid);
            this.pnlTransaction.Controls.Add(this.label3);
            this.pnlTransaction.Controls.Add(this.btnClear);
            this.pnlTransaction.Controls.Add(this.cmbTransactionType);
            this.pnlTransaction.Controls.Add(this.txtSupplier);
            this.pnlTransaction.Controls.Add(this.btnSavePaidLoan);
            this.pnlTransaction.Controls.Add(this.txtAmountToPay);
            this.pnlTransaction.Controls.Add(this.label6);
            this.pnlTransaction.Controls.Add(this.txtRemarks);
            this.pnlTransaction.Controls.Add(this.label5);
            this.pnlTransaction.Controls.Add(this.cmbPaymentAccount);
            this.pnlTransaction.Controls.Add(this.txtSupplierID);
            this.pnlTransaction.Controls.Add(this.label7);
            this.pnlTransaction.Controls.Add(this.label15);
            this.pnlTransaction.Controls.Add(this.btnTransaction);
            this.pnlTransaction.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTransaction.Location = new System.Drawing.Point(24, 127);
            this.pnlTransaction.Name = "pnlTransaction";
            this.pnlTransaction.Size = new System.Drawing.Size(1774, 671);
            this.pnlTransaction.TabIndex = 1688;
            this.pnlTransaction.Visible = false;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label36.ForeColor = System.Drawing.Color.Orange;
            this.label36.Location = new System.Drawing.Point(13, 16);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(196, 25);
            this.label36.TabIndex = 1664;
            this.label36.Text = "Add New Tranction";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(50, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 1628;
            this.label4.Text = "Salesman ID:";
            // 
            // CustomerTranGrid
            // 
            this.CustomerTranGrid.AllowUserToAddRows = false;
            this.CustomerTranGrid.AllowUserToDeleteRows = false;
            this.CustomerTranGrid.AllowUserToOrderColumns = true;
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
            this.ReciptReport,
            this.Delete1});
            this.CustomerTranGrid.Location = new System.Drawing.Point(3, 259);
            this.CustomerTranGrid.Name = "CustomerTranGrid";
            this.CustomerTranGrid.RowHeadersVisible = false;
            this.CustomerTranGrid.RowTemplate.Height = 41;
            this.CustomerTranGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CustomerTranGrid.Size = new System.Drawing.Size(1763, 406);
            this.CustomerTranGrid.TabIndex = 1624;
            this.CustomerTranGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomerTranGrid_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(50, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 16);
            this.label3.TabIndex = 1623;
            this.label3.Text = "Transaction Type:";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(913, 203);
            this.btnClear.Name = "btnClear";
            // 
            // 
            // 
            this.btnClear.RootElement.ForeColor = System.Drawing.Color.White;
            this.btnClear.Size = new System.Drawing.Size(95, 43);
            this.btnClear.TabIndex = 1621;
            this.btnClear.Text = "Clear";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClear.GetChildAt(0))).Text = "Clear";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnClear.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnClear.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnClear.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnClear.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            // 
            // cmbTransactionType
            // 
            this.cmbTransactionType.BackColor = System.Drawing.Color.White;
            this.cmbTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransactionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.cmbTransactionType.ForeColor = System.Drawing.Color.Black;
            this.cmbTransactionType.FormattingEnabled = true;
            this.cmbTransactionType.Items.AddRange(new object[] {
            "Paid Commission",
            "Opening Balance"});
            this.cmbTransactionType.Location = new System.Drawing.Point(219, 150);
            this.cmbTransactionType.Name = "cmbTransactionType";
            this.cmbTransactionType.Size = new System.Drawing.Size(407, 39);
            this.cmbTransactionType.TabIndex = 1622;
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(219, 105);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(407, 38);
            this.txtSupplier.TabIndex = 1631;
            // 
            // btnSavePaidLoan
            // 
            this.btnSavePaidLoan.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePaidLoan.ForeColor = System.Drawing.Color.White;
            this.btnSavePaidLoan.Location = new System.Drawing.Point(815, 203);
            this.btnSavePaidLoan.Name = "btnSavePaidLoan";
            // 
            // 
            // 
            this.btnSavePaidLoan.RootElement.ForeColor = System.Drawing.Color.White;
            this.btnSavePaidLoan.Size = new System.Drawing.Size(95, 43);
            this.btnSavePaidLoan.TabIndex = 1620;
            this.btnSavePaidLoan.Text = "Save";
            this.btnSavePaidLoan.Click += new System.EventHandler(this.btnSavePaidLoan_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSavePaidLoan.GetChildAt(0))).Text = "Save";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSavePaidLoan.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSavePaidLoan.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSavePaidLoan.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSavePaidLoan.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            // 
            // txtAmountToPay
            // 
            this.txtAmountToPay.BackColor = System.Drawing.Color.White;
            this.txtAmountToPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountToPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.txtAmountToPay.ForeColor = System.Drawing.Color.Black;
            this.txtAmountToPay.Location = new System.Drawing.Point(219, 195);
            this.txtAmountToPay.Name = "txtAmountToPay";
            this.txtAmountToPay.Size = new System.Drawing.Size(407, 38);
            this.txtAmountToPay.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(656, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 16);
            this.label6.TabIndex = 1617;
            this.label6.Text = "Transaction Detail:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.White;
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.ForeColor = System.Drawing.Color.Black;
            this.txtRemarks.Location = new System.Drawing.Point(815, 107);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(716, 90);
            this.txtRemarks.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(50, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 16);
            this.label5.TabIndex = 1627;
            this.label5.Text = "Salesman Name:";
            // 
            // cmbPaymentAccount
            // 
            this.cmbPaymentAccount.BackColor = System.Drawing.Color.White;
            this.cmbPaymentAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.cmbPaymentAccount.ForeColor = System.Drawing.Color.Black;
            this.cmbPaymentAccount.FormattingEnabled = true;
            this.cmbPaymentAccount.Location = new System.Drawing.Point(815, 62);
            this.cmbPaymentAccount.Name = "cmbPaymentAccount";
            this.cmbPaymentAccount.Size = new System.Drawing.Size(407, 39);
            this.cmbPaymentAccount.TabIndex = 1;
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.BackColor = System.Drawing.Color.White;
            this.txtSupplierID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierID.Enabled = false;
            this.txtSupplierID.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierID.ForeColor = System.Drawing.Color.Black;
            this.txtSupplierID.Location = new System.Drawing.Point(219, 62);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.ReadOnly = true;
            this.txtSupplierID.Size = new System.Drawing.Size(407, 38);
            this.txtSupplierID.TabIndex = 1626;
            this.txtSupplierID.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(50, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 16);
            this.label7.TabIndex = 1611;
            this.label7.Text = "Transaction Amount:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(656, 73);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(153, 16);
            this.label15.TabIndex = 1615;
            this.label15.Text = "Transaction Account:";
            // 
            // btnTransaction
            // 
            this.btnTransaction.BackColor = System.Drawing.Color.Red;
            this.btnTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransaction.ForeColor = System.Drawing.Color.White;
            this.btnTransaction.Location = new System.Drawing.Point(1718, 4);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(50, 50);
            this.btnTransaction.TabIndex = 1604;
            this.btnTransaction.Text = "X";
            this.btnTransaction.UseVisualStyleBackColor = false;
            this.btnTransaction.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // TransactionDat1
            // 
            this.TransactionDat1.DataPropertyName = "Date";
            this.TransactionDat1.HeaderText = "Date";
            this.TransactionDat1.Name = "TransactionDat1";
            this.TransactionDat1.Width = 200;
            // 
            // IDNo
            // 
            this.IDNo.DataPropertyName = "ID";
            this.IDNo.HeaderText = "Tran#";
            this.IDNo.Name = "IDNo";
            this.IDNo.Width = 80;
            // 
            // TransactionType1
            // 
            this.TransactionType1.DataPropertyName = "ReferenceType";
            this.TransactionType1.HeaderText = "Type";
            this.TransactionType1.Name = "TransactionType1";
            this.TransactionType1.Width = 200;
            // 
            // TransactionDetail1
            // 
            this.TransactionDetail1.DataPropertyName = "Particulars";
            this.TransactionDetail1.HeaderText = "Detail";
            this.TransactionDetail1.Name = "TransactionDetail1";
            this.TransactionDetail1.Width = 420;
            // 
            // TransactionAmount1
            // 
            this.TransactionAmount1.DataPropertyName = "Debit";
            this.TransactionAmount1.HeaderText = "Debit";
            this.TransactionAmount1.Name = "TransactionAmount1";
            this.TransactionAmount1.Width = 200;
            // 
            // Credit
            // 
            this.Credit.DataPropertyName = "Credit";
            this.Credit.HeaderText = "Credit";
            this.Credit.Name = "Credit";
            this.Credit.Width = 200;
            // 
            // TBalance
            // 
            this.TBalance.DataPropertyName = "Balance";
            this.TBalance.HeaderText = "Balance";
            this.TBalance.Name = "TBalance";
            this.TBalance.Width = 200;
            // 
            // ReciptReport
            // 
            this.ReciptReport.DataPropertyName = "Report";
            this.ReciptReport.HeaderText = "Report";
            this.ReciptReport.Name = "ReciptReport";
            this.ReciptReport.Width = 120;
            // 
            // Delete1
            // 
            this.Delete1.DataPropertyName = "Delete1";
            this.Delete1.HeaderText = "Delete";
            this.Delete1.Name = "Delete1";
            this.Delete1.Width = 120;
            // 
            // frmSalesManStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.pnlTransaction);
            this.Controls.Add(this.txtTotalBalance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSalesManStatement";
            this.Text = "Salesman Statement";
            this.Load += new System.EventHandler(this.frmSalesManStatement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSalesmanStatement)).EndInit();
            this.pnlTransaction.ResumeLayout(false);
            this.pnlTransaction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTranGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSavePaidLoan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSearchType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgSalesmanStatement;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewLinkColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn Paid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalBalance;
        private System.Windows.Forms.Panel pnlTransaction;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView CustomerTranGrid;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadButton btnClear;
        private System.Windows.Forms.ComboBox cmbTransactionType;
        private System.Windows.Forms.TextBox txtSupplier;
        private Telerik.WinControls.UI.RadButton btnSavePaidLoan;
        private System.Windows.Forms.TextBox txtAmountToPay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbPaymentAccount;
        private System.Windows.Forms.TextBox txtSupplierID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnTransaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionDat1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionType1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionDetail1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionAmount1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TBalance;
        private System.Windows.Forms.DataGridViewButtonColumn ReciptReport;
        private System.Windows.Forms.DataGridViewButtonColumn Delete1;
    }
}