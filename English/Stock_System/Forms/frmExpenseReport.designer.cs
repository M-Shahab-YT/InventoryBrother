namespace Stock_System.Forms
{
    partial class frmExpenseReport
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
            this.gpdate = new System.Windows.Forms.Panel();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.lib2 = new System.Windows.Forms.Label();
            this.lib1 = new System.Windows.Forms.Label();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lstExpenseDetail = new System.Windows.Forms.ListView();
            this.ID = new System.Windows.Forms.ColumnHeader();
            this.ExpenseHead = new System.Windows.Forms.ColumnHeader();
            this.ExpenseDetail = new System.Windows.Forms.ColumnHeader();
            this.ExpenseAmount = new System.Windows.Forms.ColumnHeader();
            this.Currency = new System.Windows.Forms.ColumnHeader();
            this.EntryDate = new System.Windows.Forms.ColumnHeader();
            this.btnGroupReport = new Telerik.WinControls.UI.RadButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalExpenses = new System.Windows.Forms.TextBox();
            this.ExchangeRate = new System.Windows.Forms.ColumnHeader();
            this.BasCurrencyAmount = new System.Windows.Forms.ColumnHeader();
            this.gpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGroupReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gpdate
            // 
            this.gpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpdate.Controls.Add(this.dtto);
            this.gpdate.Controls.Add(this.lib2);
            this.gpdate.Controls.Add(this.lib1);
            this.gpdate.Controls.Add(this.dtfrom);
            this.gpdate.Location = new System.Drawing.Point(24, 945);
            this.gpdate.Name = "gpdate";
            this.gpdate.Size = new System.Drawing.Size(622, 58);
            this.gpdate.TabIndex = 172;
            // 
            // dtto
            // 
            this.dtto.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtto.Location = new System.Drawing.Point(397, 9);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(170, 39);
            this.dtto.TabIndex = 52;
            // 
            // lib2
            // 
            this.lib2.AutoSize = true;
            this.lib2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib2.Location = new System.Drawing.Point(306, 18);
            this.lib2.Name = "lib2";
            this.lib2.Size = new System.Drawing.Size(57, 21);
            this.lib2.TabIndex = 54;
            this.lib2.Text = "ToDate";
            // 
            // lib1
            // 
            this.lib1.AutoSize = true;
            this.lib1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib1.Location = new System.Drawing.Point(9, 18);
            this.lib1.Name = "lib1";
            this.lib1.Size = new System.Drawing.Size(83, 21);
            this.lib1.TabIndex = 48;
            this.lib1.Text = "From Date";
            // 
            // dtfrom
            // 
            this.dtfrom.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfrom.Location = new System.Drawing.Point(126, 9);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.Size = new System.Drawing.Size(170, 39);
            this.dtfrom.TabIndex = 51;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(665, 945);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(132, 58);
            this.btnSearch.TabIndex = 173;
            this.btnSearch.Text = "View";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(19, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 25);
            this.label1.TabIndex = 1636;
            this.label1.Text = "Expenses Report";
            // 
            // lstExpenseDetail
            // 
            this.lstExpenseDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.ExpenseHead,
            this.ExpenseDetail,
            this.ExpenseAmount,
            this.Currency,
            this.ExchangeRate,
            this.BasCurrencyAmount,
            this.EntryDate});
            this.lstExpenseDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstExpenseDetail.FullRowSelect = true;
            this.lstExpenseDetail.GridLines = true;
            this.lstExpenseDetail.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstExpenseDetail.Location = new System.Drawing.Point(24, 140);
            this.lstExpenseDetail.Name = "lstExpenseDetail";
            this.lstExpenseDetail.ShowItemToolTips = true;
            this.lstExpenseDetail.Size = new System.Drawing.Size(1865, 780);
            this.lstExpenseDetail.TabIndex = 1637;
            this.lstExpenseDetail.UseCompatibleStateImageBehavior = false;
            this.lstExpenseDetail.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "#";
            this.ID.Width = 50;
            // 
            // ExpenseHead
            // 
            this.ExpenseHead.Text = "Expense Head";
            this.ExpenseHead.Width = 328;
            // 
            // ExpenseDetail
            // 
            this.ExpenseDetail.Text = "Expense Detail";
            this.ExpenseDetail.Width = 600;
            // 
            // ExpenseAmount
            // 
            this.ExpenseAmount.Text = "Expense Amount";
            this.ExpenseAmount.Width = 201;
            // 
            // Currency
            // 
            this.Currency.Text = "Currency";
            this.Currency.Width = 100;
            // 
            // EntryDate
            // 
            this.EntryDate.Text = "Entry Date";
            this.EntryDate.Width = 180;
            // 
            // btnGroupReport
            // 
            this.btnGroupReport.Location = new System.Drawing.Point(804, 945);
            this.btnGroupReport.Name = "btnGroupReport";
            this.btnGroupReport.Size = new System.Drawing.Size(144, 58);
            this.btnGroupReport.TabIndex = 1638;
            this.btnGroupReport.Text = "Group Report";
            this.btnGroupReport.Click += new System.EventHandler(this.btnGroupReport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1269, 951);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 20);
            this.label3.TabIndex = 1640;
            this.label3.Text = "Total Expenses Home Currency:";
            // 
            // txtTotalExpenses
            // 
            this.txtTotalExpenses.BackColor = System.Drawing.Color.White;
            this.txtTotalExpenses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalExpenses.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalExpenses.ForeColor = System.Drawing.Color.Black;
            this.txtTotalExpenses.Location = new System.Drawing.Point(1511, 945);
            this.txtTotalExpenses.Name = "txtTotalExpenses";
            this.txtTotalExpenses.Size = new System.Drawing.Size(378, 32);
            this.txtTotalExpenses.TabIndex = 1639;
            // 
            // ExchangeRate
            // 
            this.ExchangeRate.Text = "Exchange Rate";
            this.ExchangeRate.Width = 150;
            // 
            // BasCurrencyAmount
            // 
            this.BasCurrencyAmount.Text = "Bas Currency Amount";
            this.BasCurrencyAmount.Width = 200;
            // 
            // frmExpenseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1936, 1100);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotalExpenses);
            this.Controls.Add(this.btnGroupReport);
            this.Controls.Add(this.lstExpenseDetail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.gpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmExpenseReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Expense Report";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmExpenseReport_Load);
            this.gpdate.ResumeLayout(false);
            this.gpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGroupReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gpdate;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.Label lib2;
        private System.Windows.Forms.Label lib1;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstExpenseDetail;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader ExpenseHead;
        private System.Windows.Forms.ColumnHeader ExpenseDetail;
        private System.Windows.Forms.ColumnHeader ExpenseAmount;
        private System.Windows.Forms.ColumnHeader Currency;
        private System.Windows.Forms.ColumnHeader EntryDate;
        private Telerik.WinControls.UI.RadButton btnGroupReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalExpenses;
        private System.Windows.Forms.ColumnHeader ExchangeRate;
        private System.Windows.Forms.ColumnHeader BasCurrencyAmount;
    }
}

