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
    public partial class frmSale : Form
    {
        Dbcommon obj = new Dbcommon();
        public frmSale()
        {
            InitializeComponent();
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
            gpitem_list.SendToBack();
            gpitem_list.Visible = false;
            txtBarCode.Focus();
        }
        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                listProductList.Items.Clear();
                DataTable dt = new DataTable();
                dt = Class.conclass.GetRecord(@"SELECT        IMIS_VWProducts.ProductName, IMIS_VWProducts.ManufacturerName, IMIS_VWProducts.CategoryName, IMIS_VWProducts.SizeName, IMIS_VWProducts.PackingName, IMIS_VWProducts.ManufacturerName, 
                         IMIS_VWProducts.SalePrice, CONVERT(varchar(12), IMIS_tblStock.ExpiryDate, 106) AS ExpiryDate, IMIS_tblStock.BatchNo, IMIS_tblStock.Quantity, IMIS_tblStock.StockPrice, IMIS_tblStock.StoreID, 
                         IMIS_VWProducts.ProductBarCode, IMIS_tblStock.ID as StockID
FROM            IMIS_VWProducts INNER JOIN
                         IMIS_tblStock ON IMIS_VWProducts.ProductCode = IMIS_tblStock.ProductCode
WHERE  IMIS_VWProducts.ProductName like N'%" + txtProductSearch.Text.Trim() + "%' and     IMIS_tblStock.StoreID = " + conclass.StoreID + " and  IMIS_tblStock.Quantity>0  order by IMIS_tblStock.ProductCode,CONVERT(datetime, IMIS_tblStock.ExpiryDate, 103) asc");
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["ProductBarCode"].ToString());
                    item.SubItems.Add(dr["ProductName"].ToString());
                    item.SubItems.Add(dr["ManufacturerName"].ToString());
                    item.SubItems.Add(dr["CategoryName"].ToString());
                    item.SubItems.Add(dr["SizeName"].ToString());
                    item.SubItems.Add(dr["PackingName"].ToString());
                    item.SubItems.Add(dr["ManufacturerName"].ToString());
                    item.SubItems.Add(dr["SalePrice"].ToString());
                    item.SubItems.Add(dr["BatchNo"].ToString());
                    item.SubItems.Add(dr["ExpiryDate"].ToString());
                    item.SubItems.Add(dr["Quantity"].ToString());
                    item.SubItems.Add(dr["StockPrice"].ToString());
                    item.SubItems.Add(dr["StockID"].ToString());
                    listProductList.Items.Add(item);
                }
                txtBarCode.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void txtProductSearch_KeyDown(object sender, KeyEventArgs e)
        {
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
        private void AddProductByStockID(string StockID)
        {
            Decimal SubTotal = 0;
            Decimal TotalDiscount = 0;
            Decimal QuantityAtScan = 0;
            Decimal Total = 0;
            string str = @"SELECT       IMIS_VWProducts.ProductCode, Convert(nvarchar(12),StockPrice)+'-'+IMIS_VWProducts.ProductName+'-'+Convert(nvarchar(12),IMIS_tblStock.Quantity)   as ProductName, IMIS_VWProducts.PackingName, CONVERT(varchar(12), IMIS_tblStock.ExpiryDate, 106) 
                         AS ExpiryDate, IMIS_tblStock.BatchNo, IMIS_VWProducts.ProductBarCode, IMIS_tblStock.Quantity, IMIS_tblStock.StockPrice, IMIS_VWProducts.SalePrice, IMIS_tblStock.ID as StockID,isnull(QuantityAtScan,1) QuantityAtScan,
                DATEPART(year,ExpiryDate) as iYear,datepart(month,ExpiryDate) as iMonth FROM            IMIS_VWProducts INNER JOIN
                         IMIS_tblStock ON IMIS_VWProducts.ProductCode = IMIS_tblStock.ProductCode
            WHERE   IMIS_tblStock.ID=" + StockID + " and  Quantity > 0";
            DataTable dt = conclass.GetRecord(str);
            if (dt.Rows.Count > 0)
            {
                txtitemName.Tag = dt.Rows[0]["ProductCode"].ToString();
                txtitemName.Text = dt.Rows[0]["ProductName"].ToString();
                txtPackingName.Text = dt.Rows[0]["PackingName"].ToString();
                txtBatchNo.Text = dt.Rows[0]["BatchNo"].ToString();
                txtBatchNo.Tag = StockID;
                txtExpiryDate.Text = dt.Rows[0]["ExpiryDate"].ToString();
                txtExpiryDate.Tag = dt.Rows[0]["iYear"].ToString();
                txtPackingName.Tag = dt.Rows[0]["iMonth"].ToString();
                txtQty.Text = dt.Rows[0]["QuantityAtScan"].ToString();
                txtQty.Tag = dt.Rows[0]["Quantity"].ToString();
                txtPrice.Text = dt.Rows[0]["SalePrice"].ToString();
                txtPrice.Tag = dt.Rows[0]["StockPrice"].ToString();
                txtDiscountPer.Text = "0";
                txtDiscountValue.Text = "0";
                Total = (Decimal.Parse(txtPrice.Text) - Decimal.Parse(txtDiscountValue.Text)) * Decimal.Parse(txtQty.Text);
                txtTotal.Text = Total.ToString();
                gpitem_list.SendToBack();
                gpitem_list.Visible = false;
                txtQty.Focus();
            }
        }
        private void AddToList()
        {

            Decimal QuantityAtScan = Decimal.Parse(txtQty.Text);
            Decimal SubTotal = 0;
            Decimal DiscountParentage = 0;
            Decimal DiscountValue = 0;
            Decimal TotalDiscount = 0;
            Decimal ToBasCurrencyDiscount = 0;
            Decimal RowTotal = 0;
            bool status = false;
            #region Check Qty
            Decimal CurQty = Decimal.Parse(txtQty.Tag.ToString());
            Decimal Qty = QuantityAtScan;
            Decimal SalePrice = Decimal.Parse(txtPrice.Text);
            if (Qty > CurQty)
            {
                MessageBox.Show("Only you have " + CurQty + " Quantity for selected item in the stock");
                return;
            }
            #endregion
            if (dataGridView2.Rows.Count > 0)
            {
                // this block is used if record is exist in the grddview
                #region Section to find the same record than no need to insert new record
                String searchValue = txtBatchNo.Tag.ToString();
                Decimal NewQty = QuantityAtScan;
                //int rowIndex = -1;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells[12].Value.ToString().Equals(searchValue))
                    {
                        Decimal SalePrice1 = Decimal.Parse(txtPrice.Text);
                        DiscountValue = Decimal.Parse(txtDiscountValue.Text);
                        Decimal CurrQty1 = Decimal.Parse(row.Cells[5].Value.ToString());
                        Decimal TotalQty = CurrQty1 + NewQty;
                        if (TotalQty > CurQty)
                        {
                            MessageBox.Show("Only you have " + CurQty + " Quantity for selected item in the stock");
                            Clear();
                            return;
                        }
                        // Total Qty
                        row.Cells[5].Value = TotalQty;
                        // Row Total
                        row.Cells[10].Value = Math.Round((SalePrice1 - DiscountValue) * TotalQty, 2);
                        //this is for the total discount column
                        row.Cells[11].Value = Math.Round(DiscountValue * TotalQty, 2);

                        //this is for the Base Currency discount column
                        ToBasCurrencyDiscount = ToBaseCurrencyPrice(DiscountValue, int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                        // Base Currency Discount
                        row.Cells[16].Value = Math.Round(ToBasCurrencyDiscount, 2);
                        // Total Base Currency
                        row.Cells[17].Value = Math.Round(ToBasCurrencyDiscount * TotalQty, 2);



                        status = true;
                        break;
                    }
                }
                #endregion
                if (status == false)
                {
                    #region Adding Item

                    #region Check Qty
                    //Decimal SalePrice = Decimal.Parse(dt.Rows[0]["SalePrice"].ToString());
                    if (Qty > CurQty)
                    {
                        MessageBox.Show("Only you have " + CurQty + " Quantity for selected item in the stock");
                        Clear();
                        return;
                    }
                    #endregion


                    DiscountParentage = Decimal.Parse(txtDiscountPer.Text);
                    DiscountValue = Decimal.Parse(txtDiscountValue.Text);
                    TotalDiscount = DiscountValue * Decimal.Parse(txtQty.Text);
                    SalePrice = Decimal.Parse(txtPrice.Text);
                    RowTotal = (SalePrice - DiscountValue) * QuantityAtScan;

                    ToBasCurrencyDiscount = ToBaseCurrencyPrice(DiscountValue, int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                    string[] row = new string[] { txtitemName.Tag.ToString(), txtitemName.Text, txtPackingName.Text, txtBatchNo.Text, txtExpiryDate.Text, Qty.ToString(), txtPrice.Text, txtDiscountPer.Text, txtDiscountValue.Text, txtPrice.Tag.ToString(), RowTotal.ToString(), TotalDiscount.ToString(), txtBatchNo.Tag.ToString(), txtExpiryDate.Tag.ToString(), txtPackingName.Tag.ToString(), SalePrice.ToString(), ToBasCurrencyDiscount.ToString(), (ToBasCurrencyDiscount * QuantityAtScan).ToString(), CurQty.ToString() };
                    dataGridView2.Rows.Insert(0, row);
                    txtQty.Text = "1";

                    #endregion
                }
                txt_grand_total.Text = dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString();
                SubTotal = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString());
                TotalDiscount = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[11].Value.ToString())).ToString());

            }
            else
            {
                // this block is used for the first time entry
                #region Adding Item
                #region Check Qty
                //Decimal CurQty = Decimal.Parse(dt.Rows[0]["Quantity"].ToString());
                //Decimal Qty = QuantityAtScan;
                //Decimal SalePrice = Decimal.Parse(dt.Rows[0]["SalePrice"].ToString());
                if (Qty > CurQty)
                {
                    MessageBox.Show("Only you have " + CurQty + " Quantity for selected item in the stock");
                    Clear();
                    return;
                }
                #endregion

                DiscountParentage = Decimal.Parse(txtDiscountPer.Text);
                DiscountValue = Decimal.Parse(txtDiscountValue.Text);
                TotalDiscount = DiscountValue * Decimal.Parse(txtQty.Text);
                SalePrice = Decimal.Parse(txtPrice.Text);
                RowTotal = (SalePrice - DiscountValue) * QuantityAtScan;
                ToBasCurrencyDiscount = ToBaseCurrencyPrice(DiscountValue, int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                string[] row = new string[] { txtitemName.Tag.ToString(), txtitemName.Text, txtPackingName.Text, txtBatchNo.Text, txtExpiryDate.Text, Qty.ToString(), txtPrice.Text, txtDiscountPer.Text, txtDiscountValue.Text, txtPrice.Tag.ToString(), RowTotal.ToString(), TotalDiscount.ToString(), txtBatchNo.Tag.ToString(), txtExpiryDate.Tag.ToString(), txtPackingName.Tag.ToString(), SalePrice.ToString(), ToBasCurrencyDiscount.ToString(), (ToBasCurrencyDiscount * QuantityAtScan).ToString(), CurQty.ToString() };
                dataGridView2.Rows.Insert(0, row);
                txtQty.Text = "1";

                txt_grand_total.Text = dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString();
                SubTotal = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString());
                TotalDiscount = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[11].Value.ToString())).ToString());

                #endregion
            }

            SetSubTotal();

            Clear();
        }
        private void Clear()
        {
            txtitemName.Tag = "";
            txtitemName.Text = "";
            txtPackingName.Text = "";
            txtBatchNo.Text = "";
            txtBatchNo.Tag = "";
            txtExpiryDate.Text = "";
            txtExpiryDate.Tag = "";
            txtPackingName.Tag = "";
            txtQty.Text = "";
            txtQty.Tag = "";
            txtPrice.Text = "";
            txtPrice.Tag = "";
            txtDiscountPer.Text = "";
            txtDiscountValue.Text = "";
            txtitemName.Focus();

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

                    // re Set Sale Price
                    gr.Cells[6].Value = gr.Cells[15].Value;
                    //Re Set Discount Value
                    gr.Cells[8].Value = gr.Cells[16].Value;
                    SalePrice = Decimal.Parse(gr.Cells[6].Value.ToString());
                    Qty = Decimal.Parse(gr.Cells[5].Value.ToString());
                    Discount = Decimal.Parse(gr.Cells[8].Value.ToString());
                    // Row Total
                    gr.Cells[11].Value = Math.Round(Discount * Qty, 2);
                    // Total Discount Value
                    Total = (SalePrice - Discount) * Qty;
                    gr.Cells[10].Value = Math.Round(Total, 2);
                    gr.Cells[17].Value = Math.Round(Discount * Qty, 2);
                }
            }
            else
            {
                foreach (DataGridViewRow gr in dataGridView2.Rows)
                {
                    Qty = Decimal.Parse(gr.Cells[5].Value.ToString());
                    gr.Cells[6].Value = gr.Cells[15].Value;
                    SalePrice = Decimal.Parse(gr.Cells[6].Value.ToString());
                    // change the discount visable colum from bas currency 10 column
                    Discount = Decimal.Parse(gr.Cells[16].Value.ToString());
                    ExchangeRate = Decimal.Parse(txtExchangeRate.Text);
                    BaseCurrencySalePrice = Get_Base_Currency_Price(SalePrice, CurrencyID, ExchangeRate);
                    BasCurrencyDiscount = Get_Base_Currency_Price(Discount, CurrencyID, ExchangeRate);
                    TotalBasCurrencyTotal = (BaseCurrencySalePrice - BasCurrencyDiscount) * Qty;
                    gr.Cells[6].Value = Math.Round(BaseCurrencySalePrice, 2);
                    gr.Cells[8].Value = Math.Round(BasCurrencyDiscount, 2);
                    gr.Cells[17].Value = Math.Round(BasCurrencyDiscount * Qty, 2);
                    gr.Cells[9].Value = Math.Round(TotalBasCurrencyTotal, 2);
                    gr.Cells[10].Value = Math.Round(TotalBasCurrencyTotal, 2);
                    gr.Cells[17].Value = Math.Round(BasCurrencyDiscount * Qty, 2);
                }
            }
            txt_grand_total.Text = dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString();
            SubTotal = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString());
            TotalDiscount = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[11].Value.ToString())).ToString());
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
        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            gpitem_list.Visible = true;
            gpitem_list.BringToFront();
            txtBarCode.Text = "";
            txtProductSearch.Focus();
        }
        private void frmSale_Load(object sender, EventArgs e)
        {

            #region Load

            CashCustomer();

            // LoadSalesSetting();

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
            cmbPaymentMethod_SelectionChangeCommitted(null, null);
            //FillCustomerSaveView();
            this.ActiveControl = txtitemName;
            txtitemName.Select();

            #endregion
            txtitemName.Focus();
        }
        private void CashCustomer()
        {

            obj.fillcmb(cmbCustomer, "CustomerName", "CustomerID", "select CustomerID, CustomerName from IMIS_tblCustomer where StoreID=" + conclass.StoreID + "");
            DataTable dt = obj.GetData(@"SELECT    CustomerID, CustomerName,CustomerAddress FROM IMIS_tblCustomer where StoreID=" + conclass.StoreID + " and CustomerName='Cash Customer'");
            if (dt.Rows.Count > 0)
            {
                cmbCustomer.SelectedValue = dt.Rows[0]["CustomerID"].ToString();

            }
        }
        private void txtitemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gpitem_list.Visible = true;
                gpitem_list.BringToFront();
                txtProductSearch.Text = "";
                txtProductSearch.Focus();
               
            }
        }
        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtTotal.Text = string.Empty;
                if (txtQty.Text.Trim() != string.Empty && this.txtPrice.Text.Trim() != string.Empty)
                {
                    Decimal Total = (Decimal.Parse(txtPrice.Text) - Decimal.Parse(txtDiscountValue.Text)) * Decimal.Parse(txtQty.Text);
                    txtTotal.Text = Total.ToString();
                }

            }
            catch (Exception)
            {

            }
        }
        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDiscountPer.Focus();
        }
        private void txtDiscountPer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtTotal.Text = string.Empty;
           
                if (txtQty.Text.Trim() != string.Empty && this.txtPrice.Text.Trim() != string.Empty && this.txtDiscountPer.Text.Trim() != string.Empty)
                {
                    Decimal DiscountValue = 0;
                    Decimal DiscountPer = 0;
                    Decimal SalePrice = 0;
                    DiscountPer = Decimal.Parse(txtDiscountPer.Text);
                    SalePrice = Decimal.Parse(txtPrice.Text);
                    DiscountValue = SalePrice * DiscountPer / 100;
                    txtDiscountValue.Text = DiscountValue.ToString();
                    Decimal Total = (SalePrice - DiscountValue) * Decimal.Parse(txtQty.Text);
                    txtTotal.Text = Total.ToString();
                }
            }
            catch (Exception)
            {

            }
        }
        private void txtDiscountPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
               // txtDiscountValue.Focus();
            AddToList();

              
        }
        private void cmbPaymentMethod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbPaymentMethod.Text != "Loan")
                cmbPaymentAccount.Enabled = true;
            else
                cmbPaymentAccount.Enabled = false;
            SetSubTotal();
        }
        private void cmbCurrency_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT ID, CurrencyID, ExchangeRate FROM  FMIS_tblCurrencyExchangeRate where ID=(select max(ID) from FMIS_tblCurrencyExchangeRate where CurrencyID=" + cmbCurrency.SelectedValue + " and StoreID=" + conclass.StoreID + ")");
            if (dt.Rows.Count > 0)
            {
                txtExchangeRate.Text = dt.Rows[0]["ExchangeRate"].ToString();
                obj.fillcmb(cmbPaymentAccount, "AccountName", "AccountID", "SELECT  AccountID, AccountName FROM FMIS_tblCashAccounts where  CurrencyID=" + cmbCurrency.SelectedValue + " and StoreID=" + conclass.StoreID + "");
            }
            ChangeToCurrency();
            SetSubTotal();
        }
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
                    Decimal DiscountPercentage = Decimal.Parse(dataGridView2.CurrentRow.Cells[7].Value.ToString());
                    Decimal DiscountValue = (SalePrice * DiscountPercentage) / 100;
                    Discount = DiscountValue;

                    //This row is for the base currency as bank
                    Decimal ToBasCurrencyDiscount = ToBaseCurrencyPrice(Discount, int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                    dataGridView2.CurrentRow.Cells[16].Value = Math.Round(ToBasCurrencyDiscount, 2);
                    //Set Base Currency Discount
                    // column 10 is the base currency discount column
                    // first check if the currency base currency than one candation and if other than another candation
                    dataGridView2.CurrentRow.Cells[11].Value = Math.Round(Discount * Qty, 2);
                    dataGridView2.CurrentRow.Cells[17].Value = Math.Round(ToBasCurrencyDiscount * Qty, 2);
                    dataGridView2.CurrentRow.Cells[8].Value = Math.Round(Discount, 2);
                    dataGridView2.CurrentRow.Cells[10].Value = Math.Round((SalePrice - Discount) * Qty, 2);
                }
                if (e.ColumnIndex == 7)
                {
                    // Discount Column % is chanage-done
                    Qty = Decimal.Parse(dataGridView2.CurrentRow.Cells[5].Value.ToString());
                    Decimal SalePrice = Decimal.Parse(dataGridView2.CurrentRow.Cells[6].Value.ToString());
                    Decimal DiscountPercentage = Decimal.Parse(dataGridView2.CurrentRow.Cells[7].Value.ToString());
                    Decimal DiscountValue = (SalePrice * DiscountPercentage) / 100;
                    Discount = DiscountValue;
                    //This row is for the base currency as bank
                    Decimal ToBasCurrencyDiscount = ToBaseCurrencyPrice(Discount, int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                    dataGridView2.CurrentRow.Cells[16].Value = Math.Round(ToBasCurrencyDiscount, 2);
                    //Set Base Currency Discount
                    // column 10 is the base currency discount column
                    // first check if the currency base currency than one candation and if other than another candation
                    dataGridView2.CurrentRow.Cells[11].Value = Math.Round(Discount * Qty, 2);
                    dataGridView2.CurrentRow.Cells[17].Value = Math.Round(ToBasCurrencyDiscount * Qty, 2);
                    dataGridView2.CurrentRow.Cells[8].Value = Math.Round(Discount, 2);
                    dataGridView2.CurrentRow.Cells[10].Value = Math.Round((SalePrice - Discount) * Qty, 2);
                }
                if (e.ColumnIndex == 8)
                {
                    // if Discount Value is change than Discount % will effect 
                    Qty = Decimal.Parse(dataGridView2.CurrentRow.Cells[5].Value.ToString());
                    Decimal SalePrice = Decimal.Parse(dataGridView2.CurrentRow.Cells[6].Value.ToString());
                    Decimal DiscountPercentage = 0;
                    Decimal DiscountValue = Decimal.Parse(dataGridView2.CurrentRow.Cells[8].Value.ToString());
                    DiscountPercentage = (DiscountValue * 100) / SalePrice;
                    Discount = DiscountValue;
                
                   
                  
                    //This row is for the base currency as bank
                    Decimal ToBasCurrencyDiscount = ToBaseCurrencyPrice(Discount, int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                    dataGridView2.CurrentRow.Cells[16].Value = Math.Round(ToBasCurrencyDiscount, 2);
                    //Set Base Currency Discount
                    // column 10 is the base currency discount column
                    // first check if the currency base currency than one candation and if other than another candation
                    dataGridView2.CurrentRow.Cells[11].Value = Math.Round(Discount * Qty, 2);
                    dataGridView2.CurrentRow.Cells[17].Value = Math.Round(ToBasCurrencyDiscount * Qty, 2);
                    dataGridView2.CurrentRow.Cells[8].Value = Math.Round(Discount, 2);
                    dataGridView2.CurrentRow.Cells[7].Value = Math.Round(DiscountPercentage, 2);
                    dataGridView2.CurrentRow.Cells[10].Value = Math.Round((SalePrice - Discount) * Qty, 2);
                }
                else if (e.ColumnIndex == 5)
                {
                    // Quantity Column
                    Qty = Decimal.Parse(dataGridView2.CurrentRow.Cells[5].Value.ToString());
                    Price = Decimal.Parse(dataGridView2.CurrentRow.Cells[6].Value.ToString());
                    Decimal DiscountPercentage = Decimal.Parse(dataGridView2.CurrentRow.Cells[7].Value.ToString());
                    Decimal DiscountValue = (Price * DiscountPercentage) / 100;
                    Discount = DiscountValue;
                    Decimal ToBasCurrencyDiscount = Decimal.Parse(dataGridView2.CurrentRow.Cells[16].Value.ToString());
                    //This is used to set the bas currency discount value to changed discount during cell edit;
                    dataGridView2.CurrentRow.Cells[11].Value = Math.Round(Discount * Qty, 2);
                    CurQty = Decimal.Parse(dataGridView2.CurrentRow.Cells[18].Value.ToString());
                    if (Qty > CurQty)
                    {
                        MessageBox.Show("Only you have " + CurQty + " Quantity for selected item in the stock");
                        dataGridView2.CurrentRow.Cells[5].Value = CurQty.ToString();
                        return;
                    }
                    dataGridView2.CurrentRow.Cells[11].Value = Math.Round(Discount * Qty, 2);
                    dataGridView2.CurrentRow.Cells[17].Value = Math.Round(ToBasCurrencyDiscount * Qty, 2);
                    dataGridView2.CurrentRow.Cells[8].Value = Math.Round(Discount, 2);
                    dataGridView2.CurrentRow.Cells[10].Value = Math.Round((Price - Discount) * Qty, 2);
                }
                txt_grand_total.Text = dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString();
                SetSubTotal();
                Clear();
            }
            catch (Exception ex)
            {

            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            InsertSaleOrder();
        }
        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            txt_grand_total.Text = dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString();
            SetSubTotal();
        }
        public string GetOrderNo()
        {
            String VCode = "";
            Int32 ID = 0;
            String Code = "";
            string str_value = "";
            DataTable dtToDayDate = obj.GetData("select replace(convert(varchar, getdate(),103),'/','') as TodayDate");
            string TodayDate = conclass.StoreID + dtToDayDate.Rows[0]["TodayDate"].ToString();
            DataTable dt = obj.GetData(@"select isnull(MAX(right(InvoiceNo,3)),0) as nextid from IMIS_tblSaleOrderMain where StoreID=" + conclass.StoreID + " and substring(InvoiceNo,0,10)='" + TodayDate + "'");
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
        public void InsertSaleOrder()
        {
            string InvoiceNo = GetOrderNo();
            long MaxID = conclass.nextid("FMIS_tblCustomerStatement", "ID");
            //Int64 SNO = conclass.nextid("IMIS_tblSaleOrderMain", "SNO");
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
						 values('" + InvoiceNo + "', '" + cmbCustomer.SelectedValue + "','" + cmbPaymentMethod.Text + "', " + txt_grand_total.Text + ", " + txtPaidAmount.Text + ", " + TotalBalanceAmount + ", " + cmbCurrency.SelectedValue + ", " + txtExchangeRate.Text + ", " + Total_Base_Currency_Amount + ", " + Total_Base_Currency_Paid_Amount + ", " + Total_Base_Currency_Balance_Amount + ", null, 'Sold', '" + conclass.User_ID + "'," + conclass.StoreID + ")";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"insert into IMIS_tblSaleManTransaction(SaleManID, InvoiceNo, InvoiceAmount, StoreID, Status, UserID) values(1, '" + InvoiceNo + "', " + Total_Base_Currency_Amount + ", " +conclass.StoreID + ", 'Pending', N'" + conclass.User_ID + "')";
                cmd.ExecuteNonQuery();
                if (cmbPaymentAccount.Text != "Loan")
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
                    cmd.CommandText = "select * from FMIS_tblCustomerStatement where CustomerID=" + cmbCustomer.SelectedValue + " and StoreID=" + conclass.StoreID + " and CurrencyID=" + cmbCurrency.SelectedValue + " and ReferenceType='Opening Balance'";
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
                    cmd.CommandText = "select isnull(Balance,0) As Balance from FMIS_tblCustomerStatement where CustomerID=" + cmbCustomer.SelectedValue + " and StoreID=" + conclass.StoreID + " and CurrencyID=" + cmbCurrency.SelectedValue + " and ReferenceType='Opening Balance'";
                    SqlDataAdapter daLastBalnce = new SqlDataAdapter(cmd);
                    daLastBalnce.Fill(dtLastBalance);

                    //This Query will give the Sum Of Credit
                    cmd.CommandText = "select isnull(Sum(Credit),0) As SumOfCredit from FMIS_tblCustomerStatement where CustomerID=" + cmbCustomer.SelectedValue + " and StoreID=" + conclass.StoreID + " and CurrencyID=" + cmbCurrency.SelectedValue + "";
                    SqlDataAdapter daSumOfCredit = new SqlDataAdapter(cmd);
                    daSumOfCredit.Fill(dtSumOfCredit);

                    //This Query will give the Sum Of Debit
                    cmd.CommandText = "select isnull(Sum(Debit),0) As SumOfDebit from FMIS_tblCustomerStatement where CustomerID=" + cmbCustomer.SelectedValue + " and StoreID=" + conclass.StoreID + " and CurrencyID=" + cmbCurrency.SelectedValue + "";
                    SqlDataAdapter daSumOfDebit = new SqlDataAdapter(cmd);
                    daSumOfDebit.Fill(dtSumOfDebit);

                    if (dtLastBalance.Rows.Count > 0 && dtSumOfCredit.Rows.Count > 0 && dtSumOfDebit.Rows.Count > 0)
                    {
                        LastCustomerBalance = Decimal.Parse(dtLastBalance.Rows[0]["Balance"].ToString());
                        TotalCredit = Decimal.Parse(dtSumOfCredit.Rows[0]["SumOfCredit"].ToString());
                        TotalDebit = Decimal.Parse(dtSumOfDebit.Rows[0]["SumOfDebit"].ToString()) + Decimal.Parse(txtBalance.Text);
                        //Formula
                        NewCustomerBalance = (LastCustomerBalance + TotalDebit) - TotalCredit;
                    }
                    #endregion
                    cmd.CommandText = @"insert into FMIS_tblCustomerStatement(ID, CustomerID, StoreID, ReferenceType,ReferenceNumber, Particulars, CurrencyID,ExchangeRate, Debit, Credit, Balance, UserID) 
                values(" + MaxID + "," + cmbCustomer.SelectedValue + "," + conclass.StoreID + ", 'Sales Invoice','" + InvoiceNo + "', N'Sales Invoice'," + cmbCurrency.SelectedValue + "," + txtExchangeRate.Text + "," + txtBalance.Text + ",0," + NewCustomerBalance + ", '" + conclass.User_ID + "')";
                    cmd.ExecuteNonQuery();
                    #endregion
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
                    int CurrencyID = int.Parse(cmbCurrency.SelectedValue.ToString());
                    try
                    {
                        ItemCode = gr.Cells[0].Value.ToString();
                        Qty = Decimal.Parse(gr.Cells[5].Value.ToString());
                        SalePrice = Decimal.Parse(gr.Cells[6].Value.ToString());
                        BatchNo = gr.Cells[3].Value.ToString();
                        iYear = gr.Cells[13].Value.ToString();
                        iMonth = gr.Cells[14].Value.ToString();
                        ExpiryDate = DateTime.Parse("01/" + iMonth + "/" + iYear).ToString("dd/MM/yyyy");
                        ProductStockID = gr.Cells[12].Value.ToString();
                        Discount = Decimal.Parse(gr.Cells[8].Value.ToString());
                        AvgPrice = Decimal.Parse(gr.Cells[9].Value.ToString());
                        Total = Decimal.Parse(gr.Cells[10].Value.ToString());
                        ExchangeRate = Decimal.Parse(txtExchangeRate.Text);
                        BaseCurrencyDiscount = ToBaseCurrencyPrice(Discount, CurrencyID, ExchangeRate);
                        BaseCurrencySalePrice = ToBaseCurrencyPrice(SalePrice, CurrencyID, ExchangeRate);
                        TotalBasCurrencyTotal = (BaseCurrencySalePrice - BaseCurrencyDiscount) * Qty;
                        BaseCurrencyProfitPerUnit = (BaseCurrencySalePrice - BaseCurrencyDiscount) - AvgPrice;
                        TotalBaseCurrencyProfit = BaseCurrencyProfitPerUnit * Qty;
                    }
                    catch (Exception exxx)
                    {
                        MessageBox.Show(exxx.Message.ToString());
                        return;
                    }
                    if (obj.con.State == ConnectionState.Closed)
                        obj.con.Open();
                    cmd.CommandText = @"insert into IMIS_tblSaleOrderDetail(InvoiceNo, ProductCode, BatchNo,ExpiryDate,ProductStockID,Quantity, BaseCurrencyAveragePrice, SalePrice,Discount, CurrencyID, ExchangeRate, BaseCurrencySalePrice,BaseCurrencyDiscount,BaseCurrencyProfitPerUnit, TotalBaseCurrencyProfit, Total, BaseCurrencyTotal, Status) 
					values('" + InvoiceNo + "', '" + ItemCode + "', '" + BatchNo + "','" + ExpiryDate + "'," + ProductStockID + "," + Qty + ", " + AvgPrice + ", " + SalePrice + "," + Discount + ", " + CurrencyID + ", " + ExchangeRate + ", " + BaseCurrencySalePrice + "," + BaseCurrencyDiscount + "," + BaseCurrencyProfitPerUnit + ", " + TotalBaseCurrencyProfit + ", " + Total + ", " + TotalBasCurrencyTotal + ", 'Sold')";
                    cmd.ExecuteNonQuery();
                    #region Stock Update
                    cmd.CommandText = @"update IMIS_tblStock set Quantity=Quantity-" + Qty + " where  ID='" + ProductStockID + "'";
                    cmd.ExecuteNonQuery();
                    #endregion
                }
                tran.Commit();

                if (MessageBox.Show("Invoice Saved Successfully With SNO: " + InvoiceNo + "\r\t Do you want to Print", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    Boolean checkStatus = false;
                    if (chkA4Size.Checked == true)
                        checkStatus = true;
                    else
                        checkStatus = false;
                    printInvoice(InvoiceNo,true);
                    pnlPayment.Visible = false;
                    pnlPayment.Location = new Point(1149, 56);
                    panel1.Enabled = true;
                    dataGridView2.Rows.Clear();
                    txt_grand_total.Text = "0";
                    txtSubTotal.Text = "";
                    txtPaidAmount.Text = "0";
                    txtBalance.Text = "0";
                    btnSave.Enabled = true;
                    cmbPaymentMethod.Text = "Cash";
                    cmbPaymentMethod_SelectionChangeCommitted(null, null);
                    CashCustomer();
                }
                else
                {
                    pnlPayment.Visible = false;
                    pnlPayment.Location = new Point(1149, 56);
                    panel1.Enabled = true;
                    dataGridView2.Rows.Clear();
                    txt_grand_total.Text = "0";
                    txtSubTotal.Text = "";
                    txtPaidAmount.Text = "0";
                    txtBalance.Text = "0";
                    btnSave.Enabled = true;
                    cmbPaymentMethod.Text = "Cash";
                    cmbPaymentMethod_SelectionChangeCommitted(null, null);

                    CashCustomer();

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
        }
        private void printInvoice(string InvoiceNumber, bool PageSize)
        {

            DataTable dtPrinter = conclass.GetRecord(@"SELECT   LaserPrinterName, TerminalPrinterName, ShowPrintPreview FROM IMIS_tblPrinterSetting where UserID='" + conclass.User_ID + "'");
            if (dtPrinter.Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = conclass.GetRecord(@"SELECT InvoiceNo,CustomerID,ExchangeRate, CONVERT(varchar(12), SaleOrderDate, 106) AS SaleOrderDate, CONVERT(varchar(5), SaleOrderTime, 108) AS SaleOrderTime, CustomerName, PaymentMethod, ProductCode, UPPER(ProductName) 
                  + ' - ' + SizeName + ' ' + SUBSTRING(CONVERT(varchar(12), ExpiryDate, 101), 4, 10) AS ProductName, Quantity, BaseCurrencySalePrice, BaseCurrencyTotal, CurrencyName, StoreID, TotalOrderAmount, TotalPaidAmount, BalanceAmount, 
                  SalePrice, Discount, Total, TotalDiscount, NetTotal, Status, StoreName, StoreNameLocal, Address, BusinessLogo, ContactNumber1, CashReturnToCustomer, UserName, AddressLocal,UnitName
FROM     IMIS_VWSaleOrderInvoice   where Status <> 'Full Returned' and InvoiceNo='" + InvoiceNumber + "' and StoreID=" + conclass.StoreID + "");
                if (PageSize == false)
                {
                    Reports.Sale_Invoice_AlKhairCenter obj = new Stock_System.Reports.Sale_Invoice_AlKhairCenter();
                    obj.SetDataSource(dt);
                    Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
                    obj.PrintOptions.PrinterName = dtPrinter.Rows[0]["TerminalPrinterName"].ToString();
                    obj.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                    //crViewer.ReportSource = vrptSalesInvoice;
                    frm2.crystalReportViewer1.ReportSource = obj;
                    if (dtPrinter.Rows[0]["ShowPrintPreview"].ToString() == "True")
                        frm2.ShowDialog();
                    obj.PrintToPrinter(1, false, 0, 0);
                }
                else if (PageSize == true)
                {
                    Reports.rptSaleInvoice obj = new Stock_System.Reports.rptSaleInvoice();
                    obj.SetDataSource(dt);
                    Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
                    obj.PrintOptions.PrinterName = dtPrinter.Rows[0]["LaserPrinterName"].ToString();
                    //obj.PrintOptions.PrinterName = "PB-A11P Miniprinter";
                    //obj.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                    //crViewer.ReportSource = vrptSalesInvoice;
                    frm2.crystalReportViewer1.ReportSource = obj;
                    if (dtPrinter.Rows[0]["ShowPrintPreview"].ToString() == "True")
                        frm2.ShowDialog();
                    obj.PrintToPrinter(1, false, 0, 0);
                }
            }
        }
        #region Customer
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
            txtitemName.Focus();
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
                    DataTable dt = obj.GetData(@"SELECT    CustomerID, CustomerName,CustomerAddress FROM IMIS_tblCustomer where CustomerID=" + Id + "");
                    cmbCustomer.SelectedValue = dt.Rows[0]["CustomerID"].ToString();
                    pnlCustomer.SendToBack();
                    pnlCustomer.Visible = false;
                    txtitemName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chose Customer From the list");
            }
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
            FillCustomerSaveView();
            ClearCustomer();
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
            FillCustomerSaveView();
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
        private void lstCustomerSaveView_Click(object sender, EventArgs e)
        {
            string Id = lstCustomerSaveView.SelectedItems[0].SubItems[0].Text;
            DataTable dt = obj.GetData(@"SELECT        CustomerID, CustomerName, MobileNumber, EmailAddress, ContactPerson, CustomerAddress
FROM            IMIS_tblCustomer where CustomerID=" + Id + "");
            txtCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
            lblCustomerID.Text = dt.Rows[0]["CustomerID"].ToString();
            txtCustomerMobile.Text = dt.Rows[0]["MobileNumber"].ToString();
            txtCustomerEmailAddress.Text = dt.Rows[0]["EmailAddress"].ToString();
            txtCustomerContactPerson.Text = dt.Rows[0]["ContactPerson"].ToString();
            txtCustomerAddress.Text = dt.Rows[0]["CustomerAddress"].ToString();
            btnSaveCustomer.Text = "Update";
        }
        #endregion
        private void lstCustomerSearchView_DoubleClick(object sender, EventArgs e)
        {
            string Id = lstCustomerSearchView.SelectedItems[0].SubItems[0].Text;
            DataTable dt = obj.GetData(@"SELECT    CustomerID, CustomerName,CustomerAddress FROM IMIS_tblCustomer where CustomerID=" + Id + "");
            cmbCustomer.SelectedValue = dt.Rows[0]["CustomerID"].ToString();
            pnlCustomer.SendToBack();
            pnlCustomer.Visible = false;
            txtitemName.Focus();
        }
        private void lstCustomerSaveView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Id = lstCustomerSaveView.SelectedItems[0].SubItems[0].Text;
                DataTable dt = obj.GetData(@"SELECT        CustomerID, CustomerName, MobileNumber, EmailAddress, ContactPerson, CustomerAddress
FROM            IMIS_tblCustomer where CustomerID=" + Id + "");
                txtCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
                lblCustomerID.Text = dt.Rows[0]["CustomerID"].ToString();
                txtCustomerMobile.Text = dt.Rows[0]["MobileNumber"].ToString();
                txtCustomerEmailAddress.Text = dt.Rows[0]["EmailAddress"].ToString();
                txtCustomerContactPerson.Text = dt.Rows[0]["ContactPerson"].ToString();
                txtCustomerAddress.Text = dt.Rows[0]["CustomerAddress"].ToString();
                btnSaveCustomer.Text = "Update";
            }
        }
        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData("select InvoiceNo,SNO from IMIS_tblSaleOrderMain  where SNO=(select max(SNO) from IMIS_tblSaleOrderMain where StoreID=" + conclass.StoreID + " and UserID='" + conclass.User_ID + "')");
            if (dt.Rows.Count > 0)
                txtInvoiceNumberPrint.Text = dt.Rows[0]["SNO"].ToString();
            pnlPrint.BringToFront();
            pnlPrint.Visible = true;
            pnlPrint.Location = new Point(607, 592);
        }
        private void btnClosePrint_Click(object sender, EventArgs e)
        {
            pnlPrint.SendToBack();
            pnlPrint.Visible = false;
            txtitemName.Focus();
        }
        private void btnPrintOld_Click(object sender, EventArgs e)
        {
            Boolean PageSize = false;
            if (chkA4Reprint.Checked == true)
                PageSize = true;
            else
                PageSize = false;
            printInvoice(txtInvoiceNumberPrint.Text, PageSize);
            pnlPrint.Visible = false;
            pnlPrint.SendToBack();
            txtitemName.Focus();
        }
        private void txtitemName_TextChanged(object sender, EventArgs e)
        {
            gpitem_list.Visible = true;
            gpitem_list.BringToFront();
            txtProductSearch.Focus();
        }
        private void txtitemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            gpitem_list.Visible = true;
            gpitem_list.BringToFront();
            txtProductSearch.Text = "";
            txtProductSearch.Focus();
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
                values(" + MaxID + "," + cmbCustomer.SelectedValue + "," + conclass.StoreID + ", 'Opening Balance', N'Opening Balance'," + cmbCurrency.SelectedValue + "," + txtExchangeRate.Text + ",0,0," + txtOpeningBalance.Text + ", '" + conclass.User_ID + "')";
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
        private void btnDiscount_Click(object sender, EventArgs e)
        {
            pnlDiscount.Visible = true;
            pnlDiscount.BringToFront();
            pnlDiscount.Location = new Point(450, 350);
            txtDiscountPercentage.Focus();
        }
        private void btnSetDiscount_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow gr in dataGridView2.Rows)
            {
                Decimal Qty = Decimal.Parse(gr.Cells[5].Value.ToString());
                Decimal SalePrice = Decimal.Parse(gr.Cells[6].Value.ToString());
                gr.Cells[10].Value = SalePrice * Qty;
                gr.Cells[7].Value = 0;
                gr.Cells[8].Value = 0;
            }

            txt_grand_total.Text = dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString();
           
            SetSubTotal();



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
                    gr.Cells[16].Value = Math.Round(ToBasCurrencyDiscount, 2);
                    //Set Base Currency Discount
                    // column 10 is the base currency discount column
                    // first check if the currency base currency than one candation and if other than another candation
                    gr.Cells[11].Value = Math.Round(DiscountValue * Qty, 2);
                    gr.Cells[17].Value = Math.Round(ToBasCurrencyDiscount * Qty, 2);
                    gr.Cells[8].Value = Math.Round(DiscountValue, 2);
                    gr.Cells[7].Value = Math.Round(DiscountPercentage, 2);
                    gr.Cells[10].Value = Math.Round((SalePrice - DiscountValue) * Qty, 2);
                }
            }
            else
            {
                // how to find % tage if we find the value
                foreach (DataGridViewRow gr in dataGridView2.Rows)
                {
                    // Question How to find Discount % tage base on total value discounted
                    // Total Discount Value : 50
                    // Total Invoice Amount: 200
                    // discount value each item:  50/200= 0.25
                    // How to find Discount:  Sale Price* Discount Value= 100*0.25=25
                    // the Discount % tage value is discount value
                    Decimal Qty = Decimal.Parse(gr.Cells[5].Value.ToString());
                    Decimal SalePrice = Decimal.Parse(gr.Cells[6].Value.ToString());
                    Decimal DiscountValue = Decimal.Parse(txtDiscountPercentage.Text);
                    Decimal DiscountRate = 0;
                    Decimal GrandTotal = Decimal.Parse(txt_grand_total.Text);
                    DiscountRate = DiscountValue / GrandTotal;
                    //Decimal Discount = DistributeDiscountPerItem(SalePrice, DiscountValue, Decimal.Parse(txt_grand_total.Text));
                    //This row is for the base currency as bank
                    Decimal ToBasCurrencyDiscount = ToBaseCurrencyPrice((DiscountRate * SalePrice), int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                    gr.Cells[16].Value = Math.Round(ToBasCurrencyDiscount, 2);
                    //gr.Cells[4].Value = Math.Round(Discount, 2);
                    //gr.Cells[6].Value = Math.Round((SalePrice - Discount) * Qty, 2);
                    gr.Cells[11].Value = Math.Round((DiscountRate * SalePrice) * Qty, 2);
                    gr.Cells[17].Value = Math.Round(ToBasCurrencyDiscount * Qty, 2);
                    gr.Cells[8].Value = Math.Round((DiscountRate * SalePrice), 2);
                    gr.Cells[7].Value = Math.Round((DiscountRate * SalePrice), 2);
                    gr.Cells[10].Value = Math.Round((SalePrice - (DiscountRate * SalePrice)) * Qty, 2);
                    //100*Discount Value/total value
                    //=100*50/1000
                    // we will work on this to find the issue and slow the issue
                }
            }
            txt_grand_total.Text = dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString();
            Decimal SubTotal = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString());
            Decimal TotalDiscount = Decimal.Parse(dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[11].Value.ToString())).ToString());
            
            //InsertCustomerDisplay(SubTotal + TotalDiscount, TotalDiscount, SubTotal);
            SetSubTotal();
            pnlDiscount.Visible = false;
            pnlDiscount.SendToBack();
            txtitemName.Focus();
        }
        private void btnCloseDiscount_Click(object sender, EventArgs e)
        {
            pnlDiscount.Visible = false;
            pnlDiscount.SendToBack();
            txtitemName.Focus();
        }
        private void txtDiscountValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AddToList();
        }
        private void txtDiscountValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtTotal.Text = string.Empty;
                
                if (txtQty.Text.Trim() != string.Empty && this.txtPrice.Text.Trim() != string.Empty && this.txtDiscountPer.Text.Trim() != string.Empty && this.txtDiscountValue.Text.Trim() != string.Empty)
                {
                    Decimal DiscountValue = 0;
                    Decimal DiscountPer = 0;
                    Decimal SalePrice = 0;
                    DiscountValue = Decimal.Parse(txtDiscountValue.Text);
                    SalePrice = Decimal.Parse(txtPrice.Text);
                    DiscountPer = (DiscountValue * 100) / SalePrice;
                    txtDiscountPer.Text =Convert.ToString( Math.Round(DiscountPer,2));
                    Decimal Total = (SalePrice - DiscountValue) * Decimal.Parse(txtQty.Text);
                    txtTotal.Text = Total.ToString();
                }
            }
            catch (Exception)
            {

            }

        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow gr in dataGridView2.Rows)
            {
                Decimal Qty = Decimal.Parse(gr.Cells[5].Value.ToString());
                Decimal SalePrice = Decimal.Parse(gr.Cells[6].Value.ToString());
                gr.Cells[10].Value = SalePrice * Qty;
                gr.Cells[7].Value = 0;
                gr.Cells[8].Value = 0;
            }
            txt_grand_total.Text = dataGridView2.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString();
            SetSubTotal();
        }

       
    }
}

