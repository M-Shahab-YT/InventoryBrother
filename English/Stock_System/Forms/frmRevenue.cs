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
    public partial class frmRevenue : Form
    {
        Dbcommon obj = new Dbcommon();
        public frmRevenue()
        {
            InitializeComponent();
        }
        private void frmRevenue_Load(object sender, EventArgs e)
        {
            FillCombos();
            GetRevenueTransaction();
        }
        private void FillCombos()
        {

            obj.fillcmb(cmbCustomer, "CustomerName", "CustomerID", "select CustomerID, CustomerName from IMIS_tblCustomer where StoreID=" + conclass.StoreID + "");
            DataTable dt = obj.GetData(@"SELECT  top 1  CustomerID, CustomerName,CustomerAddress FROM IMIS_tblCustomer where StoreID=" + conclass.StoreID + " order by CustomerID");
            if (dt.Rows.Count > 0)
                cmbCustomer.SelectedValue = dt.Rows[0]["CustomerID"].ToString();

            obj.fillcmb(cmbRevenueType, "RevenueType", "RevenueTypeID", @"SELECT RevenueTypeID, RevenueType FROM   FMIS_tblRevenueType ");
            DataTable dt1 = obj.GetData(@"SELECT top 1 RevenueTypeID, RevenueType FROM   FMIS_tblRevenueType order by RevenueTypeID ");
            if (dt1.Rows.Count > 0)
                cmbRevenueType.SelectedValue = dt1.Rows[0]["RevenueTypeID"].ToString();

            obj.fillcmb(cmbDoctor, "DoctorName", "DoctorID", "SELECT        DoctorID, DoctorName FROM   DoctorInformation");


            DataTable dt3 = obj.GetData(@"SELECT    top 1    DoctorID, DoctorName FROM   DoctorInformation order by DoctorID");
            if (dt3.Rows.Count > 0)
                cmbDoctor.SelectedValue = dt3.Rows[0]["DoctorID"].ToString();

            cmbRevenueType_SelectionChangeCommitted(null, null);
        }
        private void cmbRevenueType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT isnull( RevenueValue,0) as RevenueValue FROM   FMIS_tblRevenueSetting where RevenueTypeID=" + cmbRevenueType.SelectedValue + " and DoctorID=" + cmbDoctor.SelectedValue + "");
            if (dt.Rows.Count > 0)
            {
                txtTotalRevenueValue.Text = dt.Rows[0]["RevenueValue"].ToString();
                txtPaidAmount.Text = dt.Rows[0]["RevenueValue"].ToString();

            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {

            long MaxID = conclass.nextid("FMIS_tblCustomerStatement", "ID");
            Int64 SNO = conclass.nextid("FMIS_tblRevenue", "ID");
            obj.con.Open();
            SqlTransaction tran = obj.con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Transaction = tran;
            cmd.Connection = obj.con;
            try
            {
                cmd.CommandText = @"insert into FMIS_tblRevenue( ID, RevenueTypeID, CustomerID, DoctorID, CurrencyID, ExchangeRate, RevenueAmount,Paid,Balance,UserID) 
                values(" + SNO + ", " + cmbRevenueType.SelectedValue + ", " + cmbCustomer.SelectedValue + ", " + cmbDoctor.SelectedValue + ", 1, 1, " + txtTotalRevenueValue.Text + "," + txtPaidAmount.Text + "," + txtBalance.Text + ",N'" + conclass.User_ID + "')";
                cmd.ExecuteNonQuery();
                if (float.Parse(txtPaidAmount.Text) > 0)
                {
                    cmd.CommandText = @"insert into FMIS_tblCashAccountsInOutDetail(AccountID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID,StoreID) values(" + conclass.DefaultAccountID + ", " + txtPaidAmount.Text + ", 'In', '" + cmbRevenueType.Text + "', '" + SNO + "', N'Doctor Fee', N'" + conclass.User_ID + "'," + conclass.StoreID + ")";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"update FMIS_tblCashierBalance set TotalCashIn=isnull(TotalCashIn,0)+" + txtPaidAmount.Text + " where UserID='" + conclass.User_ID + "' and ClosingStatus!='Closed' and CurrencyID=1";
                    cmd.ExecuteNonQuery();
                }
                if (Decimal.Parse(txtBalance.Text) > 0)
                {
                    #region CustomerStatement
                    DataTable dtCustomerBalance = new DataTable();
                    DataTable dtCheckOpeningBalance = new DataTable();
                    DataTable dtLastBalance = new DataTable();
                    DataTable dtSumOfCredit = new DataTable();
                    DataTable dtSumOfDebit = new DataTable();
                    Decimal TotalCredit = 0;
                    Decimal TotalDebit = 0;
                    Decimal NewCustomerBalance = 0;

                    #region Find Last New Balance
                    //This Query will give the last Balance
                    cmd.CommandText = "select isnull(Balance,0) As Balance from FMIS_tblCustomerStatement where CustomerID=" + cmbCustomer.SelectedValue + " and StoreID=" + conclass.StoreID + " and CurrencyID=1 and ReferenceType='Opening Balance'";
                    SqlDataAdapter daLastBalnce = new SqlDataAdapter(cmd);
                    daLastBalnce.Fill(dtLastBalance);

                    //This Query will give the Sum Of Credit
                    cmd.CommandText = "select isnull(Sum(Credit),0) As SumOfCredit from FMIS_tblCustomerStatement where CustomerID=" + cmbCustomer.SelectedValue + " and StoreID=" + conclass.StoreID + " and CurrencyID=1";
                    SqlDataAdapter daSumOfCredit = new SqlDataAdapter(cmd);
                    daSumOfCredit.Fill(dtSumOfCredit);

                    //This Query will give the Sum Of Debit
                    cmd.CommandText = "select isnull(Sum(Debit),0) As SumOfDebit from FMIS_tblCustomerStatement where CustomerID=" + cmbCustomer.SelectedValue + " and StoreID=" + conclass.StoreID + " and CurrencyID=1";
                    SqlDataAdapter daSumOfDebit = new SqlDataAdapter(cmd);
                    daSumOfDebit.Fill(dtSumOfDebit);

                    if (dtSumOfCredit.Rows.Count > 0 && dtSumOfDebit.Rows.Count > 0)
                    {
                        TotalCredit = Decimal.Parse(dtSumOfCredit.Rows[0]["SumOfCredit"].ToString());
                        TotalDebit = Decimal.Parse(dtSumOfDebit.Rows[0]["SumOfDebit"].ToString()) + Decimal.Parse(txtBalance.Text);
                        //Formula
                        NewCustomerBalance = TotalDebit - TotalCredit;
                    }
                    #endregion
                    cmd.CommandText = @"insert into FMIS_tblCustomerStatement(ID, CustomerID, StoreID, ReferenceType,ReferenceNumber, Particulars, CurrencyID,ExchangeRate, Debit, Credit, Balance, UserID) 
                values(" + MaxID + "," + cmbCustomer.SelectedValue + "," + conclass.StoreID + ", '" + cmbRevenueType.Text + "','" + SNO + "', N'" + cmbRevenueType.Text + "',1,1," + txtBalance.Text + ",0," + NewCustomerBalance + ", '" + conclass.User_ID + "')";
                    cmd.ExecuteNonQuery();
                    #endregion
                }

                tran.Commit();

                txtTotalRevenueValue.Text = "";
                txtPaidAmount.Text = "";
                txtBalance.Text = "";
                FillCombos();
                MessageBox.Show("Revenue Saved Succssfully..");
                GetRevenueTransaction();
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
        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            this.txtBalance.Text = string.Empty;
            if (this.txtPaidAmount.Text != string.Empty)
            {
                this.txtBalance.Text = Convert.ToString(Decimal.Parse(this.txtTotalRevenueValue.Text) - Decimal.Parse(this.txtPaidAmount.Text));
                if (Decimal.Parse(this.txtBalance.Text) < 0)
                {
                    MessageBox.Show("Your are Amount is out of Range");
                    this.txtBalance.Text = this.txtTotalRevenueValue.Text;
                    this.txtPaidAmount.Text = (0).ToString();
                    txtPaidAmount.Focus();
                }
                if (this.txtBalance.Text == string.Empty)
                {
                    this.txtPaidAmount.Text = (0).ToString();
                    txtPaidAmount.Focus();
                }
            }
        }
        private void GetRevenueTransaction()
        {
            DataTable dt = obj.GetData(@"SELECT    convert(varchar(12), FMIS_tblRevenue.SystemDate,107) as Date, FMIS_tblRevenue.ID, IMIS_tblCustomer.CustomerName, DoctorInformation.DoctorName, FMIS_tblRevenueType.RevenueType, FMIS_tblRevenue.RevenueAmount, FMIS_tblRevenue.Paid, 
                         FMIS_tblRevenue.Balance,'Print Report' as Report,'Delete' as DelRow
FROM            FMIS_tblRevenue INNER JOIN
                         DoctorInformation ON FMIS_tblRevenue.DoctorID = DoctorInformation.DoctorID INNER JOIN
                         FMIS_tblRevenueType ON FMIS_tblRevenue.RevenueTypeID = FMIS_tblRevenueType.RevenueTypeID INNER JOIN
                         IMIS_tblCustomer ON FMIS_tblRevenue.CustomerID = IMIS_tblCustomer.CustomerID

where	 (CAST(CONVERT(varchar(12), FMIS_tblRevenue.SystemDate, 106) AS datetime) >= CAST(CONVERT(varchar(12), GETDATE(), 106) AS Datetime)) AND (CAST(CONVERT(varchar(12), FMIS_tblRevenue.SystemDate,106) AS datetime) <= CAST(CONVERT(varchar(12), GETDATE(), 106) AS Datetime))   ORDER BY FMIS_tblRevenue.ID");
            GrdRevenueTransaction.DataSource = dt;
            txtTotalRevenue.Text = GrdRevenueTransaction.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[5].Value.ToString())).ToString();
            txtTotalCash.Text = GrdRevenueTransaction.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[6].Value.ToString())).ToString();
            txtTotalBalance.Text = GrdRevenueTransaction.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[7].Value.ToString())).ToString();
        }
        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (btnSaveCustomer.Text == "Save")
            {
                obj.ExecuteQuery(@"insert into IMIS_tblCustomer(CustomerName, MobileNumber, EmailAddress, ContactPerson, CustomerAddress, UserID, StoreID) values(N'" + txtCustomerName.Text + "', N'" + txtCustomerMobile.Text + "', '" + txtCustomerEmailAddress.Text + "', '" + txtCustomerContactPerson.Text + "', N'" + txtCustomerAddress.Text + "', N'" + conclass.User_ID + "', " + conclass.StoreID + ")");
                MessageBox.Show("Customer Saved Successfully..");
            }
            else
            {
                obj.ExecuteQuery(@"update IMIS_tblCustomer set CustomerName=N'" + txtCustomerName.Text + "', MobileNumber=N'" + txtCustomerMobile.Text + "', EmailAddress='" + txtCustomerEmailAddress.Text + "', ContactPerson=N'" + txtCustomerContactPerson.Text + "', CustomerAddress=N'" + txtCustomerAddress.Text + "', LastUpdatedBy=N'" + conclass.User_ID + "',LastUpdateDate=getdate() where CustomerID=" + lblCustomerID.Text + "");
                MessageBox.Show("Customer Updated Successfully..");
            }
            FillCombos();

            DataTable dt = obj.GetData("select CustomerId from IMIS_tblCustomer where customerId=(select max(CustomerId) from IMIS_tblCustomer)");
            if (dt.Rows.Count > 0)
                cmbCustomer.SelectedValue = dt.Rows[0]["CustomerId"].ToString();
            FillCustomerSaveView();
            ClearCustomer();
            pnlCustomer.Visible = false;
            pnlCustomer.SendToBack();
            cmbDoctor.Focus();
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
            ClearCustomer();
        }
        private void txtSearchCustomerSaveView_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT        CustomerID, CustomerName, MobileNumber, EmailAddress, ContactPerson, CustomerAddress
FROM            IMIS_tblCustomer where StoreID=" + conclass.StoreID + " and CustomerName like N'%" + txtSearchCustomerSaveView.Text.Trim() + "%'");
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            pnlCustomer.Visible = false;
            pnlCustomer.SendToBack();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            pnlCustomer.Visible = true;
            pnlCustomer.BringToFront();
            txtCustomerName.Focus();
        }

        private void GrdRevenueTransaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GrdRevenueTransaction.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    string CID = GrdRevenueTransaction.Rows[e.RowIndex].Cells[1].Value.ToString();
                    DeleteExpTrans(CID);
                    GetRevenueTransaction();
                }
            }
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
                string Query1 = @"delete from FMIS_tblCashAccountsInOutDetail where EntryReference='Checkup Fee' and EntryReferenceNumber='" + TranID + "'";
                cmd.CommandText = Query1;
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"delete from FMIS_tblRevenue where ID=" + TranID + "";
                cmd.ExecuteNonQuery();
                tran.Commit();
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

        private void txtSearchCustomerView_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT        CustomerID, CustomerName, MobileNumber, EmailAddress, ContactPerson, CustomerAddress
FROM            IMIS_tblCustomer where StoreID=" + conclass.StoreID + " and CustomerName like N'%" + txtSearchCustomerView.Text.Trim() + "%'");
            lstCustomerSearchView.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["CustomerID"].ToString());
                item.SubItems.Add(dr["CustomerName"].ToString());
                item.SubItems.Add(dr["MobileNumber"].ToString());
                item.SubItems.Add(dr["CustomerAddress"].ToString());
                item.SubItems.Add(dr["EmailAddress"].ToString());
                lstCustomerSearchView.Items.Add(item);
            }
        }

        private void txtSearchCustomerView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lstCustomerSearchView.Items.Count > 0)
            {
                lstCustomerSearchView.Items[0].Selected = true;
                lstCustomerSearchView.Items[0].EnsureVisible();
                lstCustomerSearchView.Select();
                lstCustomerSearchView.Focus();
            }
        }

        private void lstCustomerSearchView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string Id = lstCustomerSearchView.SelectedItems[0].SubItems[0].Text;
                    cmbCustomer.SelectedValue = Id;
                    pnlCustomer.SendToBack();
                    pnlCustomer.Visible = false;
                    cmbDoctor.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chose Customer From the list");
            }
        }

        private void lstCustomerSearchView_DoubleClick(object sender, EventArgs e)
        {
            string Id = lstCustomerSearchView.SelectedItems[0].SubItems[0].Text;
            cmbCustomer.SelectedValue = Id;
            pnlCustomer.SendToBack();
            pnlCustomer.Visible = false;
            cmbDoctor.Focus();
        }
    }
}
