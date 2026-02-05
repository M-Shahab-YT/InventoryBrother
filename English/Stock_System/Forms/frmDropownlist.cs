using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Stock_System.Class;

namespace Stock_System.Forms
{
    public partial class frmDropownlist : Form
    {

        string[] data = new string[] {
    "Absecon","Abstracta","Abundantia","Academia","Acadiau","Acamas",
    "Ackerman","Ackley","Ackworth","Acomita","Aconcagua","Acton","Acushnet",
    "Acworth","Ada","Ada","Adair","Adairs","Adair","Adak","Adalberta","Adamkrafft",
    "Adams"

};
        public frmDropownlist()
        {
            InitializeComponent();
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            HandleTextChanged();
        }

        private void HandleTextChanged()
        {
            var txt = comboBox1.Text;
            var list = from d in data
                       where d.ToUpper().StartsWith(comboBox1.Text.ToUpper())
                       select d;
            if (list.Count() > 0)
            {
                comboBox1.DataSource = list.ToList();
                //comboBox1.SelectedIndex = 0;
                var sText = comboBox1.Items[0].ToString();
                comboBox1.SelectionStart = txt.Length;
                comboBox1.SelectionLength = sText.Length - txt.Length;
                comboBox1.DroppedDown = true;
                return;
            }
            else
            {
                comboBox1.DroppedDown = false;
                comboBox1.SelectionStart = txt.Length;
            }
        }


        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                int sStart = comboBox1.SelectionStart;
                if (sStart > 0)
                {
                    sStart--;
                    if (sStart == 0)
                    {
                        comboBox1.Text = "";
                    }
                    else
                    {
                        comboBox1.Text = comboBox1.Text.Substring(0, sStart);
                    }
                }
                e.Handled = true;
            }
        }

        private void frmDropownlist_Load(object sender, EventArgs e)
        {
            //if(conclass.con.State==ConnectionState.Closed)
            //conclass.con.Open();
           //SqlCommand cmd = new SqlCommand("", conclass.con);
           // SqlDataReader sdr = cmd.ExecuteReader();
           // DataTable dt = new DataTable();
            DataTable dt = conclass.GetRecord("SELECT DISTINCT GroupID, GroupName FROM   IMIS_tblProductGroup");

            combo_search2.DisplayMember = "GroupName";
            combo_search2.DroppedDown = true;

            List<string> list = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(row.Field<string>("GroupName"));
            }
            this.combo_search2.Items.AddRange(list.ToArray<string>());
            combo_search2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combo_search2.AutoCompleteSource = AutoCompleteSource.ListItems;
            conclass.con.Close();
        }
     
       
    }
}
