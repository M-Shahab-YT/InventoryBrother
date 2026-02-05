using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
namespace CustomerDisplay
{
    public partial class frmCustomerDisplay : Form
    {
        public frmCustomerDisplay()
        {
            InitializeComponent();
        }
        public DataTable GetData(String Query)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Password=abc123@;Persist Security Info=True;User ID=sa;Initial Catalog=Inventory-Manager-Pharmacy;Data Source=192.168.1.1");
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Select Error:", ex);
            }
        }
        private void frmCustomerDisplay_Load(object sender, EventArgs e)
        {
            try
            {
                lblWelcome.Text = "";
                DataTable dt = GetData("SELECT isnull(TotalAmount,0) as TotalAmount, isnull(TotalDiscount,0) as TotalDiscount, isnull(NetTotal,0) as NetTotal, MACAddress FROM     FMIS_tblCustomerDisplay where MACAddress='" + GetMacAddress().ToString() + "'");
                if (dt.Rows.Count > 0)
                {
                    txtSubTotal.Text = dt.Rows[0]["TotalAmount"].ToString();
                    txtTotalDiscount.Text = dt.Rows[0]["TotalDiscount"].ToString();
                    txtNetTotal.Text = dt.Rows[0]["NetTotal"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }
        private void timr_Tick(object sender, EventArgs e)
        {
            try
            {
                lblWelcome.Text = "";
                DataTable dt = GetData("SELECT isnull(TotalAmount,0) as TotalAmount, isnull(TotalDiscount,0) as TotalDiscount, isnull(NetTotal,0) as NetTotal, MACAddress FROM     FMIS_tblCustomerDisplay where MACAddress='" + GetMacAddress().ToString() + "'");
                if (dt.Rows.Count > 0)
                {
                    txtSubTotal.Text = dt.Rows[0]["TotalAmount"].ToString();
                    txtTotalDiscount.Text = dt.Rows[0]["TotalDiscount"].ToString();
                    txtNetTotal.Text = dt.Rows[0]["NetTotal"].ToString();
                }
                lblWelcome.Text = "WELCOME TO HEELA KAMALI PHARMACY";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }

        }
        public static PhysicalAddress GetMacAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress();
                }
            }
            return null;
        }
    }
}
