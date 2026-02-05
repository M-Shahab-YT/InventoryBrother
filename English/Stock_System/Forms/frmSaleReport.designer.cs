namespace Stock_System.Forms
{
    partial class frmSaleReport
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
            this.txt_Invoice = new System.Windows.Forms.TextBox();
            this.lib1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalProfit = new System.Windows.Forms.Label();
            this.lib2 = new System.Windows.Forms.Label();
            this.lstSaleView = new System.Windows.Forms.ListView();
            this.Date = new System.Windows.Forms.ColumnHeader();
            this.Time = new System.Windows.Forms.ColumnHeader();
            this.InvoiceNo = new System.Windows.Forms.ColumnHeader();
            this.CustomerID = new System.Windows.Forms.ColumnHeader();
            this.CustomerName = new System.Windows.Forms.ColumnHeader();
            this.EnteredBy = new System.Windows.Forms.ColumnHeader();
            this.TotalAmount = new System.Windows.Forms.ColumnHeader();
            this.PaidAmount = new System.Windows.Forms.ColumnHeader();
            this.BalanceAmount = new System.Windows.Forms.ColumnHeader();
            this.Status = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.btnReport = new Telerik.WinControls.UI.RadButton();
            this.gpinvioce = new System.Windows.Forms.Panel();
            this.gpdate = new System.Windows.Forms.Panel();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.pnlProduct = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalProfit = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.chkA4Reprint = new System.Windows.Forms.CheckBox();
            this.btnPrintInvoice = new Telerik.WinControls.UI.RadButton();
            this.lstInvoiceDetail = new System.Windows.Forms.ListView();
            this.itemeid = new System.Windows.Forms.ColumnHeader();
            this.ItemName = new System.Windows.Forms.ColumnHeader();
            this.qty = new System.Windows.Forms.ColumnHeader();
            this.rate = new System.Windows.Forms.ColumnHeader();
            this.Discount = new System.Windows.Forms.ColumnHeader();
            this.totalAmt = new System.Windows.Forms.ColumnHeader();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotalReturnValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalSaleValue = new System.Windows.Forms.TextBox();
            this.lstSearch = new System.Windows.Forms.ListBox();
            this.txtNetSaleValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlSaleReturn = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalReturnAmount = new System.Windows.Forms.Label();
            this.btnPrintReturn = new Telerik.WinControls.UI.RadButton();
            this.lstSaleReturn = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.lblSaleReturnID = new System.Windows.Forms.Label();
            this.btnCloseReturn = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReport)).BeginInit();
            this.gpinvioce.SuspendLayout();
            this.gpdate.SuspendLayout();
            this.pnlProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintInvoice)).BeginInit();
            this.pnlSaleReturn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Invoice
            // 
            this.txt_Invoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Invoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Invoice.Location = new System.Drawing.Point(76, 4);
            this.txt_Invoice.Name = "txt_Invoice";
            this.txt_Invoice.Size = new System.Drawing.Size(281, 29);
            this.txt_Invoice.TabIndex = 49;
            // 
            // lib1
            // 
            this.lib1.AutoSize = true;
            this.lib1.Location = new System.Drawing.Point(5, 11);
            this.lib1.Name = "lib1";
            this.lib1.Size = new System.Drawing.Size(60, 13);
            this.lib1.TabIndex = 48;
            this.lib1.Text = "From Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Search Text:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTotalProfit
            // 
            this.txtTotalProfit.AutoSize = true;
            this.txtTotalProfit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalProfit.ForeColor = System.Drawing.Color.White;
            this.txtTotalProfit.Location = new System.Drawing.Point(1161, 9);
            this.txtTotalProfit.Name = "txtTotalProfit";
            this.txtTotalProfit.Size = new System.Drawing.Size(18, 19);
            this.txtTotalProfit.TabIndex = 164;
            this.txtTotalProfit.Text = "0";
            // 
            // lib2
            // 
            this.lib2.AutoSize = true;
            this.lib2.Location = new System.Drawing.Point(262, 11);
            this.lib2.Name = "lib2";
            this.lib2.Size = new System.Drawing.Size(42, 13);
            this.lib2.TabIndex = 54;
            this.lib2.Text = "ToDate";
            // 
            // lstSaleView
            // 
            this.lstSaleView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.Time,
            this.InvoiceNo,
            this.CustomerID,
            this.CustomerName,
            this.EnteredBy,
            this.TotalAmount,
            this.PaidAmount,
            this.BalanceAmount,
            this.Status});
            this.lstSaleView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSaleView.FullRowSelect = true;
            this.lstSaleView.GridLines = true;
            this.lstSaleView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstSaleView.Location = new System.Drawing.Point(17, 83);
            this.lstSaleView.Name = "lstSaleView";
            this.lstSaleView.Size = new System.Drawing.Size(1868, 757);
            this.lstSaleView.TabIndex = 152;
            this.lstSaleView.UseCompatibleStateImageBehavior = false;
            this.lstSaleView.View = System.Windows.Forms.View.Details;
            this.lstSaleView.DoubleClick += new System.EventHandler(this.lstSaleView_DoubleClick);
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 200;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 100;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.Text = "Invoice No/Bill No";
            this.InvoiceNo.Width = 200;
            // 
            // CustomerID
            // 
            this.CustomerID.Text = "Customer ID";
            this.CustomerID.Width = 320;
            // 
            // CustomerName
            // 
            this.CustomerName.Text = "Customer";
            this.CustomerName.Width = 200;
            // 
            // EnteredBy
            // 
            this.EnteredBy.Text = "User";
            this.EnteredBy.Width = 150;
            // 
            // TotalAmount
            // 
            this.TotalAmount.Text = "Total Amount";
            this.TotalAmount.Width = 150;
            // 
            // PaidAmount
            // 
            this.PaidAmount.Text = "Paid Amount";
            this.PaidAmount.Width = 150;
            // 
            // BalanceAmount
            // 
            this.BalanceAmount.Text = "Balance Amount";
            this.BalanceAmount.Width = 150;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 180;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(18, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 25);
            this.label3.TabIndex = 158;
            this.label3.Text = "SALES REPORT";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(679, 889);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(71, 64);
            this.btnSearch.TabIndex = 168;
            this.btnSearch.Text = "View";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(752, 889);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(71, 64);
            this.btnReport.TabIndex = 169;
            this.btnReport.Text = "Report";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // gpinvioce
            // 
            this.gpinvioce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpinvioce.Controls.Add(this.label4);
            this.gpinvioce.Controls.Add(this.txt_Invoice);
            this.gpinvioce.Enabled = false;
            this.gpinvioce.Location = new System.Drawing.Point(166, 874);
            this.gpinvioce.Name = "gpinvioce";
            this.gpinvioce.Size = new System.Drawing.Size(507, 37);
            this.gpinvioce.TabIndex = 170;
            // 
            // gpdate
            // 
            this.gpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpdate.Controls.Add(this.dtto);
            this.gpdate.Controls.Add(this.dtfrom);
            this.gpdate.Controls.Add(this.lib2);
            this.gpdate.Controls.Add(this.lib1);
            this.gpdate.Location = new System.Drawing.Point(166, 916);
            this.gpdate.Name = "gpdate";
            this.gpdate.Size = new System.Drawing.Size(507, 37);
            this.gpdate.TabIndex = 171;
            // 
            // dtto
            // 
            this.dtto.CalendarFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtto.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dtto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtto.Location = new System.Drawing.Point(308, 3);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(194, 29);
            this.dtto.TabIndex = 1662;
            // 
            // dtfrom
            // 
            this.dtfrom.CalendarFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtfrom.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dtfrom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtfrom.Location = new System.Drawing.Point(67, 3);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.Size = new System.Drawing.Size(196, 29);
            this.dtfrom.TabIndex = 1661;
            // 
            // pnlProduct
            // 
            this.pnlProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.pnlProduct.Controls.Add(this.label5);
            this.pnlProduct.Controls.Add(this.label1);
            this.pnlProduct.Controls.Add(this.lblTotalProfit);
            this.pnlProduct.Controls.Add(this.lblTotalAmount);
            this.pnlProduct.Controls.Add(this.chkA4Reprint);
            this.pnlProduct.Controls.Add(this.btnPrintInvoice);
            this.pnlProduct.Controls.Add(this.lstInvoiceDetail);
            this.pnlProduct.Controls.Add(this.lblInvoiceNo);
            this.pnlProduct.Controls.Add(this.btnClose);
            this.pnlProduct.Controls.Add(this.label2);
            this.pnlProduct.Location = new System.Drawing.Point(488, 59);
            this.pnlProduct.Name = "pnlProduct";
            this.pnlProduct.Size = new System.Drawing.Size(836, 483);
            this.pnlProduct.TabIndex = 173;
            this.pnlProduct.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(270, 442);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 18);
            this.label5.TabIndex = 1665;
            this.label5.Text = "Total Profit:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 442);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 18);
            this.label1.TabIndex = 1664;
            this.label1.Text = "Total Amount:";
            // 
            // lblTotalProfit
            // 
            this.lblTotalProfit.AutoSize = true;
            this.lblTotalProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProfit.ForeColor = System.Drawing.Color.White;
            this.lblTotalProfit.Location = new System.Drawing.Point(378, 442);
            this.lblTotalProfit.Name = "lblTotalProfit";
            this.lblTotalProfit.Size = new System.Drawing.Size(18, 20);
            this.lblTotalProfit.TabIndex = 1663;
            this.lblTotalProfit.Text = "0";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.White;
            this.lblTotalAmount.Location = new System.Drawing.Point(162, 442);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(18, 20);
            this.lblTotalAmount.TabIndex = 1662;
            this.lblTotalAmount.Text = "0";
            // 
            // chkA4Reprint
            // 
            this.chkA4Reprint.AutoSize = true;
            this.chkA4Reprint.Checked = true;
            this.chkA4Reprint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkA4Reprint.ForeColor = System.Drawing.Color.White;
            this.chkA4Reprint.Location = new System.Drawing.Point(605, 444);
            this.chkA4Reprint.Name = "chkA4Reprint";
            this.chkA4Reprint.Size = new System.Drawing.Size(128, 17);
            this.chkA4Reprint.TabIndex = 1661;
            this.chkA4Reprint.Text = "A4 Size Print Format";
            this.chkA4Reprint.UseVisualStyleBackColor = true;
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.Location = new System.Drawing.Point(739, 434);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(81, 37);
            this.btnPrintInvoice.TabIndex = 1636;
            this.btnPrintInvoice.Text = "Print";
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);
            // 
            // lstInvoiceDetail
            // 
            this.lstInvoiceDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.itemeid,
            this.ItemName,
            this.qty,
            this.rate,
            this.Discount,
            this.totalAmt});
            this.lstInvoiceDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstInvoiceDetail.FullRowSelect = true;
            this.lstInvoiceDetail.GridLines = true;
            this.lstInvoiceDetail.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstInvoiceDetail.Location = new System.Drawing.Point(6, 56);
            this.lstInvoiceDetail.Name = "lstInvoiceDetail";
            this.lstInvoiceDetail.Size = new System.Drawing.Size(826, 368);
            this.lstInvoiceDetail.TabIndex = 1606;
            this.lstInvoiceDetail.UseCompatibleStateImageBehavior = false;
            this.lstInvoiceDetail.View = System.Windows.Forms.View.Details;
            // 
            // itemeid
            // 
            this.itemeid.Text = "Product Code";
            this.itemeid.Width = 120;
            // 
            // ItemName
            // 
            this.ItemName.Text = "Product Name";
            this.ItemName.Width = 250;
            // 
            // qty
            // 
            this.qty.Text = "Quantity";
            this.qty.Width = 100;
            // 
            // rate
            // 
            this.rate.Text = "Sale Price";
            this.rate.Width = 100;
            // 
            // Discount
            // 
            this.Discount.Text = "Discount";
            this.Discount.Width = 100;
            // 
            // totalAmt
            // 
            this.totalAmt.Text = "Total";
            this.totalAmt.Width = 120;
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNo.ForeColor = System.Drawing.Color.White;
            this.lblInvoiceNo.Location = new System.Drawing.Point(289, 17);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(27, 20);
            this.lblInvoiceNo.TabIndex = 1605;
            this.lblInvoiceNo.Text = "11";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(793, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(39, 32);
            this.btnClose.TabIndex = 1604;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 20);
            this.label2.TabIndex = 1603;
            this.label2.Text = "Sale Detail of Invoice#: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1579, 889);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 13);
            this.label10.TabIndex = 182;
            this.label10.Text = "Total Return Value:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalReturnValue
            // 
            this.txtTotalReturnValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalReturnValue.Enabled = false;
            this.txtTotalReturnValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalReturnValue.Location = new System.Drawing.Point(1688, 879);
            this.txtTotalReturnValue.Name = "txtTotalReturnValue";
            this.txtTotalReturnValue.Size = new System.Drawing.Size(188, 29);
            this.txtTotalReturnValue.TabIndex = 183;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1579, 856);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 180;
            this.label7.Text = "Total Sale Value:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalSaleValue
            // 
            this.txtTotalSaleValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalSaleValue.Enabled = false;
            this.txtTotalSaleValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSaleValue.Location = new System.Drawing.Point(1688, 846);
            this.txtTotalSaleValue.Name = "txtTotalSaleValue";
            this.txtTotalSaleValue.Size = new System.Drawing.Size(188, 29);
            this.txtTotalSaleValue.TabIndex = 181;
            // 
            // lstSearch
            // 
            this.lstSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstSearch.FormattingEnabled = true;
            this.lstSearch.ItemHeight = 15;
            this.lstSearch.Items.AddRange(new object[] {
            "Search By Invoice No",
            "Search By Date",
            "By Customer ID & Date",
            "By Customer & Date",
            "By User & Date"});
            this.lstSearch.Location = new System.Drawing.Point(18, 874);
            this.lstSearch.Name = "lstSearch";
            this.lstSearch.Size = new System.Drawing.Size(142, 79);
            this.lstSearch.TabIndex = 1657;
            this.lstSearch.SelectedIndexChanged += new System.EventHandler(this.lstSearch_SelectedIndexChanged);
            // 
            // txtNetSaleValue
            // 
            this.txtNetSaleValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNetSaleValue.Enabled = false;
            this.txtNetSaleValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetSaleValue.Location = new System.Drawing.Point(1688, 912);
            this.txtNetSaleValue.Name = "txtNetSaleValue";
            this.txtNetSaleValue.Size = new System.Drawing.Size(188, 29);
            this.txtNetSaleValue.TabIndex = 185;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1579, 922);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 184;
            this.label6.Text = "Total Net Value:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSaleReturn
            // 
            this.pnlSaleReturn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlSaleReturn.Controls.Add(this.label9);
            this.pnlSaleReturn.Controls.Add(this.lblTotalReturnAmount);
            this.pnlSaleReturn.Controls.Add(this.btnPrintReturn);
            this.pnlSaleReturn.Controls.Add(this.lstSaleReturn);
            this.pnlSaleReturn.Controls.Add(this.lblSaleReturnID);
            this.pnlSaleReturn.Controls.Add(this.btnCloseReturn);
            this.pnlSaleReturn.Controls.Add(this.label14);
            this.pnlSaleReturn.Location = new System.Drawing.Point(732, 38);
            this.pnlSaleReturn.Name = "pnlSaleReturn";
            this.pnlSaleReturn.Size = new System.Drawing.Size(836, 483);
            this.pnlSaleReturn.TabIndex = 1658;
            this.pnlSaleReturn.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(17, 441);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(168, 18);
            this.label9.TabIndex = 1664;
            this.label9.Text = "Total Return Amount:";
            // 
            // lblTotalReturnAmount
            // 
            this.lblTotalReturnAmount.AutoSize = true;
            this.lblTotalReturnAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalReturnAmount.ForeColor = System.Drawing.Color.White;
            this.lblTotalReturnAmount.Location = new System.Drawing.Point(253, 441);
            this.lblTotalReturnAmount.Name = "lblTotalReturnAmount";
            this.lblTotalReturnAmount.Size = new System.Drawing.Size(18, 20);
            this.lblTotalReturnAmount.TabIndex = 1662;
            this.lblTotalReturnAmount.Text = "0";
            // 
            // btnPrintReturn
            // 
            this.btnPrintReturn.Location = new System.Drawing.Point(739, 434);
            this.btnPrintReturn.Name = "btnPrintReturn";
            this.btnPrintReturn.Size = new System.Drawing.Size(81, 37);
            this.btnPrintReturn.TabIndex = 1636;
            this.btnPrintReturn.Text = "Print";
            this.btnPrintReturn.Click += new System.EventHandler(this.btnPrintReturn_Click);
            // 
            // lstSaleReturn
            // 
            this.lstSaleReturn.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6});
            this.lstSaleReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSaleReturn.FullRowSelect = true;
            this.lstSaleReturn.GridLines = true;
            this.lstSaleReturn.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstSaleReturn.Location = new System.Drawing.Point(6, 56);
            this.lstSaleReturn.Name = "lstSaleReturn";
            this.lstSaleReturn.Size = new System.Drawing.Size(826, 368);
            this.lstSaleReturn.TabIndex = 1606;
            this.lstSaleReturn.UseCompatibleStateImageBehavior = false;
            this.lstSaleReturn.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Invoice No";
            this.columnHeader7.Width = 150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Product Code";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Product Name";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Return Quantity";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Return Amount";
            this.columnHeader6.Width = 140;
            // 
            // lblSaleReturnID
            // 
            this.lblSaleReturnID.AutoSize = true;
            this.lblSaleReturnID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaleReturnID.ForeColor = System.Drawing.Color.White;
            this.lblSaleReturnID.Location = new System.Drawing.Point(263, 21);
            this.lblSaleReturnID.Name = "lblSaleReturnID";
            this.lblSaleReturnID.Size = new System.Drawing.Size(27, 20);
            this.lblSaleReturnID.TabIndex = 1605;
            this.lblSaleReturnID.Text = "11";
            // 
            // btnCloseReturn
            // 
            this.btnCloseReturn.BackColor = System.Drawing.Color.Red;
            this.btnCloseReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseReturn.ForeColor = System.Drawing.Color.White;
            this.btnCloseReturn.Location = new System.Drawing.Point(794, 3);
            this.btnCloseReturn.Name = "btnCloseReturn";
            this.btnCloseReturn.Size = new System.Drawing.Size(39, 32);
            this.btnCloseReturn.TabIndex = 1604;
            this.btnCloseReturn.Text = "X";
            this.btnCloseReturn.UseVisualStyleBackColor = false;
            this.btnCloseReturn.Click += new System.EventHandler(this.btnCloseReturn_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(25, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(232, 20);
            this.label14.TabIndex = 1603;
            this.label14.Text = "Sale Return Detail of Bill #: ";
            // 
            // frmSaleReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1964, 1100);
            this.Controls.Add(this.txtNetSaleValue);
            this.Controls.Add(this.lstSaleView);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotalReturnValue);
            this.Controls.Add(this.lstSearch);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTotalSaleValue);
            this.Controls.Add(this.gpdate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gpinvioce);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtTotalProfit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnlSaleReturn);
            this.Controls.Add(this.pnlProduct);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmSaleReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmSaleReport";
            this.ThemeName = "ControlDefault";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSaleReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSaleReport_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReport)).EndInit();
            this.gpinvioce.ResumeLayout(false);
            this.gpinvioce.PerformLayout();
            this.gpdate.ResumeLayout(false);
            this.gpdate.PerformLayout();
            this.pnlProduct.ResumeLayout(false);
            this.pnlProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintInvoice)).EndInit();
            this.pnlSaleReturn.ResumeLayout(false);
            this.pnlSaleReturn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Invoice;
        private System.Windows.Forms.Label lib1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtTotalProfit;
        private System.Windows.Forms.Label lib2;
        private System.Windows.Forms.ListView lstSaleView;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ColumnHeader InvoiceNo;
        private System.Windows.Forms.ColumnHeader CustomerID;
        private System.Windows.Forms.ColumnHeader CustomerName;
        private System.Windows.Forms.ColumnHeader TotalAmount;
        private System.Windows.Forms.ColumnHeader BalanceAmount;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private Telerik.WinControls.UI.RadButton btnReport;
        private System.Windows.Forms.Panel gpinvioce;
        private System.Windows.Forms.Panel gpdate;
        private System.Windows.Forms.ColumnHeader EnteredBy;
        private System.Windows.Forms.ColumnHeader PaidAmount;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.Panel pnlProduct;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.ListView lstInvoiceDetail;
        private System.Windows.Forms.ColumnHeader itemeid;
        private System.Windows.Forms.ColumnHeader ItemName;
        private System.Windows.Forms.ColumnHeader qty;
        private System.Windows.Forms.ColumnHeader rate;
        private System.Windows.Forms.ColumnHeader Discount;
        private System.Windows.Forms.ColumnHeader totalAmt;
        private Telerik.WinControls.UI.RadButton btnPrintInvoice;
        private System.Windows.Forms.CheckBox chkA4Reprint;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTotalReturnValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalSaleValue;
        private System.Windows.Forms.ListBox lstSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalProfit;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.TextBox txtNetSaleValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlSaleReturn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotalReturnAmount;
        private Telerik.WinControls.UI.RadButton btnPrintReturn;
        private System.Windows.Forms.ListView lstSaleReturn;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label lblSaleReturnID;
        private System.Windows.Forms.Button btnCloseReturn;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ColumnHeader columnHeader7;

    }
}

