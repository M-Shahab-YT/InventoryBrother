namespace Stock_System.Forms
{
    partial class frmSaleMain
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
            this.lstCustomerSearchView = new System.Windows.Forms.ListView();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.Address = new System.Windows.Forms.ColumnHeader();
            this.Status = new System.Windows.Forms.ColumnHeader();
            this.btnCancelSaleMan = new Telerik.WinControls.UI.RadButton();
            this.btnSaveSaleMan = new Telerik.WinControls.UI.RadButton();
            this.txtSalePercentage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSaleManName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelSaleMan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveSaleMan)).BeginInit();
            this.SuspendLayout();
            // 
            // lstCustomerSearchView
            // 
            this.lstCustomerSearchView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.Address,
            this.Status});
            this.lstCustomerSearchView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCustomerSearchView.FullRowSelect = true;
            this.lstCustomerSearchView.GridLines = true;
            this.lstCustomerSearchView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstCustomerSearchView.Location = new System.Drawing.Point(630, 177);
            this.lstCustomerSearchView.Name = "lstCustomerSearchView";
            this.lstCustomerSearchView.ShowItemToolTips = true;
            this.lstCustomerSearchView.Size = new System.Drawing.Size(1245, 563);
            this.lstCustomerSearchView.TabIndex = 20;
            this.lstCustomerSearchView.UseCompatibleStateImageBehavior = false;
            this.lstCustomerSearchView.View = System.Windows.Forms.View.Details;
            this.lstCustomerSearchView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstCustomerSearchView_KeyDown);
            this.lstCustomerSearchView.Click += new System.EventHandler(this.lstCustomerSearchView_Click);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Saleman ID";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Saleman Name";
            this.columnHeader9.Width = 200;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Sales Percentage";
            this.columnHeader10.Width = 150;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Mobile No";
            this.columnHeader11.Width = 200;
            // 
            // Address
            // 
            this.Address.Text = "Address";
            this.Address.Width = 400;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 100;
            // 
            // btnCancelSaleMan
            // 
            this.btnCancelSaleMan.Location = new System.Drawing.Point(338, 686);
            this.btnCancelSaleMan.Name = "btnCancelSaleMan";
            this.btnCancelSaleMan.Size = new System.Drawing.Size(147, 54);
            this.btnCancelSaleMan.TabIndex = 7;
            this.btnCancelSaleMan.Text = "Cancel";
            this.btnCancelSaleMan.Click += new System.EventHandler(this.btnCancelSaleMan_Click);
            // 
            // btnSaveSaleMan
            // 
            this.btnSaveSaleMan.Location = new System.Drawing.Point(187, 686);
            this.btnSaveSaleMan.Name = "btnSaveSaleMan";
            this.btnSaveSaleMan.Size = new System.Drawing.Size(147, 54);
            this.btnSaveSaleMan.TabIndex = 6;
            this.btnSaveSaleMan.Text = "Save";
            this.btnSaveSaleMan.Click += new System.EventHandler(this.btnSaveSaleMan_Click);
            // 
            // txtSalePercentage
            // 
            this.txtSalePercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalePercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalePercentage.Location = new System.Drawing.Point(187, 219);
            this.txtSalePercentage.Name = "txtSalePercentage";
            this.txtSalePercentage.Size = new System.Drawing.Size(426, 31);
            this.txtSalePercentage.TabIndex = 1;
            this.txtSalePercentage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalePercentage_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sale Percentage";
            // 
            // txtSaleManName
            // 
            this.txtSaleManName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaleManName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaleManName.Location = new System.Drawing.Point(187, 178);
            this.txtSaleManName.Name = "txtSaleManName";
            this.txtSaleManName.Size = new System.Drawing.Size(426, 31);
            this.txtSaleManName.TabIndex = 0;
            this.txtSaleManName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSaleManName_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Salesman Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(43, 297);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 20);
            this.label11.TabIndex = 21;
            this.label11.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(187, 301);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(426, 131);
            this.txtAddress.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(43, 259);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 20);
            this.label12.TabIndex = 23;
            this.label12.Text = "MobileNo";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(45, 483);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 20);
            this.label13.TabIndex = 24;
            this.label13.Text = "Remarks";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMobileNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo.Location = new System.Drawing.Point(187, 260);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(426, 31);
            this.txtMobileNo.TabIndex = 2;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(187, 477);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(426, 175);
            this.txtRemarks.TabIndex = 5;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "InActive",
            "Active and Default"});
            this.cmbStatus.Location = new System.Drawing.Point(187, 438);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(193, 33);
            this.cmbStatus.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(43, 444);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 20);
            this.label14.TabIndex = 28;
            this.label14.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(17)))));
            this.label3.Location = new System.Drawing.Point(40, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(306, 37);
            this.label3.TabIndex = 1605;
            this.label3.Text = "SALES MAN Registration";
            // 
            // frmSaleMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lstCustomerSearchView);
            this.Controls.Add(this.btnCancelSaleMan);
            this.Controls.Add(this.txtSaleManName);
            this.Controls.Add(this.btnSaveSaleMan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSalePercentage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSaleMain";
            this.Text = "frmSaleMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSaleMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelSaleMan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveSaleMan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSalePercentage;
        private System.Windows.Forms.TextBox txtSaleManName;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadButton btnSaveSaleMan;
        private Telerik.WinControls.UI.RadButton btnCancelSaleMan;
        private System.Windows.Forms.ListView lstCustomerSearchView;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ColumnHeader Address;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader Status;
    }
}