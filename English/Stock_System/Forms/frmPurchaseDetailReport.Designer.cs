namespace Stock_System.Forms
{
    partial class frmPurchaseDetailReport
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
            this.InvoiceNo = new System.Windows.Forms.ColumnHeader();
            this.SupplierID = new System.Windows.Forms.ColumnHeader();
            this.SupplierName = new System.Windows.Forms.ColumnHeader();
            this.SystemDate = new System.Windows.Forms.ColumnHeader();
            this.CurrencyName = new System.Windows.Forms.ColumnHeader();
            this.ProductCode = new System.Windows.Forms.ColumnHeader();
            this.ProductName = new System.Windows.Forms.ColumnHeader();
            this.BatchNo = new System.Windows.Forms.ColumnHeader();
            this.ExpiryDate = new System.Windows.Forms.ColumnHeader();
            this.Quantity = new System.Windows.Forms.ColumnHeader();
            this.PurchasePrice = new System.Windows.Forms.ColumnHeader();
            this.Total = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
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
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalSaleValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gpdate.SuspendLayout();
            this.gpinvioce.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // lstInvoiceDetail
            // 
            this.lstInvoiceDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.InvoiceNo,
            this.SupplierID,
            this.SupplierName,
            this.SystemDate,
            this.CurrencyName,
            this.ProductCode,
            this.ProductName,
            this.BatchNo,
            this.ExpiryDate,
            this.Quantity,
            this.PurchasePrice,
            this.Total});
            this.lstInvoiceDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstInvoiceDetail.FullRowSelect = true;
            this.lstInvoiceDetail.GridLines = true;
            this.lstInvoiceDetail.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstInvoiceDetail.Location = new System.Drawing.Point(12, 161);
            this.lstInvoiceDetail.Name = "lstInvoiceDetail";
            this.lstInvoiceDetail.Size = new System.Drawing.Size(1880, 758);
            this.lstInvoiceDetail.TabIndex = 1608;
            this.lstInvoiceDetail.UseCompatibleStateImageBehavior = false;
            this.lstInvoiceDetail.View = System.Windows.Forms.View.Details;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.Text = "Bill No";
            this.InvoiceNo.Width = 100;
            // 
            // SupplierID
            // 
            this.SupplierID.Text = "SupplierID";
            this.SupplierID.Width = 100;
            // 
            // SupplierName
            // 
            this.SupplierName.Text = "SupplierName";
            this.SupplierName.Width = 250;
            // 
            // SystemDate
            // 
            this.SystemDate.Text = "Date";
            this.SystemDate.Width = 100;
            // 
            // CurrencyName
            // 
            this.CurrencyName.Text = "Currency";
            this.CurrencyName.Width = 100;
            // 
            // ProductCode
            // 
            this.ProductCode.Text = "ProductCode";
            this.ProductCode.Width = 200;
            // 
            // ProductName
            // 
            this.ProductName.Text = "Product Name";
            this.ProductName.Width = 250;
            // 
            // BatchNo
            // 
            this.BatchNo.Text = "BatchNo";
            this.BatchNo.Width = 100;
            // 
            // ExpiryDate
            // 
            this.ExpiryDate.Text = "ExpiryDate";
            this.ExpiryDate.Width = 150;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 150;
            // 
            // PurchasePrice
            // 
            this.PurchasePrice.Text = "PurchasePrice";
            this.PurchasePrice.Width = 150;
            // 
            // Total
            // 
            this.Total.Text = "Total";
            this.Total.Width = 150;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(12, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(300, 25);
            this.label3.TabIndex = 1666;
            this.label3.Text = "PURCHASE DETAIL REPORT";
            // 
            // lstSearch
            // 
            this.lstSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstSearch.FormattingEnabled = true;
            this.lstSearch.ItemHeight = 15;
            this.lstSearch.Items.AddRange(new object[] {
            "Search By Date",
            "Search By Item & Date",
            "Search By Bill No",
            "Search By Supplier and Date"});
            this.lstSearch.Location = new System.Drawing.Point(12, 945);
            this.lstSearch.Name = "lstSearch";
            this.lstSearch.Size = new System.Drawing.Size(161, 79);
            this.lstSearch.TabIndex = 1671;
            this.lstSearch.SelectedIndexChanged += new System.EventHandler(this.lstSearch_SelectedIndexChanged);
            // 
            // gpdate
            // 
            this.gpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpdate.Controls.Add(this.dtto);
            this.gpdate.Controls.Add(this.lib2);
            this.gpdate.Controls.Add(this.lib1);
            this.gpdate.Controls.Add(this.dtfrom);
            this.gpdate.Location = new System.Drawing.Point(179, 986);
            this.gpdate.Name = "gpdate";
            this.gpdate.Size = new System.Drawing.Size(393, 37);
            this.gpdate.TabIndex = 1670;
            // 
            // dtto
            // 
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtto.Location = new System.Drawing.Point(261, 8);
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
            this.gpinvioce.Location = new System.Drawing.Point(179, 946);
            this.gpinvioce.Name = "gpinvioce";
            this.gpinvioce.Size = new System.Drawing.Size(393, 37);
            this.gpinvioce.TabIndex = 1669;
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
            this.btnReport.Location = new System.Drawing.Point(667, 960);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(71, 64);
            this.btnReport.TabIndex = 1668;
            this.btnReport.Text = "Report";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(594, 960);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(71, 64);
            this.btnSearch.TabIndex = 1667;
            this.btnSearch.Text = "View";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalQty.Enabled = false;
            this.txtTotalQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalQty.Location = new System.Drawing.Point(871, 994);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Size = new System.Drawing.Size(188, 24);
            this.txtTotalQty.TabIndex = 1675;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(771, 1000);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1674;
            this.label1.Text = "Total Quantity";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalSaleValue
            // 
            this.txtTotalSaleValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalSaleValue.Enabled = false;
            this.txtTotalSaleValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSaleValue.Location = new System.Drawing.Point(871, 964);
            this.txtTotalSaleValue.Name = "txtTotalSaleValue";
            this.txtTotalSaleValue.Size = new System.Drawing.Size(188, 24);
            this.txtTotalSaleValue.TabIndex = 1673;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(771, 970);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 1672;
            this.label7.Text = "TotalSaleValue";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPurchaseDetailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.txtTotalQty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalSaleValue);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lstSearch);
            this.Controls.Add(this.gpdate);
            this.Controls.Add(this.gpinvioce);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstInvoiceDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPurchaseDetailReport";
            this.Text = "Purchase Detail Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.ColumnHeader InvoiceNo;
        private System.Windows.Forms.ColumnHeader SupplierID;
        private System.Windows.Forms.ColumnHeader SupplierName;
        private System.Windows.Forms.ColumnHeader SystemDate;
        private System.Windows.Forms.ColumnHeader CurrencyName;
        private System.Windows.Forms.ColumnHeader ProductCode;
        private System.Windows.Forms.ColumnHeader ProductName;
        private System.Windows.Forms.ColumnHeader BatchNo;
        private System.Windows.Forms.ColumnHeader ExpiryDate;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader PurchasePrice;
        private System.Windows.Forms.ColumnHeader Total;
        private System.Windows.Forms.Label label3;
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
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalSaleValue;
        private System.Windows.Forms.Label label7;
    }
}