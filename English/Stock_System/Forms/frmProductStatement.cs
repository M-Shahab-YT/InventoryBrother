using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.Shared;

namespace Stock_System.Forms
{
    public partial class frmProductStatement : Form
    {
        public frmProductStatement()
        {
            InitializeComponent();
        }

        private void frmProductStatement_Load(object sender, EventArgs e)
        {
            DataTable dt = GetProductSummary(" ");
            grdProductStatement.DataSource = dt;
        }



        public static DataTable GetProductSummary(string productName)
        {
            DataTable dt = new DataTable();

            // Base query
            string query = @"
        SELECT 
            ps.ProductID,
            p.ProductName,
            c.CategoryName,
            SUM(ISNULL(ps.Debit, 0)) AS TotalDebit,
            SUM(ISNULL(ps.Credit, 0)) AS TotalCredit,
            SUM(ISNULL(ps.Credit, 0)) - SUM(ISNULL(ps.Debit, 0)) AS Balance,
            'View Statement' AS Statement
        FROM 
            ProductStatement ps
        INNER JOIN 
            IMIS_tblProduct p ON p.ProductCode = ps.ProductID
        INNER JOIN 
            IMIS_tblProductCategory c ON c.CategoryCode = p.ProductCategoryID
        /**WHERE_CLAUSE**/
        GROUP BY 
            ps.ProductID, p.ProductName, c.CategoryName
        ORDER BY 
            ps.ProductID;";

            bool filterByProduct = productName != null && productName.Trim() != "";

            if (filterByProduct)
            {
                query = query.Replace("/**WHERE_CLAUSE**/", "WHERE p.ProductName LIKE @ProductName");
            }
            else
            {
                query = query.Replace("/**WHERE_CLAUSE**/", "");
            }

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (filterByProduct)
                    {
                        cmd.Parameters.AddWithValue("@ProductName", "%" + productName.Trim() + "%");
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }



        private void txtSearchValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = GetProductSummary(txtSearchValue.Text.Trim());
                grdProductStatement.DataSource = dt;
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlDetail.Visible = false;
            pnlDetail.SendToBack();
        }

        private void grdProductStatement_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdProductStatement.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "View Statement")
            {
                txtProductID.Text = grdProductStatement.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtProductName.Text = grdProductStatement.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtProductName.Tag = grdProductStatement.Rows[e.RowIndex].Cells[5].Value.ToString();
                btnCustomerStatmentView_Click(null, null);
                pnlDetail.Visible = true;
                pnlDetail.BringToFront();
            }
        }

        public static DataTable GetProductStatement(string productId, string fromDate, string toDate)
        {
            DataTable dt = new DataTable();

            string query = @"
    SELECT 
        ps.ID AS TransactionNo,
        ps.Date,
        ps.ReferenceType AS TransactionType,
        ps.Particulars,
        ps.ReferenceNumber AS ReferenceNo,
        ps.Debit,
        ps.Credit,
        SUM(ISNULL(ps.Credit, 0) - ISNULL(ps.Debit, 0)) OVER (
            PARTITION BY ps.ProductID 
            ORDER BY ps.Date, ps.ID 
            ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW
        ) AS Balance
    FROM 
        ProductStatement ps
    INNER JOIN 
        IMIS_tblProduct p ON p.ProductCode = ps.ProductID
    INNER JOIN 
        IMIS_tblProductCategory c ON c.CategoryCode = p.ProductCategoryID
    WHERE ps.ProductID = @ProductID 
    AND CAST(CONVERT(VARCHAR(12), Date, 101) AS DATETIME) >= CAST('" + fromDate + @"' AS DATETIME) 
    AND CAST(CONVERT(VARCHAR(12), Date, 101) AS DATETIME) <= CAST('" + toDate + @"' AS DATETIME) 
    ORDER BY 
        ps.ID;";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        cmd.Parameters.AddWithValue("@FromDate", DateTime.Parse(fromDate));
                        cmd.Parameters.AddWithValue("@ToDate", DateTime.Parse(toDate));

                        conn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the error
                throw;
            }

            return dt;
        }
        public static DataTable GetProductStatementReport(string productId, string fromDate, string toDate)
        {
            DataTable dt = new DataTable();

            string query = @"
    SELECT 
          ps.ID AS TransactionNo,
    ps.Date,
    ps.ProductID ,
    p.ProductName,
    c.CategoryName AS Category,
    ps.ReferenceType AS TransactionType,
    ps.ReferenceNumber AS ReferenceNo,
    ps.Particulars,
    ps.Debit,
    ps.Credit,
        SUM(ISNULL(ps.Credit, 0) - ISNULL(ps.Debit, 0)) OVER (
            PARTITION BY ps.ProductID 
            ORDER BY ps.Date, ps.ID 
            ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW
        ) AS Balance
    FROM 
        ProductStatement ps
    INNER JOIN 
        IMIS_tblProduct p ON p.ProductCode = ps.ProductID
    INNER JOIN 
        IMIS_tblProductCategory c ON c.CategoryCode = p.ProductCategoryID
    WHERE ps.ProductID = @ProductID 
    AND CAST(CONVERT(VARCHAR(12), Date, 101) AS DATETIME) >= CAST('" + fromDate + @"' AS DATETIME) 
    AND CAST(CONVERT(VARCHAR(12), Date, 101) AS DATETIME) <= CAST('" + toDate + @"' AS DATETIME) 
    ORDER BY 
        ps.ID;";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        cmd.Parameters.AddWithValue("@FromDate", DateTime.Parse(fromDate));
                        cmd.Parameters.AddWithValue("@ToDate", DateTime.Parse(toDate));

                        conn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the error
                throw;
            }

            return dt;
        }
        private void btnCustomerStatmentView_Click(object sender, EventArgs e)
        {
            try
            {
                string productId = txtProductID.Text.Trim();
                string from = dtfrom.Value.ToString("yyyy-MM-dd");
                string to = dtto.Value.ToString("yyyy-MM-dd");

                DataTable result = GetProductStatement(productId, from, to);

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("No data found for the specified criteria.");
                }

                grdStatementDetail.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnPrintAdvanceSearch_Click(object sender, EventArgs e)
        {
            string productId = txtProductID.Text.Trim();
            string from = dtfrom.Value.ToString("yyyy-MM-dd");
            string to = dtto.Value.ToString("yyyy-MM-dd");
            DataTable dt = GetProductStatementReport(productId, from, to);
            ParameterFields paramFields = new ParameterFields();
            // Add sale-related parameters
            paramFields.Add(CreateParameter("FromDate", from));
            paramFields.Add(CreateParameter("ToDate", to));
            paramFields.Add(CreateParameter("Balance", txtProductName.Tag.ToString()));

            Reports.ProductStatementDetail obj = new Stock_System.Reports.ProductStatementDetail();
            obj.SetDataSource(dt);
            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;
            frm2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //frm2.crystalReportViewer1.PrintReport();
            frm2.ShowDialog();


        }
        private ParameterField CreateParameter(string paramName, string paramValue)
        {
            ParameterField pf = new ParameterField();
            pf.ParameterFieldName = paramName;

            ParameterDiscreteValue dv = new ParameterDiscreteValue();
            dv.Value = paramValue;

            pf.CurrentValues.Add(dv);
            return pf;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = GetProductSummary(txtSearchValue.Text.Trim());
            grdProductStatement.DataSource = dt;
        }

    }
}
