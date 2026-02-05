namespace Stock_System.Forms
{
    partial class frmDailyCash
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
            this.cmbCahier = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lstDailyCash = new System.Windows.Forms.ListView();
            this.AccountID = new System.Windows.Forms.ColumnHeader();
            this.AccountName = new System.Windows.Forms.ColumnHeader();
            this.CurrencyName = new System.Windows.Forms.ColumnHeader();
            this.Date = new System.Windows.Forms.ColumnHeader();
            this.CashIN = new System.Windows.Forms.ColumnHeader();
            this.CashOut = new System.Windows.Forms.ColumnHeader();
            this.Balance = new System.Windows.Forms.ColumnHeader();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCahier
            // 
            this.cmbCahier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCahier.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCahier.FormattingEnabled = true;
            this.cmbCahier.Location = new System.Drawing.Point(114, 144);
            this.cmbCahier.Name = "cmbCahier";
            this.cmbCahier.Size = new System.Drawing.Size(262, 29);
            this.cmbCahier.TabIndex = 1;
            this.cmbCahier.SelectionChangeCommitted += new System.EventHandler(this.cmbCahier_SelectionChangeCommitted);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.label14.ForeColor = System.Drawing.Color.DarkOrange;
            this.label14.Location = new System.Drawing.Point(50, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(141, 37);
            this.label14.TabIndex = 1604;
            this.label14.Text = "Daily Cash";
            // 
            // lstDailyCash
            // 
            this.lstDailyCash.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AccountID,
            this.AccountName,
            this.CurrencyName,
            this.Date,
            this.CashIN,
            this.CashOut,
            this.Balance});
            this.lstDailyCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDailyCash.FullRowSelect = true;
            this.lstDailyCash.GridLines = true;
            this.lstDailyCash.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstDailyCash.Location = new System.Drawing.Point(49, 181);
            this.lstDailyCash.Name = "lstDailyCash";
            this.lstDailyCash.Size = new System.Drawing.Size(946, 407);
            this.lstDailyCash.TabIndex = 1605;
            this.lstDailyCash.UseCompatibleStateImageBehavior = false;
            this.lstDailyCash.View = System.Windows.Forms.View.Details;
            // 
            // AccountID
            // 
            this.AccountID.Text = "AccountID";
            this.AccountID.Width = 150;
            // 
            // AccountName
            // 
            this.AccountName.Text = "AccountName";
            this.AccountName.Width = 300;
            // 
            // CurrencyName
            // 
            this.CurrencyName.Text = "Currency";
            this.CurrencyName.Width = 150;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 150;
            // 
            // CashIN
            // 
            this.CashIN.Text = "Total Cash In";
            this.CashIN.Width = 150;
            // 
            // CashOut
            // 
            this.CashOut.Text = "Total Cash Out";
            this.CashOut.Width = 150;
            // 
            // Balance
            // 
            this.Balance.Text = "Balance";
            this.Balance.Width = 150;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Indigo;
            this.label5.Location = new System.Drawing.Point(43, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 21);
            this.label5.TabIndex = 1607;
            this.label5.Text = "Cashier";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(382, 142);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(108, 33);
            this.btnSearch.TabIndex = 1636;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmDailyCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1394, 826);
            this.Controls.Add(this.lstDailyCash);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbCahier);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDailyCash";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmDailyCash";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmDailyCash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCahier;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListView lstDailyCash;
        private System.Windows.Forms.ColumnHeader AccountID;
        private System.Windows.Forms.ColumnHeader AccountName;
        private System.Windows.Forms.ColumnHeader CurrencyName;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader CashIN;
        private System.Windows.Forms.ColumnHeader CashOut;
        private System.Windows.Forms.ColumnHeader Balance;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadButton btnSearch;
    }
}

