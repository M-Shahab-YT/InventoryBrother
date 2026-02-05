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
using System.IO;

namespace Stock_System.Forms
{
    public partial class frmEmployee : Form
    {
        Dbcommon obj = new Dbcommon();
        public frmEmployee()
        {
            InitializeComponent();
        }
        private void EmpPhoto_Click(object sender, EventArgs e)
        {
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                EmpPhoto.Image = System.Drawing.Image.FromFile(OpenFile.FileName);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                SqlParameter[] p = new SqlParameter[19];
                p[0] = new SqlParameter("@EmployeeID", GetProductCode());
                p[1] = new SqlParameter("@FullName", txtFullName.Text);
                p[2] = new SqlParameter("@FatherName", txtFatherName.Text);
                p[3] = new SqlParameter("@Gender", cmbGender.Text);
                p[4] = new SqlParameter("@DateOfBirth", dtDob.Value);
                p[5] = new SqlParameter("@Address", txtCurrentAddress.Text);
                p[6] = new SqlParameter("@Mobile1", txtMobile1.Text);
                p[7] = new SqlParameter("@Mobile2", txtMobile2.Text);
                p[8] = new SqlParameter("@EmailAddress", txtEmail.Text);
                p[9] = new SqlParameter("@NIDNo", txtNIDNo.Text);
                p[10] = new SqlParameter("@GurantorPerson", txtGurantorPerson.Text);
                p[11] = new SqlParameter("@TINNo", txtTINNo.Text);
                p[12] = new SqlParameter("@Position", txtPosition.Text);
                p[13] = new SqlParameter("@Salary", txtSalary.Text);
                p[14] = new SqlParameter("@JoiningDate", dtJoiningDate.Value);
                p[15] = new SqlParameter("@StoreID", conclass.StoreID);
                p[16] = new SqlParameter("@Remarks", "");
                if (this.OpenFile.FileName != "openFileDialog1")
                {
                    p[17] = new SqlParameter("@Photo", SqlDbType.VarBinary);
                    p[17].Value = File.ReadAllBytes(this.OpenFile.FileName);
                }
                else
                {
                    p[17] = new SqlParameter("@Photo", SqlDbType.VarBinary);
                    p[17].Value = DBNull.Value;
                }
                p[18] = new SqlParameter("@UserID", conclass.User_ID);
                conclass.insert_update("HRMIS_ProEmployeeInformationInsert", p);
                MessageBox.Show("Saved Successfully.");
            }
            else
            {
                SqlParameter[] p = new SqlParameter[17];
                p[0] = new SqlParameter("@EmployeeID", txtFullName.Tag.ToString());
                p[1] = new SqlParameter("@FullName", txtFullName.Text);
                p[2] = new SqlParameter("@FatherName", txtFatherName.Text);
                p[3] = new SqlParameter("@Gender", cmbGender.Text);
                p[4] = new SqlParameter("@DateOfBirth", dtDob.Value);
                p[5] = new SqlParameter("@Address", txtCurrentAddress.Text);
                p[6] = new SqlParameter("@Mobile1", txtMobile1.Text);
                p[7] = new SqlParameter("@Mobile2", txtMobile2.Text);
                p[8] = new SqlParameter("@EmailAddress", txtEmail.Text);
                p[9] = new SqlParameter("@NIDNo", txtNIDNo.Text);
                p[10] = new SqlParameter("@GurantorPerson", txtGurantorPerson.Text);
                p[11] = new SqlParameter("@TINNo", txtTINNo.Text);
                p[12] = new SqlParameter("@Position", txtPosition.Text);
                p[13] = new SqlParameter("@Salary", txtSalary.Text);
                p[14] = new SqlParameter("@JoiningDate", dtJoiningDate.Value);
                p[15] = new SqlParameter("@Status", cmbStatus.Text);
                /// The image will made balnk after update the emp record i will find the sultion from internet
                if (this.OpenFile.FileName != "openFileDialog1")
                {
                    p[16] = new SqlParameter("@Photo", SqlDbType.VarBinary);
                    p[16].Value = File.ReadAllBytes(this.OpenFile.FileName);
                }
                else
                {
                    p[16] = new SqlParameter("@Photo", SqlDbType.VarBinary);
                    p[16].Value = DBNull.Value;
                }
                conclass.insert_update("HRMIS_ProEmployeeInformationUpdate", p);
                MessageBox.Show("Saved Successfully.");
            }
            fillGrid();
            ClearBoxes();
        }
        public string GetProductCode()
        {

            DataTable dt = new DataTable();
            dt = conclass.GetRecord(@"select isnull(max(EmployeeID),0)+1 as maxID from HRMIS_tblEmployeeInformation");

            string Code = dt.Rows[0]["maxID"].ToString();
            if (Code == "")
            {
                return "00001";
            }
            int ID = 0;
            int.TryParse(Code, out ID);
            switch (ID.ToString().Length)
            {
                case 1:
                    Code = "0000" + ID.ToString();
                    break;
                case 2:
                    Code = "000" + ID.ToString();
                    break;
                case 3:
                    Code = "00" + ID.ToString();
                    break;
                case 4:
                    Code = "0" + ID.ToString();
                    break;
                case 5:
                    Code = ID.ToString();
                    break;
            }
            return Code;
        }
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            fillGrid();
            cmbStatus.Text = "Active";
        }
        private void fillGrid()
        {
            DataTable dt = obj.GetData(@"SELECT   TOP (20) EmployeeID, FullName, FatherName, Gender,convert(varchar(12), DateOfBirth,107) as DateOfBirth, Address, Mobile1, Position, Salary,convert(varchar(12), JoiningDate,107) as JoiningDate, Photo
FROM         HRMIS_tblEmployeeInformation order by EmployeeID desc ");
            dataGridView1.DataSource = dt;
        }
        private void PayrollMonths()
        {
            //This will help us to check the account payable section for balance sheet
            // 1. first will  create the table
            //2. will make code for active customer
            //3. this will call once new customer come
            //4. one buttion to call it for the first time for current employees

            DataTable dt_Month = obj.GetData("SELECT Month_ID FROM FMIS_tblFinancialYearMonths WHERE AC_ID=(select Max(AC_ID) from FMIS_tblFinancialYearMonths)");
            obj.con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction tran = obj.con.BeginTransaction();
            cmd.Transaction = tran;
            cmd.Connection = obj.con;
            try
            {
                foreach (DataRow drM in dt_Month.Rows)
                {
                    cmd.CommandText = @"insert into FMIS_tblSalaryPayable(EmployeeID, MonthID, TotalSalary, TotalPaid, Balance) values(EmployeeID, MonthID, TotalSalary, TotalPaid, Balance)";
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch (SqlException Sexp)
            {
                tran.Rollback();
                obj.con.Close();
            }
            catch (Exception ex)
            {
                obj.con.Close();
            }
            finally
            {
                obj.con.Close();
            }
        
        
        }
        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT  EmployeeID, FullName, FatherName, Gender,convert(varchar(12), DateOfBirth,107) as DateOfBirth, Address, Mobile1, Position, Salary,convert(varchar(12), JoiningDate,107) as JoiningDate, Photo
FROM         HRMIS_tblEmployeeInformation where FullName like N'%" + txtFullName.Text + "%'");
            dataGridView1.DataSource = dt;
        }
        private void btnBrows_Click(object sender, EventArgs e)
        {
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                EmpPhoto.Image = System.Drawing.Image.FromFile(OpenFile.FileName);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = obj.GetData(@"SELECT        EmployeeID, FullName, FatherName, Gender, DateOfBirth, Address, Mobile1, Position, Salary,Status, JoiningDate, Photo, Mobile2, EmailAddress, 
                         JoiningDate , GurantorPerson, TINNo, NIDNo
FROM            HRMIS_tblEmployeeInformation where EmployeeID=" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "");
            if (dt.Rows.Count > 0)
            {
                txtFullName.Tag = dt.Rows[0]["EmployeeID"].ToString();
                txtFullName.Text = dt.Rows[0]["FullName"].ToString();
                txtFatherName.Text = dt.Rows[0]["FatherName"].ToString();
                cmbGender.Text = dt.Rows[0]["Gender"].ToString();
                dtDob.Value = Convert.ToDateTime(dt.Rows[0]["DateOfBirth"].ToString());
                txtCurrentAddress.Text = dt.Rows[0]["Address"].ToString();
                txtMobile1.Text = dt.Rows[0]["Mobile1"].ToString();
                txtMobile2.Text = dt.Rows[0]["Mobile2"].ToString();
                dtJoiningDate.Value = Convert.ToDateTime(dt.Rows[0]["JoiningDate"].ToString());
                txtEmail.Text = dt.Rows[0]["EmailAddress"].ToString();
                txtGurantorPerson.Text = dt.Rows[0]["GurantorPerson"].ToString();
                txtPosition.Text = dt.Rows[0]["Position"].ToString();
                txtNIDNo.Text = dt.Rows[0]["NIDNo"].ToString();
                txtTINNo.Text = dt.Rows[0]["TINNo"].ToString();
                txtSalary.Text = dt.Rows[0]["Salary"].ToString();
                cmbStatus.Text = dt.Rows[0]["Status"].ToString();
                if (dt.Rows[0]["Photo"] != null)
                {
                    byte[] bt = dt.Rows[0]["Photo"] as byte[];
                    if (bt != null)
                    {
                        MemoryStream ms = new MemoryStream(bt);
                        this.EmpPhoto.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        this.EmpPhoto.Image = null;
                        this.EmpPhoto.Invalidate();
                    }
                }
                else
                {
                    this.EmpPhoto.Image = null;
                    this.EmpPhoto.Invalidate();
                }
                btnSave.Text = "Update";
            }
        }


        private void ClearBoxes()
        {
            txtFullName.Text = "";
            txtFatherName.Text = "";
            txtGurantorPerson.Text = "";
            txtMobile1.Text = "";
            txtMobile2.Text = "";
            txtNIDNo.Text = "";
            txtPosition.Text = "";
            txtSalary.Text = "";
            txtTINNo.Text = "";
            txtEmail.Text = "";
            txtCurrentAddress.Text = "";
            btnSave.Text = "Save";
            Photo.Image = null;
            txtFullName.Focus();
        
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            ClearBoxes();
        }

       
    }
}
