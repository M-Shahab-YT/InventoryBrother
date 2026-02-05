namespace Stock_System.Forms
{
    partial class frmProductStatement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grdProductStatement = new System.Windows.Forms.DataGridView();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLinkColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblOverallBalance = new System.Windows.Forms.Label();
            this.btnCustomerStatmentView = new Telerik.WinControls.UI.RadButton();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.label24 = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.lib1 = new System.Windows.Forms.Label();
            this.btnPrintAdvanceSearch = new Telerik.WinControls.UI.RadButton();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.lib2 = new System.Windows.Forms.Label();
            this.grdStatementDetail = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductStatement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCustomerStatmentView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintAdvanceSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStatementDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grdProductStatement);
            this.groupBox3.Location = new System.Drawing.Point(19, 170);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1871, 820);
            this.groupBox3.TabIndex = 1682;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Product Statement Summary";
            // 
            // grdProductStatement
            // 
            this.grdProductStatement.AllowUserToAddRows = false;
            this.grdProductStatement.AllowUserToDeleteRows = false;
            this.grdProductStatement.AllowUserToResizeColumns = false;
            this.grdProductStatement.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdProductStatement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdProductStatement.ColumnHeadersHeight = 41;
            this.grdProductStatement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerID,
            this.CustomerName,
            this.CategoryName,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewLinkColumn1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdProductStatement.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdProductStatement.Location = new System.Drawing.Point(6, 18);
            this.grdProductStatement.Name = "grdProductStatement";
            this.grdProductStatement.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdProductStatement.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdProductStatement.RowHeadersVisible = false;
            this.grdProductStatement.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdProductStatement.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            this.grdProductStatement.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.grdProductStatement.RowTemplate.Height = 41;
            this.grdProductStatement.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdProductStatement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdProductStatement.Size = new System.Drawing.Size(1858, 796);
            this.grdProductStatement.TabIndex = 0;
            this.grdProductStatement.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdProductStatement_CellContentClick);
            // 
            // CustomerID
            // 
            this.CustomerID.DataPropertyName = "ProductID";
            this.CustomerID.HeaderText = "ProductID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.ReadOnly = true;
            this.CustomerID.Width = 200;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "ProductName";
            this.CustomerName.HeaderText = "Product Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 450;
            // 
            // CategoryName
            // 
            this.CategoryName.DataPropertyName = "CategoryName";
            this.CategoryName.HeaderText = "CategoryName";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            this.CategoryName.Width = 400;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TotalDebit";
            this.dataGridViewTextBoxColumn4.HeaderText = "Total Debit";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TotalCredit";
            this.dataGridViewTextBoxColumn5.HeaderText = "Total Credit";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Balance";
            this.dataGridViewTextBoxColumn6.HeaderText = "Balance";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewLinkColumn1
            // 
            this.dataGridViewLinkColumn1.DataPropertyName = "Statement";
            this.dataGridViewLinkColumn1.HeaderText = "Statement";
            this.dataGridViewLinkColumn1.Name = "dataGridViewLinkColumn1";
            this.dataGridViewLinkColumn1.ReadOnly = true;
            this.dataGridViewLinkColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLinkColumn1.Width = 200;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(518, 12);
            this.btnSearch.Name = "btnSearch";
            // 
            // 
            // 
            this.btnSearch.RootElement.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Size = new System.Drawing.Size(145, 39);
            this.btnSearch.TabIndex = 1683;
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
            this.txtSearchValue.Location = new System.Drawing.Point(115, 12);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(396, 38);
            this.txtSearchValue.TabIndex = 1685;
            this.txtSearchValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchValue_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Indigo;
            this.label12.Location = new System.Drawing.Point(12, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 16);
            this.label12.TabIndex = 1684;
            this.label12.Text = "Search Value:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSearchValue);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(1222, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(668, 54);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label29.ForeColor = System.Drawing.Color.Orange;
            this.label29.Location = new System.Drawing.Point(22, 115);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(242, 25);
            this.label29.TabIndex = 1683;
            this.label29.Text = "PRODUCT STATMENT";
            // 
            // pnlDetail
            // 
            this.pnlDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(160)))), ((int)(((byte)(134)))));
            this.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetail.Controls.Add(this.label22);
            this.pnlDetail.Controls.Add(this.groupBox2);
            this.pnlDetail.Controls.Add(this.grdStatementDetail);
            this.pnlDetail.Controls.Add(this.button1);
            this.pnlDetail.Location = new System.Drawing.Point(25, 102);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(1726, 882);
            this.pnlDetail.TabIndex = 1684;
            this.pnlDetail.Visible = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.Orange;
            this.label22.Location = new System.Drawing.Point(13, 11);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(339, 25);
            this.label22.TabIndex = 1678;
            this.label22.Text = "PRODUCT STATMENT DETAILS";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblOverallBalance);
            this.groupBox2.Controls.Add(this.btnCustomerStatmentView);
            this.groupBox2.Controls.Add(this.txtProductName);
            this.groupBox2.Controls.Add(this.dtfrom);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.txtProductID);
            this.groupBox2.Controls.Add(this.lib1);
            this.groupBox2.Controls.Add(this.btnPrintAdvanceSearch);
            this.groupBox2.Controls.Add(this.dtto);
            this.groupBox2.Controls.Add(this.lib2);
            this.groupBox2.Location = new System.Drawing.Point(5, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1714, 60);
            this.groupBox2.TabIndex = 1677;
            this.groupBox2.TabStop = false;
            // 
            // lblOverallBalance
            // 
            this.lblOverallBalance.AutoSize = true;
            this.lblOverallBalance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverallBalance.ForeColor = System.Drawing.Color.White;
            this.lblOverallBalance.Location = new System.Drawing.Point(10, 25);
            this.lblOverallBalance.Name = "lblOverallBalance";
            this.lblOverallBalance.Size = new System.Drawing.Size(78, 16);
            this.lblOverallBalance.TabIndex = 1687;
            this.lblOverallBalance.Text = "Product ID:";
            // 
            // btnCustomerStatmentView
            // 
            this.btnCustomerStatmentView.Location = new System.Drawing.Point(1478, 11);
            this.btnCustomerStatmentView.Name = "btnCustomerStatmentView";
            this.btnCustomerStatmentView.Size = new System.Drawing.Size(112, 43);
            this.btnCustomerStatmentView.TabIndex = 1675;
            this.btnCustomerStatmentView.Text = "View";
            this.btnCustomerStatmentView.Click += new System.EventHandler(this.btnCustomerStatmentView_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(404, 14);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(557, 38);
            this.txtProductName.TabIndex = 1688;
            // 
            // dtfrom
            // 
            this.dtfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfrom.Location = new System.Drawing.Point(1067, 13);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.Size = new System.Drawing.Size(158, 38);
            this.dtfrom.TabIndex = 1671;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(289, 25);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(102, 16);
            this.label24.TabIndex = 1686;
            this.label24.Text = "Product Name:";
            // 
            // txtProductID
            // 
            this.txtProductID.BackColor = System.Drawing.Color.White;
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductID.Enabled = false;
            this.txtProductID.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductID.ForeColor = System.Drawing.Color.Black;
            this.txtProductID.Location = new System.Drawing.Point(105, 14);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.ReadOnly = true;
            this.txtProductID.Size = new System.Drawing.Size(177, 38);
            this.txtProductID.TabIndex = 1685;
            this.txtProductID.TabStop = false;
            // 
            // lib1
            // 
            this.lib1.AutoSize = true;
            this.lib1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib1.ForeColor = System.Drawing.Color.White;
            this.lib1.Location = new System.Drawing.Point(978, 22);
            this.lib1.Name = "lib1";
            this.lib1.Size = new System.Drawing.Size(85, 20);
            this.lib1.TabIndex = 1670;
            this.lib1.Text = "From Date";
            // 
            // btnPrintAdvanceSearch
            // 
            this.btnPrintAdvanceSearch.Location = new System.Drawing.Point(1594, 11);
            this.btnPrintAdvanceSearch.Name = "btnPrintAdvanceSearch";
            this.btnPrintAdvanceSearch.Size = new System.Drawing.Size(112, 43);
            this.btnPrintAdvanceSearch.TabIndex = 1674;
            this.btnPrintAdvanceSearch.Text = "Print";
            this.btnPrintAdvanceSearch.Click += new System.EventHandler(this.btnPrintAdvanceSearch_Click);
            // 
            // dtto
            // 
            this.dtto.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtto.Location = new System.Drawing.Point(1299, 13);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(162, 38);
            this.dtto.TabIndex = 1672;
            // 
            // lib2
            // 
            this.lib2.AutoSize = true;
            this.lib2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib2.ForeColor = System.Drawing.Color.White;
            this.lib2.Location = new System.Drawing.Point(1231, 22);
            this.lib2.Name = "lib2";
            this.lib2.Size = new System.Drawing.Size(62, 20);
            this.lib2.TabIndex = 1673;
            this.lib2.Text = "ToDate";
            // 
            // grdStatementDetail
            // 
            this.grdStatementDetail.AllowUserToAddRows = false;
            this.grdStatementDetail.AllowUserToDeleteRows = false;
            this.grdStatementDetail.AllowUserToResizeColumns = false;
            this.grdStatementDetail.AllowUserToResizeRows = false;
            this.grdStatementDetail.ColumnHeadersHeight = 40;
            this.grdStatementDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn25});
            this.grdStatementDetail.Location = new System.Drawing.Point(3, 142);
            this.grdStatementDetail.Name = "grdStatementDetail";
            this.grdStatementDetail.ReadOnly = true;
            this.grdStatementDetail.RowHeadersVisible = false;
            this.grdStatementDetail.RowTemplate.Height = 30;
            this.grdStatementDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdStatementDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdStatementDetail.Size = new System.Drawing.Size(1718, 735);
            this.grdStatementDetail.TabIndex = 1676;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "TransactionNo";
            this.ID.HeaderText = "T#";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 150;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn19.HeaderText = "Date";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Width = 160;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "TransactionType";
            this.dataGridViewTextBoxColumn20.HeaderText = "Reference Type";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Width = 400;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "Particulars";
            this.dataGridViewTextBoxColumn21.HeaderText = "Particulars";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Width = 300;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "ReferenceNo";
            this.dataGridViewTextBoxColumn22.HeaderText = "Reference No.";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.Width = 250;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "Debit";
            this.dataGridViewTextBoxColumn23.HeaderText = "Debit";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Width = 150;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "Credit";
            this.dataGridViewTextBoxColumn24.HeaderText = "Credit";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Width = 150;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "Balance";
            this.dataGridViewTextBoxColumn25.HeaderText = "Balance";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            this.dataGridViewTextBoxColumn25.Width = 150;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1679, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 41);
            this.button1.TabIndex = 1604;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmProductStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.pnlDetail);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProductStatement";
            this.Text = "Product Statement";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmProductStatement_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProductStatement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCustomerStatmentView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintAdvanceSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStatementDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView grdProductStatement;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewLinkColumn1;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Button button1;
        private Telerik.WinControls.UI.RadButton btnCustomerStatmentView;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private System.Windows.Forms.Label lib1;
        private Telerik.WinControls.UI.RadButton btnPrintAdvanceSearch;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.Label lib2;
        private System.Windows.Forms.DataGridView grdStatementDetail;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblOverallBalance;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
    }
}