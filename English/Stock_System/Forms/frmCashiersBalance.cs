using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Stock_System.Class;namespace Stock_System.Forms
{
    public partial class frmCashiersBalance : Form
    {
         Dbcommon obj = new Dbcommon();
         
        public frmCashiersBalance()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fa-IR");
        }

        private void frmCashiersBalance_Load(object sender, EventArgs e)
        {
            obj.fillcmb(cmbUsers, "UserName", "UserId", "select UserId, UserName from aspnet_Users");
            obj.fillcmb(cmbCurrency, "CurrencyName", "CurrencyID", "SELECT CurrencyID, CurrencyName +'-'+ CurrencySymbol CurrencyName FROM   Lookup_tblCurrency");
          
            if (conclass.IsInRole(conclass.UserName, "Finance Admin"))
            {
                GetPendingBalance("All", "");
                cmbUsers.Enabled = true;
            }
            else
            {
                cmbUsers.Enabled = false;
                cmbUsers.SelectedValue = conclass.User_ID;
                GetPendingBalance("", conclass.User_ID);
            }
            cmbUsers_SelectedIndexChanged(null, null);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtOpeningBalance.Text == "")
            {
                MessageBox.Show("Opening Balance must not be empty");
                return;
            }
            if (btnSave.Text == "Save")
            {
                DataTable dt = obj.GetData("SELECT   OpeningBalance,ClosingStatus FROM FMIS_tblCashierBalance where UserID='" + cmbUsers.SelectedValue.ToString() + "' and CurrencyID=" + cmbCurrency.SelectedValue + " and ClosingStatus!='Closed'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("You Still have Opening Balance for Selected Currency");
                    return;
                }

                if (MessageBox.Show("Do you really want Save Opening Balance?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    obj.ExecuteQuery("insert FMIS_tblCashierBalance(UserID,CurrencyID, OpeningDate, OpeningTime, OpeningBalance,ClosingStatus,StoreID) values('" + cmbUsers.SelectedValue.ToString() + "', " + cmbCurrency.SelectedValue + ", getdate(), getdate(), " + txtOpeningBalance.Text + ",'Open'," + conclass.StoreID + ")");
                    MessageBox.Show("Record Saved Successfully..");
                }
            }
            else
            {
                obj.ExecuteQuery("update FMIS_tblCashierBalance set OpeningBalance=" + txtOpeningBalance.Text + "  where ID=" + txtOpeningBalance.Tag + "");
                MessageBox.Show("Record Updated Successfully..");
            }
            FillOpeningBalance(cmbUsers.SelectedValue.ToString());
            btnSave.Text = "Save";
            txtOpeningBalance.Text = "";

        }
        private void FillOpeningBalance(string UserID)
        {
            DataTable dt = conclass.GetRecord(@"SELECT TOP (20) FMIS_tblCashierBalance.ID,
IMIS_tblStore.StoreNameLocal,
aspnet_Users.UserName,convert(varchar(12),FMIS_tblCashierBalance.OpeningDate,107)  AS Date,  
convert(varchar(5),FMIS_tblCashierBalance.OpeningTime, 108) AS Time,
Lookup_tblCurrency.CurrencyName, 
FMIS_tblCashierBalance.OpeningBalance AS Balance,
FMIS_tblCashierBalance.CurrencyID,
FMIS_tblCashierBalance.ClosingStatus AS Status,
 N'رسید' AS Slip
FROM     FMIS_tblCashierBalance INNER JOIN
                  Lookup_tblCurrency ON FMIS_tblCashierBalance.CurrencyID = Lookup_tblCurrency.CurrencyID INNER JOIN
                  aspnet_Users ON FMIS_tblCashierBalance.UserID = aspnet_Users.UserId INNER JOIN
                  IMIS_tblStore ON FMIS_tblCashierBalance.StoreID = IMIS_tblStore.StoreID
						  where FMIS_tblCashierBalance.UserID='" + UserID + "' and FMIS_tblCashierBalance.StoreID=" + conclass.StoreID + " and ClosingStatus!='Closed' order by  FMIS_tblCashierBalance.ID");
            if (dt.Rows.Count > 0)
                dgBalance.DataSource = dt;
            else
                dgBalance.DataSource = dt;
        }
        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillOpeningBalance(cmbUsers.SelectedValue.ToString());
        }
        private void dgBalance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgBalance.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "رسید")
            {
                DataTable dtStatus = obj.GetData("select USERID from FMIS_tblCashierBalance where USERID='" + cmbUsers.SelectedValue.ToString() + "' and  ClosingStatus='Open' ");
                if (dtStatus.Rows.Count > 0)
                {

                    if (MessageBox.Show("ایا شما میخواید که رسید چاب شود، بعد از چاپ نمودن دوباره تغیرات نخواد امد", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        obj.ExecuteQuery("update FMIS_tblCashierBalance set ClosingStatus='Open and Recipt Printed' where ID=" + dgBalance.Rows[e.RowIndex].Cells[0].Value.ToString() + "");
                        //FillOpeningBalance(conclass.User_ID);
                        //FillClosingBalance(conclass.User_ID);
                        //fillClosingSummary(conclass.User_ID);
                        PrintSlip(cmbUsers.SelectedValue.ToString());
                    }
                }
                else
                {
                    PrintSlip(cmbUsers.SelectedValue.ToString());
                }
            }
            FillOpeningBalance(cmbUsers.SelectedValue.ToString());
        }
        private void PrintSlip(string UserID)
        {
            DataTable dt = new DataTable();
            dt = conclass.GetRecord(@"SELECT   ID, UserID, CurrencyID, CurrencyName,Convert(varchar(12),OpeningDate,107) as OpeningDate, OpeningTime, OpeningBalance, ClosingStatus, EntryUser, UserName, StoreName
FROM         FMIS_VW_CashierOpeningBalance where UserID='" + UserID + "' and ClosingStatus!='Closed'");

            Reports.CashirOpeningRecipt obj = new Stock_System.Reports.CashirOpeningRecipt();
            obj.SetDataSource(dt);
            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;
            frm2.ShowDialog();
        }
        private void GetPendingBalance(string Type, string UserID)
        {

            if (Type == "All")
            {
                dataGridView1.DataSource = obj.GetData(@"SELECT TOP (20) FMIS_tblCashierBalance.ID, FMIS_tblCashierBalance.CurrencyID, Lookup_tblCurrency.CurrencyName, convert(varchar(12),FMIS_tblCashierBalance.OpeningDate,107) AS Date, CONVERT(varchar(5), 
                  FMIS_tblCashierBalance.OpeningTime, 108) AS Time, FMIS_tblCashierBalance.OpeningBalance AS Balance, FMIS_tblCashierBalance.ClosingStatus AS Status, N'بسته نماید' AS closeBalance, aspnet_Users.UserName, 
                  IMIS_tblStore.StoreNameLocal
FROM     FMIS_tblCashierBalance INNER JOIN
                  Lookup_tblCurrency ON FMIS_tblCashierBalance.CurrencyID = Lookup_tblCurrency.CurrencyID INNER JOIN
                  aspnet_Users ON FMIS_tblCashierBalance.UserID = aspnet_Users.UserId INNER JOIN
                  IMIS_tblStore ON FMIS_tblCashierBalance.StoreID = IMIS_tblStore.StoreID  where ClosingStatus='Open and Recipt Printed'
ORDER BY FMIS_tblCashierBalance.ID");

            }
            else
            {

                dataGridView1.DataSource = obj.GetData(@"SELECT TOP (20) FMIS_tblCashierBalance.ID, FMIS_tblCashierBalance.CurrencyID, Lookup_tblCurrency.CurrencyName, convert(varchar(12),FMIS_tblCashierBalance.OpeningDate,107) AS Date, CONVERT(varchar(5), 
                  FMIS_tblCashierBalance.OpeningTime, 108) AS Time, FMIS_tblCashierBalance.OpeningBalance AS Balance, FMIS_tblCashierBalance.ClosingStatus AS Status, N'بسته نماید' AS closeBalance, aspnet_Users.UserName, 
                  IMIS_tblStore.StoreNameLocal
FROM     FMIS_tblCashierBalance INNER JOIN
                  Lookup_tblCurrency ON FMIS_tblCashierBalance.CurrencyID = Lookup_tblCurrency.CurrencyID INNER JOIN
                  aspnet_Users ON FMIS_tblCashierBalance.UserID = aspnet_Users.UserId INNER JOIN
                  IMIS_tblStore ON FMIS_tblCashierBalance.StoreID = IMIS_tblStore.StoreID
WHERE  (FMIS_tblCashierBalance.ClosingStatus = 'Open and Recipt Printed') and FMIS_tblCashierBalance.UserID=N'" + UserID + "' ORDER BY FMIS_tblCashierBalance.ID");

            }
      
        }

        private void GetClosingData(string ID)
        {
            DataTable dt = obj.GetData(@"SELECT        FMIS_tblCashierBalance.ID, FMIS_tblCashierBalance.UserID, Lookup_tblCurrency.CurrencyName, FMIS_tblCashierBalance.OpeningBalance, isnull(TotalCashIn,0) as TotalCashIn, isnull(TotalCashOut,0) as TotalCashOut
FROM            FMIS_tblCashierBalance INNER JOIN
                         Lookup_tblCurrency ON FMIS_tblCashierBalance.CurrencyID = Lookup_tblCurrency.CurrencyID
WHERE        FMIS_tblCashierBalance.ID = " + ID + "");
            txtCurrency.Text = dt.Rows[0]["CurrencyName"].ToString();
            txtOpeningBalanceC.Text = dt.Rows[0]["OpeningBalance"].ToString();
            txtTotalCashIn.Text = dt.Rows[0]["TotalCashIn"].ToString();
            txtTotalCashOut.Text = dt.Rows[0]["TotalCashOut"].ToString();

            txtBalance.Text =Convert.ToString( Decimal.Parse(dt.Rows[0]["OpeningBalance"].ToString()) + Decimal.Parse(dt.Rows[0]["TotalCashIn"].ToString()) - Decimal.Parse(dt.Rows[0]["TotalCashOut"].ToString()));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "بسته نماید")
            {
                string ID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblID.Text = ID;
                GetClosingData(ID);
                pnlClsoingBalance.Visible = true;
                pnlClsoingBalance.BringToFront();
                txtClosingBalance.Focus();
                txtClosingBalance.Text = "";
                txtOverageAmount.Text = "";
                txtShortageValue.Text = "";

            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            pnlClsoingBalance.Visible = false;
            pnlClsoingBalance.SendToBack();

        }

        private void txtClosingBalance_TextChanged(object sender, EventArgs e)
        {
            Decimal OpeningBalance = 0;
            Decimal TotalCashIn = 0;
            Decimal TotalCashOut = 0;
            Decimal TotalClosing = 0;
            Decimal TotalShortage = 0;
            Decimal CashirClsoing = 0;
            CashirClsoing = Decimal.Parse(txtClosingBalance.Text == "" ? "0" : txtClosingBalance.Text);
            OpeningBalance = Decimal.Parse(txtOpeningBalanceC.Text);
            TotalCashIn = Decimal.Parse(txtTotalCashIn.Text);
            TotalCashOut = Decimal.Parse(txtTotalCashOut.Text);
            TotalClosing = (OpeningBalance + TotalCashIn) - TotalCashOut;
            TotalShortage = TotalClosing - CashirClsoing;
            txtOverageAmount.Text = "0";
            txtShortageValue.Text = "0";
            if (TotalShortage > 0)
            {
                txtShortageValue.Text = TotalShortage.ToString();
                txtOverageAmount.Text = "0";
            }
            else if (TotalShortage < 0)
            {
                txtOverageAmount.Text = Math.Abs(TotalShortage).ToString();
                txtShortageValue.Text = "0";
            }
        }

        private void btnClsoe_Click(object sender, EventArgs e)
        {
            if (txtClosingBalance.Text == "")
            {
                MessageBox.Show("پول بسته نمودن لازمی هست");
                txtClosingBalance.Focus();
                return;
            }
            if (MessageBox.Show("ایا شما میخواهی کی بلانس بسته شود?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                obj.ExecuteQuery(@"update FMIS_tblCashierBalance set ClosingBalance=" + txtClosingBalance.Text + ",ShortageAmount=" + txtShortageValue.Text + ",OverageAmount=" + txtOverageAmount.Text + ",ClosingDate=getdate(),ClosingTime=getdate(),ClosingStatus='Closed',Reason=N'" + txtShortageReason.Text + "',EntryUser=N'" + conclass.User_ID + "' where Id=" + lblID.Text + "");
                MessageBox.Show("Cashir Balance Closed for Selected Currency");
                //FillOpeningBalance(conclass.User_ID);
                //FillClosingBalance(conclass.User_ID);
                //fillClosingSummary(conclass.User_ID);
                pnlClsoingBalance.Visible = false;
                pnlClsoingBalance.SendToBack();
            }

            if (conclass.IsInRole(conclass.UserName, "Finance Admin"))
                GetPendingBalance("All", "");
            else
                GetPendingBalance("", conclass.User_ID);
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            string from = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
            string to = this.dtto.Value.Month.ToString() + "/" + this.dtto.Value.Day.ToString() + "/" + this.dtto.Value.Year.ToString();
            DataTable dt = obj.GetData(@"SELECT        ID, FMIS_tblCashierBalance.CurrencyID,StoreNameLocal,UserName, CurrencyName, convert(varchar(12),OpeningDate) +':'+    CONVERT(varchar(5), OpeningTime, 108) OpeningDate, OpeningBalance,isnull(TotalCashIn,0) as TotalCashIn, isnull(TotalCashOut,0) as TotalCashOut, ClosingBalance,Convert(varchar(12),ClosingDate,107)  +':'+  CONVERT(varchar(5), ClosingTime, 108)        as ClosingDate, ShortageAmount, 
                         OverageAmount,ClosingStatus, Reason,N'رسید' AS Slip
FROM     FMIS_tblCashierBalance INNER JOIN
                  Lookup_tblCurrency ON FMIS_tblCashierBalance.CurrencyID = Lookup_tblCurrency.CurrencyID INNER JOIN
                  aspnet_Users ON FMIS_tblCashierBalance.UserID = aspnet_Users.UserId INNER JOIN
                  IMIS_tblStore ON FMIS_tblCashierBalance.StoreID = IMIS_tblStore.StoreID
				  where ClosingStatus='Closed'  and cast(convert(varchar(12),ClosingDate,101) as datetime) between cast('" + from + "' as datetime) and cast('" + to + "' as datetime ) and ClosingStatus='Closed' order by ID");
            grdReport.DataSource = dt;
        }
        private void radButton2_Click(object sender, EventArgs e)
        {
            string from = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
            string to = this.dtto.Value.Month.ToString() + "/" + this.dtto.Value.Day.ToString() + "/" + this.dtto.Value.Year.ToString(); 
        }
        private void grdReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = conclass.GetRecord(@"SELECT        ID, FMIS_tblCashierBalance.CurrencyID,StoreNameLocal as StoreName,UserName, CurrencyName, dbo.ToPersianDate(OpeningDate) +':'+    CONVERT(varchar(5), OpeningTime, 108) OpeningDate, OpeningBalance, isnull(TotalCashIn,0) as TotalCashIn, isnull(TotalCashOut,0) as TotalCashOut, ClosingBalance,Convert(varchar(12),ClosingDate,107)  +':'+  CONVERT(varchar(5), ClosingTime, 108)        as ClosingDate, ShortageAmount, 
                         OverageAmount,ClosingStatus, Reason
FROM     FMIS_tblCashierBalance INNER JOIN
                  Lookup_tblCurrency ON FMIS_tblCashierBalance.CurrencyID = Lookup_tblCurrency.CurrencyID INNER JOIN
                  aspnet_Users ON FMIS_tblCashierBalance.UserID = aspnet_Users.UserId INNER JOIN
                  IMIS_tblStore ON FMIS_tblCashierBalance.StoreID = IMIS_tblStore.StoreID
				  where  id=" + grdReport.Rows[e.RowIndex].Cells[0].Value.ToString() + "");
            Reports.rptCahsirClosingBalance obj = new Stock_System.Reports.rptCahsirClosingBalance();
            obj.SetDataSource(dt);
            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;
            frm2.ShowDialog();
        }

        private void OpeningBalances_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
