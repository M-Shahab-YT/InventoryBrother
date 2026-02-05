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
    public partial class frmSalesReturnReport : Form
    {
        public frmSalesReturnReport()
        {
            InitializeComponent();
        }

        private void frmSalesReturnReport_Load(object sender, EventArgs e)
        {
            GetTodayReturn();
        }
        private void GetTodayReturn()
        {
            Decimal TotalSalesValue = 0;
            Decimal TotalQty = 0;
            TotalSalesValue = 0;
            Decimal TotalProfitValue = 0;
            # region Search By Date
            string from = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
            string to = this.dtto.Value.Month.ToString() + "/" + this.dtto.Value.Day.ToString() + "/" + this.dtto.Value.Year.ToString();

            try
            {
                //TempDt = null;
                lstInvoiceDetail.Items.Clear();
                DataTable dt = new DataTable();
                dt = Class.conclass.GetRecord(@"SELECT        IMIS_tblSalesReturnTransaction.ID, IMIS_tblSalesReturnTransaction.InvoiceNo, IMIS_tblSalesReturnTransaction.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.CategoryName, 
                         IMIS_tblSalesReturnTransaction.ReturnQuantity, IMIS_tblSalesReturnTransaction.ReturnAmount,
						  IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit,

						 isnull(IMIS_tblSalesReturnTransaction.ReturnQuantity,0) *  isnull(IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit,0) as TotalProfit,
						 
						 IMIS_tblSalesReturnTransaction.StoreID, IMIS_tblSalesReturnTransaction.ReturnDate, aspnet_Users.UserName
                        
FROM            IMIS_tblSalesReturnTransaction INNER JOIN
                         IMIS_VWProducts ON IMIS_tblSalesReturnTransaction.ProductCode = IMIS_VWProducts.ProductCode INNER JOIN
                         aspnet_Users ON IMIS_tblSalesReturnTransaction.ReturnUserID = aspnet_Users.UserId INNER JOIN
                         IMIS_tblSaleOrderDetail ON IMIS_tblSalesReturnTransaction.RowNumber = IMIS_tblSaleOrderDetail.SNO
WHERE        (IMIS_tblSalesReturnTransaction.StoreID = " + Class.conclass.StoreID + ") and  (CAST(CONVERT(varchar(12), IMIS_tblSalesReturnTransaction.ReturnDate, 106) AS datetime) >= CAST(CONVERT(varchar(12), GETDATE(), 106) AS Datetime)) AND (CAST(CONVERT(varchar(12), IMIS_tblSalesReturnTransaction.ReturnDate,106) AS datetime) <= CAST(CONVERT(varchar(12), GETDATE(), 106) AS Datetime))  order by IMIS_tblSalesReturnTransaction.ID ");
                //TempDt = dt;
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["ID"].ToString());
                    item.SubItems.Add(dr["InvoiceNo"].ToString());
                    item.SubItems.Add(dr["ProductCode"].ToString());
                    item.SubItems.Add(dr["ProductName"].ToString());
                    item.SubItems.Add(dr["CategoryName"].ToString());
                    item.SubItems.Add(dr["ReturnQuantity"].ToString());
                    item.SubItems.Add(dr["ReturnAmount"].ToString());
                    item.SubItems.Add(dr["BaseCurrencyProfitPerUnit"].ToString());
                    item.SubItems.Add(dr["TotalProfit"].ToString());
                    item.SubItems.Add(dr["ReturnDate"].ToString());
                    item.SubItems.Add(dr["UserName"].ToString());
                    TotalSalesValue = TotalSalesValue + Decimal.Parse(dr["ReturnAmount"].ToString());
                    TotalQty = TotalQty + Decimal.Parse(dr["ReturnQuantity"].ToString());
                    TotalProfitValue = TotalProfitValue + Decimal.Parse(dr["TotalProfit"].ToString());
                    lstInvoiceDetail.Items.Add(item);
                }
                txtTotalSaleValue.Text = TotalSalesValue.ToString();
                txtTotalQty.Text = TotalQty.ToString();
                txtTotalReturnProfit.Text = TotalProfitValue.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            lstSearch.Text = "Search By Date";

            #endregion

        }

        private void lstSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Invoice.Text = "";
             if (lstSearch.SelectedItem.ToString() == "Search By Date")
            {
                gpdate.Enabled = true;
                gpinvioce.Enabled = false;
            }
             else if (lstSearch.SelectedItem.ToString() == "Search By ITEM & Date")
            {
                gpdate.Enabled = true;
                gpinvioce.Enabled = true;
                txt_Invoice.Focus();
            }
             else if (lstSearch.SelectedItem.ToString() == "Search By Customer & Date")
            {
                gpdate.Enabled = true;
                gpinvioce.Enabled = true;
                txt_Invoice.Focus();
            }
             else if (lstSearch.SelectedItem.ToString() == "Search By CustomerID & Date")
            {
                gpdate.Enabled = true;
                gpinvioce.Enabled = true;
                txt_Invoice.Focus();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Decimal TotalSalesValue = 0;
            Decimal TotalProfitValue = 0;
            Decimal TotalQty = 0;
            if (lstSearch.SelectedItem.ToString() == "Search By Date")
            {
                TotalSalesValue = 0;
                TotalProfitValue = 0;
                # region Search By Date
                string from = this.dtfrom.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string to = this.dtto.Value.ToString("yyyy-MM-dd HH:mm:ss");
                try
                {
                    //TempDt = null;
                    lstInvoiceDetail.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT        SaleReturnDetail.ID, SaleReturnDetail.InvoiceNo, SaleReturnDetail.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.CategoryName, SaleReturnDetail.ReturnQuantity, SaleReturnDetail.ReturnAmount, 
                         IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, ISNULL(SaleReturnDetail.ReturnQuantity, 0) * ISNULL(IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, 0) AS TotalProfit, SaleReturnDetail.StoreID, 
                          aspnet_Users.FullName AS UserName, SaleReturnMain.CustomerID,IMIS_tblCustomer.CustomerName, SaleReturnMain.SaleReturnDate as ReturnDate
FROM            SaleReturnMain INNER JOIN
                         IMIS_tblCustomer ON SaleReturnMain.CustomerID = IMIS_tblCustomer.CustomerID INNER JOIN
                         SaleReturnDetail INNER JOIN
                         IMIS_VWProducts ON SaleReturnDetail.ProductCode = IMIS_VWProducts.ProductCode INNER JOIN
                         aspnet_Users ON SaleReturnDetail.ReturnUserID = aspnet_Users.UserId INNER JOIN
                         IMIS_tblSaleOrderDetail ON SaleReturnDetail.RowNumber = IMIS_tblSaleOrderDetail.SNO ON SaleReturnMain.SaleReturnID = SaleReturnDetail.SaleReturnID
WHERE        (SaleReturnDetail.StoreID = " + Class.conclass.StoreID + ") and SaleReturnMain.SaleReturnDate >= CAST('" + from + "' AS DATETIME) AND SaleReturnMain.SaleReturnDate <= CAST('" + to + "' AS DATETIME)  order by SaleReturnDetail.ID ");
                    //TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ID"].ToString());
                        item.SubItems.Add(dr["InvoiceNo"].ToString());
                        item.SubItems.Add(dr["CustomerID"].ToString());
                        item.SubItems.Add(dr["CustomerName"].ToString());
                        item.SubItems.Add(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["CategoryName"].ToString());
                        item.SubItems.Add(dr["ReturnQuantity"].ToString());
                        item.SubItems.Add(dr["ReturnAmount"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyProfitPerUnit"].ToString());
                        item.SubItems.Add(dr["TotalProfit"].ToString());
                        item.SubItems.Add(dr["ReturnDate"].ToString());
                        item.SubItems.Add(dr["UserName"].ToString());
                        TotalSalesValue = TotalSalesValue + Decimal.Parse(dr["ReturnAmount"].ToString());
                        TotalQty = TotalQty + Decimal.Parse(dr["ReturnQuantity"].ToString());
                        TotalProfitValue = TotalProfitValue + Decimal.Parse(dr["TotalProfit"].ToString());
                        lstInvoiceDetail.Items.Add(item);
                    }
                    txtTotalSaleValue.Text = TotalSalesValue.ToString();
                    txtTotalQty.Text = TotalQty.ToString();
                    txtTotalReturnProfit.Text = TotalProfitValue.ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                #endregion
            }
            else if (lstSearch.SelectedItem.ToString() == "Search By ITEM & Date")
            {
                TotalSalesValue = 0;
                TotalProfitValue = 0;
                # region Search By Date
                string from = this.dtfrom.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string to = this.dtto.Value.ToString("yyyy-MM-dd HH:mm:ss");
                try
                {
                    //TempDt = null;
                    lstInvoiceDetail.Items.Clear();
                    DataTable dt = new DataTable();


                    dt = Class.conclass.GetRecord(@"SELECT        SaleReturnDetail.ID, SaleReturnDetail.InvoiceNo, SaleReturnDetail.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.CategoryName, SaleReturnDetail.ReturnQuantity, SaleReturnDetail.ReturnAmount, 
                         IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, ISNULL(SaleReturnDetail.ReturnQuantity, 0) * ISNULL(IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, 0) AS TotalProfit, SaleReturnDetail.StoreID, 
                          aspnet_Users.FullName AS UserName, SaleReturnMain.CustomerID,IMIS_tblCustomer.CustomerName, SaleReturnMain.SaleReturnDate as ReturnDate
FROM            SaleReturnMain INNER JOIN
                         IMIS_tblCustomer ON SaleReturnMain.CustomerID = IMIS_tblCustomer.CustomerID INNER JOIN
                         SaleReturnDetail INNER JOIN
                         IMIS_VWProducts ON SaleReturnDetail.ProductCode = IMIS_VWProducts.ProductCode INNER JOIN
                         aspnet_Users ON SaleReturnDetail.ReturnUserID = aspnet_Users.UserId INNER JOIN
                         IMIS_tblSaleOrderDetail ON SaleReturnDetail.RowNumber = IMIS_tblSaleOrderDetail.SNO ON SaleReturnMain.SaleReturnID = SaleReturnDetail.SaleReturnID
WHERE        (SaleReturnDetail.StoreID = " + Class.conclass.StoreID + ") and IMIS_VWProducts.ProductName like N'%" + txt_Invoice.Text + "%' and SaleReturnMain.SaleReturnDate >= CAST('" + from + "' AS DATETIME) AND SaleReturnMain.SaleReturnDate <= CAST('" + to + "' AS DATETIME)  order by SaleReturnDetail.ID ");
     

                    //TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ID"].ToString());
                        item.SubItems.Add(dr["InvoiceNo"].ToString());
                        item.SubItems.Add(dr["CustomerID"].ToString());
                        item.SubItems.Add(dr["CustomerName"].ToString());
                        item.SubItems.Add(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["CategoryName"].ToString());
                        item.SubItems.Add(dr["ReturnQuantity"].ToString());
                        item.SubItems.Add(dr["ReturnAmount"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyProfitPerUnit"].ToString());
                        item.SubItems.Add(dr["TotalProfit"].ToString());
                        item.SubItems.Add(dr["ReturnDate"].ToString());
                        item.SubItems.Add(dr["UserName"].ToString());
                        TotalSalesValue = TotalSalesValue + Decimal.Parse(dr["ReturnAmount"].ToString());
                        TotalQty = TotalQty + Decimal.Parse(dr["ReturnQuantity"].ToString());
                        TotalProfitValue = TotalProfitValue + Decimal.Parse(dr["TotalProfit"].ToString());
                        lstInvoiceDetail.Items.Add(item);
                    }
                    txtTotalSaleValue.Text = TotalSalesValue.ToString();
                    txtTotalQty.Text = TotalQty.ToString();
                    txtTotalReturnProfit.Text = TotalProfitValue.ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                #endregion
            }

            else if (lstSearch.SelectedItem.ToString() == "Search By Customer & Date")
            {
                TotalSalesValue = 0;
                TotalProfitValue = 0;
                string from = this.dtfrom.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string to = this.dtto.Value.ToString("yyyy-MM-dd HH:mm:ss");
                # region Search By Date

                try
                {
                    //TempDt = null;
                    lstInvoiceDetail.Items.Clear();
                    DataTable dt = new DataTable();


                    dt = Class.conclass.GetRecord(@"SELECT        SaleReturnDetail.ID, SaleReturnDetail.InvoiceNo, SaleReturnDetail.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.CategoryName, SaleReturnDetail.ReturnQuantity, SaleReturnDetail.ReturnAmount, 
                         IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, ISNULL(SaleReturnDetail.ReturnQuantity, 0) * ISNULL(IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, 0) AS TotalProfit, SaleReturnDetail.StoreID, 
                          aspnet_Users.FullName AS UserName, SaleReturnMain.CustomerID,IMIS_tblCustomer.CustomerName, SaleReturnMain.SaleReturnDate as ReturnDate
FROM            SaleReturnMain INNER JOIN
                         IMIS_tblCustomer ON SaleReturnMain.CustomerID = IMIS_tblCustomer.CustomerID INNER JOIN
                         SaleReturnDetail INNER JOIN
                         IMIS_VWProducts ON SaleReturnDetail.ProductCode = IMIS_VWProducts.ProductCode INNER JOIN
                         aspnet_Users ON SaleReturnDetail.ReturnUserID = aspnet_Users.UserId INNER JOIN
                         IMIS_tblSaleOrderDetail ON SaleReturnDetail.RowNumber = IMIS_tblSaleOrderDetail.SNO ON SaleReturnMain.SaleReturnID = SaleReturnDetail.SaleReturnID
WHERE        (SaleReturnDetail.StoreID = " + Class.conclass.StoreID + ") and IMIS_tblCustomer.CustomerName like N'%" + txt_Invoice.Text + "%' and SaleReturnMain.SaleReturnDate >= CAST('" + from + "' AS DATETIME) AND SaleReturnMain.SaleReturnDate <= CAST('" + to + "' AS DATETIME)  order by SaleReturnDetail.ID ");

                  //TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ID"].ToString());
                        item.SubItems.Add(dr["InvoiceNo"].ToString());
                        item.SubItems.Add(dr["CustomerID"].ToString());
                        item.SubItems.Add(dr["CustomerName"].ToString());
                        item.SubItems.Add(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["CategoryName"].ToString());
                        item.SubItems.Add(dr["ReturnQuantity"].ToString());
                        item.SubItems.Add(dr["ReturnAmount"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyProfitPerUnit"].ToString());
                        item.SubItems.Add(dr["TotalProfit"].ToString());
                        item.SubItems.Add(dr["ReturnDate"].ToString());
                        item.SubItems.Add(dr["UserName"].ToString());
                        TotalSalesValue = TotalSalesValue + Decimal.Parse(dr["ReturnAmount"].ToString());
                        TotalQty = TotalQty + Decimal.Parse(dr["ReturnQuantity"].ToString());
                        TotalProfitValue = TotalProfitValue + Decimal.Parse(dr["TotalProfit"].ToString());
                        lstInvoiceDetail.Items.Add(item);
                    }
                    txtTotalSaleValue.Text = TotalSalesValue.ToString();
                    txtTotalQty.Text = TotalQty.ToString();
                    txtTotalReturnProfit.Text = TotalProfitValue.ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                #endregion
            }

            else if (lstSearch.SelectedItem.ToString() == "Search By CustomerID & Date")
            {
                TotalSalesValue = 0;
                TotalProfitValue = 0;
                string from = this.dtfrom.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string to = this.dtto.Value.ToString("yyyy-MM-dd HH:mm:ss");
                # region Search By Date

                try
                {
                    //TempDt = null;
                    lstInvoiceDetail.Items.Clear();
                    DataTable dt = new DataTable();


                    dt = Class.conclass.GetRecord(@"SELECT        SaleReturnDetail.ID, SaleReturnDetail.InvoiceNo, SaleReturnDetail.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.CategoryName, SaleReturnDetail.ReturnQuantity, SaleReturnDetail.ReturnAmount, 
                         IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, ISNULL(SaleReturnDetail.ReturnQuantity, 0) * ISNULL(IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, 0) AS TotalProfit, SaleReturnDetail.StoreID, 
                          aspnet_Users.FullName AS UserName, SaleReturnMain.CustomerID,IMIS_tblCustomer.CustomerName, SaleReturnMain.SaleReturnDate as ReturnDate
FROM            SaleReturnMain INNER JOIN
                         IMIS_tblCustomer ON SaleReturnMain.CustomerID = IMIS_tblCustomer.CustomerID INNER JOIN
                         SaleReturnDetail INNER JOIN
                         IMIS_VWProducts ON SaleReturnDetail.ProductCode = IMIS_VWProducts.ProductCode INNER JOIN
                         aspnet_Users ON SaleReturnDetail.ReturnUserID = aspnet_Users.UserId INNER JOIN
                         IMIS_tblSaleOrderDetail ON SaleReturnDetail.RowNumber = IMIS_tblSaleOrderDetail.SNO ON SaleReturnMain.SaleReturnID = SaleReturnDetail.SaleReturnID
WHERE        (SaleReturnDetail.StoreID = " + Class.conclass.StoreID + ") and IMIS_tblCustomer.CustomerID =" + txt_Invoice.Text + " and SaleReturnMain.SaleReturnDate >= CAST('" + from + "' AS DATETIME) AND SaleReturnMain.SaleReturnDate <= CAST('" + to + "' AS DATETIME)  order by SaleReturnDetail.ID ");

                    //TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ID"].ToString());
                        item.SubItems.Add(dr["InvoiceNo"].ToString());
                        item.SubItems.Add(dr["CustomerID"].ToString());
                        item.SubItems.Add(dr["CustomerName"].ToString());
                        item.SubItems.Add(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["CategoryName"].ToString());
                        item.SubItems.Add(dr["ReturnQuantity"].ToString());
                        item.SubItems.Add(dr["ReturnAmount"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyProfitPerUnit"].ToString());
                        item.SubItems.Add(dr["TotalProfit"].ToString());
                        item.SubItems.Add(dr["ReturnDate"].ToString());
                        item.SubItems.Add(dr["UserName"].ToString());
                        TotalSalesValue = TotalSalesValue + Decimal.Parse(dr["ReturnAmount"].ToString());
                        TotalQty = TotalQty + Decimal.Parse(dr["ReturnQuantity"].ToString());
                        TotalProfitValue = TotalProfitValue + Decimal.Parse(dr["TotalProfit"].ToString());
                        lstInvoiceDetail.Items.Add(item);
                    }
                    txtTotalSaleValue.Text = TotalSalesValue.ToString();
                    txtTotalQty.Text = TotalQty.ToString();
                    txtTotalReturnProfit.Text = TotalProfitValue.ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                #endregion
            }
        }
    }
}
