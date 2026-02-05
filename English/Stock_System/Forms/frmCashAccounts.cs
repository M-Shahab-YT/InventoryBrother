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
namespace Stock_System.Forms
{
    public partial class frmCashAccounts : Telerik.WinControls.UI.RadForm
    {
        Dbcommon obj = new Dbcommon();
        public frmCashAccounts()
        {
            InitializeComponent();
        }

        private void frmCashAccounts_Load(object sender, EventArgs e)
        {
            obj.fillcmb(cmbCurrency, "CurrencyName", "CurrencyID", @"SELECT        CurrencyID,Convert(nvarchar(12), CurrencyName)+'-'+ Convert(nvarchar(12),CurrencySymbol) as CurrencyName FROM  Lookup_tblCurrency");
            obj.fillcmb(cmbPaymentAccount, "AccountName", "AccountID", "SELECT  AccountID, AccountName FROM FMIS_tblCashAccounts where StoreID=" + conclass.StoreID + "");
            FillListCashAccount();
            FillGrid();


            obj.fillcmb(cmbWithdrawAccount, "AccountName", "AccountID", "SELECT   AccountID, AccountName FROM FMIS_tblCashAccounts where StoreID=" + conclass.StoreID + "");
            obj.fillcmb(cmbDepositAccount, "AccountName", "AccountID", "SELECT   AccountID, AccountName FROM FMIS_tblCashAccounts where StoreID=" + conclass.StoreID + "");
            FillDepositGrid("Cash Deposit");
            FillDepositGrid("Cash Withdraw");
        }
        private void FillGrid()
        {
            DataTable dt = obj.GetData(@"SELECT        FMIS_tblCashAccounts.AccountID, FMIS_tblCashAccounts.AccountName,  FMIS_tblCashAccounts.AccountDetail,Lookup_tblCurrency.CurrencyName +' '+ Lookup_tblCurrency.CurrencySymbol as CurrencyName, FMIS_tblCashAccounts.OpeningBalance,
(SELECT   isnull(sum(Amount),0) as Total_In FROM   FMIS_tblCashAccountsInOutDetail where InOutStatus='In' and FMIS_tblCashAccountsInOutDetail.AccountID=FMIS_tblCashAccounts.AccountID) as Total_In,
(SELECT   isnull(sum(Amount),0) as Total_In FROM   FMIS_tblCashAccountsInOutDetail where InOutStatus='Out' and FMIS_tblCashAccountsInOutDetail.AccountID=FMIS_tblCashAccounts.AccountID) as Total_Out,

REPLACE(CONVERT(VARCHAR,CONVERT(MONEY,
(isnull(FMIS_tblCashAccounts.OpeningBalance,0)+(SELECT   isnull(sum(Amount),0) as Total_In FROM   FMIS_tblCashAccountsInOutDetail where InOutStatus='In' and FMIS_tblCashAccountsInOutDetail.AccountID=FMIS_tblCashAccounts.AccountID))-(SELECT   isnull(sum(Amount),0) as Total_In FROM   FMIS_tblCashAccountsInOutDetail where InOutStatus='Out' and FMIS_tblCashAccountsInOutDetail.AccountID=FMIS_tblCashAccounts.AccountID)),1), '.00','') as Current_Balance  
FROM FMIS_tblCashAccounts INNER JOIN  Lookup_tblCurrency ON FMIS_tblCashAccounts.CurrencyID = Lookup_tblCurrency.CurrencyID where FMIS_tblCashAccounts.StoreID="+conclass.StoreID+" order by CurrencyName");
            dataGridView1.DataSource = dt;
        }
        private void btnSaveCashAccount_Click(object sender, EventArgs e)
        {
            if (txtAccountName.Text == "")
            {
                MessageBox.Show("Account Name is required!");
                txtAccountName.Focus();
                return;
            }
            if (txtOpeningBalance.Text == "")
            {
                MessageBox.Show("Opening Balance is required!");
                txtOpeningBalance.Focus();
                return;
            }


            if (btnSaveCashAccount.Text == "Save")
            {
                obj.ExecuteQuery("insert into FMIS_tblCashAccounts(AccountName, AccountDetail, OpeningBalance, CurrencyID, StoreID, UserID) values(N'" + txtAccountName.Text + "', N'" + txtAccountDetail.Text + "', " + txtOpeningBalance.Text + ", " + cmbCurrency.SelectedValue + ", " + conclass.StoreID + ", N'" + conclass.User_ID + "')");
                MessageBox.Show("Account Created Successfully..");
            }
            else
            {
                obj.ExecuteQuery("update FMIS_tblCashAccounts set AccountName=N'" + txtAccountName.Text + "',AccountDetail=N'" + txtAccountDetail.Text + "',OpeningBalance=" + txtOpeningBalance.Text + ",CurrencyID=" + cmbCurrency.SelectedValue + ",LastUpdatedBy=N'" + conclass.User_ID + "', LastUpdatedDate=getdate() where AccountID=" + txtAccountName.Tag.ToString() + "");
                MessageBox.Show("Account Updated Successfully..");
            }
            txtOpeningBalance.Text = "";
            txtAccountName.Text = "";
            txtAccountDetail.Text = "";
            btnSaveCashAccount.Text = "Save";
            FillListCashAccount();
            txtAccountName.Focus();
        }

        private void lstCashAccount_DoubleClick(object sender, EventArgs e)
        {
            txtAccountName.Tag = lstCashAccount.SelectedItems[0].SubItems[0].Text;
            txtAccountName.Text = lstCashAccount.SelectedItems[0].SubItems[1].Text;
            txtAccountDetail.Text = lstCashAccount.SelectedItems[0].SubItems[2].Text;
            txtOpeningBalance.Text = lstCashAccount.SelectedItems[0].SubItems[3].Text;
            cmbCurrency.SelectedValue = lstCashAccount.SelectedItems[0].SubItems[5].Text;
            btnSaveCashAccount.Text = "Update";
        }
        private void FillListCashAccount()
        {
            try
            {
                lstCashAccount.Items.Clear();
                DataTable dt = new DataTable();
                dt = Class.conclass.GetRecord(@"SELECT        FMIS_tblCashAccounts.AccountID, FMIS_tblCashAccounts.AccountName, FMIS_tblCashAccounts.AccountDetail, FMIS_tblCashAccounts.OpeningBalance, FMIS_tblCashAccounts.CurrencyID, FMIS_tblCashAccounts.StoreID, 
                         FMIS_tblCashAccounts.UserID, FMIS_tblCashAccounts.SystemDate, FMIS_tblCashAccounts.LastUpdatedBy, FMIS_tblCashAccounts.LastUpdatedDate, Lookup_tblCurrency.CurrencyName
FROM            FMIS_tblCashAccounts INNER JOIN
                         Lookup_tblCurrency ON FMIS_tblCashAccounts.CurrencyID = Lookup_tblCurrency.CurrencyID and FMIS_tblCashAccounts.StoreID="+conclass.StoreID+"");
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["AccountID"].ToString());
                    item.SubItems.Add(dr["AccountName"].ToString());
                    item.SubItems.Add(dr["AccountDetail"].ToString());
                    item.SubItems.Add(dr["OpeningBalance"].ToString());
                    item.SubItems.Add(dr["CurrencyName"].ToString());
                    item.SubItems.Add(dr["CurrencyID"].ToString());
                    lstCashAccount.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtOpeningBalance.Text = "";
            txtAccountName.Text = "";
            txtAccountDetail.Text = "";
            btnSaveCashAccount.Text = "Save";
            FillListCashAccount();
            txtAccountName.Focus();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string from = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
            string to = this.dtto.Value.Month.ToString() + "/" + this.dtto.Value.Day.ToString() + "/" + this.dtto.Value.Year.ToString();

            #region Summary Report
            DataTable dt = obj.GetData(@"SELECT   FMIS_VWCashInCashOut.ID, CONVERT(varchar(12), FMIS_VWCashInCashOut.SystemDate, 107) AS Date, FMIS_VWCashInCashOut.AccountID, FMIS_tblCashAccounts.AccountName, 
                         Lookup_tblCurrency.CurrencyName, FMIS_VWCashInCashOut.EntryReference, FMIS_VWCashInCashOut.EntryReferenceNumber, FMIS_VWCashInCashOut.Remarks, 
                         FMIS_VWCashInCashOut.DR, FMIS_VWCashInCashOut.CR, FMIS_VWCashInCashOut.UserName,'View' as Detail FROM         FMIS_VWCashInCashOut INNER JOIN  FMIS_tblCashAccounts ON FMIS_VWCashInCashOut.AccountID = FMIS_tblCashAccounts.AccountID INNER JOIN
                         Lookup_tblCurrency ON FMIS_tblCashAccounts.CurrencyID = Lookup_tblCurrency.CurrencyID where FMIS_tblCashAccounts.StoreID="+conclass.StoreID+" and cast(convert(varchar(12),FMIS_VWCashInCashOut.SystemDate,101) as datetime) between cast('" + from + "' as datetime) and cast('" + to + "' as datetime ) AND FMIS_VWCashInCashOut.AccountID=" + cmbPaymentAccount.SelectedValue + "");
            dgAccount.DataSource = dt;
            Decimal TotalDr = 0;
            Decimal TotalCr = 0;
            foreach (DataRow dr in dt.Rows)
            {
                TotalDr = TotalDr + Decimal.Parse(dr["DR"].ToString());
                TotalCr = TotalCr + Decimal.Parse(dr["CR"].ToString());
            }
            lblTotalDr.Text = TotalDr.ToString();
            lblTotalCr.Text = TotalCr.ToString();
            #endregion 

            #region Cash Despoit and WithDraw By Date
            FillDepositAndWitdrawByDate(from, to);
            #endregion 
        }
        private void dgAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ID = "";
            string EntryReference = "";
            string EntryReferenceNumber = "";
            string AccountName = "";
            string Date = "";
            if (dgAccount.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "View")
            {
                ID = dgAccount.Rows[e.RowIndex].Cells[0].Value.ToString();
                EntryReference = dgAccount.Rows[e.RowIndex].Cells[5].Value.ToString();
                EntryReferenceNumber = dgAccount.Rows[e.RowIndex].Cells[6].Value.ToString();
                AccountName = dgAccount.Rows[e.RowIndex].Cells[3].Value.ToString();
                Date = dgAccount.Rows[e.RowIndex].Cells[1].Value.ToString();
                GetAccountDetail(EntryReferenceNumber, EntryReference, AccountName,Date);
            }
        }


        private void GetAccountDetail(string RefNo, string RefType, string AccountName,string Date)
        {
            Decimal GrandTotal = 0;
            lblDate.Text = Date;
            lblAccountName.Text = AccountName;
            lblReference.Text = RefType;
            lstPurchaseSale.Items.Clear();
            lstExpenses.Items.Clear();
            if (RefType == "Sales")
            {
                DataTable dt = obj.GetData(@"SELECT  IMIS_tblSaleOrderDetail.ProductCode, IMIS_VWProducts.ProductName, IMIS_tblSaleOrderDetail.Quantity, IMIS_tblSaleOrderDetail.SalePrice, IMIS_tblSaleOrderDetail.Discount, IMIS_tblSaleOrderDetail.Total, 
                IMIS_tblSaleOrderDetail.InvoiceNo FROM    IMIS_tblSaleOrderDetail INNER JOIN   IMIS_VWProducts ON IMIS_tblSaleOrderDetail.ProductCode = IMIS_VWProducts.ProductCode WHERE  (IMIS_tblSaleOrderDetail.Status <> 'Full Returned') and IMIS_tblSaleOrderDetail.StoreID="+conclass.StoreID+" AND (IMIS_tblSaleOrderDetail.InvoiceNo = '" + RefNo + "')");
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
                    lstExpenses.Visible = false;
                }
                lblGrandTotal.Text = GrandTotal.ToString();
                pnlProduct.Visible = true;
                pnlProduct.BringToFront();
            }

            else if (RefType == "Sale Return")
            {
                DataTable dt = obj.GetData(@"SELECT  IMIS_tblSaleOrderDetail.ProductCode, IMIS_VWProducts.ProductName, IMIS_tblSaleOrderDetail.QuantityReturned as Quantity, 

IMIS_tblSaleOrderDetail.SalePrice-isnull(IMIS_tblSaleOrderDetail.Discount,0) as SalePrice,

(IMIS_tblSaleOrderDetail.SalePrice-isnull(IMIS_tblSaleOrderDetail.Discount,0))*IMIS_tblSaleOrderDetail.QuantityReturned as Total
, IMIS_tblSaleOrderDetail.InvoiceNo,IMIS_tblSaleOrderDetail.Status FROM    IMIS_tblSaleOrderDetail INNER JOIN   IMIS_VWProducts ON IMIS_tblSaleOrderDetail.ProductCode = IMIS_VWProducts.ProductCode 
WHERE  IMIS_tblSaleOrderDetail.Status in('Quantity Returned', 'Full Returned') and IMIS_tblSaleOrderDetail.StoreID="+conclass.StoreID+" AND (IMIS_tblSaleOrderDetail.InvoiceNo = '" + RefNo + "')");
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
                lstExpenses.Visible = false;
                lblGrandTotal.Text = GrandTotal.ToString();
            }
            else if (RefType == "Purchase")
            {
                DataTable dt = obj.GetData(@"SELECT IMIS_tblPurchaseOrderDetail.PurchaseOrderNo, IMIS_tblPurchaseOrderDetail.ProductCode, IMIS_VWProducts.ProductName, IMIS_tblPurchaseOrderDetail.PurchasePrice, IMIS_tblPurchaseOrderDetail.ShippingCostPerItem,  IMIS_tblPurchaseOrderDetail.Quantity, IMIS_tblPurchaseOrderDetail.Total, IMIS_tblPurchaseOrderDetail.Status, IMIS_tblPurchaseOrderDetail.QuantityReturned  FROM IMIS_tblPurchaseOrderDetail INNER JOIN  IMIS_VWProducts ON IMIS_tblPurchaseOrderDetail.ProductCode = IMIS_VWProducts.ProductCode  where Status<>'Full Returned' and IMIS_tblPurchaseOrderDetail.StoreID="+conclass.StoreID+" and PurchaseOrderNo = '" + RefNo + "'");
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
                lstExpenses.Visible = false;
                lblGrandTotal.Text = GrandTotal.ToString();
                pnlProduct.Visible = true;
                pnlProduct.BringToFront();
            }
            else if (RefType == "Purchase Return")
            {
                DataTable dt = obj.GetData(@"SELECT IMIS_tblPurchaseOrderDetail.PurchaseOrderNo, IMIS_tblPurchaseOrderDetail.ProductCode, IMIS_VWProducts.ProductName, PurchasePrice-isnull(ShippingCostPerItem,0) as PurchasePrice, (PurchasePrice-isnull(ShippingCostPerItem,0))*QuantityReturned  as Total, IMIS_tblPurchaseOrderDetail.ShippingCostPerItem,  IMIS_tblPurchaseOrderDetail.QuantityReturned as Quantity, IMIS_tblPurchaseOrderDetail.Status FROM IMIS_tblPurchaseOrderDetail INNER JOIN  IMIS_VWProducts ON IMIS_tblPurchaseOrderDetail.ProductCode = IMIS_VWProducts.ProductCode  where Status in('Full Returned','Quantity Returned') and IMIS_tblPurchaseOrderDetail.StoreID="+conclass.StoreID+" and PurchaseOrderNo = '" + RefNo + "'");
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
                lstExpenses.Visible = false;
                lblGrandTotal.Text = GrandTotal.ToString();
                pnlProduct.Visible = true;
                pnlProduct.BringToFront();
            }
            else if (RefType == "Expense")
            {
                string Query = @"SELECT  FMIS_tblExpenseDetail.ID, FMIS_tblExpenseHead.ExpenseHeadName, FMIS_tblExpenseDetail.ExpenseDetail,convert(varchar(12),FMIS_tblExpenseDetail.ExpenseDate,107) as ExpenseDate, FMIS_tblExpenseDetail.ExpenseAmount, 
                         FMIS_tblExpenseDetail.ExchangeRate, FMIS_tblExpenseDetail.BasCurrencyAmount, Lookup_tblCurrency.CurrencyName
FROM            FMIS_tblExpenseDetail INNER JOIN
                         FMIS_tblExpenseHead ON FMIS_tblExpenseDetail.ExpenseHeadID = FMIS_tblExpenseHead.ExpenseHeadID INNER JOIN
                         Lookup_tblCurrency ON FMIS_tblExpenseDetail.CurrencyID = Lookup_tblCurrency.CurrencyID
WHERE    FMIS_tblExpenseDetail.StoreID=" + conclass.StoreID + " and  FMIS_tblExpenseDetail.ID=" + RefNo + "  ";

                DataTable dt = obj.GetData(Query);
                lstExpenses.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["ExpenseHeadName"].ToString());
                    item.SubItems.Add(dr["ExpenseDetail"].ToString());
                    item.SubItems.Add(dr["ExpenseAmount"].ToString());
                    GrandTotal = GrandTotal + Decimal.Parse(dr["ExpenseAmount"].ToString());
                    lstExpenses.Items.Add(item);
                }
                lblGrandTotal.Text = GrandTotal.ToString();
                lstPurchaseSale.Visible = false;
                lstExpenses.Visible = true;
                pnlProduct.Visible = true;
                pnlProduct.BringToFront();
            }
            else
            {
                MessageBox.Show("No details found for the selected transactions!");
            
            }
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlProduct.Visible = false;
            pnlProduct.SendToBack();
        }

        private void FillDepositGrid(string EntryReference)
        {
            if (EntryReference == "Cash Deposit")
            {
                grdDeposit.DataSource = obj.GetData(@"SELECT   FMIS_tblCashAccountsInOutDetail.ID, FMIS_tblCashAccountsInOutDetail.AccountID, FMIS_tblCashAccounts.AccountName, FMIS_tblCashAccountsInOutDetail.Amount, 
                         FMIS_tblCashAccountsInOutDetail.Remarks, convert(varchar(12),FMIS_tblCashAccountsInOutDetail.SystemDate,107) as SystemDate,'Print Recipt' as Report,'Delete' as DeleteRecord
FROM         FMIS_tblCashAccountsInOutDetail INNER JOIN
                         FMIS_tblCashAccounts ON FMIS_tblCashAccountsInOutDetail.AccountID = FMIS_tblCashAccounts.AccountID
WHERE  FMIS_tblCashAccounts.StoreID=" + conclass.StoreID+" and    (FMIS_tblCashAccountsInOutDetail.EntryReference = N'" + EntryReference + "') ORDER BY FMIS_tblCashAccountsInOutDetail.ID DESC");
            }
            else
            {
                grdWithDraw.DataSource = obj.GetData(@"SELECT   FMIS_tblCashAccountsInOutDetail.ID, FMIS_tblCashAccountsInOutDetail.AccountID, FMIS_tblCashAccounts.AccountName, FMIS_tblCashAccountsInOutDetail.Amount, 
                         FMIS_tblCashAccountsInOutDetail.Remarks, convert(varchar(12),FMIS_tblCashAccountsInOutDetail.SystemDate,107) as SystemDate,'Print Recipt' as Report,'Delete' as DeleteRecord
FROM         FMIS_tblCashAccountsInOutDetail INNER JOIN
                         FMIS_tblCashAccounts ON FMIS_tblCashAccountsInOutDetail.AccountID = FMIS_tblCashAccounts.AccountID
WHERE  FMIS_tblCashAccounts.StoreID=" + conclass.StoreID+" and  (FMIS_tblCashAccountsInOutDetail.EntryReference = N'" + EntryReference + "') ORDER BY FMIS_tblCashAccountsInOutDetail.ID DESC");
            }
        }

        private void FillDepositAndWitdrawByDate(string fromDate, string ToDate)
        {
            grdDeposit.DataSource = obj.GetData(@"SELECT   FMIS_tblCashAccountsInOutDetail.ID, FMIS_tblCashAccountsInOutDetail.AccountID, FMIS_tblCashAccounts.AccountName, FMIS_tblCashAccountsInOutDetail.Amount, 
                         FMIS_tblCashAccountsInOutDetail.Remarks, convert(varchar(12),FMIS_tblCashAccountsInOutDetail.SystemDate,107) as SystemDate,'Print Recipt' as Report,'Delete' as DeleteRecord
FROM         FMIS_tblCashAccountsInOutDetail INNER JOIN
                         FMIS_tblCashAccounts ON FMIS_tblCashAccountsInOutDetail.AccountID = FMIS_tblCashAccounts.AccountID
WHERE  FMIS_tblCashAccounts.StoreID=" + conclass.StoreID + " and    (FMIS_tblCashAccountsInOutDetail.EntryReference = 'Cash Deposit') and (CAST(CONVERT(varchar(12), FMIS_tblCashAccountsInOutDetail.SystemDate, 106) AS datetime) >= CAST(CONVERT(varchar(12), '" + fromDate + "', 106) AS Datetime)) AND (CAST(CONVERT(varchar(12), FMIS_tblCashAccountsInOutDetail.SystemDate,106) AS datetime) <= CAST(CONVERT(varchar(12), '" + ToDate + "', 106) AS Datetime)) ORDER BY FMIS_tblCashAccountsInOutDetail.ID DESC");

            grdWithDraw.DataSource = obj.GetData(@"SELECT   FMIS_tblCashAccountsInOutDetail.ID, FMIS_tblCashAccountsInOutDetail.AccountID, FMIS_tblCashAccounts.AccountName, FMIS_tblCashAccountsInOutDetail.Amount, 
                         FMIS_tblCashAccountsInOutDetail.Remarks, convert(varchar(12),FMIS_tblCashAccountsInOutDetail.SystemDate,107) as SystemDate,'Print Recipt' as Report,'Delete' as DeleteRecord
FROM         FMIS_tblCashAccountsInOutDetail INNER JOIN
                         FMIS_tblCashAccounts ON FMIS_tblCashAccountsInOutDetail.AccountID = FMIS_tblCashAccounts.AccountID
WHERE  FMIS_tblCashAccounts.StoreID=" + conclass.StoreID + " and  (FMIS_tblCashAccountsInOutDetail.EntryReference = 'Cash Withdraw') and (CAST(CONVERT(varchar(12), FMIS_tblCashAccountsInOutDetail.SystemDate, 106) AS datetime) >= CAST(CONVERT(varchar(12), '" + fromDate + "', 106) AS Datetime)) AND (CAST(CONVERT(varchar(12), FMIS_tblCashAccountsInOutDetail.SystemDate,106) AS datetime) <= CAST(CONVERT(varchar(12), '" + ToDate + "', 106) AS Datetime)) ORDER BY FMIS_tblCashAccountsInOutDetail.ID DESC");
        }
        private void btnDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                obj.ExecuteQuery(@"insert into FMIS_tblCashAccountsInOutDetail(AccountID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID,StoreID) 
                    values(" + cmbDepositAccount.SelectedValue + ", " + txtDepositAmount.Text + ", 'IN', 'Cash Deposit', '" + cmbDepositAccount.SelectedValue + "', N'" + txtDepositRemarks.Text + "', N'" + conclass.User_ID + "'," + conclass.StoreID + ")");
                MessageBox.Show("Cash Deposit Successfully..");
                FillDepositGrid("Cash Deposit");
                txtDepositRemarks.Text = "";
                txtDepositAmount.Text = "";
                FillGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            try
            {
                obj.ExecuteQuery(@"insert into FMIS_tblCashAccountsInOutDetail(AccountID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID,StoreID) 
                    values(" + cmbWithdrawAccount.SelectedValue + ", " + txtWithdrawAmount.Text + ", 'OUT', 'Cash Withdraw', '" + cmbWithdrawAccount.SelectedValue + "', N'" + txtWithDrawRemarks.Text + "', N'" + conclass.User_ID + "'," + conclass.StoreID + ")");
                MessageBox.Show("Cash Withdraw Successfully..");
                FillDepositGrid("Cash Withdraw");
                txtWithdrawAmount.Text = "";
                txtWithDrawRemarks.Text = "";
                FillGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }

        private void grdWithDraw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdWithDraw.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Print Recipt")
            {
                PrintTransactionReceipt(grdDeposit.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            else if (grdWithDraw.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Delete")
            {
                DeleteRecord(grdWithDraw.Rows[e.RowIndex].Cells[0].Value.ToString());
                FillDepositGrid("Cash Withdraw");
                FillGrid();
            }
        }

        private void DeleteRecord(string ID)
        {
            obj.con.Open();
            SqlTransaction tran = obj.con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Transaction = tran;
            cmd.Connection = obj.con;
            try
            {
                cmd.CommandText = @"insert into FMIS_tblCashAccountsInOutDetailHistory(ID, AccountID, StoreID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID, SystemDate, LastUpdatedBy, LastUpdatedDate, DeletedBy)    
                    SELECT        ID, AccountID, StoreID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID, SystemDate, LastUpdatedBy, LastUpdatedDate, '" + conclass.User_ID + "' as DeletedBy FROM  FMIS_tblCashAccountsInOutDetail where id=" + ID + "";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"delete from FMIS_tblCashAccountsInOutDetail where ID=" + ID + "";
                cmd.ExecuteNonQuery();
                tran.Commit();
                MessageBox.Show("Record Deleted Successfully..");
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
        private void grdDeposit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdDeposit.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Print Recipt")
            {
                PrintTransactionReceipt(grdDeposit.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            else if (grdDeposit.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    DeleteRecord(grdDeposit.Rows[e.RowIndex].Cells[0].Value.ToString());
                    FillDepositGrid("Cash Deposit");
                    FillGrid();
                }
            }
        }

        private void PrintTransactionReceipt(string TranID)
        {
            DataTable dt = new DataTable();
            dt = conclass.GetRecord(@"SELECT  ID, EntryReference, InOutStatus, AccountID, AccountName, Amount, Remarks, SystemDate, UserName
FROM            VW_CashInCashOutReport where ID=" + TranID + "");
            Reports.rptTransactionReceipt obj = new Stock_System.Reports.rptTransactionReceipt();
            obj.SetDataSource(dt);

            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;
            frm2.ShowDialog();
        }
    }
}
