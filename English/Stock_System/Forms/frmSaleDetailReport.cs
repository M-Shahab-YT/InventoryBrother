using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stock_System.Forms
{
    public partial class frmSaleDetailReport : Form
    {
        public frmSaleDetailReport()
        {
            InitializeComponent();
        }
        Decimal TotalSalesValue = 0;
        Decimal TotalProfitValue = 0;
        Decimal TotalQty = 0;
        Decimal TotalDiscount = 0;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetZero();
          
            if (lstSearch.SelectedItem.ToString() == "Search By Date")
            {

                # region Search By Date
                string from = this.dtfrom.Value.ToString("yyyy-MM-dd");
                string to = this.dtto.Value.ToString("yyyy-MM-dd");

                try
                {
                    //TempDt = null;
                    lstInvoiceDetail.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT IMIS_tblSaleOrderDetail.SNO, IMIS_tblSaleOrderDetail.InvoiceNo, IMIS_tblSaleOrderDetail.ProductCode, IMIS_tblSaleOrderDetail.BatchNo, IMIS_tblSaleOrderDetail.ExpiryDate, IMIS_tblSaleOrderDetail.ProductStockID, 
       IMIS_tblSaleOrderDetail.Quantity, IMIS_tblSaleOrderDetail.BaseCurrencyAveragePrice, IMIS_tblSaleOrderDetail.SalePrice, IMIS_tblSaleOrderDetail.Discount, IMIS_tblSaleOrderDetail.CurrencyID, 
       IMIS_tblSaleOrderDetail.ExchangeRate, IMIS_tblSaleOrderDetail.BaseCurrencySalePrice, IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, IMIS_tblSaleOrderDetail.TotalBaseCurrencyProfit, IMIS_tblSaleOrderDetail.Total, 
       IMIS_tblSaleOrderDetail.BaseCurrencyTotal,
       IMIS_tblSaleOrderDetail.BaseCurrencyDiscount, IMIS_tblSaleOrderDetail.QuantityReturned, CONVERT(varchar(12), IMIS_tblSaleOrderDetail.SystemDate, 107) AS SystemDate, IMIS_tblProduct.ProductName, IMIS_tblProduct.ProductGenericName
FROM IMIS_tblSaleOrderDetail
INNER JOIN IMIS_tblProduct ON IMIS_tblSaleOrderDetail.ProductCode = IMIS_tblProduct.ProductCode WHERE IMIS_tblSaleOrderDetail.SystemDate >= '" + from + "' AND IMIS_tblSaleOrderDetail.SystemDate <= '" + to + "'   AND IMIS_tblSaleOrderDetail.Status != 'Full Returned' ORDER BY IMIS_tblSaleOrderDetail.SNO;");
                    //TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["ProductGenericName"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyAveragePrice"].ToString());
                        item.SubItems.Add(dr["BaseCurrencySalePrice"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyDiscount"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyTotal"].ToString());
                        item.SubItems.Add(dr["TotalBaseCurrencyProfit"].ToString());
                        TotalSalesValue = TotalSalesValue + Decimal.Parse(dr["BaseCurrencyTotal"].ToString());
                        TotalProfitValue = TotalProfitValue + Decimal.Parse(dr["TotalBaseCurrencyProfit"].ToString());
                        TotalQty = TotalQty + Decimal.Parse(dr["Quantity"].ToString());
                        TotalDiscount = TotalDiscount + (Decimal.Parse(dr["Quantity"].ToString()) * Decimal.Parse(dr["BaseCurrencyDiscount"].ToString()));
                        lstInvoiceDetail.Items.Add(item);
                    }
                    txtTotalProfitValue.Text = TotalProfitValue.ToString();
                    txtTotalSaleValue.Text = TotalSalesValue.ToString();
                    txtTotalQty.Text = TotalQty.ToString();
                    txtTotalDiscount.Text = TotalDiscount.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                #endregion
            }
            else if (lstSearch.SelectedItem.ToString() == "By Item & Date")
            {
                # region Search By Date
              
                string from = this.dtfrom.Value.ToString("yyyy-MM-dd");
                string to = this.dtto.Value.ToString("yyyy-MM-dd");
                try
                {
                    //TempDt = null;
                    lstInvoiceDetail.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT        IMIS_tblSaleOrderDetail.SNO, IMIS_tblSaleOrderDetail.InvoiceNo, IMIS_tblSaleOrderDetail.ProductCode, IMIS_tblSaleOrderDetail.BatchNo, IMIS_tblSaleOrderDetail.ExpiryDate, IMIS_tblSaleOrderDetail.ProductStockID, 
                         IMIS_tblSaleOrderDetail.Quantity, IMIS_tblSaleOrderDetail.BaseCurrencyAveragePrice, IMIS_tblSaleOrderDetail.SalePrice, IMIS_tblSaleOrderDetail.Discount, IMIS_tblSaleOrderDetail.CurrencyID, 
                         IMIS_tblSaleOrderDetail.ExchangeRate, IMIS_tblSaleOrderDetail.BaseCurrencySalePrice, IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, IMIS_tblSaleOrderDetail.TotalBaseCurrencyProfit, IMIS_tblSaleOrderDetail.Total, 
                         IMIS_tblSaleOrderDetail.BaseCurrencyTotal,
                         IMIS_tblSaleOrderDetail.BaseCurrencyDiscount, IMIS_tblSaleOrderDetail.QuantityReturned,convert(varchar(12), IMIS_tblSaleOrderDetail.SystemDate,107)as SystemDate, IMIS_tblProduct.ProductName, IMIS_tblProduct.ProductGenericName
FROM            IMIS_tblSaleOrderDetail INNER JOIN
                         IMIS_tblProduct ON IMIS_tblSaleOrderDetail.ProductCode = IMIS_tblProduct.ProductCode
						 where IMIS_tblSaleOrderDetail.SystemDate >= CAST('" + from + "' AS DATETIME) AND IMIS_tblSaleOrderDetail.SystemDate <= CAST('" + to + "' AS DATETIME)  and IMIS_tblSaleOrderDetail.Status!='Full Returned' and IMIS_tblProduct.ProductName like N'%" + txt_Invoice.Text.Trim() + "%' order by IMIS_tblSaleOrderDetail.SNO ");
                    //TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["ProductGenericName"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyAveragePrice"].ToString());
                        item.SubItems.Add(dr["BaseCurrencySalePrice"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyDiscount"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyTotal"].ToString());
                        item.SubItems.Add(dr["TotalBaseCurrencyProfit"].ToString());
                        TotalSalesValue = TotalSalesValue + Decimal.Parse(dr["BaseCurrencyTotal"].ToString());
                        TotalProfitValue = TotalProfitValue + Decimal.Parse(dr["TotalBaseCurrencyProfit"].ToString());
                        TotalQty = TotalQty + Decimal.Parse(dr["Quantity"].ToString());
                        TotalDiscount = TotalDiscount + (Decimal.Parse(dr["Quantity"].ToString()) * Decimal.Parse(dr["BaseCurrencyDiscount"].ToString()));
                        lstInvoiceDetail.Items.Add(item);
                    }
                    txtTotalProfitValue.Text = TotalProfitValue.ToString();
                    txtTotalSaleValue.Text = TotalSalesValue.ToString();
                    txtTotalQty.Text = TotalQty.ToString();
                    txtTotalDiscount.Text = TotalDiscount.ToString();
            
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                #endregion
            }
            else if (lstSearch.SelectedItem.ToString() == "Search By Generic Name")
            {
                # region Search By Date
               
                string from = this.dtfrom.Value.ToString("yyyy-MM-dd");
                string to = this.dtto.Value.ToString("yyyy-MM-dd");
                try
                {
                    //TempDt = null;
                    lstInvoiceDetail.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT        IMIS_tblSaleOrderDetail.SNO, IMIS_tblSaleOrderDetail.InvoiceNo, IMIS_tblSaleOrderDetail.ProductCode, IMIS_tblSaleOrderDetail.BatchNo, IMIS_tblSaleOrderDetail.ExpiryDate, IMIS_tblSaleOrderDetail.ProductStockID, 
                         IMIS_tblSaleOrderDetail.Quantity, IMIS_tblSaleOrderDetail.BaseCurrencyAveragePrice, IMIS_tblSaleOrderDetail.SalePrice, IMIS_tblSaleOrderDetail.Discount, IMIS_tblSaleOrderDetail.CurrencyID, 
                         IMIS_tblSaleOrderDetail.ExchangeRate, IMIS_tblSaleOrderDetail.BaseCurrencySalePrice, IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, IMIS_tblSaleOrderDetail.TotalBaseCurrencyProfit, IMIS_tblSaleOrderDetail.Total, 
                         IMIS_tblSaleOrderDetail.BaseCurrencyTotal,
                         IMIS_tblSaleOrderDetail.BaseCurrencyDiscount, IMIS_tblSaleOrderDetail.QuantityReturned,convert(varchar(12), IMIS_tblSaleOrderDetail.SystemDate,107)as SystemDate, IMIS_tblProduct.ProductName, IMIS_tblProduct.ProductGenericName
FROM            IMIS_tblSaleOrderDetail INNER JOIN
                         IMIS_tblProduct ON IMIS_tblSaleOrderDetail.ProductCode = IMIS_tblProduct.ProductCode
						 where IMIS_tblSaleOrderDetail.SystemDate >= CAST('" + from + "' AS DATETIME) AND IMIS_tblSaleOrderDetail.SystemDate <= CAST('" + to + "' AS DATETIME)  and IMIS_tblSaleOrderDetail.Status!='Full Returned' and IMIS_tblProduct.ProductGenericName like N'%" + txt_Invoice.Text.Trim() + "%' order by IMIS_tblSaleOrderDetail.SNO ");
                    //TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["ProductGenericName"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyAveragePrice"].ToString());
                        item.SubItems.Add(dr["BaseCurrencySalePrice"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyDiscount"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyTotal"].ToString());
                        item.SubItems.Add(dr["TotalBaseCurrencyProfit"].ToString());
                        TotalSalesValue = TotalSalesValue + Decimal.Parse(dr["BaseCurrencyTotal"].ToString());
                        TotalProfitValue = TotalProfitValue + Decimal.Parse(dr["TotalBaseCurrencyProfit"].ToString());
                        TotalQty = TotalQty + Decimal.Parse(dr["Quantity"].ToString());
                        TotalDiscount = TotalDiscount + (Decimal.Parse(dr["Quantity"].ToString()) * Decimal.Parse(dr["BaseCurrencyDiscount"].ToString()));
                        lstInvoiceDetail.Items.Add(item);
                    }
                    txtTotalProfitValue.Text = TotalProfitValue.ToString();
                    txtTotalSaleValue.Text = TotalSalesValue.ToString();
                    txtTotalQty.Text = TotalQty.ToString();
                    txtTotalDiscount.Text = TotalDiscount.ToString();
                                 }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                #endregion
            }
            else if (lstSearch.SelectedItem.ToString() == "By Item")
            {
                # region Search By Date

                try
                {
                    //TempDt = null;
                    lstInvoiceDetail.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT        IMIS_tblSaleOrderDetail.SNO, IMIS_tblSaleOrderDetail.InvoiceNo, IMIS_tblSaleOrderDetail.ProductCode, IMIS_tblSaleOrderDetail.BatchNo, IMIS_tblSaleOrderDetail.ExpiryDate, IMIS_tblSaleOrderDetail.ProductStockID, 
                         IMIS_tblSaleOrderDetail.Quantity, IMIS_tblSaleOrderDetail.BaseCurrencyAveragePrice, IMIS_tblSaleOrderDetail.SalePrice, IMIS_tblSaleOrderDetail.Discount, IMIS_tblSaleOrderDetail.CurrencyID, 
                         IMIS_tblSaleOrderDetail.ExchangeRate, IMIS_tblSaleOrderDetail.BaseCurrencySalePrice, IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, IMIS_tblSaleOrderDetail.TotalBaseCurrencyProfit, IMIS_tblSaleOrderDetail.Total, 
                         IMIS_tblSaleOrderDetail.BaseCurrencyTotal,
                         IMIS_tblSaleOrderDetail.BaseCurrencyDiscount, IMIS_tblSaleOrderDetail.QuantityReturned,convert(varchar(12), IMIS_tblSaleOrderDetail.SystemDate,107)as SystemDate, IMIS_tblProduct.ProductName, IMIS_tblProduct.ProductGenericName
FROM            IMIS_tblSaleOrderDetail INNER JOIN
                         IMIS_tblProduct ON IMIS_tblSaleOrderDetail.ProductCode = IMIS_tblProduct.ProductCode
						 where  IMIS_tblSaleOrderDetail.Status!='Full Returned' and IMIS_tblProduct.ProductName like N'%" + txt_Invoice.Text.Trim() + "%' order by IMIS_tblSaleOrderDetail.SNO ");
                    //TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["ProductGenericName"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyAveragePrice"].ToString());
                        item.SubItems.Add(dr["BaseCurrencySalePrice"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyDiscount"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyTotal"].ToString());
                        item.SubItems.Add(dr["TotalBaseCurrencyProfit"].ToString());
                        TotalSalesValue = TotalSalesValue + Decimal.Parse(dr["BaseCurrencyTotal"].ToString());
                        TotalProfitValue = TotalProfitValue + Decimal.Parse(dr["TotalBaseCurrencyProfit"].ToString());
                        TotalQty = TotalQty + Decimal.Parse(dr["Quantity"].ToString());
                        TotalDiscount = TotalDiscount + (Decimal.Parse(dr["Quantity"].ToString()) * Decimal.Parse(dr["BaseCurrencyDiscount"].ToString()));
                        lstInvoiceDetail.Items.Add(item);
                    }
                    txtTotalProfitValue.Text = TotalProfitValue.ToString();
                    txtTotalSaleValue.Text = TotalSalesValue.ToString();
                    txtTotalQty.Text = TotalQty.ToString();
                    txtTotalDiscount.Text = TotalDiscount.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                #endregion
            }
           
        }

        private void lstSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSearch.SelectedItem.ToString() == "Search By Invoice No")
            {
                gpdate.Enabled = false;
                gpinvioce.Enabled = true;
                txt_Invoice.Focus();
            }
            else if (lstSearch.SelectedItem.ToString() == "Search By Date")
            {
                gpdate.Enabled = true;
                gpinvioce.Enabled = false;
            }
            else if (lstSearch.SelectedItem.ToString() == "By Item & Date")
            {
                gpdate.Enabled = true;
                gpinvioce.Enabled = true;
                txt_Invoice.Focus();
            }
            else if (lstSearch.SelectedItem.ToString() == "By Item")
            {
                gpdate.Enabled = false;
                gpinvioce.Enabled = true;
                txt_Invoice.Focus();
            }
            else if (lstSearch.SelectedItem.ToString() == "Search By Generic Name")
            {
                gpdate.Enabled = false;
                gpinvioce.Enabled = true;
                txt_Invoice.Focus();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {

        }

        private void frmSaleDetailReport_Load(object sender, EventArgs e)
        {
            lstSearch.Text = "Search By Date";
            TodaySale();
        }
        private void SetZero()
        {
            TotalSalesValue = 0;
            TotalProfitValue = 0;
            TotalQty = 0;
            TotalDiscount = 0;
        }
        private void TodaySale()
        {
            SetZero();
            # region Search By Date
            string from = this.dtfrom.Value.ToString("yyyy-MM-dd");
            string to = this.dtto.Value.ToString("yyyy-MM-dd");

            try
            {
                //TempDt = null;
                lstInvoiceDetail.Items.Clear();
                DataTable dt = new DataTable();
                dt = Class.conclass.GetRecord(@"SELECT IMIS_tblSaleOrderDetail.SNO, IMIS_tblSaleOrderDetail.InvoiceNo, IMIS_tblSaleOrderDetail.ProductCode, IMIS_tblSaleOrderDetail.BatchNo, IMIS_tblSaleOrderDetail.ExpiryDate, IMIS_tblSaleOrderDetail.ProductStockID, 
       IMIS_tblSaleOrderDetail.Quantity, IMIS_tblSaleOrderDetail.BaseCurrencyAveragePrice, IMIS_tblSaleOrderDetail.SalePrice, IMIS_tblSaleOrderDetail.Discount, IMIS_tblSaleOrderDetail.CurrencyID, 
       IMIS_tblSaleOrderDetail.ExchangeRate, IMIS_tblSaleOrderDetail.BaseCurrencySalePrice, IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, IMIS_tblSaleOrderDetail.TotalBaseCurrencyProfit, IMIS_tblSaleOrderDetail.Total, 
       IMIS_tblSaleOrderDetail.BaseCurrencyTotal,
       IMIS_tblSaleOrderDetail.BaseCurrencyDiscount, IMIS_tblSaleOrderDetail.QuantityReturned, CONVERT(varchar(12), IMIS_tblSaleOrderDetail.SystemDate, 107) AS SystemDate, IMIS_tblProduct.ProductName, IMIS_tblProduct.ProductGenericName
FROM IMIS_tblSaleOrderDetail
INNER JOIN IMIS_tblProduct ON IMIS_tblSaleOrderDetail.ProductCode = IMIS_tblProduct.ProductCode
WHERE CAST(IMIS_tblSaleOrderDetail.SystemDate AS DATE) = CAST(GETDATE() AS DATE) -- Filter by today's date
  AND IMIS_tblSaleOrderDetail.Status != 'Full Returned'
ORDER BY IMIS_tblSaleOrderDetail.SNO;
 ");
                //TempDt = dt;
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                    item.SubItems.Add(dr["ProductName"].ToString());
                    item.SubItems.Add(dr["ProductGenericName"].ToString());
                    item.SubItems.Add(dr["SystemDate"].ToString());
                    item.SubItems.Add(dr["Quantity"].ToString());
                    item.SubItems.Add(dr["BaseCurrencyAveragePrice"].ToString());
                    item.SubItems.Add(dr["BaseCurrencySalePrice"].ToString());
                    item.SubItems.Add(dr["BaseCurrencyDiscount"].ToString());
                    item.SubItems.Add(dr["BaseCurrencyTotal"].ToString());
                    item.SubItems.Add(dr["TotalBaseCurrencyProfit"].ToString());
                    TotalSalesValue = TotalSalesValue + Decimal.Parse(dr["BaseCurrencyTotal"].ToString());
                    TotalProfitValue = TotalProfitValue + Decimal.Parse(dr["TotalBaseCurrencyProfit"].ToString());
                    TotalQty = TotalQty + Decimal.Parse(dr["Quantity"].ToString());
                    TotalDiscount = TotalDiscount + (Decimal.Parse(dr["Quantity"].ToString()) * Decimal.Parse(dr["BaseCurrencyDiscount"].ToString()));
                    lstInvoiceDetail.Items.Add(item);
                }
                txtTotalProfitValue.Text = TotalProfitValue.ToString();
                txtTotalSaleValue.Text = TotalSalesValue.ToString();
                txtTotalQty.Text = TotalQty.ToString();
                txtTotalDiscount.Text = TotalDiscount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            #endregion
        
        }
    }
}
