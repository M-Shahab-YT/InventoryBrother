using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stock_System.Class;

namespace Stock_System.Forms
{
    public partial class frmProductDetailReport : Form
    {
        public frmProductDetailReport()
        {
            InitializeComponent();
        }
        Decimal TotalStockAmount = 0;
        DataTable TempDt = new DataTable();
        private void frmProductDetailReport_Load(object sender, EventArgs e)
        {
            cmbSearchType.Text = "All Stock";
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
           
            if (cmbSearchType.Text == "Search By Product Name")
            {
                #region Search By Item In
                try
                {
                    lst_items.Items.Clear();

                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT   IMIS_tblStock.ProductCode, sum(IMIS_tblStock.Quantity) as Quantity, IMIS_tblStock.StockPrice as AveragePrice, IMIS_tblStock.StoreID, IMIS_VWProducts.ProductName, 
IMIS_VWProducts.GroupName, IMIS_VWProducts.CategoryName, IMIS_VWProducts.ProductOriginName,
(select sum(d.Quantity) QuantityPurchase from IMIS_tblPurchaseOrderDetail d where d.Status!='Full Returned' and d.ProductCode=IMIS_tblStock.ProductCode) as QuantityPurchase,
isnull((select sum(d.Quantity) QuantityPurchase from IMIS_tblSaleOrderDetail d where d.Status!='Full Returned' and d.ProductCode=IMIS_tblStock.ProductCode),0) as QuantitySold,
(select sum(d.Quantity) QuantityPurchase from IMIS_tblStock d where d.ProductCode=IMIS_tblStock.ProductCode) as QuantityAvailable,

 CASE WHEN (select sum(d.Quantity) QuantityPurchase from IMIS_tblStock d where d.ProductCode=IMIS_tblStock.ProductCode) !=
 (
 (select sum(d.Quantity) QuantityPurchase from IMIS_tblPurchaseOrderDetail d where d.Status!='Full Returned' and d.ProductCode=IMIS_tblStock.ProductCode) -
isnull((select sum(d.Quantity) QuantityPurchase from IMIS_tblSaleOrderDetail d where d.Status!='Full Returned' and d.ProductCode=IMIS_tblStock.ProductCode),0)
 )  THEN 'NotEqual' ELSE 'Equal' END AS EqCondation
 FROM         IMIS_tblStock INNER JOIN  IMIS_VWProducts  ON IMIS_tblStock.ProductCode = IMIS_VWProducts.ProductCode
 WHERE IMIS_tblStock.StoreID = " + conclass.StoreID + " and IMIS_VWProducts.ProductName like N'" + txtSearchValue.Text + "%' group by  IMIS_tblStock.ProductCode,IMIS_tblStock.StockPrice,IMIS_tblStock.StoreID, IMIS_VWProducts.ProductName, IMIS_VWProducts.GroupName, IMIS_VWProducts.CategoryName, IMIS_VWProducts.ProductOriginName");
                    TempDt = dt;

                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["EqCondation"].ToString());
                        item.SubItems.Add(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["GroupName"].ToString());
                        item.SubItems.Add(dr["CategoryName"].ToString());
                        item.SubItems.Add(dr["ProductOriginName"].ToString());
                        item.SubItems.Add(dr["QuantityPurchase"].ToString());
                        item.SubItems.Add(dr["QuantitySold"].ToString());
                        item.SubItems.Add(dr["QuantityAvailable"].ToString());
                        lst_items.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
            }
            else if (cmbSearchType.Text == "Search By Product Category")
            {
                #region Search by All in all Branch
                try
                {
                    lst_items.Items.Clear();

                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT   IMIS_tblStock.ProductCode, sum(IMIS_tblStock.Quantity) as Quantity, IMIS_tblStock.StockPrice as AveragePrice, IMIS_tblStock.StoreID, IMIS_VWProducts.ProductName, 
IMIS_VWProducts.GroupName, IMIS_VWProducts.CategoryName, IMIS_VWProducts.ProductOriginName,
(select sum(d.Quantity) QuantityPurchase from IMIS_tblPurchaseOrderDetail d where d.Status!='Full Returned' and d.ProductCode=IMIS_tblStock.ProductCode) as QuantityPurchase,
isnull((select sum(d.Quantity) QuantityPurchase from IMIS_tblSaleOrderDetail d where d.Status!='Full Returned' and d.ProductCode=IMIS_tblStock.ProductCode),0) as QuantitySold,
(select sum(d.Quantity) QuantityPurchase from IMIS_tblStock d where d.ProductCode=IMIS_tblStock.ProductCode) as QuantityAvailable,

 CASE WHEN (select sum(d.Quantity) QuantityPurchase from IMIS_tblStock d where d.ProductCode=IMIS_tblStock.ProductCode) !=
 (
 (select sum(d.Quantity) QuantityPurchase from IMIS_tblPurchaseOrderDetail d where d.Status!='Full Returned' and d.ProductCode=IMIS_tblStock.ProductCode) -
isnull((select sum(d.Quantity) QuantityPurchase from IMIS_tblSaleOrderDetail d where d.Status!='Full Returned' and d.ProductCode=IMIS_tblStock.ProductCode),0)
 )  THEN 'NotEqual' ELSE 'Equal' END AS EqCondation
 FROM         IMIS_tblStock INNER JOIN  IMIS_VWProducts  ON IMIS_tblStock.ProductCode = IMIS_VWProducts.ProductCode WHERE IMIS_tblStock.StoreID = " + conclass.StoreID + " and IMIS_VWProducts.CategoryName like N'" + txtSearchValue.Text + "%' group by  IMIS_tblStock.ProductCode,IMIS_tblStock.StockPrice,IMIS_tblStock.StoreID, IMIS_VWProducts.ProductName, IMIS_VWProducts.GroupName, IMIS_VWProducts.CategoryName, IMIS_VWProducts.ProductOriginName");
                    TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["EqCondation"].ToString());
                        item.SubItems.Add(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["GroupName"].ToString());
                        item.SubItems.Add(dr["CategoryName"].ToString());
                        item.SubItems.Add(dr["ProductOriginName"].ToString());
                        item.SubItems.Add(dr["QuantityPurchase"].ToString());
                        item.SubItems.Add(dr["QuantitySold"].ToString());
                        item.SubItems.Add(dr["QuantityAvailable"].ToString());
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

        private void btnViewPurchase_Click(object sender, EventArgs e)
        {
            if (cmbSearchTypePurchase.Text == "Search By Product Name")
            {
                #region Search By Item In
                try
                {
                    lstPurchaseView.Items.Clear();

                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"

 SELECT IMIS_tblPurchaseOrderDetail.PurchaseOrderNo, IMIS_tblPurchaseOrderDetail.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.GroupName, IMIS_VWProducts.CategoryName, IMIS_VWProducts.ProductOriginName, 
                  IMIS_tblPurchaseOrderDetail.ShippingCostPerItem as ShippingCostPerItemBaseCurrency, IMIS_tblPurchaseOrderDetail.BaseCurrencyPrice, IMIS_tblPurchaseOrderDetail.Quantity, IMIS_tblPurchaseOrderDetail.Total, 
                  IMIS_tblPurchaseOrderDetail.BaseCurrencyTotal, IMIS_tblPurchaseOrderDetail.Status, convert(varchar(12),IMIS_tblPurchaseOrderDetail.SystemDate,107) as SystemDate
FROM     IMIS_tblPurchaseOrderDetail INNER JOIN
                  IMIS_VWProducts ON IMIS_tblPurchaseOrderDetail.ProductCode = IMIS_VWProducts.ProductCode
				   where IMIS_tblPurchaseOrderDetail.Status!='Full Returned'
 and IMIS_tblPurchaseOrderDetail.StoreID = " + conclass.StoreID + " and IMIS_VWProducts.ProductName like N'" + txtSearchValuePurchase.Text + "%'");
                    TempDt = dt;

                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["GroupName"].ToString());
                        item.SubItems.Add(dr["CategoryName"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyPrice"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyTotal"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        lstPurchaseView.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
            }
            else if (cmbSearchTypePurchase.Text == "Search By Product Name & Date")
            {
                string from = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
                string to = this.dtto.Value.Month.ToString() + "/" + this.dtto.Value.Day.ToString() + "/" + this.dtto.Value.Year.ToString();
               
                #region Search by All in all Branch
                try
                {
                    lstPurchaseView.Items.Clear();

                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"

 SELECT IMIS_tblPurchaseOrderDetail.PurchaseOrderNo, IMIS_tblPurchaseOrderDetail.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.GroupName, IMIS_VWProducts.CategoryName, IMIS_VWProducts.ProductOriginName, 
                  IMIS_tblPurchaseOrderDetail.ShippingCostPerItem as ShippingCostPerItemBaseCurrency, IMIS_tblPurchaseOrderDetail.BaseCurrencyPrice, IMIS_tblPurchaseOrderDetail.Quantity, IMIS_tblPurchaseOrderDetail.Total, 
                  IMIS_tblPurchaseOrderDetail.BaseCurrencyTotal, IMIS_tblPurchaseOrderDetail.Status, convert(varchar(12),IMIS_tblPurchaseOrderDetail.SystemDate,107) as SystemDate
FROM     IMIS_tblPurchaseOrderDetail INNER JOIN
                  IMIS_VWProducts ON IMIS_tblPurchaseOrderDetail.ProductCode = IMIS_VWProducts.ProductCode
				   where IMIS_tblPurchaseOrderDetail.Status!='Full Returned'
 and IMIS_tblPurchaseOrderDetail.StoreID = " + conclass.StoreID + " and IMIS_VWProducts.ProductName like N'" + txtSearchValuePurchase.Text + "%'  and cast(convert(varchar(12),IMIS_tblPurchaseOrderDetail.SystemDate,101) as datetime) between cast('" + from + "' as datetime) and cast('" + to + "' as datetime )");
                    TempDt = dt;

                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["GroupName"].ToString());
                        item.SubItems.Add(dr["CategoryName"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyPrice"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyTotal"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        lstPurchaseView.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
            }
        }

        private void cmbSearchTypePurchase_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbSearchTypePurchase.Text == "Search By Product Name")
            {
                pnlPurchaseDate.Enabled = false;
                pnlPurchaseValue.Enabled = true;
                txtSearchValuePurchase.Focus();
            }
            else if (cmbSearchTypePurchase.Text == "Search By Product Name & Date")
            {
                pnlPurchaseDate.Enabled = true;
                pnlPurchaseValue.Enabled = true;
                txtSearchValuePurchase.Focus();
            
            }
        }

        private void btnSearchSold_Click(object sender, EventArgs e)
        {

            Decimal TotalQty = 0;
            Decimal TotalPrice = 0;
            Decimal TotalDiscount = 0;
            Decimal TotalNet = 0;
            Decimal TotalProfit = 0;


            if (cmbSearchTypeSold.Text == "Search By Product Name")
            {
                #region Search By Item In
                try
                {
                    lstSoldView.Items.Clear();

                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT    IMIS_tblSaleOrderDetail.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.CategoryName, IMIS_VWProducts.GroupName, 
                         IMIS_tblSaleOrderDetail.Quantity, IMIS_tblSaleOrderDetail.BaseCurrencyAveragePrice, IMIS_tblSaleOrderDetail.BaseCurrencySalePrice, 
 IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, IMIS_tblSaleOrderDetail.TotalBaseCurrencyProfit, BaseCurrencyDiscount,
                         IMIS_tblSaleOrderDetail.BaseCurrencyTotal, IMIS_tblSaleOrderDetail.Status, IMIS_tblSaleOrderDetail.Remarks, IMIS_tblSaleOrderDetail.StoreID, 
  convert(varchar(12),IMIS_tblSaleOrderDetail.SystemDate,107) as SystemDate,BaseCurrencyDiscount*Quantity as TotalDiscount
FROM         IMIS_tblSaleOrderDetail INNER JOIN
                         IMIS_VWProducts ON IMIS_tblSaleOrderDetail.ProductCode = IMIS_VWProducts.ProductCode
 WHERE IMIS_tblSaleOrderDetail.StoreID = " + conclass.StoreID + " and IMIS_tblSaleOrderDetail.Status!='Full Returned' and IMIS_VWProducts.ProductName like N'" + txtSearchValueSold.Text + "%'");
                    TempDt = dt;

                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["CategoryName"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["BaseCurrencySalePrice"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyDiscount"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyTotal"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyProfitPerUnit"].ToString());
                        item.SubItems.Add(dr["TotalBaseCurrencyProfit"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        item.SubItems.Add(dr["TotalDiscount"].ToString());
                        lstSoldView.Items.Add(item);

                        #region Total Summary
                        TotalQty =TotalQty +Decimal.Parse(dr["Quantity"].ToString());
                         TotalPrice = TotalPrice + Decimal.Parse(dr["BaseCurrencySalePrice"].ToString());
                         TotalDiscount = TotalDiscount + Decimal.Parse(dr["TotalDiscount"].ToString());
                         TotalNet = TotalNet + Decimal.Parse(dr["BaseCurrencyTotal"].ToString());
                         TotalProfit = TotalProfit + Decimal.Parse(dr["TotalBaseCurrencyProfit"].ToString());
                         //lblTotalQty.Text = TotalQty.ToString();
                         //lblTotalSoldPrice.Text = TotalPrice.ToString();
                         //lblTotalDiscount.Text = TotalDiscount.ToString();
                         //lblNetTotal.Text = TotalNet.ToString();
                         //lblTotalProfit.Text = TotalProfit.ToString();
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
            }
            else if (cmbSearchTypeSold.Text == "Search By Product Name & Date")
            {
                string from = this.dtFromSold.Value.Month.ToString() + "/" + this.dtFromSold.Value.Day.ToString() + "/" + this.dtFromSold.Value.Year.ToString();
                string to = this.dtToSold.Value.Month.ToString() + "/" + this.dtToSold.Value.Day.ToString() + "/" + this.dtToSold.Value.Year.ToString();

                #region Search by All in all Branch
                try
                {
                    lstSoldView.Items.Clear();

                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT    IMIS_tblSaleOrderDetail.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.CategoryName, IMIS_VWProducts.GroupName, 
                         IMIS_tblSaleOrderDetail.Quantity, IMIS_tblSaleOrderDetail.BaseCurrencyAveragePrice,IMIS_tblSaleOrderDetail.BaseCurrencySalePrice, 
 IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, IMIS_tblSaleOrderDetail.TotalBaseCurrencyProfit, BaseCurrencyDiscount,
                         IMIS_tblSaleOrderDetail.BaseCurrencyTotal, IMIS_tblSaleOrderDetail.Status, IMIS_tblSaleOrderDetail.Remarks, IMIS_tblSaleOrderDetail.StoreID, 
                         convert(varchar(12),IMIS_tblSaleOrderDetail.SystemDate,107) as SystemDate,BaseCurrencyDiscount*Quantity as TotalDiscount
FROM         IMIS_tblSaleOrderDetail INNER JOIN
                         IMIS_VWProducts ON IMIS_tblSaleOrderDetail.ProductCode = IMIS_VWProducts.ProductCode
 WHERE IMIS_tblSaleOrderDetail.StoreID = " + conclass.StoreID + " and IMIS_tblSaleOrderDetail.Status!='Full Returned' and IMIS_VWProducts.ProductName like N'%" + txtSearchValueSold.Text + "%'  and cast(convert(varchar(12),IMIS_tblSaleOrderDetail.SystemDate,101) as datetime) between cast('" + from + "' as datetime) and cast('" + to + "' as datetime )");
                    TempDt = dt;

                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["CategoryName"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["BaseCurrencySalePrice"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyDiscount"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyTotal"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyProfitPerUnit"].ToString());
                        item.SubItems.Add(dr["TotalBaseCurrencyProfit"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        item.SubItems.Add(dr["TotalDiscount"].ToString());
                        lstSoldView.Items.Add(item);

                        #region Total Summary
                        TotalQty = TotalQty + Decimal.Parse(dr["Quantity"].ToString());
                        TotalPrice = TotalPrice + Decimal.Parse(dr["BaseCurrencySalePrice"].ToString());
                        TotalDiscount = TotalDiscount + Decimal.Parse(dr["TotalDiscount"].ToString());
                        TotalNet = TotalNet + Decimal.Parse(dr["BaseCurrencyTotal"].ToString());
                        TotalProfit = TotalProfit + Decimal.Parse(dr["TotalBaseCurrencyProfit"].ToString());
                        //lblTotalQty.Text = TotalQty.ToString();
                        //lblTotalSoldPrice.Text = TotalPrice.ToString();
                        //lblTotalDiscount.Text = TotalDiscount.ToString();
                        //lblNetTotal.Text = TotalNet.ToString();
                        //lblTotalProfit.Text = TotalProfit.ToString();
                        #endregion
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
            }
        }

        private void cmbSearchType_SelectionChangeCommitted(object sender, EventArgs e)
        {
         
        }

        private void cmbSearchTypeSold_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbSearchTypeSold.Text == "Search By Product Name")
            {
                pnlSearchValueSold.Enabled = true;
                pnlDateSold.Enabled = false;
                txtSearchValueSold.Focus();
            }
            else if (cmbSearchTypeSold.Text == "Search By Product Name & Date")
            {

                pnlSearchValueSold.Enabled = true;
                pnlDateSold.Enabled = true;
                txtSearchValueSold.Focus();
            }
        }

        private void lst_items_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            string Value = e.Item.Text;
            if (Value == "NotEqual")
            {
                e.Item.BackColor = Color.Red;
                e.Item.ForeColor = Color.Yellow;
                e.Item.UseItemStyleForSubItems = true;
            }
        }

        private void lst_items_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lst_items_Click(object sender, EventArgs e)
        {
            string Status = lst_items.SelectedItems[0].SubItems[0].Text;
            string ProductCode = lst_items.SelectedItems[0].SubItems[1].Text;
            #region Product Stock Chanage
            DataTable dt = conclass.GetRecord(@"SELECT        IMIS_tblStockHistory.SNO, IMIS_tblStockHistory.ProductCode, IMIS_tblProduct.ProductName, IMIS_tblStockHistory.Quantity,isnull(NewQuantity,0) as NewQuantity, IMIS_tblStockHistory.AveragePrice, IMIS_tblStockHistory.SystemDate, aspnet_Users.UserName
FROM            IMIS_tblStockHistory INNER JOIN
                         IMIS_tblProduct ON IMIS_tblStockHistory.ProductCode = IMIS_tblProduct.ProductCode INNER JOIN
                         aspnet_Users ON IMIS_tblStockHistory.UserID = aspnet_Users.UserId
WHERE        (IMIS_tblStockHistory.ProductCode = '" + ProductCode + "') ORDER BY IMIS_tblStockHistory.SNO");
            if (dt.Rows.Count > 0)
            {
                lstStockHistory.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["SNO"].ToString());
                    item.SubItems.Add(dr["ProductCode"].ToString());
                    item.SubItems.Add(dr["ProductName"].ToString());
                    item.SubItems.Add(dr["Quantity"].ToString());
                    item.SubItems.Add(dr["NewQuantity"].ToString());
                    item.SubItems.Add(dr["AveragePrice"].ToString());
                    item.SubItems.Add(dr["SystemDate"].ToString());
                    item.SubItems.Add(dr["UserName"].ToString());
                    lstStockHistory.Items.Add(item);
                }
            }
            #endregion
        
            pnlDrugHistory.Visible = true;
            pnlDrugHistory.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlDrugHistory.Visible = false;
            pnlDrugHistory.SendToBack();
        }


       
    }
}
