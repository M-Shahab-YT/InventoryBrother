using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Stock_System.Class;
using CrystalDecisions.Shared;
namespace Stock_System.Forms
{
    public partial class frmPurchaseReport : Telerik.WinControls.UI.RadForm
    {
        DataTable TempDt = new DataTable();
        public frmPurchaseReport()
        {
            InitializeComponent();
        }
        private void FillTodayPurchase()
        {
            try
            {
                TempDt = null;
                lstSaleView.Items.Clear();
                DataTable dt = new DataTable();
                dt = Class.conclass.GetRecord(@"SELECT        IMIS_tblPurchaseOrderMain.PurchaseOrderNo, IMIS_tblPurchaseOrderMain.OrderReceivedDate, IMIS_tblPurchaseOrderMain.SupplierID, IMIS_tblSupplier.SupplierName, IMIS_tblPurchaseOrderMain.InvoiceNo, 
                         IMIS_tblPurchaseOrderMain.PaymentMethod, Lookup_tblCurrency.CurrencyName, IMIS_tblPurchaseOrderMain.ExchangeRate, IMIS_tblPurchaseOrderMain.TotalOrderAmount, IMIS_tblPurchaseOrderMain.TotalShippingCost, 
                         IMIS_tblPurchaseOrderMain.TotalShippingCostBaseCurrency, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyAmount, 
                         IMIS_tblPurchaseOrderMain.AmountPaidToSupplier - ISNULL(IMIS_tblPurchaseOrderMain.CashReturnFromSupplier, 0) AS AmountPaidToSupplier, IMIS_tblPurchaseOrderMain.BalanceAmount, 
                         IMIS_tblPurchaseOrderMain.PaymentStatus, IMIS_tblPurchaseOrderMain.StoreID, CONVERT(varchar(12), IMIS_tblPurchaseOrderMain.SystemDate, 107) AS SystemDate, CONVERT(varchar(5), 
                         IMIS_tblPurchaseOrderMain.SystemTime, 108) AS SystemTime, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyPaidAmount - ISNULL(IMIS_tblPurchaseOrderMain.BaseCurrencyCashReturnFromSupplier, 0) 
                         AS TotalBaseCurrencyPaidAmount, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyBalanceAmount, IMIS_tblPurchaseOrderMain.CashReturnFromSupplier, IMIS_tblPurchaseOrderMain.BaseCurrencyCashReturnFromSupplier, 
                         aspnet_Users.UserName, IMIS_tblPurchaseOrderMain.CurrencyID
FROM            IMIS_tblPurchaseOrderMain INNER JOIN
                         IMIS_tblSupplier ON IMIS_tblPurchaseOrderMain.SupplierID = IMIS_tblSupplier.SupplierID INNER JOIN
                         Lookup_tblCurrency ON IMIS_tblPurchaseOrderMain.CurrencyID = Lookup_tblCurrency.CurrencyID INNER JOIN
                         aspnet_Users ON IMIS_tblPurchaseOrderMain.UserID = aspnet_Users.UserId
						 where IMIS_tblPurchaseOrderMain.StoreID=" + conclass.StoreID + "  and (CAST(CONVERT(varchar(12), OrderReceivedDate, 106) AS datetime) >= CAST(CONVERT(varchar(12), GETDATE(), 106) AS Datetime)) AND (CAST(CONVERT(varchar(12), OrderReceivedDate,106) AS datetime) <= CAST(CONVERT(varchar(12), GETDATE(), 106) AS Datetime)) order by IMIS_tblPurchaseOrderMain.PurchaseOrderNo");
                TempDt = dt;
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["PurchaseOrderNo"].ToString());
                    item.SubItems.Add(dr["SystemDate"].ToString());
                    item.SubItems.Add(dr["SystemTime"].ToString());
                    item.SubItems.Add(dr["SupplierName"].ToString());
                    item.SubItems.Add(dr["TotalOrderAmount"].ToString());
                    item.SubItems.Add(dr["AmountPaidToSupplier"].ToString());
                    item.SubItems.Add(dr["BalanceAmount"].ToString());
                    item.SubItems.Add(dr["CurrencyName"].ToString());
                    item.SubItems.Add(dr["PaymentMethod"].ToString());
                    item.SubItems.Add(dr["UserName"].ToString());
                    lstSaleView.Items.Add(item);
                }
                grdSummaryByCurrency.DataSource = obj.GetData(@"SELECT        IMIS_tblPurchaseOrderMain.CurrencyID, Lookup_tblCurrency.CurrencyName, SUM(IMIS_tblPurchaseOrderMain.TotalOrderAmount) AS TotalOrderAmount, 'Print Report' AS Report
FROM            IMIS_tblPurchaseOrderMain INNER JOIN
                         Lookup_tblCurrency ON IMIS_tblPurchaseOrderMain.CurrencyID = Lookup_tblCurrency.CurrencyID INNER JOIN
                         IMIS_tblSupplier ON IMIS_tblPurchaseOrderMain.SupplierID = IMIS_tblSupplier.SupplierID
						 where (CAST(CONVERT(varchar(12), OrderReceivedDate, 106) AS datetime) >= CAST(CONVERT(varchar(12), GETDATE(), 106) AS Datetime)) AND (CAST(CONVERT(varchar(12), OrderReceivedDate,106) AS datetime) <= CAST(CONVERT(varchar(12), GETDATE(), 106) AS Datetime)) GROUP BY Lookup_tblCurrency.CurrencyName, IMIS_tblPurchaseOrderMain.CurrencyID");


                lstSearch.Text = "Search By Date";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (lstSearch.SelectedItem.ToString() == "Search BY OrderNo")
            {
                #region SearchByInvoice
                try
                {
                    TempDt = null;
                    lstSaleView.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT        IMIS_tblPurchaseOrderMain.PurchaseOrderNo, convert(varchar(12),IMIS_tblPurchaseOrderMain.OrderReceivedDate,107) as OrderReceivedDate, IMIS_tblPurchaseOrderMain.SupplierID, IMIS_tblSupplier.SupplierName, IMIS_tblPurchaseOrderMain.InvoiceNo, 
                         IMIS_tblPurchaseOrderMain.PaymentMethod, Lookup_tblCurrency.CurrencyName, IMIS_tblPurchaseOrderMain.ExchangeRate, IMIS_tblPurchaseOrderMain.TotalOrderAmount, IMIS_tblPurchaseOrderMain.TotalShippingCost, 
                         IMIS_tblPurchaseOrderMain.TotalShippingCostBaseCurrency, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyAmount, 
                         IMIS_tblPurchaseOrderMain.AmountPaidToSupplier - ISNULL(IMIS_tblPurchaseOrderMain.CashReturnFromSupplier, 0) AS AmountPaidToSupplier, IMIS_tblPurchaseOrderMain.BalanceAmount, 
                         IMIS_tblPurchaseOrderMain.PaymentStatus, IMIS_tblPurchaseOrderMain.StoreID, CONVERT(varchar(12), IMIS_tblPurchaseOrderMain.SystemDate, 107) AS SystemDate, CONVERT(varchar(5), 
                         IMIS_tblPurchaseOrderMain.SystemTime, 108) AS SystemTime, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyPaidAmount - ISNULL(IMIS_tblPurchaseOrderMain.BaseCurrencyCashReturnFromSupplier, 0) 
                         AS TotalBaseCurrencyPaidAmount, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyBalanceAmount, IMIS_tblPurchaseOrderMain.CashReturnFromSupplier, IMIS_tblPurchaseOrderMain.BaseCurrencyCashReturnFromSupplier, 
                         aspnet_Users.UserName, IMIS_tblPurchaseOrderMain.CurrencyID
FROM            IMIS_tblPurchaseOrderMain INNER JOIN
                         IMIS_tblSupplier ON IMIS_tblPurchaseOrderMain.SupplierID = IMIS_tblSupplier.SupplierID INNER JOIN
                         Lookup_tblCurrency ON IMIS_tblPurchaseOrderMain.CurrencyID = Lookup_tblCurrency.CurrencyID INNER JOIN
                         aspnet_Users ON IMIS_tblPurchaseOrderMain.UserID = aspnet_Users.UserId
						 where IMIS_tblPurchaseOrderMain.StoreID=" + conclass.StoreID + " AND IMIS_tblPurchaseOrderMain.PurchaseOrderNo='" + txt_Invoice.Text + "'");
                    TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["PurchaseOrderNo"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        item.SubItems.Add(dr["SystemTime"].ToString());
                        item.SubItems.Add(dr["SupplierName"].ToString());
                        item.SubItems.Add(dr["TotalOrderAmount"].ToString());
                        item.SubItems.Add(dr["AmountPaidToSupplier"].ToString());
                        item.SubItems.Add(dr["BalanceAmount"].ToString());
                        item.SubItems.Add(dr["CurrencyName"].ToString());
                        item.SubItems.Add(dr["PaymentMethod"].ToString());
                        item.SubItems.Add(dr["UserName"].ToString());
                        lstSaleView.Items.Add(item);
                    }
                    //dt = Class.conclass.GetRecord("select isnull(sum(AveragePrice*Quantity),0),isnull(sum(Quantity),0) as TotalAmount from IMIS_tblStock");
                    //if (dt.Rows.Count > 0)
                    //{
                    //    textBox1.Text = (Math.Round(Decimal.Parse(dt.Rows[0][0].ToString()), 2)).ToString();
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
            }
            if (lstSearch.SelectedItem.ToString() == "Saerch By BillNo")
            {
                #region SearchByInvoice
                try
                {
                    TempDt = null;
                    lstSaleView.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT        IMIS_tblPurchaseOrderMain.PurchaseOrderNo, convert(varchar(12),IMIS_tblPurchaseOrderMain.OrderReceivedDate,107) as OrderReceivedDate, IMIS_tblPurchaseOrderMain.SupplierID, IMIS_tblSupplier.SupplierName, IMIS_tblPurchaseOrderMain.InvoiceNo, 
                         IMIS_tblPurchaseOrderMain.PaymentMethod, Lookup_tblCurrency.CurrencyName, IMIS_tblPurchaseOrderMain.ExchangeRate, IMIS_tblPurchaseOrderMain.TotalOrderAmount, IMIS_tblPurchaseOrderMain.TotalShippingCost, 
                         IMIS_tblPurchaseOrderMain.TotalShippingCostBaseCurrency, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyAmount, 
                         IMIS_tblPurchaseOrderMain.AmountPaidToSupplier - ISNULL(IMIS_tblPurchaseOrderMain.CashReturnFromSupplier, 0) AS AmountPaidToSupplier, IMIS_tblPurchaseOrderMain.BalanceAmount, 
                         IMIS_tblPurchaseOrderMain.PaymentStatus, IMIS_tblPurchaseOrderMain.StoreID, CONVERT(varchar(12), IMIS_tblPurchaseOrderMain.SystemDate, 107) AS SystemDate, CONVERT(varchar(5), 
                         IMIS_tblPurchaseOrderMain.SystemTime, 108) AS SystemTime, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyPaidAmount - ISNULL(IMIS_tblPurchaseOrderMain.BaseCurrencyCashReturnFromSupplier, 0) 
                         AS TotalBaseCurrencyPaidAmount, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyBalanceAmount, IMIS_tblPurchaseOrderMain.CashReturnFromSupplier, IMIS_tblPurchaseOrderMain.BaseCurrencyCashReturnFromSupplier, 
                         aspnet_Users.UserName, IMIS_tblPurchaseOrderMain.CurrencyID
FROM            IMIS_tblPurchaseOrderMain INNER JOIN
                         IMIS_tblSupplier ON IMIS_tblPurchaseOrderMain.SupplierID = IMIS_tblSupplier.SupplierID INNER JOIN
                         Lookup_tblCurrency ON IMIS_tblPurchaseOrderMain.CurrencyID = Lookup_tblCurrency.CurrencyID INNER JOIN
                         aspnet_Users ON IMIS_tblPurchaseOrderMain.UserID = aspnet_Users.UserId
						 where IMIS_tblPurchaseOrderMain.StoreID=" + conclass.StoreID + " AND IMIS_tblPurchaseOrderMain.InvoiceNo='" + txt_Invoice.Text + "'");
                    TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["PurchaseOrderNo"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        item.SubItems.Add(dr["SystemTime"].ToString());
                        item.SubItems.Add(dr["SupplierName"].ToString());
                        item.SubItems.Add(dr["TotalOrderAmount"].ToString());
                        item.SubItems.Add(dr["AmountPaidToSupplier"].ToString());
                        item.SubItems.Add(dr["BalanceAmount"].ToString());
                        item.SubItems.Add(dr["CurrencyName"].ToString());
                        item.SubItems.Add(dr["PaymentMethod"].ToString());
                        item.SubItems.Add(dr["UserName"].ToString());
                        lstSaleView.Items.Add(item);
                    }
                    //dt = Class.conclass.GetRecord("select isnull(sum(AveragePrice*Quantity),0),isnull(sum(Quantity),0) as TotalAmount from IMIS_tblStock");
                    //if (dt.Rows.Count > 0)
                    //{
                    //    textBox1.Text = (Math.Round(Decimal.Parse(dt.Rows[0][0].ToString()), 2)).ToString();
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }


                #endregion
            }
         


            else if (lstSearch.SelectedItem.ToString() == "All")
            {
                #region SearchAll
                try
                {
                    TempDt = null;
                    lstSaleView.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT        IMIS_tblPurchaseOrderMain.PurchaseOrderNo, convert(varchar(12),IMIS_tblPurchaseOrderMain.OrderReceivedDate,107) as OrderReceivedDate, IMIS_tblPurchaseOrderMain.SupplierID, IMIS_tblSupplier.SupplierName, IMIS_tblPurchaseOrderMain.InvoiceNo, 
                         IMIS_tblPurchaseOrderMain.PaymentMethod, Lookup_tblCurrency.CurrencyName, IMIS_tblPurchaseOrderMain.ExchangeRate, IMIS_tblPurchaseOrderMain.TotalOrderAmount, IMIS_tblPurchaseOrderMain.TotalShippingCost, 
                         IMIS_tblPurchaseOrderMain.TotalShippingCostBaseCurrency, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyAmount, 
                         IMIS_tblPurchaseOrderMain.AmountPaidToSupplier - ISNULL(IMIS_tblPurchaseOrderMain.CashReturnFromSupplier, 0) AS AmountPaidToSupplier, IMIS_tblPurchaseOrderMain.BalanceAmount, 
                         IMIS_tblPurchaseOrderMain.PaymentStatus, IMIS_tblPurchaseOrderMain.StoreID, CONVERT(varchar(12), IMIS_tblPurchaseOrderMain.SystemDate, 107) AS SystemDate, CONVERT(varchar(5), 
                         IMIS_tblPurchaseOrderMain.SystemTime, 108) AS SystemTime, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyPaidAmount - ISNULL(IMIS_tblPurchaseOrderMain.BaseCurrencyCashReturnFromSupplier, 0) 
                         AS TotalBaseCurrencyPaidAmount, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyBalanceAmount, IMIS_tblPurchaseOrderMain.CashReturnFromSupplier, IMIS_tblPurchaseOrderMain.BaseCurrencyCashReturnFromSupplier, 
                         aspnet_Users.UserName, IMIS_tblPurchaseOrderMain.CurrencyID
FROM            IMIS_tblPurchaseOrderMain INNER JOIN
                         IMIS_tblSupplier ON IMIS_tblPurchaseOrderMain.SupplierID = IMIS_tblSupplier.SupplierID INNER JOIN
                         Lookup_tblCurrency ON IMIS_tblPurchaseOrderMain.CurrencyID = Lookup_tblCurrency.CurrencyID INNER JOIN
                         aspnet_Users ON IMIS_tblPurchaseOrderMain.UserID = aspnet_Users.UserId
						 where IMIS_tblPurchaseOrderMain.StoreID=" + conclass.StoreID + " order by IMIS_tblPurchaseOrderMain.PurchaseOrderNo ");
                    TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["PurchaseOrderNo"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        item.SubItems.Add(dr["SystemTime"].ToString());
                        item.SubItems.Add(dr["SupplierName"].ToString());
                        item.SubItems.Add(dr["TotalOrderAmount"].ToString());
                        item.SubItems.Add(dr["AmountPaidToSupplier"].ToString());
                        item.SubItems.Add(dr["BalanceAmount"].ToString());
                        item.SubItems.Add(dr["CurrencyName"].ToString());
                        item.SubItems.Add(dr["PaymentMethod"].ToString());
                        item.SubItems.Add(dr["UserName"].ToString());
                        lstSaleView.Items.Add(item);
                    }

                    grdSummaryByCurrency.DataSource = obj.GetData(@"SELECT     IMIS_tblPurchaseOrderMain.CurrencyID,Lookup_tblCurrency.CurrencyName,
sum(IMIS_tblPurchaseOrderMain.TotalOrderAmount) as TotalOrderAmount,'Print Report' as Report
FROM            IMIS_tblPurchaseOrderMain INNER JOIN
                         Lookup_tblCurrency ON IMIS_tblPurchaseOrderMain.CurrencyID = Lookup_tblCurrency.CurrencyID
                        group by Lookup_tblCurrency.CurrencyName, IMIS_tblPurchaseOrderMain.CurrencyID");




                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
            }
            else if (lstSearch.SelectedItem.ToString() == "By Supplier")
            {
                #region By Supplier
                try
                {
                    TempDt = null;
                    lstSaleView.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT        IMIS_tblPurchaseOrderMain.PurchaseOrderNo, convert(varchar(12),IMIS_tblPurchaseOrderMain.OrderReceivedDate,107) as OrderReceivedDate, IMIS_tblPurchaseOrderMain.SupplierID, IMIS_tblSupplier.SupplierName, IMIS_tblPurchaseOrderMain.InvoiceNo, 
                         IMIS_tblPurchaseOrderMain.PaymentMethod, Lookup_tblCurrency.CurrencyName, IMIS_tblPurchaseOrderMain.ExchangeRate, IMIS_tblPurchaseOrderMain.TotalOrderAmount, IMIS_tblPurchaseOrderMain.TotalShippingCost, 
                         IMIS_tblPurchaseOrderMain.TotalShippingCostBaseCurrency, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyAmount, 
                         IMIS_tblPurchaseOrderMain.AmountPaidToSupplier - ISNULL(IMIS_tblPurchaseOrderMain.CashReturnFromSupplier, 0) AS AmountPaidToSupplier, IMIS_tblPurchaseOrderMain.BalanceAmount, 
                         IMIS_tblPurchaseOrderMain.PaymentStatus, IMIS_tblPurchaseOrderMain.StoreID, CONVERT(varchar(12), IMIS_tblPurchaseOrderMain.SystemDate, 107) AS SystemDate, CONVERT(varchar(5), 
                         IMIS_tblPurchaseOrderMain.SystemTime, 108) AS SystemTime, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyPaidAmount - ISNULL(IMIS_tblPurchaseOrderMain.BaseCurrencyCashReturnFromSupplier, 0) 
                         AS TotalBaseCurrencyPaidAmount, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyBalanceAmount, IMIS_tblPurchaseOrderMain.CashReturnFromSupplier, IMIS_tblPurchaseOrderMain.BaseCurrencyCashReturnFromSupplier, 
                         aspnet_Users.UserName, IMIS_tblPurchaseOrderMain.CurrencyID
FROM            IMIS_tblPurchaseOrderMain INNER JOIN
                         IMIS_tblSupplier ON IMIS_tblPurchaseOrderMain.SupplierID = IMIS_tblSupplier.SupplierID INNER JOIN
                         Lookup_tblCurrency ON IMIS_tblPurchaseOrderMain.CurrencyID = Lookup_tblCurrency.CurrencyID INNER JOIN
                         aspnet_Users ON IMIS_tblPurchaseOrderMain.UserID = aspnet_Users.UserId
						 where IMIS_tblPurchaseOrderMain.StoreID=" + conclass.StoreID + " and IMIS_tblSupplier.SupplierName like N'%" + txt_Invoice.Text + "%' order by IMIS_tblPurchaseOrderMain.PurchaseOrderNo ");
                    TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["PurchaseOrderNo"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        item.SubItems.Add(dr["SystemTime"].ToString());
                        item.SubItems.Add(dr["SupplierName"].ToString());
                        item.SubItems.Add(dr["TotalOrderAmount"].ToString());
                        item.SubItems.Add(dr["AmountPaidToSupplier"].ToString());
                        item.SubItems.Add(dr["BalanceAmount"].ToString());
                        item.SubItems.Add(dr["CurrencyName"].ToString());
                        item.SubItems.Add(dr["PaymentMethod"].ToString());
                        item.SubItems.Add(dr["UserName"].ToString());
                        lstSaleView.Items.Add(item);
                    }

                    grdSummaryByCurrency.DataSource = obj.GetData(@"SELECT        IMIS_tblPurchaseOrderMain.CurrencyID, Lookup_tblCurrency.CurrencyName, SUM(IMIS_tblPurchaseOrderMain.TotalOrderAmount) AS TotalOrderAmount, 'Print Report' AS Report
FROM            IMIS_tblPurchaseOrderMain INNER JOIN
                         Lookup_tblCurrency ON IMIS_tblPurchaseOrderMain.CurrencyID = Lookup_tblCurrency.CurrencyID INNER JOIN
                         IMIS_tblSupplier ON IMIS_tblPurchaseOrderMain.SupplierID = IMIS_tblSupplier.SupplierID
						 where IMIS_tblSupplier.SupplierName like N'%" + txt_Invoice.Text + "%' GROUP BY Lookup_tblCurrency.CurrencyName, IMIS_tblPurchaseOrderMain.CurrencyID");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
            }
            else if (lstSearch.SelectedItem.ToString() == "By Supplier & Date")
            {
                # region Search By Date and Supplier
                string from = this.dtfrom.Value.ToString("yyyy-MM-dd");
                string to = this.dtto.Value.ToString("yyyy-MM-dd");
                try
                {
                    TempDt = null;
                    lstSaleView.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT        IMIS_tblPurchaseOrderMain.PurchaseOrderNo, convert(varchar(12),IMIS_tblPurchaseOrderMain.OrderReceivedDate,107) as OrderReceivedDate, IMIS_tblPurchaseOrderMain.SupplierID, IMIS_tblSupplier.SupplierName, IMIS_tblPurchaseOrderMain.InvoiceNo, 
                         IMIS_tblPurchaseOrderMain.PaymentMethod, Lookup_tblCurrency.CurrencyName, IMIS_tblPurchaseOrderMain.ExchangeRate, IMIS_tblPurchaseOrderMain.TotalOrderAmount, IMIS_tblPurchaseOrderMain.TotalShippingCost, 
                         IMIS_tblPurchaseOrderMain.TotalShippingCostBaseCurrency, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyAmount, 
                         IMIS_tblPurchaseOrderMain.AmountPaidToSupplier - ISNULL(IMIS_tblPurchaseOrderMain.CashReturnFromSupplier, 0) AS AmountPaidToSupplier, IMIS_tblPurchaseOrderMain.BalanceAmount, 
                         IMIS_tblPurchaseOrderMain.PaymentStatus, IMIS_tblPurchaseOrderMain.StoreID, CONVERT(varchar(12), IMIS_tblPurchaseOrderMain.SystemDate, 107) AS SystemDate, CONVERT(varchar(5), 
                         IMIS_tblPurchaseOrderMain.SystemTime, 108) AS SystemTime, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyPaidAmount - ISNULL(IMIS_tblPurchaseOrderMain.BaseCurrencyCashReturnFromSupplier, 0) 
                         AS TotalBaseCurrencyPaidAmount, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyBalanceAmount, IMIS_tblPurchaseOrderMain.CashReturnFromSupplier, IMIS_tblPurchaseOrderMain.BaseCurrencyCashReturnFromSupplier, 
                         aspnet_Users.UserName, IMIS_tblPurchaseOrderMain.CurrencyID
FROM            IMIS_tblPurchaseOrderMain INNER JOIN
                         IMIS_tblSupplier ON IMIS_tblPurchaseOrderMain.SupplierID = IMIS_tblSupplier.SupplierID INNER JOIN
                         Lookup_tblCurrency ON IMIS_tblPurchaseOrderMain.CurrencyID = Lookup_tblCurrency.CurrencyID INNER JOIN
                         aspnet_Users ON IMIS_tblPurchaseOrderMain.UserID = aspnet_Users.UserId
						 where IMIS_tblPurchaseOrderMain.StoreID=" + conclass.StoreID + "  and    OrderReceivedDate >= CAST('" + from + "' AS DATETIME) AND OrderReceivedDate <= CAST('" + to + "' AS DATETIME)  and IMIS_tblPurchaseOrderMain.StoreID=" + conclass.StoreID + " and IMIS_tblSupplier.SupplierName like N'%" + txt_Invoice.Text + "%' order by IMIS_tblPurchaseOrderMain.PurchaseOrderNo ");
                    TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["PurchaseOrderNo"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        item.SubItems.Add(dr["SystemTime"].ToString());
                        item.SubItems.Add(dr["SupplierName"].ToString());
                        item.SubItems.Add(dr["TotalOrderAmount"].ToString());
                        item.SubItems.Add(dr["AmountPaidToSupplier"].ToString());
                        item.SubItems.Add(dr["BalanceAmount"].ToString());
                        item.SubItems.Add(dr["CurrencyName"].ToString());
                        item.SubItems.Add(dr["PaymentMethod"].ToString());
                        item.SubItems.Add(dr["UserName"].ToString());
                        lstSaleView.Items.Add(item);
                    }


                    grdSummaryByCurrency.DataSource = obj.GetData(@"SELECT        IMIS_tblPurchaseOrderMain.CurrencyID, Lookup_tblCurrency.CurrencyName, SUM(IMIS_tblPurchaseOrderMain.TotalOrderAmount) AS TotalOrderAmount, 'Print Report' AS Report
FROM            IMIS_tblPurchaseOrderMain INNER JOIN
                         Lookup_tblCurrency ON IMIS_tblPurchaseOrderMain.CurrencyID = Lookup_tblCurrency.CurrencyID INNER JOIN
                         IMIS_tblSupplier ON IMIS_tblPurchaseOrderMain.SupplierID = IMIS_tblSupplier.SupplierID
						 where IMIS_tblSupplier.SupplierName like N'%" + txt_Invoice.Text + "%' and OrderReceivedDate >= CAST('" + from + "' AS DATETIME) AND OrderReceivedDate <= CAST('" + to + "' AS DATETIME) GROUP BY Lookup_tblCurrency.CurrencyName, IMIS_tblPurchaseOrderMain.CurrencyID");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
            }
            else if (lstSearch.SelectedItem.ToString() == "Search By Date")
            {
                # region Search By Date
                string from = this.dtfrom.Value.ToString("yyyy-MM-dd");
                string to = this.dtto.Value.ToString("yyyy-MM-dd");
                try
                {
                    TempDt = null;
                    lstSaleView.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT        IMIS_tblPurchaseOrderMain.PurchaseOrderNo, convert(varchar(12),IMIS_tblPurchaseOrderMain.OrderReceivedDate,107) as OrderReceivedDate, IMIS_tblPurchaseOrderMain.SupplierID, IMIS_tblSupplier.SupplierName, IMIS_tblPurchaseOrderMain.InvoiceNo, 
                         IMIS_tblPurchaseOrderMain.PaymentMethod, Lookup_tblCurrency.CurrencyName, IMIS_tblPurchaseOrderMain.ExchangeRate, IMIS_tblPurchaseOrderMain.TotalOrderAmount, IMIS_tblPurchaseOrderMain.TotalShippingCost, 
                         IMIS_tblPurchaseOrderMain.TotalShippingCostBaseCurrency, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyAmount, 
                         IMIS_tblPurchaseOrderMain.AmountPaidToSupplier - ISNULL(IMIS_tblPurchaseOrderMain.CashReturnFromSupplier, 0) AS AmountPaidToSupplier, IMIS_tblPurchaseOrderMain.BalanceAmount, 
                         IMIS_tblPurchaseOrderMain.PaymentStatus, IMIS_tblPurchaseOrderMain.StoreID, CONVERT(varchar(12), IMIS_tblPurchaseOrderMain.SystemDate, 107) AS SystemDate, CONVERT(varchar(5), 
                         IMIS_tblPurchaseOrderMain.SystemTime, 108) AS SystemTime, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyPaidAmount - ISNULL(IMIS_tblPurchaseOrderMain.BaseCurrencyCashReturnFromSupplier, 0) 
                         AS TotalBaseCurrencyPaidAmount, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyBalanceAmount, IMIS_tblPurchaseOrderMain.CashReturnFromSupplier, IMIS_tblPurchaseOrderMain.BaseCurrencyCashReturnFromSupplier, 
                         aspnet_Users.UserName, IMIS_tblPurchaseOrderMain.CurrencyID
FROM            IMIS_tblPurchaseOrderMain INNER JOIN
                         IMIS_tblSupplier ON IMIS_tblPurchaseOrderMain.SupplierID = IMIS_tblSupplier.SupplierID INNER JOIN
                         Lookup_tblCurrency ON IMIS_tblPurchaseOrderMain.CurrencyID = Lookup_tblCurrency.CurrencyID INNER JOIN
                         aspnet_Users ON IMIS_tblPurchaseOrderMain.UserID = aspnet_Users.UserId
						 where IMIS_tblPurchaseOrderMain.StoreID=" + conclass.StoreID + "  and OrderReceivedDate >= CAST('" + from + "' AS DATETIME) AND OrderReceivedDate <= CAST('" + to + "' AS DATETIME) and IMIS_tblPurchaseOrderMain.StoreID=" + conclass.StoreID + " order by IMIS_tblPurchaseOrderMain.PurchaseOrderNo ");
                    TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["PurchaseOrderNo"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        item.SubItems.Add(dr["SystemTime"].ToString());
                        item.SubItems.Add(dr["SupplierName"].ToString());
                        item.SubItems.Add(dr["TotalOrderAmount"].ToString());
                        item.SubItems.Add(dr["AmountPaidToSupplier"].ToString());
                        item.SubItems.Add(dr["BalanceAmount"].ToString());
                        item.SubItems.Add(dr["CurrencyName"].ToString());
                        item.SubItems.Add(dr["PaymentMethod"].ToString());
                        item.SubItems.Add(dr["UserName"].ToString());
                        lstSaleView.Items.Add(item);
                    }
                    grdSummaryByCurrency.DataSource = obj.GetData(@"SELECT        IMIS_tblPurchaseOrderMain.CurrencyID, Lookup_tblCurrency.CurrencyName, SUM(IMIS_tblPurchaseOrderMain.TotalOrderAmount) AS TotalOrderAmount, 'Print Report' AS Report
FROM            IMIS_tblPurchaseOrderMain INNER JOIN
                         Lookup_tblCurrency ON IMIS_tblPurchaseOrderMain.CurrencyID = Lookup_tblCurrency.CurrencyID INNER JOIN
                         IMIS_tblSupplier ON IMIS_tblPurchaseOrderMain.SupplierID = IMIS_tblSupplier.SupplierID
						 where OrderReceivedDate >= CAST('" + from + "' AS DATETIME) AND OrderReceivedDate <= CAST('" + to + "' AS DATETIME) GROUP BY Lookup_tblCurrency.CurrencyName, IMIS_tblPurchaseOrderMain.CurrencyID");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
            }
        }
        private void frmPurchaseReport_Load(object sender, EventArgs e)
        {
            FillTodayPurchase();
        }
        Dbcommon obj = new Dbcommon();
        private void lstSaleView_DoubleClick(object sender, EventArgs e)
        {
            lblInvoiceNo.Text = lstSaleView.SelectedItems[0].SubItems[0].Text;
            DataTable dt = obj.GetData(@"SELECT        IMIS_VWProducts.ProductName, IMIS_tblPurchaseOrderDetail.ProductCode, IMIS_tblPurchaseOrderDetail.BatchNo, CONVERT (varchar(12), ExpiryDate, 106) as ExpiryDate, IMIS_tblPurchaseOrderDetail.PurchasePrice, 
                         IMIS_tblPurchaseOrderDetail.Quantity, IMIS_tblPurchaseOrderDetail.Total, IMIS_tblPurchaseOrderDetail.Status
FROM            IMIS_VWProducts INNER JOIN
                         IMIS_tblPurchaseOrderDetail ON IMIS_VWProducts.ProductCode = IMIS_tblPurchaseOrderDetail.ProductCode
						 where Status in ('Purchased', 'Quantity Returned') AND PurchaseOrderNo = '" + lblInvoiceNo.Text + "'");
            lstInvoiceDetail.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                item.SubItems.Add(dr["ProductName"].ToString());
                item.SubItems.Add(dr["BatchNo"].ToString());
                item.SubItems.Add(dr["ExpiryDate"].ToString());
                item.SubItems.Add(dr["Quantity"].ToString());
                item.SubItems.Add(dr["PurchasePrice"].ToString());
                item.SubItems.Add(dr["Total"].ToString());
                lstInvoiceDetail.Items.Add(item);
            }
            pnlProduct.Visible = true;
            pnlProduct.BringToFront();

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlProduct.Visible = false;
            pnlProduct.SendToBack();
        }
        private void lstSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSearch.SelectedItem.ToString() == "Search BY OrderNo")
            {
                gpdate.Enabled = false;
                gpinvioce.Enabled = true;
                txt_Invoice.Focus();
                btnSearch.Enabled = true;
            }
            if (lstSearch.SelectedItem.ToString() == "Saerch By BillNo")
            {
                gpdate.Enabled = false;
                gpinvioce.Enabled = true;
                txt_Invoice.Focus();
                btnSearch.Enabled = true;
            }
            else if (lstSearch.SelectedItem.ToString() == "Search By Date")
            {
                gpdate.Enabled = true;
                gpinvioce.Enabled = false;
            }
            else if (lstSearch.SelectedItem.ToString() == "By Supplier & Date")
            {
                gpdate.Enabled = true;
                gpinvioce.Enabled = true;
                txt_Invoice.Focus();
            }
            else if (lstSearch.SelectedItem.ToString() == "By Supplier")
            {
                gpdate.Enabled = false;
                gpinvioce.Enabled = true;
                txt_Invoice.Focus();
                btnSearch.Enabled = true;
            }
            else if (lstSearch.SelectedItem.ToString() == "All")
            {
                gpinvioce.Enabled = false;
                gpdate.Enabled = false;
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {

        }

        private void grdSummaryByCurrency_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dtnew = new DataTable();
            if (grdSummaryByCurrency.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Print Report")
            {
                string CID = grdSummaryByCurrency.Rows[e.RowIndex].Cells[0].Value.ToString();
                DataRow[] filteredRows = TempDt.Select("CurrencyID=" + CID);
                dtnew = filteredRows.CopyToDataTable();
            }
            ParameterFields paramFields = new ParameterFields();
            ParameterField ParaFromDate = new ParameterField();
            ParameterField ParaToDate = new ParameterField();
            ParameterDiscreteValue FromValue = new ParameterDiscreteValue();
            ParameterDiscreteValue ToValue = new ParameterDiscreteValue();
            ParaFromDate.ParameterFieldName = "FromDate";
            ParaToDate.ParameterFieldName = "ToDate";
            // Set the discrete value and pass it to the parameter
            if (lstSearch.SelectedItem.ToString() == "By Supplier & Date" || lstSearch.SelectedItem.ToString() == "Search By Date")
            {
                FromValue.Value = dtfrom.Value.ToString("dd/MM/yyyy");
                ToValue.Value = dtto.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                FromValue.Value = "";
                ToValue.Value = "";
            }
            ParaFromDate.CurrentValues.Add(FromValue);
            ParaToDate.CurrentValues.Add(ToValue);
            // Add parameter to the parameter fields collection.
            paramFields.Add(ParaFromDate);
            paramFields.Add(ParaToDate);
            Reports.rptPurchaseOrderMain obj = new Stock_System.Reports.rptPurchaseOrderMain();
            obj.SetDataSource(dtnew);
            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;
            frm2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //frm2.crystalReportViewer1.PrintReport();
            frm2.ShowDialog();
        }
    }
}
