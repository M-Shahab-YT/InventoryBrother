using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stock_System.Class;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace Stock_System.Forms
{
    public partial class frmCustomerBalance : Form
    {
        Dbcommon obj = new Dbcommon();
        public frmCustomerBalance()
        {
            InitializeComponent();
        }
        private void cmbCurrency_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT ID, CurrencyID, ExchangeRate FROM  FMIS_tblCurrencyExchangeRate where ID=(select max(ID) from FMIS_tblCurrencyExchangeRate where StoreID=" + conclass.StoreID + " and CurrencyID=" + cmbCurrency.SelectedValue + ")");
            if (dt.Rows.Count > 0)
            {
                txtExchangeRate.Text = dt.Rows[0]["ExchangeRate"].ToString();
                obj.fillcmb(cmbPaymentAccount, "AccountName", "AccountID", "SELECT   AccountID, AccountName FROM FMIS_tblCashAccounts where StoreID=" + conclass.StoreID + " and CurrencyID=" + cmbCurrency.SelectedValue + "");
                if (txtCustomerID.Text != "")
                    txtAmountToPay.Focus();
            }
        }
        private Decimal ChangeToSelecteCurrency(Decimal Price, int Currency_ID, Decimal ExchangeRate)
        {
            Decimal BasePrice = 0;
            String Operator = "";
            string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            DataTable dt_cr = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT  CurrencyID, CurrencyName,ltrim(rtrim(FromBaseCurrencyOperator)) as  ExchangeOperator, IsBaseCurrency FROM  Lookup_tblCurrency where CurrencyID=" + Currency_ID + "", con);
            da.Fill(dt_cr);
            if (dt_cr.Rows.Count > 0)
            {
                Operator = dt_cr.Rows[0]["ExchangeOperator"].ToString();
                if (dt_cr.Rows[0]["IsBaseCurrency"].ToString() == "Yes")
                {
                    BasePrice = Price;
                }
                else
                {
                    if (Operator == "*")
                        BasePrice = Price * ExchangeRate;
                    else if (Operator == "/")
                        BasePrice = Price / ExchangeRate;
                }
            }
            return BasePrice;
        }
        private Decimal ChangeToBaseCurrency(Decimal Price, int Currency_ID, Decimal ExchangeRate)
        {
            Decimal BasePrice = 0;
            String Operator = "";
            string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            DataTable dt_cr = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT  CurrencyID, CurrencyName,ltrim(rtrim(ToBaseCurrencyOperator))  as  ExchangeOperator, IsBaseCurrency FROM  Lookup_tblCurrency where  CurrencyID=" + Currency_ID + "", con);
            da.Fill(dt_cr);
            if (dt_cr.Rows.Count > 0)
            {
                Operator = dt_cr.Rows[0]["ExchangeOperator"].ToString();
                if (dt_cr.Rows[0]["IsBaseCurrency"].ToString() == "Yes")
                {
                    BasePrice = Price;
                }
                else
                {
                    if (Operator == "*")
                        BasePrice = Price * ExchangeRate;
                    else if (Operator == "/")
                        BasePrice = Price / ExchangeRate;
                }
            }
            return BasePrice;
        }
        private bool isBaseCurrency(string Currency_ID)
        {
            bool status = false;
            string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            DataTable dt_cr = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT  CurrencyID, CurrencyName, IsBaseCurrency FROM  Lookup_tblCurrency where  CurrencyID=" + Currency_ID + "", con);
            da.Fill(dt_cr);
            if (dt_cr.Rows.Count > 0)
            {
                if (dt_cr.Rows[0]["IsBaseCurrency"].ToString() == "Yes")
                {
                    status = true;
                }
            }
            return status;
        }
        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT IMIS_tblCustomer.CustomerID, IMIS_tblCustomer.CustomerName, IMIS_tblCustomer.MobileNumber, IMIS_tblCustomer.EmailAddress, IMIS_tblCustomer.ContactPerson, IMIS_tblCustomer.CustomerAddress,  IMIS_tblCustomer.UserID, IMIS_tblCustomer.StoreID, IMIS_tblCustomer.SystemDate, IMIS_tblCustomer.LastUpdatedBy, IMIS_tblCustomer.LastUpdateDate, IMIS_tblCustomer.AreaCode, lookup_tblAreas.AreaName FROM  IMIS_tblCustomer INNER JOIN  lookup_tblAreas ON IMIS_tblCustomer.AreaCode = lookup_tblAreas.AreaCode where StoreID=" + conclass.StoreID + " and CustomerName like N'%" + txtSearchCustomer.Text.Trim() + "%'");
            lstCustomerSearch.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["CustomerID"].ToString());
                item.SubItems.Add(dr["CustomerName"].ToString());
                item.SubItems.Add(dr["MobileNumber"].ToString());
                item.SubItems.Add(dr["AreaName"].ToString());
                item.SubItems.Add(dr["CustomerAddress"].ToString());
                item.SubItems.Add(dr["EmailAddress"].ToString());
                lstCustomerSearch.Items.Add(item);
            }
        }
        private void lstCustomerSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    GetCustomerStatementByCustomerID(lstCustomerSearch.SelectedItems[0].SubItems[0].Text);
                    pnlCustomer.Visible = false;
                    pnlCustomer.SendToBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void LoadCustomerStatement()
        {
            DataTable dt = obj.GetData(@"SELECT        CustomerID, CustomerName, CurrencyID, CurrencyName, TotalDebit, TotalCredit, Balance, Statement,'New Transaction' as NewTransaction
FROM            FMIS_VWAllCustomersStatementSummary where StoreID=" + conclass.StoreID + " and Balance<>0 order by CustomerID");
            if (dt.Rows.Count > 0)
            {
                dgAllCustomersStatment.DataSource = dt;
                grdCurrencyBaseBalanceSummary.DataSource = obj.GetData(@"SELECT      CurrencyID, CurrencyName,sum(Balance) as TotalBalance,'Detail Report' as Report
            FROM FMIS_VWAllCustomersStatementSummary where StoreID=" + conclass.StoreID + " and Balance<>0 group by  CurrencyID, CurrencyName");

            }
        }
        private void frmCustomerBalance_Load(object sender, EventArgs e)
        {
            obj.fillcmb(cmbCurrency, "CurrencyName", "CurrencyID", @"SELECT        CurrencyID, CurrencyName, CurrencySymbol, ToBaseCurrencyOperator, FromBaseCurrencyOperator, IsBaseCurrency, UserID, SystemDate, LastUpdatedBy, LastUpdatedDate
FROM            Lookup_tblCurrency");

            obj.fillcmb(cmbCurrencyAdSarch, "CurrencyName", "CurrencyID", @"SELECT        CurrencyID, CurrencyName, CurrencySymbol, ToBaseCurrencyOperator, FromBaseCurrencyOperator, IsBaseCurrency, UserID, SystemDate, LastUpdatedBy, LastUpdatedDate
FROM            Lookup_tblCurrency");
            obj.fillcmb(cmbArea, "AreaName", "AreaCode", @"SELECT   AreaCode, AreaName FROM  lookup_tblAreas");
            cmbCurrency_SelectionChangeCommitted(null, null);
            LoadCustomerStatement();
            cmbSearchType.Text = "All Customer";
            txtAmountToPay.Focus();
        }
        private void lstCustomerSearch_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GetCustomerStatementByCustomerID(lstCustomerSearch.SelectedItems[0].SubItems[0].Text);
                pnlCustomer.Visible = false;
                pnlCustomer.SendToBack();

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void frmCustomerBalance_Shown(object sender, EventArgs e)
        {
            txtAmountToPay.Focus();
        }

        private void FillCustomerTranGrid(string CustomerID, string CurrencyID)
        {
            DataTable dt = new DataTable();
            dt = obj.GetData(@"SELECT convert(varchar(12), main.Date,107) as Date, main.ID,  main.ReferenceType, main.Particulars, main.Debit, main.Credit, 
						 (SELECT SUM(Debit - Credit) FROM FMIS_tblCustomerStatement AS sub WHERE sub.CustomerID = main.CustomerID AND sub.ID <= main.ID) AS Balance, main.CurrencyID,Lookup_tblCurrency.CurrencyName,'Recipt Report' as Report,'Delete' as Delete1
FROM            FMIS_tblCustomerStatement AS main INNER JOIN
                         Lookup_tblCurrency ON main.CurrencyID = Lookup_tblCurrency.CurrencyID where  main.ReferenceType not in('Sales Invoice','Sale Return') and   main.CustomerID=" + CustomerID + " and main.StoreID=" + conclass.StoreID + " 	 and main.CurrencyID=" + CurrencyID + " order by main.ID");
            if (dt.Rows.Count > 0)
                CustomerTranGrid.DataSource = dt;
            else
                CustomerTranGrid.DataSource = dt;

        }
        private Decimal GetCustomerBalanceSummary(string CustomerID)
        {
            Decimal TotalPaid = 0;
            Decimal Value = 0;
            DataTable dt = obj.GetData(@"select isnull(sum(BalanceAmount),0) as Balance_Amount from IMIS_tblSaleOrderMain where CustomerID='" + CustomerID + "' and BalanceAmount>0 and IMIS_tblSaleOrderMain.StoreID=" + conclass.StoreID + "");
            if (dt.Rows.Count > 0)
            {
                Value = Decimal.Parse(dt.Rows[0]["Balance_Amount"].ToString());
            }
            DataTable dt2 = obj.GetData("SELECT  isnull(sum(BaseCurrencyReceivedAmount),0) as TotalPaid FROM IMIS_tblReceivedLoanFromCustomer where CustomerID='" + CustomerID + "' and StoreID=" + conclass.StoreID + "");
            if (dt2.Rows.Count > 0)
            {
                TotalPaid = Decimal.Parse(dt2.Rows[0]["TotalPaid"].ToString());

            }
            return Value - TotalPaid;
        }

       
        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            pnlCustomer.Visible = true;
            dgAllCustomersStatment.Visible = false;
            gpCurrencyBaseBalanceSummary.Visible = false;
            pnlCustomer.BringToFront();
            txtSearchCustomer.Focus();
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
                Int64 MaxID = conclass.nextid("FMIS_tblCustomerStatement", "ID");
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
                  
                    if (cmbTransactionType.Text == "Received Loan")
                    {
                        cmd.CommandText = @"insert into FMIS_tblCustomerStatement(ID, CustomerID, StoreID, ReferenceType, Particulars, CurrencyID,ExchangeRate, Debit, Credit, UserID) 
                         values(" + MaxID + "," + txtCustomerID.Text + "," + conclass.StoreID + ", '" + cmbTransactionType.Text + "', N'" + txtRemarks.Text + "'," + cmbCurrency.SelectedValue + "," + txtExchangeRate.Text + ",0," + txtAmountToPay.Text + ",'" + conclass.User_ID + "')";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"insert into FMIS_tblCashAccountsInOutDetail(AccountID, StoreID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID) values(" + cmbPaymentAccount.SelectedValue + "," + conclass.StoreID + "," + txtAmountToPay.Text + ", 'In', '" + cmbTransactionType.Text + "', '" + MaxID + "', N'" + txtRemarks.Text + "', N'" + conclass.User_ID + "')";
                        cmd.ExecuteNonQuery();
                    }
                    else if (cmbTransactionType.Text == "Cash Payment")
                    {
                        cmd.CommandText = @"insert into FMIS_tblCustomerStatement(ID, CustomerID, StoreID, ReferenceType, Particulars, CurrencyID,ExchangeRate, Debit, Credit, UserID) 
                         values(" + MaxID + "," + txtCustomerID.Text + "," + conclass.StoreID + ", '" + cmbTransactionType.Text + "', N'" + txtRemarks.Text + "'," + cmbCurrency.SelectedValue + "," + txtExchangeRate.Text + "," + txtAmountToPay.Text + ",0, '" + conclass.User_ID + "')";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"insert into FMIS_tblCashAccountsInOutDetail(AccountID, StoreID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID) values(" + cmbPaymentAccount.SelectedValue + "," + conclass.StoreID + "," + txtAmountToPay.Text + ", 'Out', '" + cmbTransactionType.Text + "', '" + MaxID + "', N'" + txtRemarks.Text + "', N'" + conclass.User_ID + "')";
                        cmd.ExecuteNonQuery();
                    }

                    else if (cmbTransactionType.Text == "Adjustment of Received Loan with Larger than Actual")
                    {
                        cmd.CommandText = @"insert into FMIS_tblCustomerStatement(ID, CustomerID, StoreID, ReferenceType, Particulars, CurrencyID,ExchangeRate, Debit, Credit, UserID) 
                         values(" + MaxID + "," + txtCustomerID.Text + "," + conclass.StoreID + ", '" + cmbTransactionType.Text + "', N'" + txtRemarks.Text + "'," + cmbCurrency.SelectedValue + "," + txtExchangeRate.Text + "," + txtAmountToPay.Text + ",0, '" + conclass.User_ID + "')";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"insert into FMIS_tblCashAccountsInOutDetail(AccountID, StoreID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID) values(" + cmbPaymentAccount.SelectedValue + "," + conclass.StoreID + "," + txtAmountToPay.Text + ", 'Out', '" + cmbTransactionType.Text + "', '" + MaxID + "', N'" + txtRemarks.Text + "', N'" + conclass.User_ID + "')";
                        cmd.ExecuteNonQuery();
                    }
                    else if (cmbTransactionType.Text == "Adjustment of Cash Payment with Larger than Actual")
                    {
                        cmd.CommandText = @"insert into FMIS_tblCustomerStatement(ID, CustomerID, StoreID, ReferenceType, Particulars, CurrencyID,ExchangeRate, Debit, Credit, UserID) 
                         values(" + MaxID + "," + txtCustomerID.Text + "," + conclass.StoreID + ", '" + cmbTransactionType.Text + "', N'" + txtRemarks.Text + "'," + cmbCurrency.SelectedValue + "," + txtExchangeRate.Text + ",0," + txtAmountToPay.Text + ", '" + conclass.User_ID + "')";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"insert into FMIS_tblCashAccountsInOutDetail(AccountID, StoreID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID) values(" + cmbPaymentAccount.SelectedValue + "," + conclass.StoreID + "," + txtAmountToPay.Text + ", 'IN', '" + cmbTransactionType.Text + "', '" + MaxID + "', N'" + txtRemarks.Text + "', N'" + conclass.User_ID + "')";
                        cmd.ExecuteNonQuery();
                    }
                    else if (cmbTransactionType.Text == "One of the Bill not entered In the System")
                    {
                        cmd.CommandText = @"insert into FMIS_tblCustomerStatement(ID, CustomerID, StoreID, ReferenceType, Particulars, CurrencyID,ExchangeRate, Debit, Credit, UserID) 
                         values(" + MaxID + "," + txtCustomerID.Text + "," + conclass.StoreID + ", '" + cmbTransactionType.Text + "', N'" + txtRemarks.Text + "'," + cmbCurrency.SelectedValue + "," + txtExchangeRate.Text + "," + txtAmountToPay.Text + ",0, '" + conclass.User_ID + "')";
                        cmd.ExecuteNonQuery();
                    }

                    else if (cmbTransactionType.Text == "Opening Balance")
                    {
                        DataTable dtOpeningBalance = new DataTable();

                        cmd.CommandText = "select * from FMIS_tblCustomerStatement where CustomerID=" + txtCustomerID.Text + " and CurrencyID=" + cmbCurrency.SelectedValue + " and ReferenceType='Opening Balance'";
                        SqlDataAdapter daOpeningBalance = new SqlDataAdapter(cmd);
                        daOpeningBalance.Fill(dtOpeningBalance);
                        if (dtOpeningBalance.Rows.Count > 0)
                        {
                            MessageBox.Show("Customer has opening balance for selected currency");
                            return;
                        }
                        cmd.CommandText = @"insert into FMIS_tblCustomerStatement(ID, CustomerID, StoreID, ReferenceType, Particulars, CurrencyID,ExchangeRate, Debit, Credit, UserID) 
                         values(" + MaxID + "," + txtCustomerID.Text + "," + conclass.StoreID + ", '" + cmbTransactionType.Text + "', N'" + txtRemarks.Text + "'," + cmbCurrency.SelectedValue + "," + txtExchangeRate.Text + "," + txtAmountToPay.Text + ",0,'" + conclass.User_ID + "')";
                        cmd.ExecuteNonQuery();
                    }
                    #endregion
                    tran.Commit();
                    cmbCurrency_SelectionChangeCommitted(null, null);
                    txtAmountToPay.Text = "";
                    txtRemarks.Text = "";
                    MessageBox.Show("Payment Saved Successfully..");
                    LoadCustomerStatmentByID(txtCustomerID.Text);
                   FillCustomerTranGrid(txtCustomerID.Text,cmbCurrency.SelectedValue.ToString());
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbTransactionType.Text == "")
            {
                MessageBox.Show(cmbTransactionType.Text);
            }
            else
            {
                MessageBox.Show(cmbTransactionType.Text);
            }
        }

        private void PrintCustomerStatment(string CustomerID, string StoreID, string CurrencyID)
        {
            DataTable dt = new DataTable();
            dt = conclass.GetRecord(@"SELECT       ID, Date, Type AS ReferenceType,ReferenceNumber, Particulars, 
Debit, Credit, (SELECT SUM(Debit - Credit) 
 FROM FMIS_tblCustomerStatement AS sub 
 WHERE sub.CustomerID = main.CustomerID AND sub.CurrencyID = main.CurrencyID AND sub.ID <= main.ID) AS Balance,'Detail' as Detail
FROM   FMIS_VWCustomerStatement AS main  where main.CustomerID='" + CustomerID + "' and main.StoreID=" + conclass.StoreID + " and main.CurrencyID=" + CurrencyID + "");

            //------------------------parameters-------------------
            ParameterFields paramFields = new ParameterFields();
            ParameterField ParaFromDate = new ParameterField();
            ParameterField ParaToDate = new ParameterField();
            ParameterDiscreteValue FromValue = new ParameterDiscreteValue();
            ParameterDiscreteValue ToValue = new ParameterDiscreteValue();
            ParaFromDate.ParameterFieldName = "FromDate";
            ParaToDate.ParameterFieldName = "ToDate";
            // Set the discrete value and pass it to the parameter
            FromValue.Value = "0";
            ToValue.Value = "0";
            ParaFromDate.CurrentValues.Add(FromValue);
            ParaToDate.CurrentValues.Add(ToValue);
            // Add parameter to the parameter fields collection.
            paramFields.Add(ParaFromDate);
            paramFields.Add(ParaToDate);
            //----------------------------End Paramter---------------


            Reports.rptCustomerStatement obj = new Stock_System.Reports.rptCustomerStatement();
            obj.SetDataSource(dt);
            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;
            frm2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //frm2.crystalReportViewer1.PrintReport();
            frm2.ShowDialog();

        }


        private void PrintCustomerStatmentAll(string CurrencyID)
        {
            DataTable dt = new DataTable();
            dt = conclass.GetRecord(@"SELECT        Date, Type, Particulars, ReferenceNumber, Debit, Credit, Balance, StoreName, CustomerID, CustomerName, MobileNumber, EmailAddress, ContactPerson, CustomerAddress, CurrencyName, StoreID, CurrencyID
FROM            FMIS_VWCustomerStatement  where CustomerID='" + CustomerID + "' and StoreID=" + conclass.StoreID + " and CurrencyID=" + CurrencyID + "");
            Reports.rptCustomerStatement obj = new Stock_System.Reports.rptCustomerStatement();
            obj.SetDataSource(dt);
            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;
            // frm2.crystalReportViewer1.PrintReport();
            frm2.ShowDialog();
        }
        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (btnSaveCustomer.Text == "Save")
            {
                obj.ExecuteQuery(@"insert into IMIS_tblCustomer(CustomerName, MobileNumber, EmailAddress, ContactPerson, CustomerAddress, UserID, StoreID,AreaCode) values(N'" + txtCustomerName.Text + "', N'" + txtCustomerMobile.Text + "', '" + txtCustomerEmailAddress.Text + "', '" + txtCustomerContactPerson.Text + "', N'" + txtCustomerAddress.Text + "', N'" + conclass.User_ID + "', " + conclass.StoreID + "," + cmbArea.SelectedValue + ")");
                MaxCustomer();
            }
            else
            {
                obj.ExecuteQuery(@"update IMIS_tblCustomer set CustomerName=N'" + txtCustomerName.Text + "', MobileNumber=N'" + txtCustomerMobile.Text + "', EmailAddress='" + txtCustomerEmailAddress.Text + "', ContactPerson=N'" + txtCustomerContactPerson.Text + "', CustomerAddress=N'" + txtCustomerAddress.Text + "', LastUpdatedBy=N'" + conclass.User_ID + "',LastUpdateDate=getdate(),AreaCode=" + cmbArea.SelectedValue + " where CustomerID=" + lblCustomerID.Text + "");
                MessageBox.Show("Customer Updated Successfully..");
            }
            FillCustomerSaveView();
            ClearCustomer();
        }

        private void MaxCustomer()
        {

            DataTable dt = obj.GetData(@"SELECT   top 1  CustomerID, CustomerName,CustomerAddress FROM IMIS_tblCustomer where StoreID=" + conclass.StoreID + " order by CustomerID desc");
            GetCustomerStatementByCustomerID(dt.Rows[0]["CustomerID"].ToString());
            pnlCustomer.Visible = false;
            pnlCustomer.SendToBack();

        }
        private void FillCustomerSaveView()
        {
            DataTable dt = obj.GetData(@"SELECT   top 50     CustomerID, CustomerName, MobileNumber, EmailAddress, ContactPerson, CustomerAddress
FROM            IMIS_tblCustomer where StoreID=" + conclass.StoreID + " order by CustomerID desc");
            lstCustomerSaveView.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["CustomerID"].ToString());
                item.SubItems.Add(dr["CustomerName"].ToString());
                item.SubItems.Add(dr["MobileNumber"].ToString());
                item.SubItems.Add(dr["CustomerAddress"].ToString());
                item.SubItems.Add(dr["EmailAddress"].ToString());
                lstCustomerSaveView.Items.Add(item);
            }
        }
        private void ClearCustomer()
        {
            txtCustomerAddress.Text = "";
            txtCustomerEmailAddress.Text = "";
            txtCustomerName.Text = "";
            txtCustomerMobile.Text = "";
            txtCustomerContactPerson.Text = "";
            btnSaveCustomer.Text = "Save";
            txtCustomerName.Focus();
        }
        private void btnCancelCustomer_Click(object sender, EventArgs e)
        {
            FillCustomerSaveView();
            ClearCustomer();
        }
        private void txtSearchCustomerSaveView_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT        IMIS_tblCustomer.CustomerID, IMIS_tblCustomer.CustomerName, IMIS_tblCustomer.MobileNumber, IMIS_tblCustomer.EmailAddress, IMIS_tblCustomer.ContactPerson, IMIS_tblCustomer.CustomerAddress, 
                         IMIS_tblCustomer.UserID, IMIS_tblCustomer.StoreID, IMIS_tblCustomer.SystemDate, IMIS_tblCustomer.LastUpdatedBy, IMIS_tblCustomer.LastUpdateDate, IMIS_tblCustomer.AreaCode, lookup_tblAreas.AreaName
FROM            IMIS_tblCustomer INNER JOIN
                         lookup_tblAreas ON IMIS_tblCustomer.AreaCode = lookup_tblAreas.AreaCode where StoreID=" + conclass.StoreID + " and CustomerName like N'%" + txtSearchCustomerSaveView.Text.Trim() + "%'");
            lstCustomerSaveView.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["CustomerID"].ToString());
                item.SubItems.Add(dr["CustomerName"].ToString());
                item.SubItems.Add(dr["AreaName"].ToString());
                item.SubItems.Add(dr["CustomerAddress"].ToString());
                item.SubItems.Add(dr["MobileNumber"].ToString());
                item.SubItems.Add(dr["EmailAddress"].ToString());
                lstCustomerSaveView.Items.Add(item);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            pnlCustomer.SendToBack();
            pnlCustomer.Visible = false;
        }
    
        private void btnSearchAllCustomers_Click(object sender, EventArgs e)
        {
            dgAllCustomersStatment.Visible = true;
            gpCurrencyBaseBalanceSummary.Visible = true;
            DataTable dt = obj.GetData(@"SELECT        CustomerID, CustomerName, CurrencyID, CurrencyName, TotalDebit, TotalCredit, Balance, Statement
FROM            FMIS_VWAllCustomersStatementSummary where StoreID=" + conclass.StoreID + " and Balance<>0 order by CustomerID");
            if (dt.Rows.Count > 0)
            {
                dgAllCustomersStatment.DataSource = dt;
                dgAllCustomersStatment.Visible = true;
                txtCustomer.Text = "";
                txtCustomerID.Text = "";
            }
            else
            {
                dgAllCustomersStatment.DataSource = null;
            }
            grdCurrencyBaseBalanceSummary.DataSource = obj.GetData(@"SELECT      CurrencyID, CurrencyName,sum(Balance) as TotalBalance,'Detail Report' as Report
            FROM FMIS_VWAllCustomersStatementSummary where StoreID=" + conclass.StoreID + " and Balance<>0 group by  CurrencyID, CurrencyName");
        }
        private void dgAllCustomersStatment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgAllCustomersStatment.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Statement Report")
            {
                //dg_sale_loan.Rows[e.RowIndex].Cells[0].Value
                PrintCustomerStatment(dgAllCustomersStatment.Rows[e.RowIndex].Cells[0].Value.ToString(), conclass.StoreID, dgAllCustomersStatment.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
        }

        private void grdCurrencyBaseBalanceSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (grdCurrencyBaseBalanceSummary.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Detail Report")
            {
                // dg_sale_loan.Rows[e.RowIndex].Cells[0].Value;
                PrintAllCustomerStatment(grdCurrencyBaseBalanceSummary.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }
        private void PrintAllCustomerStatment(string CurrencyID)
        {
            DataTable dt = new DataTable();
            dt = conclass.GetRecord(@"SELECT        CustomerID, CustomerName, StoreID, CurrencyID, CurrencyName, TotalDebit, TotalCredit, Balance, Statement
FROM            FMIS_VWAllCustomersStatementSummary where CurrencyID=" + CurrencyID + " and Balance>0 and StoreID=" + conclass.StoreID + " order by CustomerID");
            Reports.rptAllCustomersStatement obj = new Stock_System.Reports.rptAllCustomersStatement();
            obj.SetDataSource(dt);
            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;
            //frm2.crystalReportViewer1.PrintReport();
            frm2.ShowDialog();
        }


        private void CustomerTranGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CustomerTranGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Recipt Report")
            {
                // dg_sale_loan.Rows[e.RowIndex].Cells[0].Value;
                PrintCustomerTransaction(CustomerTranGrid.Rows[e.RowIndex].Cells[1].Value.ToString());
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

                    try
                    {
                        cmd.CommandText = "select ID from FMIS_tblCustomerStatement where ID=(select max(ID) from FMIS_tblCustomerStatement where ReferenceType = N'" + CustomerTranGrid.Rows[e.RowIndex].Cells[2].Value.ToString() + "' and CustomerID=" + txtCustomerID.Text + " and CurrencyID=" + CustomerTranGrid.Rows[e.RowIndex].Cells[7].Value.ToString() + ")";
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dtRefNumber);
                        if (dtRefNumber.Rows.Count > 0)
                        {
                            RefID = dtRefNumber.Rows[0]["ID"].ToString();
                            cmd.CommandText = @"delete from FMIS_tblCashAccountsInOutDetail where id=(select Id from FMIS_tblCashAccountsInOutDetail where EntryReference='" + CustomerTranGrid.Rows[e.RowIndex].Cells[2].Value.ToString() + "' and EntryReferenceNumber='" + RefID + "')";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = @"delete from FMIS_tblCustomerStatement where ID=" + RefID + "";
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
                    FillCustomerTranGrid(txtCustomerID.Text, cmbCurrency.SelectedValue.ToString());
                    LoadCustomerStatmentByID(txtCustomerID.Text);
                }
            }
        }

        private void PrintCustomerTransaction(string TranID)
        {
            DataTable dt = new DataTable();
            dt = conclass.GetRecord(@"
SELECT        ID, ReferenceNumber, Date, ReferenceType + ': ' + Particulars AS Particulars, ExchangeRate, Debit, Credit, Balance, CurrencyID, CurrencyName, AccountName, CustomerName
FROM            FMIS_VWCustomerTransaction where ID=" + TranID + "");
            Reports.rptCustomerTransaction obj = new Stock_System.Reports.rptCustomerTransaction();
            obj.SetDataSource(dt);

            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;

            //frm2.crystalReportViewer1.PrintReport();
            frm2.ShowDialog();
        }

      


        private void btnPrintAdvanceSearch_Click(object sender, EventArgs e)
        {
            PrintCustomerStatmentByDate(txtCustomerID.Text, cmbCurrencyAdSarch.SelectedValue.ToString(),"0");
        }

        private void PrintCustomerStatmentByDate(string CustomerID, string CurrencyID, string OverallBalance)
        {
            string from = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
            string to = this.dtto.Value.Month.ToString() + "/" + this.dtto.Value.Day.ToString() + "/" + this.dtto.Value.Year.ToString();
            DataTable dt = new DataTable();
            dt = conclass.GetRecord(@"SELECT  ID, 
    Date, 
    Type, 
    Particulars, 
    ReferenceNumber, 
    StoreName, 
    CustomerID, 
    CustomerName, 
    MobileNumber, 
    EmailAddress, 
    ContactPerson, 
    CustomerAddress, 
    CurrencyName, 
    StoreID, 
    CurrencyID, 
    Debit, 
    Credit,
    (SELECT SUM(Debit - Credit) AS Expr1
     FROM FMIS_tblCustomerStatement AS sub
     WHERE sub.CustomerID = main.CustomerID 
     AND sub.CurrencyID = main.CurrencyID 
     AND sub.ID <= main.ID) AS Balance, 
    BusinessLogo, 
    Address, 
    AddressLocal, 
    StoreNameLocal, 
    ContactNumber1, 
    ContactNumber2 FROM     FMIS_VWCustomerStatement AS main WHERE  CustomerID = '" + CustomerID + "'     AND StoreID = " + conclass.StoreID + "      AND CurrencyID = " + CurrencyID + "     AND CAST(CONVERT(VARCHAR(12), Date, 101) AS DATETIME) >= CAST('" + from + "' AS DATETIME) AND CAST(CONVERT(VARCHAR(12), Date, 101) AS DATETIME) <= CAST('" + to + "' AS DATETIME)");
            //------------------------parameters-------------------
            ParameterFields paramFields = new ParameterFields();
            ParameterField ParaFromDate = new ParameterField();
            ParameterField ParaToDate = new ParameterField();
            ParameterField ParaOverallBalance = new ParameterField();

            
            ParameterDiscreteValue FromValue = new ParameterDiscreteValue();
            ParameterDiscreteValue ToValue = new ParameterDiscreteValue();
             ParameterDiscreteValue OverallBalanceValue = new ParameterDiscreteValue();
            
            ParaFromDate.ParameterFieldName = "FromDate";
            ParaToDate.ParameterFieldName = "ToDate";
            ParaOverallBalance.ParameterFieldName = "OverallBalance";
            // Set the discrete value and pass it to the parameter
            FromValue.Value = from;
            ToValue.Value = to;
            OverallBalanceValue.Value = OverallBalance;

            ParaFromDate.CurrentValues.Add(FromValue);
            ParaToDate.CurrentValues.Add(ToValue);
            ParaOverallBalance.CurrentValues.Add(OverallBalanceValue);
            // Add parameter to the parameter fields collection.
            paramFields.Add(ParaFromDate);
            paramFields.Add(ParaToDate);
            paramFields.Add(ParaOverallBalance);
            //----------------------------End Paramter---------------


            Reports.rptCustomerStatement obj = new Stock_System.Reports.rptCustomerStatement();
            obj.SetDataSource(dt);
            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;
            frm2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //frm2.crystalReportViewer1.PrintReport();
            frm2.ShowDialog();
        }
        private void PrintAllCustomerSatmentByDate(string CurrencyID)
        {

            string from = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
            string to = this.dtto.Value.Month.ToString() + "/" + this.dtto.Value.Day.ToString() + "/" + this.dtto.Value.Year.ToString();

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "FMIS_ProAllCustomersStatementSummaryByDate";
            cmd.Connection = obj.con;
            cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = from;
            cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = to;
            cmd.Parameters.Add("@CurrencyID", SqlDbType.Int).Value = CurrencyID;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Reports.rptAllCustomersStatementByDate obj2 = new Stock_System.Reports.rptAllCustomersStatementByDate();
            obj2.SetDataSource(dt);


            ParameterFields paramFields = new ParameterFields();
            ParameterField ParaFromDate = new ParameterField();
            ParameterField ParaToDate = new ParameterField();
            ParameterDiscreteValue FromValue = new ParameterDiscreteValue();
            ParameterDiscreteValue ToValue = new ParameterDiscreteValue();
            ParaFromDate.ParameterFieldName = "FromDate";
            ParaToDate.ParameterFieldName = "ToDate";
            // Set the discrete value and pass it to the parameter
            FromValue.Value = from;
            ToValue.Value = to;
            ParaFromDate.CurrentValues.Add(FromValue);
            ParaToDate.CurrentValues.Add(ToValue);
            // Add parameter to the parameter fields collection.
            paramFields.Add(ParaFromDate);
            paramFields.Add(ParaToDate);
            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj2;
            frm2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //frm2.crystalReportViewer1.PrintReport();
            frm2.ShowDialog();
        }

        

     
        private void GetAccountDetail(string RefNo, string RefType, string AccountName, string Date)
        {
            Decimal GrandTotal = 0;
            lblDate.Text = Date;
            lblAccountName.Text = AccountName;
            lblReference.Text = RefType;
            lstPurchaseSale.Items.Clear();

            if (RefType == "Sales Invoice")
            {
                DataTable dt = obj.GetData(@"	SELECT IMIS_tblSaleOrderDetail.ProductCode, IMIS_VWProducts.ProductName, IMIS_tblSaleOrderDetail.Quantity + isnull(IMIS_tblSaleOrderDetail.QuantityReturned,0) as Quantity, IMIS_tblSaleOrderDetail.SalePrice, IMIS_tblSaleOrderDetail.Discount, IMIS_tblSaleOrderDetail.Total, 
                  IMIS_tblSaleOrderDetail.InvoiceNo
FROM     IMIS_tblSaleOrderDetail INNER JOIN
                  IMIS_VWProducts ON IMIS_tblSaleOrderDetail.ProductCode = IMIS_VWProducts.ProductCode WHERE   (IMIS_tblSaleOrderDetail.InvoiceNo = '" + RefNo + "')");
                lstPurchaseSale.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                    item.SubItems.Add(dr["ProductName"].ToString());
                    item.SubItems.Add(dr["Quantity"].ToString());
                    item.SubItems.Add(dr["SalePrice"].ToString());
                    item.SubItems.Add(dr["Total"].ToString());
                    GrandTotal = GrandTotal + Decimal.Parse(dr["Total"].ToString());
                    lstPurchaseSale.Items.Add(item);
                    lstPurchaseSale.Visible = true;
                }
                lblTotalBillValue.Text = GrandTotal.ToString();
            }

            else if (RefType == "Sale Return")
            {
                DataTable dt = obj.GetData(@"SELECT  IMIS_tblSaleOrderDetail.ProductCode, IMIS_VWProducts.ProductName, IMIS_tblSaleOrderDetail.QuantityReturned as Quantity, 

IMIS_tblSaleOrderDetail.SalePrice-isnull(IMIS_tblSaleOrderDetail.Discount,0) as SalePrice,

(IMIS_tblSaleOrderDetail.SalePrice-isnull(IMIS_tblSaleOrderDetail.Discount,0))*IMIS_tblSaleOrderDetail.QuantityReturned as Total
, IMIS_tblSaleOrderDetail.InvoiceNo,IMIS_tblSaleOrderDetail.Status FROM    IMIS_tblSaleOrderDetail INNER JOIN   IMIS_VWProducts ON IMIS_tblSaleOrderDetail.ProductCode = IMIS_VWProducts.ProductCode 
WHERE  IMIS_tblSaleOrderDetail.Status in('Quantity Returned', 'Full Returned') AND (IMIS_tblSaleOrderDetail.InvoiceNo = '" + RefNo + "')");
                lstPurchaseSale.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                    item.SubItems.Add(dr["ProductName"].ToString());
                    item.SubItems.Add(dr["Quantity"].ToString());
                    item.SubItems.Add(dr["SalePrice"].ToString());
                    item.SubItems.Add(dr["Total"].ToString());
                    GrandTotal = GrandTotal + Decimal.Parse(dr["Total"].ToString());
                    lstPurchaseSale.Items.Add(item);
                }
                lstPurchaseSale.Visible = true;
                lblTotalBillValue.Text = GrandTotal.ToString();
            }
        }


       

        private void txtSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lstCustomerSearch.Items.Count > 0)
            {
                lstCustomerSearch.Items[0].Selected = true;
                lstCustomerSearch.Items[0].EnsureVisible();
                lstCustomerSearch.Select();
                lstCustomerSearch.Focus();
            }
        }

        private void lstCustomerSaveView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string Id = lstCustomerSaveView.SelectedItems[0].SubItems[0].Text;
                    DataTable dt = obj.GetData(@"SELECT        CustomerID, CustomerName, CustomerAddress, MobileNumber, EmailAddress, ContactPerson FROM  IMIS_tblCustomer where CustomerID=" + Id + "");
                    txtCustomerName.Tag = dt.Rows[0]["CustomerID"].ToString();
                    txtCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
                    txtCustomerMobile.Text = dt.Rows[0]["MobileNumber"].ToString();
                    txtCustomerContactPerson.Text = dt.Rows[0]["ContactPerson"].ToString();
                    txtCustomerAddress.Text = dt.Rows[0]["CustomerAddress"].ToString();
                    txtCustomerEmailAddress.Text = dt.Rows[0]["EmailAddress"].ToString();
                    btnSaveCustomer.Text = "Update";
                    txtCustomerName.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chose Customer From the list");
                }
            }
        }


        //--------------------------------New Code-------------------------------

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "All Customer")
            {

                DataTable dt = obj.GetData(@"SELECT        CustomerID, CustomerName, CurrencyID, CurrencyName, TotalDebit, TotalCredit, Balance, Statement,'New Transaction' as NewTransaction
FROM            FMIS_VWAllCustomersStatementSummary where StoreID=" + conclass.StoreID + " order by CustomerID");
                if (dt.Rows.Count > 0)
                {
                    dgAllCustomersStatment.DataSource = dt;
                    grdCurrencyBaseBalanceSummary.DataSource = obj.GetData(@"SELECT      CurrencyID, CurrencyName,sum(Balance) as TotalBalance,'Detail Report' as Report
            FROM FMIS_VWAllCustomersStatementSummary where StoreID=" + conclass.StoreID + "  group by  CurrencyID, CurrencyName");
                }
            }
            else if (cmbSearchType.Text == "Search By Customer Name")
            {

                DataTable dt = obj.GetData(@"SELECT        CustomerID, CustomerName, CurrencyID, CurrencyName, TotalDebit, TotalCredit, Balance, Statement,'New Transaction' as NewTransaction
FROM            FMIS_VWAllCustomersStatementSummary where StoreID=" + conclass.StoreID + " and CustomerName like N'%" + txtSearchValue.Text.Trim() + "%'  order by CustomerID");
                if (dt.Rows.Count > 0)
                {
                    dgAllCustomersStatment.DataSource = dt;
                    grdCurrencyBaseBalanceSummary.DataSource = obj.GetData(@"SELECT      CurrencyID, CurrencyName,sum(Balance) as TotalBalance,'Detail Report' as Report
            FROM FMIS_VWAllCustomersStatementSummary where StoreID=" + conclass.StoreID + " and CustomerName like N'%" + txtSearchValue.Text.Trim() + "%' group by  CurrencyID, CurrencyName");
                }
            }
            else if (cmbSearchType.Text == "Search By CustomerID")
            {


                DataTable dt = obj.GetData(@"SELECT        CustomerID, CustomerName, CurrencyID, CurrencyName, TotalDebit, TotalCredit, Balance, Statement,'New Transaction' as NewTransaction
FROM            FMIS_VWAllCustomersStatementSummary where StoreID=" + conclass.StoreID + " and CustomerID ='" + txtSearchValue.Text.Trim() + "'  order by CustomerID");
                if (dt.Rows.Count > 0)
                {
                    dgAllCustomersStatment.DataSource = dt;
                    grdCurrencyBaseBalanceSummary.DataSource = obj.GetData(@"SELECT      CurrencyID, CurrencyName,sum(Balance) as TotalBalance,'Detail Report' as Report
            FROM FMIS_VWAllCustomersStatementSummary where StoreID=" + conclass.StoreID + " and CustomerID ='" + txtSearchValue.Text.Trim() + "' group by  CurrencyID, CurrencyName");

                }
            }
        }

        private void GetCustomerStatementByCustomerID(string CustomerID)
        {
            DataTable dt = obj.GetData(@"SELECT        CustomerID, CustomerName, CurrencyID, CurrencyName, TotalDebit, TotalCredit, Balance, Statement,'New Transaction' as NewTransaction
FROM            FMIS_VWAllCustomersStatementSummary where StoreID=" + conclass.StoreID + " and CustomerID ='" + CustomerID + "'  order by CustomerID");
            if (dt.Rows.Count > 0)
            {
                dgAllCustomersStatment.DataSource = dt;
                grdCurrencyBaseBalanceSummary.DataSource = obj.GetData(@"SELECT      CurrencyID, CurrencyName,sum(Balance) as TotalBalance,'Detail Report' as Report
            FROM FMIS_VWAllCustomersStatementSummary where StoreID=" + conclass.StoreID + " and CustomerID ='" + CustomerID + "' group by  CurrencyID, CurrencyName");

            }
        
        }

        private void LoadCustomerStatmentByID(string CustomerId)
        {
        
           DataTable dt = obj.GetData(@"SELECT        CustomerID, CustomerName, CurrencyID, CurrencyName, TotalDebit, TotalCredit, Balance, Statement,'New Transaction' as NewTransaction
FROM            FMIS_VWAllCustomersStatementSummary where StoreID=" + conclass.StoreID + " and CustomerID ='" + CustomerId + "'  order by CustomerID");
                if (dt.Rows.Count > 0)
                {
                    dgAllCustomersStatment.DataSource = dt;
                    grdCurrencyBaseBalanceSummary.DataSource = obj.GetData(@"SELECT      CurrencyID, CurrencyName,sum(Balance) as TotalBalance,'Detail Report' as Report
            FROM FMIS_VWAllCustomersStatementSummary where StoreID=" + conclass.StoreID + " and CustomerID ='" + CustomerId + "' group by  CurrencyID, CurrencyName");

                }
        }

        private void dgAllCustomersStatment_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgAllCustomersStatment.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Statement Report")
            {
                txtCustomerIDStatement.Text = dgAllCustomersStatment.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCustomerNameStatement.Text = dgAllCustomersStatment.Rows[e.RowIndex].Cells[1].Value.ToString();
                cmbCurrencyAdSarch.SelectedValue = dgAllCustomersStatment.Rows[e.RowIndex].Cells[2].Value.ToString();
                string customerID = txtCustomerIDStatement.Text;
                string currencyID = dgAllCustomersStatment.Rows[e.RowIndex].Cells[2].Value.ToString();

                string query = @"
SELECT TOP 50
    ID, 
    Date, 
    Type AS ReferenceType, 
    ReferenceNumber, 
    Particulars, 
    Debit, 
    Credit, 
    (SELECT SUM(Debit - Credit) 
     FROM FMIS_tblCustomerStatement AS sub 
     WHERE sub.CustomerID = main.CustomerID 
     AND sub.CurrencyID = main.CurrencyID 
     AND sub.ID <= main.ID) AS Balance, 
    'Detail' AS Detail
FROM   
    FMIS_VWCustomerStatement AS main
WHERE        
    CustomerID = " + customerID + @" 
    AND CurrencyID = " + currencyID + @" 
ORDER BY  
    ID DESC";


                // Assuming obj.GetData is a method that takes a query string and returns a DataTable
                DataTable dt = obj.GetData(query);


               
                lblOverallBalance.Tag = dgAllCustomersStatment.Rows[e.RowIndex].Cells[6].Value.ToString();
                grdStatementDetail.DataSource = dt;
                pnlCustomerStatementDeail.Visible = true;
                pnlCustomerStatementDeail.BringToFront();

            }
            else if (dgAllCustomersStatment.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "New Transaction")
            {
                txtCustomerID.Text = dgAllCustomersStatment.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCustomer.Text = dgAllCustomersStatment.Rows[e.RowIndex].Cells[1].Value.ToString();
                FillCustomerTranGrid(txtCustomerID.Text, dgAllCustomersStatment.Rows[e.RowIndex].Cells[2].Value.ToString());
                cmbCurrency.SelectedValue = dgAllCustomersStatment.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbCurrency_SelectionChangeCommitted(null, null);
                cmbTransactionType.Text = "Received Loan";
                pnlTransaction.Visible = true;
                pnlTransaction.BringToFront();
                txtAmountToPay.Focus();
            }
        }
        private void btnCloseStatment_Click(object sender, EventArgs e)
        {
            pnlCustomerStatementDeail.Visible = false;
            pnlCustomerStatementDeail.SendToBack();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            pnlTransaction.SendToBack();
            pnlTransaction.Visible = false;
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            pnlRefDetail.Visible = false;
            pnlRefDetail.SendToBack();
        }

        private void btnCustomerStatmentView_Click(object sender, EventArgs e)
        {

//            string from = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
//            string to = this.dtto.Value.Month.ToString() + "/" + this.dtto.Value.Day.ToString() + "/" + this.dtto.Value.Year.ToString();
//            DataTable dt = obj.GetData(@"SELECT    FMIS_tblCustomerStatement.ID, FMIS_tblCustomerStatement.Date, FMIS_tblCustomerStatement.ReferenceType, FMIS_tblCustomerStatement.ReferenceNumber, FMIS_tblCustomerStatement.Particulars,  FMIS_tblCustomerStatement.Debit, FMIS_tblCustomerStatement.Credit, FMIS_tblCustomerStatement.Balance,'Detail' as Detail
//FROM            FMIS_tblCustomerStatement INNER JOIN
//                         Lookup_tblCurrency ON FMIS_tblCustomerStatement.CurrencyID = Lookup_tblCurrency.CurrencyID
//WHERE        FMIS_tblCustomerStatement.CustomerID = " + txtCustomerIDStatement.Text + " AND FMIS_tblCustomerStatement.CurrencyID = " + cmbCurrencyAdSarch.SelectedValue + " and  cast(convert(varchar(12),Date,101) as datetime) between cast('" + from + "' as datetime) and cast('" + to + "' as datetime ) order by  FMIS_tblCustomerStatement.ID");
//            grdStatementDetail.DataSource = dt;

            string from = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
            string to = this.dtto.Value.Month.ToString() + "/" + this.dtto.Value.Day.ToString() + "/" + this.dtto.Value.Year.ToString();

            DataTable dt = obj.GetData(@"
SELECT
    ID, 
    CONVERT(VARCHAR(12), Date, 107) AS Date, 
    Type AS ReferenceType, 
    ReferenceNumber, 
    Particulars, 
    Debit, 
    Credit, 
    (SELECT SUM(Debit - Credit) 
     FROM FMIS_tblCustomerStatement AS sub 
     WHERE sub.CustomerID = main.CustomerID 
     AND sub.CurrencyID = main.CurrencyID
     AND sub.ID <= main.ID) AS Balance, 
    'Detail' AS Detail 
FROM 
    FMIS_VWCustomerStatement AS main 
WHERE 
    CustomerID = " + txtCustomerIDStatement.Text + @" 
    AND CurrencyID = " + cmbCurrencyAdSarch.SelectedValue + @" 
    AND CAST(CONVERT(VARCHAR(12), Date, 101) AS DATETIME) >= CAST('" + from + @"' AS DATETIME) 
    AND CAST(CONVERT(VARCHAR(12), Date, 101) AS DATETIME) <= CAST('" + to + @"' AS DATETIME) 
ORDER BY 
    ID");

            // Bind the DataTable to the DataGridView
            grdStatementDetail.DataSource = dt;

        }

        private void btnPrintAdvanceSearch_Click_1(object sender, EventArgs e)
        {
            PrintCustomerStatmentByDate(txtCustomerIDStatement.Text,cmbCurrencyAdSarch.SelectedValue.ToString(),lblOverallBalance.Tag.ToString());
        }

        private void grdCurrencyBaseBalanceSummary_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (grdCurrencyBaseBalanceSummary.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Detail Report")
            {
                PrintAllCustomerStatment(grdCurrencyBaseBalanceSummary.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            pnlCustomer.Visible = true;
            pnlCustomer.BringToFront();
        }

        private void lstCustomerSaveView_Click(object sender, EventArgs e)
        {
            string Id = lstCustomerSaveView.SelectedItems[0].SubItems[0].Text;
            DataTable dt = obj.GetData(@"SELECT        CustomerID, CustomerName, MobileNumber, EmailAddress, ContactPerson, CustomerAddress,AreaCode
FROM            IMIS_tblCustomer where CustomerID=" + Id + "");
            txtCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
            lblCustomerID.Text = dt.Rows[0]["CustomerID"].ToString();
            txtCustomerMobile.Text = dt.Rows[0]["MobileNumber"].ToString();
            txtCustomerEmailAddress.Text = dt.Rows[0]["EmailAddress"].ToString();
            txtCustomerContactPerson.Text = dt.Rows[0]["ContactPerson"].ToString();
            txtCustomerAddress.Text = dt.Rows[0]["CustomerAddress"].ToString();
            cmbArea.SelectedValue = dt.Rows[0]["AreaCode"].ToString();
            btnSaveCustomer.Text = "Update";
        }

      
    
    }
}
