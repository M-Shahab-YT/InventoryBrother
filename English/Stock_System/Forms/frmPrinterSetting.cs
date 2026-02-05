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
    public partial class frmPrinterSetting : Form
    {
        public frmPrinterSetting()
        {
            InitializeComponent();
        }
        Dbcommon obj = new Dbcommon();
        private void frmPrinterSetting_Load(object sender, EventArgs e)
        {
            obj.fillcmb(cmbStore, "StoreName", "StoreID", "SELECT StoreID, StoreName FROM IMIS_tblStore");
            cmbStore_SelectionChangeCommitted(null, null);
            FillPrinterList();
        }

        private void cmbStore_SelectionChangeCommitted(object sender, EventArgs e)
        {
            obj.fillcmb(cmbUser, "UserName", "UserId", "SELECT UserId, UserName FROM aspnet_Users where StoreID="+cmbStore.SelectedValue+"");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int isCheck = 0;
            if (chkPPreview.Checked)
                isCheck = 1;
            else
                isCheck = 0;
            if (btnSave.Text == "Save")
            {
                obj.ExecuteQuery(@"delete from IMIS_tblPrinterSetting where UserID=N'" + cmbUser.SelectedValue + "' and StoreID=" + cmbStore.SelectedValue + "");

                obj.ExecuteQuery(@"insert into IMIS_tblPrinterSetting(StoreID, UserID, LaserPrinterName, TerminalPrinterName, ShowPrintPreview,CreatedBy) 
                values(" + cmbStore.SelectedValue + ", N'" + cmbUser.SelectedValue + "', '" + txtLaserPrinterName.Text + "', N'" + txtTerminalPrinterName.Text + "'," + isCheck + ",N'" + conclass.User_ID + "' )");
                MessageBox.Show("Printer Saved Successfully.");
            }
            else
            {
                obj.ExecuteQuery(@"update IMIS_tblPrinterSetting set StoreID=" + cmbStore.SelectedValue + ", UserID=N'" + cmbUser.SelectedValue + "', LaserPrinterName=N'" + txtLaserPrinterName.Text + "', TerminalPrinterName=N'" + txtTerminalPrinterName.Text + "', ShowPrintPreview=" + isCheck + ", LastUpdatedBy=N'" + conclass.User_ID + "',LastUpdatedDate=getdate() where ID=" + txtLaserPrinterName.Tag + "");
                MessageBox.Show("Printer Updated Successfully.");
            }
            btnSave.Text = "Save";
            txtTerminalPrinterName.Text = "";
            txtLaserPrinterName.Text = "";
            chkPPreview.Checked = false;
            FillPrinterList();
        }

        private void FillPrinterList()
        {
            DataTable dt = obj.GetData(@"SELECT   IMIS_tblPrinterSetting.ID, IMIS_tblStore.StoreName, aspnet_Users.UserName, IMIS_tblPrinterSetting.LaserPrinterName, IMIS_tblPrinterSetting.TerminalPrinterName, 
            IMIS_tblPrinterSetting.ShowPrintPreview,convert(varchar(12), IMIS_tblPrinterSetting.SystemDate,105) as EntryDate
            FROM IMIS_tblPrinterSetting INNER JOIN
            IMIS_tblStore ON IMIS_tblPrinterSetting.StoreID = IMIS_tblStore.StoreID INNER JOIN
                         aspnet_Users ON IMIS_tblPrinterSetting.UserID = aspnet_Users.UserId");
            lstPrinterList.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["ID"].ToString());
                item.SubItems.Add(dr["StoreName"].ToString());
                item.SubItems.Add(dr["UserName"].ToString());
                item.SubItems.Add(dr["LaserPrinterName"].ToString());
                item.SubItems.Add(dr["TerminalPrinterName"].ToString());
                item.SubItems.Add(dr["ShowPrintPreview"].ToString());
                item.SubItems.Add(dr["EntryDate"].ToString());
                lstPrinterList.Items.Add(item);
            }
        }

        private void lstPrinterList_DoubleClick(object sender, EventArgs e)
        {
            string Id = lstPrinterList.SelectedItems[0].SubItems[0].Text;

            DataTable dt = obj.GetData(@"SELECT   ID, StoreID, UserID, LaserPrinterName, TerminalPrinterName, ShowPrintPreview FROM IMIS_tblPrinterSetting WHERE ID = " + Id + "");
            txtLaserPrinterName.Text = dt.Rows[0]["LaserPrinterName"].ToString();
            txtTerminalPrinterName.Text = dt.Rows[0]["TerminalPrinterName"].ToString();
            if (dt.Rows[0]["ShowPrintPreview"].ToString() == "True")
                chkPPreview.Checked = true;
            else
                chkPPreview.Checked = false;
            cmbStore.SelectedValue = dt.Rows[0]["StoreID"].ToString();
            cmbStore_SelectionChangeCommitted(null, null);
            cmbUser.SelectedValue = dt.Rows[0]["UserID"].ToString();
            txtLaserPrinterName.Tag = dt.Rows[0]["ID"].ToString();
            btnSave.Text = "Update";
        }
    }
}
