namespace Stock_System.Forms
{
    partial class frmStock
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStockSummaryReport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnStockReport = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.lblValueType = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.damageOrLostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeExpiryDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label13 = new System.Windows.Forms.Label();
            this.lblStoreID = new System.Windows.Forms.Label();
            this.pnlProduct = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lstProductInStore = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.lst_items = new System.Windows.Forms.ListView();
            this.ExpDate = new System.Windows.Forms.ColumnHeader();
            this.ProductCode = new System.Windows.Forms.ColumnHeader();
            this.ProductName = new System.Windows.Forms.ColumnHeader();
            this.GenericName = new System.Windows.Forms.ColumnHeader();
            this.CategoryName = new System.Windows.Forms.ColumnHeader();
            this.BatchNo = new System.Windows.Forms.ColumnHeader();
            this.ExpiryDate = new System.Windows.Forms.ColumnHeader();
            this.Quantity = new System.Windows.Forms.ColumnHeader();
            this.AvgPrice = new System.Windows.Forms.ColumnHeader();
            this.Total = new System.Windows.Forms.ColumnHeader();
            this.SalePrice = new System.Windows.Forms.ColumnHeader();
            this.SizeName = new System.Windows.Forms.ColumnHeader();
            this.PackingName = new System.Windows.Forms.ColumnHeader();
            this.ManufacturerName = new System.Windows.Forms.ColumnHeader();
            this.StockID = new System.Windows.Forms.ColumnHeader();
            this.pnlQty = new System.Windows.Forms.Panel();
            this.btnChange = new Telerik.WinControls.UI.RadButton();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblLastPrice = new System.Windows.Forms.Label();
            this.txtStockPrice = new System.Windows.Forms.TextBox();
            this.lblLastQty = new System.Windows.Forms.Label();
            this.btnClose1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDamageOrLost = new System.Windows.Forms.Panel();
            this.dtExpiredDate = new System.Windows.Forms.DateTimePicker();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemarksDamageLost = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnDamagLost = new Telerik.WinControls.UI.RadButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQtyDamageLost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlExpiryUpdate = new System.Windows.Forms.Panel();
            this.txtNewExpDate = new System.Windows.Forms.MaskedTextBox();
            this.txtDurgCurrentExpDate = new System.Windows.Forms.TextBox();
            this.txtDurgName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDurgStockID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btnUpdateExpiryDate = new Telerik.WinControls.UI.RadButton();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCloseExp = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlProduct.SuspendLayout();
            this.pnlQty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnChange)).BeginInit();
            this.pnlDamageOrLost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDamagLost)).BeginInit();
            this.pnlExpiryUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateExpiryDate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnStockSummaryReport);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbSearchType);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnStockReport);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtSearchValue);
            this.panel1.Controls.Add(this.lblValueType);
            this.panel1.Location = new System.Drawing.Point(14, 943);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1895, 61);
            this.panel1.TabIndex = 151;
            // 
            // btnStockSummaryReport
            // 
            this.btnStockSummaryReport.BackColor = System.Drawing.Color.Indigo;
            this.btnStockSummaryReport.ForeColor = System.Drawing.Color.White;
            this.btnStockSummaryReport.Location = new System.Drawing.Point(1023, 11);
            this.btnStockSummaryReport.Name = "btnStockSummaryReport";
            this.btnStockSummaryReport.Size = new System.Drawing.Size(91, 38);
            this.btnStockSummaryReport.TabIndex = 504;
            this.btnStockSummaryReport.Text = "Stock Summary Report";
            this.btnStockSummaryReport.UseVisualStyleBackColor = false;
            this.btnStockSummaryReport.Click += new System.EventHandler(this.btnStockSummaryReport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Indigo;
            this.label2.Location = new System.Drawing.Point(2, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 503;
            this.label2.Text = "Search Type:";
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchType.FormattingEnabled = true;
            this.cmbSearchType.Items.AddRange(new object[] {
            "Search By Product Name",
            "Search By Generic Name",
            "Search By Expiry Date",
            "Search By Barcode",
            "All Stock"});
            this.cmbSearchType.Location = new System.Drawing.Point(91, 16);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(248, 28);
            this.cmbSearchType.TabIndex = 162;
            this.cmbSearchType.SelectionChangeCommitted += new System.EventHandler(this.cmbSearchType_SelectionChangeCommitted);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Indigo;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(877, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(71, 38);
            this.btnSearch.TabIndex = 159;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnStockReport
            // 
            this.btnStockReport.BackColor = System.Drawing.Color.Indigo;
            this.btnStockReport.ForeColor = System.Drawing.Color.White;
            this.btnStockReport.Location = new System.Drawing.Point(946, 11);
            this.btnStockReport.Name = "btnStockReport";
            this.btnStockReport.Size = new System.Drawing.Size(71, 38);
            this.btnStockReport.TabIndex = 155;
            this.btnStockReport.Text = "Report";
            this.btnStockReport.UseVisualStyleBackColor = false;
            this.btnStockReport.Click += new System.EventHandler(this.btnStockReport_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(1658, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(219, 29);
            this.textBox1.TabIndex = 14;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Indigo;
            this.label15.Location = new System.Drawing.Point(1537, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(117, 16);
            this.label15.TabIndex = 153;
            this.label15.Text = "Total Stock Value:";
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchValue.Location = new System.Drawing.Point(577, 16);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(292, 29);
            this.txtSearchValue.TabIndex = 12;
            this.txtSearchValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchValue_KeyDown);
            // 
            // lblValueType
            // 
            this.lblValueType.AutoSize = true;
            this.lblValueType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueType.ForeColor = System.Drawing.Color.Indigo;
            this.lblValueType.Location = new System.Drawing.Point(352, 22);
            this.lblValueType.Name = "lblValueType";
            this.lblValueType.Size = new System.Drawing.Size(92, 16);
            this.lblValueType.TabIndex = 13;
            this.lblValueType.Text = "Search Value:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.damageOrLostToolStripMenuItem,
            this.changeExpiryDateToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(177, 92);
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem1.Text = "View All Branch";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem2.Text = "Chanage Quantity";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // damageOrLostToolStripMenuItem
            // 
            this.damageOrLostToolStripMenuItem.Name = "damageOrLostToolStripMenuItem";
            this.damageOrLostToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.damageOrLostToolStripMenuItem.Text = "Damage or Lost";
            this.damageOrLostToolStripMenuItem.Click += new System.EventHandler(this.damageOrLostToolStripMenuItem_Click);
            // 
            // changeExpiryDateToolStripMenuItem
            // 
            this.changeExpiryDateToolStripMenuItem.Name = "changeExpiryDateToolStripMenuItem";
            this.changeExpiryDateToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.changeExpiryDateToolStripMenuItem.Text = "Change Expiry Date";
            this.changeExpiryDateToolStripMenuItem.Click += new System.EventHandler(this.changeExpiryDateToolStripMenuItem_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Orange;
            this.label13.Location = new System.Drawing.Point(16, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(182, 25);
            this.label13.TabIndex = 153;
            this.label13.Text = "STOCK IN HAND";
            // 
            // lblStoreID
            // 
            this.lblStoreID.AutoSize = true;
            this.lblStoreID.Location = new System.Drawing.Point(216, 119);
            this.lblStoreID.Name = "lblStoreID";
            this.lblStoreID.Size = new System.Drawing.Size(35, 13);
            this.lblStoreID.TabIndex = 154;
            this.lblStoreID.Text = "label1";
            this.lblStoreID.Visible = false;
            // 
            // pnlProduct
            // 
            this.pnlProduct.BackColor = System.Drawing.Color.Indigo;
            this.pnlProduct.Controls.Add(this.btnClose);
            this.pnlProduct.Controls.Add(this.label4);
            this.pnlProduct.Controls.Add(this.lstProductInStore);
            this.pnlProduct.Location = new System.Drawing.Point(323, 110);
            this.pnlProduct.Name = "pnlProduct";
            this.pnlProduct.Size = new System.Drawing.Size(767, 396);
            this.pnlProduct.TabIndex = 156;
            this.pnlProduct.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(681, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 32);
            this.btnClose.TabIndex = 1604;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(15, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 20);
            this.label4.TabIndex = 1603;
            this.label4.Text = "PRODUCT IN ALL STORES";
            // 
            // lstProductInStore
            // 
            this.lstProductInStore.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstProductInStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProductInStore.FullRowSelect = true;
            this.lstProductInStore.GridLines = true;
            this.lstProductInStore.Location = new System.Drawing.Point(7, 41);
            this.lstProductInStore.Name = "lstProductInStore";
            this.lstProductInStore.Size = new System.Drawing.Size(754, 348);
            this.lstProductInStore.TabIndex = 1602;
            this.lstProductInStore.UseCompatibleStateImageBehavior = false;
            this.lstProductInStore.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Product Code";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Product Name";
            this.columnHeader2.Width = 350;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Available Qty";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Store Name";
            this.columnHeader4.Width = 150;
            // 
            // lst_items
            // 
            this.lst_items.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ExpDate,
            this.ProductCode,
            this.ProductName,
            this.GenericName,
            this.CategoryName,
            this.BatchNo,
            this.ExpiryDate,
            this.Quantity,
            this.AvgPrice,
            this.Total,
            this.SalePrice,
            this.SizeName,
            this.PackingName,
            this.ManufacturerName,
            this.StockID});
            this.lst_items.ContextMenuStrip = this.contextMenuStrip1;
            this.lst_items.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_items.FullRowSelect = true;
            this.lst_items.GridLines = true;
            this.lst_items.Location = new System.Drawing.Point(15, 148);
            this.lst_items.Name = "lst_items";
            this.lst_items.OwnerDraw = true;
            this.lst_items.Size = new System.Drawing.Size(1895, 789);
            this.lst_items.TabIndex = 502;
            this.lst_items.UseCompatibleStateImageBehavior = false;
            this.lst_items.View = System.Windows.Forms.View.Details;
            this.lst_items.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView_DrawColumnHeader);
            this.lst_items.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lst_Item_DrawItem);
            // 
            // ExpDate
            // 
            this.ExpDate.Text = "ExpDate";
            this.ExpDate.Width = 0;
            // 
            // ProductCode
            // 
            this.ProductCode.Text = "Product Code";
            this.ProductCode.Width = 0;
            // 
            // ProductName
            // 
            this.ProductName.Text = "Product Name";
            this.ProductName.Width = 300;
            // 
            // GenericName
            // 
            this.GenericName.Text = "Generic Name";
            this.GenericName.Width = 300;
            // 
            // CategoryName
            // 
            this.CategoryName.Text = "Category";
            this.CategoryName.Width = 200;
            // 
            // BatchNo
            // 
            this.BatchNo.Text = "BatchNo";
            this.BatchNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BatchNo.Width = 150;
            // 
            // ExpiryDate
            // 
            this.ExpiryDate.Text = "Expiry Date";
            this.ExpiryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ExpiryDate.Width = 150;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Quantity.Width = 100;
            // 
            // AvgPrice
            // 
            this.AvgPrice.Text = "Stock Price";
            this.AvgPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AvgPrice.Width = 100;
            // 
            // Total
            // 
            this.Total.Text = "Total";
            this.Total.Width = 150;
            // 
            // SalePrice
            // 
            this.SalePrice.Text = "SalePrice";
            this.SalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SalePrice.Width = 100;
            // 
            // SizeName
            // 
            this.SizeName.Text = "Size";
            this.SizeName.Width = 70;
            // 
            // PackingName
            // 
            this.PackingName.Text = "Packing";
            this.PackingName.Width = 80;
            // 
            // ManufacturerName
            // 
            this.ManufacturerName.Text = "Manufacturer";
            this.ManufacturerName.Width = 150;
            // 
            // StockID
            // 
            this.StockID.Width = 0;
            // 
            // pnlQty
            // 
            this.pnlQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.pnlQty.Controls.Add(this.btnChange);
            this.pnlQty.Controls.Add(this.txtQty);
            this.pnlQty.Controls.Add(this.lblLastPrice);
            this.pnlQty.Controls.Add(this.txtStockPrice);
            this.pnlQty.Controls.Add(this.lblLastQty);
            this.pnlQty.Controls.Add(this.btnClose1);
            this.pnlQty.Controls.Add(this.label1);
            this.pnlQty.Location = new System.Drawing.Point(592, 100);
            this.pnlQty.Name = "pnlQty";
            this.pnlQty.Size = new System.Drawing.Size(676, 227);
            this.pnlQty.TabIndex = 503;
            this.pnlQty.Visible = false;
            // 
            // btnChange
            // 
            this.btnChange.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnChange.Location = new System.Drawing.Point(526, 139);
            this.btnChange.Name = "btnChange";
            // 
            // 
            // 
            this.btnChange.RootElement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnChange.Size = new System.Drawing.Size(97, 44);
            this.btnChange.TabIndex = 1614;
            this.btnChange.Text = "Change";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnChange.GetChildAt(0))).Text = "Change";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnChange.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnChange.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnChange.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnChange.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.White;
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtQty.Location = new System.Drawing.Point(199, 67);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(293, 29);
            this.txtQty.TabIndex = 1605;
            // 
            // lblLastPrice
            // 
            this.lblLastPrice.AutoSize = true;
            this.lblLastPrice.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastPrice.ForeColor = System.Drawing.Color.White;
            this.lblLastPrice.Location = new System.Drawing.Point(97, 106);
            this.lblLastPrice.Name = "lblLastPrice";
            this.lblLastPrice.Size = new System.Drawing.Size(96, 16);
            this.lblLastPrice.TabIndex = 1607;
            this.lblLastPrice.Text = "STOCK PRICE";
            // 
            // txtStockPrice
            // 
            this.txtStockPrice.BackColor = System.Drawing.Color.White;
            this.txtStockPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStockPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtStockPrice.Location = new System.Drawing.Point(199, 100);
            this.txtStockPrice.Name = "txtStockPrice";
            this.txtStockPrice.Size = new System.Drawing.Size(293, 29);
            this.txtStockPrice.TabIndex = 1606;
            // 
            // lblLastQty
            // 
            this.lblLastQty.AutoSize = true;
            this.lblLastQty.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastQty.ForeColor = System.Drawing.Color.White;
            this.lblLastQty.Location = new System.Drawing.Point(97, 73);
            this.lblLastQty.Name = "lblLastQty";
            this.lblLastQty.Size = new System.Drawing.Size(73, 16);
            this.lblLastQty.TabIndex = 1608;
            this.lblLastQty.Text = "QUANTITY";
            // 
            // btnClose1
            // 
            this.btnClose1.BackColor = System.Drawing.Color.Red;
            this.btnClose1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose1.ForeColor = System.Drawing.Color.White;
            this.btnClose1.Location = new System.Drawing.Point(631, 3);
            this.btnClose1.Name = "btnClose1";
            this.btnClose1.Size = new System.Drawing.Size(42, 41);
            this.btnClose1.TabIndex = 1604;
            this.btnClose1.Text = "X";
            this.btnClose1.UseVisualStyleBackColor = false;
            this.btnClose1.Click += new System.EventHandler(this.btnClose1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 20);
            this.label1.TabIndex = 1603;
            this.label1.Text = "CHANGE ITEM VALUE";
            // 
            // pnlDamageOrLost
            // 
            this.pnlDamageOrLost.BackColor = System.Drawing.Color.Red;
            this.pnlDamageOrLost.Controls.Add(this.dtExpiredDate);
            this.pnlDamageOrLost.Controls.Add(this.txtItemName);
            this.pnlDamageOrLost.Controls.Add(this.label9);
            this.pnlDamageOrLost.Controls.Add(this.txtItemCode);
            this.pnlDamageOrLost.Controls.Add(this.label8);
            this.pnlDamageOrLost.Controls.Add(this.label7);
            this.pnlDamageOrLost.Controls.Add(this.txtRemarksDamageLost);
            this.pnlDamageOrLost.Controls.Add(this.cmbStatus);
            this.pnlDamageOrLost.Controls.Add(this.btnDamagLost);
            this.pnlDamageOrLost.Controls.Add(this.label3);
            this.pnlDamageOrLost.Controls.Add(this.txtQtyDamageLost);
            this.pnlDamageOrLost.Controls.Add(this.label5);
            this.pnlDamageOrLost.Controls.Add(this.button1);
            this.pnlDamageOrLost.Controls.Add(this.label6);
            this.pnlDamageOrLost.Location = new System.Drawing.Point(272, 117);
            this.pnlDamageOrLost.Name = "pnlDamageOrLost";
            this.pnlDamageOrLost.Size = new System.Drawing.Size(591, 342);
            this.pnlDamageOrLost.TabIndex = 504;
            this.pnlDamageOrLost.Visible = false;
            // 
            // dtExpiredDate
            // 
            this.dtExpiredDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtExpiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtExpiredDate.Location = new System.Drawing.Point(434, 136);
            this.dtExpiredDate.Name = "dtExpiredDate";
            this.dtExpiredDate.Size = new System.Drawing.Size(108, 26);
            this.dtExpiredDate.TabIndex = 1623;
            this.dtExpiredDate.Visible = false;
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.White;
            this.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtItemName.Location = new System.Drawing.Point(140, 99);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(293, 29);
            this.txtItemName.TabIndex = 1621;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(53, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 16);
            this.label9.TabIndex = 1622;
            this.label9.Text = "ITEM NAME:";
            // 
            // txtItemCode
            // 
            this.txtItemCode.BackColor = System.Drawing.Color.White;
            this.txtItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtItemCode.Location = new System.Drawing.Point(140, 64);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.ReadOnly = true;
            this.txtItemCode.Size = new System.Drawing.Size(293, 29);
            this.txtItemCode.TabIndex = 1619;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(53, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 16);
            this.label8.TabIndex = 1620;
            this.label8.Text = "ITEM CODE:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(53, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 16);
            this.label7.TabIndex = 1618;
            this.label7.Text = "REMARKS:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemarksDamageLost
            // 
            this.txtRemarksDamageLost.BackColor = System.Drawing.Color.White;
            this.txtRemarksDamageLost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarksDamageLost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtRemarksDamageLost.Location = new System.Drawing.Point(140, 203);
            this.txtRemarksDamageLost.Multiline = true;
            this.txtRemarksDamageLost.Name = "txtRemarksDamageLost";
            this.txtRemarksDamageLost.Size = new System.Drawing.Size(293, 83);
            this.txtRemarksDamageLost.TabIndex = 1617;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Lost ",
            "Damage",
            "Expired"});
            this.cmbStatus.Location = new System.Drawing.Point(140, 134);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(292, 28);
            this.cmbStatus.TabIndex = 1616;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // btnDamagLost
            // 
            this.btnDamagLost.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDamagLost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDamagLost.Location = new System.Drawing.Point(141, 290);
            this.btnDamagLost.Name = "btnDamagLost";
            // 
            // 
            // 
            this.btnDamagLost.RootElement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDamagLost.Size = new System.Drawing.Size(97, 42);
            this.btnDamagLost.TabIndex = 1614;
            this.btnDamagLost.Text = "Submit";
            this.btnDamagLost.Click += new System.EventHandler(this.btnDamagLost_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDamagLost.GetChildAt(0))).Text = "Submit";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnDamagLost.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnDamagLost.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnDamagLost.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnDamagLost.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(53, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 1607;
            this.label3.Text = "STATUS:";
            // 
            // txtQtyDamageLost
            // 
            this.txtQtyDamageLost.BackColor = System.Drawing.Color.White;
            this.txtQtyDamageLost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtyDamageLost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtQtyDamageLost.Location = new System.Drawing.Point(140, 168);
            this.txtQtyDamageLost.Name = "txtQtyDamageLost";
            this.txtQtyDamageLost.Size = new System.Drawing.Size(293, 29);
            this.txtQtyDamageLost.TabIndex = 1606;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(53, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 1608;
            this.label5.Text = "QUANTITY:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Orange;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(547, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 41);
            this.button1.TabIndex = 1604;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(9, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 20);
            this.label6.TabIndex = 1603;
            this.label6.Text = "Damage or Lost Item";
            // 
            // pnlExpiryUpdate
            // 
            this.pnlExpiryUpdate.BackColor = System.Drawing.Color.Orange;
            this.pnlExpiryUpdate.Controls.Add(this.txtNewExpDate);
            this.pnlExpiryUpdate.Controls.Add(this.txtDurgCurrentExpDate);
            this.pnlExpiryUpdate.Controls.Add(this.txtDurgName);
            this.pnlExpiryUpdate.Controls.Add(this.label10);
            this.pnlExpiryUpdate.Controls.Add(this.txtDurgStockID);
            this.pnlExpiryUpdate.Controls.Add(this.label11);
            this.pnlExpiryUpdate.Controls.Add(this.label12);
            this.pnlExpiryUpdate.Controls.Add(this.textBox4);
            this.pnlExpiryUpdate.Controls.Add(this.btnUpdateExpiryDate);
            this.pnlExpiryUpdate.Controls.Add(this.label14);
            this.pnlExpiryUpdate.Controls.Add(this.btnCloseExp);
            this.pnlExpiryUpdate.Controls.Add(this.label17);
            this.pnlExpiryUpdate.Location = new System.Drawing.Point(553, 87);
            this.pnlExpiryUpdate.Name = "pnlExpiryUpdate";
            this.pnlExpiryUpdate.Size = new System.Drawing.Size(591, 342);
            this.pnlExpiryUpdate.TabIndex = 506;
            this.pnlExpiryUpdate.Visible = false;
            // 
            // txtNewExpDate
            // 
            this.txtNewExpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.txtNewExpDate.Location = new System.Drawing.Point(351, 135);
            this.txtNewExpDate.Mask = "00/0000";
            this.txtNewExpDate.Name = "txtNewExpDate";
            this.txtNewExpDate.Size = new System.Drawing.Size(105, 38);
            this.txtNewExpDate.TabIndex = 1625;
            // 
            // txtDurgCurrentExpDate
            // 
            this.txtDurgCurrentExpDate.BackColor = System.Drawing.Color.White;
            this.txtDurgCurrentExpDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDurgCurrentExpDate.Enabled = false;
            this.txtDurgCurrentExpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtDurgCurrentExpDate.Location = new System.Drawing.Point(163, 138);
            this.txtDurgCurrentExpDate.Name = "txtDurgCurrentExpDate";
            this.txtDurgCurrentExpDate.ReadOnly = true;
            this.txtDurgCurrentExpDate.Size = new System.Drawing.Size(182, 29);
            this.txtDurgCurrentExpDate.TabIndex = 1624;
            // 
            // txtDurgName
            // 
            this.txtDurgName.BackColor = System.Drawing.Color.White;
            this.txtDurgName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDurgName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtDurgName.Location = new System.Drawing.Point(163, 101);
            this.txtDurgName.Name = "txtDurgName";
            this.txtDurgName.ReadOnly = true;
            this.txtDurgName.Size = new System.Drawing.Size(293, 29);
            this.txtDurgName.TabIndex = 1621;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(76, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 16);
            this.label10.TabIndex = 1622;
            this.label10.Text = "ITEM NAME:";
            // 
            // txtDurgStockID
            // 
            this.txtDurgStockID.BackColor = System.Drawing.Color.White;
            this.txtDurgStockID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDurgStockID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtDurgStockID.Location = new System.Drawing.Point(163, 64);
            this.txtDurgStockID.Name = "txtDurgStockID";
            this.txtDurgStockID.ReadOnly = true;
            this.txtDurgStockID.Size = new System.Drawing.Size(293, 29);
            this.txtDurgStockID.TabIndex = 1619;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(76, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 16);
            this.label11.TabIndex = 1620;
            this.label11.Text = "STOCK ID:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(76, 180);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 16);
            this.label12.TabIndex = 1618;
            this.label12.Text = "REMARKS:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.White;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.textBox4.Location = new System.Drawing.Point(163, 175);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(293, 83);
            this.textBox4.TabIndex = 1617;
            // 
            // btnUpdateExpiryDate
            // 
            this.btnUpdateExpiryDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdateExpiryDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnUpdateExpiryDate.Location = new System.Drawing.Point(169, 274);
            this.btnUpdateExpiryDate.Name = "btnUpdateExpiryDate";
            // 
            // 
            // 
            this.btnUpdateExpiryDate.RootElement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnUpdateExpiryDate.Size = new System.Drawing.Size(97, 42);
            this.btnUpdateExpiryDate.TabIndex = 1614;
            this.btnUpdateExpiryDate.Text = "Submit";
            this.btnUpdateExpiryDate.Click += new System.EventHandler(this.btnUpdateExpiryDate_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnUpdateExpiryDate.GetChildAt(0))).Text = "Submit";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnUpdateExpiryDate.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnUpdateExpiryDate.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnUpdateExpiryDate.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnUpdateExpiryDate.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(76, 146);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 16);
            this.label14.TabIndex = 1607;
            this.label14.Text = "Expiry Date:";
            // 
            // btnCloseExp
            // 
            this.btnCloseExp.BackColor = System.Drawing.Color.Red;
            this.btnCloseExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseExp.ForeColor = System.Drawing.Color.White;
            this.btnCloseExp.Location = new System.Drawing.Point(547, 3);
            this.btnCloseExp.Name = "btnCloseExp";
            this.btnCloseExp.Size = new System.Drawing.Size(42, 41);
            this.btnCloseExp.TabIndex = 1604;
            this.btnCloseExp.Text = "X";
            this.btnCloseExp.UseVisualStyleBackColor = false;
            this.btnCloseExp.Click += new System.EventHandler(this.btnCloseExp_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(9, 12);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(168, 20);
            this.label17.TabIndex = 1603;
            this.label17.Text = "Change Expiry Date";
            // 
            // frmStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.pnlQty);
            this.Controls.Add(this.pnlExpiryUpdate);
            this.Controls.Add(this.pnlDamageOrLost);
            this.Controls.Add(this.lst_items);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblStoreID);
            this.Controls.Add(this.pnlProduct);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStock";
            this.Text = "Stock In Hand";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmStock_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlProduct.ResumeLayout(false);
            this.pnlProduct.PerformLayout();
            this.pnlQty.ResumeLayout(false);
            this.pnlQty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnChange)).EndInit();
            this.pnlDamageOrLost.ResumeLayout(false);
            this.pnlDamageOrLost.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDamagLost)).EndInit();
            this.pnlExpiryUpdate.ResumeLayout(false);
            this.pnlExpiryUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateExpiryDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStockReport;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Label lblValueType;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblStoreID;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Panel pnlProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lstProductInStore;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lst_items;
        private System.Windows.Forms.ColumnHeader ProductCode;
        private System.Windows.Forms.ColumnHeader ProductName;
        private System.Windows.Forms.ColumnHeader GenericName;
        private System.Windows.Forms.ColumnHeader CategoryName;
        private System.Windows.Forms.ColumnHeader SizeName;
        private System.Windows.Forms.ColumnHeader PackingName;
        private System.Windows.Forms.ColumnHeader ManufacturerName;
        private System.Windows.Forms.ColumnHeader SalePrice;
        private System.Windows.Forms.ColumnHeader BatchNo;
        private System.Windows.Forms.ColumnHeader ExpiryDate;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader AvgPrice;
        private System.Windows.Forms.ComboBox cmbSearchType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader Total;
        private System.Windows.Forms.ColumnHeader ExpDate;
        private System.Windows.Forms.Button btnStockSummaryReport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ColumnHeader StockID;
        private System.Windows.Forms.Panel pnlQty;
        private Telerik.WinControls.UI.RadButton btnChange;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblLastPrice;
        private System.Windows.Forms.TextBox txtStockPrice;
        private System.Windows.Forms.Label lblLastQty;
        private System.Windows.Forms.Button btnClose1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlDamageOrLost;
        private System.Windows.Forms.DateTimePicker dtExpiredDate;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRemarksDamageLost;
        private System.Windows.Forms.ComboBox cmbStatus;
        private Telerik.WinControls.UI.RadButton btnDamagLost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQtyDamageLost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem damageOrLostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeExpiryDateToolStripMenuItem;
        private System.Windows.Forms.Panel pnlExpiryUpdate;
        private System.Windows.Forms.MaskedTextBox txtNewExpDate;
        private System.Windows.Forms.TextBox txtDurgCurrentExpDate;
        private System.Windows.Forms.TextBox txtDurgName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDurgStockID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox4;
        private Telerik.WinControls.UI.RadButton btnUpdateExpiryDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnCloseExp;
        private System.Windows.Forms.Label label17;

    }
}