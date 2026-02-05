using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.IO.Ports;
using Stock_System.Class;
using System.Text.RegularExpressions;
using System.Globalization;
namespace Stock_System.Forms
{
    public partial class frmpurchase : Form
    {
        public frmpurchase()
        {
            InitializeComponent();
            conclass.opecon();
        }
        string Invoice_No = "";
        SqlDataAdapter da;
        Double avg_rate = 0;
        Double Current_Rate = 0;
        Decimal grandTotal = 0;
        Dbcommon obj = new Dbcommon();
        private void clearTexboxes()
        {
            txtitemName.Text = "";
            txtBarCode.Text = "";
            txtQty.Text = "";
            txtPrice.Text = "";
            txtTotal.Text = "";
            txtBarCode.Focus();
        }
        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPrice.Focus();
        }
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.txtQty.Text.Length > 0)
                {
                    txtPrice.Focus();
                }
            }

            if (e.KeyChar != 13)
            {
                conclass.ASCIn(e);

            }

        }
        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtTotal.Text = string.Empty;
                if (txtQty.Text.Trim() != string.Empty && this.txtPrice.Text.Trim() != string.Empty)
                    this.txtTotal.Text = Convert.ToString(Convert.ToDecimal(this.txtPrice.Text) * Convert.ToDecimal(this.txtQty.Text));
            }
            catch (Exception)
            {

            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gpitem_list.SendToBack();
            gpitem_list.Visible = false;
            txtBarCode.Focus();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
        
      
       
    
      
    
        private void DeleteInvoice(string InvoiceNo)
        {
            Class.conclass.ExecuteQuery(@"delete from purchase where invoice_no=" + InvoiceNo + "");
            DataTable dt = Class.conclass.GetRecord(@"SELECT     invoice_no, item_id, qty, purchase_price, total, sno, Unite_ID
            FROM  purchase_detail where invoice_no=" + InvoiceNo + "");
            foreach (DataRow dr in dt.Rows)
            {
                Class.conclass.ExecuteQuery(@"update stock_in_hand set total_qty=total_qty-" + dr["qty"].ToString() + " where Item_id=" + dr["item_id"].ToString() + "");
            }
            Class.conclass.ExecuteQuery(@"delete from purchase_detail where invoice_no=" + InvoiceNo + "");
        }
        

        private void SetSubTotal()
        {

            Decimal ShipingCost = 0;
            Decimal NetTotal = 0;
            Decimal GrandTotal = 0;
            if (txtTotalShippingCost.Text != "")
                ShipingCost = Decimal.Parse(txtTotalShippingCost.Text);

            if (txtGrandTotal.Text != "")
                NetTotal = Decimal.Parse(txtGrandTotal.Text);

            if (cmbPaymentMethod.Text == "Loan")
            {
                txt_balance.Text = txtGrandTotal.Text;
                txt_paid_amt.Text = "0";
                txt_paid_amt.Enabled = false;
                cmbPaymentAccount.Enabled = false;
                //  txtTotalShippingCost.Focus();
            }
            if (cmbPaymentMethod.Text == "Cash and Loan")
            {
                txt_balance.Text = txtGrandTotal.Text;
                txt_paid_amt.Text = "0";
                txt_paid_amt.Enabled = true;
                cmbPaymentAccount.Enabled = true;
                txt_paid_amt.Focus();
            }
            else if (cmbPaymentMethod.Text == "Cash" || cmbPaymentMethod.Text == "Bank")
            {
                txt_paid_amt.Text = txtGrandTotal.Text;
                txt_paid_amt.Enabled = false;
                txt_balance.Text = "0";
                cmbPaymentAccount.Enabled = true;
                txtTotalShippingCost.Focus();
                //GrandTotal = (NetTotal + ShipingCost);
                //Balance = GrandTotal - TotalPaid;
                //txtNetBalance.Text = Balance.ToString();
            }

            //-------------------------if the invoice chanage to the cahs or bank
            //if (cmbPaymentMethod.Text == "Loan" || cmbPaymentMethod.Text == "Cash and Loan")
            //{
            //    rdCash.Enabled = true;
            //    cmbShippingCostPaymentAccount.Enabled = true;
            //}
            //else
            //{
            //    rdCash.Enabled = false;
            //    cmbShippingCostPaymentAccount.Enabled = false;
            //}
        }
        private void cmbPaymentMethod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetSubTotal();




            // old code
            //if (cmbPaymentMethod.Text == "Cash")
            //{
            //    DataTable dtC = obj.GetData("SELECT    CurrencyID, CurrencyName, CurrencySymbol, ToBaseCurrencyOperator, FromBaseCurrencyOperator, IsBaseCurrency FROM Lookup_tblCurrency where IsBaseCurrency='Yes'");
            //    if (dtC.Rows.Count > 0)
            //        cmbCurrency.SelectedValue = dtC.Rows[0]["CurrencyID"].ToString();
            //}
            //if (cmbPaymentMethod.Text == "Loan")
            //{
            //    cmbPaymentAccount.Enabled = false;
            //    txt_paid_amt.Text = "0";
            //    txt_balance.Text = txt_grand_total.Text;
            //    txt_paid_amt.Enabled = false;
            //    btnsave.Focus();
            //}
            //else
            //{
            //    txt_paid_amt.Text = "";
            //    txt_balance.Text = txt_grand_total.Text;
            //    txt_paid_amt.Enabled = true;
            //    cmbPaymentAccount.Enabled = true;
            //    txt_paid_amt.Focus();
            //}
        }
        private void cmbCurrency_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT ID, CurrencyID, ExchangeRate FROM  FMIS_tblCurrencyExchangeRate where ID=(select max(ID) from FMIS_tblCurrencyExchangeRate where StoreID=" + conclass.StoreID + " and  CurrencyID=" + cmbCurrency.SelectedValue + ")");
            if (dt.Rows.Count > 0)
            {
                txtExchangeRate.Text = dt.Rows[0]["ExchangeRate"].ToString();
                obj.fillcmb(cmbPaymentAccount, "AccountName", "AccountID", "SELECT  AccountID, AccountName FROM FMIS_tblCashAccounts where StoreID=" + conclass.StoreID + " and CurrencyID=" + cmbCurrency.SelectedValue + "");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SerialPort sp = new SerialPort();
            sp.PortName = "COM3";
            sp.BaudRate = 9600;
            sp.Parity = Parity.None;
            sp.DataBits = 8;
            sp.StopBits = StopBits.One;
            sp.Open();
            //sp.Write(new byte[] { 0x0C }, 0, 1);
            string amount = "200";
            char[] charray = amount.ToCharArray();
            sp.Encoding = System.Text.Encoding.UTF8;
            byte[] by = System.Text.Encoding.UTF8.GetBytes(charray);
            sp.Write(by, 0, by.Length);
           // sp.WriteLine(by);
            sp.Close();
            sp.Dispose();
            sp = null;
            //-------------------------

            // SerialPort sport = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            //sport.Open();

            //Clear the Display
            //sport.Write(new byte[] { 0x0C }, 0, 1);
            //sport.Write("My System");
            // sport.Write("Hello Nazeer");
            //Goto Bottem Line - Most Left
            //sport.Write(new byte[] { 0x0A, 0x0D }, 0, 2);


            // MessageBox.Show("Hello");

            //sport.Close();

            //LineDisplay lineDisplay;
            //PosExplorer explorer;

            //explorer = new PosExplorer(this);
            //DeviceCollection devColl = explorer.GetDevices(DeviceType.LineDisplay); // is this line the problem?
            ////DeviceCollection devColl = explorer.GetDevice("LineDisplay", "HPLCM220Display"); // this one shows errors so I couldnt use it instead of the line above
            //if (devColl == null || devColl.Count <= 0)
            //{
            //    MessageBox.Show("Device not found");
            //    return;
            //}
            //lineDisplay = (LineDisplay)explorer.CreateInstance(devColl[0]);
            //lineDisplay.Open();
            //lineDisplay.Claim(10000);
            //lineDisplay.DeviceEnabled = true;
            //lineDisplay.DisplayText("Hello World.!");
            //lineDisplay.DisplayTextAt(1, 0, "Hey MSDN");

        }
        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            string cod = this.txtBarCode.Text.Trim();
            if (cod.Length == 14)
            {
                GetProductByCode(cod);
            }
            if (cod.Length == 13)
            {
                GetProductByCode(cod);
            }
            else if (cod.Length == 12)
            {
                GetProductByCode(cod);
            }
            else if (cod.Length == 11)
            {
                GetProductByCode(cod);
            }
            else if (cod.Length == 10)
            {
                GetProductByCode(cod);
            }
            else if (cod.Length == 9)
            {
                GetProductByCode(cod);
            }
            else if (cod.Length == 8)
            {
                GetProductByCode(cod);
            }
            else if (cod.Length == 7)
            {
                GetProductByCode(cod);
            }
            else if (cod.Length == 6)
            {
                GetProductByCode(cod);
            }
            else if (cod.Length == 5)
            {
                GetProductByCode(cod);
            }
            else if (cod.Length == 4)
            {
                GetProductByCode(cod);
            }
            else if (cod.Length == 3)
            {
                GetProductByCode(cod);
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (cmbSupplier.Text == "-Supplier-")
            {
                MessageBox.Show("Select Supplier");
                this.cmbSupplier.Focus();
                return;
            }
            //if (cmbPaymentMethod.Text == "Cash" && rdLoan.Checked)
            //{
            //    MessageBox.Show("Your Invoice Amount is in Cash,So your Shipping Cost Must Not Be in loan");
            //    return;
            //}


            SavePurchase();
        }
        #region My Function
        private Decimal Get_Charges_Per_Item(Decimal Price, Decimal TotalChargest, Decimal GrandTotal)
        {
            Decimal Charges = 0;
            if (TotalChargest > 0)
                Charges = Price * TotalChargest / GrandTotal;
            else
                Charges = 0;
            return Charges;
        }
        private Decimal Get_Base_Currency_Price(Decimal Price, int Currency_ID, Decimal ExchangeRate)
        {
            Decimal BasePrice = 0;
            String Operator = "";
            string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            DataTable dt_cr = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT  CurrencyID, CurrencyName,ltrim(rtrim(ToBaseCurrencyOperator))  as  ExchangeOperator, IsBaseCurrency FROM  Lookup_tblCurrency where CurrencyID=" + Currency_ID + "", con);
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




        private void SavePurchase()
        {
            if (Convert.ToDecimal(txtGrandTotal.Text) == 0 || txtGrandTotal.Text=="")
            {
                MessageBox.Show("Please fill the Invoice..");
                return;
            }
            if (cmbPaymentMethod.Text == "")
            {
                MessageBox.Show("Chose Payment Method");
                cmbPaymentMethod.Focus();
                return;
            }
            long MaxID = conclass.nextid("FMIS_tblSupplierStatement", "ID");
            long ProductStatementID = conclass.nextid("ProductStatement", "ID");
            Decimal TotalOrderAmount = 0;
            Decimal TotalShippingCost = 0;
            Decimal CostPerItem = 0;
            Decimal TotalBaseCurrencyAmount = 0;
            Decimal   TotalBaseCurrencyPaidAmount=0;
            Decimal TotalBaseCurrencyBalanceAmount = 0;
            Decimal TotalShippingCostBaseCurrency = 0;
            Decimal TotalCashPayment = 0;
            TotalOrderAmount = Decimal.Parse(txtGrandTotal.Text);
            TotalShippingCost = Decimal.Parse(txtTotalShippingCost.Text == "" ? "0" : txtTotalShippingCost.Text);
            TotalCashPayment = Decimal.Parse(txt_paid_amt.Text == "" ? "0" : txt_paid_amt.Text);
            //Invoice_No = GetOrderNo();
            //long PurchaseOrderNo = conclass.nextid("IMIS_tblPurchaseOrderMain", "PurchaseOrderNo");
            Invoice_No = GenerateOrderNo().ToString();
            obj.con.Open();
            SqlTransaction tran = obj.con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Transaction = tran;
            cmd.Connection = obj.con;
            try
            {
                TotalBaseCurrencyAmount = ToBaseCurrencyPrice(Decimal.Parse(txtGrandTotal.Text), int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                TotalBaseCurrencyPaidAmount = ToBaseCurrencyPrice(Decimal.Parse(txt_paid_amt.Text), int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                TotalBaseCurrencyBalanceAmount = ToBaseCurrencyPrice(Decimal.Parse(txt_balance.Text), int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                TotalShippingCostBaseCurrency = 0;
                cmd.CommandText = @"Insert into IMIS_tblPurchaseOrderMain(PurchaseOrderNo, OrderReceivedDate, SupplierID, PaymentMethod, CurrencyID, ExchangeRate, TotalOrderAmount, TotalShippingCost,ShippingCostCurrencyID,ShippingCostExchangeRate,TotalShippingCostBaseCurrency, TotalBaseCurrencyAmount,TotalBaseCurrencyPaidAmount,TotalBaseCurrencyBalanceAmount, AmountPaidToSupplier, BalanceAmount, PaymentStatus, UserID,StoreID,InvoiceNo,DeliveryPerson)
                values('" + Invoice_No + "',getdate(), " + cmbSupplier.SelectedValue + ",'" + cmbPaymentMethod.Text + "', " + cmbCurrency.SelectedValue + ", " + txtExchangeRate.Text + " ," + txtGrandTotal.Text + "," + TotalShippingCost + "," + cmbCurrency.SelectedValue + "," + txtExchangeRate.Text + "," + TotalShippingCostBaseCurrency + " ," + TotalBaseCurrencyAmount + "," + TotalBaseCurrencyPaidAmount + "," + TotalBaseCurrencyBalanceAmount + "," + txt_paid_amt.Text + ", " + txt_balance.Text + ",'Purchase',N'" + conclass.User_ID + "'," + conclass.StoreID + ",N'" + txtBillNo.Text + "',N'" + txtDeliveryPerson.Text + "')";
                    cmd.ExecuteNonQuery();
               
                //Condation one
                // Cahs and cash and laon and payment is grather than 0 than this condation for invoice payment
                if (cmbPaymentMethod.Text != "Loan" && Decimal.Parse(txt_paid_amt.Text) > 0)
                {
                    //Checking Current Balance in the System
                    DataTable dtCheckAccountBalance = new DataTable();
                    cmd.CommandText = "select isnull(CurrentBalance,0) as CurrentBalance from FMIS_VWCashAccountsInOutDetail where AccountID='" + cmbPaymentAccount.SelectedValue + "' and StoreID=" + conclass.StoreID + "";
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    da1.Fill(dtCheckAccountBalance);
                    if (TotalCashPayment > Decimal.Parse(dtCheckAccountBalance.Rows[0]["CurrentBalance"].ToString()))
                    {
                        MessageBox.Show("There is no enough amount in the Selected Account for selected Invoice");
                        return;
                    }
                    cmd.CommandText = @"insert into FMIS_tblCashAccountsInOutDetail(AccountID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID,StoreID) 
                    values(" + cmbPaymentAccount.SelectedValue + ", " + txt_paid_amt.Text + ", 'Out', 'Purchase', '" + Invoice_No + "', N'" + cmbPaymentMethod.Text + "', N'" + conclass.User_ID + "'," + conclass.StoreID + ")";
                    cmd.ExecuteNonQuery();

                 


                }
//                if (rdCash.Checked)
//                {
//                    DataTable dtCheckAccountBalanceShippingCost = new DataTable();
//                    cmd.CommandText = "select isnull(CurrentBalance,0) as CurrentBalance from FMIS_VWCashAccountsInOutDetail where AccountID='" + cmbShippingCostPaymentAccount.SelectedValue + "' and StoreID=" + conclass.StoreID + "";
//                    SqlDataAdapter da2 = new SqlDataAdapter(cmd);
//                    da2.Fill(dtCheckAccountBalanceShippingCost);
//                    if (TotalShippingCost > Decimal.Parse(dtCheckAccountBalanceShippingCost.Rows[0]["CurrentBalance"].ToString()))
//                    {
//                        MessageBox.Show("There is no enough amount in the Selected Account for shipping cost");
//                        return;
//                    }
//                    cmd.CommandText = @"insert into FMIS_tblCashAccountsInOutDetail(AccountID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID,StoreID) 
//                        values(" + cmbShippingCostPaymentAccount.SelectedValue + ", " + TotalShippingCost + ", 'Out', 'Shipping Cost', '" + Invoice_No + "', N'Shipping Cost', N'" + conclass.User_ID + "'," + conclass.StoreID + ")";
//                    cmd.ExecuteNonQuery();
//                }
                if (Decimal.Parse(txt_balance.Text) > 0)
                {
                     string Particulars = "Purchase on loan: BillNo:" + txtBillNo.Text;
                     cmd.CommandText = @"insert into FMIS_tblSupplierStatement(ID, SupplierID, StoreID, ReferenceType,ReferenceNumber, Particulars, CurrencyID,ExchangeRate, Debit, Credit, UserID) 
                         values(" + MaxID + "," + cmbSupplier.SelectedValue + "," + conclass.StoreID + ", 'Purchase','" + Invoice_No + "', N'" + Particulars + "'," + cmbCurrency.SelectedValue + "," + txtExchangeRate.Text + ",0," + txt_balance.Text + ", '" + conclass.User_ID + "')";
                    cmd.ExecuteNonQuery();
                }
                foreach (DataGridViewRow gr in dataGridView2.Rows)
                {
                    #region Shipping Calculation
                    Decimal Qty = 0;
                    Decimal Rate = 0;
                    Decimal SalePrice = 0;
                    Decimal Total = 0;
                    Decimal BasCurrencyPrice = 0;
                    Decimal BaseCurrencyChargesPerItem = 0;
                    string ProductCode = "";
                    ProductCode = gr.Cells[1].Value.ToString();
                    string BatchNo = gr.Cells[4].Value.ToString();
                    //string ExpiryDate ="01/"+item.SubItems[5].Text;
                    string ExpiryDate = DateTime.Parse("01/" + gr.Cells[5].Value.ToString()).ToString("dd/MM/yyyy");
                    Qty = Decimal.Parse(gr.Cells[6].Value.ToString());
                    Rate = Decimal.Parse(gr.Cells[7].Value.ToString());
                    SalePrice = Decimal.Parse(gr.Cells[9].Value.ToString());

                    Total = Decimal.Parse(gr.Cells[10].Value.ToString());
                    CostPerItem = 0;
                    BasCurrencyPrice = Math.Round(ToBaseCurrencyPrice(Rate, int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text)), 2);
                    BaseCurrencyChargesPerItem = 0;
                    Decimal New_Rate = 0;
                    New_Rate = BaseCurrencyChargesPerItem + BasCurrencyPrice;
                    #endregion
                    Decimal TotalBasCurrencyPrice = BasCurrencyPrice * Qty;
                    cmd.CommandText = @"insert into IMIS_tblPurchaseOrderDetail(PurchaseOrderNo, ProductCode, PurchasePrice,ShippingCostPerItem, CurrencyID, ExchangeRate, BaseCurrencyPrice, Quantity, Total, BaseCurrencyTotal, Status, 
                        UserID,StoreID,BatchNo,ExpiryDate) values('" + Invoice_No + "', '" + ProductCode + "'," + Rate + "," + CostPerItem + " ," + cmbCurrency.SelectedValue + ", " + txtExchangeRate.Text + ", " + BasCurrencyPrice + ", " + Qty + ", " + Total + ", " + TotalBasCurrencyPrice + ", 'Purchased', N'" + conclass.User_ID + "'," + conclass.StoreID + ",'" + BatchNo + "','" + ExpiryDate + "')";
                    cmd.ExecuteNonQuery();


                    #region Update Sale Price
                    cmd.CommandText = @"update IMIS_tblProduct set SalePrice=" + SalePrice + " where ProductCode='" + ProductCode + "'";
                    cmd.ExecuteNonQuery();
                    #endregion 

                    // #region Stock Update/Insert
                    //DataTable dt_Stock = new DataTable();
                    //cmd.CommandText = @"SELECT ID, ProductCode, ExpiryDate, BatchNo, Quantity, StockPrice FROM   IMIS_tblStock where ProductCode='" + ProductCode + "' and StoreID=" + conclass.StoreID + "";
                    //SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    //da1.Fill(dt_Stock);

                    //--- New Condation for stock Qty and Price

                    #region Stock Update/Insert
                    DataTable dt_Stock = new DataTable();
                    cmd.CommandText = @"SELECT  ID, ProductCode, Quantity, StockPrice,isnull(Quantity,0)*isnull(StockPrice,0) as TotalStockPrice FROM IMIS_tblStock where  ProductCode='" + ProductCode + "' and StoreID=" + conclass.StoreID + "";
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    da1.Fill(dt_Stock);
                    //Condation for item exist in the stock or not
                    if (dt_Stock.Rows.Count > 0)
                    {
                        Decimal New_Qty = 0;
                        Decimal Old_Total = 0;
                        Decimal New_Total = 0;
                        Decimal total_qty = 0;
                        Decimal Avg_Price = 0;
                        New_Qty = Decimal.Parse(gr.Cells[6].Value.ToString());
                        New_Total = New_Qty * New_Rate;
                        Old_Total = Decimal.Parse(dt_Stock.Rows[0]["TotalStockPrice"].ToString());
                        total_qty = Decimal.Parse(dt_Stock.Rows[0]["Quantity"].ToString()) + New_Qty;
                        Avg_Price = Math.Round((New_Total + Old_Total) / total_qty, 2);

                        //-------------Avg Price Condation---
                        cmd.CommandText = @"update IMIS_tblStock set StockPrice=" + Avg_Price + " where ProductCode='" + ProductCode + "' and StoreID=" + conclass.StoreID + "";
                        cmd.ExecuteNonQuery();


                        #region Condation of the for same expiry for qty to update
                        DataTable dtStockEx = new DataTable();
                        cmd.CommandText = @"SELECT        ID, ProductCode, ExpiryDate, BatchNo, Quantity, StockPrice FROM  IMIS_tblStock where ProductCode='" + ProductCode + "'  and StoreID=" + conclass.StoreID + " and cast(convert(varchar(12),ExpiryDate,106) as datetime)=cast(convert(varchar(12),'" + ExpiryDate + "',106) as datetime)";
                        SqlDataAdapter daEx = new SqlDataAdapter(cmd);
                        daEx.Fill(dtStockEx);
                        if (dtStockEx.Rows.Count > 0)
                        {
                            cmd.CommandText = @"update IMIS_tblStock set Quantity=Quantity+" + New_Qty + " where ProductCode='" + ProductCode + "' and StoreID=" + conclass.StoreID + " and cast(convert(varchar(12),ExpiryDate,106) as datetime)=cast(convert(varchar(12),'" + ExpiryDate + "',106) as datetime)";
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd.CommandText = @"insert into IMIS_tblStock(ProductCode, Quantity,StockPrice, ExpiryDate,BatchNo,StoreID) values('" + ProductCode + "', " + Qty + "," + Avg_Price + ",'" + ExpiryDate + "','" + BatchNo + "'," + conclass.StoreID + ")";
                            cmd.ExecuteNonQuery();

                        }
                        #endregion
                    }
                    else
                    {
                        if (obj.con.State == ConnectionState.Closed)
                            obj.con.Open();
                        //only insert logic is here..
                        cmd.CommandText = @"insert into IMIS_tblStock(ProductCode, Quantity,StockPrice, ExpiryDate,BatchNo,StoreID) values('" + ProductCode + "', " + Qty + "," + New_Rate + ",'" + ExpiryDate + "','" + BatchNo + "'," + conclass.StoreID + ")";
                        cmd.ExecuteNonQuery();
                    }
                    //end Condation for item exist in the stock or not
                    #endregion

                    #region Product Statement
                    //string StatementDescription = gr.Cells[1].Value.ToString() + " Qty:" + Qty + " Price: " + Rate;

                    string StatementDescription = "Purchase Invoice :Bill No" + txtBillNo.Text;

                    cmd.CommandText = @"insert into ProductStatement(ID, ProductID, ReferenceType, ReferenceNumber, Particulars, Debit, Credit, UserID) 
                    values(" + ProductStatementID + ", '" + ProductCode + "','Purchase' , '" + Invoice_No + "', '" + StatementDescription + "',0, " + Qty + ",N'" + conclass.User_ID + "')";
                    cmd.ExecuteNonQuery();
                    ProductStatementID++;
                    #endregion
                }
                tran.Commit();
                if (MessageBox.Show("Purchase Save with Invoice# " + Invoice_No + "\r\t Do you want to Print Bill", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    printInvoice(Invoice_No, true);
                }
                
                btnsave.Enabled = false;
               // pnlSubmitOrder.Visible = false;
                //pnlSubmitOrder.SendToBack();
                ClearPurchaseView();
                txtProductSearch.Focus();
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
        private void ClearPurchaseView()
        {
            listProductList.Items.Clear();
            dataGridView2.Rows.Clear();
            txt_balance.Text = "";
            txtGrandTotal.Text = "0";
            txt_paid_amt.Text = "";
            txtTotalShippingCost.Text = "0";
            btnsave.Enabled = true;
            obj.fillcmb(cmbSupplier, "SupplierName", "SupplierID", "SELECT  SupplierID, SupplierName FROM IMIS_tblSupplier  where StoreID=" + conclass.StoreID + "");
            //cmbSupplier.AutoCompleteMode = AutoCompleteMode.Suggest;
            //cmbSupplier.AutoCompleteSource = AutoCompleteSource.ListItems;
            obj.fillcmb(cmbCurrency, "CurrencyName", "CurrencyID", "SELECT CurrencyID, CurrencyName +'-'+ CurrencySymbol CurrencyName FROM   Lookup_tblCurrency");
            obj.fillcmb(cmbCurrencyShippingCost, "CurrencyName", "CurrencyID", "SELECT CurrencyID, CurrencyName +'-'+ CurrencySymbol CurrencyName FROM   Lookup_tblCurrency");
            cmbPaymentMethod.Text = "Cash";
            cmbPaymentMethod_SelectionChangeCommitted(null, null);
            cmbCurrency_SelectionChangeCommitted(null, null);
            txtProductSearch.Text = "";
            txtProductSearch.Focus();
        }

        private void printInvoice(string InvoiceNumber, bool PageSize)
        {
            DataTable dt = new DataTable();
            dt = conclass.GetRecord(@"select * from IMIS_VWPurchaseOrderInvoice where PurchaseOrderNo='" + InvoiceNumber + "'");
            if (PageSize == false)
            {
                Reports.rtpPurchaseOrder obj = new Stock_System.Reports.rtpPurchaseOrder();
                obj.SetDataSource(dt);
                Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
                frm2.crystalReportViewer1.ReportSource = obj;
                //  frm2.crystalReportViewer1.PrintReport();
                frm2.ShowDialog();
            }
            else if (PageSize == true)
            {
                Reports.rtpPurchaseOrder obj = new Stock_System.Reports.rtpPurchaseOrder();
                //Reports.Sale_Invoice_OmerShiq obj = new Stock_System.Reports.Sale_Invoice_OmerShiq();
                obj.SetDataSource(dt);
                Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
                frm2.crystalReportViewer1.ReportSource = obj;
                // frm2.crystalReportViewer1.PrintReport();
                frm2.ShowDialog();
            }
        }
        public string GetOrderNo()
        {
            String VCode = "";
            Int32 ID = 0;
            String Code = "";
            string str_value = "";
            DataTable dtToDayDate = obj.GetData("select replace(convert(varchar, getdate(),103),'/','') as TodayDate");
            string TodayDate = conclass.StoreID + dtToDayDate.Rows[0]["TodayDate"].ToString();
            DataTable dt = obj.GetData(@"select isnull(MAX(right(PurchaseOrderNo,3)),0) as nextid from IMIS_tblPurchaseOrderMain where StoreID=" + conclass.StoreID + " and substring(PurchaseOrderNo,0,10)='" + TodayDate + "'");
            if (dt.Rows.Count > 0)
            {
                str_value = dt.Rows[0]["nextid"].ToString();
                ID = Convert.ToInt32(str_value);
            }
            ID = ID + 1;
            {
                string IDL = ID.ToString();
                string StoreID = conclass.StoreID;
                switch (IDL.Length)
                {
                    case 1:
                        Code = TodayDate + "-" + "00" + ID;
                        break;
                    case 2:
                        Code = TodayDate + "-" + "0" + ID;
                        break;
                    case 3:
                        Code = TodayDate + "-" + ID;
                        break;
                }
                if (Code != string.Empty)
                    VCode = Code;
            }
            return VCode;
        }
        private void GetProductByCode(string Code)
        {
            DataTable dt = new DataTable();
            string Query = @"SELECT        ProductCode, ProductName, PackingName, UnitName, ProductBarCode, SizeName, SalePrice
FROM            IMIS_VWProducts WHERE  ProductCode='" + Code + "'";
            dt = conclass.GetRecord(Query);
            if (dt.Rows.Count > 0)
            {
                this.txtItemCode.Text = dt.Rows[0]["ProductCode"].ToString();
               // GetBatchInformation(dt.Rows[0]["ProductCode"].ToString());
                txtBarCode.Text = dt.Rows[0]["ProductBarCode"].ToString();
                this.txtitemName.Text = dt.Rows[0]["ProductName"].ToString();
                this.txtPackingName.Text = dt.Rows[0]["PackingName"].ToString();
                this.txtSalePrice.Text = dt.Rows[0]["SalePrice"].ToString();

               lblQtyAtStock.Text= GetStockQty(dt.Rows[0]["ProductCode"].ToString());
                lblStockPrice.Text=GetStockPrice(dt.Rows[0]["ProductCode"].ToString());
                


                this.txtQty.Text = string.Empty;
                gpitem_list.Visible = false;
                gpitem_list.SendToBack();
                txtBatchNo.Focus();
            }
        }
        private void GetBatchInformation(string Code)
        {
            DataTable dt = obj.GetData(@"SELECT  BatchNo, SUBSTRING(convert(varchar(12),ExpiryDate,103),4,10) as ExpiryDate,Quantity FROM IMIS_tblStock  where StoreID=" + conclass.StoreID + " and  ProductCode='" + Code + "'");
            lstBatchInformation.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["BatchNo"].ToString());
                item.SubItems.Add(dr["ExpiryDate"].ToString());
                item.SubItems.Add(dr["Quantity"].ToString());
                lstBatchInformation.Items.Add(item);
            }
        
        }
        #endregion
        private void frmpurchase_Shown(object sender, EventArgs e)
        {
            txtProductSearch.Focus();
        }
        private void frmpurchase_Load(object sender, EventArgs e)
        {
          //  //txtinvoice_no.Text = GetOrderNo();
          //  txtBarCode.Focus();
          //  obj.fillcmb(cmbSupplier, "SupplierName", "SupplierID", "SELECT  SupplierID, SupplierName FROM    IMIS_tblSupplier where StoreID=" + conclass.StoreID + " order by SupplierName");
          //  cmbSupplier.Text = "-Supplier-";
          //  //obj.fillcmb(cmbPaymentAccount, "AccountName", "AccountID", "SELECT  AccountID, AccountName FROM FMIS_tblCashAccounts where StoreId="+conclass.StoreID+"");
          //  obj.fillcmb(cmbCurrencyShippingCost, "CurrencyName", "CurrencyID", "SELECT CurrencyID, CurrencyName +'-'+ CurrencySymbol CurrencyName FROM   Lookup_tblCurrency");
          //  obj.fillcmb(cmbCurrency, "CurrencyName", "CurrencyID", "SELECT CurrencyID, CurrencyName +'-'+ CurrencySymbol CurrencyName FROM   Lookup_tblCurrency");
        
          ////  cmbCurrencyShippingCost_SelectionChangeCommitted(null, null);

          //  cmbCurrency_SelectionChangeCommitted(null, null);
          //  cmbPaymentMethod.Text = "Cash";
          //  cmbPaymentMethod_SelectionChangeCommitted(null, null);


            obj.fillcmb(cmbSupplier, "SupplierName", "SupplierID", "SELECT  SupplierID, SupplierName FROM IMIS_tblSupplier  where StoreID=" + conclass.StoreID + "");
            //cmbSupplier.AutoCompleteMode = AutoCompleteMode.Suggest;
            //cmbSupplier.AutoCompleteSource = AutoCompleteSource.ListItems;
            obj.fillcmb(cmbCurrency, "CurrencyName", "CurrencyID", "SELECT CurrencyID, CurrencyName +'-'+ CurrencySymbol CurrencyName FROM   Lookup_tblCurrency");
            obj.fillcmb(cmbCurrencyShippingCost, "CurrencyName", "CurrencyID", "SELECT CurrencyID, CurrencyName +'-'+ CurrencySymbol CurrencyName FROM   Lookup_tblCurrency");
            cmbPaymentMethod.Text = "Cash";
            cmbPaymentMethod_SelectionChangeCommitted(null, null);
            cmbCurrency_SelectionChangeCommitted(null, null);
            //cmbCurrencyShippingCost_SelectionChangeCommitted_1(null, null);
            txtProductSearch.Focus();
            
            
            //  txtExpiryDate.Mask = "00/00/0000";
        }
        private void btnSaveOpeningBalance_Click(object sender, EventArgs e)
        {
            Int64 MaxID = conclass.nextid("FMIS_tblSupplierStatement", "ID");
            obj.con.Open();
            SqlTransaction tran = obj.con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Transaction = tran;
            cmd.Connection = obj.con;
            try
            {
                cmd.CommandText = @"insert into FMIS_tblSupplierStatement(ID, SupplierID, StoreID, ReferenceType, Particulars, CurrencyID,ExchangeRate, Debit, Credit, Balance, UserID) 
                values(" + MaxID + "," + cmbSupplier.SelectedValue + "," + conclass.StoreID + ", 'Opening Balance', N'Opening Balance'," + cmbCurrency.SelectedValue + "," + txtExchangeRate.Text + ",0," + txtOpeningBalance.Text + "," + txtOpeningBalance.Text + ", '" + conclass.User_ID + "')";
                cmd.ExecuteNonQuery();
                tran.Commit();
                txtOpeningBalance.Text = "";
                MessageBox.Show("Saved Successfully..");
                pnlOpeningBalance.SendToBack();
                pnlOpeningBalance.Visible = false;
               
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                #region Search By Item

                if (txtProductSearch.Text != "")
                {
                    DataTable dt = obj.GetData(@"SELECT       ProductCode, ProductName, ProductGenericName, CategoryName, SizeName, PackingName, 
                         ManufacturerName, SalePrice, MRP, Discount, ProductBarCode FROM   IMIS_VWProducts  where ProductName like '" + txtProductSearch.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                    {
                        listProductList.Items.Clear();
                        foreach (DataRow dr in dt.Rows)
                        {
                            ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                            item.SubItems.Add(dr["ProductName"].ToString());
                           
                            item.SubItems.Add(dr["ProductGenericName"].ToString());
                            item.SubItems.Add(dr["CategoryName"].ToString());
                            item.SubItems.Add(dr["SizeName"].ToString());
                            item.SubItems.Add(dr["PackingName"].ToString());
                            item.SubItems.Add(dr["ManufacturerName"].ToString());
                            item.SubItems.Add(dr["SalePrice"].ToString());
                            item.SubItems.Add(dr["ProductBarCode"].ToString());
                            listProductList.Items.Add(item);
                        }
                    }
                }
                #endregion 
            }
            catch (Exception ex)
            { 
            
            
            }
        }

        private string GetStockQty(string ProductCode)
        {
            string Qty = "0";
            DataTable dt = obj.GetData("select isnull(sum(Quantity),0) as Quantity from IMIS_tblStock where ProductCode='" + ProductCode + "'");

            if (dt.Rows.Count > 0)
                Qty = dt.Rows[0]["Quantity"].ToString();
            return Qty;
        }

        private string GetStockPrice(string ProductCode)
        {
            string Qty = "0";
            DataTable dt = obj.GetData("SELECT  top 1   StockPrice FROM  IMIS_tblStock where ProductCode='" + ProductCode + "'");

            if (dt.Rows.Count > 0)
                Qty = dt.Rows[0]["StockPrice"].ToString();
            return Qty;
        }




        private void listProductList_DoubleClick(object sender, EventArgs e)
        {
                 GetProductByCode(listProductList.SelectedItems[0].SubItems[8].Text);
        }

        private void txtProductSearch_KeyDown(object sender, KeyEventArgs e)
        {

//            if (e.KeyCode == Keys.Enter && txtProductSearch.Text != "")
//            {
//                #region Search By Item 
//                DataTable dt = obj.GetData(@"SELECT       ProductCode, ProductName, ProductGenericName, CategoryName, SizeName, PackingName, 
//                         ManufacturerName, SalePrice, MRP, Discount, ProductBarCode FROM   IMIS_VWProducts  where ProductName like '%" + txtProductSearch.Text.Trim() + "%'");
//                if (dt.Rows.Count > 0)
//                {
//                    listProductList.Items.Clear();
//                    foreach (DataRow dr in dt.Rows)
//                    {
//                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
//                        item.SubItems.Add(dr["ProductName"].ToString());
//                        item.SubItems.Add(dr["ProductGenericName"].ToString());
//                        item.SubItems.Add(dr["CategoryName"].ToString());
//                        item.SubItems.Add(dr["SizeName"].ToString());
//                        item.SubItems.Add(dr["PackingName"].ToString());
//                        item.SubItems.Add(dr["ManufacturerName"].ToString());
//                        item.SubItems.Add(dr["SalePrice"].ToString());

//                        item.SubItems.Add(dr["ProductBarCode"].ToString());
//                        item.SubItems.Add(GetStockQty(dr["ProductCode"].ToString()));
//                        listProductList.Items.Add(item);
//                    }
//                }
//                #endregion 
//            }
            
            
            if (e.KeyCode == Keys.Enter && listProductList.Items.Count > 0)
            {
                listProductList.Items[0].Selected = true;
                listProductList.Items[0].EnsureVisible();
                listProductList.Select();
                listProductList.Focus();
            }
        }

        private void listProductList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && listProductList.Items.Count>0)
                GetProductByCode(listProductList.SelectedItems[0].SubItems[0].Text);
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gpitem_list.Visible = true;
                gpitem_list.BringToFront();
                txtProductSearch.Focus();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            gpitem_list.Visible = false ;
            gpitem_list.SendToBack();
            txtBarCode.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool checkDate = CheckDate("01/" + txtExpiryDate.Text);
            MessageBox.Show(checkDate.ToString());
        
        }
        protected bool CheckDate(String date)
        {
            Regex regex = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");
            //Verify whether date entered in dd/MM/yyyy format.
            bool isValid = regex.IsMatch(date);
            //Verify whether entered date is Valid date.
            DateTime dt;
            isValid = DateTime.TryParseExact(date, "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt);
            if (!isValid)
                return false;
            else
                return true;
        }
        private void txtExpiryDate_Leave(object sender, EventArgs e)
        {
            bool checkDate = CheckDate("01/" + txtExpiryDate.Text);
            if (checkDate == false)
            {
                MessageBox.Show("Date is not in correct formate");
                txtExpiryDate.Text = "";
                txtExpiryDate.Focus();
                return;
            }
        }
        private void frmpurchase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && lstBatchInformation.Items.Count > 0)
            {
                pnlBatchNo.Visible = true;
                pnlBatchNo.BringToFront();
                lstBatchInformation.Items[0].Selected = true;
                lstBatchInformation.Items[0].EnsureVisible();
                lstBatchInformation.Select();
                lstBatchInformation.Focus();
            }
            if (e.KeyCode == Keys.F2 && Decimal.Parse(txtGrandTotal.Text) > 0)
                btnsave_Click(null, null);
            if (e.KeyCode == Keys.F5)
                btnPrintInvoice_Click(null, null);
            if (e.KeyCode == Keys.F8)
                btnNewOrder_Click(null, null);
        }
        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtSaleRatePersent.Focus();
        }
        private void lstBatchInformation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBatchNo.Text = lstBatchInformation.SelectedItems[0].SubItems[0].Text;
                txtExpiryDate.Text = lstBatchInformation.SelectedItems[0].SubItems[1].Text;
                pnlBatchNo.Visible = false;
                pnlBatchNo.SendToBack();
                txtQty.Focus();
            }
        }
      
      
        private void txtBatchNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtExpiryDate.Focus();
        }

        private void txtExpiryDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtQty.Focus();
        }

       
        private void rdCash_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCash.Checked)
            {
                cmbShippingCostPaymentAccount.Enabled = true;
                txtExchangeRateShippingCost.Enabled = true;
                cmbCurrencyShippingCost.Enabled = true;
            }
            else
            {
                cmbShippingCostPaymentAccount.Enabled = false;
                txtExchangeRateShippingCost.Enabled = false;
                cmbCurrencyShippingCost.Enabled = false;
            }
        }

        private void rdLoan_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCash.Checked)
            {
                cmbShippingCostPaymentAccount.Enabled = true;
                txtExchangeRateShippingCost.Enabled = true;
                cmbCurrencyShippingCost.Enabled = true;
            }
            else
            {
                cmbShippingCostPaymentAccount.Enabled = false;
                txtExchangeRateShippingCost.Enabled = false;
                cmbCurrencyShippingCost.Enabled = false;
            }
        }

        private void cmbCurrencyShippingCost_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT ID, CurrencyID, ExchangeRate FROM  FMIS_tblCurrencyExchangeRate where ID=(select max(ID) from FMIS_tblCurrencyExchangeRate where StoreID=" + conclass.StoreID + " and  CurrencyID=" + cmbCurrencyShippingCost.SelectedValue + ")");
            if (dt.Rows.Count > 0)
            {
                txtExchangeRateShippingCost.Text = dt.Rows[0]["ExchangeRate"].ToString();
                obj.fillcmb(cmbShippingCostPaymentAccount, "AccountName", "AccountID", "SELECT  AccountID, AccountName FROM FMIS_tblCashAccounts where StoreID=" + conclass.StoreID + " and CurrencyID=" + cmbCurrencyShippingCost.SelectedValue + "");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            pnlBatchNo.Visible = false;
            pnlBatchNo.SendToBack();
            txtBatchNo.Focus();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            pnlSupplier.Visible = false;
            pnlSupplier.SendToBack();
            txtBarCode.Focus();
        }
        private void btnSaveSupplier_Click(object sender, EventArgs e)
        {
            if (btnSaveSupplier.Text == "Save")
            {
                obj.ExecuteQuery(@"insert into IMIS_tblSupplier(SupplierName, SupplierAddress, ContactPerson, ContactEmail, ContactMobileNo, StoreID, UserID) 
                values(N'" + txtSupplierName.Text + "', N'" + txtSupplierAddress.Text + "', '" + txtSupplierContactPerson.Text + "', '" + txtSupplierEmailAddress.Text + "', '" + txtSupplierMobile.Text + "', " + conclass.StoreID + ", N'" + conclass.User_ID + "')");
                MessageBox.Show("Customer Saved Successfully..");
                pnlSupplier.Visible = false;
                pnlSupplier.SendToBack();
                txtBarCode.Focus();
            }
            else
            {
                obj.ExecuteQuery(@"update IMIS_tblSupplier set SupplierName=N'" + txtSupplierName.Text + "',SupplierAddress=N'" + txtSupplierAddress.Text + "',ContactPerson=N'" + txtSupplierContactPerson.Text + "',ContactEmail='" + txtSupplierEmailAddress.Text + "',ContactMobileNo='" + txtSupplierMobile.Text + "' where SupplierID=" + lblSupplierID.Text + "");
                MessageBox.Show("Customer Updated Successfully..");
            }
            FillSupplierSaveView();
            ClearSupplier();
        }
        private void FillSupplierSaveView()
        {
            obj.fillcmb(cmbSupplier, "SupplierName", "SupplierID", "SELECT  SupplierID, SupplierName FROM    IMIS_tblSupplier where StoreID=" + conclass.StoreID + " order by SupplierName");
            DataTable dt = obj.GetData(@"SELECT   SupplierID, SupplierName, SupplierAddress, 
            ContactPerson, ContactEmail, ContactMobileNo, StoreID, UserID, LastUpdateDate
            FROM IMIS_tblSupplier where StoreID=" + conclass.StoreID + " order by SupplierID desc");
            DataTable dt1 = obj.GetData(@"SELECT  top 1 SupplierID FROM IMIS_tblSupplier where StoreID=" + conclass.StoreID + " order by SupplierID desc");
            cmbSupplier.SelectedValue = dt1.Rows[0]["SupplierID"].ToString();
            lstCustomerSaveView.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["SupplierID"].ToString());
                item.SubItems.Add(dr["SupplierName"].ToString());
                item.SubItems.Add(dr["ContactMobileNo"].ToString());
                item.SubItems.Add(dr["SupplierAddress"].ToString());
                item.SubItems.Add(dr["ContactEmail"].ToString());
                lstCustomerSaveView.Items.Add(item);
            }
        }
        private void ClearSupplier()
        {
            txtSupplierMobile.Text = "";
            txtSupplierName.Text = "";
            txtSupplierEmailAddress.Text = "";
            txtSupplierContactPerson.Text = "";
            txtSupplierAddress.Text = "";
            btnSaveSupplier.Text = "Save";
            txtSupplierName.Focus();
        }


        private void btnCancelSupplier_Click(object sender, EventArgs e)
        {
            ClearSupplier();
        }

        private void txtSearchSupplier_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT   SupplierID, SupplierName, SupplierAddress, 
            ContactPerson, ContactEmail, ContactMobileNo, StoreID, UserID, LastUpdateDate
            FROM IMIS_tblSupplier where StoreID=" + conclass.StoreID + " and SupplierName like N'%" + txtSearchSupplier.Text.Trim() + "%' order by SupplierID desc");
            lstSearchSupplier.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["SupplierID"].ToString());
                item.SubItems.Add(dr["SupplierName"].ToString());
                item.SubItems.Add(dr["ContactMobileNo"].ToString());
                item.SubItems.Add(dr["SupplierAddress"].ToString());
                item.SubItems.Add(dr["ContactEmail"].ToString());
                lstSearchSupplier.Items.Add(item);
            }
        }

        private void lstSearchSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = obj.GetData(@"SELECT        SupplierID, SupplierName, SupplierAddress, Country, ContactPerson, ContactEmail, ContactMobileNo
FROM            IMIS_tblSupplier where StoreID=" + conclass.StoreID + " and SupplierID='" + lstSearchSupplier.SelectedItems[0].SubItems[0].Text + "'");
                if (dt.Rows.Count > 0)
                {
                    cmbSupplier.SelectedValue = dt.Rows[0]["SupplierID"].ToString();
                }
                pnlSupplier.SendToBack();
                pnlSupplier.Visible = false;
                txtBarCode.Focus();
            }
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            pnlSupplier.Visible = true;
            pnlSupplier.BringToFront();
            txtSearchSupplier.Focus();
        }

        private void txtSearchSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lstSearchSupplier.Items.Count > 0)
            {
                lstSearchSupplier.Items[0].Selected = true;
                lstSearchSupplier.Items[0].EnsureVisible();
                lstSearchSupplier.Select();
                lstSearchSupplier.Focus();
            }
        }
        private void lstSearchSupplier_DoubleClick(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT        SupplierID, SupplierName, SupplierAddress, Country, ContactPerson, ContactEmail, ContactMobileNo
FROM            IMIS_tblSupplier where StoreID=" + conclass.StoreID + " and SupplierID='" + lstSearchSupplier.SelectedItems[0].SubItems[0].Text + "'");
            if (dt.Rows.Count > 0)
            {
                cmbSupplier.SelectedValue = dt.Rows[0]["SupplierID"].ToString();
            }
            pnlSupplier.SendToBack();
            pnlSupplier.Visible = false;
            txtBarCode.Focus();
        }

        private void txtGrandTotal_TextChanged(object sender, EventArgs e)
        {

        }

        int RecordNo = 1;
        private void AddItemToGridview()
        {
            #region Condation
            if (this.txtBarCode.Text == string.Empty)
            {
                MessageBox.Show("Enter Item Code");
                this.txtBarCode.Focus();
                return;
            }
            else if (this.txtQty.Text == string.Empty)
            {
                MessageBox.Show("Enter Quantity");
                this.txtQty.Focus();
                return;
            }
            else if (this.txtPrice.Text == string.Empty)
            {
                MessageBox.Show("Enter Price");
                this.txtPrice.Focus();
                return;
            }
            else if (Decimal.Parse(txtTotal.Text) == 0)
            {
                MessageBox.Show("Total Must Be More than 0");
                this.txtPrice.Focus();
                return;
            }
            #endregion
            bool status = false;
            Decimal SalePrice = Decimal.Parse(txtPrice.Text);
            if (dataGridView2.Rows.Count > 0)
            {
                // this block is used if record is exist in the grddview
                #region Section to find the same record than no need to insert new record
                String searchValue = txtBarCode.Text;
                Decimal NewQty = Decimal.Parse(txtQty.Text);
                string ExpiryDateValue = txtExpiryDate.Text;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(searchValue) && row.Cells[5].Value.ToString().Equals(ExpiryDateValue))
                    {

                        Decimal SalePrice1 = Decimal.Parse(row.Cells[7].Value.ToString());
                        Decimal CurrQty1 = Decimal.Parse(row.Cells[6].Value.ToString());
                        Decimal TotalQty = CurrQty1 + NewQty;
                        row.Cells[10].Value = SalePrice1 * TotalQty;
                        row.Cells[6].Value = TotalQty;
                        status = true;
                        break;
                    }
                }
                #endregion
                if (status == false)
                {

                    #region Adding Item
                    string[] row = new string[] {RecordNo.ToString(), txtItemCode.Text, txtitemName.Text, txtPackingName.Text, txtBatchNo.Text, txtExpiryDate.Text, txtQty.Text, txtPrice.Text,txtSaleRatePersent.Text,txtSalePrice.Text, txtTotal.Text };
                    dataGridView2.Rows.Add(row);
                    #endregion
                }
            }
            else
            {
                // this block is used for the first time entry
                #region Adding Item
                string[] row = new string[] {RecordNo.ToString(), txtItemCode.Text, txtitemName.Text, txtPackingName.Text, txtBatchNo.Text, txtExpiryDate.Text, txtQty.Text, txtPrice.Text, txtSaleRatePersent.Text, txtSalePrice.Text, txtTotal.Text };
                //dataGridView2.Rows.Insert(row);
                dataGridView2.Rows.Add(row);
                #endregion
            }
            txtGrandTotal.Text = dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString();
            SetSubTotal();
            ClearAddItemsBoxes();
            listProductList.Items.Clear();
            RecordNo++;
            txtProductSearch.Text = "";
            txtProductSearch.Focus();
        }


        private void ClearAddItemsBoxes()
        {
            txtBarCode.Text = "";
            txtitemName.Text = "";
            txtPackingName.Text = "";
            txtBatchNo.Text = "";
            txtExpiryDate.Text = "";
            txtQty.Text = "";
            txtPrice.Text = "";
            txtTotal.Text = "";
            txtItemCode.Text = "";
            txtSalePrice.Text = "";
            txtSaleRatePersent.Text = "";
         
            //listProductList.Items.Clear();
          
        
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            ClearPurchaseView();
        }

        private void btnAdvanceSearh_Click(object sender, EventArgs e)
        {
            gpitem_list.Visible = true;
            gpitem_list.BringToFront();
            txtBarCode.Focus();
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData("select PurchaseOrderNo from IMIS_tblPurchaseOrderMain  where SNO=(select max(SNO) from IMIS_tblPurchaseOrderMain where StoreID=" + conclass.StoreID + " and UserID='" + conclass.User_ID + "')");
            if (dt.Rows.Count > 0)
                txtInvoiceNumberPrint.Text = dt.Rows[0]["PurchaseOrderNo"].ToString();
            pnlPrint.Visible = true;
            pnlPrint.BringToFront();
            txtInvoiceNumberPrint.Focus();
            pnlPrint.Location = new Point(904, 372);
        }

        private void btnClosePrint_Click(object sender, EventArgs e)
        {
            pnlPrint.SendToBack();
            pnlPrint.Visible = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printInvoice(txtInvoiceNumberPrint.Text, true);
            pnlPrint.Visible = false;
            pnlPrint.SendToBack();
        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            txtGrandTotal.Text = dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString();
            SetSubTotal();
            ClearAddItemsBoxes();
            txtProductSearch.Text = "";
            txtProductSearch.Focus();
            
        }

        private void txt_paid_amt_TextChanged(object sender, EventArgs e)
        {
            Decimal NetTotal = 0;
            Decimal ShipingCost = 0;
            Decimal TotalPaid = 0;
            Decimal Balance = 0;
            Decimal GrandTotal = 0;

            if (txtGrandTotal.Text != "")
                GrandTotal = Decimal.Parse(txtGrandTotal.Text);
            if (txt_paid_amt.Text != "")
                TotalPaid = Decimal.Parse(txt_paid_amt.Text);

            //if (cmbPaymentMethod.Text == "Cash and Loan" && TotalPaid == GrandTotal)
            //{
            //    MessageBox.Show("Your Payment amount is equal to total amount, In this case chanage the payment method to cash/bank");
            //    return;
            //}

            Balance = GrandTotal - TotalPaid;
            txt_balance.Text = Balance.ToString();
        }

        private void txtSaleRatePersent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtSalePrice.Text = string.Empty;
                if (txtPrice.Text.Trim() != string.Empty && this.txtSaleRatePersent.Text.Trim() != string.Empty)
                    this.txtSalePrice.Text =(Convert.ToDecimal(this.txtPrice.Text)+(Convert.ToDecimal(this.txtPrice.Text) * Convert.ToDecimal(this.txtSaleRatePersent.Text)) / 100).ToString();
            }
            catch (Exception)
            {

            }
        }
        private void txtSaleRatePersent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtSalePrice.Focus();
        }
        private void txtSalePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            AddItemToGridview();
        }
        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Decimal Qty = 0;
                Decimal Price = 0;
                Decimal Total = 0;
                if (e.ColumnIndex == 6)
                {
                    // if Qty is Chanage-- done
                    Qty = Decimal.Parse(dataGridView2.CurrentRow.Cells[6].Value.ToString());
                    Price = Decimal.Parse(dataGridView2.CurrentRow.Cells[7].Value.ToString());
                    Total = Qty * Price;
                    dataGridView2.CurrentRow.Cells[10].Value = Total;
                }
                if (e.ColumnIndex == 7)
                {
                    Qty = Decimal.Parse(dataGridView2.CurrentRow.Cells[6].Value.ToString());
                    Price = Decimal.Parse(dataGridView2.CurrentRow.Cells[7].Value.ToString());
                    Total = Qty * Price;
                    dataGridView2.CurrentRow.Cells[10].Value = Total;
                }
                txtGrandTotal.Text = dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString();
                SetSubTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }
        }

        private void txtSaleRatePersent_KeyPress(object sender, KeyPressEventArgs e)
        {
            conclass.ASCIn(e);
        }

        private void txtSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            conclass.ASCIn(e);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            conclass.ASCIn(e);
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            AddItemToGridview();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearchSupplierSaveView_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT   SupplierID, SupplierName, SupplierAddress, 
            ContactPerson, ContactEmail, ContactMobileNo, StoreID, UserID, LastUpdateDate
            FROM Supplier where  StoreID=" + conclass.StoreID + " and SupplierName like N'%" + txtSearchSupplierSaveView.Text.Trim() + "%' order by SupplierID desc");
            lstCustomerSaveView.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["SupplierID"].ToString());
                item.SubItems.Add(dr["SupplierName"].ToString());
                item.SubItems.Add(dr["ContactMobileNo"].ToString());
                item.SubItems.Add(dr["SupplierAddress"].ToString());
                item.SubItems.Add(dr["ContactEmail"].ToString());
                lstCustomerSaveView.Items.Add(item);
            }
        }

        private void lstCustomerSaveView_Click(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT   SupplierID, SupplierName, SupplierAddress, 
            ContactPerson, ContactEmail, ContactMobileNo, StoreID, UserID, LastUpdateDate
            FROM Supplier where SupplierID=" + lstCustomerSaveView.SelectedItems[0].SubItems[0].Text + "");
            if (dt.Rows.Count > 0)
            {
                lblSupplierID.Text = dt.Rows[0]["SupplierID"].ToString();
                txtSupplierName.Text = dt.Rows[0]["SupplierName"].ToString();
                txtSupplierMobile.Text = dt.Rows[0]["ContactMobileNo"].ToString();
                txtSupplierAddress.Text = dt.Rows[0]["SupplierAddress"].ToString();
                txtSupplierContactPerson.Text = dt.Rows[0]["ContactPerson"].ToString();
                txtSupplierEmailAddress.Text = dt.Rows[0]["ContactEmail"].ToString();
                btnSaveSupplier.Text = "Update";
                txtSupplierName.Focus();
            }
        }

        private void lstCustomerSaveView_DoubleClick(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT   SupplierID, SupplierName, SupplierAddress, 
            ContactPerson, ContactEmail, ContactMobileNo, StoreID, UserID, LastUpdateDate
            FROM Supplier where SupplierID=" + lstCustomerSaveView.SelectedItems[0].SubItems[0].Text + "");
            if (dt.Rows.Count > 0)
            {
                lblSupplierID.Text = dt.Rows[0]["SupplierID"].ToString();
                txtSupplierName.Text = dt.Rows[0]["SupplierName"].ToString();
                txtSupplierMobile.Text = dt.Rows[0]["ContactMobileNo"].ToString();
                txtSupplierAddress.Text = dt.Rows[0]["SupplierAddress"].ToString();
                txtSupplierContactPerson.Text = dt.Rows[0]["ContactPerson"].ToString();
                txtSupplierEmailAddress.Text = dt.Rows[0]["ContactEmail"].ToString();
                btnSaveSupplier.Text = "Update";
                txtSupplierName.Focus();
            }
        }


        private static Random random = new Random(); // Shared random object with a seed
        private Int64 GenerateOrderNo()
        {
            Int64 newPatientID = -1; // Initialize with a default value
            bool isUnique = false;

            while (!isUnique)
            {
                newPatientID = random.Next(100000, 999999); // Generates a random 6-digit number

                // Check if the generated number already exists in the database
                if (!IsPatientIDExists(newPatientID.ToString()))
                {
                    isUnique = true;
                }
            }

            return newPatientID;
        }
        private bool IsPatientIDExists(string InvoiceNo)
        {
            using (SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["constring"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM IMIS_tblPurchaseOrderMain WHERE PurchaseOrderNo = @PurchaseOrderNo", connection))
                {
                    cmd.Parameters.AddWithValue("@PurchaseOrderNo", InvoiceNo);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
