namespace Stock_System.Forms
{
    partial class frmProductDamageOrLostReport
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
            this.label3 = new System.Windows.Forms.Label();
            this.lstInvoiceDetail = new System.Windows.Forms.ListView();
            this.SNO = new System.Windows.Forms.ColumnHeader();
            this.itemeid = new System.Windows.Forms.ColumnHeader();
            this.ItemName = new System.Windows.Forms.ColumnHeader();
            this.Category = new System.Windows.Forms.ColumnHeader();
            this.qty = new System.Windows.Forms.ColumnHeader();
            this.rate = new System.Windows.Forms.ColumnHeader();
            this.RetDate = new System.Windows.Forms.ColumnHeader();
            this.ReturnBy = new System.Windows.Forms.ColumnHeader();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalSaleValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lstSearch = new System.Windows.Forms.ListBox();
            this.gpdate = new System.Windows.Forms.Panel();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.lib2 = new System.Windows.Forms.Label();
            this.lib1 = new System.Windows.Forms.Label();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.gpinvioce = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Invoice = new System.Windows.Forms.TextBox();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.gpdate.SuspendLayout();
            this.gpinvioce.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(17, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(403, 25);
            this.label3.TabIndex = 1667;
            this.label3.Text = "PRODUCT DAMAGE OR LOST REPORT";
            // 
            // lstInvoiceDetail
            // 
            this.lstInvoiceDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SNO,
            this.itemeid,
            this.ItemName,
            this.Category,
            this.qty,
            this.rate,
            this.RetDate,
            this.ReturnBy});
            this.lstInvoiceDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstInvoiceDetail.FullRowSelect = true;
            this.lstInvoiceDetail.GridLines = true;
            this.lstInvoiceDetail.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstInvoiceDetail.Location = new System.Drawing.Point(20, 161);
            this.lstInvoiceDetail.Name = "lstInvoiceDetail";
            this.lstInvoiceDetail.Size = new System.Drawing.Size(1880, 758);
            this.lstInvoiceDetail.TabIndex = 1668;
            this.lstInvoiceDetail.UseCompatibleStateImageBehavior = false;
            this.lstInvoiceDetail.View = System.Windows.Forms.View.Details;
            // 
            // SNO
            // 
            this.SNO.Text = "SNO";
            this.SNO.Width = 120;
            // 
            // itemeid
            // 
            this.itemeid.Text = "Product Code";
            this.itemeid.Width = 200;
            // 
            // ItemName
            // 
            this.ItemName.Text = "Product Name";
            this.ItemName.Width = 300;
            // 
            // Category
            // 
            this.Category.Text = "Category";
            this.Category.Width = 200;
            // 
            // qty
            // 
            this.qty.Text = "Quantity";
            this.qty.Width = 200;
            // 
            // rate
            // 
            this.rate.Text = "Amount";
            this.rate.Width = 200;
            // 
            // RetDate
            // 
            this.RetDate.Text = "Date";
            this.RetDate.Width = 200;
            // 
            // ReturnBy
            // 
            this.ReturnBy.Text = "User";
            this.ReturnBy.Width = 200;
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalQty.Enabled = false;
            this.txtTotalQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalQty.Location = new System.Drawing.Point(700, 983);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Size = new System.Drawing.Size(188, 29);
            this.txtTotalQty.TabIndex = 1686;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(600, 989);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1685;
            this.label1.Text = "Total Quantity";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalSaleValue
            // 
            this.txtTotalSaleValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalSaleValue.Enabled = false;
            this.txtTotalSaleValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSaleValue.Location = new System.Drawing.Point(700, 949);
            this.txtTotalSaleValue.Name = "txtTotalSaleValue";
            this.txtTotalSaleValue.Size = new System.Drawing.Size(188, 29);
            this.txtTotalSaleValue.TabIndex = 1680;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(600, 955);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 1679;
            this.label7.Text = "Total Return Value";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            "Search By Category & Date"});
            this.lstSearch.Location = new System.Drawing.Point(20, 934);
            this.lstSearch.Name = "lstSearch";
            this.lstSearch.Size = new System.Drawing.Size(158, 79);
            this.lstSearch.TabIndex = 1684;
            // 
            // gpdate
            // 
            this.gpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpdate.Controls.Add(this.dtto);
            this.gpdate.Controls.Add(this.lib2);
            this.gpdate.Controls.Add(this.lib1);
            this.gpdate.Controls.Add(this.dtfrom);
            this.gpdate.Location = new System.Drawing.Point(199, 976);
            this.gpdate.Name = "gpdate";
            this.gpdate.Size = new System.Drawing.Size(393, 37);
            this.gpdate.TabIndex = 1683;
            // 
            // dtto
            // 
            this.dtto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtto.Location = new System.Drawing.Point(261, 5);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(128, 26);
            this.dtto.TabIndex = 52;
            // 
            // lib2
            // 
            this.lib2.AutoSize = true;
            this.lib2.Location = new System.Drawing.Point(206, 12);
            this.lib2.Name = "lib2";
            this.lib2.Size = new System.Drawing.Size(43, 13);
            this.lib2.TabIndex = 54;
            this.lib2.Text = "ToDate";
            // 
            // lib1
            // 
            this.lib1.AutoSize = true;
            this.lib1.Location = new System.Drawing.Point(5, 12);
            this.lib1.Name = "lib1";
            this.lib1.Size = new System.Drawing.Size(56, 13);
            this.lib1.TabIndex = 48;
            this.lib1.Text = "From Date";
            // 
            // dtfrom
            // 
            this.dtfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfrom.Location = new System.Drawing.Point(75, 5);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.Size = new System.Drawing.Size(128, 26);
            this.dtfrom.TabIndex = 51;
            // 
            // gpinvioce
            // 
            this.gpinvioce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpinvioce.Controls.Add(this.label4);
            this.gpinvioce.Controls.Add(this.txt_Invoice);
            this.gpinvioce.Enabled = false;
            this.gpinvioce.Location = new System.Drawing.Point(199, 936);
            this.gpinvioce.Name = "gpinvioce";
            this.gpinvioce.Size = new System.Drawing.Size(393, 37);
            this.gpinvioce.TabIndex = 1682;
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
            // txt_Invoice
            // 
            this.txt_Invoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Invoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Invoice.Location = new System.Drawing.Point(76, 4);
            this.txt_Invoice.Name = "txt_Invoice";
            this.txt_Invoice.Size = new System.Drawing.Size(281, 29);
            this.txt_Invoice.TabIndex = 49;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(914, 936);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 77);
            this.btnSearch.TabIndex = 1681;
            this.btnSearch.Text = "View";
            // 
            // frmProductDamageOrLostReport
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
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lstInvoiceDetail);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProductDamageOrLostReport";
            this.Text = "Damage Or Lost Report";
            this.gpdate.ResumeLayout(false);
            this.gpdate.PerformLayout();
            this.gpinvioce.ResumeLayout(false);
            this.gpinvioce.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lstInvoiceDetail;
        private System.Windows.Forms.ColumnHeader SNO;
        private System.Windows.Forms.ColumnHeader itemeid;
        private System.Windows.Forms.ColumnHeader ItemName;
        private System.Windows.Forms.ColumnHeader Category;
        private System.Windows.Forms.ColumnHeader qty;
        private System.Windows.Forms.ColumnHeader rate;
        private System.Windows.Forms.ColumnHeader RetDate;
        private System.Windows.Forms.ColumnHeader ReturnBy;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalSaleValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lstSearch;
        private System.Windows.Forms.Panel gpdate;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.Label lib2;
        private System.Windows.Forms.Label lib1;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private System.Windows.Forms.Panel gpinvioce;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Invoice;
        private Telerik.WinControls.UI.RadButton btnSearch;
    }
}