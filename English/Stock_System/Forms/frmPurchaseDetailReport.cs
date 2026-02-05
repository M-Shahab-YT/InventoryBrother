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
    public partial class frmPurchaseDetailReport : Form
    {
        public frmPurchaseDetailReport()
        {
            InitializeComponent();
        }
        DataTable TempDt = new DataTable();
        private void lstSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (lstSearch.SelectedItem.ToString() == "Search By Date")
            {
                gpdate.Enabled = true;
                gpinvioce.Enabled = false;
            }
            if (lstSearch.SelectedItem.ToString() == "Search By Item & Date")
            {
                gpdate.Enabled = true;
                gpinvioce.Enabled = true;
                txt_Invoice.Focus();
            }
            else if (lstSearch.SelectedItem.ToString() == "Search By Bill No")
            {
                gpdate.Enabled = false;
                gpinvioce.Enabled = true;
                txt_Invoice.Focus();
            }
            else if (lstSearch.SelectedItem.ToString() == "Search By Supplier and Date")
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
                //string from = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
                //string to = this.dtto.Value.Month.ToString() + "/" + this.dtto.Value.Day.ToString() + "/" + this.dtto.Value.Year.ToString();
                string from = this.dtfrom.Value.ToString("yyyy-MM-dd");
                string to = this.dtto.Value.ToString("yyyy-MM-dd");
                try
                {
                    TempDt = null;
                    lstInvoiceDetail.Items.Clear();
                    DataTable dt = new DataTable();

                    string queryString = @"SELECT InvoiceNo, SupplierID, SupplierName, SystemDate, CurrencyName, ProductCode, ProductName, BatchNo, ExpiryDate,  PurchasePrice, Quantity, Total, 
                    PurchaseOrderNo     FROM VW_PurchaseDetail WHERE SystemDate >= CAST('" + from + "' AS DATETIME) AND SystemDate <= CAST('" + to + "' AS DATETIME)     ORDER BY PurchaseOrderNo";

                    dt = Class.conclass.GetRecord(queryString); 
                    TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["InvoiceNo"].ToString());
                        item.SubItems.Add(dr["SupplierID"].ToString());
                        item.SubItems.Add(dr["SupplierName"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        item.SubItems.Add(dr["CurrencyName"].ToString());
                        item.SubItems.Add(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["BatchNo"].ToString());
                        item.SubItems.Add(dr["ExpiryDate"].ToString());
                        item.SubItems.Add(dr["PurchasePrice"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["Total"].ToString());
                        TotalSalesValue = TotalSalesValue + Decimal.Parse(dr["Total"].ToString());
                        TotalQty = TotalQty + Decimal.Parse(dr["Quantity"].ToString());
                        lstInvoiceDetail.Items.Add(item);
                    }
                  
                    txtTotalSaleValue.Text = TotalSalesValue.ToString();
                    txtTotalQty.Text = TotalQty.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                #endregion
            }
            else if (lstSearch.SelectedItem.ToString() == "Search By Item & Date")
            {
                TotalSalesValue = 0;
                TotalProfitValue = 0;
                # region Search By Item & Date
                //string from = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
                //string to = this.dtto.Value.Month.ToString() + "/" + this.dtto.Value.Day.ToString() + "/" + this.dtto.Value.Year.ToString();
                string from = this.dtfrom.Value.ToString("yyyy-MM-dd");
                string to = this.dtto.Value.ToString("yyyy-MM-dd");
                try
                {
                    TempDt = null;
                    lstInvoiceDetail.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT InvoiceNo, SupplierID, SupplierName, SystemDate, CurrencyName, ProductCode, ProductName, BatchNo, ExpiryDate,  PurchasePrice, Quantity, Total, 
                    PurchaseOrderNo     FROM VW_PurchaseDetail WHERE SystemDate >= CAST('" + from + "' AS DATETIME) AND SystemDate <= CAST('" + to + "' AS DATETIME) and ProductName like N'%" + txt_Invoice.Text.Trim()+"%' order by PurchaseOrderNo ");
                    TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["InvoiceNo"].ToString());
                        item.SubItems.Add(dr["SupplierID"].ToString());
                        item.SubItems.Add(dr["SupplierName"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        item.SubItems.Add(dr["CurrencyName"].ToString());
                        item.SubItems.Add(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["BatchNo"].ToString());
                        item.SubItems.Add(dr["ExpiryDate"].ToString());
                        item.SubItems.Add(dr["PurchasePrice"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["Total"].ToString());
                        TotalSalesValue = TotalSalesValue + Decimal.Parse(dr["Total"].ToString());
                        TotalQty = TotalQty + Decimal.Parse(dr["Quantity"].ToString());
                        lstInvoiceDetail.Items.Add(item);
                    }
                    txtTotalSaleValue.Text = TotalSalesValue.ToString();
                    txtTotalQty.Text = TotalQty.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
            }
            else if (lstSearch.SelectedItem.ToString() == "Search By Bill No")
            {
                TotalSalesValue = 0;
                TotalProfitValue = 0;
                # region Search By Bill No
                try
                {
                    TempDt = null;
                    lstInvoiceDetail.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT  InvoiceNo, SupplierID, SupplierName, SystemDate, CurrencyName, ProductCode, ProductName, BatchNo, ExpiryDate, PurchasePrice, Quantity, Total, PurchaseOrderNo FROM   VW_PurchaseDetail where InvoiceNo='"+txt_Invoice.Text.Trim()+"'");
                    TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["InvoiceNo"].ToString());
                        item.SubItems.Add(dr["SupplierID"].ToString());
                        item.SubItems.Add(dr["SupplierName"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        item.SubItems.Add(dr["CurrencyName"].ToString());
                        item.SubItems.Add(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["BatchNo"].ToString());
                        item.SubItems.Add(dr["ExpiryDate"].ToString());
                        item.SubItems.Add(dr["PurchasePrice"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["Total"].ToString());
                        TotalSalesValue = TotalSalesValue + Decimal.Parse(dr["Total"].ToString());
                        TotalQty = TotalQty + Decimal.Parse(dr["Quantity"].ToString());
                        lstInvoiceDetail.Items.Add(item);
                    }
                    txtTotalSaleValue.Text = TotalSalesValue.ToString();
                    txtTotalQty.Text = TotalQty.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
            }
            else if (lstSearch.SelectedItem.ToString() == "Search By Supplier and Date")
            {
                TotalSalesValue = 0;
                TotalProfitValue = 0;
                # region Search By Supplier and Date
                string from = this.dtfrom.Value.ToString("yyyy-MM-dd");
                string to = this.dtto.Value.ToString("yyyy-MM-dd");
                try
                {
                    TempDt = null;
                    lstInvoiceDetail.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"
SELECT        InvoiceNo, SupplierID, SupplierName, SystemDate, CurrencyName, ProductCode, ProductName, BatchNo, ExpiryDate, PurchasePrice, Quantity, Total, PurchaseOrderNo
FROM            VW_PurchaseDetail
						 where SupplierName like N'%" + txt_Invoice.Text.Trim() + "%' and SystemDate >= CAST('" + from + "' AS DATETIME) AND SystemDate <= CAST('" + to + "' AS DATETIME)  order by PurchaseOrderNo ");
                    TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["InvoiceNo"].ToString());
                        item.SubItems.Add(dr["SupplierID"].ToString());
                        item.SubItems.Add(dr["SupplierName"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        item.SubItems.Add(dr["CurrencyName"].ToString());
                        item.SubItems.Add(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["BatchNo"].ToString());
                        item.SubItems.Add(dr["ExpiryDate"].ToString());
                        item.SubItems.Add(dr["PurchasePrice"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["Total"].ToString());
                        TotalSalesValue = TotalSalesValue + Decimal.Parse(dr["Total"].ToString());
                        TotalQty = TotalQty + Decimal.Parse(dr["Quantity"].ToString());
                        lstInvoiceDetail.Items.Add(item);
                    }
                    txtTotalSaleValue.Text = TotalSalesValue.ToString();
                    txtTotalQty.Text = TotalQty.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                #endregion
            }
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = TempDt;
            Reports.rptPurchaseDetailReport obj = new Stock_System.Reports.rptPurchaseDetailReport();
            obj.SetDataSource(dt);
            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;
            //frm2.crystalReportViewer1.PrintReport();
            frm2.ShowDialog();
        }
    }
}
