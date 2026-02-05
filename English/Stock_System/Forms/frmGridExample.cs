using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Stock_System.Class;
namespace Stock_System.Forms
{
    public partial class frmGridExample : Telerik.WinControls.UI.RadForm
    {
        Dbcommon obj = new Dbcommon();
        public frmGridExample()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         string RowNumer= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Hi");
        }
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
           // MessageBox.Show("Hi");
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
                        string Code = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        Code = "00000000000" + Code;
                        DataTable dt = obj.GetData(@"SELECT        ProductCode, ProductName, ProductDescription
            FROM            IMIS_VWProducts  where ProductCode='" + Code + "'");
                        dataGridView1.Rows[e.RowIndex].Cells[1].Value = dt.Rows[0]["ProductName"].ToString();

                        //dataGridView1.ClearSelection();
                        //dataGridView1.CurrentCell = dataGridView1[3, e.RowIndex];
                        //dataGridView1.Focus();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
//            string Code = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
//            if (Code!=null)
//            {
//                Code = "00000000000" + Code;
//                DataTable dt = obj.GetData(@"SELECT        ProductCode, ProductName, ProductDescription
//FROM            IMIS_VWProducts  where ProductCode='" + Code + "'");
//                dataGridView1.Rows[e.RowIndex].Cells[1].Value = dt.Rows[0]["ProductName"].ToString();
//            }
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
//            string Code = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
//            if (Code != null)
//            {
//                Code = "00000000000" + Code;
//                DataTable dt = obj.GetData(@"SELECT        ProductCode, ProductName, ProductDescription,SalePrice
//FROM            IMIS_VWProducts  where ProductCode='" + Code + "'");
//                dataGridView1.Rows[e.RowIndex].Cells[1].Value = dt.Rows[0]["ProductName"].ToString();
//                dataGridView1.Rows[e.RowIndex].Cells[3].Value = dt.Rows[0]["SalePrice"].ToString();
              
            

            //}
        }
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
//            string Code = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
//            if (Code != null)
//            {
//                Code = "00000000000" + Code;
//                DataTable dt = obj.GetData(@"SELECT        ProductCode, ProductName, ProductDescription
//            FROM            IMIS_VWProducts  where ProductCode='" + Code + "'");
//                dataGridView1.Rows[e.RowIndex].Cells[1].Value = dt.Rows[0]["ProductName"].ToString();
//            }
        }
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
//            string Code = e.KeyChar.ToString();
//            //dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
//            if (Code != null)
//            {
//                Code = "00000000000" + Code;
//                DataTable dt = obj.GetData(@"SELECT        ProductCode, ProductName, ProductDescription
//                        FROM            IMIS_VWProducts  where ProductCode='" + Code + "'");
//                object obj2 = sender; 
//                //dataGridView1.Rows[e.RowIndex].Cells[1].Value = dt.Rows[0]["ProductName"].ToString();
//            }
        }

       
    }
}
