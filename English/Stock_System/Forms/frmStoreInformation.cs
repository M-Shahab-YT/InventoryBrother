using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.SqlClient;
using Stock_System.Class;
using System.IO;
namespace Stock_System.Forms
{
    public partial class frmStoreInformation : Telerik.WinControls.UI.RadForm
    {
        Dbcommon obj = new Dbcommon();
        public frmStoreInformation()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                SaveProduct();
            }
            else
            {
                UpdateProduct();
            }
            txtAddress.Text = "";
            txtAddressLocal.Text = "";
            txtContactNumber.Text = "";
            txtContactNumber2.Text = "";
            txtStoreGpsPoints.Text = "";
            txtStoreName.Text = "";
            txtStoreNameLocal.Text = "";
            fillStoreInfo();
        }
        private void SaveProduct()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conclass.con;
                cmd.CommandText = "IMIS_ProStoreInsert";
                SqlParameter[] p = new SqlParameter[9];
                p[0] = new SqlParameter("@StoreName", txtStoreName.Text);
                p[1] = new SqlParameter("@StoreNameLocal", txtStoreNameLocal.Text);
                p[2] = new SqlParameter("@Address", txtAddress.Text);
                p[3] = new SqlParameter("@AddressLocal", txtAddressLocal.Text);
                p[4] = new SqlParameter("@StoreGPSPoints", txtStoreGpsPoints.Text);
                p[5] = new SqlParameter("@ContactNumber1", txtContactNumber.Text);
                p[6] = new SqlParameter("@ContactNumber2", txtContactNumber2.Text);
                p[7] = new SqlParameter("@UserID", conclass.User_ID);
                if (this.OpenFile.FileName != "openFileDialog1")
                {
                    p[8] = new SqlParameter("@BusinessLogo", SqlDbType.VarBinary);
                    p[8].Value = File.ReadAllBytes(this.OpenFile.FileName);
                }
                else
                {
                    p[8] = new SqlParameter("@BusinessLogo", SqlDbType.VarBinary);
                    p[8].Value = DBNull.Value;
                }
                cmd.Parameters.AddRange(p);
                obj.con.Open();
                cmd.ExecuteNonQuery();
                obj.con.Close();
            }
          catch(Exception ex)
            {

                MessageBox.Show(ex.InnerException.ToString());
            }
            MessageBox.Show("Saved Successfully.");
        }
        private void UpdateProduct()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conclass.con;
                SqlParameter[] p;
                string ProcName = "";
                if (this.OpenFile.FileName != "openFileDialog1")
                {
                    p = new SqlParameter[10];
                    ProcName = "IMIS_ProStoreUpdate";
                    p[9] = new SqlParameter("@BusinessLogo", SqlDbType.VarBinary);
                    p[9].Value = File.ReadAllBytes(this.OpenFile.FileName);
                }
                else
                {
                    p = new SqlParameter[9];
                    ProcName = "IMIS_ProStoreUpdateNoImage";
                }

                p[0] = new SqlParameter("@StoreID", txtStoreName.Tag.ToString());
                p[1] = new SqlParameter("@StoreName", txtStoreName.Text);
                p[2] = new SqlParameter("@StoreNameLocal", txtStoreNameLocal.Text);
                p[3] = new SqlParameter("@Address", txtAddress.Text);
                p[4] = new SqlParameter("@AddressLocal", txtAddressLocal.Text);
                p[5] = new SqlParameter("@StoreGPSPoints", txtStoreGpsPoints.Text);
                p[6] = new SqlParameter("@ContactNumber1", txtContactNumber.Text);
                p[7] = new SqlParameter("@ContactNumber2", txtContactNumber2.Text);
                p[8] = new SqlParameter("@LastUpdatedBy", conclass.User_ID);
                cmd.CommandText = ProcName;
                cmd.Parameters.AddRange(p);
                obj.con.Open();
                cmd.ExecuteNonQuery();
                obj.con.Close();
                btnSave.Text = "Save";
                MessageBox.Show("Saved Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }
        private void fillStoreInfo()
        {

            DataTable dt = conclass.GetRecord(@"SELECT        StoreID, StoreName, StoreNameLocal, Address, AddressLocal, StoreGPSPoints, BusinessLogo, ContactNumber1, ContactNumber2, UserID, SystemDate, LastUpdatedDate, LastUpdatedBy FROM   IMIS_tblStore");
            if (dt.Rows.Count > 0)
            {
                lst_Item.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["StoreID"].ToString());
                    item.SubItems.Add(dr["StoreName"].ToString());
                    item.SubItems.Add(dr["StoreNameLocal"].ToString());
                    item.SubItems.Add(dr["Address"].ToString());
                    item.SubItems.Add(dr["AddressLocal"].ToString());
                    item.SubItems.Add(dr["ContactNumber1"].ToString());
                    item.SubItems.Add(dr["ContactNumber2"].ToString());
                    lst_Item.Items.Add(item);
                }
            }
        
        }
        private void frmStoreInformation_Load(object sender, EventArgs e)
        {
            fillStoreInfo();
        }
        private void lst_Item_Click(object sender, EventArgs e)
        {
            string StoreId=lst_Item.SelectedItems[0].SubItems[0].Text;
            DataTable dt = conclass.GetRecord(@"SELECT        StoreID, StoreName, StoreNameLocal, Address, AddressLocal, StoreGPSPoints, BusinessLogo, ContactNumber1, ContactNumber2, UserID, SystemDate, LastUpdatedDate, LastUpdatedBy
FROM            IMIS_tblStore where StoreID=" + StoreId + "");
            if (dt.Rows.Count > 0)
            {
                txtStoreName.Tag = dt.Rows[0]["StoreID"].ToString();
                txtStoreName.Text = dt.Rows[0]["StoreName"].ToString();
                txtStoreNameLocal.Text = dt.Rows[0]["StoreNameLocal"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtAddressLocal.Text = dt.Rows[0]["AddressLocal"].ToString();
                txtStoreGpsPoints.Text = dt.Rows[0]["StoreGPSPoints"].ToString();
                txtContactNumber.Text = dt.Rows[0]["ContactNumber1"].ToString();
                txtContactNumber2.Text = dt.Rows[0]["ContactNumber2"].ToString();

                byte[] bt = dt.Rows[0]["BusinessLogo"] as byte[];
                if (bt != null)
                {
                    MemoryStream ms = new MemoryStream(bt);
                    this.picBusinessLogo.Image = System.Drawing.Image.FromStream(ms);
                }
                else
                {
                    picBusinessLogo.Image = null;
                    this.picBusinessLogo.Invalidate();
                }
                btnSave.Text = "Update";
            }
           
        }
        private void picBusinessLogo_Click(object sender, EventArgs e)
        {
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                picBusinessLogo.Image = System.Drawing.Image.FromFile(OpenFile.FileName);

            }
        }
    }
}
