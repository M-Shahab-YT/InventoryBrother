namespace Stock_System.Forms
{
    partial class frmSaleDetailReport
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
            this.itemeid = new System.Windows.Forms.ColumnHeader();
            this.ItemName = new System.Windows.Forms.ColumnHeader();
            this.GenericName = new System.Windows.Forms.ColumnHeader();
            this.SaleDate = new System.Windows.Forms.ColumnHeader();
            this.qty = new System.Windows.Forms.ColumnHeader();
            this.PurchasePrice = new System.Windows.Forms.ColumnHeader();
            this.rate = new System.Windows.Forms.ColumnHeader();
            this.Discount = new System.Windows.Forms.ColumnHeader();
            this.totalAmt = new System.Windows.Forms.ColumnHeader();
            this.TotalProfit = new System.Windows.Forms.ColumnHeader();
            this.txtTotalProfitValue = new System.Windows.Forms.TextBox();
            this.txtTotalSaleValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lstSearch = new System.Windows.Forms.ListBox();
            this.gpdate = new System.Windows.Forms.Panel();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.lib2 = new System.Windows.Forms.Label();
            this.lib1 = new System.Windows.Forms.Label();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.gpinvioce = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Invoice = new System.Windows.Forms.TextBox();
            this.btnReport = new Telerik.WinControls.UI.RadButton();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalDiscount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gpdate.SuspendLayout();
            this.gpinvioce.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // lstInvoiceDetail
            // 
            this.lstInvoiceDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.itemeid,
            this.ItemName,
            this.GenericName,
            this.SaleDate,
            this.qty,
            this.PurchasePrice,
            this.rate,
            this.Discount,
            this.totalAmt,
            this.TotalProfit});
            this.lstInvoiceDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstInvoiceDetail.FullRowSelect = true;
            this.lstInvoiceDetail.GridLines = true;
            this.lstInvoiceDetail.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstInvoiceDetail.Location = new System.Drawing.Point(16, 157);
            this.lstInvoiceDetail.Name = "lstInvoiceDetail";
            this.lstInvoiceDetail.Size = new System.Drawing.Size(1880, 758);
            this.lstInvoiceDetail.TabIndex = 1607;
            this.lstInvoiceDetail.UseCompatibleStateImageBehavior = false;
            this.lstInvoiceDetail.View = System.Windows.Forms.View.Details;
            // 
            // itemeid
            // 
            this.itemeid.Text = "Product Code";
            this.itemeid.Width = 200;
            // 
            // ItemName
            // 
            this.ItemName.Text = "Product Name";
            this.ItemName.Width = 280;
            // 
            // GenericName
            // 
            this.GenericName.Text = "Generic Name";
            this.GenericName.Width = 250;
            // 
            // SaleDate
            // 
            this.SaleDate.Text = "Sale Date";
            this.SaleDate.Width = 150;
            // 
            // qty
            // 
            this.qty.Text = "Quantity";
            this.qty.Width = 150;
            // 
            // PurchasePrice
            // 
            this.PurchasePrice.Text = "Purchase Price";
            this.PurchasePrice.Width = 200;
            // 
            // rate
            // 
            this.rate.Text = "Sale Price";
            this.rate.Width = 150;
            // 
            // Discount
            // 
            this.Discount.Text = "Discount";
            this.Discount.Width = 150;
            // 
            // totalAmt
            // 
            this.totalAmt.Text = "Total";
            this.totalAmt.Width = 150;
            // 
            // TotalProfit
            // 
            this.TotalProfit.Text = "Total Profit";
            this.TotalProfit.Width = 150;
            // 
            // txtTotalProfitValue
            // 
            this.txtTotalProfitValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalProfitValue.Enabled = false;
            this.txtTotalProfitValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalProfitValue.Location = new System.Drawing.Point(672, 971);
            this.txtTotalProfitValue.Name = "txtTotalProfitValue";
            this.txtTotalProfitValue.Size = new System.Drawing.Size(188, 24);
            this.txtTotalProfitValue.TabIndex = 183;
            // 
            // txtTotalSaleValue
            // 
            this.txtTotalSaleValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalSaleValue.Enabled = false;
            this.txtTotalSaleValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSaleValue.Location = new System.Drawing.Point(672, 944);
            this.txtTotalSaleValue.Name = "txtTotalSaleValue";
            this.txtTotalSaleValue.Size = new System.Drawing.Size(188, 24);
            this.txtTotalSaleValue.TabIndex = 181;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(572, 950);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 180;
            this.label7.Text = "TotalSaleValue";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(572, 977);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 13);
            this.label10.TabIndex = 182;
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
            "By Item & Date",
            "By Item",
            "Search By Generic Name"});
            this.lstSearch.Location = new System.Drawing.Point(16, 928);
            this.lstSearch.Name = "lstSearch";
            this.lstSearch.Size = new System.Drawing.Size(142, 79);
            this.lstSearch.TabIndex = 1663;
            this.lstSearch.SelectedIndexChanged += new System.EventHandler(this.lstSearch_SelectedIndexChanged);
            // 
            // gpdate
            // 
            this.gpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpdate.Controls.Add(this.dtto);
            this.gpdate.Controls.Add(this.lib2);
            this.gpdate.Controls.Add(this.lib1);
            this.gpdate.Controls.Add(this.dtfrom);
            this.gpdate.Location = new System.Drawing.Point(162, 970);
            this.gpdate.Name = "gpdate";
            this.gpdate.Size = new System.Drawing.Size(393, 37);
            this.gpdate.TabIndex = 1662;
            // 
            // dtto
            // 
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtto.Location = new System.Drawing.Point(255, 8);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(128, 20);
            this.dtto.TabIndex = 52;
            // 
            // lib2
            // 
            this.lib2.AutoSize = true;
            this.lib2.Location = new System.Drawing.Point(206, 11);
            this.lib2.Name = "lib2";
            this.lib2.Size = new System.Drawing.Size(43, 13);
            this.lib2.TabIndex = 54;
            this.lib2.Text = "ToDate";
            // 
            // lib1
            // 
            this.lib1.AutoSize = true;
            this.lib1.Location = new System.Drawing.Point(5, 10);
            this.lib1.Name = "lib1";
            this.lib1.Size = new System.Drawing.Size(56, 13);
            this.lib1.TabIndex = 48;
            this.lib1.Text = "From Date";
            // 
            // dtfrom
            // 
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfrom.Location = new System.Drawing.Point(75, 6);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.Size = new System.Drawing.Size(128, 20);
            this.dtfrom.TabIndex = 51;
            // 
            // gpinvioce
            // 
            this.gpinvioce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpinvioce.Controls.Add(this.label4);
            this.gpinvioce.Controls.Add(this.txt_Invoice);
            this.gpinvioce.Enabled = false;
            this.gpinvioce.Location = new System.Drawing.Point(162, 930);
            this.gpinvioce.Name = "gpinvioce";
            this.gpinvioce.Size = new System.Drawing.Size(393, 37);
            this.gpinvioce.TabIndex = 1661;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Search Text:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_Invoice
            // 
            this.txt_Invoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Invoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Invoice.Location = new System.Drawing.Point(76, 7);
            this.txt_Invoice.Name = "txt_Invoice";
            this.txt_Invoice.Size = new System.Drawing.Size(281, 24);
            this.txt_Invoice.TabIndex = 49;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(1300, 938);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(71, 64);
            this.btnReport.TabIndex = 1660;
            this.btnReport.Text = "Report";
            this.btnReport.Visible = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1227, 938);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(71, 64);
            this.btnSearch.TabIndex = 1659;
            this.btnSearch.Text = "View";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(414, 25);
            this.label3.TabIndex = 1665;
            this.label3.Text = "SALES DETAIL REPORT( Base Currency)";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalQty.Enabled = false;
            this.txtTotalQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalQty.Location = new System.Drawing.Point(976, 940);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Size = new System.Drawing.Size(188, 24);
            this.txtTotalQty.TabIndex = 1667;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(876, 946);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1666;
            this.label1.Text = "Total Quantity";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalDiscount
            // 
            this.txtTotalDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalDiscount.Enabled = false;
            this.txtTotalDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDiscount.Location = new System.Drawing.Point(976, 971);
            this.txtTotalDiscount.Name = "txtTotalDiscount";
            this.txtTotalDiscount.Size = new System.Drawing.Size(188, 24);
            this.txtTotalDiscount.TabIndex = 1669;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(876, 977);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1668;
            this.label2.Text = "Total Discount:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSaleDetailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.txtTotalDiscount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalQty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalProfitValue);
            this.Controls.Add(this.txtTotalSaleValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lstSearch);
            this.Controls.Add(this.gpdate);
            this.Controls.Add(this.gpinvioce);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lstInvoiceDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSaleDetailReport";
            this.Text = "frmSaleDetailReport";
            this.Load += new System.EventHandler(this.frmSaleDetailReport_Load);
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
        private System.Windows.Forms.ColumnHeader itemeid;
        private System.Windows.Forms.ColumnHeader ItemName;
        private System.Windows.Forms.ColumnHeader qty;
        private System.Windows.Forms.ColumnHeader rate;
        private System.Windows.Forms.ColumnHeader Discount;
        private System.Windows.Forms.ColumnHeader totalAmt;
        private System.Windows.Forms.ColumnHeader GenericName;
        private System.Windows.Forms.ColumnHeader PurchasePrice;
        private System.Windows.Forms.ColumnHeader TotalProfit;
        private System.Windows.Forms.ColumnHeader SaleDate;
        private System.Windows.Forms.TextBox txtTotalProfitValue;
        private System.Windows.Forms.TextBox txtTotalSaleValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lstSearch;
        private System.Windows.Forms.Panel gpdate;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.Label lib2;
        private System.Windows.Forms.Label lib1;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private System.Windows.Forms.Panel gpinvioce;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Invoice;
        private Telerik.WinControls.UI.RadButton btnReport;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalDiscount;
        private System.Windows.Forms.Label label2;
    }
}