using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stock_System.Class;

namespace Stock_System.Forms
{
    public partial class frmSalesSetting : Form
    {
        Dbcommon obj = new Dbcommon();
        public frmSalesSetting()
        {
            InitializeComponent();
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            obj.ExecuteQuery("delete from IMIS_tblSalesSetting");

            int SalesPriceCanBeEditable = 0;
            int RepeatedItemsShowInSingleRow = 0;
            int InvoicePrintInA4Page = 0;
            int UserCanChangeTheDiscount = 0;
            int InvoicePrintInHalfA4Page = 0;
            int ShowAveragePrice = 0;
            int ShowSalesMan=0;
            int ShowPrintalert = 0;
            if (chkSalesPriceCanBeEditable.Checked)
                SalesPriceCanBeEditable = 1;
            else
                SalesPriceCanBeEditable = 0;
            if (chkRepeatedItemsShowInSingleRow.Checked)
                RepeatedItemsShowInSingleRow = 1;
            else
                RepeatedItemsShowInSingleRow = 0;

            if (chkInvoicePrintInA4Page.Checked)
                InvoicePrintInA4Page = 1;
            else
                InvoicePrintInA4Page = 0;
            if (chkUserCanChangetheDiscount.Checked)
                UserCanChangeTheDiscount = 1;
            else
                UserCanChangeTheDiscount = 0;

            if (chkInvoicePrintInHalfA4Page.Checked)
                InvoicePrintInHalfA4Page = 1;
            else
                InvoicePrintInHalfA4Page = 0;

            if (chkShowSalesMan.Checked)
                ShowSalesMan = 1;
            else
                ShowSalesMan = 0;


            if (chkShowPrintalert.Checked)
                ShowPrintalert = 1;
            else
                ShowPrintalert = 0;


            string InvoiceLanguage = cmbInvoiceLanguage.Text;
            int InvocieLanguageNumber = 1;
            if (InvoiceLanguage == "English")
                InvocieLanguageNumber = 1;
            else if (InvoiceLanguage == "Pashto")
                InvocieLanguageNumber = 2;
            else if (InvoiceLanguage == "Dari")
                InvocieLanguageNumber = 3;

            if (chkShowAveragePrice.Checked)
                ShowAveragePrice = 1;
            else
                ShowAveragePrice = 0;

            obj.ExecuteQuery(@"insert into IMIS_tblSalesSetting(SalesPriceCanBeEditable, RepeatedItemsShowInSingleRow, InvoicePrintInA4Page,UserCanChangeTheDiscount,InvoiceLanguage,ShowAveragePrice,InvoicePrintInHalfA4Page,ShowSalesMan,ShowPrintalert) 
            values(" + SalesPriceCanBeEditable + ", " + RepeatedItemsShowInSingleRow + ", " + InvoicePrintInA4Page + "," + UserCanChangeTheDiscount + "," + InvocieLanguageNumber + "," + ShowAveragePrice + "," + InvoicePrintInHalfA4Page + "," + ShowSalesMan + "," + ShowPrintalert + ")");
            MessageBox.Show("Sales Setting Saved Successfully..");
        }

        private void frmSalesSetting_Load(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData("SELECT * FROM     IMIS_tblSalesSetting");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["ShowPrintalert"].ToString() == "True")
                    chkShowPrintalert.Checked = true;
                else
                    chkShowPrintalert.Checked = false;
                if (dt.Rows[0]["ShowSalesMan"].ToString() == "True")
                    chkShowSalesMan.Checked = true;

                if (dt.Rows[0]["SalesPriceCanBeEditable"].ToString() == "True")
                    chkSalesPriceCanBeEditable.Checked = true;

                if (dt.Rows[0]["RepeatedItemsShowInSingleRow"].ToString() == "True")
                    chkRepeatedItemsShowInSingleRow.Checked = true;

                if (dt.Rows[0]["InvoicePrintInA4Page"].ToString() == "True")
                    chkInvoicePrintInA4Page.Checked = true;

                if (dt.Rows[0]["InvoicePrintInHalfA4Page"].ToString() == "True")
                    chkInvoicePrintInHalfA4Page.Checked = true;

                if (dt.Rows[0]["UserCanChangeTheDiscount"].ToString() == "True")
                    chkUserCanChangetheDiscount.Checked = true;
                int InvocieLanguageNumber = int.Parse(dt.Rows[0]["InvoiceLanguage"].ToString());

                string InvoiceLanguage="";
                if (InvocieLanguageNumber == 1)
                    InvoiceLanguage = "English";
                else if (InvocieLanguageNumber == 2)
                    InvoiceLanguage = "Pashto";
                else if (InvocieLanguageNumber == 3)
                    InvoiceLanguage = "Dari";

                cmbInvoiceLanguage.Text = InvoiceLanguage;

                if (dt.Rows[0]["ShowAveragePrice"].ToString() == "True")
                    chkShowAveragePrice.Checked = true;
            }
        }
    }
}
