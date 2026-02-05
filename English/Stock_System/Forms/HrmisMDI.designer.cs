namespace Stock_System.Forms
{
    partial class HrmisMDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HrmisMDI));
            this.timr = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.main_panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExpense = new Telerik.WinControls.UI.RadButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnAdvanceSalary = new Telerik.WinControls.UI.RadButton();
            this.btnSaleReport = new Telerik.WinControls.UI.RadButton();
            this.btnPOS = new Telerik.WinControls.UI.RadButton();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExpense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdvanceSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaleReport)).BeginInit();
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
            this.main_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.main_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_panel.Location = new System.Drawing.Point(0, 0);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(1556, 884);
            this.main_panel.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnExpense);
            this.panel1.Controls.Add(this.btnAdvanceSalary);
            this.panel1.Controls.Add(this.btnSaleReport);
            this.panel1.Controls.Add(this.btnPOS);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1556, 76);
            this.panel1.TabIndex = 9;
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
            this.btnExpense.Location = new System.Drawing.Point(253, 0);
            this.btnExpense.Name = "btnExpense";
            this.btnExpense.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExpense.Size = new System.Drawing.Size(123, 76);
            this.btnExpense.SmallImageList = this.imageList1;
            this.btnExpense.TabIndex = 69;
            this.btnExpense.Text = "Payroll";
            this.btnExpense.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExpense.Click += new System.EventHandler(this.btnExpense_Click);
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
            // 
            // btnAdvanceSalary
            // 
            this.btnAdvanceSalary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdvanceSalary.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAdvanceSalary.Enabled = false;
            this.btnAdvanceSalary.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAdvanceSalary.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdvanceSalary.ImageKey = "supplier.png";
            this.btnAdvanceSalary.ImageList = this.imageList1;
            this.btnAdvanceSalary.Location = new System.Drawing.Point(112, 0);
            this.btnAdvanceSalary.Name = "btnAdvanceSalary";
            this.btnAdvanceSalary.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAdvanceSalary.Size = new System.Drawing.Size(141, 76);
            this.btnAdvanceSalary.SmallImageList = this.imageList1;
            this.btnAdvanceSalary.TabIndex = 70;
            this.btnAdvanceSalary.Text = "Advance Salary";
            this.btnAdvanceSalary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdvanceSalary.Click += new System.EventHandler(this.btnAdvanceSalary_Click);
            // 
            // btnSaleReport
            // 
            this.btnSaleReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaleReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSaleReport.Enabled = false;
            this.btnSaleReport.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSaleReport.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaleReport.ImageKey = "572711.png";
            this.btnSaleReport.ImageList = this.imageList1;
            this.btnSaleReport.Location = new System.Drawing.Point(0, 0);
            this.btnSaleReport.Name = "btnSaleReport";
            this.btnSaleReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSaleReport.Size = new System.Drawing.Size(112, 76);
            this.btnSaleReport.SmallImageList = this.imageList1;
            this.btnSaleReport.TabIndex = 61;
            this.btnSaleReport.Text = "Employee";
            this.btnSaleReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaleReport.Click += new System.EventHandler(this.btnSaleReport_Click_1);
            // 
            // btnPOS
            // 
            this.btnPOS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPOS.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPOS.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnPOS.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPOS.ImageKey = "Cancel_32x32.png";
            this.btnPOS.ImageList = this.imageList1;
            this.btnPOS.Location = new System.Drawing.Point(1424, 0);
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
            this.btnExit.Location = new System.Drawing.Point(1490, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExit.Size = new System.Drawing.Size(66, 76);
            this.btnExit.SmallImageList = this.imageList1;
            this.btnExit.TabIndex = 59;
            this.btnExit.Text = "Exit";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lblCurrentUser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 839);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1556, 45);
            this.panel2.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(29, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 38;
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
            // HrmisMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1556, 884);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.main_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "HrmisMDI";
            this.Text = "MDI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDI_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExpense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdvanceSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaleReport)).EndInit();
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
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadButton btnExit;
        private System.Windows.Forms.Label lblCurrentUser;
        private Telerik.WinControls.UI.RadButton btnPOS;
        private Telerik.WinControls.UI.RadButton btnExpense;
        private Telerik.WinControls.UI.RadButton btnSaleReport;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Telerik.WinControls.UI.RadButton btnAdvanceSalary;
    }
}