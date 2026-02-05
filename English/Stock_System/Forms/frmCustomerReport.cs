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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace Stock_System.Forms
{
    public partial class frmCustomerReport : Form
    {
        public frmCustomerReport()
        {
            InitializeComponent();
        }
        DataTable dtTemp;
        private void frmCustomerReport_Load(object sender, EventArgs e)
        {
            GetCustomerSummary();
            cmbSearchType.Text = "Search By Customer Name";
        }

        private void GetCustomerSummary()
        {

            DataTable dt = conclass.GetRecord(@"SELECT        CustomerID, CustomerName, MobileNumber,  AreaName, CustomerAddress, CurrencyID, CurrencyName, Balance, LastPayment, DaysAfterLastPayment
FROM            VW_CustomerLastPaymentStatus");
            dtTemp = dt;
            dgCustomerLastPaymentReport.DataSource = dt;
        
        }

        private void cmbSearchType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "Search By Currency")
            {
                conclass.filcmb(ddlSearch, "CurrencyName", "CurrencyID", @"SELECT        CurrencyID, CurrencyName, CurrencySymbol, ToBaseCurrencyOperator, FromBaseCurrencyOperator, IsBaseCurrency, UserID, SystemDate, LastUpdatedBy, LastUpdatedDate
FROM            Lookup_tblCurrency");
                lblSarchLable.Text = "Select Currency";
                txtSearchValue.Visible = false;
                ddlSearch.Visible = true;
                ddlSearch.Focus();
              
            }
            else if (cmbSearchType.Text == "Search By Area")
            {
                conclass.filcmb(ddlSearch, "AreaName", "AreaCode", "SELECT        AreaCode, AreaName FROM            lookup_tblAreas");
                lblSarchLable.Text = "Select Area";
                txtSearchValue.Visible = false;
                ddlSearch.Visible = true;
                ddlSearch.Focus();
            }
            else if (cmbSearchType.Text == "Search By CustomerID")
            {
                lblSarchLable.Text = "Type Customer ID";
                txtSearchValue.Visible = true;
                ddlSearch.Visible = false;
                txtSearchValue.Focus();
            }
            else if (cmbSearchType.Text == "Search By Customer Name")
            {
                lblSarchLable.Text = "Type Customer Name";
                txtSearchValue.Visible = true;
                ddlSearch.Visible = false;
                txtSearchValue.Focus();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "Search By Currency")
            {
                DataTable dt = conclass.GetRecord(@"SELECT        CustomerID, CustomerName, MobileNumber,  AreaName, CustomerAddress, CurrencyID, CurrencyName, Balance, LastPayment, DaysAfterLastPayment
FROM            VW_CustomerLastPaymentStatus where CurrencyID="+ddlSearch.SelectedValue+"");
                dtTemp = dt;
                dgCustomerLastPaymentReport.DataSource = dt;
            }
            else if (cmbSearchType.Text == "Search By Area")
            {
                DataTable dt = conclass.GetRecord(@"SELECT        CustomerID, CustomerName, MobileNumber,  AreaName, CustomerAddress, CurrencyID, CurrencyName, Balance, LastPayment, DaysAfterLastPayment
FROM            VW_CustomerLastPaymentStatus where AreaCode="+ddlSearch.SelectedValue+"");
                dtTemp = dt;
                dgCustomerLastPaymentReport.DataSource = dt;
               
            }
            else if (cmbSearchType.Text == "Search By CustomerID")
            {
                DataTable dt = conclass.GetRecord(@"SELECT        CustomerID, CustomerName, MobileNumber,  AreaName, CustomerAddress, CurrencyID, CurrencyName, Balance, LastPayment, DaysAfterLastPayment
FROM            VW_CustomerLastPaymentStatus where CustomerID="+txtSearchValue.Text+"");
                dtTemp = dt;
                dgCustomerLastPaymentReport.DataSource = dt;
               
            }
            else if (cmbSearchType.Text == "Search By Customer Name")
            {
                DataTable dt = conclass.GetRecord(@"SELECT        CustomerID, CustomerName, MobileNumber,  AreaName, CustomerAddress, CurrencyID, CurrencyName, Balance, LastPayment, DaysAfterLastPayment
FROM            VW_CustomerLastPaymentStatus where CustomerName like N'%" + txtSearchValue.Text + "%'");
                dtTemp = dt;
                dgCustomerLastPaymentReport.DataSource = dt;
                
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Reports.rptCustomerDetailReport obj = new Stock_System.Reports.rptCustomerDetailReport();
            obj.SetDataSource(dtTemp);
            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;
            frm2.ShowDialog();
        }
    }
}
