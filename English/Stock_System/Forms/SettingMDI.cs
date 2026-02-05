using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Stock_System.Forms
{
    public partial class SettingMDI : Form
    {
        Form oldfrm;
        public SettingMDI()
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
            //LoadMenuOptions(5);  
           


        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            this.Hide();
            MDI frm = new MDI();
            frm.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void btnLookup_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmLookups frm2 = new Stock_System.Forms.frmLookups();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
        private void btnStore_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmStoreInformation frm2 = new Stock_System.Forms.frmStoreInformation();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
        private void btnProduct_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmDrugInformation frm2 = new Stock_System.Forms.frmDrugInformation();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
        private void btnSaleMan_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmSaleMain frm2 = new Stock_System.Forms.frmSaleMain();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
        private void radButton1_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmPrinterSetting frm2 = new Stock_System.Forms.frmPrinterSetting();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
        private void btnSalesSetting_Click(object sender, EventArgs e)
        {
            if (oldfrm != null)
                oldfrm.Close();
            Forms.frmSalesSetting frm2 = new Stock_System.Forms.frmSalesSetting();
            frm2.MdiParent = this;
            frm2.Parent = this.main_panel;
            oldfrm = frm2;
            oldfrm.Show();
        }
    }
}
