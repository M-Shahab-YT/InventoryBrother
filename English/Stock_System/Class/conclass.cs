using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace Stock_System.Class
{
    public class conclass
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static String User_Name;
        public static String UserName;
        public static String User_ID;
        public static String User_Type;
        public static string Stock_ID;
        public static string StoreID;
        public static string DefaultAccountID;
        public static string FullName;
        public static void opecon()
        {
            con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public static Int64 nextid(string stable, string scolumn)
        {
            opecon();
            string str = "select isnull(max(" + scolumn + "),0)+1 from " + stable + "";
            int a = 0;
            cmd = new SqlCommand(str, con);
            a = Convert.ToInt32(cmd.ExecuteScalar());
            return a;
        }
        public static int insert_update(string pro, SqlParameter[] prm)
        {

            opecon();
            cmd = new SqlCommand(pro, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(prm);
             cmd.ExecuteNonQuery();
             return 0;
        }
        public static void filcmb(ComboBox cmb, string dipm, string vm, string query)
        {
            opecon();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmb.DataSource = ds.Tables[0];
            cmb.DisplayMember = dipm;
            cmb.ValueMember = vm;
        }
        public static void fillist(ListBox lst, string dispm, string vm, string query)
        {
            opecon();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            lst.DataSource = ds.Tables[0];
            lst.DisplayMember = dispm;
            lst.ValueMember = vm;
        }
        public static void fillgrid(DataGridView Gname, string query)
        {
            opecon();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Gname.DataSource = ds.Tables[0];
        }
        public static DataTable GetRecord(string sQuery)
        {
            opecon();
            SqlDataAdapter da = new SqlDataAdapter(sQuery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetRecord1(string sQuery)
        {
            opecon();
            SqlDataAdapter da = new SqlDataAdapter(sQuery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static void ASCIn(KeyPressEventArgs ke)
        {
            Int32 icode = (int)ke.KeyChar;
            if ((icode >= 48 && icode <= 57) || (icode == 8) || (icode == 32) || (icode == 46))
            {
                ke.Handled = false;
            }
            else
            {
                ke.Handled = true;
            }
        }
        public static void ExecuteQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        public void ExecuteQuery1(string query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        public static bool IsInRole(string UserName, string RoleName)
        {
            DataTable dt = new DataTable();
            dt = GetRecord(@"SELECT   aspnet_UsersInRoles.UserId, aspnet_UsersInRoles.RoleId, aspnet_Roles.RoleName, aspnet_Users.UserName
FROM         aspnet_UsersInRoles INNER JOIN
                         aspnet_Roles ON aspnet_UsersInRoles.RoleId = aspnet_Roles.RoleId INNER JOIN
                         aspnet_Users ON aspnet_UsersInRoles.UserId = aspnet_Users.UserId
						 where aspnet_Users.UserName='" + UserName + "' and aspnet_Roles.RoleName='" + RoleName + "'");
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}
