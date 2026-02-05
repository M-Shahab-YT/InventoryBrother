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
using System.Drawing.Printing;

namespace Stock_System.Forms
{
    public partial class frmSaleReturn : Form
    {
        Dbcommon obj = new Dbcommon();
        public frmSaleReturn()
        {
            InitializeComponent();
        }
        private void FillInvoice(string InvoiceNo)
        {
           

            DataTable dtMain = obj.GetData(@"SELECT        IMIS_tblSaleOrderMain.InvoiceNo, convert(varchar(12),IMIS_tblSaleOrderMain.SaleOrderDate,107) as SaleOrderDate, IMIS_tblSaleOrderMain.CustomerID,IMIS_tblSaleOrderMain.SaleOrderTime, IMIS_tblCustomer.CustomerName, IMIS_tblSaleOrderMain.PaymentMethod, 
                         IMIS_tblSaleOrderMain.TotalOrderAmount, IMIS_tblSaleOrderMain.TotalPaidAmount, IMIS_tblSaleOrderMain.BalanceAmount, IMIS_tblSaleOrderMain.TotalBaseCurrencyAmount, 
                         IMIS_tblSaleOrderMain.TotalBaseCurrencyPaidAmount, IMIS_tblSaleOrderMain.TotalBaseCurrencyBalanceAmount, IMIS_tblSaleOrderMain.CurrencyID, Lookup_tblCurrency.CurrencyName, 
                         IMIS_tblSaleOrderMain.ExchangeRate, isnull(IMIS_tblSaleOrderMain.CashReturnToCustomer,0) as CashReturnToCustomer
FROM            IMIS_tblSaleOrderMain INNER JOIN
                         IMIS_tblCustomer ON IMIS_tblSaleOrderMain.CustomerID = IMIS_tblCustomer.CustomerID INNER JOIN
                         Lookup_tblCurrency ON IMIS_tblSaleOrderMain.CurrencyID = Lookup_tblCurrency.CurrencyID where IMIS_tblSaleOrderMain.InvoiceNo='" + InvoiceNo + "' and IMIS_tblSaleOrderMain.StoreID=" + conclass.StoreID + "");
            if (dtMain.Rows.Count > 0)
            {
                txtInvoiceNumber.Tag = dtMain.Rows[0]["InvoiceNo"].ToString();
                txtSaleDate.Text = dtMain.Rows[0]["SaleOrderDate"].ToString();
                txtCustomer.Text = dtMain.Rows[0]["CustomerName"].ToString();
                txtCustomer.Tag = dtMain.Rows[0]["CustomerID"].ToString();
                txtPaymentMethod.Text = dtMain.Rows[0]["PaymentMethod"].ToString();
                txtCurrency.Text = dtMain.Rows[0]["CurrencyName"].ToString();
                txtEchangeRate.Text = dtMain.Rows[0]["ExchangeRate"].ToString();
                txtOldGrandTotal.Text = dtMain.Rows[0]["TotalOrderAmount"].ToString();
                txtTotalPaidAmount.Text = (Decimal.Parse(dtMain.Rows[0]["TotalPaidAmount"].ToString()) - Decimal.Parse(dtMain.Rows[0]["CashReturnToCustomer"].ToString())).ToString();
                txtTotalBalance.Text = dtMain.Rows[0]["BalanceAmount"].ToString();
                txtCurrency.Tag = dtMain.Rows[0]["CurrencyID"].ToString();

                DataTable dtAccount = obj.GetData(@"SELECT        FMIS_tblCashAccounts.AccountName, FMIS_tblCashAccountsInOutDetail.AccountID
FROM            FMIS_tblCashAccountsInOutDetail INNER JOIN
                         FMIS_tblCashAccounts ON FMIS_tblCashAccountsInOutDetail.AccountID = FMIS_tblCashAccounts.AccountID
WHERE        FMIS_tblCashAccountsInOutDetail.StoreID = "+conclass.StoreID+" and EntryReference='Sales' and EntryReferenceNumber='"+txtInvoiceNumber.Tag.ToString()+"'");
                if (dtAccount.Rows.Count > 0)
                {
                    txtAccount.Text = dtAccount.Rows[0]["AccountName"].ToString();
                    txtAccount.Tag = dtAccount.Rows[0]["AccountID"].ToString();
                }
                DataTable dtDetail = obj.GetData(@"SELECT   IMIS_tblSaleOrderDetail.SNO, IMIS_tblSaleOrderDetail.ProductCode, IMIS_VWProducts.ProductName, IMIS_tblSaleOrderDetail.Quantity AS SoldQty, IMIS_tblSaleOrderDetail.Quantity, 
                         IMIS_tblSaleOrderDetail.SalePrice, IMIS_tblSaleOrderDetail.Discount, IMIS_tblSaleOrderDetail.Total, IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, 
                         IMIS_tblSaleOrderDetail.BaseCurrencyTotal, IMIS_tblSaleOrderDetail.BaseCurrencySalePrice,  IMIS_tblSaleOrderDetail.BatchNo, CONVERT(varchar(12), 
                         IMIS_tblSaleOrderDetail.ExpiryDate, 106) AS ExpiryDate, IMIS_tblSaleOrderDetail.ProductStockID,
						 IMIS_tblSaleMan.SaleManName, ISNULL(IMIS_tblSaleOrderDetail.BaseCurrencyDiscount, 
                         0) AS BaseCurrencyDiscount, IMIS_tblSaleOrderDetail.SalesManID, IMIS_tblSaleOrderDetail.SalesPercentage, IMIS_tblSaleMan.StoreID,IMIS_tblSaleOrderDetail.SalesPercentage
                FROM  IMIS_tblSaleOrderDetail INNER JOIN
                IMIS_VWProducts ON IMIS_tblSaleOrderDetail.ProductCode = IMIS_VWProducts.ProductCode INNER JOIN
                IMIS_tblSaleMan ON IMIS_tblSaleOrderDetail.SalesManID = IMIS_tblSaleMan.SaleManID
 where IMIS_tblSaleOrderDetail.InvoiceNo='" + InvoiceNo + "' and IMIS_tblSaleOrderDetail.Status in('Sold','Quantity Returned')");
                if (dtDetail.Rows.Count > 0)
                {

                    foreach (DataRow dr in dtDetail.Rows)
                    {
                        string[] row = new string[] { dr["SNO"].ToString(), dr["ProductCode"].ToString(), dr["ProductName"].ToString(), dr["BatchNo"].ToString(), dr["ExpiryDate"].ToString(), dr["SoldQty"].ToString(), "0", dr["SalePrice"].ToString(), dr["Discount"].ToString(), dr["Total"].ToString(), "0", dr["BaseCurrencyProfitPerUnit"].ToString(), dr["BaseCurrencySalePrice"].ToString(), dr["SaleManName"].ToString(), dr["SalesManID"].ToString(), dr["BaseCurrencyDiscount"].ToString(), dr["ProductStockID"].ToString() };
                        dataGridView1.Rows.Add(row);
                        dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
                        dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
                        dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                        dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
                        dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Orange;
                        dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
                        dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dataGridView1.AllowUserToResizeColumns = false;
                    }
                }
                    obj.fillcmb(cmbPaymentAccount, "AccountName", "AccountID", "SELECT  AccountID, AccountName FROM FMIS_tblCashAccounts where  CurrencyID=" + txtCurrency.Tag.ToString() + " and StoreID=" + conclass.StoreID + "");
            }

          
        
        }
        private void btnsave_Click(object sender, EventArgs e)
        {

            if (conclass.IsInRole(conclass.UserName, "Finance Officer"))
            {
                DataTable dtOpeningBalance = obj.GetData(@"select ClosingStatus from  FMIS_tblCashierBalance
where ID=(select max(ID) from FMIS_tblCashierBalance where UserID='" + conclass.User_ID + "' and CurrencyID='" + txtCurrency.Tag.ToString() + "')");
                if (dtOpeningBalance.Rows.Count > 0 && dtOpeningBalance.Rows[0]["ClosingStatus"].ToString() == "Closed")
                {
                    MessageBox.Show("Cashir Opening Balance is not open yet");
                    return;
                }
            }
            InsertSaleOrder();
        }
        public void InsertSaleOrder()
        {
            //string InvoiceNo = GetOrderNo();
            obj.con.Open();
            SqlTransaction tran = obj.con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Transaction = tran;
            cmd.Connection = obj.con;
            Decimal ReturnTotal = 0;
            bool status=false;
            try
            {
                Int64 MaxID = conclass.nextid("FMIS_tblCustomerStatement", "ID");
                foreach (DataGridViewRow gr in dataGridView1.Rows)
                {
                    if (gr.Cells[17].Value != null)
                    {
                        DataGridViewCheckBoxCell chk = gr.Cells[17] as DataGridViewCheckBoxCell;
                        if (Convert.ToBoolean(chk.Value) == true)
                        {
                            string ItemCode = "";
                            int SNO = 0;
                            Decimal SoldQty = 0;
                            Decimal ReturnQty = 0;
                            Decimal SalePrice = 0;
                            Decimal SoldTotal = 0;
                            Decimal BaseCurrencySalePrice = 0;
                            Decimal TotalBasCurrencyTotal = 0;
                            Decimal BaseCurrencyProfitPerUnit = 0;
                            Decimal TotalBaseCurrencyProfit = 0;
                            Decimal BaseCurrencyDiscount = 0;
                            Decimal Discount = 0;
                            int SalesManID = 0;
                            string ProductStockID = "";
                            bool FullReturn = false;
                            try
                            {
                                SNO = int.Parse(gr.Cells[0].Value.ToString());
                                ItemCode = gr.Cells[1].Value.ToString();
                                SoldQty = Decimal.Parse(gr.Cells[5].Value.ToString());
                                ReturnQty = Decimal.Parse(gr.Cells[6].Value.ToString());
                                ReturnTotal = Decimal.Parse(gr.Cells[10].Value.ToString());
                                Discount = Decimal.Parse(gr.Cells[8].Value.ToString());
                                SoldTotal = Decimal.Parse(gr.Cells[9].Value.ToString());
                                BaseCurrencyProfitPerUnit = Decimal.Parse(gr.Cells[11].Value.ToString());
                                SalePrice = Decimal.Parse(gr.Cells[7].Value.ToString());
                                BaseCurrencySalePrice = Decimal.Parse(gr.Cells[12].Value.ToString());
                                SalesManID = int.Parse(gr.Cells[14].Value.ToString());
                                BaseCurrencyDiscount = Decimal.Parse(gr.Cells[15].Value.ToString());
                                ProductStockID = gr.Cells[16].Value.ToString();
                                if (SoldQty > ReturnQty)
                                {
                                    FullReturn = false;
                                    TotalBaseCurrencyProfit = (SoldQty - ReturnQty) * BaseCurrencyProfitPerUnit;
                                    ReturnTotal = (SoldQty - ReturnQty) * (SalePrice - Discount);
                                    TotalBasCurrencyTotal = (SoldQty - ReturnQty) * BaseCurrencySalePrice;
                                }
                                else
                                    FullReturn = true;
                            }
                            catch (Exception exxx)
                            {
                                MessageBox.Show(exxx.Message.ToString());
                                return;
                            }
                            if (obj.con.State == ConnectionState.Closed)
                                obj.con.Open();

                            cmd.CommandText = @"insert into IMIS_tblSalesReturnTransaction(InvoiceNo, RowNumber, ProductCode,ProductStockID, ReturnQuantity, ReturnAmount, SalesmainID, StoreID, ReturnUserID) 
                            values('" + txtInvoiceNumber.Tag.ToString() + "', " + SNO + ", '" + ItemCode + "', " + ProductStockID + " , " + ReturnQty + ", " + ((BaseCurrencySalePrice - BaseCurrencyDiscount) * ReturnQty) + ", " + SalesManID + "," + conclass.StoreID + ", N'" + conclass.User_ID + "')";
                            cmd.ExecuteNonQuery();

                            if (FullReturn == true)
                                cmd.CommandText = @"update IMIS_tblSaleOrderDetail set Status='Full Returned',Remarks='" + ReturnQty + " Items are Returned',LastUpdateBy=N'" + conclass.User_ID + "',LastUpdateDate=getdate(),QuantityReturned=" + ReturnQty + "  where SNO=" + SNO + "";
                            else
                                cmd.CommandText = @"update IMIS_tblSaleOrderDetail set Status='Quantity Returned',Quantity=Quantity-" + ReturnQty + ",QuantityReturned=" + ReturnQty + ",BaseCurrencyTotal=" + TotalBasCurrencyTotal + ",Total=" + ReturnTotal + ",TotalBaseCurrencyProfit=" + TotalBaseCurrencyProfit + ",Remarks='" + ReturnQty + " Items are Returned',LastUpdateBy=N'" + conclass.User_ID + "',LastUpdateDate=getdate()  where SNO=" + SNO + "";
                            cmd.ExecuteNonQuery();
                            #region Stock Update
                            cmd.CommandText = @"update IMIS_tblStock set Quantity=Quantity+" + ReturnQty + " where  ID=" + ProductStockID + " ";
                            cmd.ExecuteNonQuery();
                            #endregion
                        }
                    }
                }
                Decimal Total_Base_Currency_Amount = ToBaseCurrencyPrice(Decimal.Parse(txtNewTotal.Text), int.Parse(txtCurrency.Tag.ToString()), Decimal.Parse(txtEchangeRate.Text));
                Decimal Total_Base_Currency_Paid_Amount = ToBaseCurrencyPrice(Decimal.Parse(txtTotalPaidAmount.Text), int.Parse(txtCurrency.Tag.ToString()), Decimal.Parse(txtEchangeRate.Text)); ;
                Decimal Total_Base_Currency_Balance_Amount = Decimal.Parse(txtNewBalance.Text);
                Decimal CashReturnToCustomer = Math.Abs(Decimal.Parse(txtCashReturnToCustomer.Text));
                Decimal BaseCurrencyCashReturnToCustomer = ToBaseCurrencyPrice(CashReturnToCustomer, int.Parse(txtCurrency.Tag.ToString()), Decimal.Parse(txtEchangeRate.Text)); ;
               
                if (txtPaymentMethod.Text == "Loan" || txtPaymentMethod.Text == "Cash and Loan")
                {
                    ReturnTotal = 0;
                    #region Customer Statment
                    if (txtPaymentMethod.Text == "Loan")
                        ReturnTotal = Decimal.Parse(txtReturnTotal.Text);
                    else if (txtPaymentMethod.Text == "Cash and Loan")
                        ReturnTotal = Decimal.Parse(txtReturnTotal.Text) - CashReturnToCustomer;
                    DataTable dtCustomerBalance = new DataTable();
                    DataTable dtCheckOpeningBalance = new DataTable();
                    DataTable dtLastBalance = new DataTable();
                    DataTable dtSumOfCredit = new DataTable();
                    DataTable dtSumOfDebit = new DataTable();
                    Decimal LastCustomerBalance = 0;
                    Decimal TotalCredit = 0;
                    Decimal TotalDebit = 0;
                    Decimal NewCustomerBalance = 0;
                    #region Find Last New Balance
                    //This Query will give the last Balance
                  

                    //This Query will give the Sum Of Credit
                    cmd.CommandText = "select isnull(Sum(Credit),0) As SumOfCredit from FMIS_tblCustomerStatement where CustomerID=" + txtCustomer.Tag.ToString() + " and StoreID=" + conclass.StoreID + " and CurrencyID=" + txtCurrency.Tag.ToString() + "";
                    SqlDataAdapter daSumOfCredit = new SqlDataAdapter(cmd);
                    daSumOfCredit.Fill(dtSumOfCredit);

                    //This Query will give the Sum Of Debit
                    cmd.CommandText = "select isnull(Sum(Debit),0) As SumOfDebit from FMIS_tblCustomerStatement where CustomerID=" + txtCustomer.Tag.ToString() + " and StoreID=" + conclass.StoreID + " and CurrencyID=" + txtCurrency.Tag.ToString() + "";
                    SqlDataAdapter daSumOfDebit = new SqlDataAdapter(cmd);
                    daSumOfDebit.Fill(dtSumOfDebit);
                    if (dtSumOfCredit.Rows.Count > 0 && dtSumOfDebit.Rows.Count > 0)
                    {
                        TotalCredit = Decimal.Parse(dtSumOfCredit.Rows[0]["SumOfCredit"].ToString()) + ReturnTotal;
                        TotalDebit = Decimal.Parse(dtSumOfDebit.Rows[0]["SumOfDebit"].ToString());
                        //Formula
                        NewCustomerBalance =  TotalDebit - TotalCredit;
                    }
                    #endregion
                    if (ReturnTotal > 0)
                    {
                        cmd.CommandText = @"insert into FMIS_tblCustomerStatement(ID, CustomerID, StoreID, ReferenceType,ReferenceNumber, Particulars, CurrencyID,ExchangeRate, Debit, Credit, Balance, UserID) 
                         values(" + MaxID + "," + txtCustomer.Tag.ToString() + "," + conclass.StoreID + ", 'Sale Return', '" + txtInvoiceNumber.Tag.ToString() + "','Sale Return'," + txtCurrency.Tag.ToString() + "," + txtEchangeRate.Text + ",0," + ReturnTotal + "," + NewCustomerBalance + ", '" + conclass.User_ID + "')";
                        cmd.ExecuteNonQuery();
                    }
                    #endregion
                }
                if (txtCashReturnToCustomer.Text != "" && txtPaymentMethod.Text != "Loan")
                {
                    if (CashReturnToCustomer > 0)
                    {
                        cmd.CommandText = @"insert into FMIS_tblCashAccountsInOutDetail(AccountID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID,StoreID) values(" + cmbPaymentAccount.SelectedValue + ", " + CashReturnToCustomer + ", 'Out', 'Sale Return', '" + txtInvoiceNumber.Tag.ToString() + "', N'Sale Return', N'" + conclass.User_ID + "'," + conclass.StoreID + ")";
                        cmd.ExecuteNonQuery();

                        if (conclass.IsInRole(conclass.UserName, "Finance Officer"))
                        {
                            cmd.CommandText = @"update FMIS_tblCashierBalance set TotalCashOut=isnull(TotalCashOut,0)+" + CashReturnToCustomer + " where UserID='" + conclass.User_ID + "' and ClosingStatus!='Closed' and CurrencyID=" + txtCurrency.Tag.ToString() + "";
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                cmd.CommandText = @"update IMIS_tblSaleOrderMain set TotalOrderAmount=" + txtNewTotal.Text + ",BalanceAmount=" + txtNewBalance.Text + ",TotalBaseCurrencyAmount=" + Total_Base_Currency_Amount + ",TotalBaseCurrencyBalanceAmount=" + Total_Base_Currency_Balance_Amount + ",LastUpdateBy='" + conclass.User_ID + "', LastUpdateDate=getdate(),Remarks='Some of Items Are Returned',CashReturnToCustomer=isnull(CashReturnToCustomer,0)+" + CashReturnToCustomer + ",BaseCurrencyCashReturnToCustomer=isnull(BaseCurrencyCashReturnToCustomer,0)+" + BaseCurrencyCashReturnToCustomer + " where InvoiceNo='" + txtInvoiceNumber.Tag.ToString() + "'";
                cmd.ExecuteNonQuery();
                tran.Commit();
                btnsave.Enabled = false;

                if (MessageBox.Show("return succeeded\r\t do you want to print the receipt", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    printInvoice(txtInvoiceNumber.Tag.ToString(), false);
                }


                MessageBox.Show("Return Succseed!");
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

        private void printInvoice(string InvoiceNumber, bool PageSize)
        {

            DataTable dtPrinter = conclass.GetRecord(@"SELECT   LaserPrinterName, TerminalPrinterName, ShowPrintPreview FROM IMIS_tblPrinterSetting where UserID='" + conclass.User_ID + "'");
            if (dtPrinter.Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = conclass.GetRecord(@"SELECT   ProductCode, ProductName, ReturnQuantity, ReturnAmount, ID, InvoiceNo, RowNumber, StoreID, ReturnDate, ReturnUserID, CalculatedToSalesMan, LastUpdatedBy, LastUpdatedDate, 
                         ProductStockID, ExpiryDate, StoreName, StoreNameLocal, Address, AddressLocal, ContactNumber1, ContactNumber2, BusinessLogo, CustomerName FROM         VWSalesReturnBill where InvoiceNo='"+InvoiceNumber+"' and  (CAST(CONVERT(varchar(12), ReturnDate, 106) AS datetime) >= CAST(CONVERT(varchar(12), GETDATE(), 106) AS Datetime)) AND (CAST(CONVERT(varchar(12), ReturnDate,106) AS datetime) <= CAST(CONVERT(varchar(12), GETDATE(), 106) AS Datetime))");
                if (PageSize == false)
                {
                    //Reports.rptSalesReturnReceipt obj = new Stock_System.Reports.rptSalesReturnReceipt();
                    //obj.SetDataSource(dt);
                    //Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
                    //obj.PrintOptions.PrinterName = dtPrinter.Rows[0]["TerminalPrinterName"].ToString();
                    //obj.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                    ////crViewer.ReportSource = vrptSalesInvoice;
                    //frm2.crystalReportViewer1.ReportSource = obj;
                    //frm2.ShowDialog();
                    //obj.PrintToPrinter(1, false, 0, 0);



                    PrinterSettings settings = new PrinterSettings();
                    //MessageBox.Show(settings.PrinterName);
                    Reports.rptSalesReturnReceipt obj = new Stock_System.Reports.rptSalesReturnReceipt();
                    obj.SetDataSource(dt);
                    Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
                    //obj.PrintOptions.PrinterName = dtPrinter.Rows[0]["TerminalPrinterName"].ToString();
                    obj.PrintOptions.PrinterName = settings.PrinterName.ToString();
                    obj.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                    //crViewer.ReportSource = vrptSalesInvoice;
                    frm2.crystalReportViewer1.ReportSource = obj;
                    obj.PrintToPrinter(1, false, 0, 0);








                }
                //else if (PageSize == true)
                //{
                //    Reports.rptSaleInvoice obj = new Stock_System.Reports.rptSaleInvoice();
                //    obj.SetDataSource(dt);
                //    Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
                //    obj.PrintOptions.PrinterName = dtPrinter.Rows[0]["LaserPrinterName"].ToString();
                //    //obj.PrintOptions.PrinterName = "PB-A11P Miniprinter";
                //    //obj.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                //    //crViewer.ReportSource = vrptSalesInvoice;
                //    frm2.crystalReportViewer1.ReportSource = obj;
                //    if (dtPrinter.Rows[0]["ShowPrintPreview"].ToString() == "True")
                //        frm2.ShowDialog();
                //    obj.PrintToPrinter(1, false, 0, 0);
                //}
            }
        }


        private void GetGrandTotal()
        {
            txtCashReturnToCustomer.Text = "";
            Decimal GrandTotal = 0;
            Decimal ReturnGrandTotal = 0;
            Decimal NewGrandTotal = 0;
            foreach (DataGridViewRow gr in dataGridView1.Rows)
            {
                if (gr.Cells[17].Value != null)
                {
                    if (Convert.ToBoolean(gr.Cells[17].Value))
                    {
                        ReturnGrandTotal = ReturnGrandTotal + Decimal.Parse(gr.Cells[10].Value.ToString());
                    }
                }
            }
            GrandTotal = Decimal.Parse(dataGridView1.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[9].Value.ToString())).ToString());

            NewGrandTotal = GrandTotal - ReturnGrandTotal;
            txtNewTotal.Text = NewGrandTotal.ToString();
            txtReturnTotal.Text = ReturnGrandTotal.ToString();
            Decimal PaidAmount = Decimal.Parse(txtTotalPaidAmount.Text);
            Decimal NewBalance = 0;
            NewBalance =  NewGrandTotal-PaidAmount;


          
            if (NewBalance < 0)
            {
                txtCashReturnToCustomer.Text = (NewBalance).ToString();
                txtNewBalance.Text = "0";
            }
            else
            {
                txtCashReturnToCustomer.Text = "0";
                txtNewBalance.Text = NewBalance.ToString();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Decimal Total = 0;
            Decimal SoldQty = 0;
            Decimal SoldDiscount = 0;
            Decimal SalePrice = 0;
            txtNewTotal.Text = "0";
            txtCashReturnToCustomer.Text = "0";
            txtTotalBalance.Text = "0";
            if (e.ColumnIndex == 17 && e.RowIndex >= 0)
            {
                this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                if ((bool)this.dataGridView1.CurrentCell.Value == true)
                {
                    SoldQty = Decimal.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                    SoldDiscount = Decimal.Parse(dataGridView1.CurrentRow.Cells[8].Value.ToString());
                    SalePrice = Decimal.Parse(dataGridView1.CurrentRow.Cells[7].Value.ToString());
                    //Setting Sold Qty
                    dataGridView1.CurrentRow.Cells[6].Value = SoldQty;
                    Total = Decimal.Parse(dataGridView1.CurrentRow.Cells[9].Value.ToString());

                   // This code is used to subtrect the discount and multiply by the qty
                    dataGridView1.CurrentRow.Cells[10].Value = (SalePrice -SoldDiscount) * SoldQty;
           
                }
                else
                {
                    dataGridView1.CurrentRow.Cells[6].Value = 0;
                    dataGridView1.CurrentRow.Cells[10].Value = 0;
                }
                GetGrandTotal();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtReturnQty.Text == "")
                {
                    MessageBox.Show("Return Quantity are required");
                    txtReturnQty.Text = "";
                    txtReturnQty.Focus();
                    return;
                }
                if (Decimal.Parse(txtReturnQty.Text) > Decimal.Parse(txtSoldQty.Text))
                {
                    MessageBox.Show("Return Quantity is greater than sold quantity");
                    txtReturnQty.Text = "";
                    txtReturnQty.Focus();
                    return;
                }
                int index = int.Parse(txtSNO.Text);
                Decimal SoldQty = Decimal.Parse(txtSoldQty.Text);
                dataGridView1.Rows[index].Cells[6].Value = txtReturnQty.Text;
                dataGridView1.Rows[index].Cells[10].Value = (Decimal.Parse(txtSalePrice.Text) - Decimal.Parse(txtDiscount.Text)) * Decimal.Parse(txtReturnQty.Text);
                dataGridView1.Rows[index].Cells[17].Value = CheckState.Checked;
                GetGrandTotal();
                pnlReturn.Visible = false;
                pnlReturn.SendToBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                txtReturnQty.Text = "";
                txtReturnQty.Focus();
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSNO.Text = dataGridView1.CurrentRow.Index.ToString();
            txtSoldQty.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtSalePrice.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtDiscount.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            pnlReturn.Visible = true;
            pnlReturn.BringToFront();
            txtReturnQty.Focus();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            GetGrandTotal();
            pnlReturn.Visible = false;
            pnlReturn.SendToBack();
        }
        private void frmSaleReturn_Load(object sender, EventArgs e)
        {
            DataTable dtOpeningBalance = obj.GetData(@"select ClosingStatus from  FMIS_tblCashierBalance where ID=(select max(ID) from FMIS_tblCashierBalance where UserID='" + conclass.User_ID + "')");
            foreach (DataRow dr in dtOpeningBalance.Rows)
            {
                if (dr["ClosingStatus"].ToString() == "Closed")
                {
                    MessageBox.Show("Cashir Opening Balance is not open yet");
                    panel7.Enabled = false;
                    break;
                }
            }

            lodLastInvoiceNo();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            gpitem_list.SendToBack();
            gpitem_list.Visible = false;
        }
        private void txt_item_search_TextChanged(object sender, EventArgs e)
        {
   
        }
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            ClearAll();
            lodLastInvoiceNo();
        }
        private void lodLastInvoiceNo()
        {
            DataTable dt = obj.GetData("select InvoiceNo from IMIS_tblSaleOrderMain  where SNO=(select max(SNO) from IMIS_tblSaleOrderMain where StoreID=" + conclass.StoreID + " and UserID='" + conclass.User_ID + "')");
            if (dt.Rows.Count > 0)
                txtInvoiceNumber.Text = dt.Rows[0]["InvoiceNo"].ToString();
        }
        private void ClearAll()
        {
            dataGridView1.Rows.Clear();
            txt_item_search.Text = "";
            txtAccount.Text = "";
            txtCashReturnToCustomer.Text = "";
            txtCurrency.Text = "";
            txtCustomer.Text = "";
            txtDiscount.Text = "";
            txtEchangeRate.Text = "";
            txtInvoiceNumber.Text = "";
            txtNewBalance.Text = "";
            txtNewTotal.Text = "";
            txtOldGrandTotal.Text = "";
            txtPaymentMethod.Text = "";
            txtReturnQty.Text = "";
            txtReturnTotal.Text = "";
            txtSaleDate.Text = "";
            txtSalePrice.Text = "";
            txtSNO.Text = "";
            txtSoldQty.Text = "";
            txtTotalBalance.Text = "";
            txtTotalPaidAmount.Text = "";
           
        }
        private void ClearAllForSearch()
        {
            dataGridView1.Rows.Clear();
            txt_item_search.Text = "";
            txtAccount.Text = "";
            txtCashReturnToCustomer.Text = "";
            txtCurrency.Text = "";
            txtCustomer.Text = "";
            txtDiscount.Text = "";
            txtEchangeRate.Text = "";   
            txtNewBalance.Text = "";
            txtNewTotal.Text = "";
            txtOldGrandTotal.Text = "";
            txtPaymentMethod.Text = "";
            txtReturnQty.Text = "";
            txtReturnTotal.Text = "";
            txtSaleDate.Text = "";
            txtSalePrice.Text = "";
            txtSNO.Text = "";
            txtSoldQty.Text = "";
            txtTotalBalance.Text = "";
            txtTotalPaidAmount.Text = "";
        }
        private Decimal ToBaseCurrencyPrice(Decimal Price, int Currency_ID, Decimal ExchangeRate)
        {
            Decimal BasePrice = 0;
            String Operator = "";
            string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            DataTable dt_cr = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT  CurrencyID, CurrencyName, CurrencySymbol, ltrim(rtrim(ToBaseCurrencyOperator)) as Exchange_Operator,ToBaseCurrencyOperator, IsBaseCurrency FROM  Lookup_tblCurrency where CurrencyID=" + Currency_ID + "", con);
            da.Fill(dt_cr);
            if (dt_cr.Rows.Count > 0)
            {
                Operator = dt_cr.Rows[0]["Exchange_Operator"].ToString();
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
        private Decimal Get_Base_Currency_Price(Decimal Price, int Currency_ID, Decimal ExchangeRate)
        {
            Decimal BasePrice = 0;
            String Operator = "";
            string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            DataTable dt_cr = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT  CurrencyID, CurrencyName, ltrim(rtrim(FromBaseCurrencyOperator)) as ExchangeOperator, IsBaseCurrency FROM  Lookup_tblCurrency where CurrencyID=" + Currency_ID + "", con);
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
        private void lst_Item_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string InvoiceNo = lst_Item.SelectedItems[0].SubItems[8].Text.ToString();
                txtInvoiceNumber.Text = InvoiceNo;
                dataGridView1.Rows.Clear();
                ClearAllForSearch();
                FillInvoice(InvoiceNo);
                gpitem_list.Visible = false;
                gpitem_list.SendToBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            ClearAllForSearch();
            string InvoiceNumber = "";
            if (txtInvoiceNumber.Text.Length < 5)
            {
                DataTable dt = obj.GetData("select InvoiceNo from IMIS_tblSaleOrderMain where SNO=" + txtInvoiceNumber.Text + "");
                if (dt.Rows.Count > 0)
                    InvoiceNumber = dt.Rows[0]["InvoiceNo"].ToString();
                else
                    InvoiceNumber = txtInvoiceNumber.Text;
            }
            else
            {
                InvoiceNumber = txtInvoiceNumber.Text;
            }
            FillInvoice(InvoiceNumber);
            btnsave.Enabled = true;
        }
        private void btnAdvanceSearch_Click_1(object sender, EventArgs e)
        {
            gpitem_list.Visible = true;
            gpitem_list.BringToFront();
            cmbSearchType.Text = "Product BarCode";
            txt_item_search.Focus();
        }

        private void cmbSearchType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "Product Name & Sales Date" || cmbSearchType.Text == "Salesman & Sales Date" || cmbSearchType.Text == "Customer & Sales Date")
                gpdate.Enabled = true;
            else
                gpdate.Enabled = false;
            txt_item_search.Text = "";
            txt_item_search.Focus();

        }

        private void btnSerachAd_Click(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "")
            {
                MessageBox.Show("Please Chose Search Type");
                return;
            }
            DataTable dt = new DataTable();
            if (cmbSearchType.Text == "Product Name")
            {
                    #region ByProductName
                    dt = obj.GetData(@"SELECT  top 100  IMIS_VWProducts.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.ProductBarCode, IMIS_VWProducts.BarcodeLabelValue, IMIS_tblSaleOrderDetail.InvoiceNo, 
                         CONVERT(varchar(12), IMIS_tblSaleOrderMain.SaleOrderDate, 107) AS SaleOrderDate, CONVERT(varchar(8), IMIS_tblSaleOrderMain.SaleOrderTime, 113) AS SaleOrderTime, 
                         IMIS_tblCustomer.CustomerName, IMIS_tblSaleOrderDetail.Status, IMIS_tblSaleOrderDetail.Quantity, IMIS_tblSaleOrderDetail.SalePrice, 
                         Lookup_tblCurrency.CurrencyName, IMIS_tblSaleOrderDetail.SNO
FROM         Lookup_tblCurrency INNER JOIN
                         IMIS_VWProducts INNER JOIN
                         IMIS_tblSaleOrderDetail ON IMIS_VWProducts.ProductCode = IMIS_tblSaleOrderDetail.ProductCode INNER JOIN
                         IMIS_tblSaleOrderMain ON IMIS_tblSaleOrderDetail.InvoiceNo = IMIS_tblSaleOrderMain.InvoiceNo INNER JOIN
                         IMIS_tblCustomer ON IMIS_tblSaleOrderMain.CustomerID = IMIS_tblCustomer.CustomerID ON Lookup_tblCurrency.CurrencyID = IMIS_tblSaleOrderDetail.CurrencyID 
WHERE     (IMIS_tblSaleOrderDetail.Status <> 'Full Returned')   and  IMIS_tblSaleOrderMain.StoreID = " + conclass.StoreID + " AND IMIS_VWProducts.ProductName like N'%" + txt_item_search.Text.Trim() + "%' order by IMIS_tblSaleOrderDetail.SNO desc");
                    lst_Item.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductBarCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["SalePrice"].ToString());
                        item.SubItems.Add(dr["CurrencyName"].ToString());
                        item.SubItems.Add(dr["InvoiceNo"].ToString());
                        item.SubItems.Add(dr["SaleOrderDate"].ToString());
                        item.SubItems.Add(dr["SaleOrderTime"].ToString());
                        item.SubItems.Add(dr["CustomerName"].ToString());
                        lst_Item.Items.Add(item);
                    }
                    obj.con.Close();
                    #endregion
            }
            else if (cmbSearchType.Text == "Product BarCode")
            {
                if (txt_item_search.Text.Length > 0)
                {
                    #region ByProductName
                    dt = obj.GetData(@"SELECT  top 100  IMIS_VWProducts.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.ProductBarCode, IMIS_VWProducts.BarcodeLabelValue, IMIS_tblSaleOrderDetail.InvoiceNo, 
                         CONVERT(varchar(12), IMIS_tblSaleOrderMain.SaleOrderDate, 107) AS SaleOrderDate, CONVERT(varchar(8), IMIS_tblSaleOrderMain.SaleOrderTime, 113) AS SaleOrderTime, 
                         IMIS_tblCustomer.CustomerName, IMIS_tblSaleOrderDetail.Status, IMIS_tblSaleOrderDetail.Quantity, IMIS_tblSaleOrderDetail.SalePrice, 
                         Lookup_tblCurrency.CurrencyName, IMIS_tblSaleOrderDetail.SNO
FROM         Lookup_tblCurrency INNER JOIN
                         IMIS_VWProducts INNER JOIN
                         IMIS_tblSaleOrderDetail ON IMIS_VWProducts.ProductCode = IMIS_tblSaleOrderDetail.ProductCode INNER JOIN
                         IMIS_tblSaleOrderMain ON IMIS_tblSaleOrderDetail.InvoiceNo = IMIS_tblSaleOrderMain.InvoiceNo INNER JOIN
                         IMIS_tblCustomer ON IMIS_tblSaleOrderMain.CustomerID = IMIS_tblCustomer.CustomerID ON Lookup_tblCurrency.CurrencyID = IMIS_tblSaleOrderDetail.CurrencyID 
WHERE     (IMIS_tblSaleOrderDetail.Status <> 'Full Returned')   and  IMIS_tblSaleOrderMain.StoreID = " + conclass.StoreID + " AND IMIS_VWProducts.ProductBarCode='" + txt_item_search.Text.Trim() + "' order by IMIS_tblSaleOrderDetail.SNO desc");
                    lst_Item.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductBarCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["SalePrice"].ToString());
                        item.SubItems.Add(dr["CurrencyName"].ToString());
                        item.SubItems.Add(dr["InvoiceNo"].ToString());
                        item.SubItems.Add(dr["SaleOrderDate"].ToString());
                        item.SubItems.Add(dr["SaleOrderTime"].ToString());
                        item.SubItems.Add(dr["CustomerName"].ToString());
                        lst_Item.Items.Add(item);
                    }
                    obj.con.Close();
                    #endregion
                }
                else
                {
                    lst_Item.Items.Clear();
                }
            }
            else if (cmbSearchType.Text == "Product Code")
            {
                if (txt_item_search.Text.Length > 0)
                {
                    #region ByProductName
                    dt = obj.GetData(@"SELECT  top 100  IMIS_VWProducts.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.ProductBarCode, IMIS_VWProducts.BarcodeLabelValue, IMIS_tblSaleOrderDetail.InvoiceNo, 
                         CONVERT(varchar(12), IMIS_tblSaleOrderMain.SaleOrderDate, 107) AS SaleOrderDate, CONVERT(varchar(8), IMIS_tblSaleOrderMain.SaleOrderTime, 113) AS SaleOrderTime, 
                         IMIS_tblCustomer.CustomerName, IMIS_tblSaleOrderDetail.Status, IMIS_tblSaleOrderDetail.Quantity, IMIS_tblSaleOrderDetail.SalePrice, 
                         Lookup_tblCurrency.CurrencyName, IMIS_tblSaleOrderDetail.SNO
FROM         Lookup_tblCurrency INNER JOIN
                         IMIS_VWProducts INNER JOIN
                         IMIS_tblSaleOrderDetail ON IMIS_VWProducts.ProductCode = IMIS_tblSaleOrderDetail.ProductCode INNER JOIN
                         IMIS_tblSaleOrderMain ON IMIS_tblSaleOrderDetail.InvoiceNo = IMIS_tblSaleOrderMain.InvoiceNo INNER JOIN
                         IMIS_tblCustomer ON IMIS_tblSaleOrderMain.CustomerID = IMIS_tblCustomer.CustomerID ON Lookup_tblCurrency.CurrencyID = IMIS_tblSaleOrderDetail.CurrencyID 
WHERE     (IMIS_tblSaleOrderDetail.Status <> 'Full Returned')  and  IMIS_tblSaleOrderMain.StoreID = " + conclass.StoreID + " AND IMIS_VWProducts.ProductCode='" + GetCode(txt_item_search.Text) + "' order by IMIS_tblSaleOrderDetail.SNO desc");
                    lst_Item.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductBarCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["SalePrice"].ToString());
                        item.SubItems.Add(dr["CurrencyName"].ToString());
                        item.SubItems.Add(dr["InvoiceNo"].ToString());
                        item.SubItems.Add(dr["SaleOrderDate"].ToString());
                        item.SubItems.Add(dr["SaleOrderTime"].ToString());
                        item.SubItems.Add(dr["CustomerName"].ToString());
                        lst_Item.Items.Add(item);
                    }
                    obj.con.Close();
                    #endregion
                }
                else
                {
                    lst_Item.Items.Clear();
                }
            }
            else if (cmbSearchType.Text == "Product Name & Sales Date")
            {
                if (txt_item_search.Text.Length > 0)
                {
                    #region ByProductName
                    string from = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
                    string to = this.dtto.Value.Month.ToString() + "/" + this.dtto.Value.Day.ToString() + "/" + this.dtto.Value.Year.ToString();

                    dt = obj.GetData(@"SELECT  top 100  IMIS_VWProducts.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.ProductBarCode, IMIS_VWProducts.BarcodeLabelValue, IMIS_tblSaleOrderDetail.InvoiceNo, 
                         CONVERT(varchar(12), IMIS_tblSaleOrderMain.SaleOrderDate, 107) AS SaleOrderDate, CONVERT(varchar(8), IMIS_tblSaleOrderMain.SaleOrderTime, 113) AS SaleOrderTime, 
                         IMIS_tblCustomer.CustomerName, IMIS_tblSaleOrderDetail.Status, IMIS_tblSaleOrderDetail.Quantity, IMIS_tblSaleOrderDetail.SalePrice, 
                         Lookup_tblCurrency.CurrencyName, IMIS_tblSaleOrderDetail.SNO
FROM         Lookup_tblCurrency INNER JOIN
                         IMIS_VWProducts INNER JOIN
                         IMIS_tblSaleOrderDetail ON IMIS_VWProducts.ProductCode = IMIS_tblSaleOrderDetail.ProductCode INNER JOIN
                         IMIS_tblSaleOrderMain ON IMIS_tblSaleOrderDetail.InvoiceNo = IMIS_tblSaleOrderMain.InvoiceNo INNER JOIN
                         IMIS_tblCustomer ON IMIS_tblSaleOrderMain.CustomerID = IMIS_tblCustomer.CustomerID ON Lookup_tblCurrency.CurrencyID = IMIS_tblSaleOrderDetail.CurrencyID 
WHERE     (IMIS_tblSaleOrderDetail.Status <> 'Full Returned') and  IMIS_tblSaleOrderMain.StoreID = " + conclass.StoreID + " and IMIS_VWProducts.ProductName like N'%" + txt_item_search.Text + "%' and cast(convert(varchar(12),SaleOrderDate,101) as datetime) between cast('" + from + "' as datetime) and cast('" + to + "' as datetime )order by IMIS_tblSaleOrderDetail.SNO desc");
                    lst_Item.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductBarCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["SalePrice"].ToString());
                        item.SubItems.Add(dr["CurrencyName"].ToString());
                        item.SubItems.Add(dr["InvoiceNo"].ToString());
                        item.SubItems.Add(dr["SaleOrderDate"].ToString());
                        item.SubItems.Add(dr["SaleOrderTime"].ToString());
                        item.SubItems.Add(dr["CustomerName"].ToString());
                        lst_Item.Items.Add(item);
                    }
                    obj.con.Close();
                    #endregion
                }
                else
                {
                    lst_Item.Items.Clear();
                }
            }

            else if (cmbSearchType.Text == "Customer & Sales Date")
            {
                if (txt_item_search.Text.Length > 0)
                {
                    #region ByProductName
                    string from = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
                    string to = this.dtto.Value.Month.ToString() + "/" + this.dtto.Value.Day.ToString() + "/" + this.dtto.Value.Year.ToString();

                    dt = obj.GetData(@"SELECT  top 100  IMIS_VWProducts.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.ProductBarCode, IMIS_VWProducts.BarcodeLabelValue, IMIS_tblSaleOrderDetail.InvoiceNo, 
                         CONVERT(varchar(12), IMIS_tblSaleOrderMain.SaleOrderDate, 107) AS SaleOrderDate, CONVERT(varchar(8), IMIS_tblSaleOrderMain.SaleOrderTime, 113) AS SaleOrderTime, 
                         IMIS_tblCustomer.CustomerName, IMIS_tblSaleOrderDetail.Status, IMIS_tblSaleOrderDetail.Quantity, IMIS_tblSaleOrderDetail.SalePrice, 
                         Lookup_tblCurrency.CurrencyName, IMIS_tblSaleOrderDetail.SNO
FROM         Lookup_tblCurrency INNER JOIN
                         IMIS_VWProducts INNER JOIN
                         IMIS_tblSaleOrderDetail ON IMIS_VWProducts.ProductCode = IMIS_tblSaleOrderDetail.ProductCode INNER JOIN
                         IMIS_tblSaleOrderMain ON IMIS_tblSaleOrderDetail.InvoiceNo = IMIS_tblSaleOrderMain.InvoiceNo INNER JOIN
                         IMIS_tblCustomer ON IMIS_tblSaleOrderMain.CustomerID = IMIS_tblCustomer.CustomerID ON Lookup_tblCurrency.CurrencyID = IMIS_tblSaleOrderDetail.CurrencyID 
WHERE     (IMIS_tblSaleOrderDetail.Status <> 'Full Returned') and  IMIS_tblSaleOrderMain.StoreID = " + conclass.StoreID + " and IMIS_tblCustomer.CustomerName like N'%" + txt_item_search.Text + "%' and cast(convert(varchar(12),SaleOrderDate,101) as datetime) between cast('" + from + "' as datetime) and cast('" + to + "' as datetime )order by IMIS_tblSaleOrderDetail.SNO desc");
                    lst_Item.Items.Clear();
                    int i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        i++;
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductBarCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["SalePrice"].ToString());
                        item.SubItems.Add(dr["CurrencyName"].ToString());
                        item.SubItems.Add(dr["InvoiceNo"].ToString());
                        item.SubItems.Add(dr["SaleOrderDate"].ToString());
                        item.SubItems.Add(dr["SaleOrderTime"].ToString());
                        item.SubItems.Add(dr["CustomerName"].ToString());
                        lst_Item.Items.Add(item);

                    }
                    obj.con.Close();
                    #endregion
                }
                else
                {
                    lst_Item.Items.Clear();
                }
            }
            else if (cmbSearchType.Text == "Salesman & Sales Date")
            {
                if (txt_item_search.Text.Length > 0)
                {
                    #region ByProductName
                    string from = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
                    string to = this.dtto.Value.Month.ToString() + "/" + this.dtto.Value.Day.ToString() + "/" + this.dtto.Value.Year.ToString();

                    dt = obj.GetData(@"SELECT  top 100  IMIS_VWProducts.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.ProductBarCode, IMIS_VWProducts.BarcodeLabelValue, IMIS_tblSaleOrderDetail.InvoiceNo, 
                         CONVERT(varchar(12), IMIS_tblSaleOrderMain.SaleOrderDate, 107) AS SaleOrderDate, CONVERT(varchar(8), IMIS_tblSaleOrderMain.SaleOrderTime, 113) AS SaleOrderTime, 
                         IMIS_tblCustomer.CustomerName, IMIS_tblSaleOrderDetail.Status, IMIS_tblSaleOrderDetail.Quantity, IMIS_tblSaleOrderDetail.SalePrice, 
                         Lookup_tblCurrency.CurrencyName, IMIS_tblSaleOrderDetail.SNO
FROM         Lookup_tblCurrency INNER JOIN
                         IMIS_VWProducts INNER JOIN
                         IMIS_tblSaleOrderDetail ON IMIS_VWProducts.ProductCode = IMIS_tblSaleOrderDetail.ProductCode INNER JOIN
                         IMIS_tblSaleOrderMain ON IMIS_tblSaleOrderDetail.InvoiceNo = IMIS_tblSaleOrderMain.InvoiceNo INNER JOIN
                         IMIS_tblCustomer ON IMIS_tblSaleOrderMain.CustomerID = IMIS_tblCustomer.CustomerID ON Lookup_tblCurrency.CurrencyID = IMIS_tblSaleOrderDetail.CurrencyID 
WHERE     (IMIS_tblSaleOrderDetail.Status <> 'Full Returned') and  IMIS_tblSaleOrderMain.StoreID = " + conclass.StoreID + " and IMIS_tblSaleMan.SaleManName like N'%" + txt_item_search.Text + "%' and  cast(convert(varchar(12),SaleOrderDate,101) as datetime) between cast('" + from + "' as datetime) and cast('" + to + "' as datetime )order by IMIS_tblSaleOrderDetail.SNO desc");
                    lst_Item.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductBarCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["SalePrice"].ToString());
                        item.SubItems.Add(dr["CurrencyName"].ToString());
                        item.SubItems.Add(dr["InvoiceNo"].ToString());
                        item.SubItems.Add(dr["SaleOrderDate"].ToString());
                        item.SubItems.Add(dr["SaleOrderTime"].ToString());
                        item.SubItems.Add(dr["CustomerName"].ToString());
                        lst_Item.Items.Add(item);
                    }
                    obj.con.Close();
                    #endregion
                }
                else
                {
                    lst_Item.Items.Clear();
                }
               
            }

           
        }

        private string GetCode(string Code)
        {
            string ReturnCode = Code;
            if (Code.Length == 1)
                ReturnCode = "00000000000" + Code;
            else if (Code.Length == 2)
                ReturnCode = "0000000000" + Code;
            else if (Code.Length == 3)
                ReturnCode = "000000000" + Code;
            else if (Code.Length == 4)
                ReturnCode = "00000000" + Code;
            else if (Code.Length == 5)
                ReturnCode = "0000000" + Code;
            else if (Code.Length == 6)
                ReturnCode = "000000" + Code;
            else if (Code.Length == 7)
                ReturnCode = "00000" + Code;
            else if (Code.Length == 8)
                ReturnCode = "0000" + Code;
            else if (Code.Length == 9)
                ReturnCode = "000" + Code;
            else if (Code.Length == 10)
                ReturnCode = "00" + Code;
            else if (Code.Length == 11)
                ReturnCode = "0" + Code;
            else if (Code.Length == 12)
                ReturnCode = Code;
            return ReturnCode;
        }

        private void lst_Item_DoubleClick_1(object sender, EventArgs e)
        {
            Decimal Total = 0;
            Decimal SoldQty = 0;
            Decimal SoldDiscount = 0;
            Decimal SalePrice = 0;
            txtNewTotal.Text = "0";
            txtCashReturnToCustomer.Text = "0";
            txtTotalBalance.Text = "0";
            try
            {
                string InvoiceNo = lst_Item.SelectedItems[0].SubItems[6].Text.ToString();
                string Code = lst_Item.SelectedItems[0].SubItems[0].Text.ToString();
                txtInvoiceNumber.Text = InvoiceNo;
                dataGridView1.Rows.Clear();
                ClearAllForSearch();
                FillInvoice(InvoiceNo);
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value.ToString().Equals(Code))
                        {
                            dataGridView1.Rows[i].Cells[17].Value = CheckState.Checked;
                            //if ((bool)dataGridView1.Rows[i].Cells[14].Value == true)
                            //{
                            SoldQty = Decimal.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                            SoldDiscount = Decimal.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
                            SalePrice = Decimal.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                            //Setting Sold Qty
                            dataGridView1.Rows[i].Cells[6].Value = SoldQty;
                            Total = Decimal.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString());
                            // This code is used to subtrect the discount and multiply by the qty
                            dataGridView1.Rows[i].Cells[10].Value = (SalePrice - SoldDiscount) * SoldQty;
                            //}
                            dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                    }
                }
                GetGrandTotal();
                gpitem_list.Visible = false;
                gpitem_list.SendToBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            gpitem_list.Visible = false;
            gpitem_list.SendToBack();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printInvoice(txtInvoiceNumber.Text, false);
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            Decimal Total = 0;
            Decimal SoldQty = 0;
            Decimal SoldDiscount = 0;
            Decimal SalePrice = 0;
            txtNewTotal.Text = "0";
            txtCashReturnToCustomer.Text = "0";
            txtTotalBalance.Text = "0";
            if (chkAll.Checked)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                    {
                        dataGridView1.Rows[i].Cells[17].Value = CheckState.Checked;
                        //if ((bool)dataGridView1.Rows[i].Cells[14].Value == true)
                        //{
                        SoldQty = Decimal.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                        SoldDiscount = Decimal.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
                        SalePrice = Decimal.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                        //Setting Sold Qty
                        dataGridView1.Rows[i].Cells[6].Value = SoldQty;
                        Total = Decimal.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString());
                        // This code is used to subtrect the discount and multiply by the qty
                        dataGridView1.Rows[i].Cells[10].Value = (SalePrice - SoldDiscount) * SoldQty;
                        //}
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
            }
            else
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                    {
                        dataGridView1.Rows[i].Cells[17].Value = CheckState.Unchecked;
                        dataGridView1.Rows[i].Cells[6].Value = 0;
                        dataGridView1.Rows[i].Cells[10].Value = 0;
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
            GetGrandTotal();
        }

        private void lst_Item_KeyDown(object sender, KeyEventArgs e)
        {
            Decimal Total = 0;
            Decimal SoldQty = 0;
            Decimal SoldDiscount = 0;
            Decimal SalePrice = 0;
            txtNewTotal.Text = "0";
            txtCashReturnToCustomer.Text = "0";
            txtTotalBalance.Text = "0";
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string InvoiceNo = lst_Item.SelectedItems[0].SubItems[6].Text.ToString();
                    string Code = lst_Item.SelectedItems[0].SubItems[0].Text.ToString();
                    txtInvoiceNumber.Text = InvoiceNo;
                    dataGridView1.Rows.Clear();
                    ClearAllForSearch();
                    FillInvoice(InvoiceNo);
                    if (dataGridView1.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                        {
                            if (dataGridView1.Rows[i].Cells[1].Value.ToString().Equals(Code))
                            {
                                dataGridView1.Rows[i].Cells[17].Value = CheckState.Checked;
                                //if ((bool)dataGridView1.Rows[i].Cells[14].Value == true)
                                //{
                                SoldQty = Decimal.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                                SoldDiscount = Decimal.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
                                SalePrice = Decimal.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                                //Setting Sold Qty
                                dataGridView1.Rows[i].Cells[6].Value = SoldQty;
                                Total = Decimal.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString());
                                // This code is used to subtrect the discount and multiply by the qty
                                dataGridView1.Rows[i].Cells[10].Value = (SalePrice - SoldDiscount) * SoldQty;
                                //}
                                dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                            }
                        }
                    }
                    GetGrandTotal();
                    gpitem_list.Visible = false;
                    gpitem_list.SendToBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
        }

        private void txt_item_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txt_item_search.Text != "")
            {
                GetProductByCode(txt_item_search.Text.Trim());
            }
            else if (e.KeyCode == Keys.Enter && lst_Item.Items.Count > 0)
            {
                lst_Item.Items[0].Selected = true;
                lst_Item.Items[0].EnsureVisible();
                lst_Item.Select();
                lst_Item.Focus();
            }
        }

        private void GetProductByCode(string Code)
        {
            #region Barcode Search
         DataTable   dt = obj.GetData(@"SELECT  top 100  IMIS_VWProducts.ProductCode, IMIS_VWProducts.ProductName, IMIS_VWProducts.ProductBarCode, IMIS_VWProducts.BarcodeLabelValue, IMIS_tblSaleOrderDetail.InvoiceNo, 
                         CONVERT(varchar(12), IMIS_tblSaleOrderMain.SaleOrderDate, 107) AS SaleOrderDate, CONVERT(varchar(8), IMIS_tblSaleOrderMain.SaleOrderTime, 113) AS SaleOrderTime, 
                         IMIS_tblCustomer.CustomerName, IMIS_tblSaleOrderDetail.Status, IMIS_tblSaleOrderDetail.Quantity, IMIS_tblSaleOrderDetail.SalePrice, 
                         Lookup_tblCurrency.CurrencyName, IMIS_tblSaleOrderDetail.SNO
FROM         Lookup_tblCurrency INNER JOIN
                         IMIS_VWProducts INNER JOIN
                         IMIS_tblSaleOrderDetail ON IMIS_VWProducts.ProductCode = IMIS_tblSaleOrderDetail.ProductCode INNER JOIN
                         IMIS_tblSaleOrderMain ON IMIS_tblSaleOrderDetail.InvoiceNo = IMIS_tblSaleOrderMain.InvoiceNo INNER JOIN
                         IMIS_tblCustomer ON IMIS_tblSaleOrderMain.CustomerID = IMIS_tblCustomer.CustomerID ON Lookup_tblCurrency.CurrencyID = IMIS_tblSaleOrderDetail.CurrencyID 
WHERE     (IMIS_tblSaleOrderDetail.Status <> 'Full Returned')   and  IMIS_tblSaleOrderMain.StoreID = " + conclass.StoreID + " AND IMIS_VWProducts.ProductBarCode='" + Code + "' order by IMIS_tblSaleOrderDetail.SNO desc");
            lst_Item.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                item.SubItems.Add(dr["ProductBarCode"].ToString());
                item.SubItems.Add(dr["ProductName"].ToString());
                item.SubItems.Add(dr["Quantity"].ToString());
                item.SubItems.Add(dr["SalePrice"].ToString());
                item.SubItems.Add(dr["CurrencyName"].ToString());
                item.SubItems.Add(dr["InvoiceNo"].ToString());
                item.SubItems.Add(dr["SaleOrderDate"].ToString());
                item.SubItems.Add(dr["SaleOrderTime"].ToString());
                item.SubItems.Add(dr["CustomerName"].ToString());
                lst_Item.Items.Add(item);
            }
            obj.con.Close();
            #endregion
        }





    }
}
