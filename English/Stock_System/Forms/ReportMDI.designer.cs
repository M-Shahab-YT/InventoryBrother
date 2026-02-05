namespace Stock_System.Forms
{
    partial class ReportMDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportMDI));
            this.timr = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCashFlow = new Telerik.WinControls.UI.RadButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnShortItem = new Telerik.WinControls.UI.RadButton();
            this.btnCustomerReport = new Telerik.WinControls.UI.RadButton();
            this.btnProductReport = new Telerik.WinControls.UI.RadButton();
            this.btnExpenses = new Telerik.WinControls.UI.RadButton();
            this.btnPurchaseDetailReport = new Telerik.WinControls.UI.RadButton();
            this.btnPOS = new Telerik.WinControls.UI.RadButton();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.btnPurchaseReport = new Telerik.WinControls.UI.RadButton();
            this.btnSalesDetailReport = new Telerik.WinControls.UI.RadButton();
            this.btnSaleReport = new Telerik.WinControls.UI.RadButton();
            this.lib_date_time = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.main_panel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCashFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShortItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCustomerReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProductReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExpenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPurchaseDetailReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPOS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPurchaseReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalesDetailReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaleReport)).BeginInit();
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnCashFlow);
            this.panel1.Controls.Add(this.btnShortItem);
            this.panel1.Controls.Add(this.btnCustomerReport);
            this.panel1.Controls.Add(this.btnProductReport);
            this.panel1.Controls.Add(this.btnExpenses);
            this.panel1.Controls.Add(this.btnPurchaseDetailReport);
            this.panel1.Controls.Add(this.btnPOS);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnPurchaseReport);
            this.panel1.Controls.Add(this.btnSalesDetailReport);
            this.panel1.Controls.Add(this.btnSaleReport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 76);
            this.panel1.TabIndex = 9;
            // 
            // btnCashFlow
            // 
            this.btnCashFlow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCashFlow.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCashFlow.Enabled = false;
            this.btnCashFlow.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCashFlow.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCashFlow.ImageKey = "stockInStockOut.jpg";
            this.btnCashFlow.ImageList = this.imageList1;
            this.btnCashFlow.Location = new System.Drawing.Point(1247, 0);
            this.btnCashFlow.Name = "btnCashFlow";
            this.btnCashFlow.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCashFlow.Size = new System.Drawing.Size(118, 76);
            this.btnCashFlow.SmallImageList = this.imageList1;
            this.btnCashFlow.TabIndex = 73;
            this.btnCashFlow.Text = "CASH FLOW";
            this.btnCashFlow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCashFlow.Click += new System.EventHandler(this.btnCashFlow_Click);
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
            this.imageList1.Images.SetKeyName(34, "1389181.png");
            this.imageList1.Images.SetKeyName(35, "user-circle.png");
            this.imageList1.Images.SetKeyName(36, "sales-report-24-1153334.png");
            this.imageList1.Images.SetKeyName(37, "1466663.png");
            // 
            // btnShortItem
            // 
            this.btnShortItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShortItem.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnShortItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnShortItem.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnShortItem.ImageKey = "NetByte Design Studio - 0009.png";
            this.btnShortItem.ImageList = this.imageList1;
            this.btnShortItem.Location = new System.Drawing.Point(1088, 0);
            this.btnShortItem.Name = "btnShortItem";
            this.btnShortItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnShortItem.Size = new System.Drawing.Size(159, 76);
            this.btnShortItem.SmallImageList = this.imageList1;
            this.btnShortItem.TabIndex = 67;
            this.btnShortItem.Text = "Short Stock\'s Item";
            this.btnShortItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnShortItem.Click += new System.EventHandler(this.btnShortItem_Click);
            // 
            // btnCustomerReport
            // 
            this.btnCustomerReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomerReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCustomerReport.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCustomerReport.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCustomerReport.ImageKey = "Customer.png";
            this.btnCustomerReport.ImageList = this.imageList1;
            this.btnCustomerReport.Location = new System.Drawing.Point(945, 0);
            this.btnCustomerReport.Name = "btnCustomerReport";
            this.btnCustomerReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCustomerReport.Size = new System.Drawing.Size(143, 76);
            this.btnCustomerReport.SmallImageList = this.imageList1;
            this.btnCustomerReport.TabIndex = 64;
            this.btnCustomerReport.Text = "Customer Report";
            this.btnCustomerReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCustomerReport.Click += new System.EventHandler(this.btnCustomerReport_Click);
            // 
            // btnProductReport
            // 
            this.btnProductReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnProductReport.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnProductReport.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnProductReport.ImageKey = "NetByte Design Studio - 1041.png";
            this.btnProductReport.ImageList = this.imageList1;
            this.btnProductReport.Location = new System.Drawing.Point(772, 0);
            this.btnProductReport.Name = "btnProductReport";
            this.btnProductReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnProductReport.Size = new System.Drawing.Size(173, 76);
            this.btnProductReport.SmallImageList = this.imageList1;
            this.btnProductReport.TabIndex = 62;
            this.btnProductReport.Text = "Product Report";
            this.btnProductReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProductReport.Click += new System.EventHandler(this.btnProductReport_Click);
            // 
            // btnExpenses
            // 
            this.btnExpenses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExpenses.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExpenses.Enabled = false;
            this.btnExpenses.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnExpenses.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExpenses.ImageKey = "1466663.png";
            this.btnExpenses.ImageList = this.imageList1;
            this.btnExpenses.Location = new System.Drawing.Point(637, 0);
            this.btnExpenses.Name = "btnExpenses";
            this.btnExpenses.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExpenses.Size = new System.Drawing.Size(135, 76);
            this.btnExpenses.SmallImageList = this.imageList1;
            this.btnExpenses.TabIndex = 60;
            this.btnExpenses.Text = "Expense Report";
            this.btnExpenses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExpenses.Click += new System.EventHandler(this.btnExpenses_Click);
            // 
            // btnPurchaseDetailReport
            // 
            this.btnPurchaseDetailReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPurchaseDetailReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPurchaseDetailReport.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnPurchaseDetailReport.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPurchaseDetailReport.ImageKey = "PR.png";
            this.btnPurchaseDetailReport.ImageList = this.imageList1;
            this.btnPurchaseDetailReport.Location = new System.Drawing.Point(443, 0);
            this.btnPurchaseDetailReport.Name = "btnPurchaseDetailReport";
            this.btnPurchaseDetailReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPurchaseDetailReport.Size = new System.Drawing.Size(194, 76);
            this.btnPurchaseDetailReport.SmallImageList = this.imageList1;
            this.btnPurchaseDetailReport.TabIndex = 65;
            this.btnPurchaseDetailReport.Text = "Purchase Detail Report";
            this.btnPurchaseDetailReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPurchaseDetailReport.Click += new System.EventHandler(this.btnPurchaseDetailReport_Click);
            // 
            // btnPOS
            // 
            this.btnPOS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPOS.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPOS.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnPOS.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPOS.ImageKey = "Cancel_32x32.png";
            this.btnPOS.ImageList = this.imageList1;
            this.btnPOS.Location = new System.Drawing.Point(1788, 0);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPOS.Size = new System.Drawing.Size(66, 76);
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
            this.btnExit.Location = new System.Drawing.Point(1854, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExit.Size = new System.Drawing.Size(66, 76);
            this.btnExit.SmallImageList = this.imageList1;
            this.btnExit.TabIndex = 59;
            this.btnExit.Text = "Exit";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPurchaseReport
            // 
            this.btnPurchaseReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPurchaseReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPurchaseReport.Enabled = false;
            this.btnPurchaseReport.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnPurchaseReport.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPurchaseReport.ImageKey = "sales-report-24-1153334.png";
            this.btnPurchaseReport.ImageList = this.imageList1;
            this.btnPurchaseReport.Location = new System.Drawing.Point(308, 0);
            this.btnPurchaseReport.Name = "btnPurchaseReport";
            this.btnPurchaseReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPurchaseReport.Size = new System.Drawing.Size(135, 76);
            this.btnPurchaseReport.SmallImageList = this.imageList1;
            this.btnPurchaseReport.TabIndex = 60;
            this.btnPurchaseReport.Text = "Purchase Report";
            this.btnPurchaseReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPurchaseReport.Click += new System.EventHandler(this.btnPurchaseReport_Click);
            // 
            // btnSalesDetailReport
            // 
            this.btnSalesDetailReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalesDetailReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSalesDetailReport.Enabled = false;
            this.btnSalesDetailReport.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSalesDetailReport.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSalesDetailReport.ImageKey = "NetByte Design Studio - 0673.png";
            this.btnSalesDetailReport.ImageList = this.imageList1;
            this.btnSalesDetailReport.Location = new System.Drawing.Point(135, 0);
            this.btnSalesDetailReport.Name = "btnSalesDetailReport";
            this.btnSalesDetailReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSalesDetailReport.Size = new System.Drawing.Size(173, 76);
            this.btnSalesDetailReport.SmallImageList = this.imageList1;
            this.btnSalesDetailReport.TabIndex = 61;
            this.btnSalesDetailReport.Text = "Sales Detail Report";
            this.btnSalesDetailReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalesDetailReport.Click += new System.EventHandler(this.btnSalesDetailReport_Click);
            // 
            // btnSaleReport
            // 
            this.btnSaleReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaleReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSaleReport.Enabled = false;
            this.btnSaleReport.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSaleReport.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaleReport.ImageKey = "1389181.png";
            this.btnSaleReport.ImageList = this.imageList1;
            this.btnSaleReport.Location = new System.Drawing.Point(0, 0);
            this.btnSaleReport.Name = "btnSaleReport";
            this.btnSaleReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSaleReport.Size = new System.Drawing.Size(135, 76);
            this.btnSaleReport.SmallImageList = this.imageList1;
            this.btnSaleReport.TabIndex = 58;
            this.btnSaleReport.Text = "Sales Report";
            this.btnSaleReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaleReport.Click += new System.EventHandler(this.btnSaleReport_Click);
            // 
            // lib_date_time
            // 
            this.lib_date_time.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lib_date_time.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_date_time.ForeColor = System.Drawing.Color.GreenYellow;
            this.lib_date_time.Location = new System.Drawing.Point(1099, 13);
            this.lib_date_time.Name = "lib_date_time";
            this.lib_date_time.Size = new System.Drawing.Size(132, 23);
            this.lib_date_time.TabIndex = 29;
            this.lib_date_time.Text = "                     ";
            this.lib_date_time.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.lblCurrentUser);
            this.panel2.Controls.Add(this.lib_date_time);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 1035);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1920, 45);
            this.panel2.TabIndex = 10;
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
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::Stock_System.Properties.Resources.Polaris_Logo5;
            this.pictureBox1.Location = new System.Drawing.Point(20, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // main_panel
            // 
            this.main_panel.BackgroundImage = global::Stock_System.Properties.Resources.Polaris_Logo1;
            this.main_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.main_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_panel.Location = new System.Drawing.Point(0, 0);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(1920, 1080);
            this.main_panel.TabIndex = 10;
            // 
            // ReportMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.main_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "ReportMDI";
            this.Text = "MDI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDI_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCashFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShortItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCustomerReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProductReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExpenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPurchaseDetailReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPOS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPurchaseReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalesDetailReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaleReport)).EndInit();
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
        private Telerik.WinControls.UI.RadButton btnPurchaseReport;
        private Telerik.WinControls.UI.RadButton btnSaleReport;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lib_date_time;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadButton btnExit;
        private System.Windows.Forms.Label lblCurrentUser;
        private Telerik.WinControls.UI.RadButton btnPOS;
        private Telerik.WinControls.UI.RadButton btnExpenses;
        private Telerik.WinControls.UI.RadButton btnSalesDetailReport;
        private Telerik.WinControls.UI.RadButton btnProductReport;
        private Telerik.WinControls.UI.RadButton btnCustomerReport;
        private Telerik.WinControls.UI.RadButton btnPurchaseDetailReport;
        private Telerik.WinControls.UI.RadButton btnShortItem;
        private Telerik.WinControls.UI.RadButton btnCashFlow;
    }
}