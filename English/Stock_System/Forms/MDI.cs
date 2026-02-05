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
    public partial class MDI : Form
    {
        Form oldfrm;
        public MDI()
        {
            InitializeComponent();
        }
     
        private void btnpurchase_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmpurchase frm2 = new Stock_System.Forms.frmpurchase();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
       
        private void btnItem_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmSaleReturn frm2 = new Stock_System.Forms.frmSaleReturn();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
      
        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void MDI_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = "Logged in User: " + Class.conclass.FullName.ToString();
            //if (oldfrm != null)
            //    oldfrm.Close();
            //Forms.frmPointOfSale frm2 = new Stock_System.Forms.frmPointOfSale();
            //frm2.MdiParent = this;
            //frm2.Parent = this.main_panel;
            //oldfrm = frm2;
            //oldfrm.Show();
            loadRoleManagement();
        }
        private void radButton2_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmSaleReturn frm2 = new Stock_System.Forms.frmSaleReturn();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
        private void btnStock_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmStock frm2 = new Stock_System.Forms.frmStock();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
        private void radButton4_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmpurchase frm2 = new Stock_System.Forms.frmpurchase();
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
        private void btnReports_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportMDI frm = new ReportMDI();
            frm.Show();
        }
        private void btnSale_Click_1(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmPointOfSale frm2 = new Stock_System.Forms.frmPointOfSale();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();

            //if (oldfrm != null)
            //    oldfrm.Close();
            //Forms.frmSale frm2 = new Stock_System.Forms.frmSale();
            //frm2.MdiParent = this;
            //frm2.Parent = this.main_panel;
            //oldfrm = frm2;
            //oldfrm.Show();
        }
        private void btnSaleReturn_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.SalesReturnUpdate frm2 = new SalesReturnUpdate();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
        private void btnPurchase_Click_1(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmpurchase frm2 = new Stock_System.Forms.frmpurchase();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
        private void btnPurchaseReturn_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmPurchaseReturn frm2 = new Stock_System.Forms.frmPurchaseReturn();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
      
        private void btnSetting_Click(object sender, EventArgs e)
        {
            this.Hide();
            SettingMDI frm = new SettingMDI();
            frm.Show();
        }
        private void btnLookup_Click(object sender, EventArgs e)
        {
            //if (oldfrm != null)
            //    oldfrm.Close();
            //Forms.frmBookLookups frm2 = new Stock_System.Forms.frmBookLookups();
            //frm2.MdiParent = this;
            //frm2.Parent = this.main_panel;
            //oldfrm = frm2;
            //oldfrm.Show();
        }
        private void btnFinance_Click(object sender, EventArgs e)
        {
            this.Hide();
            FinanceMDI frm = new FinanceMDI();
            frm.Show();
        }
        #region Dropdonw Buttion Code

        #endregion 
        #region Role Management
        private void loadRoleManagement()
        {

            if (conclass.IsInRole(conclass.UserName, "Sale"))
                btnSale.Enabled = true;

            if (conclass.IsInRole(conclass.UserName, "Sale Return"))
                btnSaleReturn.Enabled = true;

            if (conclass.IsInRole(conclass.UserName, "Purchase"))
                btnPurchase.Enabled = true;

            if (conclass.IsInRole(conclass.UserName, "Purchase Return"))
                btnPurchaseReturn.Enabled = true;

            if (conclass.IsInRole(conclass.UserName, "Product Entry Form"))
                btnSetting.Enabled = true;
            if (conclass.IsInRole(conclass.UserName, "Stock View"))
                btnStock.Enabled = true;

            if (conclass.IsInRole(conclass.UserName, "Finance Manager"))
            {
                btnFinance.Enabled = true;
                btnHR.Enabled = true;
            }

            if (conclass.IsInRole(conclass.UserName, "Reports"))
                btnReports.Enabled = true;

            if (conclass.IsInRole(conclass.UserName, "Setting"))
                btnSetting.Enabled = true;

          
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

        private void btnHR_Click(object sender, EventArgs e)
        {
            this.Hide();
            HrmisMDI frm = new HrmisMDI();
            frm.Show();
        }
    }
}
