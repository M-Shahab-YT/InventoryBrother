using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Stock_System.Class;
namespace Stock_System.Forms
{
    public partial class frmCurrency : Telerik.WinControls.UI.RadForm
    {
        Dbcommon obj = new Dbcommon();
        public frmCurrency()
        {
            InitializeComponent();
        }
        private void btnSaveCurrency_Click(object sender, EventArgs e)
        {
            if (txtCurrencyName.Text == "")
            {
                MessageBox.Show("Currency Name is Required!");
                txtCurrencyName.Focus();
                return;
            }
            if (txtCurrencySymbol.Text == "")
            {
                MessageBox.Show("Currency Symbol is Required!");
                txtCurrencySymbol.Focus();
                return;
            }
            if (cmbFromBaseCurrencyOperator.Text == "")
            {
                MessageBox.Show("FromBaseCurrencyOperator is Required!");
                cmbFromBaseCurrencyOperator.Focus();
                return;
            }
            if (cmbToBaseCurrencyOperator.Text == "")
            {
                MessageBox.Show("To Base Currency Operator is Required!");
                cmbToBaseCurrencyOperator.Focus();
                return;
            }
            string IsBaseCurrency = "No";
            if (chkIsBaseCurrency.Checked)
                IsBaseCurrency = "Yes";
            if (btnSaveCurrency.Text == "Save")
            {
                obj.ExecuteQuery(@"insert into Lookup_tblCurrency(CurrencyName, CurrencySymbol, ToBaseCurrencyOperator, FromBaseCurrencyOperator, IsBaseCurrency, UserID)  values('" + txtCurrencyName.Text + "', N'" + txtCurrencySymbol.Text + "', N'" + cmbToBaseCurrencyOperator.Text + "','" + cmbFromBaseCurrencyOperator.Text + "' ,'" + IsBaseCurrency + "',N'" + conclass.User_ID + "')");
            }
            else
            {
                obj.ExecuteQuery("update Lookup_tblCurrency set CurrencyName=N'" + txtCurrencyName.Text + "',CurrencySymbol=N'" + txtCurrencySymbol.Text + "',ToBaseCurrencyOperator='" + cmbToBaseCurrencyOperator.Text + "',FromBaseCurrencyOperator='" + cmbFromBaseCurrencyOperator.Text + "',LastUpdatedBy=N'" + conclass.User_ID + "', LastUpdatedDate=getdate() where CurrencyID=" + txtCurrencyName.Tag.ToString() + "");
            }
            FillListCurrency();
            txtCurrencySymbol.Text = "";
            txtCurrencyName.Text = "";
            chkIsBaseCurrency.Checked = false;
            MessageBox.Show("Record Saved Successfully..");
            txtCurrencyName.Focus();
        }
        private void FillListCurrency()
        {
            try
            {
                lstCurrency.Items.Clear();
                DataTable dt = new DataTable();
                dt = Class.conclass.GetRecord(@"SELECT        CurrencyID, CurrencyName, CurrencySymbol, ToBaseCurrencyOperator, FromBaseCurrencyOperator, IsBaseCurrency
FROM            Lookup_tblCurrency");
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["CurrencyID"].ToString());
                    item.SubItems.Add(dr["CurrencyName"].ToString());
                    item.SubItems.Add(dr["CurrencySymbol"].ToString());
                    item.SubItems.Add(dr["ToBaseCurrencyOperator"].ToString());
                    item.SubItems.Add(dr["FromBaseCurrencyOperator"].ToString());
                    item.SubItems.Add(dr["IsBaseCurrency"].ToString());
                    lstCurrency.Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillListExchangeRate()
        {
            try
            {
                lstExchangeRate.Items.Clear();
                DataTable dt = new DataTable();
                dt = Class.conclass.GetRecord(@"SELECT        ID, CurrencyID, Currency_Name, ExchangeRate,Convert(varchar(12),System_Date,107) as System_Date, UserName, StoreId, rang
FROM            FMIS_VW_CurrencyExchangeRate where StoreID=" +conclass.StoreID+" and rang=1");
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["ID"].ToString());
                    item.SubItems.Add(dr["Currency_Name"].ToString());
                    item.SubItems.Add(dr["ExchangeRate"].ToString());
                    item.SubItems.Add(dr["System_Date"].ToString());
                    item.SubItems.Add(dr["UserName"].ToString());
                    lstExchangeRate.Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmCurrency_Load(object sender, EventArgs e)
        {
            FillListCurrency();
            obj.fillcmb(cmbCurrency, "CurrencyName", "CurrencyID", @"SELECT        CurrencyID,Convert(nvarchar(12), CurrencyName)+'-'+ Convert(nvarchar(12),CurrencySymbol) as CurrencyName FROM  Lookup_tblCurrency where IsBaseCurrency='No'");
            FillListExchangeRate();
            txtExchangeRate.Focus();
        }
        private void lstCurrency_DoubleClick(object sender, EventArgs e)
        {
            txtCurrencyName.Tag = lstCurrency.SelectedItems[0].SubItems[0].Text;
            txtCurrencyName.Text = lstCurrency.SelectedItems[0].SubItems[1].Text;
            txtCurrencySymbol.Text = lstCurrency.SelectedItems[0].SubItems[2].Text;
            cmbFromBaseCurrencyOperator.Text = lstCurrency.SelectedItems[0].SubItems[3].Text;
            cmbToBaseCurrencyOperator.Text = lstCurrency.SelectedItems[0].SubItems[4].Text;
            if (lstCurrency.SelectedItems[0].SubItems[5].Text == "Yes")
                chkIsBaseCurrency.Checked = true;
            else
                chkIsBaseCurrency.Checked = false;
            btnSaveCurrency.Text = "Update";
        }

        private void btnSaveExchangeRate_Click(object sender, EventArgs e)
        {
            if (txtExchangeRate.Text == "")
            {
                MessageBox.Show("Exchange Rate is Required!");
                return;
            }
            obj.ExecuteQuery("insert into FMIS_tblCurrencyExchangeRate(StoreID, CurrencyID, ExchangeRate, UserID) values("+conclass.StoreID+", "+cmbCurrency.SelectedValue+", "+txtExchangeRate.Text+", N'"+conclass.User_ID+"')");
            txtExchangeRate.Text = "";
            FillListExchangeRate();
            MessageBox.Show("Record Saved Successfully..");
            txtExchangeRate.Focus();
        }

       
    }
}
