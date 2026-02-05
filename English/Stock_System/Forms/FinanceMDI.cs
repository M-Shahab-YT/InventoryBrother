using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Stock_System.Class;
namespace Stock_System.Forms
{
    public partial class FinanceMDI : Form
    {
        Form oldfrm;
        public FinanceMDI()
        {
            InitializeComponent();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void MDI_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = "Logged in User: " + Class.conclass.FullName.ToString();
            loadRoleManagement();
        }
        private void btnPOS_Click(object sender, EventArgs e)
        {
            this.Hide();
            MDI frm = new MDI();
            frm.Show();
        }
        private void btnSaleReport_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmCurrency frm2 = new Stock_System.Forms.frmCurrency();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
        private void btnPurchaseReport_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmCashAccounts frm2 = new Stock_System.Forms.frmCashAccounts();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
        private void btnTodayCash_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmDailyCash frm2 = new Stock_System.Forms.frmDailyCash();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
        private void btnExpense_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmExpenses frm2 = new Stock_System.Forms.frmExpenses();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
        private void btnSaleReport_Click_1(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmCurrency frm2 = new Stock_System.Forms.frmCurrency();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
        private void btnPurchaseReport_Click_1(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmCashAccounts frm2 = new Stock_System.Forms.frmCashAccounts();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmCustomerBalance frm2 = new Stock_System.Forms.frmCustomerBalance();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmSupplierStatement frm2 = new Stock_System.Forms.frmSupplierStatement();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
        #region Role Management
        private void loadRoleManagement()
        {
            if (conclass.IsInRole(conclass.UserName, "Expenses Entry"))
                btnExpense.Enabled = true;

            if (conclass.IsInRole(conclass.UserName, "Currency Setting"))
                btnCurrency.Enabled = true;

            if (conclass.IsInRole(conclass.UserName, "Accounts Setting"))
               btnAccounts.Enabled = true;

            if (conclass.IsInRole(conclass.UserName, "Customer Statement"))
                btnCustomer.Enabled = true;

            if (conclass.IsInRole(conclass.UserName, "Supplier Statement"))
                btnSupplier.Enabled = true;

            if (conclass.IsInRole(conclass.UserName, "Finance Manager"))
            {
                btnAccounts.Enabled = true;
                btnSalesMan.Enabled = true;
                btnCashirBalance.Enabled = true;
            }

        }
        #endregion

        private void btnCashirBalance_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmCashiersBalance frm2 = new Stock_System.Forms.frmCashiersBalance();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmRevenue frm2 = new Stock_System.Forms.frmRevenue();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }

        private void btnSalesMan_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmSalesManStatement frm2 = new Stock_System.Forms.frmSalesManStatement();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
    }
}
