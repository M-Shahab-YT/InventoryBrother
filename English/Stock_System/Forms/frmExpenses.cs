using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.SqlClient;
using Stock_System.Class;
namespace Stock_System.Forms
{
    public partial class frmExpenses : Telerik.WinControls.UI.RadForm
    {
        Dbcommon obj = new Dbcommon();

        public frmExpenses()
        {
            InitializeComponent();
        }
        private void btnSaveHead_Click(object sender, EventArgs e)
        {
            if (btnSaveHead.Text == "Save")
            {
                obj.ExecuteQuery("insert into FMIS_tblExpenseHead(ExpenseHeadName, UserID,StoreID) values(N'" + txtExpenseHeadName.Text + "', N'" + conclass.User_ID + "',"+conclass.StoreID+")");
                MessageBox.Show("Record Saved Successfully..");
            }
            else
            {
                obj.ExecuteQuery(@"update FMIS_tblExpenseHead set ExpenseHeadName=N'" + txtExpenseHeadName.Text + "',LastActivityDoneBy=N'" + conclass.User_ID + "',LastActivityDate=getdate() where ExpenseHeadID=" + txtExpenseHeadName.Tag.ToString() + "");
                MessageBox.Show("Record Saved Successfully..");
            }
            obj.fillcmb(ddlExpenseHead, "ExpenseHeadName", "ExpenseHeadID", "SELECT  ExpenseHeadID, ExpenseHeadName FROM   FMIS_tblExpenseHead where StoreID=" + conclass.StoreID + "");
            txtExpenseHeadName.Text = "";
            btnSaveHead.Text = "Save";
            FillListExpenaseHead();
            txtExpenseHeadName.Focus();
        }
        private void FillListExpenaseHead()
        {
            DataTable dt = obj.GetData(@"SELECT  ExpenseHeadID, ExpenseHeadName, UserID, SystemDate
FROM            FMIS_tblExpenseHead where StoreID=" + conclass.StoreID + " and ExpenseHeadName not in('Product Damaged','Product Lost','Product Expired')");
            lstExpenseHead.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["ExpenseHeadID"].ToString());
                item.SubItems.Add(dr["ExpenseHeadName"].ToString());
                lstExpenseHead.Items.Add(item);
            }
        }
        private void FillExpenseDetail()
        {

            string Query = @"SELECT  top 20 ID, ExpenseHeadName, ExpenseDetail, ExpenseDate, ExpenseAmount, ExchangeRate, CurrencyName, AccountName,'Print Report' as Report,'Delete' as DelRow  FROM  FMIS_VWExpense order by ID desc";
            CustomerTranGrid.DataSource = obj.GetData(Query);
          
        }
        private void frmExpenses_Load(object sender, EventArgs e)
        {
            FillListExpenaseHead();
            obj.fillcmb(ddlExpenseHead, "ExpenseHeadName", "ExpenseHeadID", "SELECT  ExpenseHeadID, ExpenseHeadName FROM   FMIS_tblExpenseHead where StoreID=" + conclass.StoreID + " and ExpenseHeadName not in('Product Damaged','Product Lost','Product Expired')");




            obj.fillcmb(cmbCurrency, "CurrencyName", "CurrencyID", @"SELECT  CurrencyID, CurrencyName, CurrencySymbol FROM Lookup_tblCurrency");
            cmbCurrency_SelectionChangeCommitted(null, null);

            FillExpenseDetail();
        }
        private void cmbCurrency_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT ID, CurrencyID, ExchangeRate FROM  FMIS_tblCurrencyExchangeRate where ID=(select max(ID) from FMIS_tblCurrencyExchangeRate where StoreID=" + conclass.StoreID + " and CurrencyID=" + cmbCurrency.SelectedValue + ")");
            if (dt.Rows.Count > 0)
            {
                txtExchangeRate.Text = dt.Rows[0]["ExchangeRate"].ToString();
                obj.fillcmb(cmbPaymentAccount, "AccountName", "AccountID", "SELECT   AccountID, AccountName FROM FMIS_tblCashAccounts where StoreID=" + conclass.StoreID + " and CurrencyID=" + cmbCurrency.SelectedValue + "");
            }
        }
        private void ddlExpenseHead_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtExpenseDetail.Focus();
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
            obj.con.Open();
            if (btnSave.Text == "Save")
            {
                SqlTransaction tran = obj.con.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                try
                {
                    Decimal BasCurrencyPrice = ChangeToBaseCurrency(Decimal.Parse(txtExpenseAmount.Text), int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                    Int64 ID = conclass.nextid("FMIS_tblExpenseDetail", "ID");

                    cmd.Transaction = tran;
                    cmd.Connection = obj.con;



                    string Query1 = @"insert into FMIS_tblExpenseDetail(ID,ExpenseHeadID, ExpenseDetail, CurrencyID, ExpenseAmount, ExchangeRate, BasCurrencyAmount, StoreID, UserID) values(" + ID + "," + ddlExpenseHead.SelectedValue + ", N'" + txtExpenseDetail.Text + "', " + cmbCurrency.SelectedValue + ", " + txtExpenseAmount.Text + ", " + txtExchangeRate.Text + ", " + BasCurrencyPrice + ", " + conclass.StoreID + ", N'" + conclass.User_ID + "')";
                    cmd.CommandText = Query1;
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"insert into FMIS_tblCashAccountsInOutDetail(AccountID, StoreID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID) 
                    values(" + cmbPaymentAccount.SelectedValue + "," + conclass.StoreID + "," + txtExpenseAmount.Text + ", 'Out', 'Expense', '" + ID + "', N'" + txtExpenseDetail.Text + "', N'" + conclass.User_ID + "')";
                    cmd.ExecuteNonQuery();
                    tran.Commit();


                    txtExpenseAmount.Text = "";
                    txtExpenseDetail.Text = "";
                    txtExpenseHeadName.Text = "";
                    btnSave.Text = "Save";



                    FillExpenseDetail();
                    MessageBox.Show("Record Saved Successfully..");
                }
                catch (SqlException Sexp)
                {
                    tran.Rollback();
                    obj.con.Close();
                }
                catch (Exception ex)
                {
                    obj.con.Close();
                }
                finally
                {
                    obj.con.Close();
                }
            }
            else
            {
                obj.ExecuteQuery("");

            }

        }

        private void CustomerTranGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CustomerTranGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Print Report")
            {
                string CID = CustomerTranGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                PrintExpenseTransaction(CID);
            }
            else if (CustomerTranGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    string CID = CustomerTranGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                    DeleteExpTrans(CID);
                }
            }
        }
        private void PrintExpenseTransaction(string TranID)
        {
            DataTable dt = new DataTable();
            dt = conclass.GetRecord(@"SELECT   ID, ExpenseHeadName, ExpenseDetail, ExpenseDate, ExpenseAmount, ExchangeRate, BasCurrencyAmount, CurrencyName, AccountName, EntryReference,'Print Report' as Report,'Delete' as DelRow  FROM  FMIS_VWExpense where ID=" + TranID + "");
            Reports.rptExpenseTransaction obj = new Stock_System.Reports.rptExpenseTransaction();
            obj.SetDataSource(dt);
            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;
            frm2.ShowDialog();
        }
        private void DeleteExpTrans(string TranID)
        {
            obj.con.Open();
            SqlTransaction tran = obj.con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Transaction = tran;
                cmd.Connection = obj.con;
                string Query1 = @"delete from FMIS_tblCashAccountsInOutDetail where EntryReference='Expense' and EntryReferenceNumber='" + TranID + "'";
                cmd.CommandText = Query1;
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"delete from FMIS_tblExpenseDetail where ID=" + TranID + "";
                cmd.ExecuteNonQuery();
                tran.Commit();

                FillExpenseDetail();
                MessageBox.Show("Record Deleted Successfully..");
            }
            catch (SqlException Sexp)
            {
                tran.Rollback();
                obj.con.Close();
            }
            catch (Exception ex)
            {
                obj.con.Close();
            }
            finally
            {
                obj.con.Close();
            }
        
        }

        private void btnCloseOpeningBalance_Click(object sender, EventArgs e)
        {
            pnlExpHead.Visible = false;
            pnlExpHead.SendToBack();
        }

        private void btnExpHead_Click(object sender, EventArgs e)
        {
            pnlExpHead.Visible = true;
            pnlExpHead.BringToFront();
            txtExpenseHeadName.Text = "";
            txtExpenseHeadName.Focus();
        }

        private void lstExpenseHead_Click(object sender, EventArgs e)
        {
            txtExpenseHeadName.Tag = lstExpenseHead.SelectedItems[0].SubItems[0].Text;
            txtExpenseHeadName.Text = lstExpenseHead.SelectedItems[0].SubItems[1].Text;
            btnSaveHead.Text = "Update";
            txtExpenseHeadName.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string from = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
            string to = this.dtto.Value.Month.ToString() + "/" + this.dtto.Value.Day.ToString() + "/" + this.dtto.Value.Year.ToString();

            string Query = @"SELECT  ID, ExpenseHeadName, ExpenseDetail, ExpenseDate, ExpenseAmount, ExchangeRate, CurrencyName, AccountName,'Print Report' as Report,'Delete' as DelRow  FROM  FMIS_VWExpense where cast(convert(varchar(12),ExpenseDate,101) as datetime) between cast('" + from + "' as datetime) and cast('" + to + "' as datetime ) order by ID";
            CustomerTranGrid.DataSource = obj.GetData(Query);
        }
    }
}
