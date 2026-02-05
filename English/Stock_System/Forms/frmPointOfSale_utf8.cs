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
using Stock_System.Reports;
using System.Net.NetworkInformation;
using System.Drawing.Printing;

namespace Stock_System.Forms
{
    public partial class frmPointOfSale : Telerik.WinControls.UI.RadForm
    {
        Dbcommon obj = new Dbcommon();
        Boolean isButtionPressed = false;

        Boolean PrintA4 = false;
        int InvoiceLanguage = 1;
        public frmPointOfSale()
        {
            InitializeComponent();

        }
        private void InsertCustomerDisplay(Decimal TotalAmount, Decimal TotalDiscount, Decimal NetTotal)
        {
            obj.ExecuteQuery(@"Delete From FMIS_tblCustomerDisplay where MACAddress='" + GetMacAddress().ToString() + "'");
            obj.ExecuteQuery("insert into FMIS_tblCustomerDisplay(TotalAmount, TotalDiscount, NetTotal, MACAddress) values(" + TotalAmount + "," + TotalDiscount + ", " + NetTotal + ", N'" + GetMacAddress().ToString() + "')");
        }
        public static PhysicalAddress GetMacAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress();
                }
            }
            return null;
        }

   

        private void frmPointOfSale_Load(object sender, EventArgs e)
        {
            
            //obj.ExecuteQuery(@"Delete From FMIS_tblCustomerDisplay where MACAddress='" + GetMacAddress().ToString() + "'");
            lblStoreID.Text = conclass.StoreID;
            obj.fillcmb(cmbSaleMan, "SaleManName", "SaleManID", "SELECT        SaleManID, SaleManName FROM IMIS_tblSaleMan where StoreID="+conclass.StoreID+"");
            obj.fillcmb(cmbArea, "AreaName", "AreaCode", @"SELECT   AreaCode, AreaName FROM  lookup_tblAreas");
            CashCustomer();
            LoadSalesSetting();
            //obj.fillcmb(cmbCurrency, "CurrencyName", "CurrencyID", "SELECT CurrencyID, CurrencyName +'-'+ CurrencySymbol CurrencyName FROM   Lookup_tblCurrency");
            #region Currency
            obj.fillcmb(cmbCurrency, "CurrencyName", "CurrencyID", "SELECT CurrencyID, CurrencyName +'-'+ CurrencySymbol CurrencyName FROM   Lookup_tblCurrency");
            DataTable dtCu = obj.GetData("SELECT CurrencyID FROM   Lookup_tblCurrency where IsBaseCurrency='Yes'");
            if (dtCu.Rows.Count > 0)
                cmbCurrency.SelectedValue = dtCu.Rows[0]["CurrencyID"].ToString();
            DataTable dt = obj.GetData(@"SELECT ID, CurrencyID, ExchangeRate FROM  FMIS_tblCurrencyExchangeRate where ID=(select max(ID) from FMIS_tblCurrencyExchangeRate where CurrencyID=" + cmbCurrency.SelectedValue + " and StoreID=" + conclass.StoreID + ")");
            if (dt.Rows.Count > 0)
            {
                txtExchangeRate.Text = dt.Rows[0]["ExchangeRate"].ToString();
                obj.fillcmb(cmbPaymentAccount, "AccountName", "AccountID", "SELECT  AccountID, AccountName FROM FMIS_tblCashAccounts where  CurrencyID=" + cmbCurrency.SelectedValue + " and StoreID=" + conclass.StoreID + "");
            }
            #endregion
            cmbPaymentMethod.Text = "Cash";
            cmbPaymentMethod_SelectionChangeCommitted(null,null);
            txtTotalDisply.Text = "Sub Total: 0.00";
            txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
            txtTotalDisply.Text =txtTotalDisply.Text+ "Total Discount: 0.00";
            txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
            txtTotalDisply.Text = txtTotalDisply.Text + "Net Total: 0.00";
            FillCustomerSaveView();
            this.ActiveControl = txt_item_id;
            txt_item_id.Select();
        }
        private void CashCustomer()
        {
            DataTable dt = obj.GetData(@"SELECT  top 1  CustomerID, CustomerName,CustomerAddress FROM IMIS_tblCustomer where StoreID=" + conclass.StoreID + " order by CustomerID");
            if (dt.Rows.Count > 0)
            {
                lblSaleCustomerID.Tag = dt.Rows[0]["CustomerID"].ToString();
                lblCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
                lblCustomerAddress.Text = dt.Rows[0]["CustomerAddress"].ToString();
              
            }
        }
        #region My New Code
     
        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Decimal Qty = 0;
                Decimal Price = 0;
                Decimal Discount = 0;
                Decimal Total = 0;
                Decimal CurQty = 0;
                if (e.ColumnIndex == 6)
                {
                    // if sales Price Chanage-- done
                    Qty = Decimal.Parse(dataGridView2.CurrentRow.Cells[5].Value.ToString());
                    Decimal SalePrice = Decimal.Parse(dataGridView2.CurrentRow.Cells[6].Value.ToString());
                    Decimal DiscountPercentage = 0;
                    Decimal DiscountValue = Decimal.Parse(dataGridView2.CurrentRow.Cells[8].Value.ToString());
                    DiscountPercentage = Math.Round((DiscountValue * 100) / SalePrice, 2);
                    dataGridView2.CurrentRow.Cells[7].Value = Math.Round(DiscountPercentage, 2);
                    Discount = DiscountValue;
                    Decimal ToBasCurrencyDiscount = ToBaseCurrencyPrice(Discount, int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                    dataGridView2.CurrentRow.Cells[14].Value = Math.Round(ToBasCurrencyDiscount, 2);
                    //This is used to set the bas currency discount value to changed discount during cell edit;
                    CurQty = Decimal.Parse(dataGridView2.CurrentRow.Cells[11].Value.ToString());
                    //if (Qty > CurQty)
                    //{
                    //    MessageBox.Show("Only you have " + CurQty + " Quantity for selected item in the stock");
                    //    dataGridView2.CurrentRow.Cells[5].Value = "1";
                    //    txt_item_id.Focus();
                    //    return;
                    //}
                    dataGridView2.CurrentRow.Cells[15].Value = Math.Round(Discount * Qty, 2);
                    dataGridView2.CurrentRow.Cells[16].Value = Math.Round(ToBasCurrencyDiscount * Qty, 2);
                    dataGridView2.CurrentRow.Cells[8].Value = Math.Round(Discount, 2);
                    dataGridView2.CurrentRow.Cells[10].Value = Math.Round((SalePrice - Discount) * Qty, 2);
                }
                if (e.ColumnIndex == 5)
                {
                    // Quantity
                    Qty = Decimal.Parse(dataGridView2.CurrentRow.Cells[5].Value.ToString());
                    Decimal SalePrice = Decimal.Parse(dataGridView2.CurrentRow.Cells[6].Value.ToString());
                    Decimal DiscountPercentage = 0;
                    Decimal DiscountValue = Decimal.Parse(dataGridView2.CurrentRow.Cells[8].Value.ToString());
                    DiscountPercentage = Math.Round((DiscountValue * 100) / SalePrice, 2);
                    dataGridView2.CurrentRow.Cells[7].Value = Math.Round(DiscountPercentage, 2);
                    Discount = DiscountValue;
                    Decimal ToBasCurrencyDiscount = ToBaseCurrencyPrice(Discount, int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                    dataGridView2.CurrentRow.Cells[14].Value = Math.Round(ToBasCurrencyDiscount, 2);
                    //This is used to set the bas currency discount value to changed discount during cell edit;
                    CurQty = Decimal.Parse(dataGridView2.CurrentRow.Cells[11].Value.ToString());
                    if (Qty > CurQty)
                    {
                        MessageBox.Show("Only you have " + CurQty + " Quantity for selected item in the stock");
                        dataGridView2.CurrentRow.Cells[5].Value = "1";
                        txt_item_id.Focus();
                        return;
                    }
                    dataGridView2.CurrentRow.Cells[15].Value = Math.Round(Discount * Qty, 2);
                    dataGridView2.CurrentRow.Cells[16].Value = Math.Round(ToBasCurrencyDiscount * Qty, 2);
                    dataGridView2.CurrentRow.Cells[8].Value = Math.Round(Discount, 2);
                    dataGridView2.CurrentRow.Cells[10].Value = Math.Round((SalePrice - Discount) * Qty, 2);
                }
                if (e.ColumnIndex == 7)
                {
                    // Discount Column %
                    Qty = Decimal.Parse(dataGridView2.CurrentRow.Cells[5].Value.ToString());
                    Decimal SalePrice = Decimal.Parse(dataGridView2.CurrentRow.Cells[6].Value.ToString());
                    Decimal DiscountPercentage = Decimal.Parse(dataGridView2.CurrentRow.Cells[7].Value.ToString());
                    Decimal DiscountValue = (SalePrice * DiscountPercentage) / 100;
                    Discount = DiscountValue;
                    //This row is for the base currency as bank
                    Decimal ToBasCurrencyDiscount = ToBaseCurrencyPrice(Discount, int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                    dataGridView2.CurrentRow.Cells[14].Value = Math.Round(ToBasCurrencyDiscount, 2);
                    //Set Base Currency Discount
                    // column 10 is the base currency discount column
                    // first check if the currency base currency than one candation and if other than another candation
                    dataGridView2.CurrentRow.Cells[15].Value = Math.Round(Discount * Qty, 2);
                    dataGridView2.CurrentRow.Cells[16].Value = Math.Round(ToBasCurrencyDiscount * Qty, 2);
                    dataGridView2.CurrentRow.Cells[8].Value = Math.Round(Discount, 2);
                    dataGridView2.CurrentRow.Cells[10].Value = Math.Round((SalePrice - Discount) * Qty, 2);
                }
                else if (e.ColumnIndex == 8)
                {
                    // Discount Value
                    Qty = Decimal.Parse(dataGridView2.CurrentRow.Cells[5].Value.ToString());
                    Decimal SalePrice = Decimal.Parse(dataGridView2.CurrentRow.Cells[6].Value.ToString());
                    Decimal DiscountPercentage = 0;
                    Decimal DiscountValue = Decimal.Parse(dataGridView2.CurrentRow.Cells[8].Value.ToString());
                    DiscountPercentage =Math.Round( (DiscountValue * 100) / SalePrice,2);
                    Discount =DiscountValue;
                    dataGridView2.CurrentRow.Cells[7].Value = DiscountPercentage;
                    //This row is for the base currency as bank
                    Decimal ToBasCurrencyDiscount = ToBaseCurrencyPrice(Discount, int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                    dataGridView2.CurrentRow.Cells[14].Value = Math.Round(ToBasCurrencyDiscount, 2);
                    //Set Base Currency Discount
                    // column 10 is the base currency discount column
                    // first check if the currency base currency than one candation and if other than another candation
                    dataGridView2.CurrentRow.Cells[15].Value = Math.Round(Discount * Qty, 2);
                    dataGridView2.CurrentRow.Cells[16].Value = Math.Round(ToBasCurrencyDiscount * Qty, 2);
                    dataGridView2.CurrentRow.Cells[8].Value = Math.Round(Discount, 2);
                    dataGridView2.CurrentRow.Cells[10].Value = Math.Round((SalePrice - Discount) * Qty, 2);
                    //Qty = Decimal.Parse(dataGridView2.CurrentRow.Cells[5].Value.ToString());
                    //Decimal SalePrice = Decimal.Parse(dataGridView2.CurrentRow.Cells[6].Value.ToString());
                    //Decimal DiscountValue = Decimal.Parse(dataGridView2.CurrentRow.Cells[8].Value.ToString());
                    //Discount = DiscountValue;
                    //if (DiscountValue > SalePrice)
                    //{
                    //    MessageBox.Show("Discount value is greater than sale price");
                    //    dataGridView2.CurrentRow.Cells[8].Value = 0;
                    //    return;
                    //}
                    //if (DiscountValue < 0)
                    //{
                    //    MessageBox.Show("Discount value is less than zero");
                    //    dataGridView2.CurrentRow.Cells[8].Value = 0;
                    //    return;
                    //}
                    ////This row is for the base currency as bank
                    //Decimal ToBasCurrencyDiscount = ToBaseCurrencyPrice(Discount, int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                    //dataGridView2.CurrentRow.Cells[13].Value = Math.Round(ToBasCurrencyDiscount, 2);
                    ////Set Base Currency Discount
                    //// column 10 is the base currency discount column
                    //// first check if the currency base currency than one candation and if other than another candation
                    //dataGridView2.CurrentRow.Cells[7].Value = Math.Round(Discount, 2);
                    ////This is for the total discount value
                    //dataGridView2.CurrentRow.Cells[14].Value = Math.Round(Discount * Qty, 2);
                    ////this is for the row total
                    //dataGridView2.CurrentRow.Cells[9].Value = Math.Round(((SalePrice - Discount) * Qty), 2);
                }
                txt_grand_total.Text = dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString();
                Decimal SubTotal = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString());
                Decimal TotalDiscount = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[15].Value.ToString())).ToString());
                txtTotalDisply.Text = "";
                txtTotalDisply.Text = "Sub Total:" + (SubTotal + TotalDiscount);
                txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
                txtTotalDisply.Text = txtTotalDisply.Text + "Total Discount:" + TotalDiscount;
                txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
                txtTotalDisply.Text = txtTotalDisply.Text + "Net Total:" + (SubTotal);
                //InsertCustomerDisplay(SubTotal + TotalDiscount, TotalDiscount, SubTotal);
                SetSubTotal();
                GetTotalGrossProfit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }
        }
        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            txt_grand_total.Text = dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString();
            Decimal SubTotal = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString());
            Decimal TotalDiscount = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[15].Value.ToString())).ToString());
            txtTotalDisply.Text = "";
            txtTotalDisply.Text = "Sub Total:" + (SubTotal + TotalDiscount);
            txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
            txtTotalDisply.Text = txtTotalDisply.Text + "Total Discount:" + TotalDiscount;
            txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
            txtTotalDisply.Text = txtTotalDisply.Text + "Net Total:" + (SubTotal);
            SetSubTotal();
            GetTotalGrossProfit();
            txt_item_id.Text = "";
            txt_item_id.Focus();
        }
        #endregion
        private void printInvoice(string InvoiceNumber, bool PageSize)
        {
            try
            {
                DataTable dt = new DataTable();
                                    dt = conclass.GetRecord(@"SELECT     
    CONVERT(varchar(20), InvoiceNo) AS InvoiceNo,
    CONVERT(varchar(12), SaleOrderDate, 106) AS SaleOrderDate,
    CONVERT(varchar(5), SaleOrderTime, 108) AS SaleOrderTime,
    CustomerName,
    PaymentMethod,
    ProductCode,
    UPPER(ProductName) + ' exp:' + CONVERT(varchar(2), DATEPART(Month, ExpiryDate)) + '/' + CONVERT(varchar(4), DATEPART(Year, ExpiryDate)) AS ProductName,
    Quantity,
    BaseCurrencySalePrice,
    BaseCurrencyTotal,
    CurrencyName,
    StoreID,
    TotalOrderAmount,
    TotalPaidAmount,
    BalanceAmount,
    (SalePrice - Discount) AS SalePrice,
    Discount,
    Total,
    TotalDiscount,
    NetTotal,
    Status,
    StoreName,
    StoreNameLocal,
    Address,
    CAST(BusinessLogo AS VARBINARY(MAX)) AS BusinessLogo,
    ContactNumber1,
    CashReturnToCustomer,
    UserName,
    AddressLocal,
    UnitName,
    CustomerID,
    ExchangeRate,
    TotalBalance
FROM IMIS_VWSaleOrderInvoice
WHERE Status <> 'Full Returned' 
    AND InvoiceNo = '" + InvoiceNumber + @"' 
    AND StoreID = " + conclass.StoreID + @"

UNION

SELECT
    CONVERT(varchar(20), InvoiceNo + 1) AS InvoiceNo,
    '' AS SaleOrderDate,
    '' AS SaleOrderTime,
    '' AS CustomerName,
    '' AS PaymentMethod,
    ProductCode,
    'Ret :' + ProductName AS ProductName,
    -ReturnQuantity AS Quantity,
    '' AS BaseCurrencySalePrice,
    0 AS BaseCurrencyTotal,
    '' AS CurrencyName,
    '' AS StoreID,
    0 AS TotalOrderAmount,
    0 AS TotalPaidAmount,
    0 AS BalanceAmount,
    ReturnAmount AS SalePrice,
    0 AS Discount,
    0 AS Total,
    0 AS TotalDiscount,
    -ReturnAmount AS NetTotal,
    '' AS Status,
    '' AS StoreName,
    '' AS StoreNameLocal,
    '' AS Address,
    CAST(NULL AS VARBINARY(MAX)) AS BusinessLogo,
    NULL AS ContactNumber1,
    0 AS CashReturnToCustomer,
    '' AS UserName,
    '' AS AddressLocal,
    '' AS UnitName,
    0 AS CustomerID,
    1 AS ExchangeRate,
    0 AS TotalBalance
FROM VW_SaleReturnForReceipt
WHERE InvoiceNo = '" + InvoiceNumber + @"' ");



                    if (PageSize == false)
                    {
                        // ُThis will get the current default printer 
                        PrinterSettings settings = new PrinterSettings();
                        //MessageBox.Show(settings.PrinterName);
                        Reports.Sale_Invoice_AlKhairCenter obj = new Stock_System.Reports.Sale_Invoice_AlKhairCenter();
                        obj.SetDataSource(dt);
                        Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
                        //obj.PrintOptions.PrinterName = dtPrinter.Rows[0]["TerminalPrinterName"].ToString();
                        obj.PrintOptions.PrinterName = settings.PrinterName.ToString();
                        obj.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                        //crViewer.ReportSource = vrptSalesInvoice;
                        frm2.crystalReportViewer1.ReportSource = obj;
                       obj.PrintToPrinter(1, false, 0, 0);
                       frm2.ShowDialog();

                    }
                    else if (PageSize == true)
                    {
                        //Reports.rptSaleInvoice obj = new Stock_System.Reports.rptSaleInvoice();
                        //Reports.Sale_Invoice_OmerShiq obj = new Stock_System.Reports.Sale_Invoice_OmerShiq();
                        //obj.SetDataSource(dt);
                        //Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
                        //frm2.crystalReportViewer1.ReportSource = obj;
                        //frm2.crystalReportViewer1.PrintReport();
                        //frm2.ShowDialog();
                    }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }
    
       
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            pnlPayment.Visible = false;
            pnlPayment.Location = new Point(1149, 56);
            panel1.Enabled = true;
            txt_item_id.Focus();
        }
        private void btnClosePrint_Click(object sender, EventArgs e)
        {
            pnlPrint.Visible = false;
            pnlPrint.SendToBack();
            txt_item_id.Focus();
            pnlPrint.Location = new Point(39, 625);
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Boolean PageSize=false;
            if (chkA4Reprint.Checked == true)
                PageSize=true;
            else
                PageSize=false;
            printInvoice(txtInvoiceNumberPrint.Text, PageSize);
            pnlPrint.Visible = false;
            pnlPrint.SendToBack();
            pnlPrint.Location = new Point(39, 625);
            txt_item_id.Focus();
           
        }
        private void cmbPaymentMethod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbPaymentMethod.Text != "Loan")
                cmbPaymentAccount.Enabled = true;
            else
                cmbPaymentAccount.Enabled = false;
            SetSubTotal();
        }
        private Decimal GetCustomerBalanceSummary(string CustomerID)
        {
            Decimal TotalPaid = 0;
            Decimal Value = 0;
            DataTable dt = obj.GetData(@"select isnull(sum(TotalBaseCurrencyBalanceAmount),0) as Balance_Amount from IMIS_tblSaleOrderMain where CustomerID='" + CustomerID + "' and TotalBaseCurrencyBalanceAmount>0");
            if (dt.Rows.Count > 0)
            {
                Value = Decimal.Parse(dt.Rows[0]["Balance_Amount"].ToString());
            }
            DataTable dt2 = obj.GetData("SELECT  isnull(sum(BaseCurrencyReceivedAmount),0) as TotalPaid FROM IMIS_tblReceivedLoanFromCustomer where CustomerID='" + CustomerID + "'");
            if (dt2.Rows.Count > 0)
            {
                TotalPaid = Decimal.Parse(dt2.Rows[0]["TotalPaid"].ToString());

            }
            return  Math.Round(Value - TotalPaid,2);
        }
        private void cmbCurrency_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT ID, CurrencyID, ExchangeRate FROM  FMIS_tblCurrencyExchangeRate where ID=(select max(ID) from FMIS_tblCurrencyExchangeRate where CurrencyID=" + cmbCurrency.SelectedValue + " and StoreID="+conclass.StoreID+")");
            if (dt.Rows.Count > 0)
            {
                txtExchangeRate.Text = dt.Rows[0]["ExchangeRate"].ToString();
                obj.fillcmb(cmbPaymentAccount, "AccountName", "AccountID", "SELECT  AccountID, AccountName FROM FMIS_tblCashAccounts where  CurrencyID=" + cmbCurrency.SelectedValue + " and StoreID="+conclass.StoreID+"");
            }
            ChangeToCurrency();
            SetSubTotal();
        }
        private Decimal ChangeToSelecteCurrency(Decimal Price, int Currency_ID, Decimal ExchangeRate)
        {
            Decimal BasePrice = 0;
            String Operator = "";
            string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            DataTable dt_cr = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT  CurrencyID, CurrencyName,ltrim(rtrim(FromBaseCurrencyOperator)) as  ExchangeOperator, IsBaseCurrency FROM  Lookup_tblCurrency where CurrencyID=" + Currency_ID + "", con);
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
        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            this.txtBalance.Text = string.Empty;
            if (this.txtPaidAmount.Text != string.Empty && this.txtSubTotal.Text.Trim() != string.Empty)
            {
                this.txtBalance.Text = Convert.ToString(Decimal.Parse(this.txtSubTotal.Text) - Decimal.Parse(this.txtPaidAmount.Text));
                if (Decimal.Parse(this.txtBalance.Text) < 0)
                {
                    MessageBox.Show("Your are Amount is out of Range");
                    this.txtBalance.Text = this.txtSubTotal.Text;
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
       
        public void InsertSaleOrder()
        {
            int SalesManID = cmbSaleMan.SelectedValue == null ? 1 : int.Parse(cmbSaleMan.SelectedValue.ToString());
            Decimal SalesManCommission = 0;
            Decimal SalePercentage=0;
            if (lblShowSalesMan.Tag == "1")
            {
                DataTable dtSalesPer = obj.GetData(@"SELECT  isnull(SalePercentage,0) as SalePercentage FROM IMIS_tblSaleMan WHERE SaleManID = " + SalesManID + "");
                if (dtSalesPer.Rows.Count > 0)
                    SalePercentage = Decimal.Parse(dtSalesPer.Rows[0]["SalePercentage"].ToString());
            }
         
            //string InvoiceNo = GetOrderNo();
            string InvoiceNo = GenerateUniquePatientNumber().ToString();

            long MaxID = conclass.nextid("FMIS_tblCustomerStatement", "ID");
            long SalesManStatementID = conclass.nextid("FMIS_tblSalesManStatement", "ID");
            long ProductStatementID = conclass.nextid("ProductStatement", "ID");

            obj.con.Open();
            SqlTransaction tran = obj.con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Transaction = tran;
            cmd.Connection = obj.con;
            try
            {
                Decimal Total_Base_Currency_Amount = ToBaseCurrencyPrice(Decimal.Parse(txt_grand_total.Text), int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                Decimal Total_Base_Currency_Paid_Amount = ToBaseCurrencyPrice(Decimal.Parse(txtPaidAmount.Text), int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                Decimal Total_Base_Currency_Balance_Amount = (Total_Base_Currency_Amount - Total_Base_Currency_Paid_Amount);
                Decimal TotalBalanceAmount = Decimal.Parse(txt_grand_total.Text) - Decimal.Parse(txtPaidAmount.Text);
                cmd.CommandText = @"insert into IMIS_tblSaleOrderMain(InvoiceNo, CustomerID,PaymentMethod, TotalOrderAmount, TotalPaidAmount, BalanceAmount, CurrencyID, ExchangeRate, 
                         TotalBaseCurrencyAmount, TotalBaseCurrencyPaidAmount, TotalBaseCurrencyBalanceAmount, Remarks, Status, UserID,StoreID) 
						 values('" + InvoiceNo + "', '" + lblSaleCustomerID.Tag.ToString() + "','" + cmbPaymentMethod.Text + "', " + txt_grand_total.Text + ", " + txtPaidAmount.Text + ", " + TotalBalanceAmount + ", " + cmbCurrency.SelectedValue + ", " + txtExchangeRate.Text + ", " + Total_Base_Currency_Amount + ", " + Total_Base_Currency_Paid_Amount + ", " + Total_Base_Currency_Balance_Amount + ", null, 'Sold', '" + conclass.User_ID + "',"+conclass.StoreID+")";
                cmd.ExecuteNonQuery();
             
                if (cmbPaymentMethod.Text != "Loan")
                {
                    cmd.CommandText = @"insert into FMIS_tblCashAccountsInOutDetail(AccountID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID,StoreID) values(" + cmbPaymentAccount.SelectedValue + ", " + txtPaidAmount.Text + ", 'In', 'Sales', '" + InvoiceNo + "', N'" + cmbPaymentMethod.Text + "', N'" + conclass.User_ID + "'," + conclass.StoreID + ")";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"update FMIS_tblCashierBalance set TotalCashIn=isnull(TotalCashIn,0)+" + txtPaidAmount.Text + " where UserID='" + conclass.User_ID + "' and ClosingStatus!='Closed' and CurrencyID=" + cmbCurrency.SelectedValue + "";
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
                    Decimal LastCustomerBalance = 0;
                    Decimal TotalCredit = 0;
                    Decimal TotalDebit = 0;
                    Decimal NewCustomerBalance = 0;
                    #region Opening Balance Candation
                    //If opening Balnace is not avialbe than other transaction will not be done
                    cmd.CommandText = "select * from FMIS_tblCustomerStatement where CustomerID=" + lblSaleCustomerID.Tag + " and StoreID=" + conclass.StoreID + " and CurrencyID=" + cmbCurrency.SelectedValue + " and ReferenceType='Opening Balance'";
                    SqlDataAdapter daCheckOpeningBalance = new SqlDataAdapter(cmd);
                    daCheckOpeningBalance.Fill(dtCheckOpeningBalance);
                    if (dtCheckOpeningBalance.Rows.Count > 0)
                    {
                    }
                    else
                    {
                        pnlOpeningBalance.BringToFront();
                        pnlOpeningBalance.Visible = true;
                        pnlOpeningBalance.Location = new Point(343, 265);
                        txtOpeningBalance.Text = "";
                        txtOpeningBalance.Focus();
                        return;
                    }
                    #endregion
                    #region Find Last New Balance
                    //This Query will give the last Balance
                  

                    //This Query will give the Sum Of Credit
                    cmd.CommandText = "select isnull(Sum(Credit),0) As SumOfCredit from FMIS_tblCustomerStatement where CustomerID=" + lblSaleCustomerID.Tag + " and StoreID=" + conclass.StoreID + " and CurrencyID=" + cmbCurrency.SelectedValue + "";
                    SqlDataAdapter daSumOfCredit = new SqlDataAdapter(cmd);
                    daSumOfCredit.Fill(dtSumOfCredit);

                    //This Query will give the Sum Of Debit
                    cmd.CommandText = "select isnull(Sum(Debit),0) As SumOfDebit from FMIS_tblCustomerStatement where CustomerID=" + lblSaleCustomerID.Tag + " and StoreID=" + conclass.StoreID + " and CurrencyID=" + cmbCurrency.SelectedValue + "";
                    SqlDataAdapter daSumOfDebit = new SqlDataAdapter(cmd);
                    daSumOfDebit.Fill(dtSumOfDebit);

                    if ( dtSumOfCredit.Rows.Count > 0 && dtSumOfDebit.Rows.Count > 0)
                    {
                       
                        TotalCredit = Decimal.Parse(dtSumOfCredit.Rows[0]["SumOfCredit"].ToString());
                        TotalDebit = Decimal.Parse(dtSumOfDebit.Rows[0]["SumOfDebit"].ToString()) + Decimal.Parse(txtBalance.Text);
                        //Formula
                        NewCustomerBalance =  TotalDebit - TotalCredit;
                    }
                    #endregion
                    cmd.CommandText = @"insert into FMIS_tblCustomerStatement(ID, CustomerID, StoreID, ReferenceType,ReferenceNumber, Particulars, CurrencyID,ExchangeRate, Debit, Credit, Balance, UserID) 
                values(" + MaxID + "," + lblSaleCustomerID.Tag + "," + conclass.StoreID + ", 'Sales Invoice','" + InvoiceNo + "', N'Sales Invoice'," + cmbCurrency.SelectedValue + "," + txtExchangeRate.Text + "," + txtBalance.Text + ",0," + NewCustomerBalance + ", '" + conclass.User_ID + "')";
                    cmd.ExecuteNonQuery();
                    #endregion
                }
                if (SalePercentage > 0)
                {
                    SalesManCommission =Math.Round(((Total_Base_Currency_Amount * SalePercentage) / 100),2);
                    cmd.CommandText = @"insert into FMIS_tblSalesManStatement(ID, SalesManID, StoreID, ReferenceType,ReferenceNumber, Particulars, Debit, Credit, UserID) 
                         values(" + SalesManStatementID + "," + SalesManID + "," + conclass.StoreID + ", 'Commission','" + InvoiceNo + "', N'Sales Invoice Commission',0," + SalesManCommission + " ,'" + conclass.User_ID + "')";
                    cmd.ExecuteNonQuery();
                }

                foreach (DataGridViewRow gr in dataGridView2.Rows)
                {
                    string ItemCode = "";
                    string BatchNo = "";
                    string ExpiryDate = "";
                    string ProductStockID = "";
                    string iYear = "";
                    string iMonth = "";
                    Decimal Qty = 0;
                    Decimal Discount = 0;
                    Decimal BaseCurrencyDiscount = 0;
                    Decimal SalePrice = 0;
                    Decimal Total = 0;
                    Decimal AvgPrice = 0;
                    Decimal ExchangeRate = 0;
                    Decimal BaseCurrencySalePrice = 0;
                    Decimal TotalBasCurrencyTotal = 0;
                    Decimal BaseCurrencyProfitPerUnit = 0;
                    Decimal TotalBaseCurrencyProfit = 0;
                    Decimal SalesPercentage = 0;
                    int CurrencyID = int.Parse(cmbCurrency.SelectedValue.ToString());
                    try
                    {
                        ItemCode = gr.Cells[0].Value.ToString();
                        Qty = Decimal.Parse(gr.Cells[5].Value.ToString());
                        SalePrice = Decimal.Parse(gr.Cells[6].Value.ToString());
                        BatchNo = gr.Cells[3].Value.ToString();
                        iYear = gr.Cells[18].Value.ToString();
                        iMonth = gr.Cells[19].Value.ToString();
                        //ExpiryDate = DateTime.Parse(gr.Cells[4].Value.ToString()).ToString("dd/MM/yyyy");
                        ExpiryDate = DateTime.Parse("01/" + iMonth + "/" + iYear).ToString("dd/MM/yyyy");
                        ProductStockID = gr.Cells[17].Value.ToString();
                        Discount = Decimal.Parse(gr.Cells[8].Value.ToString());
                        AvgPrice = Decimal.Parse(gr.Cells[9].Value.ToString());
                        Total = Decimal.Parse(gr.Cells[10].Value.ToString());
                        ExchangeRate = Decimal.Parse(txtExchangeRate.Text);
                        BaseCurrencyDiscount = ToBaseCurrencyPrice(Discount, CurrencyID, ExchangeRate);
                        BaseCurrencySalePrice = ToBaseCurrencyPrice(SalePrice, CurrencyID, ExchangeRate);
                        TotalBasCurrencyTotal = (BaseCurrencySalePrice - BaseCurrencyDiscount) * Qty;
                        BaseCurrencyProfitPerUnit = (BaseCurrencySalePrice - BaseCurrencyDiscount) - AvgPrice;
                        TotalBaseCurrencyProfit = BaseCurrencyProfitPerUnit * Qty;
                       
                        //SalesManCommission = SalesManCommission + ((TotalBasCurrencyTotal * SalesPercentage) / 100);
                      
                    }
                    catch (Exception exxx)
                    {
                        MessageBox.Show(exxx.Message.ToString());
                        return;
                    }
                    if (obj.con.State == ConnectionState.Closed)
                        obj.con.Open();
                    cmd.CommandText = @"insert into IMIS_tblSaleOrderDetail(InvoiceNo, ProductCode, BatchNo,ExpiryDate,ProductStockID,Quantity, BaseCurrencyAveragePrice, SalePrice,Discount, CurrencyID, ExchangeRate, BaseCurrencySalePrice,BaseCurrencyDiscount,BaseCurrencyProfitPerUnit, TotalBaseCurrencyProfit, Total, BaseCurrencyTotal, Status,StoreID,SalesManID,SalesPercentage) 
					values('" + InvoiceNo + "', '" + ItemCode + "', '" + BatchNo + "','" + ExpiryDate + "'," + ProductStockID + "," + Qty + ", " + AvgPrice + ", " + SalePrice + "," + Discount + ", " + CurrencyID + ", " + ExchangeRate + ", " + BaseCurrencySalePrice + "," + BaseCurrencyDiscount + "," + BaseCurrencyProfitPerUnit + ", " + TotalBaseCurrencyProfit + ", " + Total + ", " + TotalBasCurrencyTotal + ", 'Sold'," + conclass.StoreID + "," + SalesManID + ", " + SalesPercentage + ")";
                    cmd.ExecuteNonQuery();
                    #region Stock Update
                    cmd.CommandText = @"update IMIS_tblStock set Quantity=Quantity-" + Qty + " where  ID='" + ProductStockID + "'";
                    cmd.ExecuteNonQuery();
                    #endregion

                    #region Product Statement
                    string StatementDescription = "Sale on via bill no:  " + InvoiceNo + " on Customer: " + lblCustomerName.Text;
                    cmd.CommandText = @"insert into ProductStatement( ID, ProductID, ReferenceType, ReferenceNumber, Particulars, Debit, Credit, UserID) 
                            values(" + ProductStatementID + ", '" + ItemCode + "','Sale' , '" + InvoiceNo + "', N'" + StatementDescription + "'," + Qty + ",0,N'" + conclass.User_ID + "')";
                    cmd.ExecuteNonQuery();
                    ProductStatementID++;
                    #endregion
                }
                tran.Commit();
                #region Print 

                if (lblShowPrintalert.Tag.ToString() == "1")
                {
                    #region Yes or No Print
                    if (MessageBox.Show("Invoice Saved Successfully\r\t Do you want to Print", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        Boolean checkStatus = false;
                        if (PrintA4 == true)
                            checkStatus = true;
                        else
                            checkStatus = false;
                        printInvoice(InvoiceNo, checkStatus);
                        pnlPayment.Visible = false;
                        pnlPayment.Location = new Point(1149, 56);
                        panel1.Enabled = true;
                        txt_item_id.Focus();
                        dataGridView2.Rows.Clear();
                        txt_grand_total.Text = "0";
                        txtSubTotal.Text = "";
                        txtPaidAmount.Text = "0";
                        txtBalance.Text = "0";
                        btnSave.Enabled = true;
                        cmbPaymentMethod.Text = "Cash";
                        cmbPaymentMethod_SelectionChangeCommitted(null, null);
                        txtTotalDisply.Text = "";
                        txtTotalDisply.Text = "Sub Total: 0.00";
                        txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
                        txtTotalDisply.Text = txtTotalDisply.Text + "Total Discount: 0.00";
                        txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
                        txtTotalDisply.Text = txtTotalDisply.Text + "Net Total: 0.00";
                        CashCustomer();
                        txt_item_id.Clear();
                        txt_item_id.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Invoice Saved Successfully");
                        pnlPayment.Visible = false;
                        pnlPayment.Location = new Point(1149, 56);
                        panel1.Enabled = true;
                        txt_item_id.Focus();
                        dataGridView2.Rows.Clear();
                        txt_grand_total.Text = "0";
                        txtSubTotal.Text = "";
                        txtPaidAmount.Text = "0";
                        txtBalance.Text = "0";
                        btnSave.Enabled = true;
                        cmbPaymentMethod.Text = "Cash";
                        cmbPaymentMethod_SelectionChangeCommitted(null, null);
                        txtTotalDisply.Text = "";
                        txtTotalDisply.Text = "Sub Total: 0.00";
                        txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
                        txtTotalDisply.Text = txtTotalDisply.Text + "Total Discount: 0.00";
                        txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
                        txtTotalDisply.Text = txtTotalDisply.Text + "Net Total: 0.00";
                        CashCustomer();
                        txt_item_id.Clear();
                        txt_item_id.Focus();
                    }

#endregion 
                }
                else
                {
                    #region Not Show Alert
                    MessageBox.Show("Invoice Saved Successfully");
                    pnlPayment.Visible = false;
                    pnlPayment.Location = new Point(1149, 56);
                    panel1.Enabled = true;
                    txt_item_id.Focus();
                    dataGridView2.Rows.Clear();
                    txt_grand_total.Text = "0";
                    txtSubTotal.Text = "";
                    txtPaidAmount.Text = "0";
                    txtBalance.Text = "0";
                    btnSave.Enabled = true;
                    cmbPaymentMethod.Text = "Cash";
                    cmbPaymentMethod_SelectionChangeCommitted(null, null);
                    txtTotalDisply.Text = "";
                    txtTotalDisply.Text = "Sub Total: 0.00";
                    txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
                    txtTotalDisply.Text = txtTotalDisply.Text + "Total Discount: 0.00";
                    txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
                    txtTotalDisply.Text = txtTotalDisply.Text + "Net Total: 0.00";
                    CashCustomer();
                    txt_item_id.Clear();
                    txt_item_id.Focus();
                    #endregion 
                }
                #endregion
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
        private bool isBaseCurrency(string Currency_ID)
        {
            bool status = false;
            string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            DataTable dt_cr = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT  CurrencyID, CurrencyName, IsBaseCurrency FROM  Lookup_tblCurrency where CurrencyID=" + Currency_ID + "", con);
            da.Fill(dt_cr);
            if (dt_cr.Rows.Count > 0)
            {
                if (dt_cr.Rows[0]["IsBaseCurrency"].ToString() == "Yes")
                {
                    status = true;
                }
            }
            return status; 
        }
        private void ChangeToCurrency()
        {
            Decimal SubTotal = 0;
            Decimal TotalDiscount = 0;
            int CurrencyID = int.Parse(cmbCurrency.SelectedValue.ToString());
            Decimal SalePrice = 0;
            Decimal Total = 0;
            Decimal Qty = 0;
            Decimal Discount = 0;
            Decimal ExchangeRate = 0;
            Decimal BaseCurrencySalePrice = 0;
            Decimal TotalBasCurrencyTotal = 0;
            Decimal BasCurrencyDiscount = 0;
            if (isBaseCurrency(CurrencyID.ToString()))
            {
                foreach (DataGridViewRow gr in dataGridView2.Rows)
                {
                    gr.Cells[6].Value = gr.Cells[13].Value;
                    // change the discount visable colum from bas currency 10 column
                    gr.Cells[8].Value = gr.Cells[14].Value;
                    
                    SalePrice = Decimal.Parse(gr.Cells[6].Value.ToString());
                    Qty = Decimal.Parse(gr.Cells[5].Value.ToString());
                    Discount =Decimal.Parse(gr.Cells[8].Value.ToString());
                    Total = (SalePrice - Discount) * Qty;
                    gr.Cells[10].Value = Math.Round(Total, 2);
                    gr.Cells[15].Value = Math.Round(Discount*Qty, 2);
                }
                TotalDiscount = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[15].Value.ToString())).ToString());
            }
            else
            {
                foreach (DataGridViewRow gr in dataGridView2.Rows)
                {
                    Qty = Decimal.Parse(gr.Cells[5].Value.ToString());
                    gr.Cells[6].Value = gr.Cells[13].Value;
                    SalePrice = Decimal.Parse(gr.Cells[6].Value.ToString());
                  
                    // change the discount visable colum from bas currency 10 column
                    Discount = Decimal.Parse(gr.Cells[14].Value.ToString());

                    ExchangeRate = Decimal.Parse(txtExchangeRate.Text);
                    BaseCurrencySalePrice = Get_Base_Currency_Price(SalePrice, CurrencyID, ExchangeRate);
                    BasCurrencyDiscount = Get_Base_Currency_Price(Discount, CurrencyID, ExchangeRate);
                    TotalBasCurrencyTotal = (BaseCurrencySalePrice - BasCurrencyDiscount) * Qty;
                    gr.Cells[6].Value = Math.Round(BaseCurrencySalePrice, 2);
                    gr.Cells[8].Value = Math.Round(BasCurrencyDiscount, 2);
                    gr.Cells[16].Value = Math.Round(BasCurrencyDiscount*Qty, 2);
                    gr.Cells[10].Value = Math.Round(TotalBasCurrencyTotal, 2);
                }

                TotalDiscount = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[16].Value.ToString())).ToString());
            }
            txt_grand_total.Text = dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString();
            SubTotal = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString());
      
            txtTotalDisply.Text = "";
            txtTotalDisply.Text = "Sub Total:" + (SubTotal + TotalDiscount);
            txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
            txtTotalDisply.Text = txtTotalDisply.Text + "Total Discount:" + TotalDiscount;
            txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
            txtTotalDisply.Text = txtTotalDisply.Text + "Net Total:" + SubTotal;
        }
        private void SetSubTotal()
        {
            if (cmbPaymentMethod.Text == "Loan")
            {
                txtBalance.Text = txt_grand_total.Text;
                txtSubTotal.Text = txt_grand_total.Text;
                txtPaidAmount.Text = "0";
                txtPaidAmount.Enabled = false;
                cmbPaymentAccount.Enabled = false;
            }
            if (cmbPaymentMethod.Text == "Cash and Loan")
            {
                txtBalance.Text = txt_grand_total.Text;
                txtSubTotal.Text = txt_grand_total.Text;
                txtPaidAmount.Text = "0";
                txtPaidAmount.Enabled = true;
                cmbPaymentAccount.Enabled = true;
                txtPaidAmount.Focus();
            }
            else if (cmbPaymentMethod.Text == "Cash")
            {
                txtSubTotal.Text = txt_grand_total.Text;
                txtPaidAmount.Text = txt_grand_total.Text;
                txtPaidAmount.Enabled = false;
                txtBalance.Text = "0";
                cmbPaymentAccount.Enabled = true;
            }
            else if (cmbPaymentMethod.Text == "Bank")
            {
                txtSubTotal.Text = txt_grand_total.Text;
                txtPaidAmount.Text = txt_grand_total.Text;
                txtPaidAmount.Enabled = false;
                txtBalance.Text = "0";
               
            }
        
        }
        private void nUdQty_ValueChanged(object sender, EventArgs e)
        {
            txt_item_id.Focus();
        }
        private void frmPointOfSale_Shown(object sender, EventArgs e)
        {
            txt_item_id.Focus();
        }
        public string GetOrderNo()
        {
            String VCode = "";
            Int32 ID = 0;
            String Code = "";
            string str_value = "";
            //string Month = DateTime.Today.Month.ToString();
            //string Day = DateTime.Today.Day.ToString();
            //if (Day.Length == 1)
            //    Day = "0" + Day;
            //if (Month.Length == 1)
            //    Month = "0" + Month;
           

            DataTable dtToDayDate = obj.GetData("select replace(convert(varchar, getdate(),103),'/','') as TodayDate");
            string TodayDate = conclass.StoreID + dtToDayDate.Rows[0]["TodayDate"].ToString();

           DataTable dt = obj.GetData(@"select isnull(MAX(right(InvoiceNo,3)),0) as nextid from IMIS_tblSaleOrderMain where StoreID="+lblStoreID.Text+" and substring(InvoiceNo,0,10)='" + TodayDate + "'");


            if (dt.Rows.Count > 0)
            {
                str_value = dt.Rows[0]["nextid"].ToString();
                ID = Convert.ToInt32(str_value);
            }
            ID = ID + 1;
            {
                string IDL = ID.ToString();
                string StoreID=conclass.StoreID;
                switch (IDL.Length)
                {
                    case 1:
                        Code =TodayDate + "-" + "00" + ID;
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
        private void PoleDisply(string Value)
        {

            //  SerialPort sp = new SerialPort("com11", 19200, Parity.None,8, StopBits.One);
            SerialPort sp = new SerialPort("com11", 19200);
            sp.BaudRate = 19200;
            if (!sp.IsOpen)
                sp.Open();
           // sp.Write("                    ");
            //sp.Write("-----------------");
            StringBuilder sb = new StringBuilder();
            //sb.Append("....Total Amount....");
            //sb.Append("Total: "+Value+"");
            //string amount = "5600";

            //sb.Append("Total:Amount of Sir1");
            sb.Append("Total:Amount of Sir1");
            sb.Append("........Total.......");
            sb.Append("........50000.......");
            int len = 20 - sb.Length;
            int reminder = len % 2;
            int spaces = len / 2;
            int rightspaces = spaces + reminder;
            int leftspaces = spaces + 1;

            for (int i = 0; i < rightspaces; i++)
            {
                sb.Append(" ");
            }
            for (int j = 0; j < leftspaces; j++)
            {
                sb.Insert(j, " ");
            }
            sp.Write("\n" + sb.ToString());

            ////sp.Write(alltext);
            ////sp.Write(string.Format(""H");
            //byte[] by = System.Text.Encoding.Default.GetBytes(alltext);
            //st.Write(by, 0, by.Length);
            ////sp.WriteLine(alltext);
            if (sp.IsOpen)
                sp.Close();
        
        
        }
       
        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
           // GetOrderNo();
            txt_grand_total.Text = "0";
            btnSave.Enabled = true;
            CashCustomer();
            txt_grand_total.Text = "0";
            txtSubTotal.Text = "";
            txtPaidAmount.Text = "0";
            txtBalance.Text = "0";
            txt_item_id.Text = "";
            txt_item_id.Focus();
        }
        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData("select InvoiceNo from IMIS_tblSaleOrderMain  where SNO=(select max(SNO) from IMIS_tblSaleOrderMain where StoreID=" + lblStoreID.Text + " and UserID='" + conclass.User_ID + "')");
            if (dt.Rows.Count > 0)
                txtInvoiceNumberPrint.Text = dt.Rows[0]["InvoiceNo"].ToString();

            pnlPrint.Visible = true;
            pnlPrint.BringToFront();
            txtInvoiceNumberPrint.Focus();
            pnlPrint.Location = new Point(39, 439);
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            pnlCustomer.Visible = true;
            pnlCustomer.BringToFront();
            txtSearchCustomerView.Focus();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            pnlCustomer.Visible = false;
            pnlCustomer.SendToBack();
            txt_item_id.Focus();

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
        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (btnSaveCustomer.Text == "Save")
            {
                obj.ExecuteQuery(@"insert into IMIS_tblCustomer(CustomerName, MobileNumber, EmailAddress, ContactPerson, CustomerAddress, UserID, StoreID,AreaCode) values(N'" + txtCustomerName.Text + "', N'" + txtCustomerMobile.Text + "', '" + txtCustomerEmailAddress.Text + "', '" + txtCustomerContactPerson.Text + "', N'" + txtCustomerAddress.Text + "', N'" + conclass.User_ID + "', " + conclass.StoreID + ","+cmbArea.SelectedValue+")");
                MessageBox.Show("Customer Saved Successfully..");
                MaxCustomer();
            }
            else
            {
                obj.ExecuteQuery(@"update IMIS_tblCustomer set CustomerName=N'" + txtCustomerName.Text + "', MobileNumber=N'" + txtCustomerMobile.Text + "', EmailAddress='" + txtCustomerEmailAddress.Text + "', ContactPerson=N'" + txtCustomerContactPerson.Text + "', CustomerAddress=N'" + txtCustomerAddress.Text + "', LastUpdatedBy=N'" + conclass.User_ID + "',LastUpdateDate=getdate(),AreaCode="+cmbArea.SelectedValue+" where CustomerID=" + lblCustomerID.Text + "");
                MessageBox.Show("Customer Updated Successfully..");
            }
            FillCustomerSaveView();
            ClearCustomer();
        }

        private void MaxCustomer()
        {
            DataTable dt = obj.GetData(@"SELECT   top 1  CustomerID, CustomerName,CustomerAddress FROM IMIS_tblCustomer where StoreID=" + conclass.StoreID + " order by CustomerID desc");
            lblSaleCustomerID.Tag = dt.Rows[0]["CustomerID"].ToString();
            lblCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
            pnlCustomer.SendToBack();
            pnlCustomer.Visible = false;
            txt_item_id.Focus();

        }
        private void txtSearchCustomerSaveView_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT        IMIS_tblCustomer.CustomerID, IMIS_tblCustomer.CustomerName, IMIS_tblCustomer.MobileNumber, IMIS_tblCustomer.EmailAddress, IMIS_tblCustomer.ContactPerson, IMIS_tblCustomer.CustomerAddress, 
                         IMIS_tblCustomer.UserID, IMIS_tblCustomer.StoreID, IMIS_tblCustomer.SystemDate, IMIS_tblCustomer.LastUpdatedBy, IMIS_tblCustomer.LastUpdateDate, IMIS_tblCustomer.AreaCode, lookup_tblAreas.AreaName
FROM            IMIS_tblCustomer INNER JOIN
                         lookup_tblAreas ON IMIS_tblCustomer.AreaCode = lookup_tblAreas.AreaCode where StoreID=" + conclass.StoreID + " and CustomerName like N'%" + txtSearchCustomerSaveView.Text.Trim() + "%'");
              lstCustomerSaveView.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["CustomerID"].ToString());
                item.SubItems.Add(dr["CustomerName"].ToString());
                item.SubItems.Add(dr["AreaName"].ToString());
                item.SubItems.Add(dr["CustomerAddress"].ToString());
                item.SubItems.Add(dr["MobileNumber"].ToString());
                item.SubItems.Add(dr["EmailAddress"].ToString());
                lstCustomerSaveView.Items.Add(item);
            }
        }
        private void txtSearchCustomerView_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT        IMIS_tblCustomer.CustomerID, IMIS_tblCustomer.CustomerName, IMIS_tblCustomer.MobileNumber, IMIS_tblCustomer.EmailAddress, IMIS_tblCustomer.ContactPerson, IMIS_tblCustomer.CustomerAddress, 
                         IMIS_tblCustomer.UserID, IMIS_tblCustomer.StoreID, IMIS_tblCustomer.SystemDate, IMIS_tblCustomer.LastUpdatedBy, IMIS_tblCustomer.LastUpdateDate, IMIS_tblCustomer.AreaCode, lookup_tblAreas.AreaName
FROM            IMIS_tblCustomer INNER JOIN
                         lookup_tblAreas ON IMIS_tblCustomer.AreaCode = lookup_tblAreas.AreaCode where StoreID=" + conclass.StoreID + " and CustomerName like N'%" + txtSearchCustomerView.Text.Trim() + "%'");
            lstCustomerSearchView.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["CustomerID"].ToString());
                item.SubItems.Add(dr["CustomerName"].ToString());
                item.SubItems.Add(dr["MobileNumber"].ToString());
                item.SubItems.Add(dr["AreaName"].ToString());
                item.SubItems.Add(dr["CustomerAddress"].ToString());
                item.SubItems.Add(dr["EmailAddress"].ToString());
                lstCustomerSearchView.Items.Add(item);
            }
        }
        private void FillCustomerSaveView()
        {
            DataTable dt = obj.GetData(@"SELECT    top 50    IMIS_tblCustomer.CustomerID, IMIS_tblCustomer.CustomerName, IMIS_tblCustomer.MobileNumber, IMIS_tblCustomer.EmailAddress, IMIS_tblCustomer.ContactPerson, IMIS_tblCustomer.CustomerAddress, 
                         IMIS_tblCustomer.UserID, IMIS_tblCustomer.StoreID, IMIS_tblCustomer.SystemDate, IMIS_tblCustomer.LastUpdatedBy, IMIS_tblCustomer.LastUpdateDate, IMIS_tblCustomer.AreaCode, lookup_tblAreas.AreaName
FROM            IMIS_tblCustomer INNER JOIN
                         lookup_tblAreas ON IMIS_tblCustomer.AreaCode = lookup_tblAreas.AreaCode where StoreID=" + conclass.StoreID + " order by CustomerID desc");
            lstCustomerSaveView.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["CustomerID"].ToString());
                item.SubItems.Add(dr["CustomerName"].ToString());
                item.SubItems.Add(dr["AreaName"].ToString());
                item.SubItems.Add(dr["CustomerAddress"].ToString());
                item.SubItems.Add(dr["MobileNumber"].ToString());
                item.SubItems.Add(dr["EmailAddress"].ToString());
                lstCustomerSaveView.Items.Add(item);
            }
        }
        private void lstCustomerSaveView_Click(object sender, EventArgs e)
        {
            string Id = lstCustomerSaveView.SelectedItems[0].SubItems[0].Text;
            DataTable dt = obj.GetData(@"SELECT        CustomerID, CustomerName, MobileNumber, EmailAddress, ContactPerson, CustomerAddress,AreaCode
FROM            IMIS_tblCustomer where CustomerID=" +Id+"");
            txtCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
            lblCustomerID.Text = dt.Rows[0]["CustomerID"].ToString();
            txtCustomerMobile.Text = dt.Rows[0]["MobileNumber"].ToString();
            txtCustomerEmailAddress.Text = dt.Rows[0]["EmailAddress"].ToString();
            txtCustomerContactPerson.Text = dt.Rows[0]["ContactPerson"].ToString();
            txtCustomerAddress.Text = dt.Rows[0]["CustomerAddress"].ToString();
            cmbArea.SelectedValue = dt.Rows[0]["AreaCode"].ToString();
            btnSaveCustomer.Text = "Update";
        }
        private void btnCancelCustomer_Click(object sender, EventArgs e)
        {
            FillCustomerSaveView();
            ClearCustomer();
        }
        private void lstCustomerSearchView_DoubleClick(object sender, EventArgs e)
        {
            string Id = lstCustomerSearchView.SelectedItems[0].SubItems[0].Text;
            DataTable dt = obj.GetData(@"SELECT    CustomerID, CustomerName,CustomerAddress FROM IMIS_tblCustomer where CustomerID=" + Id + "");
            lblSaleCustomerID.Tag = dt.Rows[0]["CustomerID"].ToString();
            lblCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
            lblCustomerAddress.Text = dt.Rows[0]["CustomerAddress"].ToString();
          
            pnlCustomer.SendToBack();
            pnlCustomer.Visible = false;
            txt_item_id.Focus();
        }
        private void lstCustomerSearchView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string Id = lstCustomerSearchView.SelectedItems[0].SubItems[0].Text;
                    DataTable dt = obj.GetData(@"SELECT    CustomerID, CustomerName,CustomerAddress FROM IMIS_tblCustomer where CustomerID=" + Id + "");
                    lblSaleCustomerID.Tag = dt.Rows[0]["CustomerID"].ToString();
                    lblCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
                    lblCustomerAddress.Text = dt.Rows[0]["CustomerAddress"].ToString();
                    pnlCustomer.SendToBack();
                    pnlCustomer.Visible = false;
                    txt_item_id.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chose Customer From the list");
            }
        }
        private void btnCloseOpeningBalance_Click(object sender, EventArgs e)
        {
            pnlOpeningBalance.Location = new Point(543, 621);
            pnlOpeningBalance.SendToBack();
            pnlOpeningBalance.Visible = false;
        }
        private void btnSaveOpeningBalance_Click(object sender, EventArgs e)
        {
            Int64 MaxID = conclass.nextid("FMIS_tblCustomerStatement", "ID");
            obj.con.Open();
            SqlTransaction tran = obj.con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Transaction = tran;
            cmd.Connection = obj.con;
            try
            {
                cmd.CommandText = @"insert into FMIS_tblCustomerStatement(ID, CustomerID, StoreID, ReferenceType, Particulars, CurrencyID,ExchangeRate, Debit, Credit, Balance, UserID) 
                values(" + MaxID + "," + lblSaleCustomerID.Tag + "," + conclass.StoreID + ", 'Opening Balance', N'Opening Balance'," + cmbCurrency.SelectedValue + "," + txtExchangeRate.Text + "," + txtOpeningBalance.Text + ",0," + txtOpeningBalance.Text + ", '" + conclass.User_ID + "')";
                cmd.ExecuteNonQuery();
                tran.Commit();
                txtOpeningBalance.Text = "";
                MessageBox.Show("Saved Successfully..");
                pnlOpeningBalance.Location = new Point(543, 621);
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
        //private void frmPointOfSale_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //   // txt_item_id.Focus();
        //}
      
        #region Number Buttions
        private void btnTwo_Click(object sender, EventArgs e)
        {
            if (isButtionPressed)
                txtQty.Text = txtQty.Text + "2";
            else
            {
                txtQty.Text = "2";
                isButtionPressed = true;
            }
            txt_item_id.Text = "";
            txt_item_id.Focus();
        }
        private void btnThree_Click(object sender, EventArgs e)
        {
            if (isButtionPressed)
                txtQty.Text = txtQty.Text + "3";
            else
            {
                txtQty.Text = "3";
                isButtionPressed = true;
            }
                txt_item_id.Text = "";
            txt_item_id.Focus();
        }
        private void btnFoure_Click(object sender, EventArgs e)
        {
            if (isButtionPressed)
                txtQty.Text = txtQty.Text + "4";
            else
            {
                txtQty.Text = "4";
                isButtionPressed = true;
            }
            txt_item_id.Text = "";
            txt_item_id.Focus();
        }
        private void btnFive_Click(object sender, EventArgs e)
        {
            if (isButtionPressed)
                txtQty.Text = txtQty.Text + "5";
            else
            {
                txtQty.Text = "5";
                isButtionPressed = true;
            }
            txt_item_id.Text = "";
            txt_item_id.Focus();
        }
        private void btnSix_Click(object sender, EventArgs e)
        {
            if (isButtionPressed)
                txtQty.Text = txtQty.Text + "6";
            else
            {
                txtQty.Text = "6";
                isButtionPressed = true;
            }
            txt_item_id.Text = "";
            txt_item_id.Focus();
        }
        private void btnSeven_Click(object sender, EventArgs e)
        {
            if (isButtionPressed)
                txtQty.Text = txtQty.Text + "7";
            else
            {
                txtQty.Text = "7";
                isButtionPressed = true;
            }
            txt_item_id.Text = "";
            txt_item_id.Focus();
        }
        private void btnEight_Click(object sender, EventArgs e)
        {
            if (isButtionPressed)
                txtQty.Text = txtQty.Text + "8";
            else
            {
                txtQty.Text = "8";
                isButtionPressed = true;
            }
            txt_item_id.Text = "";
            txt_item_id.Focus();
        }
        private void btnNin_Click(object sender, EventArgs e)
        {
            if (isButtionPressed)
                txtQty.Text = txtQty.Text + "9";
            else
            {
                txtQty.Text = "9";
                isButtionPressed = true;
            }
            txt_item_id.Text = "";
            txt_item_id.Focus();
        }
        private void btnClearQty_Click(object sender, EventArgs e)
        {
            isButtionPressed = false;
            txt_item_id.Text = "";
            txtQty.Text = "1";
            txt_item_id.Focus();

        }
        private void btnZero_Click(object sender, EventArgs e)
        {
            if (isButtionPressed)
                txtQty.Text = txtQty.Text + "0";
            else
            {
                txtQty.Text = "0";
                isButtionPressed = true;
            }
            txt_item_id.Focus();
        }
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (isButtionPressed)
                txtQty.Text = txtQty.Text + ".";
            txt_item_id.Focus();
        }
        private void btnOne_Click(object sender, EventArgs e)
        {
            if (isButtionPressed)
                txtQty.Text = txtQty.Text + "1";
            else
            {
                txtQty.Text = "1";
                isButtionPressed = true;
            }
            txt_item_id.Text = "";
            txt_item_id.Focus();
        }
        #endregion
     
        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
        private void frmPointOfSale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
            {
                pnlCustomer.Visible = true;
                pnlCustomer.BringToFront();
                txtSearchCustomerView.Focus();
            }

            if (e.KeyCode == Keys.F3)
            {
                gpitem_list.Visible = true;
                gpitem_list.BringToFront();
                txtProductSearch.Focus();
            }
            else if (e.KeyCode == Keys.F5)
            {
                DataTable dt = obj.GetData("select InvoiceNo from IMIS_tblSaleOrderMain  where SNO=(select max(SNO) from IMIS_tblSaleOrderMain where StoreID=" + lblStoreID.Text + " and UserID='" + conclass.User_ID + "')");
                if (dt.Rows.Count > 0)
                    txtInvoiceNumberPrint.Text = dt.Rows[0]["InvoiceNo"].ToString();

                pnlPrint.Visible = true;
                pnlPrint.BringToFront();
                txtInvoiceNumberPrint.Focus();
                pnlPrint.Location = new Point(834, 324);
            }
            else if (e.KeyCode == Keys.F4)
            {
                pnlDiscount.Visible = true;
                pnlDiscount.BringToFront();
                pnlDiscount.Location = new Point(877, 67);
                txtDiscountPercentage.Focus();
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnSubmit_Click(null, null);
            }
            else if (e.KeyCode == Keys.F8)
            {
                dataGridView2.Rows.Clear();
                // GetOrderNo();
                txt_grand_total.Text = "0";
                btnSave.Enabled = true;
                CashCustomer();
                txt_item_id.Text = "";
                txt_item_id.Focus();
            }
            //else if (e.KeyCode == Keys.Enter && pnlPayment.Visible == false)
            //{
            //    txt_item_id.Text = "";
            //    txt_item_id.Focus();
            //}
            else if (pnlPayment.Visible == true && e.KeyCode == Keys.Enter)
            {
                btnSave_Click(null, null);
            }
            //try
            //{
            //    int aski = e.KeyChar;
            //    if (aski == 9)
            //    {
            //        gpitem_list.Visible = true;
            //        gpitem_list.BringToFront();
            //        txt_item_search.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private void btnSetDiscount_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow gr in dataGridView2.Rows)
            {
                //Decimal Qty = Decimal.Parse(gr.Cells[2].Value.ToString());
                //Decimal SalePrice = Decimal.Parse(gr.Cells[3].Value.ToString());
                //gr.Cells[7].Value = SalePrice * Qty;
                Decimal Qty = Decimal.Parse(gr.Cells[5].Value.ToString());
                Decimal SalePrice = Decimal.Parse(gr.Cells[6].Value.ToString());
                gr.Cells[10].Value = SalePrice * Qty;
            }
            #region Refresh Sub Total
            //txt_grand_total.Text = dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString();
            //SubTotal = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString());
            //TotalDiscount = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[15].Value.ToString())).ToString());
            //txtTotalDisply.Text = "";
            //txtTotalDisply.Text = "Sub Total:" + (SubTotal + TotalDiscount);
            //txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
            //txtTotalDisply.Text = txtTotalDisply.Text + "Total Discount:" + TotalDiscount;
            //txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
            //txtTotalDisply.Text = txtTotalDisply.Text + "Net Total:" + (SubTotal);
            ////InsertCustomerDisplay(SubTotal + TotalDiscount, TotalDiscount, SubTotal);
            #endregion
            if (rdPercentage.Checked)
            {
                foreach (DataGridViewRow gr in dataGridView2.Rows)
                {
                    //gr.Cells[10].Value = 0;
                    //gr.Cells[4].Value = 0;
                    Decimal Qty = Decimal.Parse(gr.Cells[5].Value.ToString());
                    Decimal SalePrice = Decimal.Parse(gr.Cells[6].Value.ToString());
                    Decimal DiscountPercentage = Decimal.Parse(txtDiscountPercentage.Text);
                    Decimal DiscountValue = (SalePrice * DiscountPercentage) / 100;
                    //This row is for the base currency as bank
                    Decimal ToBasCurrencyDiscount = ToBaseCurrencyPrice(DiscountValue, int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                    gr.Cells[14].Value = Math.Round(ToBasCurrencyDiscount, 2);
                    //Set Base Currency Discount
                    // column 10 is the base currency discount column
                    // first check if the currency base currency than one candation and if other than another candation
                    gr.Cells[7].Value = Math.Round(DiscountPercentage, 2);
                    gr.Cells[8].Value = Math.Round(DiscountValue, 2);
                    gr.Cells[10].Value = Math.Round((SalePrice - DiscountValue) * Qty, 2);
                    gr.Cells[15].Value = Math.Round(DiscountValue * Qty, 2);
                    gr.Cells[16].Value = Math.Round(ToBasCurrencyDiscount * Qty, 2);
                }
            }
            else
            {
                // how to find % tage if we find the value
                foreach (DataGridViewRow gr in dataGridView2.Rows)
                {
                    Decimal Qty = Decimal.Parse(gr.Cells[5].Value.ToString());
                    Decimal SalePrice = Decimal.Parse(gr.Cells[6].Value.ToString());
                    // This means the total value to be deducted from bill 
                    Decimal DiscountValue = Decimal.Parse(txtDiscountPercentage.Text);
                    Decimal DiscountRate = 0;
                    Decimal GrandTotal = Decimal.Parse(txt_grand_total.Text);
                    DiscountRate = DiscountValue / GrandTotal;
                    //Decimal Discount = DistributeDiscountPerItem(SalePrice, DiscountValue, Decimal.Parse(txt_grand_total.Text));
                    //This row is for the base currency as bank
                    Decimal ToBasCurrencyDiscount = ToBaseCurrencyPrice((DiscountRate * SalePrice), int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                    gr.Cells[14].Value = Math.Round(ToBasCurrencyDiscount, 2);
                   
                    gr.Cells[15].Value = Math.Round((DiscountRate * SalePrice) * Qty, 2);
                    gr.Cells[16].Value = Math.Round(ToBasCurrencyDiscount * Qty, 2);
                    // how to find disocunt % this issue was find by karim zai store kabul
                    Decimal DiscountPercentage = ((DiscountRate * SalePrice) * 100) / SalePrice;
                    gr.Cells[7].Value = Math.Round(DiscountPercentage, 2);
                    //gr.Cells[4].Value = Math.Round((DiscountRate * SalePrice), 2);
                    gr.Cells[8].Value = Math.Round((DiscountRate * SalePrice), 2);
                    gr.Cells[10].Value = Math.Round((SalePrice - (DiscountRate * SalePrice)) * Qty, 2);
                    //100*Discount Value/total value
                    //=100*50/1000
                    // we will work on this to find the issue and slow the issue
                }
            }
            txt_grand_total.Text = dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString();
            Decimal SubTotal = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString());
            Decimal TotalDiscount = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[15].Value.ToString())).ToString());
            txtTotalDisply.Text = "";
            txtTotalDisply.Text = "Sub Total:" + (SubTotal + TotalDiscount);
            txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
            txtTotalDisply.Text = txtTotalDisply.Text + "Total Discount:" + TotalDiscount;
            txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
            txtTotalDisply.Text = txtTotalDisply.Text + "Net Total:" + (SubTotal);
            //InsertCustomerDisplay(SubTotal + TotalDiscount, TotalDiscount, SubTotal);
            SetSubTotal();
            GetTotalGrossProfit();
            pnlDiscount.Visible = false;
            pnlDiscount.SendToBack();
            txt_item_id.Focus();
        }
        private void btnDiscount_Click(object sender, EventArgs e)
        {
            pnlDiscount.Visible = true;
            pnlDiscount.BringToFront();
            pnlDiscount.Location = new Point(450, 350);
            txtDiscountPercentage.Focus();
        }
        private void btnCloseDiscount_Click(object sender, EventArgs e)
        {
            pnlDiscount.Visible = false;
            pnlDiscount.SendToBack();
            txt_item_id.Focus();
        }
        private Decimal DistributeDiscountPerItem (Decimal Price, Decimal TotalDiscountValue, Decimal GrandTotal)
        {
            Decimal Charges = 0;
            if (TotalDiscountValue > 0)
                Charges = Price * TotalDiscountValue / GrandTotal;
            else
                Charges = 0;
            return Charges;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(GetOrderNo().ToString());
        }
        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnAdvanceSearh_Click(object sender, EventArgs e)
        {
            gpitem_list.Visible = true;
            gpitem_list.BringToFront();
            txtProductSearch.Focus();
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            gpitem_list.SendToBack();
            gpitem_list.Visible = false;
            txt_item_id.Focus();
        }
        private void txtProductSearch_KeyDown(object sender, KeyEventArgs e)
        {
            
                DataTable dtSalePrice = Class.conclass.GetRecord(@"SELECT   UserID, Value FROM   tblDefaultSalePrice where UserID in('"+ conclass.User_ID+"')");
                Decimal SalePricePersentage=0;
                Decimal NewSalePrice = 0;
                if (dtSalePrice.Rows.Count > 0)
                    SalePricePersentage = Decimal.Parse(dtSalePrice.Rows[0]["Value"].ToString());

            




            if (e.KeyCode == Keys.Enter && txtProductSearch.Text != "")
            {
                #region product Search
                try
                {
                    listProductList.Items.Clear();
                    DataTable dt = new DataTable();

                    dt = Class.conclass.GetRecord(@"SELECT        IMIS_VWProducts.ProductName, IMIS_VWProducts.ManufacturerName, IMIS_VWProducts.CategoryName, IMIS_VWProducts.SizeName, IMIS_VWProducts.PackingName, IMIS_VWProducts.ManufacturerName, 
                         IMIS_VWProducts.SalePrice, CONVERT(varchar(12), IMIS_tblStock.ExpiryDate, 106) AS ExpiryDate, IMIS_tblStock.BatchNo, IMIS_tblStock.Quantity, IMIS_tblStock.StockPrice, IMIS_tblStock.StoreID, 
                         IMIS_VWProducts.ProductBarCode, IMIS_tblStock.ID as StockID
FROM            IMIS_VWProducts INNER JOIN
                         IMIS_tblStock ON IMIS_VWProducts.ProductCode = IMIS_tblStock.ProductCode
WHERE      IMIS_tblStock.ExpiryDate> GETDATE() and  IMIS_VWProducts.ProductName like N'%" + txtProductSearch.Text.Trim() + "%' and     IMIS_tblStock.StoreID = " + conclass.StoreID + " and  IMIS_tblStock.Quantity>0  order by IMIS_tblStock.ProductCode,CONVERT(datetime, IMIS_tblStock.ExpiryDate, 103) asc");


//dt = Class.conclass.GetRecord(@"SELECT        IMIS_VWProducts.ProductName, IMIS_VWProducts.ManufacturerName, IMIS_VWProducts.CategoryName, IMIS_VWProducts.SizeName, IMIS_VWProducts.PackingName, IMIS_VWProducts.ManufacturerName, 
//IMIS_VWProducts.SalePrice, CONVERT(varchar(12), IMIS_tblStock.ExpiryDate, 106) AS ExpiryDate, IMIS_tblStock.BatchNo, IMIS_tblStock.Quantity, IMIS_tblStock.StockPrice, IMIS_tblStock.StoreID, 
//IMIS_VWProducts.ProductBarCode, IMIS_tblStock.ID as StockID FROM IMIS_VWProducts INNER JOIN IMIS_tblStock ON IMIS_VWProducts.ProductCode = IMIS_tblStock.ProductCode
//WHERE      IMIS_tblStock.ExpiryDate> GETDATE() and  IMIS_VWProducts.ProductName like N'%" + txtProductSearch.Text.Trim() + "%' and     IMIS_tblStock.StoreID = " + conclass.StoreID + "  order by IMIS_tblStock.ProductCode,CONVERT(datetime, IMIS_tblStock.ExpiryDate, 103) asc");

                    if (dt.Rows.Count > 0)
                    {

                        foreach (DataRow dr in dt.Rows)
                        {
                            ListViewItem item = new ListViewItem(dr["ProductBarCode"].ToString());
                            item.SubItems.Add(dr["ProductName"].ToString());
                            item.SubItems.Add(dr["ManufacturerName"].ToString());
                            item.SubItems.Add(dr["CategoryName"].ToString());
                            item.SubItems.Add(dr["SizeName"].ToString());
                            item.SubItems.Add(dr["PackingName"].ToString());
                            item.SubItems.Add(dr["ManufacturerName"].ToString());
                            if (SalePricePersentage > 0)
                                NewSalePrice =Decimal.Parse(dr["StockPrice"].ToString())+( (Decimal.Parse(dr["StockPrice"].ToString()) * SalePricePersentage) / 100);
                            else
                                NewSalePrice = Decimal.Parse(dr["StockPrice"].ToString()); 
                            item.SubItems.Add(NewSalePrice.ToString());
                            item.SubItems.Add(dr["BatchNo"].ToString());
                            item.SubItems.Add(dr["ExpiryDate"].ToString());
                            item.SubItems.Add(dr["Quantity"].ToString());


                            item.SubItems.Add(dr["StockPrice"].ToString());
                            item.SubItems.Add(dr["StockID"].ToString());
                            listProductList.Items.Add(item);
                        }
                    }
                    else
                    { 
                    txtProductSearch.Text="";
                    txtProductSearch.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                #endregion

            }
            
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
            if (e.KeyCode == Keys.Enter && listProductList.Items.Count > 0)
                AddProductByStockID(listProductList.SelectedItems[0].SubItems[12].Text);
        }
        private void listProductList_Click(object sender, EventArgs e)
        {
            AddProductByStockID(listProductList.SelectedItems[0].SubItems[12].Text);
        }
        private void listProductList_DoubleClick(object sender, EventArgs e)
        {
            AddProductByStockID(listProductList.SelectedItems[0].SubItems[12].Text);
        }
       

        private void GetTotalGrossProfit()
        {
            Decimal TotalGrossProfit = 0;
           
            foreach (DataGridViewRow gr in dataGridView2.Rows)
            {
                Decimal Qty = 0;
                Decimal StockPrice = 0;
                Decimal SalePrice = 0;
                Decimal Discount = 0;
                Decimal NetProfit = 0;
                Qty = Decimal.Parse(gr.Cells[5].Value.ToString());
                StockPrice = Decimal.Parse(gr.Cells[9].Value.ToString());
                SalePrice = Decimal.Parse(gr.Cells[13].Value.ToString());
                Discount = Decimal.Parse(gr.Cells[14].Value.ToString());
                NetProfit = ((SalePrice - Discount) - StockPrice) * Qty;
                TotalGrossProfit = TotalGrossProfit + NetProfit;
            }

            lblGrossProfit.Text = TotalGrossProfit.ToString();
        
        }



        private void AddProductByStockID(string StockID)
        {
            Decimal SubTotal = 0;
            Decimal TotalDiscount = 0;
            Decimal QuantityAtScan = 0;
            Decimal DiscountParentage = 0;
            Decimal DiscountValue = 0;
            Decimal RowTotal = 0;
            Decimal ToBasCurrencyDiscount = 0;
            DataTable dtSalePrice = Class.conclass.GetRecord(@"SELECT   UserID, Value FROM   tblDefaultSalePrice where UserID in('" + conclass.User_ID + "')");
            Decimal SalePricePersentage = 0;
            Decimal NewSalePrice = 0;
            if (dtSalePrice.Rows.Count > 0)
                SalePricePersentage = Decimal.Parse(dtSalePrice.Rows[0]["Value"].ToString());
            string str = "";
            str = @"SELECT IMIS_VWProducts.ProductCode, CONVERT(nvarchar(12), IMIS_tblStock.StockPrice) + '-' + IMIS_VWProducts.ProductName + '-' + CONVERT(nvarchar(12), IMIS_tblStock.Quantity) AS ProductName, IMIS_VWProducts.PackingName, 
                         CONVERT(varchar(12), IMIS_tblStock.ExpiryDate, 106) AS ExpiryDate, IMIS_tblStock.BatchNo, IMIS_VWProducts.ProductBarCode, IMIS_tblStock.Quantity, IMIS_tblStock.StockPrice, IMIS_VWProducts.SalePrice, 
                         IMIS_tblStock.ID AS StockID, ISNULL(IMIS_VWProducts.QuantityAtScan, 1) AS QuantityAtScan, DATEPART(year, IMIS_tblStock.ExpiryDate) AS iYear, DATEPART(month, IMIS_tblStock.ExpiryDate) AS iMonth, 
                         isnull(IMIS_VWProducts.DiscountParentage,0) as DiscountParentage, isnull(IMIS_VWProducts.Discount,0)  as DiscountValue
FROM            IMIS_VWProducts INNER JOIN
                         IMIS_tblStock ON IMIS_VWProducts.ProductCode = IMIS_tblStock.ProductCode
            WHERE   IMIS_tblStock.ID=" + StockID + " and  IMIS_tblStock.ExpiryDate> GETDATE() and  Quantity > 0";

//            str = @"SELECT IMIS_VWProducts.ProductCode, CONVERT(nvarchar(12), IMIS_tblStock.StockPrice) + '-' + IMIS_VWProducts.ProductName + '-' + CONVERT(nvarchar(12), IMIS_tblStock.Quantity) AS ProductName, IMIS_VWProducts.PackingName, 
//                         CONVERT(varchar(12), IMIS_tblStock.ExpiryDate, 106) AS ExpiryDate, IMIS_tblStock.BatchNo, IMIS_VWProducts.ProductBarCode, IMIS_tblStock.Quantity, IMIS_tblStock.StockPrice, IMIS_VWProducts.SalePrice, 
//                         IMIS_tblStock.ID AS StockID, ISNULL(IMIS_VWProducts.QuantityAtScan, 1) AS QuantityAtScan, DATEPART(year, IMIS_tblStock.ExpiryDate) AS iYear, DATEPART(month, IMIS_tblStock.ExpiryDate) AS iMonth, 
//                         isnull(IMIS_VWProducts.DiscountParentage,0) as DiscountParentage, isnull(IMIS_VWProducts.Discount,0)  as DiscountValue
//FROM            IMIS_VWProducts INNER JOIN
//                         IMIS_tblStock ON IMIS_VWProducts.ProductCode = IMIS_tblStock.ProductCode
//            WHERE   IMIS_tblStock.ID=" + StockID + " and  IMIS_tblStock.ExpiryDate> GETDATE()";


            DataTable dt = conclass.GetRecord(str);
            if (dt.Rows.Count > 0)
            {
                
                if (SalePricePersentage > 0)
                    NewSalePrice = Decimal.Parse(dt.Rows[0]["StockPrice"].ToString()) + ((Decimal.Parse(dt.Rows[0]["StockPrice"].ToString()) * SalePricePersentage) / 100);
                else
                    NewSalePrice = Decimal.Parse(dt.Rows[0]["SalePrice"].ToString());

                if (isButtionPressed)
                    QuantityAtScan = Decimal.Parse(txtQty.Text);
                else if (Decimal.Parse(dt.Rows[0]["QuantityAtScan"].ToString()) > Decimal.Parse(dt.Rows[0]["Quantity"].ToString()))
                    QuantityAtScan = Decimal.Parse(dt.Rows[0]["Quantity"].ToString());
                else
                    QuantityAtScan = Decimal.Parse(dt.Rows[0]["QuantityAtScan"].ToString());
                bool status = false;
                #region Check Qty
                Decimal CurQty = Decimal.Parse(dt.Rows[0]["Quantity"].ToString());
                Decimal Qty = QuantityAtScan;
                Decimal SalePrice = Decimal.Parse(dt.Rows[0]["SalePrice"].ToString());
                if (Qty > CurQty)
                {
                    MessageBox.Show("Only you have " + CurQty + " Quantity for selected item in the stock");
                    txt_item_id.Text = "";
                    txt_item_id.Focus();
                    gpitem_list.SendToBack();
                    gpitem_list.Visible = false;
                    txt_item_id.Focus();
                    pnlBatchNo.Visible = false;
                    pnlBatchNo.SendToBack();
                    txt_item_id.Focus();
                    return;
                }
                #endregion
                if (dataGridView2.Rows.Count > 0)
                {
                    // this block is used if record is exist in the grddview
                    #region Section to find the same record than no need to insert new record
                    String searchValue = dt.Rows[0]["StockID"].ToString();
                    Decimal NewQty = QuantityAtScan;
                    //int rowIndex = -1;
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        if (row.Cells[17].Value.ToString().Equals(searchValue))
                        {
                            Decimal SalePrice1 = Decimal.Parse(row.Cells[6].Value.ToString());
                            DiscountValue = Decimal.Parse(row.Cells[8].Value.ToString());
                            Decimal CurrQty1 = Decimal.Parse(row.Cells[5].Value.ToString());
                            Decimal TotalQty = CurrQty1 + NewQty;
                            if (TotalQty > CurQty)
                            {
                                MessageBox.Show("Only you have " + CurQty + " Quantity for selected item in the stock");
                                txt_item_id.Text = "";
                                txt_item_id.Focus();
                                gpitem_list.SendToBack();
                                gpitem_list.Visible = false;
                                txt_item_id.Focus();
                                pnlBatchNo.Visible = false;
                                pnlBatchNo.SendToBack();
                                txt_item_id.Focus();
                                return;
                            }
                            //This row is for the base currency as bank
                             ToBasCurrencyDiscount = ToBaseCurrencyPrice(DiscountValue, int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                            row.Cells[14].Value = Math.Round(ToBasCurrencyDiscount, 2);
                            //Set Base Currency Discount
                            // column 10 is the base currency discount column
                            // first check if the currency base currency than one candation and if other than another candation
                            row.Cells[8].Value = Math.Round(DiscountValue, 2);
                            //this is for the total discount column
                            row.Cells[15].Value = Math.Round(DiscountValue * TotalQty, 2);
                            //this is for the row toal
                            row.Cells[10].Value = Math.Round((SalePrice1 - DiscountValue) * TotalQty, 2);
                            row.Cells[5].Value = TotalQty;
                            status = true;
                            break;
                        }
                    }
                    #endregion
                    if (status == false)
                    {
                        #region Adding Item
                        if (dt.Rows.Count > 0)
                        {
                            #region Check Qty
                            //Decimal SalePrice = Decimal.Parse(dt.Rows[0]["SalePrice"].ToString());
                            if (Qty > CurQty)
                            {
                                MessageBox.Show("Only you have " + CurQty + " Quantity for selected item in the stock");
                                txt_item_id.Text = "";
                                txt_item_id.Focus();
                                return;
                            }
                            #endregion


                            // This Section is usd if we had record in the gridview before
                            DiscountParentage = Decimal.Parse(dt.Rows[0]["DiscountParentage"].ToString());
                            DiscountValue = Decimal.Parse(dt.Rows[0]["DiscountValue"].ToString());
                            TotalDiscount = DiscountValue * QuantityAtScan;




                            SalePrice = NewSalePrice;
                            RowTotal = (SalePrice - DiscountValue) * QuantityAtScan;
                            ToBasCurrencyDiscount = Math.Round(ToBaseCurrencyPrice(DiscountValue, int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text)), 2);
                            string[] row = new string[] { dt.Rows[0]["ProductCode"].ToString(), dt.Rows[0]["ProductName"].ToString(), dt.Rows[0]["PackingName"].ToString(), dt.Rows[0]["BatchNo"].ToString(), dt.Rows[0]["ExpiryDate"].ToString(), Qty.ToString(),SalePrice.ToString() , dt.Rows[0]["DiscountParentage"].ToString(), dt.Rows[0]["DiscountValue"].ToString(), dt.Rows[0]["StockPrice"].ToString(), RowTotal.ToString(), dt.Rows[0]["Quantity"].ToString(), dt.Rows[0]["ProductBarCode"].ToString(), SalePrice.ToString(), ToBasCurrencyDiscount.ToString(), TotalDiscount.ToString(), (ToBasCurrencyDiscount * QuantityAtScan).ToString(), dt.Rows[0]["StockID"].ToString(), dt.Rows[0]["iYear"].ToString(), dt.Rows[0]["iMonth"].ToString() };
                            dataGridView2.Rows.Insert(0, row);
                            txt_item_id.Text = "";
                            txtQty.Text = "1";
                        }
                        #endregion
                    }
                    txt_grand_total.Text = dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString();
                    SubTotal = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString());
                    TotalDiscount = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[15].Value.ToString())).ToString());
                    txtTotalDisply.Text = "";
                    txtTotalDisply.Text = "Sub Total:" + (SubTotal + TotalDiscount);
                    txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
                    txtTotalDisply.Text = txtTotalDisply.Text + "Total Discount:" + TotalDiscount;
                    txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
                    txtTotalDisply.Text = txtTotalDisply.Text + "Net Total:" + (SubTotal);
                }
                else
                {
                    // this block is used for the first time entry
                    #region Adding Item
                    if (dt.Rows.Count > 0)
                    {
                        #region Check Qty
                        //Decimal CurQty = Decimal.Parse(dt.Rows[0]["Quantity"].ToString());
                        //Decimal Qty = QuantityAtScan;
                        //Decimal SalePrice = Decimal.Parse(dt.Rows[0]["SalePrice"].ToString());
                        if (Qty > CurQty)
                        {
                            MessageBox.Show("Only you have " + CurQty + " Quantity for selected item in the stock");
                            txt_item_id.Text = "";
                            txt_item_id.Focus();
                            return;
                        }
                        #endregion
                        DiscountParentage = Decimal.Parse(dt.Rows[0]["DiscountParentage"].ToString());
                        DiscountValue = Decimal.Parse(dt.Rows[0]["DiscountValue"].ToString());
                        TotalDiscount = DiscountValue * QuantityAtScan;
                        SalePrice = SalePrice = NewSalePrice;
                        RowTotal = (SalePrice - DiscountValue) * QuantityAtScan;
                        ToBasCurrencyDiscount = Math.Round(ToBaseCurrencyPrice(DiscountValue, int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text)), 2);
                        string[] row = new string[] { dt.Rows[0]["ProductCode"].ToString(), dt.Rows[0]["ProductName"].ToString(), dt.Rows[0]["PackingName"].ToString(), dt.Rows[0]["BatchNo"].ToString(), dt.Rows[0]["ExpiryDate"].ToString(), Qty.ToString(), SalePrice.ToString(), dt.Rows[0]["DiscountParentage"].ToString(), dt.Rows[0]["DiscountValue"].ToString(), dt.Rows[0]["StockPrice"].ToString(), RowTotal.ToString(), dt.Rows[0]["Quantity"].ToString(), dt.Rows[0]["ProductBarCode"].ToString(), SalePrice.ToString(), ToBasCurrencyDiscount.ToString(), TotalDiscount.ToString(), (ToBasCurrencyDiscount * QuantityAtScan).ToString(), dt.Rows[0]["StockID"].ToString(), dt.Rows[0]["iYear"].ToString(), dt.Rows[0]["iMonth"].ToString() };
                        dataGridView2.Rows.Insert(0, row);
                        txt_item_id.Text = "";
                        txtQty.Text = "1";
                        //string[] row = new string[] { dt.Rows[0]["ProductCode"].ToString(), dt.Rows[0]["ProductName"].ToString(), dt.Rows[0]["PackingName"].ToString(), dt.Rows[0]["BatchNo"].ToString(), dt.Rows[0]["ExpiryDate"].ToString(), Qty.ToString(), dt.Rows[0]["SalePrice"].ToString(), "0", dt.Rows[0]["StockPrice"].ToString(), (Qty * SalePrice).ToString(), dt.Rows[0]["Quantity"].ToString(), dt.Rows[0]["ProductBarCode"].ToString(), dt.Rows[0]["SalePrice"].ToString(), "0", "0", dt.Rows[0]["StockID"].ToString(), dt.Rows[0]["iYear"].ToString(), dt.Rows[0]["iMonth"].ToString() };
                        //dataGridView2.Rows.Insert(0, row);
                        //txt_item_id.Text = "";
                        //txtQty.Text = "1";
                    }
                    txt_grand_total.Text = dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString();
                    SubTotal = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString());
                    TotalDiscount = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[15].Value.ToString())).ToString());
                    txtTotalDisply.Text = "";
                    txtTotalDisply.Text = "Sub Total:" + (SubTotal + TotalDiscount);
                    txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
                    txtTotalDisply.Text = txtTotalDisply.Text + "Total Discount:" + TotalDiscount;
                    txtTotalDisply.Text = txtTotalDisply.Text + "\r\n";
                    txtTotalDisply.Text = txtTotalDisply.Text + "Net Total:" + (SubTotal);
                    // InsertCustomerDisplay(SubTotal + TotalDiscount, TotalDiscount, SubTotal);
                    #endregion
                }
                isButtionPressed = false;
                SetSubTotal();
                GetTotalGrossProfit();
                gpitem_list.SendToBack();
                gpitem_list.Visible = false;
                txt_item_id.Focus();
            }
        }
        private void GetBatchInformation(string Code)
        {
//            DataTable dt = obj.GetData(@"SELECT  IMIS_tblStock.ID, Convert(nvarchar(12),StockPrice)+'-'+IMIS_VWProducts.ProductName+'-'+Convert(nvarchar(12),IMIS_tblStock.Quantity)   as ProductName ,IMIS_VWProducts.PackingName,
// IMIS_tblStock.BatchNo, SUBSTRING(CONVERT(varchar(12), IMIS_tblStock.ExpiryDate, 103), 4, 10) AS ExpiryDate, IMIS_tblStock.Quantity,IMIS_VWProducts.ProductBarCode
//FROM            IMIS_tblStock INNER JOIN
//                         IMIS_VWProducts ON IMIS_tblStock.ProductCode = IMIS_VWProducts.ProductCode
// where StoreID=" + conclass.StoreID + " and  ProductBarCode='" + Code + "' and IMIS_tblStock.Quantity>0   order by ProductBarCode,CONVERT(datetime, IMIS_tblStock.ExpiryDate, 103) asc");
            DataTable dt = obj.GetData(@"SELECT  IMIS_tblStock.ID, Convert(nvarchar(12),StockPrice)+'-'+IMIS_VWProducts.ProductName+'-'+Convert(nvarchar(12),IMIS_tblStock.Quantity)   as ProductName ,IMIS_VWProducts.PackingName,
 IMIS_tblStock.BatchNo, SUBSTRING(CONVERT(varchar(12), IMIS_tblStock.ExpiryDate, 103), 4, 10) AS ExpiryDate, IMIS_tblStock.Quantity,IMIS_VWProducts.ProductBarCode
FROM            IMIS_tblStock INNER JOIN
                         IMIS_VWProducts ON IMIS_tblStock.ProductCode = IMIS_VWProducts.ProductCode
 where  IMIS_tblStock.Quantity>0  AND (IMIS_tblStock.ExpiryDate IS NULL OR IMIS_tblStock.ExpiryDate > GETDATE()) and StoreID=" + conclass.StoreID + " and  ProductBarCode='" + Code + "' order by ProductBarCode,CONVERT(datetime, IMIS_tblStock.ExpiryDate, 103) asc");


            lstBatchInformation.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["ID"].ToString());
                    item.SubItems.Add(dr["ProductName"].ToString());
                    item.SubItems.Add(dr["PackingName"].ToString());
                    item.SubItems.Add(dr["BatchNo"].ToString());
                    item.SubItems.Add(dr["ExpiryDate"].ToString());
                    item.SubItems.Add(dr["Quantity"].ToString());
                    lstBatchInformation.Items.Add(item);
                }
                txt_item_id.Text = "";
                pnlBatchNo.Visible = true;
                pnlBatchNo.BringToFront();
                pnlBatchNo.Location = new Point(240, 87);
                //lstBatchInformation.Focus();
                //lstBatchInformation.Items[0].Selected = true;
                //lstBatchInformation.Items[0].EnsureVisible();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            pnlBatchNo.Visible = false;
            pnlBatchNo.SendToBack();
            txt_item_id.Focus();
            pnlBatchNo.Location = new Point(240, 595);
        }
        private void lstBatchInformation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               AddProductByStockID(lstBatchInformation.SelectedItems[0].SubItems[0].Text);
                pnlBatchNo.Visible = false;
                pnlBatchNo.SendToBack();
                pnlBatchNo.Location = new Point(240, 595);
                txt_item_id.Focus();
            }
        }
        private void txt_item_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_item_id.Text != "" && e.KeyCode == Keys.Enter)
            {
                GetBatchInformation(txt_item_id.Text.Trim());
                gpitem_list.Visible = false;
            }
            else if (txt_item_id.Text == "" && e.KeyCode == Keys.Enter && pnlBatchNo.Visible == false)
            {
                gpitem_list.Visible = true;
                gpitem_list.BringToFront();
                listProductList.Items.Clear();
                txtProductSearch.Text = "";
                txtProductSearch.Focus();
            }
            if (e.KeyCode == Keys.Enter && pnlBatchNo.Visible == true)
            {
                lstBatchInformation.Items[0].Selected = true;
                lstBatchInformation.Items[0].EnsureVisible();
                lstBatchInformation.Select();
                lstBatchInformation.Focus();
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DataTable dtOpeningBalance = obj.GetData(@"select ClosingStatus from  FMIS_tblCashierBalance where ID=(select max(ID) from FMIS_tblCashierBalance where UserID='" + conclass.User_ID + "' and CurrencyID='" + cmbCurrency.SelectedValue + "')");
            if (dtOpeningBalance.Rows.Count > 0 && dtOpeningBalance.Rows[0]["ClosingStatus"].ToString() == "Closed")
            {
                MessageBox.Show("Cashir Opening Balance is not open yet");
                return;
            }
            else if (dtOpeningBalance.Rows.Count < 0 || dtOpeningBalance.Rows.Count == 0)
            {
                MessageBox.Show("Cashir Opening Balance is not open yet");
                return;
            }
            if (txt_grand_total.Text == "0" || txt_grand_total.Text == "")
            {
                MessageBox.Show("Please add an Item");
                txt_item_id.Focus();
                return;
            }

            if (cmbPaymentMethod.Text == "")
            {
                MessageBox.Show("Chose Payment Method");
                cmbPaymentMethod.Focus();
                return;
            }

            if (lblShowSalesMan.Tag.ToString() == "1")
            {
                pnlPayment.Visible = true;
                pnlPayment.BringToFront();
                pnlPayment.Location = new Point(583, 521);
                pnlPayment.Enabled = true;
            }
            else
            {
                #region Default Sales Man Details
                if (lblShowSalesMan.Tag == "0")
                {
                    DataTable dtSalesMan = obj.GetData("SELECT top 1  SaleManID FROM IMIS_tblSaleMan where Status='Active and Default'");
                    if (dtSalesMan.Rows.Count > 0)
                        cmbSaleMan.SelectedValue = dtSalesMan.Rows[0]["SaleManID"].ToString();
                }
                else
                {
                    MessageBox.Show("Add Default Sales man from setting");
                    return;
                }
                #endregion 
                InsertSaleOrder();
            }
        }

        private static Random random = new Random(); // Shared random object with a seed
        private Int64 GenerateUniquePatientNumber()
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
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM IMIS_tblSaleOrderMain WHERE InvoiceNo = @InvoiceNo", connection))
                {
                    cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
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

        private void LoadSalesSetting()
        {
            DataTable dtOpeningBalance = obj.GetData(@"select ClosingStatus from  FMIS_tblCashierBalance where ID=(select max(ID) from FMIS_tblCashierBalance where UserID='" + conclass.User_ID + "')");
            foreach (DataRow dr in dtOpeningBalance.Rows)
            {
                if (dr["ClosingStatus"].ToString() == "Closed")
                {
                    MessageBox.Show("Cashir Opening Balance is not open yet");
                    btnSave.Enabled = false;
                    break;
                }
            }
            DataTable dt = obj.GetData("SELECT * FROM IMIS_tblSalesSetting");
            if (dt.Rows.Count > 0)
            {



                if (dt.Rows[0]["ShowProfitOnScreen"].ToString() == "True")
                {
                    lblGrossProfit.Visible = true;
                }
                else
                {
                    lblGrossProfit.Visible = false;
                }





                if (dt.Rows[0]["SalesPriceCanBeEditable"].ToString() == "True")
                {
                    dataGridView2.Columns[6].ReadOnly = false;
                    dataGridView2.Columns[6].DefaultCellStyle.BackColor = Color.LightYellow;
                    dataGridView2.Columns[6].DefaultCellStyle.SelectionBackColor = Color.LightYellow;
                    dataGridView2.Columns[6].DefaultCellStyle.ForeColor = Color.Red;
                    dataGridView2.Columns[6].DefaultCellStyle.SelectionForeColor = Color.Red;
                }
                else
                {
                }
                if (dt.Rows[0]["RepeatedItemsShowInSingleRow"].ToString() == "True")
                {
                    //For RepeatedItemsShowInSingleRow
                    cmbCurrency.Tag = "True";
                }
                else
                {
                    cmbCurrency.Tag = "False";
                }

                if (dt.Rows[0]["ShowSalesMan"].ToString() == "True")
                    lblShowSalesMan.Tag = "1";
                else
                    lblShowSalesMan.Tag = "0";

                if (dt.Rows[0]["ShowPrintalert"].ToString() == "True")
                      lblShowPrintalert.Tag = "1";
                else
                      lblShowPrintalert.Tag = "0";

                if (dt.Rows[0]["ShowAveragePrice"].ToString() == "True")
                    lblShowAvgPrice.Text = "1";
                else
                    lblShowAvgPrice.Text = "0";
                InvoiceLanguage = int.Parse(dt.Rows[0]["InvoiceLanguage"].ToString());
                if (dt.Rows[0]["InvoicePrintInA4Page"].ToString() == "True")
                {
                    //For RepeatedItemsShowInSingleRow
                  PrintA4 = true;
                    chkA4Reprint.Checked = true;
                }
                else
                {
                    PrintA4 = false;
                    chkA4Reprint.Checked = false;
                }
                if (dt.Rows[0]["UserCanChangeTheDiscount"].ToString() == "True")
                {
                    #region Discont %
                    dataGridView2.Columns[7].ReadOnly = false;
                    dataGridView2.Columns[7].DefaultCellStyle.BackColor = Color.LightYellow;
                    dataGridView2.Columns[7].DefaultCellStyle.SelectionBackColor = Color.LightYellow;
                    dataGridView2.Columns[7].DefaultCellStyle.ForeColor = Color.Red;
                    dataGridView2.Columns[7].DefaultCellStyle.SelectionForeColor = Color.Red;
                    #endregion
                    #region Discount Value
                    dataGridView2.Columns[8].ReadOnly = false;
                    dataGridView2.Columns[8].DefaultCellStyle.BackColor = Color.LightYellow;
                    dataGridView2.Columns[8].DefaultCellStyle.SelectionBackColor = Color.LightYellow;
                    dataGridView2.Columns[8].DefaultCellStyle.ForeColor = Color.Red;
                    dataGridView2.Columns[8].DefaultCellStyle.SelectionForeColor = Color.Red;
                    #endregion
                    btnDiscount.Enabled = true;
                }
                else
                {
                    #region Discont %
                    dataGridView2.Columns[7].ReadOnly = true;
                    dataGridView2.Columns[7].DefaultCellStyle.BackColor = Color.White;
                    dataGridView2.Columns[7].DefaultCellStyle.SelectionBackColor = Color.White;
                    dataGridView2.Columns[7].DefaultCellStyle.ForeColor = Color.Black;
                    dataGridView2.Columns[7].DefaultCellStyle.SelectionForeColor = Color.Black;
                    #endregion
                    #region Discount Value
                    dataGridView2.Columns[8].ReadOnly = true;
                    dataGridView2.Columns[8].DefaultCellStyle.BackColor = Color.White;
                    dataGridView2.Columns[8].DefaultCellStyle.SelectionBackColor = Color.White;
                    dataGridView2.Columns[8].DefaultCellStyle.ForeColor = Color.Black;
                    dataGridView2.Columns[8].DefaultCellStyle.SelectionForeColor = Color.Black;
                    #endregion
                    btnDiscount.Enabled = true;
                }
                if (conclass.IsInRole(conclass.UserName, "Finance Admin"))
                {
                    #region Discont %
                    dataGridView2.Columns[7].ReadOnly = false;
                    dataGridView2.Columns[7].DefaultCellStyle.BackColor = Color.LightYellow;
                    dataGridView2.Columns[7].DefaultCellStyle.SelectionBackColor = Color.LightYellow;
                    dataGridView2.Columns[7].DefaultCellStyle.ForeColor = Color.Red;
                    dataGridView2.Columns[7].DefaultCellStyle.SelectionForeColor = Color.Red;
                    #endregion
                    #region Discount Value
                    dataGridView2.Columns[8].ReadOnly = false;
                    dataGridView2.Columns[8].DefaultCellStyle.BackColor = Color.LightYellow;
                    dataGridView2.Columns[8].DefaultCellStyle.SelectionBackColor = Color.LightYellow;
                    dataGridView2.Columns[8].DefaultCellStyle.ForeColor = Color.Red;
                    dataGridView2.Columns[8].DefaultCellStyle.SelectionForeColor = Color.Red;
                    #endregion
                    btnDiscount.Enabled = true;
                }
                else
                {
                    if (dt.Rows[0]["UserCanChangeTheDiscount"].ToString() == "True")
                        btnDiscount.Enabled = true;
                    else
                        btnDiscount.Enabled = false;
                }


            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            InsertSaleOrder();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

      
      
    }
}
