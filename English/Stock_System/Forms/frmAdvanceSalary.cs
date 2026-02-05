using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stock_System.Class;
using System.IO;
using System.Data.SqlClient;

namespace Stock_System.Forms
{
    public partial class frmAdvanceSalary : Form
    {
        Dbcommon obj = new Dbcommon();
        public frmAdvanceSalary()
        {
            InitializeComponent();
        }
        private void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
            pnlEmployee.Visible = true;
            pnlEmployee.BringToFront();
            txtEmployeeNameSearch.Text = "";
            txtEmployeeNameSearch.Focus();




        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            pnlEmployee.Visible = false;
            pnlEmployee.SendToBack();
        }
        private void txtEmployeeNameSearch_TextChanged(object sender, EventArgs e)
        {
            string Query = @"SELECT   EmployeeID, FullName, FatherName, Address, Mobile1, EmailAddress 
FROM         HRMIS_tblEmployeeInformation where status='Active' and  FullName like N'%" + txtEmployeeNameSearch.Text + "%'";
            DataTable dt = obj.GetData(Query);
            if (dt.Rows.Count > 0)
            {
                lstEmployee.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["EmployeeID"].ToString());
                    item.SubItems.Add(dr["FullName"].ToString());
                    item.SubItems.Add(dr["Mobile1"].ToString());
                    item.SubItems.Add(dr["EmailAddress"].ToString());
                    item.SubItems.Add(dr["Address"].ToString());
                    lstEmployee.Items.Add(item);
                }
            }
        }
        private void lstEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    txtSearch.Text = lstEmployee.SelectedItems[0].SubItems[0].Text;
                    GetEmployeeInfo(txtSearch.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }
        private void GetEmployeeInfo(string empNo)
        {
            DataTable dt = obj.GetData(@"SELECT   EmployeeID, FullName, FatherName, Address, Mobile1 +''+ Mobile2 as Mobile, EmailAddress, Position, Salary,convert(varchar(12), JoiningDate,107) as JoiningDate, 
Photo, Gender, convert(varchar(12),DateOfBirth,107) as DateOfBirth, TINNo, NIDNo, GurantorPerson
FROM         HRMIS_tblEmployeeInformation where EmployeeID='" + empNo + "'");
            if (dt.Rows.Count > 0)
            {
                txtFullName.Text = dt.Rows[0]["FullName"].ToString();
                txtFullName.Tag = dt.Rows[0]["EmployeeID"].ToString();
                txtFatherName.Text = dt.Rows[0]["FatherName"].ToString();
                txtCurrentAddress.Text = dt.Rows[0]["Address"].ToString();
                txtMobile1.Text = dt.Rows[0]["Mobile"].ToString();
                txtEmail.Text = dt.Rows[0]["EmailAddress"].ToString();
                txtPosition.Text = dt.Rows[0]["Position"].ToString();

                txtSalary.Text = dt.Rows[0]["Salary"].ToString();
                txtJoningDate.Text = dt.Rows[0]["JoiningDate"].ToString();
                txtGender.Text = dt.Rows[0]["Gender"].ToString();
                txtDob.Text = dt.Rows[0]["DateOfBirth"].ToString();
                txtTINNo.Text = dt.Rows[0]["TINNo"].ToString();
                txtNIDNo.Text = dt.Rows[0]["NIDNo"].ToString();
                txtGurantorPerson.Text = dt.Rows[0]["GurantorPerson"].ToString();
                byte[] bt = dt.Rows[0]["Photo"] as byte[];
                if (bt != null)
                {
                    MemoryStream ms = new MemoryStream(bt);
                    this.EmpPhoto.Image = System.Drawing.Image.FromStream(ms);
                }
                else
                {
                    EmpPhoto.Image = null;
                    this.EmpPhoto.Invalidate();
                }

//                DataTable dtBalance = obj.GetData(@"select isnull(Balance,0) as Balance from FMIS_tblEmployeeAdvanceSalaryStatment
//where id=(select max(ID) from FMIS_tblEmployeeAdvanceSalaryStatment where EmployeeID='" +txtFullName.Tag+"')");
//                if (dtBalance.Rows.Count > 0)
//                    txtRemainingAmount.Text = dtBalance.Rows[0]["Balance"].ToString();





                pnlEmployee.Visible = false;
                pnlEmployee.SendToBack();
            }
            else
            {

                MessageBox.Show("Record Not Found!");
            }
        
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetEmployeeInfo(txtSearch.Text);
        }
        private void frmAdvanceSalary_Load(object sender, EventArgs e)
        {
            obj.fillcmb(cmbCurrency, "CurrencyName", "CurrencyID", @"SELECT        CurrencyID, CurrencyName, CurrencySymbol, ToBaseCurrencyOperator, FromBaseCurrencyOperator, IsBaseCurrency, UserID, SystemDate, LastUpdatedBy, LastUpdatedDate
FROM            Lookup_tblCurrency");
            obj.fillcmb(cmbMonth, "MonthName", "MonthID", @"SELECT  MonthID, MonthName +'-'+ Convert(varchar(12),Year) as MonthName FROM HRMIS_tblPayrollMonths  where Year=(select MAX(Year) from HRMIS_tblPayrollMonths) order by MonthID");            
            cmbCurrency_SelectionChangeCommitted(null, null);
           
        }
        private void cmbCurrency_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT        ID, StoreID, CurrencyID, ExchangeRate FROM FMIS_tblCurrencyExchangeRate where CurrencyID="+cmbCurrency.SelectedValue+"");
            if (dt.Rows.Count > 0)
            {
                txtExchangeRate.Text = dt.Rows[0]["ExchangeRate"].ToString();
                obj.fillcmb(cmbPaymentAccount, "AccountName", "AccountID", "SELECT  AccountID,  AccountName, AccountDetail, OpeningBalance FROM     FMIS_tblCashAccounts where StoreID="+conclass.StoreID+" and CurrencyID="+cmbCurrency.SelectedValue+"");
            }
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            Decimal BasCurrencyPrice = ChangeToBaseCurrency(Decimal.Parse(txtAmountToPay.Text), int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
            
            Int64 MaxID = conclass.nextid("FMIS_tblEmployeeAdvanceSalary", "ID");
            obj.con.Open();
            SqlTransaction tran = obj.con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Transaction = tran;
            cmd.Connection = obj.con;

            DataTable dtCustomerBalance = new DataTable();
            DataTable dtCheckOpeningBalance = new DataTable();
            DataTable dtLastBalance = new DataTable();
            DataTable dtSumOfCredit = new DataTable();
            DataTable dtSumOfDebit = new DataTable();
            Decimal LastCustomerBalance = 0;
            Decimal TotalCredit = 0;
            Decimal TotalDebit = 0;
            Decimal NewCustomerBalance = 0;
            try
            {

                cmd.CommandText = @"insert into FMIS_tblEmployeeAdvanceSalary(ID, EmployeeID, MonthID, Date, AdvancePayment, Remarks, UserID,CurrencyID, ExchangeRate, BasCurrencyAmount) 
                values(" + MaxID + ", " + txtFullName.Tag + ", " + cmbMonth.SelectedValue + ", getdate(), " + txtAmountToPay.Text + ", N'" + txtRemarks.Text + "', N'" + conclass.User_ID + "'," + cmbCurrency.SelectedValue + ", " + txtExchangeRate.Text + ", " + BasCurrencyPrice + ")";
                cmd.ExecuteNonQuery();

                //cmd.CommandText = @"insert into FMIS_tblCashAccountsInOutDetail(AccountID, StoreID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID) values(" + cmbPaymentAccount.SelectedValue + "," + conclass.StoreID + "," + txtAdvanceSalary.Text + ", 'Out', 'Advance Salary', '" + MaxID + "', N'" + txtRemarks.Text + "', N'" + conclass.User_ID + "')";
                //cmd.ExecuteNonQuery();

                cmd.CommandText = @"insert into FMIS_tblCashAccountsInOutDetail(AccountID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID,StoreID) 
                    values(" + cmbPaymentAccount.SelectedValue + ", " + txtAmountToPay.Text + ", 'Out', 'Advance Salary', '" + MaxID + "', N'"+txtRemarks.Text+"', N'" + conclass.User_ID + "'," + conclass.StoreID + ")";
                cmd.ExecuteNonQuery();

                tran.Commit();

                if (MessageBox.Show("Advance Salary Saved Successfully, Do you want to Print the Slip", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    cmbMonth_SelectionChangeCommitted(null,null);
                    txtAmountToPay.Text = "";
                    btnSave.Enabled = false;
                    printInvoice();
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
        }
        private void lstEmployee_DoubleClick(object sender, EventArgs e)
        {
            txtSearch.Text = lstEmployee.SelectedItems[0].SubItems[0].Text;
            GetEmployeeInfo(txtSearch.Text);
         
        }
        private void printInvoice()
        {
            DataTable dt = new DataTable();
            dt = conclass.GetRecord(@"SELECT        EmployeeID, FullName, FatherName, Position, AdvancePayment, MonthID, convert(varchar(12),SystemDate,107) as DAte, ID, Remarks, Month, StoreName, StoreNameLocal, Address, AddressLocal, BusinessLogo, ContactNumber1, ContactNumber2
FROM            FMIS_VW_AdvanceSalary where ID=(select max(ID) from FMIS_VW_AdvanceSalary where EmployeeID=" + txtFullName.Tag + ")");
            Reports.rtpAdvanceSalarySlip obj = new Stock_System.Reports.rtpAdvanceSalarySlip();
            obj.SetDataSource(dt);
            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;
            //  frm2.crystalReportViewer1.PrintReport();
            frm2.ShowDialog();

        }
        private void AdvanceSalaryStatment()
        {
            DataTable dt = new DataTable();
            dt = conclass.GetRecord(@" select * from FMIS_VWEmployeeAdvanceSalaryStatment where EmployeeID='" + txtFullName.Tag + "'");
            Reports.rptAdvanceSalaryStatment obj = new Stock_System.Reports.rptAdvanceSalaryStatment();
            obj.SetDataSource(dt);
            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;
            //  frm2.crystalReportViewer1.PrintReport();
            frm2.ShowDialog();

        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            printInvoice();
        }
        private void btnStatment_Click(object sender, EventArgs e)
        {
            AdvanceSalaryStatment();
        }
        private void cmbMonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"select * from FMIS_tblPayroll where EmployeeID=" + txtFullName.Tag + " and MonthID=" + cmbMonth.SelectedValue + "");
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Salary is alreday paid for this month");
                btnSave.Enabled = false;
                return;
            }
            txtTotalReceived.Text = GetAdvanceSalary().ToString();
            Decimal TotalSalary = Decimal.Parse(txtSalary.Text);
            Decimal AdvanceSalary = Decimal.Parse(txtTotalReceived.Text);
            Decimal TotalBalance = TotalSalary - AdvanceSalary;
            txtRemainingAmount.Text = TotalBalance.ToString();
            btnSave.Enabled = true;
        }
        private Decimal GetAdvanceSalary()
        {
            Decimal TotalAdvanceSalary = 0;
            try
            {
                DataTable dt = obj.GetData(@"
select isnull(sum(AdvancePayment),0) as TotalAdvanceSalary from FMIS_tblEmployeeAdvanceSalary
where MonthID=" + cmbMonth.SelectedValue + " and EmployeeID=" + txtFullName.Tag + "");
                if (dt.Rows.Count > 0)
                    TotalAdvanceSalary = Decimal.Parse(dt.Rows[0]["TotalAdvanceSalary"].ToString());
            }
            catch (Exception ex)
            {
            }
            return TotalAdvanceSalary;
        }

        private void txtEmployeeNameSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lstEmployee.Items.Count > 0)
            {
                lstEmployee.Items[0].Selected = true;
                lstEmployee.Items[0].EnsureVisible();
                lstEmployee.Select();
                lstEmployee.Focus();
            }
        }
    }
}
