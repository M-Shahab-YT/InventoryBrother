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
using System.Drawing.Printing;
using System.Data.SqlClient;
namespace Stock_System.Forms
{
   
    public partial class frmSaleReport : Telerik.WinControls.UI.RadForm
    {
        DataTable TempDt = new DataTable();
        Dbcommon obj = new Dbcommon();
        Decimal TotalSaleValue = 0;
        Decimal TotalProfitValue = 0;
        public frmSaleReport()
        {
            InitializeComponent();
        }
        private void frmSaleReport_Load(object sender, EventArgs e)
        {
            //FillTodaySale();
            //Search By Date
            lstSearch.Text = "Search By Date";
        }
        #region New Functions
        // Function to get sales and returns data table
        public DataTable GetSalesAndReturns(
     DateTime fromDate,
     DateTime toDate,
     string customerID,
     string customerName,
     string invoiceNo,
     string userName)
        {
            // Base select queries for sales and returns
            string baseSaleQuery = "SELECT " +
                "CONVERT(VARCHAR(12), SOM.SaleOrderDate, 107) AS [Date], " +
                "SOM.SaleOrderTime AS [Time], " +
                "SOM.InvoiceNo, " +
                "SOM.CustomerID, " +
                "C.CustomerName, " +
                "U.FullName AS EnteredBy, " +
                "SOM.TotalBaseCurrencyAmount AS TotalAmount, " +
                "SOM.TotalBaseCurrencyPaidAmount AS PaidAmount, " +
                "SOM.TotalBaseCurrencyBalanceAmount AS BalanceAmount, " +
                "'Sale' AS Status " +
                "FROM IMIS_tblSaleOrderMain SOM " +
                "LEFT JOIN aspnet_Users U ON SOM.UserID = U.UserId " +
                "LEFT JOIN IMIS_tblCustomer C ON SOM.CustomerID = C.CustomerID " +
                "WHERE 1=1 ";

            string baseReturnQuery = "SELECT " +
                "CONVERT(VARCHAR(12), CAST(SRM.SaleReturnDate AS DATE), 107) AS [Date], " +
                "CONVERT(VARCHAR(8), SRM.SaleReturnDate, 108) AS [Time], " +
                "CAST(SRD.SaleReturnID AS VARCHAR) AS InvoiceNo, " +
                "SRM.CustomerID, " +
                "C.CustomerName, " +
                "U.FullName AS EnteredBy, " +
                "SUM(SRD.ReturnAmount) * -1 AS TotalAmount, " +
                "0 AS PaidAmount, " +
                "0 AS BalanceAmount, " +
                "'Return' AS Status " +
                "FROM SaleReturnMain SRM " +
                "INNER JOIN SaleReturnDetail SRD ON SRM.SaleReturnID = SRD.SaleReturnID " +
                "LEFT JOIN aspnet_Users U ON SRM.SaleReturnBy = U.UserId " +
                "LEFT JOIN IMIS_tblCustomer C ON SRM.CustomerID = C.CustomerID " +
                "WHERE 1=1 ";

            // Build WHERE clauses
            string saleWhere = "";
            string returnWhere = "";

            List<SqlParameter> parameters = new List<SqlParameter>();

            // Date range condition (always required)
            saleWhere += " AND CAST(CONVERT(VARCHAR(10), SOM.SaleOrderDate, 120) + ' ' + CONVERT(VARCHAR(8), SOM.SaleOrderTime, 108) AS DATETIME) >= @fromDate";
            saleWhere += " AND CAST(CONVERT(VARCHAR(10), SOM.SaleOrderDate, 120) + ' ' + CONVERT(VARCHAR(8), SOM.SaleOrderTime, 108) AS DATETIME) <= @toDate";

            returnWhere += " AND SRM.SaleReturnDate >= @fromDate";
            returnWhere += " AND SRM.SaleReturnDate <= @toDate";

            parameters.Add(new SqlParameter("@fromDate", fromDate));
            parameters.Add(new SqlParameter("@toDate", toDate));

            // Customer ID filter
            if (!string.IsNullOrEmpty(customerID))
            {
                saleWhere += " AND SOM.CustomerID = @customerID";
                returnWhere += " AND SRM.CustomerID = @customerID";
                parameters.Add(new SqlParameter("@customerID", customerID));
            }

            // Customer Name filter (LIKE %name%)
            if (!string.IsNullOrEmpty(customerName))
            {
                saleWhere += " AND C.CustomerName LIKE @customerName";
                returnWhere += " AND C.CustomerName LIKE @customerName";
                parameters.Add(new SqlParameter("@customerName", "%" + customerName + "%"));
            }

            // Invoice No filter
            if (!string.IsNullOrEmpty(invoiceNo))
            {
                saleWhere += " AND SOM.InvoiceNo = @invoiceNo";
                returnWhere += " AND CAST(SRD.SaleReturnID AS VARCHAR) = @invoiceNo";
                parameters.Add(new SqlParameter("@invoiceNo", invoiceNo));
            }

            // User name filter (LIKE %user%)
            if (!string.IsNullOrEmpty(userName))
            {
                saleWhere += " AND U.FullName LIKE @userName";
                returnWhere += " AND U.FullName LIKE @userName";
                parameters.Add(new SqlParameter("@userName", "%" + userName + "%"));
            }

            // Complete queries
            string saleQuery = baseSaleQuery + saleWhere;
            string returnQuery = baseReturnQuery + returnWhere +
                " GROUP BY SRD.SaleReturnID, SRM.SaleReturnDate, SRM.CustomerID, C.CustomerName, U.FullName";

            // Combine with UNION ALL and order result
            string finalQuery =
                "SELECT * FROM ( " +
                saleQuery + " UNION ALL " + returnQuery +
                " ) AS CombinedResults ORDER BY [Date], [Time]";

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand(finalQuery, con))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                try
                {
                    con.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    // handle error (log or rethrow)
                    throw;
                }
            }

            return dt;
        }


        private void PrintSaleReturn(string SaleReturnID, bool PageSize, int Qty)
        {

            //DataTable dtPrinter = conclass.GetRecord(@"SELECT   LaserPrinterName, TerminalPrinterName, ShowPrintPreview FROM IMIS_tblPrinterSetting where UserID='" + conclass.User_ID + "'");
            //if (dtPrinter.Rows.Count > 0)
            //{
            DataTable dt = new DataTable();
            dt = conclass.GetRecord(@"SELECT       CONVERT(VARCHAR(20), SaleReturnID) AS SaleReturnID, CONVERT(VARCHAR(12), CustomerID) AS CustomerID, TotalReturnAmount, SaleReturnBy, SaleReturnDate, ProductName, ReturnQuantity, ReturnAmount, FullName, CustomerName, MobileNumber, InvoiceNo, StoreName, StoreNameLocal, Address, 
                         AddressLocal, BusinessLogo, ContactNumber1, ContactNumber2
FROM            VW_SaleReturn where SaleReturnID=" + SaleReturnID + "");
            if (PageSize == false)
            {
                PrinterSettings settings = new PrinterSettings();
                Reports.SaleRetrun obj = new Stock_System.Reports.SaleRetrun();
                obj.SetDataSource(dt);
                Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
                obj.PrintOptions.PrinterName = settings.PrinterName.ToString();
                obj.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                frm2.crystalReportViewer1.ReportSource = obj;
                obj.PrintToPrinter(Qty, false, 0, 0);
               // frm2.ShowDialog();

            }
        }


        #endregion 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //DateTime from = dtfrom.Value;
            //DateTime to = dtto.Value;
            DateTime from = new DateTime(dtfrom.Value.Year, dtfrom.Value.Month, dtfrom.Value.Day, dtfrom.Value.Hour, dtfrom.Value.Minute, 0);
            DateTime to = new DateTime(dtto.Value.Year, dtto.Value.Month, dtto.Value.Day, dtto.Value.Hour, dtto.Value.Minute, 0);
            string custID = "";
            string custName = "";
            string invoiceNo = "";
            string userName = "";
            if (lstSearch.SelectedItem == "")
            {
                MessageBox.Show("Chose Search Option");
                return;
            }
            string searchBy = lstSearch.SelectedItem.ToString();

            if (searchBy == "By Customer & Date")
            {
                custName = txt_Invoice.Text.Trim();
            }
            else if (searchBy == "By Customer ID & Date")
            {
                custID = txt_Invoice.Text.Trim();
            }
            else if (searchBy == "Search By Invoice No")
            {
                invoiceNo = txt_Invoice.Text.Trim();
            }
            else if (searchBy == "By User & Date")
            {
                userName = txt_Invoice.Text.Trim();
            }

            DataTable dt = GetSalesAndReturns(from, to, custID, custName, invoiceNo, userName);

            TempDt = dt;
            lstSaleView.Items.Clear();

            decimal totalSales = 0;
            decimal totalReturns = 0;

            foreach (DataRow dr in dt.Rows)
            {
                decimal totalAmount = 0;
                decimal.TryParse(dr["TotalAmount"].ToString(), out totalAmount);

                string status = dr["Status"].ToString().ToLower();

                if (status == "sale")
                {
                    totalSales += totalAmount;
                }
                else if (status == "return")
                {
                    totalReturns +=Math.Abs( totalAmount);
                }

                ListViewItem item = new ListViewItem(dr["Date"].ToString());
                item.SubItems.Add(dr["Time"].ToString());
                item.SubItems.Add(dr["InvoiceNo"].ToString());
                item.SubItems.Add(dr["CustomerID"].ToString());
                item.SubItems.Add(dr["CustomerName"].ToString());
                item.SubItems.Add(dr["EnteredBy"].ToString());
                item.SubItems.Add(dr["TotalAmount"].ToString());
                item.SubItems.Add(dr["PaidAmount"].ToString());
                item.SubItems.Add(dr["BalanceAmount"].ToString());
                item.SubItems.Add(dr["Status"].ToString());

                lstSaleView.Items.Add(item);
            }

            decimal netSales = totalSales - totalReturns;

            txtTotalSaleValue.Text = totalSales.ToString("N2");
            txtTotalReturnValue.Text = totalReturns.ToString("N2");
            txtNetSaleValue.Text = netSales.ToString("N2");
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlProduct.Visible = false;
            pnlProduct.SendToBack();
        }
        private void printInvoicePageQty(string InvoiceNumber, bool PageSize, int Qty)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = conclass.GetRecord(@"SELECT        CONVERT(varchar(20), InvoiceNo) AS InvoiceNo, CONVERT(varchar(12), SaleOrderDate, 106) AS SaleOrderDate, CONVERT(varchar(5), SaleOrderTime, 108) AS SaleOrderTime, CustomerName, PaymentMethod, ProductCode, 
                         UPPER(ProductName) AS ProductName, Quantity, CurrencyName, StoreID, SalePrice - Discount AS SalePrice, Discount, Total, TotalDiscount, NetTotal, Status, StoreName, StoreNameLocal, Address, ContactNumber1, UserName, 
                         AddressLocal, UnitName, CustomerID, ExchangeRate, TotalBalance
FROM            IMIS_VWSaleOrderInvoice WHERE  (InvoiceNo = " + InvoiceNumber + ") AND (StoreID = 1) UNION all SELECT        CONVERT(varchar(20), InvoiceNo + 1) AS InvoiceNo, '' AS SaleOrderDate, '' AS SaleOrderTime, '' AS CustomerName, '' AS PaymentMethod, ProductCode, 'Ret :' + ProductName AS ProductName, - ReturnQuantity AS ReturnQuantity, '', '' AS StoreID,  ReturnAmount AS SalePrice, 0 AS Discount, 0 AS Total, 0 AS TotalDiscount, - ReturnAmount AS NetTotal, '' AS Status, '' AS StoreName, '' AS StoreNameLocal, '' AS Address, NULL AS ContactNumber1, '' AS UserName, '' AS AddressLocal, '' AS UnitName, 0 AS CustomerID, 1 AS ExchangeRate, 0 AS TotalBalance FROM   VW_SaleReturnForReceipt WHERE        (InvoiceNo = " + InvoiceNumber + ") order by ProductCode");

                if (dt.Rows.Count > 0)
                {
                    if (PageSize == false)
                    {
                        PrinterSettings settings = new PrinterSettings();
                        //MessageBox.Show(settings.PrinterName);
                        Reports.Sale_Invoice_AlKhairCenter obj = new Stock_System.Reports.Sale_Invoice_AlKhairCenter();
                        obj.SetDataSource(dt);
                        Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
                        //obj.PrintOptions.PrinterName = dtPrinter.Rows[0]["TerminalPrinterName"].ToString();
                        obj.PrintOptions.PrinterName = settings.PrinterName.ToString();
                        obj.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                        //crViewer.ReportSource = vrptSalesInvoice;
                        frm2.crystalReportViewer1.ReportSource = obj;
                         //frm2.ShowDialog();
                        obj.PrintToPrinter(Qty, false, 0, 0);
                    }
                    else if (PageSize == true)
                    {
                        Reports.rptSaleInvoice obj = new Stock_System.Reports.rptSaleInvoice();
                        //Reports.Sale_Invoice_OmerShiq obj = new Stock_System.Reports.Sale_Invoice_OmerShiq();
                        obj.SetDataSource(dt);
                        Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
                        frm2.crystalReportViewer1.ReportSource = obj;
                       // frm2.crystalReportViewer1.PrintReport();
                        frm2.ShowDialog();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }
        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            Boolean PageSize = false;
            if (chkA4Reprint.Checked == true)
                PageSize = true;
            else
                PageSize = false;
  
            printInvoicePageQty(lblInvoiceNo.Text, PageSize, 1);
        }
        private void lstSaleView_DoubleClick(object sender, EventArgs e)
        {
            if (lstSaleView.SelectedItems[0].SubItems[9].Text == "Sale")
            {
                Decimal TotalAmount = 0;
                Decimal TotalProfit = 0;
                lblInvoiceNo.Text = lstSaleView.SelectedItems[0].SubItems[2].Text;
                DataTable dt = obj.GetData(@"SELECT        IMIS_tblSaleOrderDetail.ProductCode, IMIS_VWProducts.ProductName, IMIS_tblSaleOrderDetail.Quantity, IMIS_tblSaleOrderDetail.SalePrice, IMIS_tblSaleOrderDetail.Discount, IMIS_tblSaleOrderDetail.Total, 
                         IMIS_tblSaleOrderDetail.InvoiceNo, IMIS_tblSaleOrderDetail.TotalBaseCurrencyProfit
FROM            IMIS_tblSaleOrderDetail INNER JOIN
                         IMIS_VWProducts ON IMIS_tblSaleOrderDetail.ProductCode = IMIS_VWProducts.ProductCode
WHERE       (IMIS_tblSaleOrderDetail.InvoiceNo = '" + lblInvoiceNo.Text + "')");
                lstInvoiceDetail.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                    item.SubItems.Add(dr["ProductName"].ToString());
                    item.SubItems.Add(dr["Quantity"].ToString());
                    item.SubItems.Add(dr["SalePrice"].ToString());
                    item.SubItems.Add(dr["Discount"].ToString());
                    item.SubItems.Add(dr["Total"].ToString());
                    lstInvoiceDetail.Items.Add(item);
                    TotalAmount = TotalAmount + Decimal.Parse(dr["Total"].ToString());
                    TotalProfit = TotalProfit + Decimal.Parse(dr["TotalBaseCurrencyProfit"].ToString());
                }

                lblTotalAmount.Text = TotalAmount.ToString();
                lblTotalProfit.Text = TotalProfit.ToString();
                pnlProduct.Visible = true;
                pnlProduct.BringToFront();
            }
            else if (lstSaleView.SelectedItems[0].SubItems[9].Text == "Return")
            {

                Decimal TotalAmount = 0;
                Decimal TotalProfit = 0;
                lblSaleReturnID.Text = lstSaleView.SelectedItems[0].SubItems[2].Text;
                DataTable dt = obj.GetData(@"SELECT        SaleReturnDetail.SaleReturnID, SaleReturnDetail.InvoiceNo, SaleReturnDetail.ProductCode, IMIS_VWProducts.ProductName, SaleReturnDetail.ReturnQuantity, 
                         SaleReturnDetail.ReturnAmount, SaleReturnDetail.ReturnDate
FROM            SaleReturnDetail INNER JOIN
                         IMIS_VWProducts ON SaleReturnDetail.ProductCode = IMIS_VWProducts.ProductCode
                         where  SaleReturnDetail.SaleReturnID=" + lblSaleReturnID.Text + "");
                lstSaleReturn.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["InvoiceNo"].ToString());
                    item.SubItems.Add(dr["ProductCode"].ToString());
                    item.SubItems.Add(dr["ProductName"].ToString());
                    item.SubItems.Add(dr["ReturnQuantity"].ToString());
                    item.SubItems.Add(dr["ReturnAmount"].ToString());
               
                    lstSaleReturn.Items.Add(item);
                    TotalAmount = TotalAmount + Decimal.Parse(dr["ReturnAmount"].ToString());
                  
                }

                lblTotalReturnAmount.Text = TotalAmount.ToString();
                pnlSaleReturn.Visible = true;
                pnlSaleReturn.BringToFront();
            
            
            
            }
        }
        private Decimal GetTotalSaleValue(string Query)
        {
            DataTable dt = obj.GetData(Query);
            if (dt.Rows.Count > 0)
                TotalSaleValue = Decimal.Parse(dt.Rows[0]["TotalSaleValue"].ToString());
            return TotalSaleValue;
        }
        private Decimal GetTotalProfitValue(string Query)
        {
            DataTable dt = obj.GetData(Query);
            if (dt.Rows.Count > 0)
                TotalSaleValue = Decimal.Parse(dt.Rows[0]["TotalProfitValue"].ToString());
            return TotalSaleValue;
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            printInvoice();
        }
        private void printInvoice()
        {
            DataTable dt = new DataTable();

            dt = TempDt;
            Reports.rptSalesSummaryReport obj = new Stock_System.Reports.rptSalesSummaryReport();
                obj.SetDataSource(dt);
                Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
                frm2.crystalReportViewer1.ReportSource = obj;
                //frm2.crystalReportViewer1.PrintReport();
                frm2.ShowDialog();
            
        }
        private void lstSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSearch.SelectedItem.ToString() == "Search By Invoice No")
            {
                gpdate.Enabled = true;
                gpinvioce.Enabled = true;
                txt_Invoice.Focus();
                btnSearch.Enabled = true;
            }
            else if (lstSearch.SelectedItem.ToString() == "Search By Date")
            {
                gpdate.Enabled = true;
                gpinvioce.Enabled = false;
            }
            else if (lstSearch.SelectedItem.ToString() == "By Customer & Date")
            {
                gpdate.Enabled = true;
                gpinvioce.Enabled = true;
                txt_Invoice.Focus();
            }
            else if (lstSearch.SelectedItem.ToString() == "By Customer ID & Date")
            {
                gpdate.Enabled = true;
                gpinvioce.Enabled = true;
                txt_Invoice.Focus();
            }
            else if (lstSearch.SelectedItem.ToString() == "By Customer")
            {
                gpdate.Enabled = false;
                gpinvioce.Enabled = true;
                txt_Invoice.Focus();
                btnSearch.Enabled = true;
            }
            else if (lstSearch.SelectedItem.ToString() == "By User & Date")
            {
                gpdate.Enabled = true;
                gpinvioce.Enabled = true;
                txt_Invoice.Focus();
            }
        }
        private void frmSaleReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                ExecuteUpdateWithTransaction();
            }

            if (e.Control && e.KeyCode == Keys.R)
            {
                ExecuteResetTransaction();
            }
        }
        #region Code for hide and show the sale report
        public bool ExecuteUpdateWithTransaction()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Begin a transaction
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // First command: CTE and inserting into a temporary table
                            string cteQuery = @"
                            WITH CTE_SaleOrder AS (
                                SELECT TOP (60) PERCENT InvoiceNo
                                FROM IMIS_tblSaleOrderMain
                                WHERE StoreID != 0 -- Exclude rows where StoreID is already 0
                                ORDER BY NEWID() -- Randomize the row selection
                            )
                            SELECT InvoiceNo INTO #SelectedInvoices
                            FROM CTE_SaleOrder;";

                            using (SqlCommand cmd1 = new SqlCommand(cteQuery, conn, transaction))
                            {
                                cmd1.ExecuteNonQuery();
                            }

                            // Second command: Update IMIS_tblSaleOrderMain
                            string updateSaleOrderQuery = @"
                            UPDATE IMIS_tblSaleOrderMain
                            SET StoreID = 0
                            WHERE InvoiceNo IN (SELECT InvoiceNo FROM #SelectedInvoices);";

                            using (SqlCommand cmd2 = new SqlCommand(updateSaleOrderQuery, conn, transaction))
                            {
                                cmd2.ExecuteNonQuery();
                            }

                            // 3rd  command: IMIS_tblSaleOrderDetail
                            string updateSaleOrderQuery1 = @"
                            UPDATE IMIS_tblSaleOrderDetail
                            SET StoreID = 0
                            WHERE InvoiceNo IN (SELECT InvoiceNo FROM #SelectedInvoices);";

                            using (SqlCommand cmd2 = new SqlCommand(updateSaleOrderQuery1, conn, transaction))
                            {
                                cmd2.ExecuteNonQuery();
                            }

                            // 4th  command: SaleReturnDetail
                            string updateSaleOrderQuery2 = @"
                            UPDATE SaleReturnDetail
                            SET StoreID = 0
                            WHERE InvoiceNo IN (SELECT InvoiceNo FROM #SelectedInvoices);";

                            using (SqlCommand cmd2 = new SqlCommand(updateSaleOrderQuery2, conn, transaction))
                            {
                                cmd2.ExecuteNonQuery();
                            }

                            // Third command: Update FMIS_tblCashAccountsInOutDetail
                            string updateCashAccountsQuery = @"
                            UPDATE FMIS_tblCashAccountsInOutDetail
                            SET StoreID = 0
                            WHERE EntryReferenceNumber IN (SELECT InvoiceNo FROM #SelectedInvoices)
                            AND EntryReference = 'Sales';";

                            using (SqlCommand cmd3 = new SqlCommand(updateCashAccountsQuery, conn, transaction))
                            {
                                cmd3.ExecuteNonQuery();
                            }

                            // Drop the temporary table
                            string dropTempTableQuery = "DROP TABLE #SelectedInvoices;";

                            using (SqlCommand cmd4 = new SqlCommand(dropTempTableQuery, conn, transaction))
                            {
                                cmd4.ExecuteNonQuery();
                            }

                            // Commit the transaction
                            transaction.Commit();
                            MessageBox.Show("Transaction committed successfully.");
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction in case of an error
                            transaction.Rollback();
    
                            MessageBox.Show("Error: " + ex.Message);
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection error: " + ex.Message);
                return false;
            }
        }
        public bool ExecuteResetTransaction()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Begin a transaction
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                          
                            // Second command: Update IMIS_tblSaleOrderMain
                            string updateSaleOrderQuery = @"UPDATE IMIS_tblSaleOrderMain SET StoreID = 1 WHERE StoreID=0";

                            using (SqlCommand cmd2 = new SqlCommand(updateSaleOrderQuery, conn, transaction))
                            {
                                cmd2.ExecuteNonQuery();
                            }

                            // command: IMIS_tblSaleOrderDetail
                            string updateSaleOrderQuery1 = @"UPDATE IMIS_tblSaleOrderDetail SET StoreID = 1 WHERE StoreID=0";

                            using (SqlCommand cmd2 = new SqlCommand(updateSaleOrderQuery1, conn, transaction))
                            {
                                cmd2.ExecuteNonQuery();
                            }



                            //  SaleReturnDetail
                            string updateSaleOrderQuery2 = @"UPDATE SaleReturnDetail SET StoreID = 1 WHERE StoreID=0";

                            using (SqlCommand cmd2 = new SqlCommand(updateSaleOrderQuery2, conn, transaction))
                            {
                                cmd2.ExecuteNonQuery();
                            }

                            // Third command: Update FMIS_tblCashAccountsInOutDetail
                            string updateCashAccountsQuery = @"UPDATE FMIS_tblCashAccountsInOutDetail  SET StoreID = 1
                            WHERE StoreID=0";

                            using (SqlCommand cmd3 = new SqlCommand(updateCashAccountsQuery, conn, transaction))
                            {
                                cmd3.ExecuteNonQuery();
                            }

                          
                            transaction.Commit();
                            MessageBox.Show("Transaction Rollback successfully.");
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction in case of an error
                            transaction.Rollback();

                            MessageBox.Show("Error: " + ex.Message);
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection error: " + ex.Message);
                return false;
            }
        }
        #endregion 
        private void btnCloseReturn_Click(object sender, EventArgs e)
        {
            pnlSaleReturn.Visible = false;
            pnlSaleReturn.SendToBack();
        }
        private void btnPrintReturn_Click(object sender, EventArgs e)
        {
            PrintSaleReturn(lblSaleReturnID.Text, false, 1);
            
        }
    }
}
