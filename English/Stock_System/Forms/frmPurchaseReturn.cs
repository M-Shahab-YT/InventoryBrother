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
    public partial class frmPurchaseReturn : Telerik.WinControls.UI.RadForm
    {
        Dbcommon obj = new Dbcommon();
        public frmPurchaseReturn()
        {
            InitializeComponent();
        }
        private void lodLastInvoiceNo()
        {
            DataTable dt = obj.GetData("select PurchaseOrderNo from IMIS_tblPurchaseOrderMain  where SNO=(select max(SNO) from IMIS_tblPurchaseOrderMain where StoreID=" + conclass.StoreID + " and UserID='" + conclass.User_ID + "')");
            if (dt.Rows.Count > 0)
                txtInvoiceNumber.Text = dt.Rows[0]["PurchaseOrderNo"].ToString();
        }
        private void frmPurchaseReturn_Load(object sender, EventArgs e)
        {
            lodLastInvoiceNo();
        }
        private void ClearAllForSearch()
        {
            dataGridView1.Rows.Clear();
          
            txtAccount.Text = "";
            txtCashReturnToCustomer.Text = "";
            txtCurrency.Text = "";
            txtCustomer.Text = "";
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
        private void FillInvoice(string InvoiceNo)
        {
            DataTable dtMain = obj.GetData(@"SELECT        IMIS_tblPurchaseOrderMain.SNO,IMIS_tblPurchaseOrderMain.SupplierID, IMIS_tblPurchaseOrderMain.PurchaseOrderNo,convert(varchar(12),IMIS_tblPurchaseOrderMain.OrderReceivedDate,107) as OrderReceivedDate, IMIS_tblPurchaseOrderMain.SupplierID, IMIS_tblPurchaseOrderMain.InvoiceNo, 
                         IMIS_tblPurchaseOrderMain.PaymentMethod, IMIS_tblPurchaseOrderMain.CurrencyID, IMIS_tblPurchaseOrderMain.ExchangeRate, IMIS_tblPurchaseOrderMain.TotalOrderAmount, IMIS_tblPurchaseOrderMain.TotalShippingCost, 
                         IMIS_tblPurchaseOrderMain.TotalBaseCurrencyAmount, IMIS_tblPurchaseOrderMain.AmountPaidToSupplier, IMIS_tblPurchaseOrderMain.BalanceAmount, IMIS_tblPurchaseOrderMain.PaymentStatus, 
                         IMIS_tblPurchaseOrderMain.Remarks, IMIS_tblPurchaseOrderMain.UserID, IMIS_tblPurchaseOrderMain.StoreID, IMIS_tblPurchaseOrderMain.SystemDate, IMIS_tblPurchaseOrderMain.SystemTime, 
                         IMIS_tblPurchaseOrderMain.LastUpdateBy, IMIS_tblPurchaseOrderMain.LastUpdateDate, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyPaidAmount, IMIS_tblPurchaseOrderMain.TotalBaseCurrencyBalanceAmount, 
                        isnull(IMIS_tblPurchaseOrderMain.CashReturnFromSupplier,0) as CashReturnFromSupplier, IMIS_tblSupplier.SupplierName, Lookup_tblCurrency.CurrencyName
FROM            IMIS_tblPurchaseOrderMain INNER JOIN
                         IMIS_tblSupplier ON IMIS_tblPurchaseOrderMain.SupplierID = IMIS_tblSupplier.SupplierID INNER JOIN
                         Lookup_tblCurrency ON IMIS_tblPurchaseOrderMain.CurrencyID = Lookup_tblCurrency.CurrencyID
						 where PurchaseOrderNo='" + InvoiceNo + "' and IMIS_tblPurchaseOrderMain.StoreID=" + conclass.StoreID + "");
            if (dtMain.Rows.Count > 0)
            {
                txtInvoiceNumber.Tag = dtMain.Rows[0]["PurchaseOrderNo"].ToString();
                txtSaleDate.Text = dtMain.Rows[0]["OrderReceivedDate"].ToString();
                txtCustomer.Text = dtMain.Rows[0]["SupplierName"].ToString();
                txtCustomer.Tag = dtMain.Rows[0]["SupplierID"].ToString();
                txtPaymentMethod.Text = dtMain.Rows[0]["PaymentMethod"].ToString();
                txtCurrency.Text = dtMain.Rows[0]["CurrencyName"].ToString();
                txtEchangeRate.Text = dtMain.Rows[0]["ExchangeRate"].ToString();
                txtOldGrandTotal.Text = dtMain.Rows[0]["TotalOrderAmount"].ToString();
                txtTotalPaidAmount.Text = (Decimal.Parse(dtMain.Rows[0]["AmountPaidToSupplier"].ToString()) - Decimal.Parse(dtMain.Rows[0]["CashReturnFromSupplier"].ToString())).ToString();
                txtTotalBalance.Text = dtMain.Rows[0]["BalanceAmount"].ToString();
                txtCurrency.Tag = dtMain.Rows[0]["CurrencyID"].ToString();
            }
            DataTable dtAccount = obj.GetData(@"SELECT        FMIS_tblCashAccounts.AccountName, FMIS_tblCashAccountsInOutDetail.AccountID
FROM            FMIS_tblCashAccountsInOutDetail INNER JOIN
                         FMIS_tblCashAccounts ON FMIS_tblCashAccountsInOutDetail.AccountID = FMIS_tblCashAccounts.AccountID
WHERE        FMIS_tblCashAccountsInOutDetail.StoreID = " + conclass.StoreID + " and EntryReference='Purchase' and EntryReferenceNumber='" + txtInvoiceNumber.Tag.ToString() + "'");
            if (dtAccount.Rows.Count > 0)
            {
                txtAccount.Text = dtAccount.Rows[0]["AccountName"].ToString();
                txtAccount.Tag = dtAccount.Rows[0]["AccountID"].ToString();
            }
            DataTable dtDetail = obj.GetData(@"SELECT        IMIS_tblPurchaseOrderDetail.SNO, IMIS_VWProducts.ProductName, IMIS_tblPurchaseOrderDetail.PurchasePrice, IMIS_tblPurchaseOrderDetail.ShippingCostPerItem, IMIS_tblPurchaseOrderDetail.BaseCurrencyTotal, 
                         IMIS_tblPurchaseOrderDetail.BaseCurrencyPrice, IMIS_tblPurchaseOrderDetail.Total, IMIS_tblPurchaseOrderDetail.Quantity, IMIS_tblPurchaseOrderDetail.Status, IMIS_tblPurchaseOrderDetail.ProductCode, 
                         IMIS_tblPurchaseOrderDetail.BatchNo,CONVERT(varchar(12),IMIS_tblPurchaseOrderDetail.ExpiryDate, 106) AS ExpiryDate
FROM            IMIS_VWProducts INNER JOIN
                         IMIS_tblPurchaseOrderDetail ON IMIS_VWProducts.ProductCode = IMIS_tblPurchaseOrderDetail.ProductCode
WHERE        IMIS_tblPurchaseOrderDetail.Status IN ('Purchased', 'Quantity Returned') and IMIS_tblPurchaseOrderDetail.StoreID=" + conclass.StoreID + " and  (IMIS_tblPurchaseOrderDetail.PurchaseOrderNo = '" + InvoiceNo + "') ");
            if (dtDetail.Rows.Count > 0)
            {
                foreach (DataRow dr in dtDetail.Rows)
                {
                    string[] row = new string[] { dr["SNO"].ToString(), dr["ProductCode"].ToString(), dr["ProductName"].ToString(), dr["BatchNo"].ToString(),dr["ExpiryDate"].ToString(),dr["Quantity"].ToString(), "0", dr["PurchasePrice"].ToString(), dr["Total"].ToString(), "0", dr["BaseCurrencyPrice"].ToString() };
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClearAllForSearch();
            FillInvoice(txtInvoiceNumber.Text);
            if(txtNewTotal.Text!="" && Decimal.Parse(txtNewTotal.Text)>0)
            btnsave.Enabled = true;
        }
        private void GetGrandTotal()
        {
            txtCashReturnToCustomer.Text = "";
            Decimal GrandTotal = 0;
            Decimal ReturnGrandTotal = 0;
            Decimal NewGrandTotal = 0;
            foreach (DataGridViewRow gr in dataGridView1.Rows)
            {
                if (gr.Cells[11].Value != null)
                {
                    if (Convert.ToBoolean(gr.Cells[11].Value))
                    {
                        ReturnGrandTotal = ReturnGrandTotal + Decimal.Parse(gr.Cells[9].Value.ToString());
                    }
                }
            }
            GrandTotal = Decimal.Parse(dataGridView1.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[8].Value.ToString())).ToString());
            NewGrandTotal = GrandTotal - ReturnGrandTotal;
            txtNewTotal.Text = NewGrandTotal.ToString();
            txtReturnTotal.Text = ReturnGrandTotal.ToString();
            Decimal PaidAmount = Decimal.Parse(txtTotalPaidAmount.Text);
            Decimal NewBalance = 0;
            NewBalance = NewGrandTotal - PaidAmount;
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
            if (e.ColumnIndex == 11 && e.RowIndex >= 0)
            {
                this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                if ((bool)this.dataGridView1.CurrentCell.Value == true)
                {
                    SoldQty = Decimal.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                    //SoldDiscount = Decimal.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString());
                    SalePrice = Decimal.Parse(dataGridView1.CurrentRow.Cells[7].Value.ToString());
                    //Setting Sold Qty
                    dataGridView1.CurrentRow.Cells[6].Value = SoldQty;
                    Total = Decimal.Parse(dataGridView1.CurrentRow.Cells[8].Value.ToString());

                    // This code is used to subtrect the discount and multiply by the qty
                    dataGridView1.CurrentRow.Cells[9].Value = (SalePrice) * SoldQty;

                }
                else
                {
                    dataGridView1.CurrentRow.Cells[6].Value = 0;
                    dataGridView1.CurrentRow.Cells[9].Value = 0;
                }
                GetGrandTotal();
            }
        }
        public void InsertSaleOrder()
        {
            obj.con.Open();
            SqlTransaction tran = obj.con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Transaction = tran;
            cmd.Connection = obj.con;
            Decimal ReturnTotal = 0;
            bool status = false;
            try
            {
                Int64 MaxID = conclass.nextid("FMIS_tblSupplierStatement", "ID");
                long ProductStatementID = conclass.nextid("ProductStatement", "ID");
                foreach (DataGridViewRow gr in dataGridView1.Rows)
                {
                    if (gr.Cells[11].Value != null)
                    {
                        DataGridViewCheckBoxCell chk = gr.Cells[11] as DataGridViewCheckBoxCell;
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
                            string ExpryDate = "";
                            bool FullReturn = false;
                            try
                            {
                                SNO = int.Parse(gr.Cells[0].Value.ToString());
                                ItemCode = gr.Cells[1].Value.ToString();
                                SoldQty = Decimal.Parse(gr.Cells[5].Value.ToString());
                                ReturnQty = Decimal.Parse(gr.Cells[6].Value.ToString());
                                SalePrice = Decimal.Parse(gr.Cells[7].Value.ToString());
                                SoldTotal = Decimal.Parse(gr.Cells[8].Value.ToString());
                                ReturnTotal = Decimal.Parse(gr.Cells[9].Value.ToString());
                                BaseCurrencySalePrice = Decimal.Parse(gr.Cells[10].Value.ToString());


                                ExpryDate = gr.Cells[4].Value.ToString();
                               // ExpryDate = DateTime.Parse(gr.Cells[4].Value.ToString()).ToString("dd/MM/yyyy");
                               // MessageBox.Show(gr.Cells[4].Value.ToString());
                                //string ExpiryDate = DateTime.Parse("01/" + item.SubItems[5].Text).ToString("dd/MM/yyyy");

                                if (SoldQty > ReturnQty)
                                {
                                    FullReturn = false;
                                    ReturnTotal = (SoldQty - ReturnQty) * (SalePrice);
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
                            cmd.CommandText = @"insert into IMIS_tblPurchaseReturnTransaction(InvoiceNo, RowNumber, ProductCode, ReturnQuantity, ReturnAmount, StoreID, ReturnUserID) 
                            values('" + txtInvoiceNumber.Tag.ToString() + "', " + SNO + ", '" + ItemCode + "', " + ReturnQty + ", " + ReturnTotal + "," + conclass.StoreID + ", N'" + conclass.User_ID + "')";
                            cmd.ExecuteNonQuery();

                            if (FullReturn == true)
                                cmd.CommandText = @"update IMIS_tblPurchaseOrderDetail set Status='Full Returned',Remarks='" + ReturnQty + " Items are Returned',LastUpdateBy=N'" + conclass.User_ID + "',LastUpdateDate=getdate(),QuantityReturned=" + ReturnQty + "  where SNO=" + SNO + "";
                            else
                                cmd.CommandText = @"update IMIS_tblPurchaseOrderDetail set Status='Quantity Returned',Quantity=Quantity-" + ReturnQty + ",QuantityReturned=" + ReturnQty + ",BaseCurrencyTotal=" + TotalBasCurrencyTotal + ",Total=" + ReturnTotal + ",Remarks='" + ReturnQty + " Items are Returned',LastUpdateBy=N'" + conclass.User_ID + "',LastUpdateDate=getdate()  where SNO=" + SNO + "";
                            cmd.ExecuteNonQuery();
                            #region Stock Update


                            cmd.CommandText = @"update IMIS_tblStock set Quantity=Quantity-" + ReturnQty + " where  ProductCode='" + ItemCode + "' and StoreID=" + conclass.StoreID + " and cast(convert(varchar(12),ExpiryDate,106) as datetime)=cast(convert(varchar(12),'" + ExpryDate + "',106) as datetime)";
                            cmd.ExecuteNonQuery();
                            #endregion

                            #region Product Statement
                            string StatementDescription = "Purchase Return :Invoice No:" + txtInvoiceNumber.Tag.ToString();
                            cmd.CommandText = @"insert into ProductStatement( ID, ProductID, ReferenceType, ReferenceNumber, Particulars, Debit, Credit, UserID) 
                            values(" + ProductStatementID + ", '" + ItemCode + "','Purchase Return' , '" + SNO + "', '" + StatementDescription + "'," + ReturnQty + ",0,N'" + conclass.User_ID + "')";
                            cmd.ExecuteNonQuery();
                            ProductStatementID++;
                            #endregion
                        }
                        
                    }


                    
                }
                Decimal Total_Base_Currency_Amount = ToBaseCurrencyPrice(Decimal.Parse(txtNewTotal.Text), int.Parse(txtCurrency.Tag.ToString()), Decimal.Parse(txtEchangeRate.Text));
                Decimal Total_Base_Currency_Paid_Amount = ToBaseCurrencyPrice(Decimal.Parse(txtTotalPaidAmount.Text), int.Parse(txtCurrency.Tag.ToString()), Decimal.Parse(txtEchangeRate.Text));
                Decimal Total_Base_Currency_Balance_Amount = Decimal.Parse(txtNewBalance.Text);
                Decimal CashReturnToCustomer = Math.Abs(Decimal.Parse(txtCashReturnToCustomer.Text));
                Decimal BaseCurrencyCashReturnToCustomer = ToBaseCurrencyPrice(CashReturnToCustomer, int.Parse(txtCurrency.Tag.ToString()), Decimal.Parse(txtEchangeRate.Text));
                if (txtPaymentMethod.Text == "Loan" || txtPaymentMethod.Text == "Cash and Loan")
                {
                    ReturnTotal = 0;
                    #region Supplier Statment
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

                    //This Query will give the Sum Of Credit
                    cmd.CommandText = "select isnull(Sum(Credit),0) As SumOfCredit from FMIS_tblSupplierStatement where SupplierID=" + txtCustomer.Tag.ToString() + " and StoreID=" + conclass.StoreID + " and CurrencyID=" + txtCurrency.Tag.ToString() + "";
                    SqlDataAdapter daSumOfCredit = new SqlDataAdapter(cmd);
                    daSumOfCredit.Fill(dtSumOfCredit);

                    //This Query will give the Sum Of Debit
                    cmd.CommandText = "select isnull(Sum(Debit),0) As SumOfDebit from FMIS_tblSupplierStatement where SupplierID=" + txtCustomer.Tag.ToString() + " and StoreID=" + conclass.StoreID + " and CurrencyID=" + txtCurrency.Tag.ToString() + "";
                    SqlDataAdapter daSumOfDebit = new SqlDataAdapter(cmd);
                    daSumOfDebit.Fill(dtSumOfDebit);
                    if (dtSumOfCredit.Rows.Count > 0 && dtSumOfDebit.Rows.Count > 0)
                    {
                        TotalCredit = Decimal.Parse(dtSumOfCredit.Rows[0]["SumOfCredit"].ToString());
                        TotalDebit = Decimal.Parse(dtSumOfDebit.Rows[0]["SumOfDebit"].ToString()) + ReturnTotal;
                        //Formula
                        NewCustomerBalance = TotalCredit - TotalDebit;
                    }
                    #endregion
                    if (ReturnTotal > 0)
                    {
                        cmd.CommandText = @"insert into FMIS_tblSupplierStatement(ID, SupplierID, StoreID, ReferenceType,ReferenceNumber, Particulars, CurrencyID,ExchangeRate, Debit, Credit, Balance, UserID) 
                        values(" + MaxID + "," + txtCustomer.Tag.ToString() + "," + conclass.StoreID + ", 'Purchase Return','" + txtInvoiceNumber.Tag.ToString() + "', N'Purchase Return'," + txtCurrency.Tag.ToString() + "," + txtEchangeRate.Text + "," + ReturnTotal + ",0," + NewCustomerBalance + ", '" + conclass.User_ID + "')";
                        cmd.ExecuteNonQuery();
                    }
                    #endregion
                }
                if (txtCashReturnToCustomer.Text != "" && txtPaymentMethod.Text != "Loan")
                {
                    if (CashReturnToCustomer > 0)
                    {
                        cmd.CommandText = @"insert into FMIS_tblCashAccountsInOutDetail(AccountID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID,StoreID) values(" + cmbPaymentAccount.SelectedValue + ", " + CashReturnToCustomer + ", 'In', 'Purchase Return', '" + txtInvoiceNumber.Tag.ToString() + "', N'Purchase Return', N'" + conclass.User_ID + "'," + conclass.StoreID + ")";
                        cmd.ExecuteNonQuery();
                    }
                }
                cmd.CommandText = @"update IMIS_tblPurchaseOrderMain set TotalOrderAmount=" + txtNewTotal.Text + ",BalanceAmount=" + txtNewBalance.Text + ",TotalBaseCurrencyAmount=" + Total_Base_Currency_Amount + ",TotalBaseCurrencyBalanceAmount=" + Total_Base_Currency_Balance_Amount + ",LastUpdateBy='" + conclass.User_ID + "', LastUpdateDate=getdate(),Remarks='Some of Items Are Returned',CashReturnFromSupplier=isnull(CashReturnFromSupplier,0)+" + CashReturnToCustomer + ",BaseCurrencyCashReturnFromSupplier=isnull(BaseCurrencyCashReturnFromSupplier,0)+" + BaseCurrencyCashReturnToCustomer + " where PurchaseOrderNo='" + txtInvoiceNumber.Tag.ToString() + "' and StoreID=" + conclass.StoreID + "";
                cmd.ExecuteNonQuery();
                tran.Commit();
                btnsave.Enabled = false;
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
        private void btnsave_Click(object sender, EventArgs e)
        {
            InsertSaleOrder();
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

        private void btnCloseAds_Click(object sender, EventArgs e)
        {
            gpitem_list.SendToBack();
            gpitem_list.Visible = false;
        }

        private void btnSerachAd_Click(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "")
            {
                MessageBox.Show("Please Chose Search Type");
                return;
            }

            if (cmbSearchType.Text == "Product Name")
            {
                if (txtSearchValue.Text.Length > 0)
                {
                    #region ByProductName
                    obj.con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conclass.con;
                    cmd.CommandText = "IMIS_ProSearchProductByCodePurchaseReturn";
                    cmd.Parameters.Add("@CRI", SqlDbType.VarChar).Value = txtSearchValue.Text.Trim();
                    cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = Class.conclass.StoreID;
                    cmd.Parameters.Add("@SarchType", SqlDbType.VarChar).Value = "By Name";
                    cmd.Parameters.Add("@Date", SqlDbType.VarChar).Value = "";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    lst_Item.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductBarCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["PurchasePrice"].ToString());
                        item.SubItems.Add(dr["CurrencyName"].ToString());
                        item.SubItems.Add(dr["PurchaseOrderNo"].ToString());
                        item.SubItems.Add(dr["OrderReceivedDate"].ToString());
                        item.SubItems.Add(dr["SupplierName"].ToString());
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
            else if (cmbSearchType.Text == "Product BarCode")
            {
                if (txtSearchValue.Text.Length > 0)
                {
                    #region searechByCode
                    obj.con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conclass.con;
                    cmd.CommandText = "IMIS_ProSearchProductByCodePurchaseReturn";
                    cmd.Parameters.Add("@CRI", SqlDbType.VarChar).Value = txtSearchValue.Text.Trim();
                    cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = Class.conclass.StoreID;
                    cmd.Parameters.Add("@SarchType", SqlDbType.VarChar).Value = "By BarCode";
                    cmd.Parameters.Add("@Date", SqlDbType.VarChar).Value = "";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    lst_Item.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductBarCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["PurchasePrice"].ToString());
                        item.SubItems.Add(dr["CurrencyName"].ToString());
                        item.SubItems.Add(dr["PurchaseOrderNo"].ToString());
                        item.SubItems.Add(dr["OrderReceivedDate"].ToString());
                        item.SubItems.Add(dr["SupplierName"].ToString());
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
            else if (cmbSearchType.Text == "Product Name & Purchase Date")
            {
                #region searechByCode
                try
                {
                    string Date = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
                    obj.con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conclass.con;
                    cmd.CommandText = "IMIS_ProSearchProductByCodePurchaseReturn";
                    cmd.Parameters.Add("@CRI", SqlDbType.VarChar).Value = txtSearchValue.Text.Trim();
                    cmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = Class.conclass.StoreID;
                    cmd.Parameters.Add("@SarchType", SqlDbType.VarChar).Value = "Product Name & Purchase Date";
                    cmd.Parameters.Add("@Date", SqlDbType.VarChar).Value = Date;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    lst_Item.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductBarCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["PurchasePrice"].ToString());
                        item.SubItems.Add(dr["CurrencyName"].ToString());
                        item.SubItems.Add(dr["PurchaseOrderNo"].ToString());
                        item.SubItems.Add(dr["OrderReceivedDate"].ToString());
                        item.SubItems.Add(dr["SupplierName"].ToString());
                        lst_Item.Items.Add(item);
                    }
                    obj.con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
            }
        }

        private void cmbSearchType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "Product Name & Purchase Date")
                gpdate.Enabled = true;
            else
                gpdate.Enabled = false;
            txtSearchValue.Text = "";
            txtSearchValue.Focus();
        }
        private void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
            gpitem_list.BringToFront();
            gpitem_list.Visible = true;
        }

        private void lst_Item_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string InvoiceNo = lst_Item.SelectedItems[0].SubItems[6].Text.ToString();
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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtSNO.Text = dataGridView1.CurrentRow.Index.ToString();
            txtSoldQty.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtSalePrice.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            pnlReturn.Visible = true;
            pnlReturn.BringToFront();
            txtReturnQty.Focus();
            
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
                dataGridView1.Rows[index].Cells[9].Value = Decimal.Parse(txtSalePrice.Text) * Decimal.Parse(txtReturnQty.Text);
                dataGridView1.Rows[index].Cells[11].Value = CheckState.Checked;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlReturn.Visible = false;
            pnlReturn.SendToBack();
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
                        dataGridView1.Rows[i].Cells[11].Value = CheckState.Checked;
                        SoldQty = Decimal.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                        SalePrice = Decimal.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                        //Setting Sold Qty
                        dataGridView1.Rows[i].Cells[6].Value = SoldQty;
                        dataGridView1.Rows[i].Cells[9].Value = SalePrice * SoldQty;
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
                        dataGridView1.Rows[i].Cells[11].Value = CheckState.Unchecked;
                        dataGridView1.Rows[i].Cells[6].Value = 0;
                        dataGridView1.Rows[i].Cells[9].Value = 0;
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
            GetGrandTotal();
        }
    }
}
