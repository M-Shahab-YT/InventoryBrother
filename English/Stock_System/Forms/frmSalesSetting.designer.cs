namespace Stock_System.Forms
{
    partial class frmSalesSetting
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
            this.label14 = new System.Windows.Forms.Label();
            this.chkSalesPriceCanBeEditable = new System.Windows.Forms.CheckBox();
            this.btnSaveSetting = new Telerik.WinControls.UI.RadButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkInvoicePrintInHalfA4Page = new System.Windows.Forms.CheckBox();
            this.chkShowAveragePrice = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbInvoiceLanguage = new System.Windows.Forms.ComboBox();
            this.chkUserCanChangetheDiscount = new System.Windows.Forms.CheckBox();
            this.chkInvoicePrintInA4Page = new System.Windows.Forms.CheckBox();
            this.chkRepeatedItemsShowInSingleRow = new System.Windows.Forms.CheckBox();
            this.chkShowSalesMan = new System.Windows.Forms.CheckBox();
            this.chkShowPrintalert = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveSetting)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            this.label14.Location = new System.Drawing.Point(34, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(199, 37);
            this.label14.TabIndex = 1604;
            this.label14.Text = "SALES SETTING";
            // 
            // chkSalesPriceCanBeEditable
            // 
            this.chkSalesPriceCanBeEditable.AutoSize = true;
            this.chkSalesPriceCanBeEditable.Location = new System.Drawing.Point(44, 42);
            this.chkSalesPriceCanBeEditable.Name = "chkSalesPriceCanBeEditable";
            this.chkSalesPriceCanBeEditable.Size = new System.Drawing.Size(188, 17);
            this.chkSalesPriceCanBeEditable.TabIndex = 1606;
            this.chkSalesPriceCanBeEditable.Text = "User Can Change The Sales Price";
            this.chkSalesPriceCanBeEditable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSalesPriceCanBeEditable.UseVisualStyleBackColor = true;
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSetting.ForeColor = System.Drawing.Color.White;
            this.btnSaveSetting.Location = new System.Drawing.Point(142, 305);
            this.btnSaveSetting.Name = "btnSaveSetting";
            // 
            // 
            // 
            this.btnSaveSetting.RootElement.ForeColor = System.Drawing.Color.White;
            this.btnSaveSetting.Size = new System.Drawing.Size(121, 49);
            this.btnSaveSetting.TabIndex = 1616;
            this.btnSaveSetting.Text = "Save";
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSaveSetting.GetChildAt(0))).Text = "Save";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSaveSetting.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSaveSetting.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSaveSetting.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSaveSetting.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkShowPrintalert);
            this.groupBox1.Controls.Add(this.chkShowSalesMan);
            this.groupBox1.Controls.Add(this.chkInvoicePrintInHalfA4Page);
            this.groupBox1.Controls.Add(this.chkShowAveragePrice);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbInvoiceLanguage);
            this.groupBox1.Controls.Add(this.chkUserCanChangetheDiscount);
            this.groupBox1.Controls.Add(this.chkInvoicePrintInA4Page);
            this.groupBox1.Controls.Add(this.chkRepeatedItemsShowInSingleRow);
            this.groupBox1.Controls.Add(this.chkSalesPriceCanBeEditable);
            this.groupBox1.Controls.Add(this.btnSaveSetting);
            this.groupBox1.Location = new System.Drawing.Point(41, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 403);
            this.groupBox1.TabIndex = 1617;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Check your setting option";
            // 
            // chkInvoicePrintInHalfA4Page
            // 
            this.chkInvoicePrintInHalfA4Page.AutoSize = true;
            this.chkInvoicePrintInHalfA4Page.Location = new System.Drawing.Point(44, 111);
            this.chkInvoicePrintInHalfA4Page.Name = "chkInvoicePrintInHalfA4Page";
            this.chkInvoicePrintInHalfA4Page.Size = new System.Drawing.Size(162, 17);
            this.chkInvoicePrintInHalfA4Page.TabIndex = 1623;
            this.chkInvoicePrintInHalfA4Page.Text = "Invoice Print in Half A4 Page";
            this.chkInvoicePrintInHalfA4Page.UseVisualStyleBackColor = true;
            // 
            // chkShowAveragePrice
            // 
            this.chkShowAveragePrice.AutoSize = true;
            this.chkShowAveragePrice.Location = new System.Drawing.Point(45, 157);
            this.chkShowAveragePrice.Name = "chkShowAveragePrice";
            this.chkShowAveragePrice.Size = new System.Drawing.Size(111, 17);
            this.chkShowAveragePrice.TabIndex = 1622;
            this.chkShowAveragePrice.Text = "Show Stock Price";
            this.chkShowAveragePrice.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1621;
            this.label1.Text = "Invoice Language:";
            // 
            // cmbInvoiceLanguage
            // 
            this.cmbInvoiceLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvoiceLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInvoiceLanguage.FormattingEnabled = true;
            this.cmbInvoiceLanguage.Items.AddRange(new object[] {
            "English",
            "Pashto",
            "Dari"});
            this.cmbInvoiceLanguage.Location = new System.Drawing.Point(142, 235);
            this.cmbInvoiceLanguage.Name = "cmbInvoiceLanguage";
            this.cmbInvoiceLanguage.Size = new System.Drawing.Size(165, 28);
            this.cmbInvoiceLanguage.TabIndex = 1620;
            // 
            // chkUserCanChangetheDiscount
            // 
            this.chkUserCanChangetheDiscount.AutoSize = true;
            this.chkUserCanChangetheDiscount.Location = new System.Drawing.Point(45, 134);
            this.chkUserCanChangetheDiscount.Name = "chkUserCanChangetheDiscount";
            this.chkUserCanChangetheDiscount.Size = new System.Drawing.Size(173, 17);
            this.chkUserCanChangetheDiscount.TabIndex = 1619;
            this.chkUserCanChangetheDiscount.Text = "User Can Change the Discount";
            this.chkUserCanChangetheDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUserCanChangetheDiscount.UseVisualStyleBackColor = true;
            // 
            // chkInvoicePrintInA4Page
            // 
            this.chkInvoicePrintInA4Page.AutoSize = true;
            this.chkInvoicePrintInA4Page.Location = new System.Drawing.Point(44, 88);
            this.chkInvoicePrintInA4Page.Name = "chkInvoicePrintInA4Page";
            this.chkInvoicePrintInA4Page.Size = new System.Drawing.Size(140, 17);
            this.chkInvoicePrintInA4Page.TabIndex = 1618;
            this.chkInvoicePrintInA4Page.Text = "Invoice Print in A4 Page";
            this.chkInvoicePrintInA4Page.UseVisualStyleBackColor = true;
            // 
            // chkRepeatedItemsShowInSingleRow
            // 
            this.chkRepeatedItemsShowInSingleRow.AutoSize = true;
            this.chkRepeatedItemsShowInSingleRow.Location = new System.Drawing.Point(44, 65);
            this.chkRepeatedItemsShowInSingleRow.Name = "chkRepeatedItemsShowInSingleRow";
            this.chkRepeatedItemsShowInSingleRow.Size = new System.Drawing.Size(190, 17);
            this.chkRepeatedItemsShowInSingleRow.TabIndex = 1617;
            this.chkRepeatedItemsShowInSingleRow.Text = "Repeated Items show in single row";
            this.chkRepeatedItemsShowInSingleRow.UseVisualStyleBackColor = true;
            // 
            // chkShowSalesMan
            // 
            this.chkShowSalesMan.AutoSize = true;
            this.chkShowSalesMan.Location = new System.Drawing.Point(45, 180);
            this.chkShowSalesMan.Name = "chkShowSalesMan";
            this.chkShowSalesMan.Size = new System.Drawing.Size(106, 17);
            this.chkShowSalesMan.TabIndex = 1624;
            this.chkShowSalesMan.Text = "Show Sales Man";
            this.chkShowSalesMan.UseVisualStyleBackColor = true;
            // 
            // chkShowPrintalert
            // 
            this.chkShowPrintalert.AutoSize = true;
            this.chkShowPrintalert.Location = new System.Drawing.Point(44, 203);
            this.chkShowPrintalert.Name = "chkShowPrintalert";
            this.chkShowPrintalert.Size = new System.Drawing.Size(101, 17);
            this.chkShowPrintalert.TabIndex = 1625;
            this.chkShowPrintalert.Text = "Show Print Alert";
            this.chkShowPrintalert.UseVisualStyleBackColor = true;
            // 
            // frmSalesSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1556, 884);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label14);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSalesSetting";
            this.Text = "SalesSetting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSalesSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveSetting)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkSalesPriceCanBeEditable;
        private Telerik.WinControls.UI.RadButton btnSaveSetting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkRepeatedItemsShowInSingleRow;
        private System.Windows.Forms.CheckBox chkInvoicePrintInA4Page;
        private System.Windows.Forms.CheckBox chkUserCanChangetheDiscount;
        private System.Windows.Forms.ComboBox cmbInvoiceLanguage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkShowAveragePrice;
        private System.Windows.Forms.CheckBox chkInvoicePrintInHalfA4Page;
        private System.Windows.Forms.CheckBox chkShowSalesMan;
        private System.Windows.Forms.CheckBox chkShowPrintalert;
    }
}