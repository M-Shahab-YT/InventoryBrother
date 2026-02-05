using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Stock_System.Class;
using System.Data.SqlClient;
using CrystalDecisions.Shared;

namespace Stock_System.Forms
{
    public partial class frmSupplierStatement : Form
    {

        Dbcommon obj = new Dbcommon();
        public frmSupplierStatement()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "All Supplier")
            {
                DataTable dt = obj.GetData(@"SELECT        SupplierID, SupplierName, CurrencyID, CurrencyName, TotalDebit, TotalCredit, Balance, Statement,'New Transaction' as NewTransaction
FROM            FMIS_VWAllSuppliersStatementSummary where StoreID=" + conclass.StoreID + " order by SupplierID");
                if (dt.Rows.Count > 0)
                {
                    dgAllCustomersStatment.DataSource = dt;
                    grdCurrencyBaseBalanceSummary.DataSource = obj.GetData(@"SELECT      CurrencyID, CurrencyName,sum(Balance) as TotalBalance,'Detail Report' as Report
            FROM FMIS_VWAllSuppliersStatementSummary where StoreID=" + conclass.StoreID + "  group by  CurrencyID, CurrencyName");
                }
            }
            else if (cmbSearchType.Text == "Search By Supplier Name")
            {

                DataTable dt = obj.GetData(@"SELECT        SupplierID, SupplierName, CurrencyID, CurrencyName, TotalDebit, TotalCredit, Balance, Statement,'New Transaction' as NewTransaction
FROM            FMIS_VWAllSuppliersStatementSummary where StoreID=" + conclass.StoreID + " and SupplierName like N'%" + txtSearchValue.Text.Trim() + "%'  order by SupplierID");
                if (dt.Rows.Count > 0)
                {
                    dgAllCustomersStatment.DataSource = dt;
                    grdCurrencyBaseBalanceSummary.DataSource = obj.GetData(@"SELECT      CurrencyID, CurrencyName,sum(Balance) as TotalBalance,'Detail Report' as Report
            FROM FMIS_VWAllSuppliersStatementSummary where StoreID=" + conclass.StoreID + " and SupplierName like N'%" + txtSearchValue.Text.Trim() + "%' group by  CurrencyID, CurrencyName");
                }
            }
            else if (cmbSearchType.Text == "Search By SupplierID")
            {


                DataTable dt = obj.GetData(@"SELECT        SupplierID, SupplierName, CurrencyID, CurrencyName, TotalDebit, TotalCredit, Balance, Statement,'New Transaction' as NewTransaction
FROM            FMIS_VWAllSuppliersStatementSummary  where StoreID=" + conclass.StoreID + " and SupplierID ='" + txtSearchValue.Text.Trim() + "'  order by SupplierID");
                if (dt.Rows.Count > 0)
                {
                    dgAllCustomersStatment.DataSource = dt;
                    grdCurrencyBaseBalanceSummary.DataSource = obj.GetData(@"SELECT      CurrencyID, CurrencyName,sum(Balance) as TotalBalance,'Detail Report' as Report
            FROM FMIS_VWAllSuppliersStatementSummary where StoreID=" + conclass.StoreID + " and SupplierID ='" + txtSearchValue.Text.Trim() + "' group by  CurrencyID, CurrencyName");
                }
            }
        }

        private void GetStatementBySupplierID(string SupplierID)
        {
            DataTable dt = obj.GetData(@"SELECT        SupplierID, SupplierName, CurrencyID, CurrencyName, TotalDebit, TotalCredit, Balance, Statement,'New Transaction' as NewTransaction
FROM            FMIS_VWAllSuppliersStatementSummary  where StoreID=" + conclass.StoreID + " and SupplierID ='" + SupplierID + "'  order by SupplierID");
            if (dt.Rows.Count > 0)
            {
                dgAllCustomersStatment.DataSource = dt;
                grdCurrencyBaseBalanceSummary.DataSource = obj.GetData(@"SELECT      CurrencyID, CurrencyName,sum(Balance) as TotalBalance,'Detail Report' as Report
            FROM FMIS_VWAllSuppliersStatementSummary where StoreID=" + conclass.StoreID + " and SupplierID ='" + SupplierID + "' group by  CurrencyID, CurrencyName");

            }
            pnlSupplier.Visible = false;
            pnlSupplier.SendToBack();
        }
        private void LoadSupplierStatement(string SupplierId)
        {

            DataTable dt = obj.GetData(@"SELECT        SupplierID, SupplierName, CurrencyID, CurrencyName, TotalDebit, TotalCredit, Balance, Statement,'New Transaction' as NewTransaction
FROM            FMIS_VWAllSuppliersStatementSummary  where StoreID=" + conclass.StoreID + " and SupplierID ='" + SupplierId + "'  order by SupplierID");
            if (dt.Rows.Count > 0)
            {
                dgAllCustomersStatment.DataSource = dt;
                grdCurrencyBaseBalanceSummary.DataSource = obj.GetData(@"SELECT      CurrencyID, CurrencyName,sum(Balance) as TotalBalance,'Detail Report' as Report
            FROM FMIS_VWAllSuppliersStatementSummary where StoreID=" + conclass.StoreID + " and SupplierID ='" + SupplierId + "' group by  CurrencyID, CurrencyName");

            }
        }
        private void btnCloseStatment_Click(object sender, EventArgs e)
        {
            pnlSupplierStatementDeail.SendToBack();
            pnlSupplierStatementDeail.Visible = false;
        }
        private void dgAllSuppliersStatment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgAllCustomersStatment.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Statement Report")
            {
                //PrintCustomerStatment(txtCustomerID.Text, conclass.StoreID, dgAllCustomersStatment.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtSupplierIDStatement.Text = dgAllCustomersStatment.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtSupplierNameStatement.Text = dgAllCustomersStatment.Rows[e.RowIndex].Cells[1].Value.ToString();
                cmbCurrencyAdSarch.SelectedValue = dgAllCustomersStatment.Rows[e.RowIndex].Cells[2].Value.ToString();
                lblBalance.Tag = dgAllCustomersStatment.Rows[e.RowIndex].Cells[6].Value.ToString();
                string supplierID = txtSupplierIDStatement.Text;
string currencyID = dgAllCustomersStatment.Rows[e.RowIndex].Cells[2].Value.ToString();

string query = @"
SELECT TOP 100
    ID, 
    CONVERT(VARCHAR(12), Date, 107) AS Date, 
    ReferenceType, 
    ReferenceNumber, 
    Particulars, 
    Debit, 
    Credit, 
    (SELECT SUM(Credit - Debit) 
     FROM FMIS_tblSupplierStatement AS sub 
     WHERE sub.SupplierID = main.SupplierID 
     AND sub.CurrencyID = main.CurrencyID
     AND sub.ID <= main.ID) AS Balance,
    'Detail' AS Detail 
FROM 
    FMIS_tblSupplierStatement AS main 
WHERE 
    SupplierID = " + supplierID + @" 
    AND CurrencyID = " + currencyID + @" 
ORDER BY 
    ID DESC";

// Assuming obj.GetData is a method that takes a query string and returns a DataTable
DataTable dt = obj.GetData(query);

                grdStatementDetail.DataSource = dt;
                pnlSupplierStatementDeail.Visible = true;
                pnlSupplierStatementDeail.BringToFront();

            }
            else if (dgAllCustomersStatment.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "New Transaction")
            {
                txtSupplierID.Text = dgAllCustomersStatment.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtSupplier.Text = dgAllCustomersStatment.Rows[e.RowIndex].Cells[1].Value.ToString();
                FillSupplierTranGrid(txtSupplierID.Text, dgAllCustomersStatment.Rows[e.RowIndex].Cells[2].Value.ToString());
                cmbCurrency.SelectedValue = dgAllCustomersStatment.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbCurrency_SelectionChangeCommitted(null, null);
                cmbTransactionType.Text = "Paid Loan";
                pnlTransaction.Visible = true;
                pnlTransaction.BringToFront();
                txtAmountToPay.Focus();
            }
        }

        private void frmSupplierStatement_Load(object sender, EventArgs e)
        {
            obj.fillcmb(cmbCurrencyAdSarch, "CurrencyName", "CurrencyID", @"SELECT        CurrencyID, CurrencyName, CurrencySymbol, ToBaseCurrencyOperator, FromBaseCurrencyOperator, IsBaseCurrency, UserID, SystemDate, LastUpdatedBy, LastUpdatedDate
FROM            Lookup_tblCurrency");


            obj.fillcmb(cmbCurrency, "CurrencyName", "CurrencyID", @"SELECT        CurrencyID, CurrencyName, CurrencySymbol, ToBaseCurrencyOperator, FromBaseCurrencyOperator, IsBaseCurrency, UserID, SystemDate, LastUpdatedBy, LastUpdatedDate
FROM            Lookup_tblCurrency");
            cmbCurrency_SelectionChangeCommitted(null, null);



            DataTable dt = obj.GetData(@"SELECT        SupplierID, SupplierName, CurrencyID, CurrencyName, TotalDebit, TotalCredit, Balance, Statement,'New Transaction' as NewTransaction
FROM            FMIS_VWAllSuppliersStatementSummary where StoreID=" + conclass.StoreID + " order by SupplierID");
            if (dt.Rows.Count > 0)
            {
                dgAllCustomersStatment.DataSource = dt;
                grdCurrencyBaseBalanceSummary.DataSource = obj.GetData(@"SELECT      CurrencyID, CurrencyName,sum(Balance) as TotalBalance,'Detail Report' as Report
            FROM FMIS_VWAllSuppliersStatementSummary where StoreID=" + conclass.StoreID + "  group by  CurrencyID, CurrencyName");
            }
        }

        private void btnSupplierStatmentView_Click(object sender, EventArgs e)
        {
            string from = this.dtfrom.Value.ToString("MM/dd/yyyy");
            string to = this.dtto.Value.ToString("MM/dd/yyyy");

            string query = @"
SELECT 
    ID, 
    CONVERT(VARCHAR(12), Date, 107) AS Date, 
    ReferenceType, 
    ReferenceNumber, 
    Particulars, 
    Debit, 
    Credit, 
    (SELECT SUM(Credit - Debit)
     FROM FMIS_tblSupplierStatement AS sub 
     WHERE sub.SupplierID = main.SupplierID AND sub.CurrencyID = main.CurrencyID AND sub.ID <= main.ID) AS Balance,
    'Detail' AS Detail 
FROM 
    FMIS_tblSupplierStatement AS main  
WHERE 
    SupplierID = @CustomerID AND 
    CurrencyID = @CurrencyID AND 
    Date >= @FromDate AND 
    Date <= @ToDate
ORDER BY 
    ID";

            // Create a new DataTable to hold the data
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand(query, Class.conclass.con))
            {
                // Adding parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@CustomerID", txtSupplierIDStatement.Text);
                cmd.Parameters.AddWithValue("@CurrencyID", cmbCurrencyAdSarch.SelectedValue);
                cmd.Parameters.AddWithValue("@FromDate", from);
                cmd.Parameters.AddWithValue("@ToDate", to);

                // Create a SqlDataAdapter
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    // Fill the DataTable
                    da.Fill(dt);
                }
            }

            // Bind the DataTable to the DataGridView
            grdStatementDetail.DataSource = dt;
        }

        private void btnPrintAdvanceSearch_Click(object sender, EventArgs e)
        {
            PrintCustomerStatmentByDate(txtSupplierIDStatement.Text, cmbCurrencyAdSarch.SelectedValue.ToString(),lblBalance.Tag.ToString());
        }


        private void PrintCustomerStatmentByDate(string CustomerID, string CurrencyID,string Balance)
        {
            string from = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
            string to = this.dtto.Value.Month.ToString() + "/" + this.dtto.Value.Day.ToString() + "/" + this.dtto.Value.Year.ToString();

            DataTable dt = new DataTable();

            string query = @"
SELECT  
    Date, 
    Type, 
    Particulars, 
    ReferenceNumber, 
    Debit, 
    Credit, 
    (SELECT SUM(Credit - Debit) 
     FROM FMIS_tblSupplierStatement AS sub 
     WHERE sub.SupplierID = main.SupplierID 
     AND sub.CurrencyID = main.CurrencyID 
     AND sub.ID <= main.ID) AS Balance, 
    StoreName, 
    SupplierID, 
    SupplierName, 
    ContactMobileNo, 
    ContactEmail, 
    ContactPerson, 
    SupplierAddress, 
    CurrencyName, 
    StoreID, 
    CurrencyID,
    ContactMobileNo, 
    StoreNameLocal, 
    Address, 
    AddressLocal, 
    BusinessLogo, 
    ContactNumber1, 
    ContactNumber2
FROM            
    FMIS_VWSupplierStatement AS main
WHERE 
    SupplierID = '" + CustomerID + @"' 
    AND StoreID = " + conclass.StoreID + @" 
    AND CurrencyID = " + CurrencyID + @" 
    AND CAST(CONVERT(VARCHAR(12), Date, 101) AS DATETIME) >= CAST('" + from + @"' AS DATETIME) 
    AND CAST(CONVERT(VARCHAR(12), Date, 101) AS DATETIME) <= CAST('" + to + @"' AS DATETIME)
ORDER BY 
    ID";

            dt = conclass.GetRecord(query);

            //------------------------parameters-------------------
            ParameterFields paramFields = new ParameterFields();
            ParameterField ParaFromDate = new ParameterField();
            ParameterField ParaToDate = new ParameterField();
            ParameterField ParaBalance = new ParameterField();

            ParameterDiscreteValue FromValue = new ParameterDiscreteValue();
            ParameterDiscreteValue ToValue = new ParameterDiscreteValue();
            ParameterDiscreteValue BalanceValue = new ParameterDiscreteValue();

            ParaFromDate.ParameterFieldName = "FromDate";
            ParaToDate.ParameterFieldName = "ToDate";
            ParaBalance.ParameterFieldName = "OverallBalance";
            // Set the discrete value and pass it to the parameter
            FromValue.Value = from;
            ToValue.Value = to;
            BalanceValue.Value = Balance;
            ParaFromDate.CurrentValues.Add(FromValue);
            ParaToDate.CurrentValues.Add(ToValue);
            ParaBalance.CurrentValues.Add(BalanceValue);
            // Add parameter to the parameter fields collection.
            paramFields.Add(ParaFromDate);
            paramFields.Add(ParaToDate);
            paramFields.Add(ParaBalance);
            //----------------------------End Paramter---------------


            Reports.rptSupplierStatment obj = new Stock_System.Reports.rptSupplierStatment();
            obj.SetDataSource(dt);
            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;
            frm2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //frm2.crystalReportViewer1.PrintReport();
            frm2.ShowDialog();
        }

        private void grdStatementDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ID = "";
            string EntryReference = "";
            string EntryReferenceNumber = "";
            string AccountName = "";
            string Date = "";

            if (grdStatementDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Detail")
            {
                EntryReference = grdStatementDetail.Rows[e.RowIndex].Cells[2].Value.ToString();
                EntryReferenceNumber = grdStatementDetail.Rows[e.RowIndex].Cells[3].Value.ToString();
                AccountName = grdStatementDetail.Rows[e.RowIndex].Cells[3].Value.ToString();
                lblTotalBalancePerBill.Text = grdStatementDetail.Rows[e.RowIndex].Cells[6].Value.ToString();
                Date = grdStatementDetail.Rows[e.RowIndex].Cells[1].Value.ToString();
                GetAccountDetail(EntryReferenceNumber, EntryReference, AccountName, Date);
                pnlRefDetail.Visible = true;
                pnlRefDetail.BringToFront();

            }
        }

        private void GetAccountDetail(string RefNo, string RefType, string AccountName, string Date)
        {
            Decimal GrandTotal = 0;
            lblDate.Text = Date;
            lblAccountName.Text = AccountName;
            lblReference.Text = RefType;
            lstPurchaseSale.Items.Clear();

            if (RefType == "Purchase" || RefType == "Loan Invoice")
            {
              DataTable dt = obj.GetData(@"SELECT        IMIS_tblPurchaseOrderDetail.PurchaseOrderNo, IMIS_tblPurchaseOrderDetail.ProductCode, IMIS_VWProducts.ProductName, IMIS_tblPurchaseOrderDetail.PurchasePrice, 
                         IMIS_tblPurchaseOrderDetail.Quantity, IMIS_tblPurchaseOrderDetail.Total, IMIS_tblPurchaseOrderDetail.Status, IMIS_tblPurchaseOrderDetail.QuantityReturned
FROM            IMIS_tblPurchaseOrderDetail INNER JOIN
                         IMIS_VWProducts ON IMIS_tblPurchaseOrderDetail.ProductCode = IMIS_VWProducts.ProductCode
						 where Status<>'Full Returned' and PurchaseOrderNo = '" + RefNo + "'");
                lstPurchaseSale.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                    item.SubItems.Add(dr["ProductName"].ToString());
                    item.SubItems.Add(dr["Quantity"].ToString());
                    item.SubItems.Add(dr["PurchasePrice"].ToString());
                    item.SubItems.Add(dr["Total"].ToString());
                    GrandTotal = GrandTotal + Decimal.Parse(dr["Total"].ToString());
                    lstPurchaseSale.Items.Add(item);
                    lstPurchaseSale.Visible = true;
                }
                lblTotalBillValue.Text = GrandTotal.ToString();
                lstPurchaseSale.Visible = true;
                lblTotalBillValue.Text = GrandTotal.ToString();
            }

            else if (RefType == "Purchase Return")
            {
                DataTable dt = obj.GetData(@"SELECT        IMIS_tblPurchaseOrderDetail.PurchaseOrderNo, IMIS_tblPurchaseOrderDetail.ProductCode, IMIS_VWProducts.ProductName, IMIS_tblPurchaseOrderDetail.PurchasePrice, 
                         IMIS_tblPurchaseOrderDetail.Quantity, IMIS_tblPurchaseOrderDetail.Total, IMIS_tblPurchaseOrderDetail.Status, IMIS_tblPurchaseOrderDetail.QuantityReturned
FROM            IMIS_tblPurchaseOrderDetail INNER JOIN
                         IMIS_VWProducts ON IMIS_tblPurchaseOrderDetail.ProductCode = IMIS_VWProducts.ProductCode
WHERE  IMIS_tblPurchaseOrderDetail.Status in('Quantity Returned', 'Full Returned') AND (IMIS_tblPurchaseOrderDetail.PurchaseOrderNo = '" + RefNo + "')");
                lstPurchaseSale.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                    item.SubItems.Add(dr["ProductName"].ToString());
                    item.SubItems.Add(dr["Quantity"].ToString());
                    item.SubItems.Add(dr["PurchasePrice"].ToString());
                    item.SubItems.Add(dr["Total"].ToString());
                    GrandTotal = GrandTotal + Decimal.Parse(dr["Total"].ToString());
                    lstPurchaseSale.Items.Add(item);
                }
                lstPurchaseSale.Visible = true;
                lblTotalBillValue.Text = GrandTotal.ToString();
            }
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            pnlTransaction.SendToBack();
            pnlTransaction.Visible = false;
        }

        private void btnSaveRecivedLoan_Click(object sender, EventArgs e)
        {
            if (btnSaveRecivedLoan.Text == "Save")
            {
                if (cmbTransactionType.Text == "")
                {
                    MessageBox.Show("Chose Transaction Type");
                    cmbTransactionType.Focus();
                    return;
                }
                if (txtAmountToPay.Text == "")
                {
                    MessageBox.Show("Transaction Payment is required");
                    txtAmountToPay.Focus();
                    return;
                }

                if (float.Parse(txtAmountToPay.Text) < 0)
                {
                    MessageBox.Show("Your Payment amount is less than zero!");
                    return;
                }

                Int64 MaxID = conclass.nextid("FMIS_tblSupplierStatement", "ID");
                obj.con.Open();
                SqlTransaction tran = obj.con.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = tran;
                cmd.Connection = obj.con;
                try
                {
                    #region CustomerStatement
                    //DataTable dtCustomerBalance = new DataTable();
                    //DataTable dtCheckOpeningBalance = new DataTable();

                    //DataTable dtLastBalance = new DataTable();
                    //DataTable dtSumOfCredit = new DataTable();
                    //DataTable dtSumOfDebit = new DataTable();
                    //Decimal LastCustomerBalance = 0;
                    //Decimal TotalCredit = 0;
                    //Decimal TotalDebit = 0;
                    //Decimal NewCustomerBalance = 0;
                   
                    if (cmbTransactionType.Text == "Paid Loan" || cmbTransactionType.Text == "Advance Payment To Supplier")
                    {

                        
                        cmd.CommandText = @"insert into FMIS_tblSupplierStatement(ID, SupplierID, StoreID, ReferenceType, Particulars, CurrencyID,ExchangeRate, Debit, Credit, UserID) 
                         values(" + MaxID + "," + txtSupplierID.Text + "," + conclass.StoreID + ", '" + cmbTransactionType.Text + "', N'" + txtRemarks.Text + "'," + cmbCurrency.SelectedValue + "," + txtExchangeRate.Text + "," + txtAmountToPay.Text + ",0,'" + conclass.User_ID + "')";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"insert into FMIS_tblCashAccountsInOutDetail(AccountID, StoreID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID) values(" + cmbPaymentAccount.SelectedValue + "," + conclass.StoreID + "," + txtAmountToPay.Text + ", 'Out', '" + cmbTransactionType.Text + "', '" + MaxID + "', N'" + txtRemarks.Text + "', N'" + conclass.User_ID + "')";
                        cmd.ExecuteNonQuery();
                    }
                    else if (cmbTransactionType.Text == "Received Cash Loan")
                    {

                        
                        cmd.CommandText = @"insert into FMIS_tblSupplierStatement(ID, SupplierID, StoreID, ReferenceType, Particulars, CurrencyID,ExchangeRate, Debit, Credit, UserID) 
                         values(" + MaxID + "," + txtSupplierID.Text + "," + conclass.StoreID + ", '" + cmbTransactionType.Text + "', N'" + txtRemarks.Text + "'," + cmbCurrency.SelectedValue + "," + txtExchangeRate.Text + ",0," + txtAmountToPay.Text + ",'" + conclass.User_ID + "')";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"insert into FMIS_tblCashAccountsInOutDetail(AccountID, StoreID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID) values(" + cmbPaymentAccount.SelectedValue + "," + conclass.StoreID + "," + txtAmountToPay.Text + ", 'IN', '" + cmbTransactionType.Text + "', '" + MaxID + "', N'" + txtRemarks.Text + "', N'" + conclass.User_ID + "')";
                        cmd.ExecuteNonQuery();
                    }
                    else if (cmbTransactionType.Text == "Opening Balance")
                    {
                        DataTable dtOpeningBalance = new DataTable();
                        cmd.CommandText = "select * from FMIS_tblSupplierStatement where SupplierID=" + txtSupplierID.Text + " and CurrencyID=" + cmbCurrency.SelectedValue + " and ReferenceType='Opening Balance'";
                        SqlDataAdapter daOpeningBalance = new SqlDataAdapter(cmd);
                        daOpeningBalance.Fill(dtOpeningBalance);
                        if (dtOpeningBalance.Rows.Count > 0)
                        {
                            MessageBox.Show("Supplier has opening balance for selected currency");
                            return;
                        }
                        
                        cmd.CommandText = @"insert into FMIS_tblSupplierStatement(ID, SupplierID, StoreID, ReferenceType, Particulars, CurrencyID,ExchangeRate, Debit, Credit, UserID) 
                         values(" + MaxID + "," + txtSupplierID.Text + "," + conclass.StoreID + ", '" + cmbTransactionType.Text + "', N'" + txtRemarks.Text + "'," + cmbCurrency.SelectedValue + "," + txtExchangeRate.Text + ",0," + txtAmountToPay.Text + ", '" + conclass.User_ID + "')";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"insert into FMIS_tblCashAccountsInOutDetail(AccountID, StoreID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID) values(" + cmbPaymentAccount.SelectedValue + "," + conclass.StoreID + "," + txtAmountToPay.Text + ", 'IN', '" + cmbTransactionType.Text + "', '" + MaxID + "', N'" + txtRemarks.Text + "', N'" + conclass.User_ID + "')";
                        cmd.ExecuteNonQuery();
                    }
                    #endregion
                    tran.Commit();
                    cmbCurrency_SelectionChangeCommitted(null, null);
                    txtAmountToPay.Text = "";
                    txtRemarks.Text = "";
                    MessageBox.Show("Payment Saved Successfully..");
                    FillSupplierTranGrid(txtSupplierID.Text, cmbCurrency.SelectedValue.ToString());
                    LoadSupplierStatement(txtSupplierID.Text);
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
            else
            {

            }
            btnSaveRecivedLoan.Text = "Save";
        }

        private void cmbCurrency_SelectionChangeCommitted(object sender, EventArgs e)
        {

            DataTable dt = obj.GetData(@"SELECT ID, CurrencyID, ExchangeRate FROM  FMIS_tblCurrencyExchangeRate where ID=(select max(ID) from FMIS_tblCurrencyExchangeRate where StoreID=" + conclass.StoreID + " and CurrencyID=" + cmbCurrency.SelectedValue + ")");
            if (dt.Rows.Count > 0)
            {
                txtExchangeRate.Text = dt.Rows[0]["ExchangeRate"].ToString();
                obj.fillcmb(cmbPaymentAccount, "AccountName", "AccountID", "SELECT   AccountID, AccountName FROM FMIS_tblCashAccounts where StoreID=" + conclass.StoreID + " and CurrencyID=" + cmbCurrency.SelectedValue + "");
                if (txtSupplierID.Text != "")
                {
                    FillSupplierTranGrid(txtSupplierID.Text,cmbCurrency.SelectedValue.ToString());
                }
                txtAmountToPay.Focus();
            }
        }

        private void FillSupplierTranGrid(string CustomerID, string CurrencyID)
        {
            DataTable dt = new DataTable();
//            dt = obj.GetData(@"SELECT convert(varchar(12), main.Date,107) as Date, main.ID,  main.ReferenceType, main.Particulars, main.Debit, main.Credit, 
//						 (SELECT SUM(Credit-Debit) FROM FMIS_tblSupplierStatement AS sub WHERE sub.SupplierID = main.SupplierID AND sub.ID <= main.ID) AS Balance, main.CurrencyID,Lookup_tblCurrency.CurrencyName,'Delete' as Delete1
//FROM            FMIS_tblSupplierStatement AS main INNER JOIN
//                         Lookup_tblCurrency ON main.CurrencyID = Lookup_tblCurrency.CurrencyID where  main.ReferenceType not in('Purchase','Purchase Return') and   main.SupplierID=" + CustomerID + " and main.StoreID=" + conclass.StoreID + " 	 and main.CurrencyID=" + CurrencyID + " order by main.ID");

            dt = obj.GetData(@"SELECT 
    convert(varchar(12), main.Date, 107) as Date,
    main.ID,
    main.ReferenceType,
    main.Particulars,
    main.Debit,
    main.Credit,
    SUM(main.Credit - main.Debit) OVER (PARTITION BY main.SupplierID ORDER BY main.ID) AS Balance,
    main.CurrencyID,
    Lookup_tblCurrency.CurrencyName,
    'Delete' as Delete1
FROM
    FMIS_tblSupplierStatement AS main
INNER JOIN
    Lookup_tblCurrency ON main.CurrencyID = Lookup_tblCurrency.CurrencyID
WHERE
    main.ReferenceType NOT IN ('Purchase','Loan Invoice', 'Purchase Return')     AND main.SupplierID = " + CustomerID + "     AND main.StoreID = " + conclass.StoreID + "     AND main.CurrencyID = " + CurrencyID + " ORDER BY     main.ID;");
            
            
            if (dt.Rows.Count > 0)
                CustomerTranGrid.DataSource = dt;
            else
                CustomerTranGrid.DataSource = dt;
        }

         private void PrintAllCustomerStatment(string CurrencyID)
         {

             DataTable dt = new DataTable();
             dt = conclass.GetRecord(@"SELECT        SupplierId, SupplierName, StoreID, CurrencyID, CurrencyName, TotalDebit, TotalCredit, Balance, Statement
FROM            FMIS_VWAllSuppliersStatementSummary where CurrencyID=" + CurrencyID + " and Balance>0 and StoreID=" + conclass.StoreID + " order by SupplierId");
             Reports.rptAllSupplierStatment obj = new Stock_System.Reports.rptAllSupplierStatment();
             obj.SetDataSource(dt);
             Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
             frm2.crystalReportViewer1.ReportSource = obj;
             //frm2.crystalReportViewer1.PrintReport();
             frm2.ShowDialog();
         }

         private void grdCurrencyBaseBalanceSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {
             if (grdCurrencyBaseBalanceSummary.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Detail Report")
             {
                 string CurrencyID = grdCurrencyBaseBalanceSummary.Rows[e.RowIndex].Cells[0].Value.ToString();
                 PrintAllCustomerStatment(CurrencyID);
             }
         }

         private void button1_Click(object sender, EventArgs e)
         {
             pnlRefDetail.SendToBack();
             pnlRefDetail.Visible = false;
         }

         private void CustomerTranGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {
             if (CustomerTranGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Recipt Report")
             {
                 // dg_sale_loan.Rows[e.RowIndex].Cells[0].Value;
                 //PrintCustomerTransaction(CustomerTranGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
             }
             else if (CustomerTranGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Delete")
             {

                 if (MessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                 {
                     #region Delete
                     obj.con.Open();
                     SqlTransaction tran = obj.con.BeginTransaction();
                     SqlCommand cmd = new SqlCommand();
                     cmd.Transaction = tran;
                     cmd.Connection = obj.con;
                     DataTable dtRefNumber = new DataTable();
                     string RefID = "";
                     string ReferenceType = "";
                     try
                     {
                         RefID = CustomerTranGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                         cmd.CommandText = "SELECT ID,  ReferenceType, ReferenceNumber FROM   FMIS_tblSupplierStatement WHERE    ID =" + RefID + "";
                         SqlDataAdapter da = new SqlDataAdapter(cmd);
                         da.Fill(dtRefNumber);
                         if (dtRefNumber.Rows.Count > 0)
                         {
                             RefID = dtRefNumber.Rows[0]["ID"].ToString();
                             ReferenceType = dtRefNumber.Rows[0]["ReferenceType"].ToString();
                             cmd.CommandText = @"delete from FMIS_tblSupplierStatement where ID=" + RefID + "";
                             cmd.ExecuteNonQuery();
                             cmd.CommandText = @"delete from  FMIS_tblCashAccountsInOutDetail where EntryReferenceNumber=" + RefID + " and EntryReference='" + ReferenceType + "'";
                             cmd.ExecuteNonQuery();
                             tran.Commit();
                         }
                         else
                         {
                             tran.Rollback();
                             obj.con.Close();
                         }
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
                     #endregion
                     FillSupplierTranGrid(txtSupplierID.Text, cmbCurrency.SelectedValue.ToString());
                     LoadSupplierStatement(txtSupplierID.Text);
                 }
             }
         }

         private void btnSaveSupplier_Click(object sender, EventArgs e)
         {
             if (btnSaveSupplier.Text == "Save")
             {
                 obj.ExecuteQuery(@"insert into IMIS_tblSupplier(SupplierName, SupplierAddress, ContactPerson, ContactEmail, ContactMobileNo, StoreID, UserID) 
                values(N'" + txtSupplierName.Text + "', N'" + txtSupplierAddress.Text + "', '" + txtSupplierContactPerson.Text + "', '" + txtSupplierEmailAddress.Text + "', '" + txtSupplierMobile.Text + "', " + conclass.StoreID + ", N'" + conclass.User_ID + "')");
                 
                 MaxSupplier();
             }
             else
             {
                 obj.ExecuteQuery(@"update IMIS_tblSupplier set SupplierName=N'" + txtSupplierName.Text + "',SupplierAddress=N'" + txtSupplierAddress.Text + "',ContactPerson=N'" + txtSupplierContactPerson.Text + "',ContactEmail='" + txtSupplierEmailAddress.Text + "',ContactMobileNo='" + txtSupplierMobile.Text + "' where SupplierID=" + lblSupplierID.Text + "");
                
                 MessageBox.Show("Customer Updated Successfully..");
             }
             FillSupplierSaveView();
             ClearSupplier();
         }

         private void MaxSupplier()
         {
             DataTable dt = obj.GetData(@"SELECT  top 1  SupplierID, SupplierName, SupplierAddress, Country, ContactPerson, ContactEmail, ContactMobileNo, OpeningBalance, StoreID, UserID, LastUpdateDate FROM            IMIS_tblSupplier where StoreID=" + conclass.StoreID + " order by SupplierID desc");
             string SupplierID = dt.Rows[0]["SupplierID"].ToString();
             GetStatementBySupplierID(SupplierID);
             pnlSupplier.SendToBack();
             pnlSupplier.Visible = false;
         }
         private void FillSupplierSaveView()
         {
             DataTable dt = obj.GetData(@"SELECT   SupplierID, SupplierName, SupplierAddress, 
            ContactPerson, ContactEmail, ContactMobileNo, OpeningBalance, StoreID, UserID, LastUpdateDate
            FROM IMIS_tblSupplier where StoreID=" + conclass.StoreID + " order by SupplierID desc");
             lstCustomerSaveView.Items.Clear();
             foreach (DataRow dr in dt.Rows)
             {
                 ListViewItem item = new ListViewItem(dr["SupplierID"].ToString());
                 item.SubItems.Add(dr["SupplierName"].ToString());
                 item.SubItems.Add(dr["ContactMobileNo"].ToString());
                 item.SubItems.Add(dr["SupplierAddress"].ToString());
                 item.SubItems.Add(dr["ContactEmail"].ToString());
                 lstCustomerSaveView.Items.Add(item);
             }
         }
         private void ClearSupplier()
         {
             txtSupplierMobile.Text = "";
             txtSupplierName.Text = "";
             txtSupplierEmailAddress.Text = "";
             txtSupplierContactPerson.Text = "";
             txtSupplierAddress.Text = "";
             btnSaveSupplier.Text = "Save";
             txtSupplierName.Focus();
         }

         private void btnCancelSupplier_Click(object sender, EventArgs e)
         {
             ClearSupplier();
         }
         private void lstCustomerSaveView_Click(object sender, EventArgs e)
         {
             DataTable dt = obj.GetData(@"SELECT   SupplierID, SupplierName, SupplierAddress, 
            ContactPerson, ContactEmail, ContactMobileNo, OpeningBalance, StoreID, UserID, LastUpdateDate
            FROM IMIS_tblSupplier where SupplierID=" + lstCustomerSaveView.SelectedItems[0].SubItems[0].Text + "");
             if (dt.Rows.Count > 0)
             {
                 lblSupplierID.Text = dt.Rows[0]["SupplierID"].ToString();
                 txtSupplierName.Text = dt.Rows[0]["SupplierName"].ToString();
                 txtSupplierMobile.Text = dt.Rows[0]["ContactMobileNo"].ToString();
                 txtSupplierAddress.Text = dt.Rows[0]["SupplierAddress"].ToString();
                 txtSupplierContactPerson.Text = dt.Rows[0]["ContactPerson"].ToString();
                 txtSupplierEmailAddress.Text = dt.Rows[0]["ContactEmail"].ToString();
                 btnSaveSupplier.Text = "Update";
                 txtSupplierName.Focus();
             }
         }

         private void lstCustomerSaveView_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyCode == Keys.Enter)
                 lstCustomerSaveView_Click(null, null);
         }

         private void txtSearchSupplierSaveView_TextChanged(object sender, EventArgs e)
         {
             DataTable dt = obj.GetData(@"SELECT   SupplierID, SupplierName, SupplierAddress, 
            ContactPerson, ContactEmail, ContactMobileNo, OpeningBalance, StoreID, UserID, LastUpdateDate
            FROM IMIS_tblSupplier where  StoreID=" + conclass.StoreID + " and SupplierName like N'%" + txtSearchSupplierSaveView.Text.Trim() + "%' order by SupplierID desc");
             lstCustomerSaveView.Items.Clear();
             foreach (DataRow dr in dt.Rows)
             {
                 ListViewItem item = new ListViewItem(dr["SupplierID"].ToString());
                 item.SubItems.Add(dr["SupplierName"].ToString());
                 item.SubItems.Add(dr["ContactMobileNo"].ToString());
                 item.SubItems.Add(dr["SupplierAddress"].ToString());
                 item.SubItems.Add(dr["ContactEmail"].ToString());
                 lstCustomerSaveView.Items.Add(item);
             }
         }

         private void txtSearchSupplierSaveView_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyCode == Keys.Enter && lstCustomerSaveView.Items.Count > 0)
             {
                 lstCustomerSaveView.Items[0].Selected = true;
                 lstCustomerSaveView.Items[0].EnsureVisible();
                 lstCustomerSaveView.Select();
                 lstCustomerSaveView.Focus();
             }
         }

         private void txtSearchSupplier_TextChanged(object sender, EventArgs e)
         {
             DataTable dt = obj.GetData(@"SELECT   SupplierID, SupplierName, SupplierAddress, 
            ContactPerson, ContactEmail, ContactMobileNo, OpeningBalance, StoreID, UserID, LastUpdateDate
            FROM IMIS_tblSupplier where StoreID=" + conclass.StoreID + " and SupplierName like N'%" + txtSearchSupplier.Text.Trim() + "%' order by SupplierID desc");
             lstSearchSupplier.Items.Clear();
             foreach (DataRow dr in dt.Rows)
             {
                 ListViewItem item = new ListViewItem(dr["SupplierID"].ToString());
                 item.SubItems.Add(dr["SupplierName"].ToString());
                 item.SubItems.Add(dr["ContactMobileNo"].ToString());
                 item.SubItems.Add(dr["SupplierAddress"].ToString());
                 item.SubItems.Add(dr["ContactEmail"].ToString());
                 lstSearchSupplier.Items.Add(item);
             }
         }

         private void txtSearchSupplier_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyCode == Keys.Enter && lstSearchSupplier.Items.Count > 0)
             {
                 lstSearchSupplier.Items[0].Selected = true;
                 lstSearchSupplier.Items[0].EnsureVisible();
                 lstSearchSupplier.Select();
                 lstSearchSupplier.Focus();

             }
         }
         private void lstSearchSupplier_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyCode == Keys.Enter)
             {
                 GetStatementBySupplierID(lstSearchSupplier.SelectedItems[0].SubItems[0].Text);
             }
         }
         private void lstSearchSupplier_Click(object sender, EventArgs e)
         {
             GetStatementBySupplierID(lstSearchSupplier.SelectedItems[0].SubItems[0].Text);
         }
         private void btnExit_Click(object sender, EventArgs e)
         {
             pnlSupplier.Visible = false;
             pnlSupplier.SendToBack();
         }

         private void btnAddCustomer_Click(object sender, EventArgs e)
         {
             pnlSupplier.Visible = true;
             pnlSupplier.BringToFront();
         }

         private void lstSearchSupplier_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
         {

         }


       
    }
}
