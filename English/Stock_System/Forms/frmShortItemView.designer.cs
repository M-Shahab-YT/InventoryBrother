namespace Stock_System.Forms
{
    partial class frmShortItemView
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
            this.label13 = new System.Windows.Forms.Label();
            this.gpStock = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.btnViewReport = new Telerik.WinControls.UI.RadButton();
            this.btnPrintReport = new Telerik.WinControls.UI.RadButton();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lst_items = new System.Windows.Forms.ListView();
            this.itemeid = new System.Windows.Forms.ColumnHeader();
            this.itemName = new System.Windows.Forms.ColumnHeader();
            this.GroupName = new System.Windows.Forms.ColumnHeader();
            this.CategoryName = new System.Windows.Forms.ColumnHeader();
            this.Brand = new System.Windows.Forms.ColumnHeader();
            this.MINIMUMQUANTITY = new System.Windows.Forms.ColumnHeader();
            this.qty = new System.Windows.Forms.ColumnHeader();
            this.gpStock.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintReport)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Orange;
            this.label13.Location = new System.Drawing.Point(33, 123);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(263, 25);
            this.label13.TabIndex = 155;
            this.label13.Text = "SHORT STOCK\'S ITEMS";
            // 
            // gpStock
            // 
            this.gpStock.Controls.Add(this.panel1);
            this.gpStock.Controls.Add(this.lst_items);
            this.gpStock.Location = new System.Drawing.Point(31, 151);
            this.gpStock.Name = "gpStock";
            this.gpStock.Size = new System.Drawing.Size(1858, 858);
            this.gpStock.TabIndex = 154;
            this.gpStock.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cmbSearchType);
            this.panel1.Controls.Add(this.btnViewReport);
            this.panel1.Controls.Add(this.btnPrintReport);
            this.panel1.Controls.Add(this.txtSearchValue);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Location = new System.Drawing.Point(4, 779);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1850, 71);
            this.panel1.TabIndex = 152;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Indigo;
            this.label10.Location = new System.Drawing.Point(14, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 16);
            this.label10.TabIndex = 159;
            this.label10.Text = "Search Type:";
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchType.FormattingEnabled = true;
            this.cmbSearchType.Items.AddRange(new object[] {
            "All Stock",
            "Search By Product Name"});
            this.cmbSearchType.Location = new System.Drawing.Point(128, 21);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(246, 28);
            this.cmbSearchType.TabIndex = 159;
            this.cmbSearchType.SelectionChangeCommitted += new System.EventHandler(this.cmbSearchType_SelectionChangeCommitted);
            // 
            // btnViewReport
            // 
            this.btnViewReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnViewReport.Location = new System.Drawing.Point(746, 13);
            this.btnViewReport.Name = "btnViewReport";
            // 
            // 
            // 
            this.btnViewReport.RootElement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnViewReport.Size = new System.Drawing.Size(97, 44);
            this.btnViewReport.TabIndex = 1667;
            this.btnViewReport.Text = "View";
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnViewReport.GetChildAt(0))).Text = "View";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnViewReport.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnViewReport.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnViewReport.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnViewReport.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrintReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPrintReport.Location = new System.Drawing.Point(845, 13);
            this.btnPrintReport.Name = "btnPrintReport";
            // 
            // 
            // 
            this.btnPrintReport.RootElement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPrintReport.Size = new System.Drawing.Size(97, 44);
            this.btnPrintReport.TabIndex = 1613;
            this.btnPrintReport.Text = "Report";
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnPrintReport.GetChildAt(0))).Text = "Report";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnPrintReport.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnPrintReport.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnPrintReport.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnPrintReport.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchValue.Location = new System.Drawing.Point(480, 20);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(248, 31);
            this.txtSearchValue.TabIndex = 12;
            this.txtSearchValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchValue_KeyDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Indigo;
            this.label17.Location = new System.Drawing.Point(391, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 16);
            this.label17.TabIndex = 13;
            this.label17.Text = "Search Value";
            // 
            // lst_items
            // 
            this.lst_items.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.itemeid,
            this.itemName,
            this.GroupName,
            this.CategoryName,
            this.Brand,
            this.MINIMUMQUANTITY,
            this.qty});
            this.lst_items.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_items.FullRowSelect = true;
            this.lst_items.GridLines = true;
            this.lst_items.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lst_items.Location = new System.Drawing.Point(3, 9);
            this.lst_items.Name = "lst_items";
            this.lst_items.Size = new System.Drawing.Size(1849, 764);
            this.lst_items.TabIndex = 146;
            this.lst_items.UseCompatibleStateImageBehavior = false;
            this.lst_items.View = System.Windows.Forms.View.Details;
            // 
            // itemeid
            // 
            this.itemeid.Text = "ITEM CODE";
            this.itemeid.Width = 200;
            // 
            // itemName
            // 
            this.itemName.Text = "ITEM NAME";
            this.itemName.Width = 550;
            // 
            // GroupName
            // 
            this.GroupName.Text = "GROUP";
            this.GroupName.Width = 200;
            // 
            // CategoryName
            // 
            this.CategoryName.Text = "CATEGORY";
            this.CategoryName.Width = 200;
            // 
            // Brand
            // 
            this.Brand.Text = "ORIGIN";
            this.Brand.Width = 200;
            // 
            // MINIMUMQUANTITY
            // 
            this.MINIMUMQUANTITY.Text = "MINIMUM QUANTITY";
            this.MINIMUMQUANTITY.Width = 200;
            // 
            // qty
            // 
            this.qty.Text = "QUANTITY AVAILABLE";
            this.qty.Width = 200;
            // 
            // frmShortItemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.gpStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShortItemView";
            this.Text = "Short Item";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShortItemView_Load);
            this.gpStock.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox gpStock;
        private System.Windows.Forms.ListView lst_items;
        private System.Windows.Forms.ColumnHeader itemeid;
        private System.Windows.Forms.ColumnHeader itemName;
        private System.Windows.Forms.ColumnHeader GroupName;
        private System.Windows.Forms.ColumnHeader CategoryName;
        private System.Windows.Forms.ColumnHeader Brand;
        private System.Windows.Forms.ColumnHeader qty;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbSearchType;
        private Telerik.WinControls.UI.RadButton btnViewReport;
        private Telerik.WinControls.UI.RadButton btnPrintReport;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ColumnHeader MINIMUMQUANTITY;
    }
}