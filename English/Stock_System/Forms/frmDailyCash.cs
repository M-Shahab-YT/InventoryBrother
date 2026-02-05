using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
namespace Stock_System.Forms
{
    public partial class frmDailyCash : Telerik.WinControls.UI.RadForm
    {
        Class.Dbcommon obj = new Stock_System.Class.Dbcommon();
        public frmDailyCash()
        {
            InitializeComponent();
        }
        private void frmDailyCash_Load(object sender, EventArgs e)
        {
            obj.fillcmb(cmbCahier, "FullName", "UserId", @"SELECT        HRMIS_tblEmployeeInformation.FullName, aspnet_Users.UserId, HRMIS_tblEmployeeInformation.StoreID
FROM            aspnet_Users INNER JOIN
                         HRMIS_tblEmployeeInformation ON aspnet_Users.Registration_Number = HRMIS_tblEmployeeInformation.EmployeeID
WHERE       IsAnonymous=0 and  HRMIS_tblEmployeeInformation.StoreID = "+Class.conclass.StoreID+"");
        }
        private void cmbCahier_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillList();
        }
        private void FillList()
        {
            try
            {
                lstDailyCash.Items.Clear();
                DataTable dt = new DataTable();
                dt = Class.conclass.GetRecord(@"SELECT        M.AccountID, M.UserID, CAST(CONVERT(varchar(12), M.SystemDate, 106) AS datetime) AS SystemDate,
                             (SELECT        ISNULL(SUM(Amount), 0) AS Expr1
                               FROM            FMIS_tblCashAccountsInOutDetail AS D
                               WHERE        (InOutStatus = 'In') AND (M.AccountID = AccountID) AND (M.UserID = UserID) AND (CAST(CONVERT(varchar(12), SystemDate, 106) AS datetime) = CAST(CONVERT(varchar(12), M.SystemDate, 106) AS datetime))) 
                         AS TotalIN,
                             (SELECT        ISNULL(SUM(Amount), 0) AS Expr1
                               FROM            FMIS_tblCashAccountsInOutDetail AS D
                               WHERE        (InOutStatus = 'Out') AND (M.AccountID = AccountID) AND (M.UserID = UserID) AND (CAST(CONVERT(varchar(12), SystemDate, 106) AS datetime) = CAST(CONVERT(varchar(12), M.SystemDate, 106) AS datetime))) 
                         AS TotalOut,
                             (SELECT        ISNULL(SUM(Amount), 0) AS Expr1
                               FROM            FMIS_tblCashAccountsInOutDetail AS D
                               WHERE        (InOutStatus = 'In') AND (M.AccountID = AccountID) AND (M.UserID = UserID) AND (CAST(CONVERT(varchar(12), SystemDate, 106) AS datetime) = CAST(CONVERT(varchar(12), M.SystemDate, 106) AS datetime))) 
                         -
                             (SELECT        ISNULL(SUM(Amount), 0) AS Expr1
                               FROM            FMIS_tblCashAccountsInOutDetail AS D
                               WHERE        (InOutStatus = 'Out') AND (M.AccountID = AccountID) AND (M.UserID = UserID) AND (CAST(CONVERT(varchar(12), SystemDate, 106) AS datetime) = CAST(CONVERT(varchar(12), M.SystemDate, 106) AS datetime))) 
                         AS Balance, FMIS_tblCashAccounts.AccountName, Lookup_tblCurrency.CurrencyName
FROM            FMIS_tblCashAccountsInOutDetail AS M INNER JOIN
                         FMIS_tblCashAccounts ON M.AccountID = FMIS_tblCashAccounts.AccountID INNER JOIN
                         Lookup_tblCurrency ON FMIS_tblCashAccounts.CurrencyID = Lookup_tblCurrency.CurrencyID
WHERE        (M.StoreID = "+Class.conclass.StoreID+") AND (M.UserID = '"+cmbCahier.SelectedValue+"') AND (CAST(CONVERT(varchar(12), M.SystemDate, 106) AS datetime) = CAST(CONVERT(varchar(12), GETDATE(), 106) AS Datetime)) GROUP BY M.AccountID, M.UserID, CAST(CONVERT(varchar(12), M.SystemDate, 106) AS datetime), FMIS_tblCashAccounts.AccountName, Lookup_tblCurrency.CurrencyName");
              
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["AccountID"].ToString());
                    item.SubItems.Add(dr["AccountName"].ToString());
                    item.SubItems.Add(dr["CurrencyName"].ToString());
                    item.SubItems.Add(dr["SystemDate"].ToString());
                    item.SubItems.Add(dr["TotalIN"].ToString());
                    item.SubItems.Add(dr["TotalOut"].ToString());
                    item.SubItems.Add(dr["Balance"].ToString());
                    lstDailyCash.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillList();
        }
//SELECT  M.AccountID, M.AccountName, M.CurrencyName as CurrencyName, M.UserID,(CAST(CONVERT(varchar(12), M.SystemDate, 106) AS datetime)) As Date,sum(M.Amount) as CashIN,
//(SELECT  ISNULL(SUM(Amount), 0) AS TotalOut  FROM dbo.FMIS_VWUserBaseCashInOutDetail D WHERE D.InOutStatus = 'Out' AND D.AccountID = M.AccountID and D.UserID=M.UserID and (CAST(CONVERT(varchar(12), D.SystemDate, 106) AS datetime))=(CAST(CONVERT(varchar(12), M.SystemDate, 106) AS datetime))) AS CashOut,

//(SELECT  ISNULL(SUM(Amount), 0) AS TotalOut  FROM dbo.FMIS_VWUserBaseCashInOutDetail D WHERE D.InOutStatus = 'IN' AND D.AccountID = M.AccountID and D.UserID=M.UserID and (CAST(CONVERT(varchar(12), D.SystemDate, 106) AS datetime))=(CAST(CONVERT(varchar(12), M.SystemDate, 106) AS datetime)))-
//(SELECT  ISNULL(SUM(Amount), 0) AS TotalOut  FROM dbo.FMIS_VWUserBaseCashInOutDetail D WHERE D.InOutStatus = 'Out' AND D.AccountID = M.AccountID and D.UserID=M.UserID and (CAST(CONVERT(varchar(12), D.SystemDate, 106) AS datetime))=(CAST(CONVERT(varchar(12), M.SystemDate, 106) AS datetime))) AS Balance

//FROM FMIS_VWUserBaseCashInOutDetail M where M.UserID='789fda24-5281-42ee-93fe-cc52f5a548fb' and  (CAST(CONVERT(varchar(12), M.SystemDate, 106) AS datetime) = CAST(CONVERT(varchar(12), getdate(), 106) AS Datetime)) 
//group by M.AccountID, M.AccountName, M.CurrencyName, M.UserID,(CAST(CONVERT(varchar(12), M.SystemDate, 106) AS datetime))


    }
}
