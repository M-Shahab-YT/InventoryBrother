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
    public partial class ReportMDI : Form
    {
        Form oldfrm;
        public ReportMDI()
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
            Forms.frmSaleReport frm2 = new Stock_System.Forms.frmSaleReport();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }

        private void btnPurchaseReport_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmPurchaseReport frm2 = new Stock_System.Forms.frmPurchaseReport();
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

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmExpenseReport frm2 = new Stock_System.Forms.frmExpenseReport();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }

        #region Role Management
        private void loadRoleManagement()
        {
            if (conclass.IsInRole(conclass.UserName, "Sales Report"))
            {  btnSaleReport.Enabled = true;
                 btnSalesDetailReport.Enabled = true;
                 btnCashFlow.Enabled = true;
            }

            if (conclass.IsInRole(conclass.UserName, "Purchase Report"))
                btnPurchaseReport.Enabled = true;

            if (conclass.IsInRole(conclass.UserName, "Expense Report"))
                btnExpenses.Enabled = true;

        }
        #endregion

        private void btnSalesDetailReport_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.SaleAndSaleReturnView frm2 = new Stock_System.Forms.SaleAndSaleReturnView();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }

        private void btnProductReport_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmProductStatement frm2 = new Stock_System.Forms.frmProductStatement();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }

        private void btnSaleReturnReport_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmSalesReturnReport frm2 = new Stock_System.Forms.frmSalesReturnReport();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }

        private void btnCustomerReport_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmCustomerReport frm2 = new Stock_System.Forms.frmCustomerReport();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }

        private void btnPurchaseDetailReport_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmPurchaseDetailReport frm2 = new Stock_System.Forms.frmPurchaseDetailReport();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }

        private void btnShortItem_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmShortItemView frm2 = new frmShortItemView();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }

        private void btnCashFlow_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmCashFlowReport frm2 = new frmCashFlowReport();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
    }
}
