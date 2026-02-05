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
    public partial class frmSaleMain : Form
    {
        public frmSaleMain()
        {
            InitializeComponent();
        }
        Dbcommon obj = new Dbcommon();
        private void btnSaveSaleMan_Click(object sender, EventArgs e)
        {
            if (btnSaveSaleMan.Text == "Save")
            {
                obj.ExecuteQuery(@"insert into IMIS_tblSaleMan(SaleManName, Address, MobileNo, Remarks, SalePercentage, Status, StoreID, UserID) 
                values(N'" +txtSaleManName.Text+"', N'"+txtAddress.Text+"', '"+txtMobileNo.Text+"', N'"+txtRemarks.Text+"', "+txtSalePercentage.Text+", '"+cmbStatus.Text+"', "+conclass.StoreID+", N'"+conclass.User_ID+"')");
                MessageBox.Show("Record Saved Successfully..");
            }
            else
            {
                obj.ExecuteQuery(@"update IMIS_tblSaleMan set SaleManName=N'"+txtSaleManName.Text+"', Address=N'"+txtAddress.Text+"', MobileNo='"+txtMobileNo.Text+"', Remarks=N'"+txtRemarks.Text+"', SalePercentage="+txtSalePercentage.Text+", Status='"+cmbStatus.Text+"',LastUpdatedBy=N'"+conclass.User_ID+"',LastUpdatedDate=getdate() where SaleManID="+txtSaleManName.Tag+"");
                MessageBox.Show("Record Updated Successfully..");
            }
            Clear();
            FillSaleManDetail();
        }
        private void Clear()
        {
            txtAddress.Text = "";
            txtMobileNo.Text = "";
            txtRemarks.Text = "";
            cmbStatus.Text = "Active";
            txtSaleManName.Text = "";
            txtSalePercentage.Text = "";
            btnSaveSaleMan.Text = "Save";
            txtSaleManName.Focus();
        }
        private void FillSaleManDetail()
        {
            DataTable dt = obj.GetData(@"SELECT        SaleManID, SaleManName, Address, MobileNo, Remarks, SalePercentage, Status FROM            IMIS_tblSaleMan order by SaleManID");
            lstCustomerSearchView.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["SaleManID"].ToString());
                item.SubItems.Add(dr["SaleManName"].ToString());
                item.SubItems.Add(dr["SalePercentage"].ToString());
                item.SubItems.Add(dr["MobileNo"].ToString());
                item.SubItems.Add(dr["Address"].ToString());
                item.SubItems.Add(dr["Status"].ToString());
                lstCustomerSearchView.Items.Add(item);
            }
        }
        private void frmSaleMain_Load(object sender, EventArgs e)
        {
            FillSaleManDetail();
            cmbStatus.Text = "Active";
            txtSaleManName.Focus();
         
        }
        private void lstCustomerSearchView_Click(object sender, EventArgs e)
        {
            string Id = lstCustomerSearchView.SelectedItems[0].SubItems[0].Text;
            DataTable dt = obj.GetData(@"SELECT        SaleManID, SaleManName, Address, MobileNo, Remarks, SalePercentage, Status FROM   IMIS_tblSaleMan  where SaleManID=" + Id + "");
            txtSaleManName.Tag = dt.Rows[0]["SaleManID"].ToString();
            txtSaleManName.Text = dt.Rows[0]["SaleManName"].ToString();
            txtSalePercentage.Text = dt.Rows[0]["SalePercentage"].ToString();
            txtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
            txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            cmbStatus.Text = dt.Rows[0]["Status"].ToString();
            btnSaveSaleMan.Text = "Update";
        }
        private void btnCancelSaleMan_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtSaleManName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtSaleManName.Text != "")
            {
                #region ByName
                DataTable dt = obj.GetData(@"SELECT        SaleManID, SaleManName, Address, MobileNo, Remarks, SalePercentage, Status FROM            IMIS_tblSaleMan where SaleManName like N'%"+txtSaleManName.Text+"%'");
                lstCustomerSearchView.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["SaleManID"].ToString());
                    item.SubItems.Add(dr["SaleManName"].ToString());
                    item.SubItems.Add(dr["SalePercentage"].ToString());
                    item.SubItems.Add(dr["MobileNo"].ToString());
                    item.SubItems.Add(dr["Address"].ToString());
                    item.SubItems.Add(dr["Status"].ToString());
                    lstCustomerSearchView.Items.Add(item);
                }
                #endregion
            }
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
            if (e.KeyCode == Keys.Enter && lstCustomerSearchView.Items.Count > 0)
            {
                string Id = lstCustomerSearchView.SelectedItems[0].SubItems[0].Text;
                DataTable dt = obj.GetData(@"SELECT        SaleManID, SaleManName, Address, MobileNo, Remarks, SalePercentage, Status FROM   IMIS_tblSaleMan  where SaleManID=" + Id + "");
                txtSaleManName.Tag = dt.Rows[0]["SaleManID"].ToString();
                txtSaleManName.Text = dt.Rows[0]["SaleManName"].ToString();
                txtSalePercentage.Text = dt.Rows[0]["SalePercentage"].ToString();
                txtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
                txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                cmbStatus.Text = dt.Rows[0]["Status"].ToString();
                btnSaveSaleMan.Text = "Update";
            }
        }

        private void txtSalePercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
            {
                conclass.ASCIn(e);

            }
        }

       
      
    }
}
