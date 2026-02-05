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
    public partial class frmShortItemView : Form
    {
        DataTable TempDt = new DataTable();
        public frmShortItemView()
        {
            InitializeComponent();
        }

        private void frmShortItemView_Load(object sender, EventArgs e)
        {
            fillstok();
        }
        private void fillstok()
        {
            try
            {
                lst_items.Items.Clear();
                DataTable dt = new DataTable();
                dt = Class.conclass.GetRecord(@"SELECT 
    S.ProductCode, 
    P.ProductName + ' ,' + P.ColorName + ' ,' + P.SizeName AS ProductName,
    P.ProductBarCode, 
    P.GroupName, 
    P.CategoryName, 
    P.ProductOriginName, 
    P.ColorShortName, 
    P.SizeShortName, 
    P.SalePrice, 
    ROUND(SUM(S.Quantity), 2) AS Quantity, 
    ROUND(AVG(S.StockPrice), 2) AS AveragePrice, -- Or use MAX or another logic
    NULL AS StoreID, -- Multiple stores, so omit or use logic like MAX(StoreID)
    ROUND(SUM(S.Quantity * S.StockPrice), 2) AS TOTAL,
    P.MinimumStockQty AS MinimumQuantity
FROM 
    IMIS_tblStock S
INNER JOIN 
    IMIS_VWProducts P ON P.ProductCode = S.ProductCode
GROUP BY 
    S.ProductCode, 
    P.ProductName, 
    P.ColorName, 
    P.SizeName, 
    P.ProductBarCode, 
    P.GroupName, 
    P.CategoryName, 
    P.ProductOriginName, 
    P.ColorShortName, 
    P.SizeShortName, 
    P.SalePrice,
    P.MinimumStockQty
HAVING 
    SUM(S.Quantity) < P.MinimumStockQty
");
                TempDt = dt;
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                    item.SubItems.Add(dr["ProductName"].ToString());
                    item.SubItems.Add(dr["GroupName"].ToString());
                    item.SubItems.Add(dr["CategoryName"].ToString());
                    item.SubItems.Add(dr["ProductOriginName"].ToString());
                    item.SubItems.Add(dr["MinimumQuantity"].ToString());
                    item.SubItems.Add(dr["Quantity"].ToString());
                    lst_items.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbSearchType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "All Stock")
            {
                txtSearchValue.Enabled = false;

            }
            else
            {
                txtSearchValue.Enabled = true;
                txtSearchValue.Focus();
            }
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "Search By Product Name")
            {
                #region Search By Product Name (Grouped Short Items)
                try
                {
                    lst_items.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"
            SELECT 
                S.ProductCode, 
                P.ProductName + ' ,' + P.ColorName + ' ,' + P.SizeName AS ProductName,
                P.ProductBarCode, 
                P.GroupName, 
                P.CategoryName, 
                P.ProductOriginName, 
                P.ColorShortName, 
                P.SizeShortName, 
                P.SalePrice, 
                ROUND(SUM(S.Quantity), 2) AS Quantity, 
                ROUND(AVG(S.StockPrice), 2) AS AveragePrice,
                ROUND(SUM(S.Quantity * S.StockPrice), 2) AS TOTAL,
                P.MinimumStockQty AS MinimumQuantity
            FROM 
                IMIS_tblStock S
            INNER JOIN 
                IMIS_VWProducts P ON P.ProductCode = S.ProductCode
            WHERE  
                S.StoreID = " + conclass.StoreID + @" AND 
                P.ProductName LIKE N'%" + txtSearchValue.Text.Trim() + @"%' 
            GROUP BY 
                S.ProductCode, P.ProductName, P.ColorName, P.SizeName, 
                P.ProductBarCode, P.GroupName, P.CategoryName, 
                P.ProductOriginName, P.ColorShortName, P.SizeShortName, 
                P.SalePrice, P.MinimumStockQty
            HAVING 
                SUM(S.Quantity) < P.MinimumStockQty
            ORDER BY 
                S.ProductCode");

                    TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["GroupName"].ToString());
                        item.SubItems.Add(dr["CategoryName"].ToString());
                        item.SubItems.Add(dr["ProductOriginName"].ToString());
                        item.SubItems.Add(dr["MinimumQuantity"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        lst_items.Items.Add(item);
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
                #region All Short Items (Grouped)
                try
                {
                    lst_items.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"
            SELECT 
                S.ProductCode, 
                P.ProductName + ' ,' + P.ColorName + ' ,' + P.SizeName AS ProductName,
                P.ProductBarCode, 
                P.GroupName, 
                P.CategoryName, 
                P.ProductOriginName, 
                P.ColorShortName, 
                P.SizeShortName, 
                P.SalePrice, 
                ROUND(SUM(S.Quantity), 2) AS Quantity, 
                ROUND(AVG(S.StockPrice), 2) AS AveragePrice,
                ROUND(SUM(S.Quantity * S.StockPrice), 2) AS TOTAL,
                P.MinimumStockQty AS MinimumQuantity
            FROM 
                IMIS_tblStock S
            INNER JOIN 
                IMIS_VWProducts P ON P.ProductCode = S.ProductCode
            WHERE  
                S.StoreID = " + conclass.StoreID + @"
            GROUP BY 
                S.ProductCode, P.ProductName, P.ColorName, P.SizeName, 
                P.ProductBarCode, P.GroupName, P.CategoryName, 
                P.ProductOriginName, P.ColorShortName, P.SizeShortName, 
                P.SalePrice, P.MinimumStockQty
            HAVING 
                SUM(S.Quantity) < P.MinimumStockQty
            ORDER BY 
                S.ProductCode");

                    TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["GroupName"].ToString());
                        item.SubItems.Add(dr["CategoryName"].ToString());
                        item.SubItems.Add(dr["ProductOriginName"].ToString());
                        item.SubItems.Add(dr["MinimumQuantity"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        lst_items.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
            }

        }

        private void txtSearchValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnViewReport_Click(null, null);
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {

        }
    }
}
