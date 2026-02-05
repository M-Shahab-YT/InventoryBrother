namespace Stock_System.Forms
{
    partial class frmSaleReturn
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
            this.components = new System.ComponentModel.Container();
            this.pnlReturn = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSNO = new System.Windows.Forms.TextBox();
            this.txtReturnQty = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSoldQty = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SBatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoldQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoldTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaseCurrencyProfitPerUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaseCurrencySalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleManID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaseCurrencyDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Return = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnAdvanceSearch = new Telerik.WinControls.UI.RadButton();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new Telerik.WinControls.UI.RadButton();
            this.txtCashReturnToCustomer = new System.Windows.Forms.TextBox();
            this.txtNewBalance = new System.Windows.Forms.TextBox();
            this.txtReturnTotal = new System.Windows.Forms.TextBox();
            this.txtNewTotal = new System.Windows.Forms.TextBox();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.txtEchangeRate = new System.Windows.Forms.TextBox();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.txtPaymentMethod = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtSaleDate = new System.Windows.Forms.TextBox();
            this.txtOldGrandTotal = new System.Windows.Forms.TextBox();
            this.txtTotalBalance = new System.Windows.Forms.TextBox();
            this.txtTotalPaidAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnsave = new Telerik.WinControls.UI.RadButton();
            this.label25 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbPaymentAccount = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gpdate = new System.Windows.Forms.Panel();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.lib2 = new System.Windows.Forms.Label();
            this.lib1 = new System.Windows.Forms.Label();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.btnSerachAd = new Telerik.WinControls.UI.RadButton();
            this.lblSearchLabel1 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.txt_item_search = new System.Windows.Forms.TextBox();
            this.lst_Item = new System.Windows.Forms.ListView();
            this.ProductCode = new System.Windows.Forms.ColumnHeader();
            this.ProductBarCode = new System.Windows.Forms.ColumnHeader();
            this.ProductName = new System.Windows.Forms.ColumnHeader();
            this.Quantity = new System.Windows.Forms.ColumnHeader();
            this.SalePrice = new System.Windows.Forms.ColumnHeader();
            this.Currency = new System.Windows.Forms.ColumnHeader();
            this.InvoiceNo = new System.Windows.Forms.ColumnHeader();
            this.SaleOrderDate = new System.Windows.Forms.ColumnHeader();
            this.SaleOrderTime = new System.Windows.Forms.ColumnHeader();
            this.CustomerName = new System.Windows.Forms.ColumnHeader();
            this.gpitem_list = new System.Windows.Forms.Panel();
            this.pnlReturn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdvanceSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnsave)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSerachAd)).BeginInit();
            this.gpitem_list.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlReturn
            // 
            this.pnlReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(160)))), ((int)(((byte)(134)))));
            this.pnlReturn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReturn.Controls.Add(this.label26);
            this.pnlReturn.Controls.Add(this.txtDiscount);
            this.pnlReturn.Controls.Add(this.label18);
            this.pnlReturn.Controls.Add(this.btnClose);
            this.pnlReturn.Controls.Add(this.txtSalePrice);
            this.pnlReturn.Controls.Add(this.label14);
            this.pnlReturn.Controls.Add(this.button1);
            this.pnlReturn.Controls.Add(this.label13);
            this.pnlReturn.Controls.Add(this.txtSNO);
            this.pnlReturn.Controls.Add(this.txtReturnQty);
            this.pnlReturn.Controls.Add(this.label11);
            this.pnlReturn.Controls.Add(this.txtSoldQty);
            this.pnlReturn.Controls.Add(this.label12);
            this.pnlReturn.Location = new System.Drawing.Point(656, 153);
            this.pnlReturn.Name = "pnlReturn";
            this.pnlReturn.Size = new System.Drawing.Size(548, 241);
            this.pnlReturn.TabIndex = 1654;
            this.pnlReturn.Visible = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(12, 10);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(308, 24);
            this.label26.TabIndex = 13;
            this.label26.Text = "SPECIFIC QUANTITY TO RETURN";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Enabled = false;
            this.txtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(195, 105);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Size = new System.Drawing.Size(251, 26);
            this.txtDiscount.TabIndex = 12;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(42, 112);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 13);
            this.label18.TabIndex = 11;
            this.label18.Text = "DISCOUNT";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(347, 201);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 37);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.Enabled = false;
            this.txtSalePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalePrice.Location = new System.Drawing.Point(195, 77);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.ReadOnly = true;
            this.txtSalePrice.Size = new System.Drawing.Size(251, 26);
            this.txtSalePrice.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(42, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "SALE PRICE";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(437, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 37);
            this.button1.TabIndex = 7;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(42, 173);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(147, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "QUANTITY TO RETURN";
            // 
            // txtSNO
            // 
            this.txtSNO.Enabled = false;
            this.txtSNO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSNO.Location = new System.Drawing.Point(195, 49);
            this.txtSNO.Name = "txtSNO";
            this.txtSNO.ReadOnly = true;
            this.txtSNO.Size = new System.Drawing.Size(251, 26);
            this.txtSNO.TabIndex = 0;
            // 
            // txtReturnQty
            // 
            this.txtReturnQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnQty.Location = new System.Drawing.Point(195, 166);
            this.txtReturnQty.Name = "txtReturnQty";
            this.txtReturnQty.Size = new System.Drawing.Size(251, 26);
            this.txtReturnQty.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(42, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "SNO";
            // 
            // txtSoldQty
            // 
            this.txtSoldQty.Enabled = false;
            this.txtSoldQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoldQty.Location = new System.Drawing.Point(195, 134);
            this.txtSoldQty.Name = "txtSoldQty";
            this.txtSoldQty.ReadOnly = true;
            this.txtSoldQty.Size = new System.Drawing.Size(251, 26);
            this.txtSoldQty.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(42, 141);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "QUANTITY SOLD";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SNO,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.SBatchNo,
            this.ExpDate,
            this.SoldQty,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.SubCode,
            this.SoldTotal,
            this.dataGridViewTextBoxColumn5,
            this.BaseCurrencyProfitPerUnit,
            this.BaseCurrencySalePrice,
            this.SaleMan,
            this.SaleManID,
            this.BaseCurrencyDiscount,
            this.StockID,
            this.Return});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(1, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 41;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(1551, 828);
            this.dataGridView1.TabIndex = 172;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // SNO
            // 
            this.SNO.HeaderText = "SNO";
            this.SNO.Name = "SNO";
            this.SNO.ReadOnly = true;
            this.SNO.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "CODE";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 130;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "ITEM";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 390;
            // 
            // SBatchNo
            // 
            this.SBatchNo.HeaderText = "BATCH NO";
            this.SBatchNo.Name = "SBatchNo";
            this.SBatchNo.Width = 200;
            // 
            // ExpDate
            // 
            this.ExpDate.HeaderText = "EXPIRY DATE";
            this.ExpDate.Name = "ExpDate";
            this.ExpDate.Width = 200;
            // 
            // SoldQty
            // 
            this.SoldQty.HeaderText = "QTY SOLD";
            this.SoldQty.Name = "SoldQty";
            this.SoldQty.ReadOnly = true;
            this.SoldQty.Width = 90;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "QTY TO RETURN";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "SALE PRICE";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // SubCode
            // 
            this.SubCode.HeaderText = "DISCOUNT";
            this.SubCode.Name = "SubCode";
            this.SubCode.ReadOnly = true;
            this.SubCode.Width = 80;
            // 
            // SoldTotal
            // 
            this.SoldTotal.HeaderText = "SOLD TOTAL";
            this.SoldTotal.Name = "SoldTotal";
            this.SoldTotal.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "RETURN TOTAL";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // BaseCurrencyProfitPerUnit
            // 
            this.BaseCurrencyProfitPerUnit.HeaderText = "BaseCurrencyProfitPerUnit";
            this.BaseCurrencyProfitPerUnit.Name = "BaseCurrencyProfitPerUnit";
            this.BaseCurrencyProfitPerUnit.ReadOnly = true;
            this.BaseCurrencyProfitPerUnit.Visible = false;
            // 
            // BaseCurrencySalePrice
            // 
            this.BaseCurrencySalePrice.HeaderText = "BaseCurrencySalePrice";
            this.BaseCurrencySalePrice.Name = "BaseCurrencySalePrice";
            this.BaseCurrencySalePrice.ReadOnly = true;
            this.BaseCurrencySalePrice.Visible = false;
            // 
            // SaleMan
            // 
            this.SaleMan.HeaderText = "SaleMan";
            this.SaleMan.Name = "SaleMan";
            this.SaleMan.ReadOnly = true;
            this.SaleMan.Visible = false;
            // 
            // SaleManID
            // 
            this.SaleManID.HeaderText = "SaleManID";
            this.SaleManID.Name = "SaleManID";
            this.SaleManID.Visible = false;
            // 
            // BaseCurrencyDiscount
            // 
            this.BaseCurrencyDiscount.HeaderText = "BaseCurrencyDiscount";
            this.BaseCurrencyDiscount.Name = "BaseCurrencyDiscount";
            this.BaseCurrencyDiscount.Visible = false;
            // 
            // StockID
            // 
            this.StockID.HeaderText = "StockID";
            this.StockID.Name = "StockID";
            this.StockID.Visible = false;
            // 
            // Return
            // 
            this.Return.HeaderText = "CHECK TO RETURN    ";
            this.Return.Name = "Return";
            this.Return.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnAdvanceSearch);
            this.groupBox5.Controls.Add(this.btnSearch);
            this.groupBox5.Controls.Add(this.lblInvoiceNumber);
            this.groupBox5.Controls.Add(this.txtInvoiceNumber);
            this.groupBox5.Controls.Add(this.lblCustomerID);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.groupBox5.Location = new System.Drawing.Point(14, 125);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(601, 62);
            this.groupBox5.TabIndex = 1663;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Search Box";
            // 
            // btnAdvanceSearch
            // 
            this.btnAdvanceSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAdvanceSearch.ForeColor = System.Drawing.Color.White;
            this.btnAdvanceSearch.Location = new System.Drawing.Point(485, 16);
            this.btnAdvanceSearch.Name = "btnAdvanceSearch";
            // 
            // 
            // 
            this.btnAdvanceSearch.RootElement.ForeColor = System.Drawing.Color.White;
            this.btnAdvanceSearch.Size = new System.Drawing.Size(108, 42);
            this.btnAdvanceSearch.TabIndex = 1672;
            this.btnAdvanceSearch.Text = "Advance Search";
            this.btnAdvanceSearch.Click += new System.EventHandler(this.btnAdvanceSearch_Click_1);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnAdvanceSearch.GetChildAt(0))).Text = "Advance Search";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnAdvanceSearch.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(160)))), ((int)(((byte)(134)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnAdvanceSearch.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(160)))), ((int)(((byte)(134)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnAdvanceSearch.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(160)))), ((int)(((byte)(134)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnAdvanceSearch.GetChildAt(0).GetChildAt(0))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnAdvanceSearch.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(160)))), ((int)(((byte)(134)))));
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(374, 16);
            this.btnSearch.Name = "btnSearch";
            // 
            // 
            // 
            this.btnSearch.RootElement.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Size = new System.Drawing.Size(108, 42);
            this.btnSearch.TabIndex = 1667;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSearch.GetChildAt(0))).Text = "Search";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSearch.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSearch.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSearch.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSearch.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            // 
            // lblInvoiceNumber
            // 
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Location = new System.Drawing.Point(195, 4);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(0, 18);
            this.lblInvoiceNumber.TabIndex = 1639;
            this.lblInvoiceNumber.Visible = false;
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNumber.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.txtInvoiceNumber.Location = new System.Drawing.Point(119, 18);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(230, 38);
            this.txtInvoiceNumber.TabIndex = 1631;
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Location = new System.Drawing.Point(192, 15);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(0, 18);
            this.lblCustomerID.TabIndex = 1638;
            this.lblCustomerID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 18);
            this.label1.TabIndex = 1632;
            this.label1.Text = "Invoice Number";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(1728, 762);
            this.btnPrint.Name = "btnPrint";
            // 
            // 
            // 
            this.btnPrint.RootElement.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Size = new System.Drawing.Size(127, 60);
            this.btnPrint.TabIndex = 1674;
            this.btnPrint.Text = "Reprint Recipt";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).Text = "Reprint Recipt";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            // 
            // txtCashReturnToCustomer
            // 
            this.txtCashReturnToCustomer.Enabled = false;
            this.txtCashReturnToCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtCashReturnToCustomer.Location = new System.Drawing.Point(1656, 617);
            this.txtCashReturnToCustomer.Name = "txtCashReturnToCustomer";
            this.txtCashReturnToCustomer.ReadOnly = true;
            this.txtCashReturnToCustomer.Size = new System.Drawing.Size(208, 35);
            this.txtCashReturnToCustomer.TabIndex = 182;
            this.txtCashReturnToCustomer.Text = "0";
            this.txtCashReturnToCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNewBalance
            // 
            this.txtNewBalance.BackColor = System.Drawing.Color.White;
            this.txtNewBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewBalance.Enabled = false;
            this.txtNewBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtNewBalance.ForeColor = System.Drawing.Color.YellowGreen;
            this.txtNewBalance.Location = new System.Drawing.Point(1661, 487);
            this.txtNewBalance.Name = "txtNewBalance";
            this.txtNewBalance.ReadOnly = true;
            this.txtNewBalance.Size = new System.Drawing.Size(203, 35);
            this.txtNewBalance.TabIndex = 1659;
            this.txtNewBalance.Text = "0";
            this.txtNewBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtReturnTotal
            // 
            this.txtReturnTotal.BackColor = System.Drawing.Color.White;
            this.txtReturnTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReturnTotal.Enabled = false;
            this.txtReturnTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtReturnTotal.ForeColor = System.Drawing.Color.YellowGreen;
            this.txtReturnTotal.Location = new System.Drawing.Point(1661, 409);
            this.txtReturnTotal.Name = "txtReturnTotal";
            this.txtReturnTotal.ReadOnly = true;
            this.txtReturnTotal.Size = new System.Drawing.Size(203, 35);
            this.txtReturnTotal.TabIndex = 182;
            this.txtReturnTotal.Text = "0";
            this.txtReturnTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNewTotal
            // 
            this.txtNewTotal.BackColor = System.Drawing.Color.White;
            this.txtNewTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewTotal.Enabled = false;
            this.txtNewTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtNewTotal.ForeColor = System.Drawing.Color.YellowGreen;
            this.txtNewTotal.Location = new System.Drawing.Point(1661, 447);
            this.txtNewTotal.Name = "txtNewTotal";
            this.txtNewTotal.ReadOnly = true;
            this.txtNewTotal.Size = new System.Drawing.Size(203, 35);
            this.txtNewTotal.TabIndex = 25;
            this.txtNewTotal.Text = "0";
            this.txtNewTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCurrency
            // 
            this.txtCurrency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrency.Enabled = false;
            this.txtCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtCurrency.Location = new System.Drawing.Point(1661, 88);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(57, 35);
            this.txtCurrency.TabIndex = 1651;
            // 
            // txtEchangeRate
            // 
            this.txtEchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEchangeRate.Enabled = false;
            this.txtEchangeRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtEchangeRate.Location = new System.Drawing.Point(1814, 88);
            this.txtEchangeRate.Name = "txtEchangeRate";
            this.txtEchangeRate.Size = new System.Drawing.Size(49, 35);
            this.txtEchangeRate.TabIndex = 1648;
            // 
            // txtAccount
            // 
            this.txtAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccount.Enabled = false;
            this.txtAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtAccount.Location = new System.Drawing.Point(1661, 166);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(203, 35);
            this.txtAccount.TabIndex = 1646;
            // 
            // txtPaymentMethod
            // 
            this.txtPaymentMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaymentMethod.Enabled = false;
            this.txtPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtPaymentMethod.Location = new System.Drawing.Point(1661, 128);
            this.txtPaymentMethod.Name = "txtPaymentMethod";
            this.txtPaymentMethod.Size = new System.Drawing.Size(203, 35);
            this.txtPaymentMethod.TabIndex = 1644;
            // 
            // txtCustomer
            // 
            this.txtCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomer.Enabled = false;
            this.txtCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtCustomer.Location = new System.Drawing.Point(1661, 10);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(203, 35);
            this.txtCustomer.TabIndex = 1634;
            // 
            // txtSaleDate
            // 
            this.txtSaleDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaleDate.Enabled = false;
            this.txtSaleDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtSaleDate.Location = new System.Drawing.Point(1661, 49);
            this.txtSaleDate.Name = "txtSaleDate";
            this.txtSaleDate.Size = new System.Drawing.Size(203, 35);
            this.txtSaleDate.TabIndex = 1635;
            // 
            // txtOldGrandTotal
            // 
            this.txtOldGrandTotal.BackColor = System.Drawing.Color.White;
            this.txtOldGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldGrandTotal.Enabled = false;
            this.txtOldGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtOldGrandTotal.ForeColor = System.Drawing.Color.YellowGreen;
            this.txtOldGrandTotal.Location = new System.Drawing.Point(1661, 261);
            this.txtOldGrandTotal.Name = "txtOldGrandTotal";
            this.txtOldGrandTotal.ReadOnly = true;
            this.txtOldGrandTotal.Size = new System.Drawing.Size(203, 35);
            this.txtOldGrandTotal.TabIndex = 180;
            this.txtOldGrandTotal.Text = "0";
            this.txtOldGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalBalance
            // 
            this.txtTotalBalance.BackColor = System.Drawing.Color.White;
            this.txtTotalBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalBalance.Enabled = false;
            this.txtTotalBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtTotalBalance.ForeColor = System.Drawing.Color.YellowGreen;
            this.txtTotalBalance.Location = new System.Drawing.Point(1661, 339);
            this.txtTotalBalance.Name = "txtTotalBalance";
            this.txtTotalBalance.ReadOnly = true;
            this.txtTotalBalance.Size = new System.Drawing.Size(203, 35);
            this.txtTotalBalance.TabIndex = 53;
            this.txtTotalBalance.Text = "0";
            this.txtTotalBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalPaidAmount
            // 
            this.txtTotalPaidAmount.BackColor = System.Drawing.Color.White;
            this.txtTotalPaidAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalPaidAmount.Enabled = false;
            this.txtTotalPaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtTotalPaidAmount.ForeColor = System.Drawing.Color.YellowGreen;
            this.txtTotalPaidAmount.Location = new System.Drawing.Point(1661, 300);
            this.txtTotalPaidAmount.Name = "txtTotalPaidAmount";
            this.txtTotalPaidAmount.Size = new System.Drawing.Size(203, 35);
            this.txtTotalPaidAmount.TabIndex = 55;
            this.txtTotalPaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.label4.ForeColor = System.Drawing.Color.DarkOrange;
            this.label4.Location = new System.Drawing.Point(1690, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 37);
            this.label4.TabIndex = 1630;
            this.label4.Text = "SALES RETURN";
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(1596, 762);
            this.btnsave.Name = "btnsave";
            // 
            // 
            // 
            this.btnsave.RootElement.ForeColor = System.Drawing.Color.White;
            this.btnsave.Size = new System.Drawing.Size(127, 60);
            this.btnsave.TabIndex = 1666;
            this.btnsave.Text = "Return";
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnsave.GetChildAt(0))).Text = "Return";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnsave.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnsave.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnsave.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnsave.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label25.Location = new System.Drawing.Point(1557, 497);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(92, 15);
            this.label25.TabIndex = 1673;
            this.label25.Text = "NEW BALANCE";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label21.Location = new System.Drawing.Point(1557, 419);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(98, 15);
            this.label21.TabIndex = 1672;
            this.label21.Text = "RETURN TOTAL";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label23.Location = new System.Drawing.Point(1557, 457);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(103, 15);
            this.label23.TabIndex = 1671;
            this.label23.Text = "NEW SUB TOTAL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label7.Location = new System.Drawing.Point(1561, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 15);
            this.label7.TabIndex = 1673;
            this.label7.Text = "INVOICE TOTAL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label5.Location = new System.Drawing.Point(1561, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 1671;
            this.label5.Text = "BALANCE";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label24.Location = new System.Drawing.Point(1561, 310);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(89, 15);
            this.label24.TabIndex = 1672;
            this.label24.Text = "PAID AMOUNT";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label36.Location = new System.Drawing.Point(1730, 98);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(63, 15);
            this.label36.TabIndex = 1671;
            this.label36.Text = "Exch Rate";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label10.Location = new System.Drawing.Point(1560, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 15);
            this.label10.TabIndex = 1675;
            this.label10.Text = "CURRENCY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label3.Location = new System.Drawing.Point(1560, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 1671;
            this.label3.Text = "CUSTOMER";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label15.Location = new System.Drawing.Point(1560, 59);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 15);
            this.label15.TabIndex = 1672;
            this.label15.Text = "SALES DATE";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label20.Location = new System.Drawing.Point(1561, 176);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(99, 15);
            this.label20.TabIndex = 1673;
            this.label20.Text = "CASH ACCOUNT";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label22.Location = new System.Drawing.Point(1561, 138);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(85, 15);
            this.label22.TabIndex = 1674;
            this.label22.Text = "PAY METHOD";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.chkAll);
            this.panel7.Controls.Add(this.label25);
            this.panel7.Controls.Add(this.label36);
            this.panel7.Controls.Add(this.txtNewBalance);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.label21);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Controls.Add(this.label23);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.txtNewTotal);
            this.panel7.Controls.Add(this.txtCurrency);
            this.panel7.Controls.Add(this.txtReturnTotal);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.label15);
            this.panel7.Controls.Add(this.txtOldGrandTotal);
            this.panel7.Controls.Add(this.txtSaleDate);
            this.panel7.Controls.Add(this.cmbPaymentAccount);
            this.panel7.Controls.Add(this.label20);
            this.panel7.Controls.Add(this.label24);
            this.panel7.Controls.Add(this.txtEchangeRate);
            this.panel7.Controls.Add(this.dataGridView1);
            this.panel7.Controls.Add(this.label22);
            this.panel7.Controls.Add(this.txtTotalPaidAmount);
            this.panel7.Controls.Add(this.txtCustomer);
            this.panel7.Controls.Add(this.btnPrint);
            this.panel7.Controls.Add(this.txtAccount);
            this.panel7.Controls.Add(this.txtPaymentMethod);
            this.panel7.Controls.Add(this.txtTotalBalance);
            this.panel7.Controls.Add(this.txtCashReturnToCustomer);
            this.panel7.Controls.Add(this.btnsave);
            this.panel7.Location = new System.Drawing.Point(12, 193);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1873, 833);
            this.panel7.TabIndex = 1671;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(1528, 16);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 14);
            this.chkAll.TabIndex = 1675;
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label8.Location = new System.Drawing.Point(1559, 629);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 16);
            this.label8.TabIndex = 1676;
            this.label8.Text = "Return Amt";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label6.Location = new System.Drawing.Point(1555, 664);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 18);
            this.label6.TabIndex = 1675;
            this.label6.Text = "ACCOUNT:";
            // 
            // cmbPaymentAccount
            // 
            this.cmbPaymentAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentAccount.FormattingEnabled = true;
            this.cmbPaymentAccount.Location = new System.Drawing.Point(1656, 658);
            this.cmbPaymentAccount.Name = "cmbPaymentAccount";
            this.cmbPaymentAccount.Size = new System.Drawing.Size(208, 32);
            this.cmbPaymentAccount.TabIndex = 1674;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(4, 11);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(164, 24);
            this.label28.TabIndex = 19;
            this.label28.Text = "Advance Saerch";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(1409, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 42);
            this.button2.TabIndex = 19;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.gpdate);
            this.panel3.Controls.Add(this.btnSerachAd);
            this.panel3.Controls.Add(this.lblSearchLabel1);
            this.panel3.Controls.Add(this.label31);
            this.panel3.Controls.Add(this.cmbSearchType);
            this.panel3.Controls.Add(this.txt_item_search);
            this.panel3.Location = new System.Drawing.Point(1, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1455, 55);
            this.panel3.TabIndex = 1677;
            // 
            // gpdate
            // 
            this.gpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpdate.Controls.Add(this.dtfrom);
            this.gpdate.Controls.Add(this.lib2);
            this.gpdate.Controls.Add(this.lib1);
            this.gpdate.Controls.Add(this.dtto);
            this.gpdate.Enabled = false;
            this.gpdate.Location = new System.Drawing.Point(887, 10);
            this.gpdate.Name = "gpdate";
            this.gpdate.Size = new System.Drawing.Size(449, 37);
            this.gpdate.TabIndex = 1677;
            // 
            // dtfrom
            // 
            this.dtfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfrom.Location = new System.Drawing.Point(71, 5);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.Size = new System.Drawing.Size(128, 26);
            this.dtfrom.TabIndex = 51;
            // 
            // lib2
            // 
            this.lib2.AutoSize = true;
            this.lib2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib2.ForeColor = System.Drawing.Color.White;
            this.lib2.Location = new System.Drawing.Point(7, 8);
            this.lib2.Name = "lib2";
            this.lib2.Size = new System.Drawing.Size(66, 20);
            this.lib2.TabIndex = 54;
            this.lib2.Text = "ToDate:";
            // 
            // lib1
            // 
            this.lib1.AutoSize = true;
            this.lib1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib1.ForeColor = System.Drawing.Color.White;
            this.lib1.Location = new System.Drawing.Point(205, 8);
            this.lib1.Name = "lib1";
            this.lib1.Size = new System.Drawing.Size(89, 20);
            this.lib1.TabIndex = 48;
            this.lib1.Text = "From Date:";
            // 
            // dtto
            // 
            this.dtto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtto.Location = new System.Drawing.Point(300, 6);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(128, 26);
            this.dtto.TabIndex = 52;
            // 
            // btnSerachAd
            // 
            this.btnSerachAd.Location = new System.Drawing.Point(1342, 9);
            this.btnSerachAd.Name = "btnSerachAd";
            this.btnSerachAd.Size = new System.Drawing.Size(108, 40);
            this.btnSerachAd.TabIndex = 1676;
            this.btnSerachAd.Text = "Search";
            this.btnSerachAd.Click += new System.EventHandler(this.btnSerachAd_Click);
            // 
            // lblSearchLabel1
            // 
            this.lblSearchLabel1.AutoSize = true;
            this.lblSearchLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchLabel1.ForeColor = System.Drawing.Color.White;
            this.lblSearchLabel1.Location = new System.Drawing.Point(443, 16);
            this.lblSearchLabel1.Name = "lblSearchLabel1";
            this.lblSearchLabel1.Size = new System.Drawing.Size(109, 20);
            this.lblSearchLabel1.TabIndex = 1673;
            this.lblSearchLabel1.Text = "Search Value:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.White;
            this.label31.Location = new System.Drawing.Point(5, 16);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(102, 20);
            this.label31.TabIndex = 1672;
            this.label31.Text = "Search Type:";
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchType.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.cmbSearchType.FormattingEnabled = true;
            this.cmbSearchType.Items.AddRange(new object[] {
            "Product BarCode",
            "Product Code",
            "Product Name",
            "Product Name & Sales Date",
            "Customer & Sales Date",
            "Salesman & Sales Date"});
            this.cmbSearchType.Location = new System.Drawing.Point(114, 7);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(305, 39);
            this.cmbSearchType.TabIndex = 1603;
            this.cmbSearchType.SelectionChangeCommitted += new System.EventHandler(this.cmbSearchType_SelectionChangeCommitted);
            // 
            // txt_item_search
            // 
            this.txt_item_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_item_search.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.txt_item_search.Location = new System.Drawing.Point(553, 7);
            this.txt_item_search.Name = "txt_item_search";
            this.txt_item_search.Size = new System.Drawing.Size(305, 38);
            this.txt_item_search.TabIndex = 1600;
            this.txt_item_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_item_search_KeyDown);
            // 
            // lst_Item
            // 
            this.lst_Item.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProductCode,
            this.ProductBarCode,
            this.ProductName,
            this.Quantity,
            this.SalePrice,
            this.Currency,
            this.InvoiceNo,
            this.SaleOrderDate,
            this.SaleOrderTime,
            this.CustomerName});
            this.lst_Item.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_Item.ForeColor = System.Drawing.Color.Black;
            this.lst_Item.FullRowSelect = true;
            this.lst_Item.GridLines = true;
            this.lst_Item.Location = new System.Drawing.Point(1, 105);
            this.lst_Item.Name = "lst_Item";
            this.lst_Item.Size = new System.Drawing.Size(1455, 407);
            this.lst_Item.TabIndex = 1601;
            this.lst_Item.UseCompatibleStateImageBehavior = false;
            this.lst_Item.View = System.Windows.Forms.View.Details;
            this.lst_Item.DoubleClick += new System.EventHandler(this.lst_Item_DoubleClick_1);
            this.lst_Item.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lst_Item_KeyDown);
            // 
            // ProductCode
            // 
            this.ProductCode.Text = "ProductCode";
            this.ProductCode.Width = 150;
            // 
            // ProductBarCode
            // 
            this.ProductBarCode.Text = "Bar Code";
            this.ProductBarCode.Width = 0;
            // 
            // ProductName
            // 
            this.ProductName.Text = "Product Name";
            this.ProductName.Width = 200;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 120;
            // 
            // SalePrice
            // 
            this.SalePrice.Text = "Sale Price";
            this.SalePrice.Width = 120;
            // 
            // Currency
            // 
            this.Currency.Text = "Currency";
            this.Currency.Width = 0;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.Text = "InvoiceNo";
            this.InvoiceNo.Width = 150;
            // 
            // SaleOrderDate
            // 
            this.SaleOrderDate.Text = "Sale Date";
            this.SaleOrderDate.Width = 150;
            // 
            // SaleOrderTime
            // 
            this.SaleOrderTime.Text = "Sale Time";
            this.SaleOrderTime.Width = 115;
            // 
            // CustomerName
            // 
            this.CustomerName.Text = "Customer";
            this.CustomerName.Width = 150;
            // 
            // gpitem_list
            // 
            this.gpitem_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            this.gpitem_list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpitem_list.Controls.Add(this.lst_Item);
            this.gpitem_list.Controls.Add(this.panel3);
            this.gpitem_list.Controls.Add(this.button2);
            this.gpitem_list.Controls.Add(this.label28);
            this.gpitem_list.Location = new System.Drawing.Point(135, 125);
            this.gpitem_list.Name = "gpitem_list";
            this.gpitem_list.Size = new System.Drawing.Size(1460, 517);
            this.gpitem_list.TabIndex = 1672;
            this.gpitem_list.Visible = false;
            // 
            // frmSaleReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.pnlReturn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gpitem_list);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSaleReturn";
            this.Text = "Sale Return";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSaleReturn_Load);
            this.pnlReturn.ResumeLayout(false);
            this.pnlReturn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdvanceSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnsave)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.gpdate.ResumeLayout(false);
            this.gpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSerachAd)).EndInit();
            this.gpitem_list.ResumeLayout(false);
            this.gpitem_list.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtEchangeRate;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.TextBox txtPaymentMethod;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.TextBox txtSaleDate;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCashReturnToCustomer;
        private System.Windows.Forms.TextBox txtOldGrandTotal;
        private System.Windows.Forms.TextBox txtTotalBalance;
        private System.Windows.Forms.TextBox txtTotalPaidAmount;
        private System.Windows.Forms.TextBox txtNewTotal;
        private System.Windows.Forms.TextBox txtCurrency;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.TextBox txtSNO;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtReturnQty;
        private System.Windows.Forms.TextBox txtSoldQty;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlReturn;
        private System.Windows.Forms.TextBox txtSalePrice;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtReturnTotal;
        private System.Windows.Forms.TextBox txtNewBalance;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.GroupBox groupBox5;
        private Telerik.WinControls.UI.RadButton btnsave;
        private System.Windows.Forms.Panel panel7;
        private Telerik.WinControls.UI.RadButton btnAdvanceSearch;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private Telerik.WinControls.UI.RadButton btnPrint;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel gpdate;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private System.Windows.Forms.Label lib2;
        private System.Windows.Forms.Label lib1;
        private Telerik.WinControls.UI.RadButton btnSerachAd;
        private System.Windows.Forms.Label lblSearchLabel1;
        private System.Windows.Forms.TextBox txt_item_search;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox cmbSearchType;
        private System.Windows.Forms.ListView lst_Item;
        private System.Windows.Forms.ColumnHeader ProductCode;
        private System.Windows.Forms.ColumnHeader ProductBarCode;
        private System.Windows.Forms.ColumnHeader ProductName;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader SalePrice;
        private System.Windows.Forms.ColumnHeader Currency;
        private System.Windows.Forms.ColumnHeader InvoiceNo;
        private System.Windows.Forms.ColumnHeader SaleOrderDate;
        private System.Windows.Forms.ColumnHeader SaleOrderTime;
        private System.Windows.Forms.ColumnHeader CustomerName;
        private System.Windows.Forms.Panel gpitem_list;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbPaymentAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SBatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoldQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoldTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaseCurrencyProfitPerUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaseCurrencySalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleManID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaseCurrencyDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Return;
        private System.Windows.Forms.CheckBox chkAll;
    }
}