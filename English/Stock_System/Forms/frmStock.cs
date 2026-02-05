using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Stock_System.Class;

namespace Stock_System.Forms
{
    public partial class frmStock : Form
    {
        DataTable TempDt = new DataTable();
        Decimal TotalStockAmount = 0;
        Dbcommon obj = new Dbcommon();
        public frmStock()
        {
            InitializeComponent();
            Class.conclass.opecon();
        }
        private void frmStock_Load(object sender, EventArgs e)
        {

            lblStoreID.Text = conclass.StoreID;
       
            if (clsSession.LoginType == "Admin")
            {
            }
            fillstok();
            cmbSearchType.Text = "Search By Barcode";
        }
        private void fillstok()
        {
            try
            {
                lst_items.Items.Clear();
                DataTable dt = new DataTable();
                dt = Class.conclass.GetRecord(@"SELECT TOP (100) IMIS_VWProducts.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.ProductGenericName, IMIS_VWProducts.CategoryName, IMIS_VWProducts.SizeName, IMIS_VWProducts.PackingName, 
                  IMIS_VWProducts.ManufacturerName, IMIS_VWProducts.SalePrice, CONVERT(varchar(12), IMIS_tblStock.ExpiryDate, 106) AS ExpiryDate, IMIS_tblStock.BatchNo, IMIS_tblStock.Quantity, IMIS_tblStock.StockPrice, IMIS_tblStock.StoreID, 
                  ISNULL(IMIS_tblStock.Quantity, 0) * ISNULL(IMIS_tblStock.StockPrice, 0) AS Total, CASE WHEN ExpiryDate <= DATEADD(day, 30, getdate()) THEN 'Expired' ELSE 'Not Expired' END AS ExpCondation, IMIS_tblStock.ID
FROM     IMIS_VWProducts INNER JOIN
                  IMIS_tblStock ON IMIS_VWProducts.ProductCode = IMIS_tblStock.ProductCode
WHERE        IMIS_tblStock.StoreID = " + conclass.StoreID+" order by IMIS_tblStock.ProductCode desc");
                TempDt = dt;
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["ExpCondation"].ToString());
                    item.SubItems.Add(dr["ProductCode"].ToString());
                    item.SubItems.Add(dr["ProductName"].ToString());
                    item.SubItems.Add(dr["ProductGenericName"].ToString());
                    item.SubItems.Add(dr["CategoryName"].ToString());
                    item.SubItems.Add(dr["BatchNo"].ToString());
                    item.SubItems.Add(dr["ExpiryDate"].ToString());
                    item.SubItems.Add(dr["Quantity"].ToString());
                    item.SubItems.Add(dr["StockPrice"].ToString());
                    item.SubItems.Add(dr["Total"].ToString());
                    item.SubItems.Add(dr["SalePrice"].ToString());
                    item.SubItems.Add(dr["SizeName"].ToString());
                    item.SubItems.Add(dr["PackingName"].ToString());
                    item.SubItems.Add(dr["ManufacturerName"].ToString());
                    item.SubItems.Add(dr["ID"].ToString());
                    lst_items.Items.Add(item);
                }
                dt = Class.conclass.GetRecord("select isnull(sum(StockPrice*Quantity),0) as TotalAmount from IMIS_tblStock");
                if (dt.Rows.Count > 0)
                {
                    textBox1.Text =(Math.Round(Decimal.Parse(dt.Rows[0][0].ToString()),2)).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            
            }
        
        }
        private void txt_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            Class.conclass.ASCIn(e);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            TotalStockAmount = 0;
            if (cmbSearchType.Text == "Search By Product Name")
            {
                #region Search By Item Name
                try
                {
                    lst_items.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT        IMIS_VWProducts.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.ProductGenericName, IMIS_VWProducts.CategoryName, IMIS_VWProducts.SizeName, IMIS_VWProducts.PackingName, 
                         IMIS_VWProducts.ManufacturerName, IMIS_VWProducts.SalePrice,convert(varchar(12),IMIS_tblStock.ExpiryDate,106) as ExpiryDate, IMIS_tblStock.BatchNo, IMIS_tblStock.Quantity, IMIS_tblStock.StockPrice, IMIS_tblStock.StoreID,
isnull(Quantity,0)* isnull(StockPrice,0) as Total,
CASE WHEN ExpiryDate<= DATEADD(day,30,getdate()) THEN 'Expired' ELSE 'Not Expired' END AS ExpCondation, IMIS_tblStock.ID

FROM            IMIS_VWProducts INNER JOIN
                         IMIS_tblStock ON IMIS_VWProducts.ProductCode = IMIS_tblStock.ProductCode
WHERE   IMIS_tblStock.Quantity>0  and  ProductName like N'%" + txtSearchValue.Text + "%' order by IMIS_tblStock.ProductCode");
                    TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ExpCondation"].ToString());
                        item.SubItems.Add(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["ProductGenericName"].ToString());
                        item.SubItems.Add(dr["CategoryName"].ToString());
                        item.SubItems.Add(dr["BatchNo"].ToString());
                        item.SubItems.Add(dr["ExpiryDate"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["StockPrice"].ToString());
                        item.SubItems.Add(dr["Total"].ToString());
                        item.SubItems.Add(dr["SalePrice"].ToString());
                        item.SubItems.Add(dr["SizeName"].ToString());
                        item.SubItems.Add(dr["PackingName"].ToString());
                        item.SubItems.Add(dr["ManufacturerName"].ToString());
                        item.SubItems.Add(dr["ID"].ToString());
                        lst_items.Items.Add(item);
                    }
                    dt = Class.conclass.GetRecord("select isnull(sum(StockPrice*Quantity),0),isnull(sum(Quantity),0) as TotalAmount from IMIS_tblStock");
                    if (dt.Rows.Count > 0)
                    {
                        textBox1.Text = (Math.Round(Decimal.Parse(dt.Rows[0][0].ToString()), 2)).ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                #endregion
            }
            if (cmbSearchType.Text == "Search By Generic Name")
            {
                #region Search By Item Name
                try
                {
                    lst_items.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT        IMIS_VWProducts.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.ProductGenericName, IMIS_VWProducts.CategoryName, IMIS_VWProducts.SizeName, IMIS_VWProducts.PackingName, 
                         IMIS_VWProducts.ManufacturerName, IMIS_VWProducts.SalePrice,convert(varchar(12),IMIS_tblStock.ExpiryDate,106) as ExpiryDate, IMIS_tblStock.BatchNo, IMIS_tblStock.Quantity, IMIS_tblStock.StockPrice, IMIS_tblStock.StoreID,
isnull(Quantity,0)* isnull(StockPrice,0) as Total,
CASE WHEN ExpiryDate<= DATEADD(day,30,getdate()) THEN 'Expired' ELSE 'Not Expired' END AS ExpCondation, IMIS_tblStock.ID

FROM            IMIS_VWProducts INNER JOIN
                         IMIS_tblStock ON IMIS_VWProducts.ProductCode = IMIS_tblStock.ProductCode
WHERE      IMIS_tblStock.Quantity>0  and     ProductGenericName like N'%" + txtSearchValue.Text + "%' order by IMIS_tblStock.ProductCode");
                    TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ExpCondation"].ToString());
                        item.SubItems.Add(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["ProductGenericName"].ToString());
                        item.SubItems.Add(dr["CategoryName"].ToString());
                        item.SubItems.Add(dr["BatchNo"].ToString());
                        item.SubItems.Add(dr["ExpiryDate"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["StockPrice"].ToString());
                        item.SubItems.Add(dr["Total"].ToString());
                        item.SubItems.Add(dr["SalePrice"].ToString());
                        item.SubItems.Add(dr["SizeName"].ToString());
                        item.SubItems.Add(dr["PackingName"].ToString());
                        item.SubItems.Add(dr["ManufacturerName"].ToString());
                        item.SubItems.Add(dr["ID"].ToString());
                        lst_items.Items.Add(item);
                    }
                    dt = Class.conclass.GetRecord("select isnull(sum(StockPrice*Quantity),0),isnull(sum(Quantity),0) as TotalAmount from IMIS_tblStock");
                    if (dt.Rows.Count > 0)
                    {
                        textBox1.Text = (Math.Round(Decimal.Parse(dt.Rows[0][0].ToString()), 2)).ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                #endregion
            }
            else if (cmbSearchType.Text == "Search By Barcode")
            {
                #region Search By Item Name
                try
                {
                    lst_items.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT        IMIS_VWProducts.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.ProductGenericName, IMIS_VWProducts.CategoryName, IMIS_VWProducts.SizeName, IMIS_VWProducts.PackingName, 
                         IMIS_VWProducts.ManufacturerName, IMIS_VWProducts.SalePrice,convert(varchar(12),IMIS_tblStock.ExpiryDate,106) as ExpiryDate, IMIS_tblStock.BatchNo, IMIS_tblStock.Quantity, IMIS_tblStock.StockPrice, IMIS_tblStock.StoreID,
isnull(Quantity,0)* isnull(StockPrice,0) as Total,CASE WHEN ExpiryDate<= DATEADD(day,30,getdate()) THEN 'Expired' ELSE 'Not Expired' END AS ExpCondation, IMIS_tblStock.ID
FROM            IMIS_VWProducts INNER JOIN
                         IMIS_tblStock ON IMIS_VWProducts.ProductCode = IMIS_tblStock.ProductCode
WHERE    IMIS_tblStock.Quantity>0  and     IMIS_VWProducts.ProductBarCode='" + txtSearchValue.Text + "' order by IMIS_tblStock.ProductCode");
                    TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ExpCondation"].ToString());
                        item.SubItems.Add(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["ProductGenericName"].ToString());
                        item.SubItems.Add(dr["CategoryName"].ToString());
                        item.SubItems.Add(dr["BatchNo"].ToString());
                        item.SubItems.Add(dr["ExpiryDate"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["StockPrice"].ToString());
                        item.SubItems.Add(dr["Total"].ToString());
                        item.SubItems.Add(dr["SalePrice"].ToString());
                        item.SubItems.Add(dr["SizeName"].ToString());
                        item.SubItems.Add(dr["PackingName"].ToString());
                        item.SubItems.Add(dr["ManufacturerName"].ToString());
                        item.SubItems.Add(dr["ID"].ToString());
                        lst_items.Items.Add(item);
                    }
                    dt = Class.conclass.GetRecord("select isnull(sum(StockPrice*Quantity),0),isnull(sum(Quantity),0) as TotalAmount from IMIS_tblStock");
                    if (dt.Rows.Count > 0)
                    {
                        textBox1.Text = (Math.Round(Decimal.Parse(dt.Rows[0][0].ToString()), 2)).ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                #endregion
            }

            else if (cmbSearchType.Text == "Search By Expiry Date")
            {
                #region Search By Item Name
                try
                {
                    lst_items.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT        IMIS_VWProducts.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.ProductGenericName, IMIS_VWProducts.CategoryName, IMIS_VWProducts.SizeName, IMIS_VWProducts.PackingName, 
                         IMIS_VWProducts.ManufacturerName, IMIS_VWProducts.SalePrice,convert(varchar(12),IMIS_tblStock.ExpiryDate,106) as ExpiryDate, IMIS_tblStock.BatchNo, IMIS_tblStock.Quantity, IMIS_tblStock.StockPrice, IMIS_tblStock.StoreID,
isnull(Quantity,0)* isnull(StockPrice,0) as Total,
CASE WHEN ExpiryDate<= DATEADD(day,30,getdate()) THEN 'Expired' ELSE 'Not Expired' END AS ExpCondation, IMIS_tblStock.ID
FROM            IMIS_VWProducts INNER JOIN
                         IMIS_tblStock ON IMIS_VWProducts.ProductCode = IMIS_tblStock.ProductCode
WHERE    IMIS_tblStock.Quantity>0  and   ExpiryDate > getdate() and ExpiryDate <= DATEADD(day," + txtSearchValue.Text + ",getdate()) order by IMIS_tblStock.ProductCode");
                    TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ExpCondation"].ToString());
                        item.SubItems.Add(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["ProductGenericName"].ToString());
                        item.SubItems.Add(dr["CategoryName"].ToString());
                        item.SubItems.Add(dr["BatchNo"].ToString());
                        item.SubItems.Add(dr["ExpiryDate"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["StockPrice"].ToString());
                        item.SubItems.Add(dr["Total"].ToString());
                        item.SubItems.Add(dr["SalePrice"].ToString());
                        item.SubItems.Add(dr["SizeName"].ToString());
                        item.SubItems.Add(dr["PackingName"].ToString());
                        item.SubItems.Add(dr["ManufacturerName"].ToString());
                        item.SubItems.Add(dr["ID"].ToString());
                        lst_items.Items.Add(item);
                    }
                    dt = Class.conclass.GetRecord("select isnull(sum(StockPrice*Quantity),0),isnull(sum(Quantity),0) as TotalAmount from IMIS_tblStock where  IMIS_tblStock.StoreID = " + conclass.StoreID + " and IMIS_tblStock.Quantity>0 and ExpiryDate > getdate() and ExpiryDate <= DATEADD(day," + txtSearchValue.Text + ",getdate())");
                    if (dt.Rows.Count > 0)
                    {
                        textBox1.Text = (Math.Round(Decimal.Parse(dt.Rows[0][0].ToString()), 2)).ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
            }

            else if (cmbSearchType.Text == "All Stock")
            {
                #region Search By Item Name
                try
                {
                    lst_items.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT        IMIS_VWProducts.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.ProductGenericName, IMIS_VWProducts.CategoryName, IMIS_VWProducts.SizeName, IMIS_VWProducts.PackingName, 
                         IMIS_VWProducts.ManufacturerName, IMIS_VWProducts.SalePrice,convert(varchar(12),IMIS_tblStock.ExpiryDate,106) as ExpiryDate, IMIS_tblStock.BatchNo, IMIS_tblStock.Quantity, IMIS_tblStock.StockPrice, IMIS_tblStock.StoreID,
isnull(Quantity,0)* isnull(StockPrice,0) as Total,CASE WHEN ExpiryDate<= DATEADD(day,30,getdate()) THEN 'Expired' ELSE 'Not Expired' END AS ExpCondation, IMIS_tblStock.ID
FROM            IMIS_VWProducts INNER JOIN
                         IMIS_tblStock ON IMIS_VWProducts.ProductCode = IMIS_tblStock.ProductCode  where IMIS_tblStock.Quantity>0  order by IMIS_tblStock.ProductCode");
                    TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ExpCondation"].ToString());
                        item.SubItems.Add(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["ProductGenericName"].ToString());
                        item.SubItems.Add(dr["CategoryName"].ToString());
                        item.SubItems.Add(dr["BatchNo"].ToString());
                        item.SubItems.Add(dr["ExpiryDate"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["StockPrice"].ToString());
                        item.SubItems.Add(dr["Total"].ToString());
                        item.SubItems.Add(dr["SalePrice"].ToString());
                        item.SubItems.Add(dr["SizeName"].ToString());
                        item.SubItems.Add(dr["PackingName"].ToString());
                        item.SubItems.Add(dr["ManufacturerName"].ToString());
                        item.SubItems.Add(dr["ID"].ToString());
                        lst_items.Items.Add(item);
                    }
                    dt = Class.conclass.GetRecord("select isnull(sum(StockPrice*Quantity),0),isnull(sum(Quantity),0) as TotalAmount from IMIS_tblStock");
                    if (dt.Rows.Count > 0)
                    {
                        textBox1.Text = (Math.Round(Decimal.Parse(dt.Rows[0][0].ToString()), 2)).ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
            }
        }
        private Decimal Get_Total_Stock(string Query)
        {
            Decimal Total_Stock_Amount = 0;
            DataTable dt = conclass.GetRecord(Query);
            if (dt.Rows.Count > 0)
            {
                Total_Stock_Amount =Math.Round(Convert.ToDecimal(dt.Rows[0]["Total"].ToString()),2);
            }
            return Total_Stock_Amount;
        }
        private void AddProductByBarCode(string Code)
        {
            try
            {
                lst_items.Items.Clear();
                DataTable dt = new DataTable();
                dt = Class.conclass.GetRecord(@"SELECT        IMIS_VWProducts.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.ProductGenericName, IMIS_VWProducts.CategoryName, IMIS_VWProducts.SizeName, IMIS_VWProducts.PackingName, 
                         IMIS_VWProducts.ManufacturerName, IMIS_VWProducts.SalePrice,convert(varchar(12),IMIS_tblStock.ExpiryDate,106) as ExpiryDate, IMIS_tblStock.BatchNo, IMIS_tblStock.Quantity, IMIS_tblStock.StockPrice, IMIS_tblStock.StoreID,
isnull(Quantity,0)* isnull(StockPrice,0) as Total,
CASE WHEN ExpiryDate<= DATEADD(day,30,getdate()) THEN 'Expired' ELSE 'Not Expired' END AS ExpCondation, IMIS_tblStock.ID

FROM            IMIS_VWProducts INNER JOIN
                         IMIS_tblStock ON IMIS_VWProducts.ProductCode = IMIS_tblStock.ProductCode
WHERE        IMIS_tblStock.StoreID = " + lblStoreID.Text + " and IMIS_VWProducts.ProductBarCode='"+Code+"' order by IMIS_tblStock.ProductCode");
                TempDt = dt;
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["ExpCondation"].ToString());
                    item.SubItems.Add(dr["ProductCode"].ToString());
                    item.SubItems.Add(dr["ProductName"].ToString());
                    item.SubItems.Add(dr["ProductGenericName"].ToString());
                    item.SubItems.Add(dr["CategoryName"].ToString());
                    item.SubItems.Add(dr["BatchNo"].ToString());
                    item.SubItems.Add(dr["ExpiryDate"].ToString());
                    item.SubItems.Add(dr["Quantity"].ToString());
                    item.SubItems.Add(dr["StockPrice"].ToString());
                    item.SubItems.Add(dr["Total"].ToString());
                    item.SubItems.Add(dr["SalePrice"].ToString());
                    item.SubItems.Add(dr["SizeName"].ToString());
                    item.SubItems.Add(dr["PackingName"].ToString());
                    item.SubItems.Add(dr["ManufacturerName"].ToString());
                    item.SubItems.Add(dr["ID"].ToString());
                    lst_items.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
           
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlProduct.SendToBack();
            pnlProduct.Visible = false;

        }
        private void cmbSearchType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "Search By Expiry Date")
            {
                lblValueType.Text = "No.Of Days For Expiry";
                txtSearchValue.Enabled = true;
                txtSearchValue.Focus();
                
            }
            else if (cmbSearchType.Text == "All Stock")
            {
                lblValueType.Text = "All Stock";
                txtSearchValue.Enabled = false;
            }
            else if (cmbSearchType.Text == "Search By Generic Name")
            {
                lblValueType.Text = "Search By Generic Name";
                txtSearchValue.Enabled = true;
                txtSearchValue.Focus();
            }
            else if (cmbSearchType.Text == "Search By Barcode")
            {
                lblValueType.Text = "Search By Barcode";
                txtSearchValue.Enabled = true;
                txtSearchValue.Focus();
            }
            else
            {
                lblValueType.Text = "Product Name For Search";
                txtSearchValue.Enabled = true;
                txtSearchValue.Focus();
            }
            
           
        }
        private void btnStockReport_Click(object sender, EventArgs e)
        {
            Reports.rptStockReport obj = new Stock_System.Reports.rptStockReport();
            obj.SetDataSource(TempDt);
            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;
            //frm2.crystalReportViewer1.PrintReport();
            frm2.ShowDialog();
        }
        private void lst_Item_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            string Value = e.Item.Text;
            if (Value == "Expired")
            {
                e.Item.BackColor = Color.Red;
                e.Item.ForeColor = Color.Yellow;
                e.Item.UseItemStyleForSubItems = true;
            }
        }
        private void listView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }
        private void btnStockSummaryReport_Click(object sender, EventArgs e)
        {

            DataTable dt = conclass.GetRecord(@"select * from VW_StockSummaryReport order by productcode");
            Reports.rptStockSummaryReport obj = new Stock_System.Reports.rptStockSummaryReport();
            obj.SetDataSource(dt);
            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;
            //frm2.crystalReportViewer1.PrintReport();
            frm2.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
            if (conclass.IsInRole(conclass.UserName, "Admin"))
            {
                string Id = lst_items.SelectedItems[0].SubItems[14].Text;
                txtQty.Tag = Id.ToString();
               
                lblLastQty.Tag = lst_items.SelectedItems[0].SubItems[7].Text;
                txtQty.Text = lst_items.SelectedItems[0].SubItems[7].Text;
                txtStockPrice.Text = lst_items.SelectedItems[0].SubItems[8].Text;
                lblLastPrice.Tag = lst_items.SelectedItems[0].SubItems[8].Text;
                txtStockPrice.Tag = lst_items.SelectedItems[0].SubItems[1].Text;
                btnChange.Enabled = true;
                pnlQty.Visible = true;
              
                pnlQty.BringToFront();
            }
            else
            {
                MessageBox.Show("You are not authorized user for this option");
            }
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            long ProductStatementID = conclass.nextid("ProductStatement", "ID");

            float LastQty1 = float.Parse(lblLastQty.Tag.ToString());
            float LastPrice1 = float.Parse(lblLastPrice.Tag.ToString());
            float NewQty1 = float.Parse(txtQty.Text);
            float NewPrice1 = float.Parse(txtStockPrice.Text);

            bool isQtyChanged = LastQty1 != NewQty1;
            bool isPriceChanged = LastPrice1 != NewPrice1;

            // Only proceed if there is any change
            if (isQtyChanged || isPriceChanged)
            {
                using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        float LastQty = float.Parse(lblLastQty.Tag.ToString());
                        float NewQty = float.Parse(txtQty.Text);
                        float Difference = NewQty - LastQty;
                        float TransactionValue = Math.Abs(Difference);
                        string TransactionStatus = "";
                        string Remarks = " Last Price: " + lblLastPrice.Tag.ToString() + " Last Qty: " + lblLastQty.Tag.ToString();

                        // 1. Insert into Stock History
                        SqlCommand cmd1 = new SqlCommand(@"
            INSERT INTO IMIS_tblStockHistory(ID, ProductCode, Quantity, NewQuantity, AveragePrice, StoreID, SystemDate, UserID)
            SELECT ID, ProductCode, Quantity, @NewQty, StockPrice, StoreID, GETDATE(), @UserID
            FROM IMIS_tblStock WHERE ID = @StockID", conn, transaction);
                        cmd1.Parameters.AddWithValue("@NewQty", NewQty);
                        cmd1.Parameters.AddWithValue("@UserID", conclass.User_ID);
                        cmd1.Parameters.AddWithValue("@StockID", txtQty.Tag.ToString());
                        cmd1.ExecuteNonQuery();

                        // 2. Update IMIS_tblStock (quantity, price, remarks)
                        SqlCommand cmd2 = new SqlCommand(@"
            UPDATE IMIS_tblStock
            SET Quantity = @NewQty,
                StockPrice = @StockPrice,
                lastUpdatedBy = @UserID,
                Remarks = ISNULL(Remarks, '') + @Remarks
            WHERE ID = @StockID", conn, transaction);
                        cmd2.Parameters.AddWithValue("@NewQty", NewQty);
                        cmd2.Parameters.AddWithValue("@StockPrice", float.Parse(txtStockPrice.Text));
                        cmd2.Parameters.AddWithValue("@UserID", conclass.User_ID);
                        cmd2.Parameters.AddWithValue("@Remarks", Remarks);
                        cmd2.Parameters.AddWithValue("@StockID", txtQty.Tag.ToString());
                        cmd2.ExecuteNonQuery();

                        // 3. Update global stock price by product code
                        SqlCommand cmd3 = new SqlCommand(@"
            UPDATE IMIS_tblStock
            SET StockPrice = @StockPrice
            WHERE ProductCode = @ProductCode", conn, transaction);
                        cmd3.Parameters.AddWithValue("@StockPrice", float.Parse(txtStockPrice.Text));
                        cmd3.Parameters.AddWithValue("@ProductCode", txtStockPrice.Tag.ToString());
                        cmd3.ExecuteNonQuery();

                        // 4. Insert into ProductStatement if qty changed
                        if (Difference != 0)
                        {
                            TransactionStatus = Difference > 0 ? "Cr" : "Dr";

                            SqlCommand cmd4 = new SqlCommand(@"
                INSERT INTO ProductStatement
                (ID,ProductID, ReferenceType, ReferenceNumber, Date, Particulars, Debit, Credit)
                VALUES (@ProductStatementID,@ProductID, @RefType, @RefNo, @Date, @Particulars, @Debit, @Credit)", conn, transaction);
                            cmd4.Parameters.AddWithValue("@ProductID", txtStockPrice.Tag.ToString());
                            cmd4.Parameters.AddWithValue("@RefType", "ManualAdjust");
                            cmd4.Parameters.AddWithValue("@RefNo", "Stock Update");
                            cmd4.Parameters.AddWithValue("@Date", DateTime.Now);
                            cmd4.Parameters.AddWithValue("@Particulars", "Manual adjustment of stock");
                            cmd4.Parameters.AddWithValue("@ProductStatementID", ProductStatementID);

                            if (TransactionStatus == "Cr")
                            {
                                cmd4.Parameters.AddWithValue("@Debit", 0);
                                cmd4.Parameters.AddWithValue("@Credit", TransactionValue);
                            }
                            else
                            {
                                cmd4.Parameters.AddWithValue("@Debit", TransactionValue);
                                cmd4.Parameters.AddWithValue("@Credit", 0);
                            }

                            cmd4.ExecuteNonQuery();
                        }

                        // Commit transaction
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error during stock update: " + ex.Message);
                    }
                }
                MessageBox.Show("Product Chanaged Successfully..");
            }
            else
            {
                MessageBox.Show("No changes occurred");
            }
            
        }
        private void btnClose1_Click(object sender, EventArgs e)
        {
            pnlQty.Visible = false;
            pnlQty.SendToBack();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string Id = lst_items.SelectedItems[0].SubItems[0].Text;
            try
            {
                lstProductInStore.Items.Clear();
                DataTable dt = new DataTable();
                dt = Class.conclass.GetRecord(@"SELECT IMIS_tblStock.ProductCode, IMIS_VWProducts.ProductName, IMIS_tblStock.Quantity, IMIS_tblStore.StoreName
FROM            IMIS_tblStock INNER JOIN
                         IMIS_tblStore ON IMIS_tblStock.StoreID = IMIS_tblStore.StoreID INNER JOIN
                         IMIS_VWProducts ON IMIS_tblStock.ProductCode = IMIS_VWProducts.ProductCode
WHERE        (IMIS_tblStock.ProductCode = '" + Id + "')");
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                    item.SubItems.Add(dr["ProductName"].ToString());
                    item.SubItems.Add(dr["Quantity"].ToString());
                    item.SubItems.Add(dr["StoreName"].ToString());
                    lstProductInStore.Items.Add(item);
                }
                pnlProduct.BringToFront();
                pnlProduct.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void damageOrLostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conclass.IsInRole(conclass.UserName, "Admin"))
            {
                txtItemCode.Text = lst_items.SelectedItems[0].SubItems[1].Text;
                txtItemCode.Tag = lst_items.SelectedItems[0].SubItems[14].Text;
                txtItemName.Text = lst_items.SelectedItems[0].SubItems[2].Text;
                // to store actual stock price
                txtItemName.Tag = lst_items.SelectedItems[0].SubItems[8].Text;

                // to store qty
                txtQtyDamageLost.Text = lst_items.SelectedItems[0].SubItems[7].Text;
                txtQtyDamageLost.Tag = lst_items.SelectedItems[0].SubItems[7].Text;

                //to store Expiry date
                txtRemarksDamageLost.Tag = lst_items.SelectedItems[0].SubItems[6].Text;
                txtRemarksDamageLost.Text = "";
                cmbStatus.Text = "Expired";
                dtExpiredDate.Value = DateTime.Parse(lst_items.SelectedItems[0].SubItems[6].Text);

                dtExpiredDate.Visible = true;
                pnlDamageOrLost.Visible = true;
                pnlDamageOrLost.BringToFront();
            }
            else
            {
                MessageBox.Show("You are not authorized user for this option");
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatus.Text == "Expired")
            {
                dtExpiredDate.Visible = true;
                dtExpiredDate.Value = DateTime.Parse(txtRemarksDamageLost.Tag.ToString());
            }
            else
                dtExpiredDate.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlDamageOrLost.Visible = false;
            pnlDamageOrLost.SendToBack();
        }

        private void btnDamagLost_Click(object sender, EventArgs e)
        {
            float Quantity = 0;
            float Price = 0;
            Price = float.Parse(txtItemName.Tag.ToString() == "" ? "0" : txtItemName.Tag.ToString());
            Quantity = float.Parse(txtQtyDamageLost.Text == "" ? "0" : txtQtyDamageLost.Text);
            if (Quantity > 0)
            {
                Int64 ID = conclass.nextid("FMIS_tblExpenseDetail", "ID");
                long ProductStatementID = conclass.nextid("ProductStatement", "ID");
                string CurrencyID = "";
                DataTable dtCurrencyID = conclass.GetRecord("select CurrencyID from Lookup_tblCurrency where IsBaseCurrency='Yes'");
                CurrencyID = dtCurrencyID.Rows[0]["CurrencyID"].ToString();
                string ExpenseDetail = "";
                #region Expense Head ID
                string ExpenseHeadID = "";
                if (cmbStatus.Text == "Expired")
                {
                    DataTable dt = conclass.GetRecord("select top 1 ExpenseHeadID from FMIS_tblExpenseHead where ExpenseHeadName='Product Expired'");
                    if (dt.Rows.Count > 0)
                    {
                        ExpenseHeadID = dt.Rows[0]["ExpenseHeadID"].ToString();
                        ExpenseDetail = txtItemName.Text + "  is expired";
                    }
                }
                else if (cmbStatus.Text == "Damage")
                {
                    DataTable dt = conclass.GetRecord("select top 1 ExpenseHeadID from FMIS_tblExpenseHead where ExpenseHeadName='Product Damaged'");
                    if (dt.Rows.Count > 0)
                    {
                        ExpenseHeadID = dt.Rows[0]["ExpenseHeadID"].ToString();
                        ExpenseDetail = txtItemName.Text + "  is Damaged";
                    }
                }
                else if (cmbStatus.Text == "Lost")
                {
                    DataTable dt = conclass.GetRecord("select top 1 ExpenseHeadID from FMIS_tblExpenseHead where ExpenseHeadName='Product Lost'");
                    if (dt.Rows.Count > 0)
                    {
                        ExpenseHeadID = dt.Rows[0]["ExpenseHeadID"].ToString();
                        ExpenseDetail = txtItemName.Text + "  is Lost";
                    }
                }
                #endregion
                float QtyAtStock = 0;
                float QtyDamage = 0;

                QtyAtStock = float.Parse(txtQtyDamageLost.Tag.ToString());
                QtyDamage = float.Parse(txtQtyDamageLost.Text);

                if (QtyDamage > QtyAtStock)
                {
                    MessageBox.Show("The Damage or lost quantity is more than the actual stock quantity");
                    return;
                }
                obj.con.Open();
                SqlTransaction tran = obj.con.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = tran;
                cmd.Connection = obj.con;
                try
                {
                    string ExpiredDate = "1/1/1900";
                    if (cmbStatus.Text == "Expired")
                        ExpiredDate = dtExpiredDate.Value.ToString("MM/dd/yyyy");
                    cmd.CommandText = @"insert into IMIS_tblDamageOrLost(ProductCode, ExpiredDate, Quantity, Status, Remarks,StoreID, UserID) values('" + txtItemCode.Text + "', '" + ExpiredDate + "', " + txtQtyDamageLost.Text + ", '" + cmbStatus.Text + "', N'" + txtRemarksDamageLost.Text + "'," + conclass.StoreID + ", N'" + conclass.User_ID + "')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"update IMIS_tblStock set Quantity=Quantity-" + txtQtyDamageLost.Text + " where  ID=" + txtItemCode.Tag.ToString();
                    cmd.ExecuteNonQuery();
                    string Query1 = @"insert into FMIS_tblExpenseDetail(ID,ExpenseHeadID, ExpenseDetail, CurrencyID, ExpenseAmount, ExchangeRate, BasCurrencyAmount, StoreID, UserID) values(" + ID + "," + ExpenseHeadID + ", N'" + ExpenseDetail + "', " + CurrencyID + ", " + Math.Round((Quantity * Price), 2) + ", 1, " + Math.Round((Quantity * Price), 2) + ", " + conclass.StoreID + ", N'" + conclass.User_ID + "')";
                    cmd.CommandText = Query1;
                    cmd.ExecuteNonQuery();

                    #region Product Statement
                    string StatementDescription = cmbStatus.Text + ": " + txtRemarksDamageLost.Text;
                    cmd.CommandText = @"insert into ProductStatement(ID, ProductID, ReferenceType, Particulars, Debit, Credit, UserID) 
                    values(" + ProductStatementID + ", '" + txtItemCode.Text + "','" + cmbStatus.Text + "' ,  N'" + StatementDescription + "'," + Quantity + ",0,N'" + conclass.User_ID + "')";
                    cmd.ExecuteNonQuery();
                    #endregion


                    tran.Commit();
                    MessageBox.Show("Record Saved Successfully..");
                    fillstok();
                }
                catch (SqlException Sexp)
                {
                    tran.Rollback();
                    obj.con.Close();
                    MessageBox.Show(Sexp.InnerException.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    obj.con.Close();
                }
                finally
                {
                    obj.con.Close();
                }
            }
        }

        private void btnCloseExp_Click(object sender, EventArgs e)
        {
            pnlExpiryUpdate.Visible = false;
            pnlExpiryUpdate.SendToBack();
        }

        private void changeExpiryDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conclass.IsInRole(conclass.UserName, "Admin"))
            {
                txtDurgStockID.Text = lst_items.SelectedItems[0].SubItems[14].Text;
                txtDurgName.Text = lst_items.SelectedItems[0].SubItems[2].Text;
                txtDurgCurrentExpDate.Text = lst_items.SelectedItems[0].SubItems[6].Text;
                pnlExpiryUpdate.Visible = true;
                pnlExpiryUpdate.BringToFront();
            }
        }
        private void btnUpdateExpiryDate_Click(object sender, EventArgs e)
        {
            string Remarks = "Expiry Date is Chanage";
            string ExpiryDate = DateTime.Parse("01/" + txtNewExpDate.Text).ToString("dd/MM/yyyy");
            conclass.ExecuteQuery(@"insert into IMIS_tblStockHistory(ID, ProductCode, Quantity, AveragePrice, StoreID, SystemDate, UserID,ExpiryDate,Remarks)  SELECT ID, ProductCode, Quantity, StockPrice, StoreID,getdate(),N'" + conclass.User_ID + "',ExpiryDate,N'" + Remarks + "' FROM IMIS_tblStock where ID='" + txtDurgStockID.Text + "'");
            conclass.ExecuteQuery(@"Update IMIS_tblStock set ExpiryDate='" + ExpiryDate + "' where  ID=" + txtDurgStockID.Text + "");
            btnChange.Enabled = false;
            MessageBox.Show("Expiry Date Chanaged Successfully..");
            pnlExpiryUpdate.Visible = false;
            pnlExpiryUpdate.SendToBack();
        }

        private void txtSearchValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(null, null);
        }
    }
}
