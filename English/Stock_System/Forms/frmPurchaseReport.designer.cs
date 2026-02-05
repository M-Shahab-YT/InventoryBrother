namespace Stock_System.Forms
{
    partial class frmPurchaseReport
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
            this.gpdate = new System.Windows.Forms.Panel();
            this.lib2 = new System.Windows.Forms.Label();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.lib1 = new System.Windows.Forms.Label();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.gpinvioce = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReport = new Telerik.WinControls.UI.RadButton();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.txtTotalProfit = new System.Windows.Forms.Label();
            this.pnlProduct = new System.Windows.Forms.Panel();
            this.lstInvoiceDetail = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.BatchNo = new System.Windows.Forms.ColumnHeader();
            this.ExpiryDate = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lstSaleView = new System.Windows.Forms.ListView();
            this.Invoiceno = new System.Windows.Forms.ColumnHeader();
            this.SaleOrderDate = new System.Windows.Forms.ColumnHeader();
            this.SaleOrderTime = new System.Windows.Forms.ColumnHeader();
            this.CustomerName = new System.Windows.Forms.ColumnHeader();
            this.TotalOrderAmount = new System.Windows.Forms.ColumnHeader();
            this.TotalPaidAmount = new System.Windows.Forms.ColumnHeader();
            this.BalanceAmount = new System.Windows.Forms.ColumnHeader();
            this.Currency = new System.Windows.Forms.ColumnHeader();
            this.PaymentMethod = new System.Windows.Forms.ColumnHeader();
            this.UserName = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.grdSummaryByCurrency = new System.Windows.Forms.DataGridView();
            this.CurrencyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Report = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lstSearch = new System.Windows.Forms.ListBox();
            this.gpdate.SuspendLayout();
            this.gpinvioce.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            this.pnlProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSummaryByCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Invoice
            // 
            this.txt_Invoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Invoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txt_Invoice.Location = new System.Drawing.Point(135, 7);
            this.txt_Invoice.Name = "txt_Invoice";
            this.txt_Invoice.Size = new System.Drawing.Size(450, 35);
            this.txt_Invoice.TabIndex = 49;
            // 
            // gpdate
            // 
            this.gpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpdate.Controls.Add(this.lib2);
            this.gpdate.Controls.Add(this.dtto);
            this.gpdate.Controls.Add(this.lib1);
            this.gpdate.Controls.Add(this.dtfrom);
            this.gpdate.Location = new System.Drawing.Point(219, 936);
            this.gpdate.Name = "gpdate";
            this.gpdate.Size = new System.Drawing.Size(598, 46);
            this.gpdate.TabIndex = 180;
            // 
            // lib2
            // 
            this.lib2.AutoSize = true;
            this.lib2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib2.Location = new System.Drawing.Point(326, 12);
            this.lib2.Name = "lib2";
            this.lib2.Size = new System.Drawing.Size(70, 20);
            this.lib2.TabIndex = 1610;
            this.lib2.Text = "To Date:";
            // 
            // dtto
            // 
            this.dtto.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtto.Location = new System.Drawing.Point(409, 5);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(176, 35);
            this.dtto.TabIndex = 52;
            // 
            // lib1
            // 
            this.lib1.AutoSize = true;
            this.lib1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib1.Location = new System.Drawing.Point(8, 12);
            this.lib1.Name = "lib1";
            this.lib1.Size = new System.Drawing.Size(89, 20);
            this.lib1.TabIndex = 1609;
            this.lib1.Text = "From Date:";
            // 
            // dtfrom
            // 
            this.dtfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfrom.Location = new System.Drawing.Point(137, 5);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.Size = new System.Drawing.Size(176, 35);
            this.dtfrom.TabIndex = 51;
            // 
            // gpinvioce
            // 
            this.gpinvioce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpinvioce.Controls.Add(this.label4);
            this.gpinvioce.Controls.Add(this.txt_Invoice);
            this.gpinvioce.Enabled = false;
            this.gpinvioce.Location = new System.Drawing.Point(219, 879);
            this.gpinvioce.Name = "gpinvioce";
            this.gpinvioce.Size = new System.Drawing.Size(598, 48);
            this.gpinvioce.TabIndex = 179;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 1609;
            this.label4.Text = "By Invoice No";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(972, 907);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(134, 75);
            this.btnReport.TabIndex = 178;
            this.btnReport.Text = "Report";
            this.btnReport.Visible = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(830, 907);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(134, 75);
            this.btnSearch.TabIndex = 177;
            this.btnSearch.Text = "View";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtTotalProfit
            // 
            this.txtTotalProfit.AutoSize = true;
            this.txtTotalProfit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalProfit.ForeColor = System.Drawing.Color.White;
            this.txtTotalProfit.Location = new System.Drawing.Point(1218, 149);
            this.txtTotalProfit.Name = "txtTotalProfit";
            this.txtTotalProfit.Size = new System.Drawing.Size(18, 19);
            this.txtTotalProfit.TabIndex = 175;
            this.txtTotalProfit.Text = "0";
            // 
            // pnlProduct
            // 
            this.pnlProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.pnlProduct.Controls.Add(this.lstInvoiceDetail);
            this.pnlProduct.Controls.Add(this.lblInvoiceNo);
            this.pnlProduct.Controls.Add(this.btnClose);
            this.pnlProduct.Controls.Add(this.label2);
            this.pnlProduct.Location = new System.Drawing.Point(540, 67);
            this.pnlProduct.Name = "pnlProduct";
            this.pnlProduct.Size = new System.Drawing.Size(915, 483);
            this.pnlProduct.TabIndex = 181;
            this.pnlProduct.Visible = false;
            // 
            // lstInvoiceDetail
            // 
            this.lstInvoiceDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.BatchNo,
            this.ExpiryDate,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstInvoiceDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstInvoiceDetail.FullRowSelect = true;
            this.lstInvoiceDetail.GridLines = true;
            this.lstInvoiceDetail.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstInvoiceDetail.Location = new System.Drawing.Point(11, 47);
            this.lstInvoiceDetail.Name = "lstInvoiceDetail";
            this.lstInvoiceDetail.Size = new System.Drawing.Size(889, 417);
            this.lstInvoiceDetail.TabIndex = 1606;
            this.lstInvoiceDetail.UseCompatibleStateImageBehavior = false;
            this.lstInvoiceDetail.View = System.Windows.Forms.View.Details;
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
            // BatchNo
            // 
            this.BatchNo.Text = "Batch No";
            this.BatchNo.Width = 100;
            // 
            // ExpiryDate
            // 
            this.ExpiryDate.Text = "Expiry Date";
            this.ExpiryDate.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Quantity";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Sale Price";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Total";
            this.columnHeader5.Width = 120;
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNo.ForeColor = System.Drawing.Color.White;
            this.lblInvoiceNo.Location = new System.Drawing.Point(166, 11);
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
            this.btnClose.Location = new System.Drawing.Point(822, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 32);
            this.btnClose.TabIndex = 1604;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 20);
            this.label2.TabIndex = 1603;
            this.label2.Text = "Detail of Invoice#: ";
            // 
            // lstSaleView
            // 
            this.lstSaleView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Invoiceno,
            this.SaleOrderDate,
            this.SaleOrderTime,
            this.CustomerName,
            this.TotalOrderAmount,
            this.TotalPaidAmount,
            this.BalanceAmount,
            this.Currency,
            this.PaymentMethod,
            this.UserName});
            this.lstSaleView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSaleView.FullRowSelect = true;
            this.lstSaleView.GridLines = true;
            this.lstSaleView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstSaleView.Location = new System.Drawing.Point(29, 107);
            this.lstSaleView.Name = "lstSaleView";
            this.lstSaleView.Size = new System.Drawing.Size(1868, 766);
            this.lstSaleView.TabIndex = 1607;
            this.lstSaleView.UseCompatibleStateImageBehavior = false;
            this.lstSaleView.View = System.Windows.Forms.View.Details;
            this.lstSaleView.DoubleClick += new System.EventHandler(this.lstSaleView_DoubleClick);
            // 
            // Invoiceno
            // 
            this.Invoiceno.Text = "Order No";
            this.Invoiceno.Width = 250;
            // 
            // SaleOrderDate
            // 
            this.SaleOrderDate.Text = "Order Date";
            this.SaleOrderDate.Width = 200;
            // 
            // SaleOrderTime
            // 
            this.SaleOrderTime.Text = "Time";
            this.SaleOrderTime.Width = 100;
            // 
            // CustomerName
            // 
            this.CustomerName.Text = "Supplier";
            this.CustomerName.Width = 320;
            // 
            // TotalOrderAmount
            // 
            this.TotalOrderAmount.Text = "Total Order Amount";
            this.TotalOrderAmount.Width = 150;
            // 
            // TotalPaidAmount
            // 
            this.TotalPaidAmount.Text = "Total Paid Amount";
            this.TotalPaidAmount.Width = 150;
            // 
            // BalanceAmount
            // 
            this.BalanceAmount.Text = "Balance Amount";
            this.BalanceAmount.Width = 120;
            // 
            // Currency
            // 
            this.Currency.Text = "Currency";
            this.Currency.Width = 150;
            // 
            // PaymentMethod
            // 
            this.PaymentMethod.Text = "Payment Method";
            this.PaymentMethod.Width = 150;
            // 
            // UserName
            // 
            this.UserName.Text = "UserName";
            this.UserName.Width = 200;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(34, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 24);
            this.label3.TabIndex = 1608;
            this.label3.Text = "PURCHASE REPORT";
            // 
            // grdSummaryByCurrency
            // 
            this.grdSummaryByCurrency.AllowDrop = true;
            this.grdSummaryByCurrency.AllowUserToAddRows = false;
            this.grdSummaryByCurrency.AllowUserToDeleteRows = false;
            this.grdSummaryByCurrency.AllowUserToOrderColumns = true;
            this.grdSummaryByCurrency.AllowUserToResizeColumns = false;
            this.grdSummaryByCurrency.AllowUserToResizeRows = false;
            this.grdSummaryByCurrency.ColumnHeadersHeight = 30;
            this.grdSummaryByCurrency.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CurrencyID,
            this.dataGridViewTextBoxColumn1,
            this.TotalSale,
            this.Report});
            this.grdSummaryByCurrency.Location = new System.Drawing.Point(1365, 875);
            this.grdSummaryByCurrency.Name = "grdSummaryByCurrency";
            this.grdSummaryByCurrency.RowHeadersVisible = false;
            this.grdSummaryByCurrency.RowTemplate.Height = 30;
            this.grdSummaryByCurrency.Size = new System.Drawing.Size(533, 107);
            this.grdSummaryByCurrency.TabIndex = 1663;
            this.grdSummaryByCurrency.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSummaryByCurrency_CellContentClick);
            // 
            // CurrencyID
            // 
            this.CurrencyID.DataPropertyName = "CurrencyID";
            this.CurrencyID.HeaderText = "CurrencyID";
            this.CurrencyID.Name = "CurrencyID";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CurrencyName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Currency";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // TotalSale
            // 
            this.TotalSale.DataPropertyName = "TotalOrderAmount";
            this.TotalSale.HeaderText = "Total Purchase Value";
            this.TotalSale.Name = "TotalSale";
            this.TotalSale.Width = 200;
            // 
            // Report
            // 
            this.Report.DataPropertyName = "Report";
            this.Report.HeaderText = "Report";
            this.Report.Name = "Report";
            this.Report.Width = 130;
            // 
            // lstSearch
            // 
            this.lstSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSearch.FormattingEnabled = true;
            this.lstSearch.ItemHeight = 20;
            this.lstSearch.Items.AddRange(new object[] {
            "Saerch By BillNo",
            "Search BY OrderNo",
            "Search By Date",
            "By Supplier & Date",
            "By Supplier",
            "All"});
            this.lstSearch.Location = new System.Drawing.Point(29, 878);
            this.lstSearch.Name = "lstSearch";
            this.lstSearch.Size = new System.Drawing.Size(184, 104);
            this.lstSearch.TabIndex = 1664;
            this.lstSearch.SelectedIndexChanged += new System.EventHandler(this.lstSearch_SelectedIndexChanged);
            // 
            // frmPurchaseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1944, 1100);
            this.Controls.Add(this.lstSearch);
            this.Controls.Add(this.grdSummaryByCurrency);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstSaleView);
            this.Controls.Add(this.pnlProduct);
            this.Controls.Add(this.gpdate);
            this.Controls.Add(this.gpinvioce);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtTotalProfit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPurchaseReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmPurchaseReport";
            this.ThemeName = "ControlDefault";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPurchaseReport_Load);
            this.gpdate.ResumeLayout(false);
            this.gpdate.PerformLayout();
            this.gpinvioce.ResumeLayout(false);
            this.gpinvioce.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            this.pnlProduct.ResumeLayout(false);
            this.pnlProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSummaryByCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Invoice;
        private System.Windows.Forms.Panel gpdate;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private System.Windows.Forms.Panel gpinvioce;
        private Telerik.WinControls.UI.RadButton btnReport;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private System.Windows.Forms.Label txtTotalProfit;
        private System.Windows.Forms.Panel pnlProduct;
        private System.Windows.Forms.ListView lstInvoiceDetail;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader BatchNo;
        private System.Windows.Forms.ColumnHeader ExpiryDate;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstSaleView;
        private System.Windows.Forms.ColumnHeader Invoiceno;
        private System.Windows.Forms.ColumnHeader SaleOrderDate;
        private System.Windows.Forms.ColumnHeader SaleOrderTime;
        private System.Windows.Forms.ColumnHeader CustomerName;
        private System.Windows.Forms.ColumnHeader TotalOrderAmount;
        private System.Windows.Forms.ColumnHeader TotalPaidAmount;
        private System.Windows.Forms.ColumnHeader BalanceAmount;
        private System.Windows.Forms.ColumnHeader Currency;
        private System.Windows.Forms.ColumnHeader PaymentMethod;
        private System.Windows.Forms.ColumnHeader UserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lib2;
        private System.Windows.Forms.Label lib1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView grdSummaryByCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrencyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSale;
        private System.Windows.Forms.DataGridViewButtonColumn Report;
        private System.Windows.Forms.ListBox lstSearch;
    }
}

