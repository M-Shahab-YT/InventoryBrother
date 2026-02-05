namespace Stock_System.Forms
{
    partial class SaleAndSaleReturnView
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
            this.lstInvoiceDetail = new System.Windows.Forms.ListView();
            this.Date = new System.Windows.Forms.ColumnHeader();
            this.Time = new System.Windows.Forms.ColumnHeader();
            this.InvoiceNo = new System.Windows.Forms.ColumnHeader();
            this.Customer = new System.Windows.Forms.ColumnHeader();
            this.ProductName = new System.Windows.Forms.ColumnHeader();
            this.ProductCategory = new System.Windows.Forms.ColumnHeader();
            this.Quantity = new System.Windows.Forms.ColumnHeader();
            this.StockPrice = new System.Windows.Forms.ColumnHeader();
            this.SalePrice = new System.Windows.Forms.ColumnHeader();
            this.Discount = new System.Windows.Forms.ColumnHeader();
            this.Total = new System.Windows.Forms.ColumnHeader();
            this.ProfitPerUnit = new System.Windows.Forms.ColumnHeader();
            this.TotalProfit = new System.Windows.Forms.ColumnHeader();
            this.Status = new System.Windows.Forms.ColumnHeader();
            this.TotalAmount = new System.Windows.Forms.ColumnHeader();
            this.UserName = new System.Windows.Forms.ColumnHeader();
            this.txtTotalDiscount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalProfitValue = new System.Windows.Forms.TextBox();
            this.txtTotalSaleValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lstSearch = new System.Windows.Forms.ListBox();
            this.gpdate = new System.Windows.Forms.Panel();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.lib2 = new System.Windows.Forms.Label();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.lib1 = new System.Windows.Forms.Label();
            this.gpinvioce = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnReport = new Telerik.WinControls.UI.RadButton();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.txtTotalRetSaleValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalRetDiscount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalRetQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotalRetProfitValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalNetSaleValue = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotalNetDiscount = new System.Windows.Forms.TextBox();
            this.txtTotalNetProfitValue = new System.Windows.Forms.TextBox();
            this.txtTotalNetQty = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.DiscountTotal = new System.Windows.Forms.ColumnHeader();
            this.gpdate.SuspendLayout();
            this.gpinvioce.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // lstInvoiceDetail
            // 
            this.lstInvoiceDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.Time,
            this.InvoiceNo,
            this.Customer,
            this.ProductName,
            this.ProductCategory,
            this.Quantity,
            this.StockPrice,
            this.SalePrice,
            this.Discount,
            this.DiscountTotal,
            this.Total,
            this.ProfitPerUnit,
            this.TotalProfit,
            this.Status,
            this.TotalAmount,
            this.UserName});
            this.lstInvoiceDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstInvoiceDetail.FullRowSelect = true;
            this.lstInvoiceDetail.GridLines = true;
            this.lstInvoiceDetail.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstInvoiceDetail.Location = new System.Drawing.Point(14, 151);
            this.lstInvoiceDetail.Name = "lstInvoiceDetail";
            this.lstInvoiceDetail.Size = new System.Drawing.Size(1880, 739);
            this.lstInvoiceDetail.TabIndex = 1608;
            this.lstInvoiceDetail.UseCompatibleStateImageBehavior = false;
            this.lstInvoiceDetail.View = System.Windows.Forms.View.Details;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 100;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.Text = "Invoice No";
            this.InvoiceNo.Width = 100;
            // 
            // Customer
            // 
            this.Customer.Text = "Customer";
            this.Customer.Width = 120;
            // 
            // ProductName
            // 
            this.ProductName.Text = "Product Name";
            this.ProductName.Width = 150;
            // 
            // ProductCategory
            // 
            this.ProductCategory.Text = "Category";
            this.ProductCategory.Width = 100;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 80;
            // 
            // StockPrice
            // 
            this.StockPrice.Text = "Stock Price";
            this.StockPrice.Width = 120;
            // 
            // SalePrice
            // 
            this.SalePrice.Text = "Sale Price";
            this.SalePrice.Width = 120;
            // 
            // Discount
            // 
            this.Discount.Text = "Discount";
            this.Discount.Width = 100;
            // 
            // Total
            // 
            this.Total.DisplayIndex = 11;
            this.Total.Text = "Total";
            this.Total.Width = 100;
            // 
            // ProfitPerUnit
            // 
            this.ProfitPerUnit.DisplayIndex = 12;
            this.ProfitPerUnit.Text = "Profit Per Unit";
            this.ProfitPerUnit.Width = 120;
            // 
            // TotalProfit
            // 
            this.TotalProfit.DisplayIndex = 13;
            this.TotalProfit.Text = "Total Profit";
            this.TotalProfit.Width = 150;
            // 
            // Status
            // 
            this.Status.DisplayIndex = 14;
            this.Status.Text = "Status";
            this.Status.Width = 80;
            // 
            // TotalAmount
            // 
            this.TotalAmount.Text = "Total Amount";
            this.TotalAmount.Width = 110;
            // 
            // UserName
            // 
            this.UserName.DisplayIndex = 16;
            this.UserName.Text = "User";
            this.UserName.Width = 120;
            // 
            // txtTotalDiscount
            // 
            this.txtTotalDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalDiscount.Enabled = false;
            this.txtTotalDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDiscount.Location = new System.Drawing.Point(1067, 904);
            this.txtTotalDiscount.Name = "txtTotalDiscount";
            this.txtTotalDiscount.Size = new System.Drawing.Size(128, 24);
            this.txtTotalDiscount.TabIndex = 1682;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(952, 910);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1681;
            this.label2.Text = "Total Discount:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalQty.Enabled = false;
            this.txtTotalQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalQty.Location = new System.Drawing.Point(1592, 904);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Size = new System.Drawing.Size(154, 24);
            this.txtTotalQty.TabIndex = 1680;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1484, 910);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1679;
            this.label1.Text = "Total Quantity";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalProfitValue
            // 
            this.txtTotalProfitValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalProfitValue.Enabled = false;
            this.txtTotalProfitValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalProfitValue.Location = new System.Drawing.Point(1333, 904);
            this.txtTotalProfitValue.Name = "txtTotalProfitValue";
            this.txtTotalProfitValue.Size = new System.Drawing.Size(142, 24);
            this.txtTotalProfitValue.TabIndex = 1673;
            // 
            // txtTotalSaleValue
            // 
            this.txtTotalSaleValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalSaleValue.Enabled = false;
            this.txtTotalSaleValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSaleValue.Location = new System.Drawing.Point(775, 904);
            this.txtTotalSaleValue.Name = "txtTotalSaleValue";
            this.txtTotalSaleValue.Size = new System.Drawing.Size(171, 24);
            this.txtTotalSaleValue.TabIndex = 1671;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(675, 910);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 1670;
            this.label7.Text = "TotalSaleValue";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1202, 910);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 13);
            this.label10.TabIndex = 1672;
            this.label10.Text = "Total Profit Value";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstSearch
            // 
            this.lstSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstSearch.FormattingEnabled = true;
            this.lstSearch.ItemHeight = 15;
            this.lstSearch.Items.AddRange(new object[] {
            "Search By Date",
            "By Product & Date",
            "By Category & Date",
            "By Customer & Date"});
            this.lstSearch.Location = new System.Drawing.Point(13, 899);
            this.lstSearch.Name = "lstSearch";
            this.lstSearch.Size = new System.Drawing.Size(123, 79);
            this.lstSearch.TabIndex = 1678;
            // 
            // gpdate
            // 
            this.gpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpdate.Controls.Add(this.dtto);
            this.gpdate.Controls.Add(this.lib2);
            this.gpdate.Controls.Add(this.dtfrom);
            this.gpdate.Controls.Add(this.lib1);
            this.gpdate.Location = new System.Drawing.Point(141, 940);
            this.gpdate.Name = "gpdate";
            this.gpdate.Size = new System.Drawing.Size(525, 37);
            this.gpdate.TabIndex = 1677;
            // 
            // dtto
            // 
            this.dtto.CalendarFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtto.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dtto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtto.Location = new System.Drawing.Point(318, 3);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(194, 29);
            this.dtto.TabIndex = 1684;
            // 
            // lib2
            // 
            this.lib2.AutoSize = true;
            this.lib2.Location = new System.Drawing.Point(269, 11);
            this.lib2.Name = "lib2";
            this.lib2.Size = new System.Drawing.Size(43, 13);
            this.lib2.TabIndex = 54;
            this.lib2.Text = "ToDate";
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
            this.dtfrom.TabIndex = 1683;
            // 
            // lib1
            // 
            this.lib1.AutoSize = true;
            this.lib1.Location = new System.Drawing.Point(5, 11);
            this.lib1.Name = "lib1";
            this.lib1.Size = new System.Drawing.Size(56, 13);
            this.lib1.TabIndex = 48;
            this.lib1.Text = "From Date";
            // 
            // gpinvioce
            // 
            this.gpinvioce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpinvioce.Controls.Add(this.label4);
            this.gpinvioce.Controls.Add(this.txtSearch);
            this.gpinvioce.Location = new System.Drawing.Point(141, 900);
            this.gpinvioce.Name = "gpinvioce";
            this.gpinvioce.Size = new System.Drawing.Size(525, 37);
            this.gpinvioce.TabIndex = 1676;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Search Text:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(76, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(444, 29);
            this.txtSearch.TabIndex = 49;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(1824, 919);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(69, 57);
            this.btnReport.TabIndex = 1675;
            this.btnReport.Text = "Report";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1752, 919);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(69, 57);
            this.btnSearch.TabIndex = 1674;
            this.btnSearch.Text = "View";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtTotalRetSaleValue
            // 
            this.txtTotalRetSaleValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalRetSaleValue.Enabled = false;
            this.txtTotalRetSaleValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRetSaleValue.Location = new System.Drawing.Point(775, 928);
            this.txtTotalRetSaleValue.Name = "txtTotalRetSaleValue";
            this.txtTotalRetSaleValue.Size = new System.Drawing.Size(171, 24);
            this.txtTotalRetSaleValue.TabIndex = 1684;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(675, 936);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 1683;
            this.label3.Text = "Total Return Value";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalRetDiscount
            // 
            this.txtTotalRetDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalRetDiscount.Enabled = false;
            this.txtTotalRetDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRetDiscount.Location = new System.Drawing.Point(1067, 928);
            this.txtTotalRetDiscount.Name = "txtTotalRetDiscount";
            this.txtTotalRetDiscount.Size = new System.Drawing.Size(128, 24);
            this.txtTotalRetDiscount.TabIndex = 1686;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(952, 938);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 1685;
            this.label5.Text = "Total Return Discount:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalRetQty
            // 
            this.txtTotalRetQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalRetQty.Enabled = false;
            this.txtTotalRetQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRetQty.Location = new System.Drawing.Point(1592, 928);
            this.txtTotalRetQty.Name = "txtTotalRetQty";
            this.txtTotalRetQty.Size = new System.Drawing.Size(154, 24);
            this.txtTotalRetQty.TabIndex = 1688;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1484, 935);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 1687;
            this.label6.Text = "Total Return Quantity";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalRetProfitValue
            // 
            this.txtTotalRetProfitValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalRetProfitValue.Enabled = false;
            this.txtTotalRetProfitValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRetProfitValue.Location = new System.Drawing.Point(1333, 928);
            this.txtTotalRetProfitValue.Name = "txtTotalRetProfitValue";
            this.txtTotalRetProfitValue.Size = new System.Drawing.Size(142, 24);
            this.txtTotalRetProfitValue.TabIndex = 1690;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1202, 936);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 13);
            this.label8.TabIndex = 1689;
            this.label8.Text = "Total Return Profit Value";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalNetSaleValue
            // 
            this.txtTotalNetSaleValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalNetSaleValue.Enabled = false;
            this.txtTotalNetSaleValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalNetSaleValue.Location = new System.Drawing.Point(775, 952);
            this.txtTotalNetSaleValue.Name = "txtTotalNetSaleValue";
            this.txtTotalNetSaleValue.Size = new System.Drawing.Size(171, 24);
            this.txtTotalNetSaleValue.TabIndex = 1692;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(675, 958);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 1691;
            this.label9.Text = "Net Value";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalNetDiscount
            // 
            this.txtTotalNetDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalNetDiscount.Enabled = false;
            this.txtTotalNetDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalNetDiscount.Location = new System.Drawing.Point(1067, 952);
            this.txtTotalNetDiscount.Name = "txtTotalNetDiscount";
            this.txtTotalNetDiscount.Size = new System.Drawing.Size(128, 24);
            this.txtTotalNetDiscount.TabIndex = 1694;
            // 
            // txtTotalNetProfitValue
            // 
            this.txtTotalNetProfitValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalNetProfitValue.Enabled = false;
            this.txtTotalNetProfitValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalNetProfitValue.Location = new System.Drawing.Point(1333, 952);
            this.txtTotalNetProfitValue.Name = "txtTotalNetProfitValue";
            this.txtTotalNetProfitValue.Size = new System.Drawing.Size(142, 24);
            this.txtTotalNetProfitValue.TabIndex = 1696;
            // 
            // txtTotalNetQty
            // 
            this.txtTotalNetQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalNetQty.Enabled = false;
            this.txtTotalNetQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalNetQty.Location = new System.Drawing.Point(1592, 952);
            this.txtTotalNetQty.Name = "txtTotalNetQty";
            this.txtTotalNetQty.Size = new System.Drawing.Size(154, 24);
            this.txtTotalNetQty.TabIndex = 1698;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(952, 960);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 1699;
            this.label11.Text = "Net Value";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1201, 958);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 1700;
            this.label12.Text = "Net Value";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1484, 958);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 1701;
            this.label13.Text = "Net Value";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Orange;
            this.label14.Location = new System.Drawing.Point(12, 109);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(376, 25);
            this.label14.TabIndex = 1702;
            this.label14.Text = "SALES AND SALE RETURN REPORT";
            // 
            // DiscountTotal
            // 
            this.DiscountTotal.DisplayIndex = 10;
            this.DiscountTotal.Text = "Total Discount";
            this.DiscountTotal.Width = 120;
            // 
            // SaleAndSaleReturnView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTotalNetQty);
            this.Controls.Add(this.txtTotalNetProfitValue);
            this.Controls.Add(this.txtTotalNetDiscount);
            this.Controls.Add(this.txtTotalNetSaleValue);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTotalRetProfitValue);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTotalRetQty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotalRetDiscount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotalRetSaleValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotalDiscount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalQty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalProfitValue);
            this.Controls.Add(this.txtTotalSaleValue);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lstSearch);
            this.Controls.Add(this.gpdate);
            this.Controls.Add(this.gpinvioce);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lstInvoiceDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SaleAndSaleReturnView";
            this.Text = "SaleAndSaleReturnView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SaleAndSaleReturnView_Load);
            this.gpdate.ResumeLayout(false);
            this.gpdate.PerformLayout();
            this.gpinvioce.ResumeLayout(false);
            this.gpinvioce.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstInvoiceDetail;
        private System.Windows.Forms.ColumnHeader Customer;
        private System.Windows.Forms.ColumnHeader ProductName;
        private System.Windows.Forms.ColumnHeader ProductCategory;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader StockPrice;
        private System.Windows.Forms.ColumnHeader SalePrice;
        private System.Windows.Forms.ColumnHeader Discount;
        private System.Windows.Forms.ColumnHeader Total;
        private System.Windows.Forms.ColumnHeader ProfitPerUnit;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader InvoiceNo;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ColumnHeader TotalProfit;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader TotalAmount;
        private System.Windows.Forms.TextBox txtTotalDiscount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalProfitValue;
        private System.Windows.Forms.TextBox txtTotalSaleValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lstSearch;
        private System.Windows.Forms.Panel gpdate;
        private System.Windows.Forms.Label lib2;
        private System.Windows.Forms.Label lib1;
        private System.Windows.Forms.Panel gpinvioce;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearch;
        private Telerik.WinControls.UI.RadButton btnReport;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private System.Windows.Forms.ColumnHeader UserName;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private System.Windows.Forms.TextBox txtTotalRetSaleValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalRetDiscount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalRetQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotalRetProfitValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotalNetSaleValue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotalNetDiscount;
        private System.Windows.Forms.TextBox txtTotalNetProfitValue;
        private System.Windows.Forms.TextBox txtTotalNetQty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ColumnHeader DiscountTotal;
    }
}