using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace Stock_System.Class
{
    public class Dbcommon
    {
        public SqlConnection con;
        public Dbcommon()
        {
            con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
        }
        public DataTable GetData(String Query)
        {
            try
            {
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
        public void ExecuteQuery(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }
        public  void fillcmb(ComboBox cmb, string dipm, string vm, string query)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cmb.DataSource = ds;
            cmb.DisplayMember = dipm;
            cmb.ValueMember = vm;
        }
    }
}
