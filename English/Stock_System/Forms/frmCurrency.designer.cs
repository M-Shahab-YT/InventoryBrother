namespace Stock_System.Forms
{
    partial class frmCurrency
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
            this.radPageView2 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.lstCurrency = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.BarCode = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.btnSaveCurrency = new Telerik.WinControls.UI.RadButton();
            this.chkIsBaseCurrency = new System.Windows.Forms.CheckBox();
            this.txtCurrencySymbol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFromBaseCurrencyOperator = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCurrencyName = new System.Windows.Forms.TextBox();
            this.cmbToBaseCurrencyOperator = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radPageViewPage3 = new Telerik.WinControls.UI.RadPageViewPage();
            this.btnSaveExchangeRate = new Telerik.WinControls.UI.RadButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExchangeRate = new System.Windows.Forms.TextBox();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lstExchangeRate = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView2)).BeginInit();
            this.radPageView2.SuspendLayout();
            this.radPageViewPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveCurrency)).BeginInit();
            this.radPageViewPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveExchangeRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Orange;
            this.label14.Location = new System.Drawing.Point(46, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(220, 24);
            this.label14.TabIndex = 1635;
            this.label14.Text = "CURRENCY SETTING";
            // 
            // radPageView2
            // 
            this.radPageView2.Controls.Add(this.radPageViewPage2);
            this.radPageView2.Controls.Add(this.radPageViewPage3);
            this.radPageView2.Cursor = System.Windows.Forms.Cursors.Default;
            this.radPageView2.Location = new System.Drawing.Point(44, 148);
            this.radPageView2.Name = "radPageView2";
            this.radPageView2.SelectedPage = this.radPageViewPage2;
            this.radPageView2.Size = new System.Drawing.Size(1384, 609);
            this.radPageView2.TabIndex = 1636;
            this.radPageView2.Text = "radPageView2";
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.lstCurrency);
            this.radPageViewPage2.Controls.Add(this.btnSaveCurrency);
            this.radPageViewPage2.Controls.Add(this.chkIsBaseCurrency);
            this.radPageViewPage2.Controls.Add(this.txtCurrencySymbol);
            this.radPageViewPage2.Controls.Add(this.label1);
            this.radPageViewPage2.Controls.Add(this.cmbFromBaseCurrencyOperator);
            this.radPageViewPage2.Controls.Add(this.label3);
            this.radPageViewPage2.Controls.Add(this.label8);
            this.radPageViewPage2.Controls.Add(this.txtCurrencyName);
            this.radPageViewPage2.Controls.Add(this.cmbToBaseCurrencyOperator);
            this.radPageViewPage2.Controls.Add(this.label4);
            this.radPageViewPage2.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(1363, 561);
            this.radPageViewPage2.Text = "Currency";
            // 
            // lstCurrency
            // 
            this.lstCurrency.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.BarCode,
            this.columnHeader4,
            this.columnHeader5});
            this.lstCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCurrency.FullRowSelect = true;
            this.lstCurrency.GridLines = true;
            this.lstCurrency.Location = new System.Drawing.Point(10, 134);
            this.lstCurrency.Name = "lstCurrency";
            this.lstCurrency.Size = new System.Drawing.Size(1326, 403);
            this.lstCurrency.TabIndex = 502;
            this.lstCurrency.UseCompatibleStateImageBehavior = false;
            this.lstCurrency.View = System.Windows.Forms.View.Details;
            this.lstCurrency.DoubleClick += new System.EventHandler(this.lstCurrency_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Currency ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Currency Name";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Symbol";
            this.columnHeader3.Width = 100;
            // 
            // BarCode
            // 
            this.BarCode.Text = "To Base Currency";
            this.BarCode.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "From Base Currency";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Is Base Currency?";
            this.columnHeader5.Width = 150;
            // 
            // btnSaveCurrency
            // 
            this.btnSaveCurrency.Location = new System.Drawing.Point(148, 81);
            this.btnSaveCurrency.Name = "btnSaveCurrency";
            this.btnSaveCurrency.Size = new System.Drawing.Size(116, 38);
            this.btnSaveCurrency.TabIndex = 181;
            this.btnSaveCurrency.Text = "Save";
            this.btnSaveCurrency.Click += new System.EventHandler(this.btnSaveCurrency_Click);
            // 
            // chkIsBaseCurrency
            // 
            this.chkIsBaseCurrency.AutoSize = true;
            this.chkIsBaseCurrency.Location = new System.Drawing.Point(285, 92);
            this.chkIsBaseCurrency.Name = "chkIsBaseCurrency";
            this.chkIsBaseCurrency.Size = new System.Drawing.Size(113, 17);
            this.chkIsBaseCurrency.TabIndex = 180;
            this.chkIsBaseCurrency.Text = "Is Base Currency?";
            this.chkIsBaseCurrency.UseVisualStyleBackColor = true;
            // 
            // txtCurrencySymbol
            // 
            this.txtCurrencySymbol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrencySymbol.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrencySymbol.Location = new System.Drawing.Point(148, 50);
            this.txtCurrencySymbol.Name = "txtCurrencySymbol";
            this.txtCurrencySymbol.Size = new System.Drawing.Size(264, 25);
            this.txtCurrencySymbol.TabIndex = 172;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(10, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 18);
            this.label1.TabIndex = 173;
            this.label1.Text = "Currency Symbol";
            // 
            // cmbFromBaseCurrencyOperator
            // 
            this.cmbFromBaseCurrencyOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromBaseCurrencyOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFromBaseCurrencyOperator.FormattingEnabled = true;
            this.cmbFromBaseCurrencyOperator.Items.AddRange(new object[] {
            "*",
            "/"});
            this.cmbFromBaseCurrencyOperator.Location = new System.Drawing.Point(653, 48);
            this.cmbFromBaseCurrencyOperator.Name = "cmbFromBaseCurrencyOperator";
            this.cmbFromBaseCurrencyOperator.Size = new System.Drawing.Size(242, 28);
            this.cmbFromBaseCurrencyOperator.TabIndex = 178;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Indigo;
            this.label3.Location = new System.Drawing.Point(431, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 20);
            this.label3.TabIndex = 179;
            this.label3.Text = "To Base Currency Operator";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Indigo;
            this.label8.Location = new System.Drawing.Point(431, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(221, 20);
            this.label8.TabIndex = 177;
            this.label8.Text = "From Base Currency Operator";
            // 
            // txtCurrencyName
            // 
            this.txtCurrencyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrencyName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrencyName.Location = new System.Drawing.Point(148, 18);
            this.txtCurrencyName.Name = "txtCurrencyName";
            this.txtCurrencyName.Size = new System.Drawing.Size(264, 25);
            this.txtCurrencyName.TabIndex = 170;
            // 
            // cmbToBaseCurrencyOperator
            // 
            this.cmbToBaseCurrencyOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToBaseCurrencyOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbToBaseCurrencyOperator.FormattingEnabled = true;
            this.cmbToBaseCurrencyOperator.Items.AddRange(new object[] {
            "*",
            "/"});
            this.cmbToBaseCurrencyOperator.Location = new System.Drawing.Point(653, 16);
            this.cmbToBaseCurrencyOperator.Name = "cmbToBaseCurrencyOperator";
            this.cmbToBaseCurrencyOperator.Size = new System.Drawing.Size(242, 28);
            this.cmbToBaseCurrencyOperator.TabIndex = 176;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Indigo;
            this.label4.Location = new System.Drawing.Point(10, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 18);
            this.label4.TabIndex = 171;
            this.label4.Text = "Currency Name";
            // 
            // radPageViewPage3
            // 
            this.radPageViewPage3.Controls.Add(this.btnSaveExchangeRate);
            this.radPageViewPage3.Controls.Add(this.label2);
            this.radPageViewPage3.Controls.Add(this.txtExchangeRate);
            this.radPageViewPage3.Controls.Add(this.cmbCurrency);
            this.radPageViewPage3.Controls.Add(this.label5);
            this.radPageViewPage3.Controls.Add(this.lstExchangeRate);
            this.radPageViewPage3.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPage3.Name = "radPageViewPage3";
            this.radPageViewPage3.Size = new System.Drawing.Size(1363, 561);
            this.radPageViewPage3.Text = "Exchange Rate";
            // 
            // btnSaveExchangeRate
            // 
            this.btnSaveExchangeRate.Location = new System.Drawing.Point(117, 71);
            this.btnSaveExchangeRate.Name = "btnSaveExchangeRate";
            this.btnSaveExchangeRate.Size = new System.Drawing.Size(116, 38);
            this.btnSaveExchangeRate.TabIndex = 508;
            this.btnSaveExchangeRate.Text = "Save";
            this.btnSaveExchangeRate.Click += new System.EventHandler(this.btnSaveExchangeRate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Indigo;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 507;
            this.label2.Text = "Currency";
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExchangeRate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExchangeRate.Location = new System.Drawing.Point(117, 40);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Size = new System.Drawing.Size(264, 25);
            this.txtExchangeRate.TabIndex = 504;
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Items.AddRange(new object[] {
            "*",
            "/"});
            this.cmbCurrency.Location = new System.Drawing.Point(117, 6);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(264, 28);
            this.cmbCurrency.TabIndex = 506;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Indigo;
            this.label5.Location = new System.Drawing.Point(4, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 18);
            this.label5.TabIndex = 505;
            this.label5.Text = "Exchange Rate";
            // 
            // lstExchangeRate
            // 
            this.lstExchangeRate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lstExchangeRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstExchangeRate.FullRowSelect = true;
            this.lstExchangeRate.GridLines = true;
            this.lstExchangeRate.Location = new System.Drawing.Point(3, 115);
            this.lstExchangeRate.Name = "lstExchangeRate";
            this.lstExchangeRate.Size = new System.Drawing.Size(1320, 395);
            this.lstExchangeRate.TabIndex = 503;
            this.lstExchangeRate.UseCompatibleStateImageBehavior = false;
            this.lstExchangeRate.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ID";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Currency";
            this.columnHeader7.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Exchange Rate";
            this.columnHeader8.Width = 150;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Date";
            this.columnHeader9.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "User";
            this.columnHeader10.Width = 150;
            // 
            // frmCurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.radPageView2);
            this.Controls.Add(this.label14);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCurrency";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Currency";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmCurrency_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView2)).EndInit();
            this.radPageView2.ResumeLayout(false);
            this.radPageViewPage2.ResumeLayout(false);
            this.radPageViewPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveCurrency)).EndInit();
            this.radPageViewPage3.ResumeLayout(false);
            this.radPageViewPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveExchangeRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private Telerik.WinControls.UI.RadPageView radPageView2;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage3;
        private System.Windows.Forms.TextBox txtCurrencySymbol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurrencyName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbToBaseCurrencyOperator;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbFromBaseCurrencyOperator;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIsBaseCurrency;
        private Telerik.WinControls.UI.RadButton btnSaveCurrency;
        private System.Windows.Forms.ListView lstCurrency;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader BarCode;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExchangeRate;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lstExchangeRate;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private Telerik.WinControls.UI.RadButton btnSaveExchangeRate;
    }
}

