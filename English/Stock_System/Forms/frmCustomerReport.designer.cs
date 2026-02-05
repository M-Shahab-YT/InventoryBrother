namespace Stock_System.Forms
{
    partial class frmCustomerReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label22 = new System.Windows.Forms.Label();
            this.dgCustomerLastPaymentReport = new System.Windows.Forms.DataGridView();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastPaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaysAfterLastPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new Telerik.WinControls.UI.RadButton();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.lblSarchLable = new System.Windows.Forms.Label();
            this.ddlSearch = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomerLastPaymentReport)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.Orange;
            this.label22.Location = new System.Drawing.Point(23, 131);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(248, 25);
            this.label22.TabIndex = 1671;
            this.label22.Text = "CUSTOMER\'S REPORT";
            // 
            // dgCustomerLastPaymentReport
            // 
            this.dgCustomerLastPaymentReport.AllowUserToAddRows = false;
            this.dgCustomerLastPaymentReport.AllowUserToDeleteRows = false;
            this.dgCustomerLastPaymentReport.AllowUserToResizeColumns = false;
            this.dgCustomerLastPaymentReport.AllowUserToResizeRows = false;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCustomerLastPaymentReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgCustomerLastPaymentReport.ColumnHeadersHeight = 41;
            this.dgCustomerLastPaymentReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerID,
            this.CustomerName,
            this.ContactNumber,
            this.Area,
            this.Address,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn6,
            this.LastPaidAmount,
            this.DaysAfterLastPayment});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCustomerLastPaymentReport.DefaultCellStyle = dataGridViewCellStyle17;
            this.dgCustomerLastPaymentReport.Location = new System.Drawing.Point(17, 171);
            this.dgCustomerLastPaymentReport.Name = "dgCustomerLastPaymentReport";
            this.dgCustomerLastPaymentReport.ReadOnly = true;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCustomerLastPaymentReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgCustomerLastPaymentReport.RowHeadersVisible = false;
            this.dgCustomerLastPaymentReport.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgCustomerLastPaymentReport.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.dgCustomerLastPaymentReport.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgCustomerLastPaymentReport.RowTemplate.Height = 41;
            this.dgCustomerLastPaymentReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCustomerLastPaymentReport.Size = new System.Drawing.Size(1879, 754);
            this.dgCustomerLastPaymentReport.TabIndex = 1672;
            // 
            // CustomerID
            // 
            this.CustomerID.DataPropertyName = "CustomerID";
            this.CustomerID.HeaderText = "Customer ID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.ReadOnly = true;
            this.CustomerID.Width = 120;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "CustomerName";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 300;
            // 
            // ContactNumber
            // 
            this.ContactNumber.DataPropertyName = "MobileNumber";
            this.ContactNumber.HeaderText = "Contact Number";
            this.ContactNumber.Name = "ContactNumber";
            this.ContactNumber.ReadOnly = true;
            this.ContactNumber.Width = 200;
            // 
            // Area
            // 
            this.Area.DataPropertyName = "AreaName";
            this.Area.HeaderText = "Area";
            this.Area.Name = "Area";
            this.Area.ReadOnly = true;
            this.Area.Width = 270;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "CustomerAddress";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CurrencyName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Currency";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CurrencyID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Currency ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Balance";
            this.dataGridViewTextBoxColumn6.HeaderText = "Balance";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // LastPaidAmount
            // 
            this.LastPaidAmount.DataPropertyName = "LastPayment";
            this.LastPaidAmount.HeaderText = "Last Paid Amount";
            this.LastPaidAmount.Name = "LastPaidAmount";
            this.LastPaidAmount.ReadOnly = true;
            this.LastPaidAmount.Width = 200;
            // 
            // DaysAfterLastPayment
            // 
            this.DaysAfterLastPayment.DataPropertyName = "DaysAfterLastPayment";
            this.DaysAfterLastPayment.HeaderText = "Days After Last Payment";
            this.DaysAfterLastPayment.Name = "DaysAfterLastPayment";
            this.DaysAfterLastPayment.ReadOnly = true;
            this.DaysAfterLastPayment.Width = 200;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbSearchType);
            this.groupBox1.Controls.Add(this.lblSarchLable);
            this.groupBox1.Controls.Add(this.ddlSearch);
            this.groupBox1.Controls.Add(this.txtSearchValue);
            this.groupBox1.Location = new System.Drawing.Point(17, 931);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1879, 80);
            this.groupBox1.TabIndex = 1680;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Information";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(1745, 17);
            this.btnPrint.Name = "btnPrint";
            // 
            // 
            // 
            this.btnPrint.RootElement.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Size = new System.Drawing.Size(128, 51);
            this.btnPrint.TabIndex = 1670;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrint.GetChildAt(0))).Text = "Print";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(1172, 17);
            this.btnSearch.Name = "btnSearch";
            // 
            // 
            // 
            this.btnSearch.RootElement.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Size = new System.Drawing.Size(145, 50);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSearch.GetChildAt(0))).Text = "Search";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSearch.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSearch.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSearch.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnSearch.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.BackColor = System.Drawing.Color.White;
            this.txtSearchValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchValue.ForeColor = System.Drawing.Color.Black;
            this.txtSearchValue.Location = new System.Drawing.Point(648, 25);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(396, 38);
            this.txtSearchValue.TabIndex = 1640;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 1639;
            this.label2.Text = "Search Type:";
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.BackColor = System.Drawing.Color.White;
            this.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchType.ForeColor = System.Drawing.Color.Black;
            this.cmbSearchType.FormattingEnabled = true;
            this.cmbSearchType.Items.AddRange(new object[] {
            "Search By CustomerID",
            "Search By Customer Name",
            "Search By Currency",
            "Search By Area"});
            this.cmbSearchType.Location = new System.Drawing.Point(119, 23);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(381, 39);
            this.cmbSearchType.TabIndex = 0;
            this.cmbSearchType.SelectionChangeCommitted += new System.EventHandler(this.cmbSearchType_SelectionChangeCommitted);
            // 
            // lblSarchLable
            // 
            this.lblSarchLable.AutoSize = true;
            this.lblSarchLable.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSarchLable.ForeColor = System.Drawing.Color.Indigo;
            this.lblSarchLable.Location = new System.Drawing.Point(506, 34);
            this.lblSarchLable.Name = "lblSarchLable";
            this.lblSarchLable.Size = new System.Drawing.Size(97, 16);
            this.lblSarchLable.TabIndex = 1622;
            this.lblSarchLable.Text = "Search Value:";
            // 
            // ddlSearch
            // 
            this.ddlSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSearch.FormattingEnabled = true;
            this.ddlSearch.Location = new System.Drawing.Point(647, 24);
            this.ddlSearch.Name = "ddlSearch";
            this.ddlSearch.Size = new System.Drawing.Size(397, 37);
            this.ddlSearch.TabIndex = 1681;
            this.ddlSearch.Visible = false;
            // 
            // frmCustomerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgCustomerLastPaymentReport);
            this.Controls.Add(this.label22);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCustomerReport";
            this.Text = "Customer Report";
            this.Load += new System.EventHandler(this.frmCustomerReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomerLastPaymentReport)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DataGridView dgCustomerLastPaymentReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadButton btnPrint;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSearchType;
        private System.Windows.Forms.Label lblSarchLable;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastPaidAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaysAfterLastPayment;
        private System.Windows.Forms.ComboBox ddlSearch;
    }
}