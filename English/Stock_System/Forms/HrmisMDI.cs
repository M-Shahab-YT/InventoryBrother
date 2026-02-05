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
    public partial class HrmisMDI : Form
    {
        Form oldfrm;
        public HrmisMDI()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MDI_Load(object sender, EventArgs e)
        {
            //lblCurrentUser.Text = "Logged in User: " + Class.conclass.FullName.ToString();
            loadRoleManagement();
           


        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            this.Hide();
            MDI frm = new MDI();
            frm.Show();
        }

        private void btnPurchaseReport_Click(object sender, EventArgs e)
        {
            //if (oldfrm != null)
            //    oldfrm.Close();
            //Forms.frmCashAccounts frm2 = new Stock_System.Forms.frmCashAccounts();
            //frm2.MdiParent = this;
            //frm2.Parent = this.main_panel;
            //oldfrm = frm2;
            //oldfrm.Show();
        }

        private void btnTodayCash_Click(object sender, EventArgs e)
        {
            //if (oldfrm != null)
            //    oldfrm.Close();
            //Forms.frmDailyCash frm2 = new Stock_System.Forms.frmDailyCash();
            //frm2.MdiParent = this;
            //frm2.Parent = this.main_panel;
            //oldfrm = frm2;
            //oldfrm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

       
        private void btnExpense_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmMonthlyPayroll frm2 = new Stock_System.Forms.frmMonthlyPayroll();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }

        private void btnSaleReport_Click_1(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmEmployee frm2 = new Stock_System.Forms.frmEmployee();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }

        private void btnPurchaseReport_Click_1(object sender, EventArgs e)
        {
            //if (oldfrm != null)
            //    oldfrm.Close();
            //Forms.frmCashAccounts frm2 = new Stock_System.Forms.frmCashAccounts();
            //frm2.MdiParent = this;
            //frm2.Parent = this.main_panel;
            //oldfrm = frm2;
            //oldfrm.Show();
        }

        private void btnAdvanceSalary_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmAdvanceSalary frm2 = new Stock_System.Forms.frmAdvanceSalary();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            //if (oldfrm != null)
            //    oldfrm.Close();
            //Forms.frmEmployeeStatementSummary frm2 = new Stock_System.Forms.frmEmployeeStatementSummary();
            //frm2.MdiParent = this;
            //frm2.Parent = this.main_panel;
            //oldfrm = frm2;
            //oldfrm.Show();

        }
        #region Role Management
        private void loadRoleManagement()
        {
            if (conclass.IsInRole(conclass.UserName, "Finance Admin") || conclass.IsInRole(conclass.UserName, "Admin"))
            {
                btnSaleReport.Enabled = true;
                btnAdvanceSalary.Enabled = true;
                btnExpense.Enabled = true;
            }
        }
        #endregion
        
    }
}
