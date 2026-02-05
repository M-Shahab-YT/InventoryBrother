using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Stock_System.Class;
using System.Drawing.Printing;

namespace Stock_System.Forms
{
    public partial class SalesReturnUpdate : Form
    {
        Class.Dbcommon obj = new Stock_System.Class.Dbcommon();
        public SalesReturnUpdate()
        {
            InitializeComponent();
        }

        private void btnSearchCustomerOrders_Click(object sender, EventArgs e)
        {

        }


        int rowNo = 1;
        private void AddToReturnList()
        {
            bool status = false;
            if (txtQtyToReturn.Text == "")
            {
                txtQtyToReturn.Focus();
                txtQtyToReturn.BackColor = Color.Red;
                txtQtyToReturn.ForeColor = Color.Yellow;
                return;
            }

            if (Decimal.Parse(txtQtyToReturn.Text) < 0)
            {
                txtQtyToReturn.Focus();
                txtQtyToReturn.BackColor = Color.Red;
                txtQtyToReturn.ForeColor = Color.Yellow;
                return;
            }
            if (Decimal.Parse(txtQtyToReturn.Text) == 0)
            {
                txtQtyToReturn.BackColor = Color.Red;
                txtQtyToReturn.ForeColor = Color.Yellow;
                txtQtyToReturn.Focus();
                return;
            }
            if (Decimal.Parse(txtQtyToReturn.Text) > Decimal.Parse(txtSoldQty.Text))
            {
                txtQtyToReturn.BackColor = Color.Red;
                txtQtyToReturn.ForeColor = Color.Yellow;
                txtQtyToReturn.Focus();
                return;
            }

            string StockID = ProductStockID1.Text;
            string SNO = SNO1.Text;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[15].Value.ToString().Equals(StockID) && row.Cells[1].Value.ToString().Equals(SNO))
                {
                   

                    Decimal QtySoldAdded = Decimal.Parse(row.Cells[5].Value.ToString());
                    Decimal QtyToReturnAdded = Decimal.Parse(row.Cells[6].Value.ToString());
                    Decimal QtyToReturn = Decimal.Parse(txtQtyToReturn.Text);
                    if ((QtyToReturnAdded + QtyToReturn) > QtySoldAdded)
                    {
                        string message = "Item already added once, overall you can return: " + QtySoldAdded + " quantity.";
                        MessageBox.Show(message);
                        txtQtyToReturn.Focus();
                        return;
                    }

                    Decimal TotalQtyToReturn = 0;
                    TotalQtyToReturn = QtyToReturnAdded + QtyToReturn;
                    Decimal SalePrice = Decimal.Parse(row.Cells[7].Value.ToString());
                    Decimal DiscountValue = Decimal.Parse(row.Cells[8].Value.ToString());




                    Decimal ReturnTotal = (SalePrice - DiscountValue) * TotalQtyToReturn;
                    row.Cells[6].Value = Math.Round(TotalQtyToReturn, 2);
                    row.Cells[10].Value = Math.Round(ReturnTotal, 2);
                    row.Cells[7].Value = Math.Round(ReturnTotal, 2);




                    ////This row is for the base currency as bank
                    //ToBasCurrencyDiscount = ToBaseCurrencyPrice(DiscountValue, int.Parse(cmbCurrency.SelectedValue.ToString()), Decimal.Parse(txtExchangeRate.Text));
                    //row.Cells[14].Value = Math.Round(ToBasCurrencyDiscount, 2);
                    ////Set Base Currency Discount
                    //// column 10 is the base currency discount column
                    //// first check if the currency base currency than one candation and if other than another candation
                    //row.Cells[8].Value = Math.Round(DiscountValue, 2);
                    ////this is for the total discount column
                    //row.Cells[15].Value = Math.Round(DiscountValue * TotalQty, 2);
                    ////this is for the row toal
                    //row.Cells[10].Value = Math.Round((SalePrice1 - DiscountValue) * TotalQty, 2);
                    //row.Cells[5].Value = TotalQty;
                    status = true;
                    break;
                }
            }

            if (status == false)
            {
                Decimal Total1 = (Decimal.Parse(SalePrice1.Text) - Decimal.Parse(Discount1.Text)) * Decimal.Parse(txtSoldQty.Text);
                Decimal ReturnTotal1 = (Decimal.Parse(SalePrice1.Text) - Decimal.Parse(Discount1.Text)) * Decimal.Parse(txtQtyToReturn.Text);

                string[] rowToAdd = new string[] { rowNo.ToString(), SNO1.Text, txtitemName.Tag.ToString(), txtitemName.Text, txtExpiryDate.Text, txtSoldQty.Text, txtQtyToReturn.Text, SalePrice1.Text, Discount1.Text, Total1.ToString(), ReturnTotal1.ToString(), BaseCurrencyProfitPerUnit1.Text, BaseCurrencySalePrice1.Text, SalesManID1.Text, BaseCurrencyDiscount1.Text, ProductStockID1.Text, InvoiceNumber.Text };
                dataGridView1.Rows.Add(rowToAdd);
            }
            rowNo++;

            txtReturnTotal.Text = dataGridView1.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString();
            ClearAfterAddToList();

        }

        private void SalesReturnUpdate_Load(object sender, EventArgs e)
        {
            obj.fillcmb(cmbPaymentAccount, "AccountName", "AccountID", "SELECT  AccountID, AccountName FROM FMIS_tblCashAccounts where  CurrencyID=1 and StoreID=" + conclass.StoreID + "");
            cmbReturnMethod.Text = "Cash";
            cmbReturnMethod_SelectionChangeCommitted(null, null);
            txtCustomerIDSearch.Focus();
        }

        private void SalesReturnUpdate_Shown(object sender, EventArgs e)
        {
            txtCustomerIDSearch.Focus();
        }

        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCustomerIDSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (rbSearchByCustomerID.Checked == true && txtCustomerIDSearch.Text != "" && e.KeyCode == Keys.Enter)
            {
                DataTable dt = obj.GetData(@"SELECT   CustomerID, CustomerName, MobileNumber, CustomerAddress FROM   IMIS_tblCustomer where CustomerID='" + txtCustomerIDSearch.Text.Trim() + "'");
                if (dt.Rows.Count > 0)
                {
                    lblCustomerID.Text = dt.Rows[0]["CustomerID"].ToString();
                    lblCustomerName1.Text = dt.Rows[0]["CustomerName"].ToString();
                    txtProductSearch.Text = "";
                    txtProductSearch.Focus();
                }

            }
            else if (rdSearchByInvoiceNo.Checked == true && txtCustomerIDSearch.Text != "" && e.KeyCode == Keys.Enter)
            {
                FillByInvoiceNo();
                if (lstCustomerOrder.Items.Count > 0)
                {
                    lstCustomerOrder.Items[0].Selected = true;
                    lstCustomerOrder.Items[0].EnsureVisible();
                    lstCustomerOrder.Select();
                    lstCustomerOrder.Focus();
                }
            }
        }

        private void FillByInvoiceNo()
        {

            DataTable dt = obj.GetData(@"SELECT 
    IMIS_tblSaleOrderDetail.InvoiceNo, 
    IMIS_tblSaleOrderDetail.SNO, 
    IMIS_tblSaleOrderDetail.ProductCode, 
    IMIS_VWProducts.ProductName, 
    IMIS_tblSaleOrderDetail.Quantity AS SoldQty, 
    IMIS_tblSaleOrderDetail.Quantity, 
    dbo.fn_GetReturnedQuantity(IMIS_tblSaleOrderDetail.ProductCode, IMIS_tblSaleOrderDetail.SNO) AS ReturnedQty,
    (IMIS_tblSaleOrderDetail.Quantity - dbo.fn_GetReturnedQuantity(IMIS_tblSaleOrderDetail.ProductCode, IMIS_tblSaleOrderDetail.SNO)) AS NetQuantity,
    IMIS_tblSaleOrderDetail.SalePrice, 
    IMIS_tblSaleOrderDetail.Discount, 
    IMIS_tblSaleOrderDetail.Total, 
    IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, 
    IMIS_tblSaleOrderDetail.BaseCurrencyTotal, 
    IMIS_tblSaleOrderDetail.BaseCurrencySalePrice, 
    IMIS_tblSaleOrderDetail.BatchNo, 
    CONVERT(varchar(12), IMIS_tblSaleOrderDetail.ExpiryDate, 106) AS ExpiryDate, 
    IMIS_tblSaleOrderDetail.ProductStockID, 
    IMIS_tblSaleMan.SaleManName, 
    ISNULL(IMIS_tblSaleOrderDetail.BaseCurrencyDiscount, 0) AS BaseCurrencyDiscount, 
    IMIS_tblSaleOrderDetail.SalesManID, 
    IMIS_tblSaleOrderDetail.SalesPercentage, 
    IMIS_tblSaleMan.StoreID,
    IMIS_tblSaleOrderDetail.SalesPercentage AS Expr1, 
    IMIS_tblSaleOrderMain.CustomerID, 
    IMIS_tblSaleOrderDetail.SystemDate, 
    CONVERT(varchar(12), IMIS_tblSaleOrderMain.SaleOrderDate, 107) AS SaleOrderDate, 
    CONVERT(varchar(8), IMIS_tblSaleOrderMain.SaleOrderTime, 113) AS SaleOrderTime, 
    IMIS_tblCustomer.CustomerName
FROM 
    IMIS_tblSaleOrderDetail 
    INNER JOIN IMIS_VWProducts ON IMIS_tblSaleOrderDetail.ProductCode = IMIS_VWProducts.ProductCode 
    INNER JOIN IMIS_tblSaleMan ON IMIS_tblSaleOrderDetail.SalesManID = IMIS_tblSaleMan.SaleManID 
    INNER JOIN IMIS_tblSaleOrderMain ON IMIS_tblSaleOrderDetail.InvoiceNo = IMIS_tblSaleOrderMain.InvoiceNo 
    INNER JOIN IMIS_tblCustomer ON IMIS_tblSaleOrderMain.CustomerID = IMIS_tblCustomer.CustomerID
WHERE   (IMIS_tblSaleOrderDetail.InvoiceNo = '" + txtCustomerIDSearch.Text.Trim() + "') AND (IMIS_tblSaleOrderDetail.Quantity - dbo.fn_GetReturnedQuantity(IMIS_tblSaleOrderDetail.ProductCode, IMIS_tblSaleOrderDetail.SNO)) > 0  ORDER BY     IMIS_tblSaleOrderDetail.SNO");

            lstCustomerOrder.Items.Clear();

            if (dt.Rows.Count > 0)
            {
                lblCustomerID.Text = dt.Rows[0]["CustomerID"].ToString();
                lblCustomerName1.Text = dt.Rows[0]["CustomerName"].ToString();

            }
            foreach (DataRow dr in dt.Rows)
            {

                ListViewItem item = new ListViewItem(dr["SNO"].ToString());
                item.SubItems.Add(dr["InvoiceNo"].ToString());
                item.SubItems.Add(dr["ProductCode"].ToString());
                item.SubItems.Add(dr["ProductName"].ToString());
                item.SubItems.Add(dr["SaleOrderDate"].ToString());
                item.SubItems.Add(dr["SaleOrderTime"].ToString());
                item.SubItems.Add(dr["NetQuantity"].ToString());
                item.SubItems.Add(dr["SalePrice"].ToString());
                item.SubItems.Add(dr["Discount"].ToString());
                item.SubItems.Add(dr["ExpiryDate"].ToString());
                item.SubItems.Add(dr["BaseCurrencyProfitPerUnit"].ToString());
                item.SubItems.Add(dr["BaseCurrencySalePrice"].ToString());
                item.SubItems.Add(dr["ProductStockID"].ToString());
                item.SubItems.Add(dr["SalesManID"].ToString());
                item.SubItems.Add(dr["SalesPercentage"].ToString());
                item.SubItems.Add(dr["BaseCurrencyDiscount"].ToString());
                lstCustomerOrder.Items.Add(item);
            }
            if (lstCustomerOrder.Items.Count > 0)
            {
                lstCustomerOrder.Items[0].Selected = true;
                lstCustomerOrder.Items[0].EnsureVisible();
                lstCustomerOrder.Select();
                lstCustomerOrder.Focus();
            
            }
           
        }
        private void txtProductSearch_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {

                if (txtProductSearch.Text != "")
                {
                    DataTable dt = obj.GetData(@"
SELECT TOP 100 
    d.InvoiceNo, 
    d.SNO, 
    d.ProductCode, 
    p.ProductName, 
    d.Quantity AS SoldQty, 
    d.Quantity, 
    dbo.fn_GetReturnedQuantity(d.ProductCode, d.SNO) AS ReturnedQty,
    (d.Quantity - dbo.fn_GetReturnedQuantity(d.ProductCode, d.SNO)) AS NetQuantity,
    d.SalePrice, 
    d.Discount, 
    d.Total, 
    d.BaseCurrencyProfitPerUnit, 
    d.BaseCurrencyTotal, 
    d.BaseCurrencySalePrice, 
    d.BatchNo, 
    CONVERT(varchar(12), d.ExpiryDate, 106) AS ExpiryDate, 
    d.ProductStockID, 
    s.SaleManName, 
    ISNULL(d.BaseCurrencyDiscount, 0) AS BaseCurrencyDiscount, 
    d.SalesManID, 
    d.SalesPercentage, 
    s.StoreID, 
    d.SalesPercentage AS Expr1, 
    m.CustomerID, 
    c.CustomerName,
    d.SystemDate, 
    CONVERT(varchar(12), m.SaleOrderDate, 107) AS SaleOrderDate, 
    CONVERT(varchar(8), m.SaleOrderTime, 113) AS SaleOrderTime
FROM 
    IMIS_tblSaleOrderDetail d
    INNER JOIN IMIS_VWProducts p ON d.ProductCode = p.ProductCode 
    INNER JOIN IMIS_tblSaleMan s ON d.SalesManID = s.SaleManID 
    INNER JOIN IMIS_tblSaleOrderMain m ON d.InvoiceNo = m.InvoiceNo
    INNER JOIN IMIS_tblCustomer c ON m.CustomerID = c.CustomerID
WHERE 
     m.CustomerID = " + lblCustomerID.Text + @"
 
    AND p.ProductName LIKE N'" + txtProductSearch.Text.Trim() + @"%'
    AND (d.Quantity - dbo.fn_GetReturnedQuantity(d.ProductCode, d.SNO)) > 0
ORDER BY 
    SaleOrderDate, SaleOrderTime DESC
");

                    lstCustomerOrder.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {

                        ListViewItem item = new ListViewItem(dr["SNO"].ToString());
                        item.SubItems.Add(dr["InvoiceNo"].ToString());
                        item.SubItems.Add(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["SaleOrderDate"].ToString());
                        item.SubItems.Add(dr["SaleOrderTime"].ToString());
                        item.SubItems.Add(dr["NetQuantity"].ToString());
                        item.SubItems.Add(dr["SalePrice"].ToString());
                        item.SubItems.Add(dr["Discount"].ToString());
                        item.SubItems.Add(dr["ExpiryDate"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyProfitPerUnit"].ToString());
                        item.SubItems.Add(dr["BaseCurrencySalePrice"].ToString());
                        item.SubItems.Add(dr["ProductStockID"].ToString());
                        item.SubItems.Add(dr["SalesManID"].ToString());
                        item.SubItems.Add(dr["SalesPercentage"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyDiscount"].ToString());
                        lstCustomerOrder.Items.Add(item);

                    }
                }
            }
            if (e.KeyCode == Keys.Enter && lstCustomerOrder.Items.Count > 0)
            {
                lstCustomerOrder.Items[0].Selected = true;
                lstCustomerOrder.Items[0].EnsureVisible();
                lstCustomerOrder.Select();
                lstCustomerOrder.Focus();
            }
        }

        private void lstCustomerOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
              ChoseToAdd();
        }

        private void ChoseToAdd()
        {
            txtitemName.Text = lstCustomerOrder.SelectedItems[0].SubItems[3].Text;
            txtitemName.Tag = lstCustomerOrder.SelectedItems[0].SubItems[2].Text;
            txtSoldQty.Text = lstCustomerOrder.SelectedItems[0].SubItems[6].Text;
            txtExpiryDate.Text = lstCustomerOrder.SelectedItems[0].SubItems[9].Text;
            SNO1.Text = lstCustomerOrder.SelectedItems[0].SubItems[0].Text;
            ItemCode.Text = lstCustomerOrder.SelectedItems[0].SubItems[2].Text;
            SalePrice1.Text = lstCustomerOrder.SelectedItems[0].SubItems[7].Text;
            Discount1.Text = lstCustomerOrder.SelectedItems[0].SubItems[8].Text;
            BaseCurrencySalePrice1.Text = lstCustomerOrder.SelectedItems[0].SubItems[11].Text;
            BaseCurrencyDiscount1.Text = lstCustomerOrder.SelectedItems[0].SubItems[15].Text;
            BaseCurrencyProfitPerUnit1.Text = lstCustomerOrder.SelectedItems[0].SubItems[10].Text;
            SalesManID1.Text = lstCustomerOrder.SelectedItems[0].SubItems[13].Text;
            SalesPercentage1.Text = lstCustomerOrder.SelectedItems[0].SubItems[14].Text;
            ProductStockID1.Text = lstCustomerOrder.SelectedItems[0].SubItems[12].Text;
            InvoiceNumber.Text = lstCustomerOrder.SelectedItems[0].SubItems[1].Text;
            txtQtyToReturn.Text = "";
            txtQtyToReturn.Focus();
        }

        private void ChoseToAddAdvance()
        {
            txtitemName.Text = lstAdvanceSearch.SelectedItems[0].SubItems[3].Text;
            txtitemName.Tag = lstAdvanceSearch.SelectedItems[0].SubItems[2].Text;
            txtSoldQty.Text = lstAdvanceSearch.SelectedItems[0].SubItems[6].Text;
            txtExpiryDate.Text = lstAdvanceSearch.SelectedItems[0].SubItems[9].Text;
            SNO1.Text = lstAdvanceSearch.SelectedItems[0].SubItems[0].Text;
            ItemCode.Text = lstAdvanceSearch.SelectedItems[0].SubItems[2].Text;
            SalePrice1.Text = lstAdvanceSearch.SelectedItems[0].SubItems[7].Text;
            Discount1.Text = lstAdvanceSearch.SelectedItems[0].SubItems[8].Text;
            BaseCurrencySalePrice1.Text = lstAdvanceSearch.SelectedItems[0].SubItems[11].Text;
            BaseCurrencyDiscount1.Text = lstAdvanceSearch.SelectedItems[0].SubItems[15].Text;
            BaseCurrencyProfitPerUnit1.Text = lstAdvanceSearch.SelectedItems[0].SubItems[10].Text;
            SalesManID1.Text = lstAdvanceSearch.SelectedItems[0].SubItems[13].Text;
            SalesPercentage1.Text = lstAdvanceSearch.SelectedItems[0].SubItems[14].Text;
            ProductStockID1.Text = lstAdvanceSearch.SelectedItems[0].SubItems[12].Text;
            InvoiceNumber.Text = lstAdvanceSearch.SelectedItems[0].SubItems[1].Text;

            lblCustomerID.Text = lstAdvanceSearch.SelectedItems[0].SubItems[16].Text;
            lblCustomerName1.Text = lstAdvanceSearch.SelectedItems[0].SubItems[17].Text;
            pnlAdvanceSearch.Visible = false;
            pnlAdvanceSearch.SendToBack();

            foreach (ListViewItem item in lstAdvanceSearch.Items)
            {
                if (item.SubItems[0].Text == SNO1.Text)
                {
                    lstAdvanceSearch.Items.Remove(item);
                    break; // Exit the loop after removing the item
                }
            }





            txtQtyToReturn.Text = "";
            txtQtyToReturn.Focus();
           
        }

        private void txtQtyToReturn_KeyPress(object sender, KeyPressEventArgs e)
        {
            Class.conclass.ASCIn(e);

           
        }

        private void btnAddToReturn_Click(object sender, EventArgs e)
        {
            if (rbSearchByCustomerID.Checked == true)
            {
                AddToReturnList();
                lstCustomerOrder.Items.Clear();
                txtProductSearch.Focus();
               
            }
            else if (rdSearchByInvoiceNo.Checked == true)
            {
                foreach (ListViewItem item in lstCustomerOrder.Items)
                {
                    if (item.SubItems[0].Text == SNO1.Text)
                    {
                        lstCustomerOrder.Items.Remove(item);
                        break; // Exit the loop after removing the item
                    }
                }
                AddToReturnList();

                if (lstCustomerOrder.Items.Count > 0)
                {
                    lstCustomerOrder.Items[0].Selected = true;
                    lstCustomerOrder.Items[0].EnsureVisible();
                    lstCustomerOrder.Select();
                    lstCustomerOrder.Focus();
                }
            }
        }

        private void txtQtyToReturn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAddToReturn_Click(null, null);
        }

        private void ClearAfterAddToList()
        {
            txtitemName.Text = "";
            txtitemName.Tag = "";
            txtExpiryDate.Text = "";
            txtSoldQty.Text = "";
            txtQtyToReturn.Text = "";
            txtQtyToReturn.BackColor = Color.White;
            txtQtyToReturn.ForeColor = Color.Black;
           
            txtProductSearch.Text = "";
            //txtProductSearch.Focus();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            txtReturnTotal.Text = dataGridView1.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => Decimal.Parse(x.Cells[10].Value.ToString())).ToString();
            txtProductSearch.Text = "";
            txtProductSearch.Focus();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Int64 MaxID = conclass.nextid("FMIS_tblCustomerStatement", "ID");
            Int64 SaleReturnID = conclass.nextid("SaleReturnMain", "SaleReturnID");
            long ProductStatementID = conclass.nextid("ProductStatement", "ID");
            obj.con.Open();
            SqlTransaction tran = obj.con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Transaction = tran;
            cmd.Connection = obj.con;

          Decimal  CashReturnToCustomer=0;
          Decimal BaseCurrencyCashReturnToCustomer = 0;
              foreach (DataGridViewRow gr in dataGridView1.Rows)
              {
                  string ItemCode = "";
                  int SNO = 0;
                  string InvoiceNo = "";
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
                  Decimal ReturnTotal = 0;
                  int SalesManID = 0;
                  string ProductStockID = "";
                  bool FullReturn = false;

                  #region Assgin Value
                  SNO = int.Parse(gr.Cells[1].Value.ToString());
                  ItemCode = gr.Cells[2].Value.ToString();
                  SoldQty = Decimal.Parse(gr.Cells[5].Value.ToString());
                  ReturnQty = Decimal.Parse(gr.Cells[6].Value.ToString());

                  ReturnTotal = Decimal.Parse(gr.Cells[10].Value.ToString());
                  SalePrice = Decimal.Parse(gr.Cells[7].Value.ToString());
                  Discount = Decimal.Parse(gr.Cells[8].Value.ToString());
                  SoldTotal = Decimal.Parse(gr.Cells[9].Value.ToString());

                  BaseCurrencyProfitPerUnit = Decimal.Parse(gr.Cells[11].Value.ToString());
                  BaseCurrencySalePrice = Decimal.Parse(gr.Cells[12].Value.ToString());
                  BaseCurrencyDiscount = Decimal.Parse(gr.Cells[14].Value.ToString());
                  SalesManID = int.Parse(gr.Cells[13].Value.ToString());

                  ProductStockID = gr.Cells[15].Value.ToString();
                  InvoiceNo = gr.Cells[16].Value.ToString();

                  if (SoldQty > ReturnQty)
                  {
                      FullReturn = false;
                      TotalBaseCurrencyProfit = (SoldQty - ReturnQty) * BaseCurrencyProfitPerUnit;
                      ReturnTotal = (SoldQty - ReturnQty) * (SalePrice - Discount);
                      TotalBasCurrencyTotal = (SoldQty - ReturnQty) * BaseCurrencySalePrice;
                  }
                  else
                      FullReturn = true;
                  #endregion
                  cmd.CommandText = @"insert into SaleReturnDetail(rate, SaleReturnID,InvoiceNo, RowNumber, ProductCode,ProductStockID, ReturnQuantity, ReturnAmount, SalesmainID, StoreID, ReturnUserID) 
                            values("+SalePrice+"," + SaleReturnID + ",'" + InvoiceNo + "', " + SNO + ", '" + ItemCode + "', " + ProductStockID + " , " + ReturnQty + ", " + ((BaseCurrencySalePrice - BaseCurrencyDiscount) * ReturnQty) + ", " + SalesManID + "," + conclass.StoreID + ", N'" + conclass.User_ID + "')";
                  cmd.ExecuteNonQuery();

                  //if (FullReturn == true)
                  //    cmd.CommandText = @"update IMIS_tblSaleOrderDetail set Status='Full Returned',Remarks='" + ReturnQty + " Items are Returned',LastUpdateBy=N'" + conclass.User_ID + "',LastUpdateDate=getdate(),QuantityReturned=" + ReturnQty + "  where SNO=" + SNO + "";
                  //else
                  //    cmd.CommandText = @"update IMIS_tblSaleOrderDetail set Status='Quantity Returned',Quantity=Quantity-" + ReturnQty + ",QuantityReturned=" + ReturnQty + ",BaseCurrencyTotal=" + TotalBasCurrencyTotal + ",Total=" + ReturnTotal + ",TotalBaseCurrencyProfit=" + TotalBaseCurrencyProfit + ",Remarks='" + ReturnQty + " Items are Returned',LastUpdateBy=N'" + conclass.User_ID + "',LastUpdateDate=getdate()  where SNO=" + SNO + "";
                  //cmd.ExecuteNonQuery();
                  #region Stock Update
                  cmd.CommandText = @"update IMIS_tblStock set Quantity=Quantity+" + ReturnQty + " where  ID=" + ProductStockID + " ";
                  cmd.ExecuteNonQuery();
                  #endregion


                  #region Sale Order Main
//                  DataTable dtSaleOrderMain = new DataTable();
//                  cmd.CommandText = @"SELECT        SNO, InvoiceNo, SaleOrderDate, SaleOrderTime, CustomerID, PaymentMethod, TotalOrderAmount, TotalPaidAmount, BalanceAmount, CurrencyID, ExchangeRate, TotalBaseCurrencyAmount, TotalBaseCurrencyPaidAmount, 
//                         TotalBaseCurrencyBalanceAmount, Remarks, Status, StoreID, UserID, LastUpdateBy, LastUpdateDate, CashReturnToCustomer, BaseCurrencyCashReturnToCustomer
//FROM            IMIS_tblSaleOrderMain where InvoiceNo=" + InvoiceNo + "";
//                  SqlDataAdapter daSaleOrderMain = new SqlDataAdapter(cmd);
//                  daSaleOrderMain.Fill(dtSaleOrderMain);
//                  if (dtSaleOrderMain.Rows.Count > 0)
//                  {
//                      cmd.CommandText = @"update IMIS_tblSaleOrderMain set TotalOrderAmount=TotalOrderAmount-" + ReturnTotal + " , TotalBaseCurrencyAmount=TotalBaseCurrencyAmount-" + TotalBasCurrencyTotal + " where InvoiceNo=" + InvoiceNo + "";
//                      cmd.ExecuteNonQuery();
//                  }

                  #endregion 

                  #region Product Statement
                  string StatementDescription = "Sale Return via Bill no: " + InvoiceNo + " From Customer: " + lblCustomerID.Text;
                  cmd.CommandText = @"insert into ProductStatement(ID, ProductID, ReferenceType, ReferenceNumber, Particulars, Debit, Credit, UserID) 
                             values(" + ProductStatementID + ", '" + ItemCode + "','Sale Return' , '" + SNO + "', N'" + StatementDescription + "', 0," + ReturnQty + ",N'" + conclass.User_ID + "')";
                  cmd.ExecuteNonQuery();
                  ProductStatementID++;
                  #endregion

              }

              #region Sale Return
              cmd.CommandText = @"insert into SaleReturnMain(SaleReturnID, CustomerID, TotalReturnAmount, SaleReturnBy, SaleReturnDate) 
                    values(" + SaleReturnID + ", " + lblCustomerID.Text + ", " + txtReturnTotal.Text + ", N'" + conclass.User_ID + "', getdate())";
              cmd.ExecuteNonQuery();
              #endregion 

              #region Cash Account
            
              #endregion 


              if (cmbReturnMethod.Text == "Cash")
              {
                  cmd.CommandText = @"insert into FMIS_tblCashAccountsInOutDetail(AccountID, Amount, InOutStatus, EntryReference, EntryReferenceNumber, Remarks, UserID,StoreID) values(" + cmbPaymentAccount.SelectedValue + ", " + txtReturnTotal.Text + ", 'Out', 'Sale Return', '" + SaleReturnID + "', N'Sale Return', N'" + conclass.User_ID + "'," + conclass.StoreID + ")";
                  cmd.ExecuteNonQuery();
              }
              else if (cmbReturnMethod.Text == "Credit")
              {
                  cmd.CommandText = @"insert into FMIS_tblCustomerStatement(ID, CustomerID, StoreID, ReferenceType,ReferenceNumber, Particulars, CurrencyID,ExchangeRate, Debit, Credit, UserID) 
                         values(" + MaxID + "," + lblCustomerID.Text + "," + conclass.StoreID + ", 'Sale Return', '" + SaleReturnID + "','Sale Return',1,1,0," + txtReturnTotal.Text + ", '" + conclass.User_ID + "')";
                  cmd.ExecuteNonQuery();
              }












              tran.Commit();
              obj.con.Close();
              if (MessageBox.Show("return succeeded\r\t do you want to print the receipt", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
              {
                  printInvoice(SaleReturnID.ToString(), false);
              }
              ClearAll();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void printInvoice(string InvoiceNumber, bool PageSize)
        {

            //DataTable dtPrinter = conclass.GetRecord(@"SELECT   LaserPrinterName, TerminalPrinterName, ShowPrintPreview FROM IMIS_tblPrinterSetting where UserID='" + conclass.User_ID + "'");
            //if (dtPrinter.Rows.Count > 0)
            //{
            DataTable dt = new DataTable();
            dt = conclass.GetRecord(@"SELECT        ProductCode, ProductName, ReturnQuantity, ReturnAmount, SaleReturnID, InvoiceNo, SaleReturnBy, SaleReturnDate, StoreName, StoreNameLocal, Address, AddressLocal, BusinessLogo, ContactNumber1, ContactNumber2, 
                         Rate, CustomerName, CustomerID, UserName
FROM            VW_SaleReturnForReceipt where SaleReturnID=" + InvoiceNumber + "");
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
                Reports.SaleRetrun obj = new Stock_System.Reports.SaleRetrun();
                obj.SetDataSource(dt);
                Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
                //obj.PrintOptions.PrinterName = dtPrinter.Rows[0]["TerminalPrinterName"].ToString();
                obj.PrintOptions.PrinterName = settings.PrinterName.ToString();
                obj.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                //crViewer.ReportSource = vrptSalesInvoice;
                frm2.crystalReportViewer1.ReportSource = obj;
                obj.PrintToPrinter(2, false, 0, 0);
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
            // }
        }
        private void printInvoiceLast(string CustomerID, bool PageSize, int Qty)
        {

            //DataTable dtPrinter = conclass.GetRecord(@"SELECT   LaserPrinterName, TerminalPrinterName, ShowPrintPreview FROM IMIS_tblPrinterSetting where UserID='" + conclass.User_ID + "'");
            //if (dtPrinter.Rows.Count > 0)
            //{
            DataTable dt = new DataTable();
            dt = conclass.GetRecord(@"SELECT        ProductCode, ProductName, ReturnQuantity, ReturnAmount, SaleReturnID, InvoiceNo, SaleReturnBy, SaleReturnDate, StoreName, StoreNameLocal, Address, AddressLocal, BusinessLogo, ContactNumber1, ContactNumber2, 
                         Rate, CustomerName, CustomerID, UserName
FROM            VW_SaleReturnForReceipt where CustomerID=" + CustomerID + " ");
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
                Reports.SaleRetrun obj = new Stock_System.Reports.SaleRetrun();
                obj.SetDataSource(dt);
                Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
                //obj.PrintOptions.PrinterName = dtPrinter.Rows[0]["TerminalPrinterName"].ToString();
                obj.PrintOptions.PrinterName = settings.PrinterName.ToString();
                obj.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                //crViewer.ReportSource = vrptSalesInvoice;
                frm2.crystalReportViewer1.ReportSource = obj;
               // obj.PrintToPrinter(Qty, false, 0, 0);
               frm2.ShowDialog();







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
            // }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dt = conclass.GetRecord(@"SELECT DISTINCT TOP 30 
    CustomerID, 
    CustomerName,
    SaleReturnID, 
    CONVERT(VARCHAR(12), SaleReturnDate, 103) AS SaleReturnDate, 
    InvoiceNo, 
    'Re Print' AS PrintBill
FROM VW_SaleReturnForReceipt
ORDER BY SaleReturnID DESC;
");
            grdReprint.DataSource = dt;
            pnlReprint.Visible = true;
            pnlReprint.BringToFront();
        }
        private void lstCustomerOrder_DoubleClick(object sender, EventArgs e)
        {
            ChoseToAdd();
        }


        private void ClearAll()
        {
            lstCustomerOrder.Items.Clear();
            dataGridView1.Rows.Clear();
            txtitemName.Text = "";
            txtitemName.Tag = "";
            txtExpiryDate.Text = "";
            txtSoldQty.Text = "";
            txtQtyToReturn.Text = "";
            txtQtyToReturn.BackColor = Color.White;
            txtQtyToReturn.ForeColor = Color.Black;
            lstCustomerOrder.Items.Clear();
            txtProductSearch.Text = "";

            lblCustomerID.Text = "";
            lblCustomerName1.Text = "";
                   

            txtCustomerIDSearch.Text = "";
            txtCustomerIDSearch.Focus();
        
        
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void rdSearchByInvoiceNo_CheckedChanged(object sender, EventArgs e)
        {
            lblSearch.Text = "Type Invoice No:";
            txtCustomerIDSearch.Focus();
        }

        private void rbSearchByCustomerID_CheckedChanged(object sender, EventArgs e)
        {
            lblSearch.Text = "Type Customer ID:";
            txtCustomerIDSearch.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlAdvanceSearch.Visible = false;
            pnlAdvanceSearch.SendToBack();
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            pnlAdvanceSearch.Visible = true;
            pnlAdvanceSearch.BringToFront();
            txt_item_search.Text = "";
            txt_item_search.Focus();
        }

        private void btnSerachAd_Click(object sender, EventArgs e)
        {
            string from = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
            string to = this.dtto.Value.Month.ToString() + "/" + this.dtto.Value.Day.ToString() + "/" + this.dtto.Value.Year.ToString();
            DataTable dt = obj.GetData(@"
SELECT 
    IMIS_tblSaleOrderDetail.InvoiceNo, 
    IMIS_tblSaleOrderDetail.SNO, 
    IMIS_tblSaleOrderDetail.ProductCode, 
    IMIS_VWProducts.ProductName, 
    IMIS_tblSaleOrderDetail.Quantity AS SoldQty, 
    IMIS_tblSaleOrderDetail.Quantity, 
    dbo.fn_GetReturnedQuantity(IMIS_tblSaleOrderDetail.ProductCode, IMIS_tblSaleOrderDetail.SNO) AS ReturnedQty,
    (IMIS_tblSaleOrderDetail.Quantity - dbo.fn_GetReturnedQuantity(IMIS_tblSaleOrderDetail.ProductCode, IMIS_tblSaleOrderDetail.SNO)) AS NetQuantity,
    IMIS_tblSaleOrderDetail.SalePrice, 
    IMIS_tblSaleOrderDetail.Discount, 
    IMIS_tblSaleOrderDetail.Total, 
    IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, 
    IMIS_tblSaleOrderDetail.BaseCurrencyTotal, 
    IMIS_tblSaleOrderDetail.BaseCurrencySalePrice, 
    IMIS_tblSaleOrderDetail.BatchNo, 
    CONVERT(varchar(12), IMIS_tblSaleOrderDetail.ExpiryDate, 106) AS ExpiryDate, 
    IMIS_tblSaleOrderDetail.ProductStockID, 
    IMIS_tblSaleMan.SaleManName, 
    ISNULL(IMIS_tblSaleOrderDetail.BaseCurrencyDiscount, 0) AS BaseCurrencyDiscount, 
    IMIS_tblSaleOrderDetail.SalesManID, 
    IMIS_tblSaleOrderDetail.SalesPercentage, 
    IMIS_tblSaleMan.StoreID,
    IMIS_tblSaleOrderDetail.SalesPercentage AS Expr1, 
    IMIS_tblSaleOrderMain.CustomerID, 
    IMIS_tblSaleOrderDetail.SystemDate, 
    CONVERT(varchar(12), IMIS_tblSaleOrderMain.SaleOrderDate, 107) AS SaleOrderDate, 
    CONVERT(varchar(8), IMIS_tblSaleOrderMain.SaleOrderTime, 113) AS SaleOrderTime, 
    IMIS_tblCustomer.CustomerName
FROM 
    IMIS_tblSaleOrderDetail 
    INNER JOIN IMIS_VWProducts ON IMIS_tblSaleOrderDetail.ProductCode = IMIS_VWProducts.ProductCode 
    INNER JOIN IMIS_tblSaleMan ON IMIS_tblSaleOrderDetail.SalesManID = IMIS_tblSaleMan.SaleManID 
    INNER JOIN IMIS_tblSaleOrderMain ON IMIS_tblSaleOrderDetail.InvoiceNo = IMIS_tblSaleOrderMain.InvoiceNo 
    INNER JOIN IMIS_tblCustomer ON IMIS_tblSaleOrderMain.CustomerID = IMIS_tblCustomer.CustomerID
WHERE 
    IMIS_VWProducts.ProductName LIKE N'" + txt_item_search.Text + @"%' AND 
    CAST(CONVERT(VARCHAR(12), IMIS_tblSaleOrderMain.SaleOrderDate, 101) AS DATETIME) >= CAST('" + from + @"' AS DATETIME) AND
    CAST(CONVERT(VARCHAR(12), IMIS_tblSaleOrderMain.SaleOrderDate, 101) AS DATETIME) <= CAST('" + to + @"' AS DATETIME) AND
    (IMIS_tblSaleOrderDetail.Quantity - dbo.fn_GetReturnedQuantity(IMIS_tblSaleOrderDetail.ProductCode, IMIS_tblSaleOrderDetail.SNO)) > 0
ORDER BY 
    SaleOrderDate, SaleOrderTime DESC
");


            lstAdvanceSearch.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {

                ListViewItem item = new ListViewItem(dr["SNO"].ToString());
                item.SubItems.Add(dr["InvoiceNo"].ToString());
                item.SubItems.Add(dr["ProductCode"].ToString());
                item.SubItems.Add(dr["ProductName"].ToString());
                item.SubItems.Add(dr["SaleOrderDate"].ToString());
                item.SubItems.Add(dr["SaleOrderTime"].ToString());
                item.SubItems.Add(dr["NetQuantity"].ToString());
                item.SubItems.Add(dr["SalePrice"].ToString());
                item.SubItems.Add(dr["Discount"].ToString());
                item.SubItems.Add(dr["ExpiryDate"].ToString());
                item.SubItems.Add(dr["BaseCurrencyProfitPerUnit"].ToString());
                item.SubItems.Add(dr["BaseCurrencySalePrice"].ToString());
                item.SubItems.Add(dr["ProductStockID"].ToString());
                item.SubItems.Add(dr["SalesManID"].ToString());
                item.SubItems.Add(dr["SalesPercentage"].ToString());
                item.SubItems.Add(dr["BaseCurrencyDiscount"].ToString());
                item.SubItems.Add(dr["CustomerID"].ToString());
                item.SubItems.Add(dr["CustomerName"].ToString());
                lstAdvanceSearch.Items.Add(item);

            }
            if (lstAdvanceSearch.Items.Count > 0)
            {
                lstAdvanceSearch.Items[0].Selected = true;
                lstAdvanceSearch.Items[0].EnsureVisible();
                lstAdvanceSearch.Select();
                lstAdvanceSearch.Focus();
            }
        }

        private void lstAdvanceSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                rdSearchByInvoiceNo.Checked = true;
                txtCustomerIDSearch.Text = lstAdvanceSearch.SelectedItems[0].SubItems[1].Text;
                pnlAdvanceSearch.Visible = false;
                pnlAdvanceSearch.SendToBack();
                FillByInvoiceNo();
               
            }
        }

        private void txt_item_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_item_search.Text != "" && e.KeyCode == Keys.Enter)
                btnSerachAd_Click(null, null);
        }

        private void SalesReturnUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnAddToList_Click(null,null);

            }
        }

        private void SalesReturnUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void lstAdvanceSearch_DoubleClick(object sender, EventArgs e)
        {
            ChoseToAddAdvance();

        }

        private void grdReprint_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdReprint.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "Re Print")
            {
                printInvoice(grdReprint.Rows[e.RowIndex].Cells[2].Value.ToString(),false);
            }
        }

        private void btncloseReprint_Click(object sender, EventArgs e)
        {
            pnlReprint.Visible = false;
            pnlReprint.SendToBack();
            txtCustomerIDSearch.Focus();
        }

        private void cmbReturnMethod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbReturnMethod.Text == "Cash")
                cmbPaymentAccount.Enabled = true;
            else
                cmbPaymentAccount.Enabled = false;
        }
    }
}
