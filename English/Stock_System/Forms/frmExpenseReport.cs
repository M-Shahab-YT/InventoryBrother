using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data;
using System.Data.SqlClient;
using Stock_System.Class;
namespace Stock_System.Forms
{
    public partial class frmExpenseReport : Telerik.WinControls.UI.RadForm
    {
        Dbcommon obj = new Dbcommon();
        public frmExpenseReport()
        {
            InitializeComponent();
        }

        Decimal TotalExpense = 0;
        private void FillExpenseDetail()
        {
            TotalExpense = 0;
            string from = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
            string to = this.dtto.Value.Month.ToString() + "/" + this.dtto.Value.Day.ToString() + "/" + this.dtto.Value.Year.ToString();

            string Query = @"SELECT  FMIS_tblExpenseDetail.ID, FMIS_tblExpenseHead.ExpenseHeadName, FMIS_tblExpenseDetail.ExpenseDetail,convert(varchar(12),FMIS_tblExpenseDetail.ExpenseDate,107) as ExpenseDate, FMIS_tblExpenseDetail.ExpenseAmount, 
                         FMIS_tblExpenseDetail.ExchangeRate, FMIS_tblExpenseDetail.BasCurrencyAmount, Lookup_tblCurrency.CurrencyName
FROM            FMIS_tblExpenseDetail INNER JOIN
                         FMIS_tblExpenseHead ON FMIS_tblExpenseDetail.ExpenseHeadID = FMIS_tblExpenseHead.ExpenseHeadID INNER JOIN
                         Lookup_tblCurrency ON FMIS_tblExpenseDetail.CurrencyID = Lookup_tblCurrency.CurrencyID
WHERE        (FMIS_tblExpenseDetail.StoreID = " + conclass.StoreID + ")  and cast(convert(varchar(12),ExpenseDate,101) as datetime) between cast('" + from + "' as datetime) and cast('" + to + "' as datetime) order by FMIS_tblExpenseDetail.ID";

            DataTable dt = obj.GetData(Query);
            lstExpenseDetail.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["ID"].ToString());
                item.SubItems.Add(dr["ExpenseHeadName"].ToString());
                item.SubItems.Add(dr["ExpenseDetail"].ToString());
                item.SubItems.Add(dr["ExpenseAmount"].ToString());
                item.SubItems.Add(dr["CurrencyName"].ToString());
                item.SubItems.Add(dr["ExchangeRate"].ToString());
                item.SubItems.Add(dr["BasCurrencyAmount"].ToString());
                item.SubItems.Add(dr["ExpenseDate"].ToString());
                lstExpenseDetail.Items.Add(item);
                TotalExpense = TotalExpense + Decimal.Parse(dr["BasCurrencyAmount"].ToString());
               
            }
            txtTotalExpenses.Text = TotalExpense.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillExpenseDetail();
        }

        private void btnGroupReport_Click(object sender, EventArgs e)
        {
            string from = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
            string to = this.dtto.Value.Month.ToString() + "/" + this.dtto.Value.Day.ToString() + "/" + this.dtto.Value.Year.ToString();

            DataTable dt = new DataTable();
            dt = conclass.GetRecord(@"SELECT        Expense_Type_ID, ExpenseHeadName, ExpenseDetail, convert(varchar(12),ExpenseDate,107) as ExpenseDate, CurrencyName, ExchangeRate, BasCurrencyAmount, ID, StoreID
FROM            Expense_DetailView where StoreID=" + conclass.StoreID + " and cast(convert(varchar(12),ExpenseDate,101) as datetime) between cast('" + from + "' as datetime) and cast('" + to + "' as datetime )");

//            dt = conclass.GetRecord(@"SELECT  FMIS_tblExpenseDetail.ID, FMIS_tblExpenseHead.ExpenseHeadName, FMIS_tblExpenseDetail.ExpenseDetail,convert(varchar(12),FMIS_tblExpenseDetail.ExpenseDate,107) as ExpenseDate, FMIS_tblExpenseDetail.ExpenseAmount, 
//                         FMIS_tblExpenseDetail.ExchangeRate, FMIS_tblExpenseDetail.BasCurrencyAmount, Lookup_tblCurrency.CurrencyName
//FROM            FMIS_tblExpenseDetail INNER JOIN
//                         FMIS_tblExpenseHead ON FMIS_tblExpenseDetail.ExpenseHeadID = FMIS_tblExpenseHead.ExpenseHeadID INNER JOIN
//                         Lookup_tblCurrency ON FMIS_tblExpenseDetail.CurrencyID = Lookup_tblCurrency.CurrencyID where FMIS_tblExpenseDetail.StoreID=" + conclass.StoreID + " and (CAST(CONVERT(varchar(12), ExpenseDate, 106) AS datetime) >= CAST(CONVERT(varchar(12), GETDATE(), 106) AS Datetime)) AND (CAST(CONVERT(varchar(12), ExpenseDate,106) AS datetime) <= CAST(CONVERT(varchar(12), GETDATE(), 106) AS Datetime))");


            Reports.rptExpensesReport obj = new Stock_System.Reports.rptExpensesReport();
            obj.SetDataSource(dt);
            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;
            //frm2.crystalReportViewer1.PrintReport();
            frm2.ShowDialog();
        }

        private void frmExpenseReport_Load(object sender, EventArgs e)
        {
            TotalExpense = 0;
          DataTable dt = new DataTable();
          dt = conclass.GetRecord(@"SELECT  FMIS_tblExpenseDetail.ID, FMIS_tblExpenseHead.ExpenseHeadName, FMIS_tblExpenseDetail.ExpenseDetail,convert(varchar(12),FMIS_tblExpenseDetail.ExpenseDate,107) as ExpenseDate, FMIS_tblExpenseDetail.ExpenseAmount, 
                         FMIS_tblExpenseDetail.ExchangeRate, FMIS_tblExpenseDetail.BasCurrencyAmount, Lookup_tblCurrency.CurrencyName
FROM            FMIS_tblExpenseDetail INNER JOIN
                         FMIS_tblExpenseHead ON FMIS_tblExpenseDetail.ExpenseHeadID = FMIS_tblExpenseHead.ExpenseHeadID INNER JOIN
                         Lookup_tblCurrency ON FMIS_tblExpenseDetail.CurrencyID = Lookup_tblCurrency.CurrencyID where FMIS_tblExpenseDetail.StoreID=" + conclass.StoreID + " and (CAST(CONVERT(varchar(12), ExpenseDate, 106) AS datetime) >= CAST(CONVERT(varchar(12), GETDATE(), 106) AS Datetime)) AND (CAST(CONVERT(varchar(12), ExpenseDate,106) AS datetime) <= CAST(CONVERT(varchar(12), GETDATE(), 106) AS Datetime))");
            lstExpenseDetail.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["ID"].ToString());
                item.SubItems.Add(dr["ExpenseHeadName"].ToString());
                item.SubItems.Add(dr["ExpenseDetail"].ToString());
                item.SubItems.Add(dr["ExpenseAmount"].ToString());
                item.SubItems.Add(dr["CurrencyName"].ToString());
                item.SubItems.Add(dr["ExpenseDate"].ToString());
                lstExpenseDetail.Items.Add(item);
                TotalExpense = TotalExpense + Decimal.Parse(dr["ExpenseAmount"].ToString());
            }
            txtTotalExpenses.Text = TotalExpense.ToString();
        }
    }
}
