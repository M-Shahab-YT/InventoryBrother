using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.Web.Security;
using Stock_System.Class;
using CrystalDecisions.Shared;
namespace Stock_System.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

            DataTable dtCheck = conclass.GetRecord("select dbo.CheckProfile()");
            if (dtCheck.Rows.Count > 0 && dtCheck.Rows[0][0].ToString() == "Yes")
            {
                MessageBox.Show("System have some technical issue please contact to system administrator");
                return;
            }
            else
            {
                if (Membership.ValidateUser(txtUserName.Text, txtPassword.Text))
                {
                    DataTable dt = conclass.GetRecord(@"SELECT   UserId, UserName, StoreID
            FROM         aspnet_Users where LoweredUserName=N'" + txtUserName.Text.ToLower() + "'");
                    if (dt.Rows.Count > 0)
                    {
                        conclass.User_ID = dt.Rows[0]["UserId"].ToString();
                        conclass.StoreID = dt.Rows[0]["StoreID"].ToString();
                        conclass.FullName = dt.Rows[0]["UserName"].ToString();
                        conclass.UserName = dt.Rows[0]["UserName"].ToString();
                        this.Hide();
                        MDI frm = new MDI();
                        frm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Invilid User/Password");
                    txtUserName.Focus();
                }
            }

//            if (Membership.ValidateUser(txtUserName.Text, txtPassword.Text))
//            {
//                DataTable dt = conclass.GetRecord(@"SELECT   UserId, UserName, StoreID
//FROM         aspnet_Users where LoweredUserName=N'" + txtUserName.Text.ToLower() + "'");
//                if (dt.Rows.Count > 0)
//                {
//                    conclass.User_ID = dt.Rows[0]["UserId"].ToString();
//                    conclass.StoreID = dt.Rows[0]["StoreID"].ToString();
//                    conclass.FullName = dt.Rows[0]["UserName"].ToString();
//                    conclass.UserName = dt.Rows[0]["UserName"].ToString();
//                    this.Hide();
//                    MDI frm = new MDI();
//                    frm.Show();
//                }
//            }
//            else
//            {
//                MessageBox.Show("Invilid User/Password");
//                txtUserName.Focus();
//            }

            
        }

     

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DataTable dtCheck = conclass.GetRecord("select dbo.CheckProfile()");
                if (dtCheck.Rows.Count > 0 && dtCheck.Rows[0][0].ToString() == "Yes")
                {
                    MessageBox.Show("System have some technical issue please contact to system administrator");
                    return;
                }
                else
                {
                    if (Membership.ValidateUser(txtUserName.Text, txtPassword.Text))
                    {
                        DataTable dt = conclass.GetRecord(@"SELECT   UserId, UserName, StoreID
FROM         aspnet_Users where LoweredUserName=N'" + txtUserName.Text.ToLower() + "'");
                        if (dt.Rows.Count > 0)
                        {
                            conclass.User_ID = dt.Rows[0]["UserId"].ToString();
                            conclass.StoreID = dt.Rows[0]["StoreID"].ToString();
                            conclass.FullName = dt.Rows[0]["UserName"].ToString();
                            conclass.UserName = dt.Rows[0]["UserName"].ToString();
                            this.Hide();
                            MDI frm = new MDI();
                            frm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invilid User/Password");
                        txtUserName.Focus();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //BackupRestore frm = new BackupRestore();
            //frm.Show();

        }

        private void txtUserName_DoubleClick(object sender, EventArgs e)
        {
            //this.Hide();
            //BackupRestore frm = new BackupRestore();
            //frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region Print Crsital Report
            DataTable dt = new DataTable();
            dt = conclass.GetRecord(@"SELECT  top 1 ProductCode , ProductName, ProductBarCode, SalePrice, BarCodePrice,BarSubTitle FROM     IMIS_VWProducts");
            //------------------------parameters-------------------
            ParameterFields paramFields = new ParameterFields();
            ParameterField StoreName = new ParameterField();
            ParameterField StoreNameLocal = new ParameterField();
            ParameterDiscreteValue StoreNameValue = new ParameterDiscreteValue();
            ParameterDiscreteValue StoreNameLocalValue = new ParameterDiscreteValue();
            StoreName.ParameterFieldName = "StoreName";
            StoreNameLocal.ParameterFieldName = "StoreNameLocal";
            // Set the discrete value and pass it to the parameter
            StoreNameValue.Value = "ABC";
            StoreNameLocalValue.Value = "ABC";
            StoreName.CurrentValues.Add(StoreNameValue);
            StoreNameLocal.CurrentValues.Add(StoreNameLocalValue);
            // Add parameter to the parameter fields collection.
            paramFields.Add(StoreName);
            paramFields.Add(StoreNameLocal);
            //----------------------------End Paramter---------------

            Reports.rpt20x30mTowColumn obj = new Stock_System.Reports.rpt20x30mTowColumn();
            obj.SetDataSource(dt);
            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;
            frm2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //frm2.crystalReportViewer1.PrintReport();
            frm2.ShowDialog();

            #endregion
        }
    }
}
