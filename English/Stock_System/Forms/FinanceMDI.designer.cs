namespace Stock_System.Forms
{
    partial class FinanceMDI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinanceMDI));
            this.timr = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.main_panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRevenue = new Telerik.WinControls.UI.RadButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCashirBalance = new Telerik.WinControls.UI.RadButton();
            this.btnSalesMan = new Telerik.WinControls.UI.RadButton();
            this.btnSupplier = new Telerik.WinControls.UI.RadButton();
            this.btnCustomer = new Telerik.WinControls.UI.RadButton();
            this.btnAccounts = new Telerik.WinControls.UI.RadButton();
            this.btnCurrency = new Telerik.WinControls.UI.RadButton();
            this.btnExpense = new Telerik.WinControls.UI.RadButton();
            this.btnPOS = new Telerik.WinControls.UI.RadButton();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.lib_date_time = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRevenue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCashirBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalesMan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExpense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPOS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timr
            // 
            this.timr.Enabled = true;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.OwnerDraw = true;
            this.toolTip1.ReshowDelay = 1000;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.StripAmpersands = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Information";
            // 
            // main_panel
            // 
            this.main_panel.BackgroundImage = global::Stock_System.Properties.Resources.Polaris_Logo;
            this.main_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.main_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_panel.Location = new System.Drawing.Point(0, 0);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(1920, 1080);
            this.main_panel.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnRevenue);
            this.panel1.Controls.Add(this.btnCashirBalance);
            this.panel1.Controls.Add(this.btnSalesMan);
            this.panel1.Controls.Add(this.btnSupplier);
            this.panel1.Controls.Add(this.btnCustomer);
            this.panel1.Controls.Add(this.btnAccounts);
            this.panel1.Controls.Add(this.btnCurrency);
            this.panel1.Controls.Add(this.btnExpense);
            this.panel1.Controls.Add(this.btnPOS);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 76);
            this.panel1.TabIndex = 9;
            // 
            // btnRevenue
            // 
            this.btnRevenue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRevenue.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRevenue.Enabled = false;
            this.btnRevenue.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnRevenue.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRevenue.ImageKey = "payments_payment_card_credit-512.png";
            this.btnRevenue.ImageList = this.imageList1;
            this.btnRevenue.Location = new System.Drawing.Point(787, 0);
            this.btnRevenue.Name = "btnRevenue";
            this.btnRevenue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnRevenue.Size = new System.Drawing.Size(98, 76);
            this.btnRevenue.SmallImageList = this.imageList1;
            this.btnRevenue.TabIndex = 75;
            this.btnRevenue.Text = "Revenue";
            this.btnRevenue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRevenue.Visible = false;
            this.btnRevenue.Click += new System.EventHandler(this.btnRevenue_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Calculator.png");
            this.imageList1.Images.SetKeyName(1, "Customer.png");
            this.imageList1.Images.SetKeyName(2, "Search.png");
            this.imageList1.Images.SetKeyName(3, "Styles.png");
            this.imageList1.Images.SetKeyName(4, "06_calculator.png");
            this.imageList1.Images.SetKeyName(5, "Exit.png");
            this.imageList1.Images.SetKeyName(6, "user-group-icon.png");
            this.imageList1.Images.SetKeyName(7, "NetByte Design Studio - 0673.png");
            this.imageList1.Images.SetKeyName(8, "NetByte Design Studio - 0993.png");
            this.imageList1.Images.SetKeyName(9, "NetByte Design Studio - 0253.png");
            this.imageList1.Images.SetKeyName(10, "NetByte Design Studio - 0609.png");
            this.imageList1.Images.SetKeyName(11, "NetByte Design Studio - 0675.png");
            this.imageList1.Images.SetKeyName(12, "NetByte Design Studio - 0687.png");
            this.imageList1.Images.SetKeyName(13, "NetByte Design Studio - 0925.png");
            this.imageList1.Images.SetKeyName(14, "NetByte Design Studio - 0926.png");
            this.imageList1.Images.SetKeyName(15, "NetByte Design Studio - 0937.png");
            this.imageList1.Images.SetKeyName(16, "NetByte Design Studio - 0993.png");
            this.imageList1.Images.SetKeyName(17, "NetByte Design Studio - 1017.png");
            this.imageList1.Images.SetKeyName(18, "NetByte Design Studio - 1041.png");
            this.imageList1.Images.SetKeyName(19, "NetByte Design Studio - 1550.png");
            this.imageList1.Images.SetKeyName(20, "NetByte Design Studio - 1551.png");
            this.imageList1.Images.SetKeyName(21, "NetByte Design Studio - 1555.png");
            this.imageList1.Images.SetKeyName(22, "NetByte Design Studio - 1557.png");
            this.imageList1.Images.SetKeyName(23, "NetByte Design Studio - 0229.png");
            this.imageList1.Images.SetKeyName(24, "NetByte Design Studio - 0009.png");
            this.imageList1.Images.SetKeyName(25, "NetByte Design Studio - 0038.png");
            this.imageList1.Images.SetKeyName(26, "Summary.jpg");
            this.imageList1.Images.SetKeyName(27, "stockInStockOut.jpg");
            this.imageList1.Images.SetKeyName(28, "StudentFee.jpg");
            this.imageList1.Images.SetKeyName(29, "PR.png");
            this.imageList1.Images.SetKeyName(30, "ladyShopx.png");
            this.imageList1.Images.SetKeyName(31, "WholesalersRetailers-1496232434.png");
            this.imageList1.Images.SetKeyName(32, "1-22-512.png");
            this.imageList1.Images.SetKeyName(33, "Cancel_32x32.png");
            this.imageList1.Images.SetKeyName(34, "33-512.png");
            this.imageList1.Images.SetKeyName(35, "6310_-_Holding_Gift-512.png");
            this.imageList1.Images.SetKeyName(36, "572711.png");
            this.imageList1.Images.SetKeyName(37, "dashboard_report_reports_kpi_3_bar_hand_chart-512.png");
            this.imageList1.Images.SetKeyName(38, "Donate-Icon-Stocks.png");
            this.imageList1.Images.SetKeyName(39, "download.png");
            this.imageList1.Images.SetKeyName(40, "img_296425.png");
            this.imageList1.Images.SetKeyName(41, "kazem93.ir.puzel.png");
            this.imageList1.Images.SetKeyName(42, "operating-system-97849_640.png");
            this.imageList1.Images.SetKeyName(43, "Product-Icons-04.png");
            this.imageList1.Images.SetKeyName(44, "Products_Icon.png");
            this.imageList1.Images.SetKeyName(45, "purchases_return-512.png");
            this.imageList1.Images.SetKeyName(46, "return-purchase-filled.png");
            this.imageList1.Images.SetKeyName(47, "Salesmen-2-512.png");
            this.imageList1.Images.SetKeyName(48, "supplier.png");
            this.imageList1.Images.SetKeyName(49, "Receipt-512.png");
            this.imageList1.Images.SetKeyName(50, "settings_icon-300x300.png");
            this.imageList1.Images.SetKeyName(51, "1466663.png");
            this.imageList1.Images.SetKeyName(52, "payments_payment_card_credit-512.png");
            this.imageList1.Images.SetKeyName(53, "salesman.png");
            this.imageList1.Images.SetKeyName(54, "salesman3.png");
            // 
            // btnCashirBalance
            // 
            this.btnCashirBalance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCashirBalance.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCashirBalance.Enabled = false;
            this.btnCashirBalance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCashirBalance.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCashirBalance.ImageKey = "1466663.png";
            this.btnCashirBalance.ImageList = this.imageList1;
            this.btnCashirBalance.Location = new System.Drawing.Point(668, 0);
            this.btnCashirBalance.Name = "btnCashirBalance";
            this.btnCashirBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCashirBalance.Size = new System.Drawing.Size(119, 76);
            this.btnCashirBalance.SmallImageList = this.imageList1;
            this.btnCashirBalance.TabIndex = 74;
            this.btnCashirBalance.Text = "Cashir Balance";
            this.btnCashirBalance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCashirBalance.Click += new System.EventHandler(this.btnCashirBalance_Click);
            // 
            // btnSalesMan
            // 
            this.btnSalesMan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalesMan.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSalesMan.Enabled = false;
            this.btnSalesMan.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSalesMan.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSalesMan.ImageKey = "salesman3.png";
            this.btnSalesMan.ImageList = this.imageList1;
            this.btnSalesMan.Location = new System.Drawing.Point(510, 0);
            this.btnSalesMan.Name = "btnSalesMan";
            this.btnSalesMan.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSalesMan.Size = new System.Drawing.Size(158, 76);
            this.btnSalesMan.SmallImageList = this.imageList1;
            this.btnSalesMan.TabIndex = 76;
            this.btnSalesMan.Text = "Salesman Statement";
            this.btnSalesMan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalesMan.Click += new System.EventHandler(this.btnSalesMan_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupplier.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSupplier.Enabled = false;
            this.btnSupplier.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSupplier.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSupplier.ImageKey = "supplier.png";
            this.btnSupplier.ImageList = this.imageList1;
            this.btnSupplier.Location = new System.Drawing.Point(412, 0);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSupplier.Size = new System.Drawing.Size(98, 76);
            this.btnSupplier.SmallImageList = this.imageList1;
            this.btnSupplier.TabIndex = 73;
            this.btnSupplier.Text = "Supplier";
            this.btnSupplier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomer.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCustomer.Enabled = false;
            this.btnCustomer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCustomer.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCustomer.ImageKey = "Customer.png";
            this.btnCustomer.ImageList = this.imageList1;
            this.btnCustomer.Location = new System.Drawing.Point(314, 0);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCustomer.Size = new System.Drawing.Size(98, 76);
            this.btnCustomer.SmallImageList = this.imageList1;
            this.btnCustomer.TabIndex = 72;
            this.btnCustomer.Text = "Customer";
            this.btnCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnAccounts
            // 
            this.btnAccounts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccounts.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAccounts.Enabled = false;
            this.btnAccounts.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAccounts.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAccounts.ImageKey = "6310_-_Holding_Gift-512.png";
            this.btnAccounts.ImageList = this.imageList1;
            this.btnAccounts.Location = new System.Drawing.Point(196, 0);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAccounts.Size = new System.Drawing.Size(118, 76);
            this.btnAccounts.SmallImageList = this.imageList1;
            this.btnAccounts.TabIndex = 71;
            this.btnAccounts.Text = "Cash Accounts";
            this.btnAccounts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAccounts.Click += new System.EventHandler(this.btnPurchaseReport_Click_1);
            // 
            // btnCurrency
            // 
            this.btnCurrency.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCurrency.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCurrency.Enabled = false;
            this.btnCurrency.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCurrency.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCurrency.ImageKey = "dashboard_report_reports_kpi_3_bar_hand_chart-512.png";
            this.btnCurrency.ImageList = this.imageList1;
            this.btnCurrency.Location = new System.Drawing.Point(98, 0);
            this.btnCurrency.Name = "btnCurrency";
            this.btnCurrency.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCurrency.Size = new System.Drawing.Size(98, 76);
            this.btnCurrency.SmallImageList = this.imageList1;
            this.btnCurrency.TabIndex = 70;
            this.btnCurrency.Text = "Currency";
            this.btnCurrency.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCurrency.Click += new System.EventHandler(this.btnSaleReport_Click_1);
            // 
            // btnExpense
            // 
            this.btnExpense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExpense.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExpense.Enabled = false;
            this.btnExpense.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnExpense.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExpense.ImageKey = "Receipt-512.png";
            this.btnExpense.ImageList = this.imageList1;
            this.btnExpense.Location = new System.Drawing.Point(0, 0);
            this.btnExpense.Name = "btnExpense";
            this.btnExpense.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExpense.Size = new System.Drawing.Size(98, 76);
            this.btnExpense.SmallImageList = this.imageList1;
            this.btnExpense.TabIndex = 69;
            this.btnExpense.Text = "Expense";
            this.btnExpense.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExpense.Click += new System.EventHandler(this.btnExpense_Click);
            // 
            // btnPOS
            // 
            this.btnPOS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPOS.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPOS.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnPOS.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPOS.ImageKey = "Cancel_32x32.png";
            this.btnPOS.ImageList = this.imageList1;
            this.btnPOS.Location = new System.Drawing.Point(1748, 0);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPOS.Size = new System.Drawing.Size(86, 76);
            this.btnPOS.SmallImageList = this.imageList1;
            this.btnPOS.TabIndex = 60;
            this.btnPOS.Text = "POS";
            this.btnPOS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPOS.Click += new System.EventHandler(this.btnPOS_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnExit.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExit.ImageKey = "Exit.png";
            this.btnExit.ImageList = this.imageList1;
            this.btnExit.Location = new System.Drawing.Point(1834, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExit.Size = new System.Drawing.Size(86, 76);
            this.btnExit.SmallImageList = this.imageList1;
            this.btnExit.TabIndex = 59;
            this.btnExit.Text = "Exit";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lib_date_time
            // 
            this.lib_date_time.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lib_date_time.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_date_time.ForeColor = System.Drawing.Color.GreenYellow;
            this.lib_date_time.Location = new System.Drawing.Point(562, 13);
            this.lib_date_time.Name = "lib_date_time";
            this.lib_date_time.Size = new System.Drawing.Size(132, 23);
            this.lib_date_time.TabIndex = 29;
            this.lib_date_time.Text = "                     ";
            this.lib_date_time.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lblCurrentUser);
            this.panel2.Controls.Add(this.lib_date_time);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 1035);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1920, 45);
            this.panel2.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::Stock_System.Properties.Resources.Polaris_Logo4;
            this.pictureBox1.Location = new System.Drawing.Point(20, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.ForeColor = System.Drawing.Color.Blue;
            this.lblCurrentUser.Location = new System.Drawing.Point(355, 13);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(13, 13);
            this.lblCurrentUser.TabIndex = 35;
            this.lblCurrentUser.Text = "..";
            // 
            // FinanceMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.main_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "FinanceMDI";
            this.Text = "MDI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDI_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnRevenue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCashirBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalesMan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExpense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPOS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timr;
        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lib_date_time;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadButton btnExit;
        private System.Windows.Forms.Label lblCurrentUser;
        private Telerik.WinControls.UI.RadButton btnPOS;
        private Telerik.WinControls.UI.RadButton btnExpense;
        private Telerik.WinControls.UI.RadButton btnAccounts;
        private Telerik.WinControls.UI.RadButton btnCurrency;
        private Telerik.WinControls.UI.RadButton btnSupplier;
        private Telerik.WinControls.UI.RadButton btnCustomer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Telerik.WinControls.UI.RadButton btnCashirBalance;
        private Telerik.WinControls.UI.RadButton btnRevenue;
        private Telerik.WinControls.UI.RadButton btnSalesMan;
    }
}