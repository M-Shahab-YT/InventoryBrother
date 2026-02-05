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

namespace Stock_System.Forms
{
    public partial class frmSalesManStatement : Form
    {
        Dbcommon obj = new Dbcommon();
        public frmSalesManStatement()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "All Salesman")
            {
                DataTable dt = Class.conclass.GetRecord(@"SELECT        SaleManID, SaleManName, TotalDebit, TotalCredit, Balance,Statement, NewTransaction
FROM            SalemanStatementSummary order by SaleManID");
                dgSalesmanStatement.DataSource = dt;
            }
            else if (cmbSearchType.Text == "Search By Salesman Name")
            {

                DataTable dt = Class.conclass.GetRecord(@"SELECT        SaleManID, SaleManName, TotalDebit, TotalCredit, Balance,Statement, NewTransaction
FROM            SalemanStatementSummary where SaleManName like N'%" +txtSearchValue.Text+"%' order by SaleManID");
                dgSalesmanStatement.DataSource = dt;
            }


            txtTotalBalance.Text = dgSalesmanStatement.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[4].Value.ToString())).ToString();
        }

        private void SalemanStatementSummaryByID(string SaleManID)
        {
            DataTable dt = Class.conclass.GetRecord(@"SELECT        SaleManID, SaleManName, TotalDebit, TotalCredit, Balance,Statement, NewTransaction
FROM            SalemanStatementSummary where SaleManID=" + SaleManID + "");
            dgSalesmanStatement.DataSource = dt;
            txtTotalBalance.Text = dgSalesmanStatement.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[4].Value.ToString())).ToString();
        }
        private void SalesmanTransactionByID(string SalesManID)
        {
            DataTable dt = Class.conclass.GetRecord(@"SELECT        convert(varchaR(12),Date,107) as Date,ID,ReferenceType, Particulars, Debit, Credit, 
(SELECT SUM(Credit-Debit)
 FROM FMIS_tblSalesManStatement AS sub 
 WHERE sub.SalesManID = main.SalesManID AND  sub.ID <= main.ID) AS Balance,'Report' as Report,'Delete' as Delete1
FROM            FMIS_tblSalesManStatement main
where  main.ReferenceType!='Commission' and  main.SalesManID=" + SalesManID + " order by ID");
            CustomerTranGrid.DataSource = dt;
        }
        private void frmSalesManStatement_Load(object sender, EventArgs e)
        {
            cmbSearchType.Text = "All Salesman";
            cmbTransactionType.Text = "Paid Commission";
            btnSearch_Click(null, null);
            obj.fillcmb(cmbPaymentAccount, "AccountName", "AccountID", "SELECT   AccountID, AccountName FROM FMIS_tblCashAccounts where StoreID=" + conclass.StoreID + " and  CurrencyID=1");

        
        }

        private void cmbSearchType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "Search By Salesman Name")
                txtSearchValue.Focus();

        }

        private void txtSearchValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(null, null);
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            pnlTransaction.Visible = false;
            pnlTransaction.SendToBack();
        }

        private void dgSalesmanStatement_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgSalesmanStatement.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Statement Report")
            {
                //PrintCustomerStatment(txtCustomerID.Text, conclass.StoreID, dgAllCustomersStatment.Rows[e.RowIndex].Cells[0].Value.ToString());
              
            }
            else if (dgSalesmanStatement.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "New Transaction")
            {

                txtSupplierID.Text = dgSalesmanStatement.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtSupplier.Text = dgSalesmanStatement.Rows[e.RowIndex].Cells[1].Value.ToString();

                DataTable dt = Class.conclass.GetRecord(@"SELECT        convert(varchaR(12),Date,107) as Date,ID,ReferenceType, Particulars, Debit, Credit, 
(SELECT SUM(Credit-Debit)
 FROM FMIS_tblSalesManStatement AS sub 
 WHERE sub.SalesManID = main.SalesManID AND  sub.ID <= main.ID) AS Balance,'Report' as Report,'Delete' as Delete1
FROM            FMIS_tblSalesManStatement main
where  main.ReferenceType!='Commission' and  main.SalesManID=" + txtSupplierID.Text + " order by ID");
                CustomerTranGrid.DataSource = dt;
                pnlTransaction.Visible = true;
                pnlTransaction.BringToFront();
                txtAmountToPay.Focus();
              

            }
        }

        private void btnSavePaidLoan_Click(object sender, EventArgs e)
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

            Int64 MaxID = conclass.nextid("FMIS_tblSalesManStatement", "ID");
            obj.con.Open();
            SqlTransaction tran = obj.con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Transaction = tran;
            cmd.Connection = obj.con;
            try
            {
                #region CustomerStatement
                DataTable dtCustomerBalance = new DataTable();
                DataTable dtCheckOpeningBalance = new DataTable();
                DataTable dtLastBalance = new DataTable();
                DataTable dtSumOfCredit = new DataTable();
                DataTable dtSumOfDebit = new DataTable();
                Decimal LastCustomerBalance = 0;
                Decimal TotalCredit = 0;
                Decimal TotalDebit = 0;
                Decimal NewCustomerBalance = 0;

                if (cmbTransactionType.Text == "Paid Commission")
                {
                    cmd.CommandText = @"insert into FMIS_tblSalesManStatement(ID, SalesManID, StoreID, ReferenceType, Particulars, Debit, Credit, UserID) 
                         values(" + MaxID + "," + txtSupplierID.Text + "," + conclass.StoreID + ", '" + cmbTransactionType.Text + "', N'" + txtRemarks.Text + "'," + txtAmountToPay.Text + ",0,'" + conclass.User_ID + "')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"insert into FMIS_tblCashAccountsInOutDetail(AccountID, StoreID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID) values(" + cmbPaymentAccount.SelectedValue + "," + conclass.StoreID + "," + txtAmountToPay.Text + ", 'Out', '" + cmbTransactionType.Text + "', '" + MaxID + "', N'" + txtRemarks.Text + "', N'" + conclass.User_ID + "')";
                    cmd.ExecuteNonQuery();
                }
               
                else if (cmbTransactionType.Text == "Opening Balance")
                {
                    DataTable dtOpeningBalance = new DataTable();
                    cmd.CommandText = "select * from FMIS_tblSalesManStatement where SalesManID=" + txtSupplierID.Text + " and ReferenceType='Opening Balance'";
                    SqlDataAdapter daOpeningBalance = new SqlDataAdapter(cmd);
                    daOpeningBalance.Fill(dtOpeningBalance);
                    if (dtOpeningBalance.Rows.Count > 0)
                    {
                        MessageBox.Show("Supplier has opening balance for selected currency");
                        return;
                    }
                    cmd.CommandText = @"insert into FMIS_tblSalesManStatement(ID, SalesManID, StoreID, ReferenceType, Particulars, Debit, Credit, UserID) 
                         values(" + MaxID + "," + txtSupplierID.Text + "," + conclass.StoreID + ", '" + cmbTransactionType.Text + "', N'" + txtRemarks.Text + "',0," + txtAmountToPay.Text + ", '" + conclass.User_ID + "')";
                    cmd.ExecuteNonQuery();
                }
                #endregion
                tran.Commit();
                txtAmountToPay.Text = "";
                txtRemarks.Text = "";
                MessageBox.Show("Payment Saved Successfully..");
                SalesmanTransactionByID(txtSupplierID.Text);
                SalemanStatementSummaryByID(txtSupplierID.Text);
             
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

        private void CustomerTranGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CustomerTranGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Recipt Report")
            {
                // dg_sale_loan.Rows[e.RowIndex].Cells[0].Value;
                //PrintCustomerTransaction(CustomerTranGrid.Rows[e.RowIndex].Cells[1].Value.ToString());
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
                        cmd.CommandText = "SELECT ID,  ReferenceType, ReferenceNumber FROM   FMIS_tblSalesManStatement WHERE  ID =" + RefID + "";
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dtRefNumber);
                        if (dtRefNumber.Rows.Count > 0)
                        {
                            RefID = dtRefNumber.Rows[0]["ID"].ToString();
                            ReferenceType = dtRefNumber.Rows[0]["ReferenceType"].ToString();
                            cmd.CommandText = @"delete from FMIS_tblSalesManStatement where ID=" + RefID + "";
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
                    SalesmanTransactionByID(txtSupplierID.Text);
                    SalemanStatementSummaryByID(txtSupplierID.Text);
                }
            }
        }
    }
}
