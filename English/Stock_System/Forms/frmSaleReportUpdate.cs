using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stock_System.Class;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
namespace Stock_System.Forms
{
    public partial class frmSaleReportUpdate : Form
    {
        public frmSaleReportUpdate()
        {
            InitializeComponent();
        }
        Dbcommon obj = new Dbcommon();
        DataTable TempTrans = new DataTable();
        private void btnView_Click(object sender, EventArgs e)
        {
            //string from = this.dtfrom.Value.Month.ToString() + "/" + this.dtfrom.Value.Day.ToString() + "/" + this.dtfrom.Value.Year.ToString();
            //string to = this.dtto.Value.Month.ToString() + "/" + this.dtto.Value.Day.ToString() + "/" + this.dtto.Value.Year.ToString();
            string from = this.dtfrom.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string to = this.dtto.Value.ToString("yyyy-MM-dd HH:mm:ss");
            #region Summary Report
            DataTable dt = obj.GetData(@"SELECT   FMIS_VWCashInCashOut.ID, FMIS_VWCashInCashOut.AccountID, FMIS_tblCashAccounts.AccountName, 
                         Lookup_tblCurrency.CurrencyName,CONVERT(varchar(12), FMIS_VWCashInCashOut.SystemDate, 107) AS Date, FMIS_VWCashInCashOut.EntryReference, FMIS_VWCashInCashOut.EntryReferenceNumber, FMIS_VWCashInCashOut.Remarks, 
                         FMIS_VWCashInCashOut.DR, FMIS_VWCashInCashOut.CR, FMIS_VWCashInCashOut.UserName,'View' as Detail,CONVERT(varchar(12), FMIS_VWCashInCashOut.SystemDate, 107) as SystemDate FROM         FMIS_VWCashInCashOut INNER JOIN  FMIS_tblCashAccounts ON FMIS_VWCashInCashOut.AccountID = FMIS_tblCashAccounts.AccountID INNER JOIN
                         Lookup_tblCurrency ON FMIS_tblCashAccounts.CurrencyID = Lookup_tblCurrency.CurrencyID where FMIS_tblCashAccounts.StoreID=" + conclass.StoreID + " and FMIS_VWCashInCashOut.SystemDate >= CAST('" + from + "' AS DATETIME) AND FMIS_VWCashInCashOut.SystemDate <= CAST('" + to + "' AS DATETIME) AND FMIS_VWCashInCashOut.AccountID=" + cmbPaymentAccount.SelectedValue + " ORDER BY CASE  WHEN FMIS_VWCashInCashOut.EntryReference LIKE 'Sales' THEN 1 WHEN FMIS_VWCashInCashOut.EntryReference LIKE 'Sale Return%' THEN 2  WHEN FMIS_VWCashInCashOut.EntryReference LIKE 'Purchase%' THEN 3  WHEN FMIS_VWCashInCashOut.EntryReference LIKE 'Purchase Return%' THEN 4  ELSE 5 END, FMIS_VWCashInCashOut.ID");
            dgAccount.DataSource = dt;
            TempTrans = dt;
            Decimal TotalDr = 0;
            Decimal TotalCr = 0;
            foreach (DataRow dr in dt.Rows)
            {
                TotalDr = TotalDr + Decimal.Parse(dr["DR"].ToString());
                TotalCr = TotalCr + Decimal.Parse(dr["CR"].ToString());
            }
            lblTotalDr.Text = TotalDr.ToString();
            lblTotalCr.Text = TotalCr.ToString();
            #endregion

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Reports.rptCashFlow obj = new Stock_System.Reports.rptCashFlow();
            obj.SetDataSource(TempTrans);
            Reports.Report_Form frm2 = new Stock_System.Reports.Report_Form();
            frm2.crystalReportViewer1.ReportSource = obj;
            //  frm2.crystalReportViewer1.PrintReport();
            frm2.ShowDialog();
        }
        private void GetReport()
        {

            iTextSharp.text.Font FontRed = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.RED);
            iTextSharp.text.Font FontBlue = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLUE);
            iTextSharp.text.Font fontTitle = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            Document doc = new Document(new iTextSharp.text.Rectangle(PageSize.A4));
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Report.pdf", FileMode.Create));
            doc.Open();
            doc.NewPage();
            Decimal GrandTotalDR = 0;
            Decimal GrandTotalCR = 0;

            #region Header
            Paragraph titleAccountName = new Paragraph("Account: " + cmbPaymentAccount.Text, fontTitle);
            titleAccountName.Alignment = Element.ALIGN_LEFT;
            titleAccountName.SpacingAfter = 10.0f;
            doc.Add(titleAccountName);



            Paragraph title = new Paragraph("Date: " + System.DateTime.Today.Date.ToString("dd/MM/yyyy"), fontTitle);
            title.Alignment = Element.ALIGN_LEFT;
            title.SpacingAfter = 5.0f;
            doc.Add(title);




            Paragraph title2 = new Paragraph("From Date: " + dtfrom.Text, fontTitle);
            title2.Alignment = Element.ALIGN_LEFT;
            title2.SpacingAfter = 5.0f;
            doc.Add(title2);
            Paragraph title3 = new Paragraph("To Date:   " + dtto.Text, fontTitle);
            title3.Alignment = Element.ALIGN_LEFT;
            title3.SpacingAfter = 5.0f;
            doc.Add(title3);
            #endregion

            string from = this.dtfrom.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string to = this.dtto.Value.ToString("yyyy-MM-dd HH:mm:ss");

            DataTable dt = obj.GetData(@"SELECT   FMIS_VWCashInCashOut.ID, FMIS_VWCashInCashOut.AccountID, FMIS_tblCashAccounts.AccountName, 
                        Lookup_tblCurrency.CurrencyName,CONVERT(varchar(12), FMIS_VWCashInCashOut.SystemDate, 107) AS Date, FMIS_VWCashInCashOut.EntryReference, FMIS_VWCashInCashOut.EntryReferenceNumber, FMIS_VWCashInCashOut.Remarks, 
                         FMIS_VWCashInCashOut.DR, FMIS_VWCashInCashOut.CR, FMIS_VWCashInCashOut.UserName,'View' as Detail,CONVERT(varchar(12), FMIS_VWCashInCashOut.SystemDate, 107) as SystemDate FROM         FMIS_VWCashInCashOut INNER JOIN  FMIS_tblCashAccounts ON FMIS_VWCashInCashOut.AccountID = FMIS_tblCashAccounts.AccountID INNER JOIN
                        Lookup_tblCurrency ON FMIS_tblCashAccounts.CurrencyID = Lookup_tblCurrency.CurrencyID where FMIS_tblCashAccounts.StoreID=" + conclass.StoreID + " and FMIS_VWCashInCashOut.SystemDate >= CAST('" + from + "' AS DATETIME) AND FMIS_VWCashInCashOut.SystemDate <= CAST('" + to + "' AS DATETIME) AND FMIS_VWCashInCashOut.AccountID=" + cmbPaymentAccount.SelectedValue + " ORDER BY CASE  WHEN FMIS_VWCashInCashOut.EntryReference LIKE 'Sales' THEN 1 WHEN FMIS_VWCashInCashOut.EntryReference LIKE 'Sale Return' THEN 2  WHEN FMIS_VWCashInCashOut.EntryReference LIKE 'Purchase%' THEN 3  WHEN FMIS_VWCashInCashOut.EntryReference LIKE 'Purchase Return%' THEN 4  ELSE 5 END");


            // Grouping data by EntryReference
            var groupedData = dt.AsEnumerable()
                .GroupBy(row => row.Field<string>("EntryReference"))
                .ToDictionary(g => g.Key, g => g.ToList());

            foreach (var group in groupedData)
            {
                Decimal TotalDR = 0;
                Decimal TotalCR = 0;
                string referenceType = group.Key;
                var rows = group.Value;

                #region Cash Flow Table
                PdfPTable tblSales = new PdfPTable(6);
                tblSales.WidthPercentage = 100;
                tblSales.HeaderRows = 2;

                Paragraph SHeaderValue = new Paragraph(referenceType, FontBlue);
                SHeaderValue.Alignment = Element.ALIGN_CENTER;
                PdfPCell SHeader = new PdfPCell(SHeaderValue);
                SHeader.Colspan = 6;
                SHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                tblSales.AddCell(SHeader);

                // Column Header
                tblSales.AddCell("SNO");
                tblSales.AddCell("Transaction No");
                tblSales.AddCell("Date");
                tblSales.AddCell("Reference No.");
                tblSales.AddCell("IN");
                tblSales.AddCell("OUT");

                int RowNumber = 1;
                foreach (var dr in rows)
                {
                    tblSales.AddCell(RowNumber.ToString());
                    tblSales.AddCell(dr["ID"].ToString());
                    tblSales.AddCell(dr["Date"].ToString());
                    tblSales.AddCell(dr["EntryReferenceNumber"].ToString());
                    tblSales.AddCell(dr["DR"].ToString());
                    tblSales.AddCell(dr["CR"].ToString());
                    TotalDR += Decimal.Parse(dr["DR"].ToString());
                    TotalCR += Decimal.Parse(dr["CR"].ToString());

                    GrandTotalDR += Decimal.Parse(dr["DR"].ToString());
                    GrandTotalCR += Decimal.Parse(dr["CR"].ToString());


                    RowNumber++;
                }

                PdfPCell TotalCell = new PdfPCell(new Phrase("Total:"));
                TotalCell.Colspan = 4;
                TotalCell.HorizontalAlignment = Element.ALIGN_LEFT;
                tblSales.AddCell(TotalCell);

                PdfPCell TotalDr = new PdfPCell(new Phrase(TotalDR.ToString()));
                TotalDr.HorizontalAlignment = Element.ALIGN_LEFT;
                tblSales.AddCell(TotalDr);
                PdfPCell TotalCr = new PdfPCell(new Phrase(TotalCR.ToString()));
                TotalCr.HorizontalAlignment = Element.ALIGN_LEFT;
                tblSales.AddCell(TotalCr);

                tblSales.SpacingAfter = 20.0f;
                doc.Add(tblSales);
                #endregion



            }
            #region Summary
            Paragraph ParaGrandTotalIN = new Paragraph("Total IN :" + GrandTotalDR, FontBlue);
            ParaGrandTotalIN.Alignment = Element.ALIGN_LEFT;
            ParaGrandTotalIN.SpacingAfter = 5.0f;

            Paragraph ParaGrandTotalOut = new Paragraph("Total Out :" + GrandTotalCR, FontRed);
            ParaGrandTotalOut.Alignment = Element.ALIGN_LEFT;
            ParaGrandTotalOut.SpacingAfter = 5.0f;

            Paragraph ParaBalance = new Paragraph("Balance: " + Math.Round((GrandTotalDR - GrandTotalCR), 2).ToString(), fontTitle);
            ParaBalance.Alignment = Element.ALIGN_LEFT;
            ParaBalance.SpacingAfter = 5.0f;

            doc.Add(ParaGrandTotalIN);
            doc.Add(ParaGrandTotalOut);
            doc.Add(ParaBalance);
            #endregion
            doc.Close();
            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Report.pdf");
        }

        private void btnGroupReport_Click(object sender, EventArgs e)
        {
            GetReport();
        }

        private void frmSaleReportUpdate_Load(object sender, EventArgs e)
        {
            obj.fillcmb(cmbPaymentAccount, "AccountName", "AccountID", "SELECT  AccountID, AccountName FROM FMIS_tblCashAccounts where StoreID=" + conclass.StoreID + "");
        }
    }
}
