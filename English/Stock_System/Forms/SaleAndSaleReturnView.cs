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
using CrystalDecisions.Shared;

namespace Stock_System.Forms
{
    public partial class SaleAndSaleReturnView : Form
    {
        public SaleAndSaleReturnView()
        {
            InitializeComponent();
        }
        Decimal TotalSalesValue = 0;
        Decimal TotalProfitValue = 0;
        Decimal TotalQty = 0;
        Decimal TotalDiscount = 0;
        private void SaleAndSaleReturnView_Load(object sender, EventArgs e)
        {
            lstSearch.Text = "Search By Date";
        }

        private void btnSearch_Click1(object sender, EventArgs e)
        {
            if (lstSearch.SelectedItem == null)
                lstSearch.Text = "Search By Date";
            if (lstSearch.SelectedItem.ToString() == "Search By Date")
            {

                # region Search By Date
                string from = this.dtfrom.Value.ToString("yyyy-MM-dd");
                string to = this.dtto.Value.ToString("yyyy-MM-dd");

                try
                {
                    //TempDt = null;
                    lstInvoiceDetail.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"
DECLARE @StartDate DATETIME = '2025-05-17';  
DECLARE @EndDate DATETIME = '2025-05-17';    
DECLARE @UserIds VARCHAR(MAX) = '1C7E6236-2579-4B72-BBD9-F7A9307BCFEF'; -- example GUIDs
 SELECT
    SOD.SNO,
    Convert(varchar(12), SOD.SystemDate, 107) as Date, 
   CONVERT(varchar(5), SOD.SystemDate, 108) as Time, 


    SOD.InvoiceNo,
    PI.CustomerID,
    PI.CustomerName,
    SOD.ProductCode,
    IP.ProductName,
    IPC.CategoryName,
    SOD.Quantity,
    SOD.BaseCurrencyAveragePrice AS StockPrice,
    SOD.BaseCurrencySalePrice AS SalePrice,
    SOD.BaseCurrencyDiscount AS Discount,
    SOD.BaseCurrencyTotal AS Total,
    SOD.BaseCurrencyProfitPerUnit AS ProfitPerUnit,
    SOD.TotalBaseCurrencyProfit AS TotalProfit,
    'Sale' AS Status,
    SUM(SOD.BaseCurrencyTotal) AS TotalAmount,
    AU.UserId AS UserID,
    AU.UserName AS UserName
FROM IMIS_tblSaleOrderDetail SOD
INNER JOIN IMIS_tblProduct IP ON SOD.ProductCode = IP.ProductCode
INNER JOIN IMIS_tblProductCategory IPC ON IP.ProductCategoryID = IPC.CategoryCode
INNER JOIN IMIS_tblSaleOrderMain SOM ON SOD.InvoiceNo = SOM.InvoiceNo
INNER JOIN IMIS_tblCustomer PI ON SOM.CustomerID = PI.CustomerID
INNER JOIN aspnet_Users AU ON SOM.UserID = AU.UserId
WHERE
    SOD.SystemDate >= @StartDate
    AND SOD.SystemDate <= @EndDate
    AND SOD.StoreID = 1
    AND AU.UserId IN (SELECT value FROM dbo.SplitString(@UserIds, ','))
GROUP BY
    SOD.SNO, SOD.SystemDate, SOD.InvoiceNo, PI.CustomerID, PI.CustomerName,
    SOD.ProductCode, IP.ProductName, IPC.CategoryName, SOD.Quantity, SOD.BaseCurrencyAveragePrice,
    SOD.BaseCurrencySalePrice, SOD.BaseCurrencyDiscount, SOD.BaseCurrencyTotal,
    SOD.BaseCurrencyProfitPerUnit, SOD.TotalBaseCurrencyProfit, AU.UserId, AU.UserName

	         UNION ALL
            SELECT
                SRD.ID AS SNO,
                CONVERT(varchar(12), SRD.ReturnDate, 107) AS Date,
                CONVERT(VARCHAR, SRD.ReturnDate, 8) AS Time,
                SRD.InvoiceNo,
                PI.CustomerID,
                PI.CustomerName,
              
                SRD.ProductCode,
                IP.ProductName,
                IPC.CategoryName,
                SRD.ReturnQuantity AS Quantity,
                SOD.BaseCurrencyAveragePrice AS StockPrice,
                SOD.BaseCurrencySalePrice AS SalePrice,
                SOD.BaseCurrencyDiscount AS Discount,
                SRD.ReturnAmount * -1 AS Total,
                SOD.BaseCurrencyProfitPerUnit * -1 AS ProfitPerUnit,
                (SOD.BaseCurrencyProfitPerUnit * SRD.ReturnQuantity) * -1 AS TotalProfit,
                'Return' AS Status,
                SUM(SRD.ReturnAmount) * -1 AS TotalAmount,
                AU.UserId AS UserID,
                AU.UserName AS UserName
            FROM SaleReturnDetail SRD
            INNER JOIN SaleReturnMain SRM ON SRD.SaleReturnID = SRM.SaleReturnID
            INNER JOIN IMIS_tblCustomer PI ON SRM.CustomerID = PI.CustomerID
            INNER JOIN IMIS_tblSaleOrderDetail SOD ON SRD.RowNumber = SOD.SNO
            INNER JOIN IMIS_tblSaleOrderMain SOM ON SRD.InvoiceNo = SOM.InvoiceNo
        
            INNER JOIN IMIS_tblProduct IP ON SRD.ProductCode = IP.ProductCode
            INNER JOIN IMIS_tblProductCategory IPC ON IP.ProductCategoryID = IPC.CategoryCode
            INNER JOIN aspnet_Users AU ON SRM.SaleReturnBy = AU.UserId
            WHERE
                CAST(CONVERT(varchar(12), SRD.ReturnDate, 107) AS datetime) >= @StartDate
                AND CAST(CONVERT(varchar(12), SRD.ReturnDate, 107) AS datetime) <= @EndDate
                AND SRD.StoreID = 1
                AND AU.UserId IN (SELECT value FROM dbo.SplitString(@UserIds, ','))
            GROUP BY
                SRD.ID, SRD.ReturnDate, SRD.InvoiceNo, PI.CustomerID, PI.CustomerName,
                SRD.ProductCode, IP.ProductName, IPC.CategoryName, SRD.ReturnQuantity, SOD.BaseCurrencyAveragePrice,
                SOD.BaseCurrencySalePrice, SOD.BaseCurrencyDiscount, SRD.ReturnAmount, SOD.BaseCurrencyProfitPerUnit,
                AU.UserId, AU.UserName");
                    //TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["Date"].ToString());
                        item.SubItems.Add(dr["Time"].ToString());
                        item.SubItems.Add(dr["InvoiceNo"].ToString());
                        item.SubItems.Add(dr["CustomerName"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["CategoryName"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["StockPrice"].ToString());
                        item.SubItems.Add(dr["SalePrice"].ToString());
                        item.SubItems.Add(dr["Discount"].ToString());
                        item.SubItems.Add(dr["Total"].ToString());
                        item.SubItems.Add(dr["ProfitPerUnit"].ToString());
                        item.SubItems.Add(dr["TotalProfit"].ToString());
                        item.SubItems.Add(dr["Status"].ToString());
                        item.SubItems.Add(dr["TotalAmount"].ToString());
                        item.SubItems.Add(dr["UserName"].ToString());
                        lstInvoiceDetail.Items.Add(item);
                    }
                 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                #endregion

            }
            else if (lstSearch.SelectedItem.ToString() == "By Item & Date")
            {
                # region Search By Date

                string from = this.dtfrom.Value.ToString("yyyy-MM-dd");
                string to = this.dtto.Value.ToString("yyyy-MM-dd");
                try
                {
                    //TempDt = null;
                    lstInvoiceDetail.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT        IMIS_tblSaleOrderDetail.SNO, IMIS_tblSaleOrderDetail.InvoiceNo, IMIS_tblSaleOrderDetail.ProductCode, IMIS_tblSaleOrderDetail.BatchNo, IMIS_tblSaleOrderDetail.ExpiryDate, IMIS_tblSaleOrderDetail.ProductStockID, 
                         IMIS_tblSaleOrderDetail.Quantity, IMIS_tblSaleOrderDetail.BaseCurrencyAveragePrice, IMIS_tblSaleOrderDetail.SalePrice, IMIS_tblSaleOrderDetail.Discount, IMIS_tblSaleOrderDetail.CurrencyID, 
                         IMIS_tblSaleOrderDetail.ExchangeRate, IMIS_tblSaleOrderDetail.BaseCurrencySalePrice, IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, IMIS_tblSaleOrderDetail.TotalBaseCurrencyProfit, IMIS_tblSaleOrderDetail.Total, 
                         IMIS_tblSaleOrderDetail.BaseCurrencyTotal,
                         IMIS_tblSaleOrderDetail.BaseCurrencyDiscount, IMIS_tblSaleOrderDetail.QuantityReturned,convert(varchar(12), IMIS_tblSaleOrderDetail.SystemDate,107)as SystemDate, IMIS_tblProduct.ProductName, IMIS_tblProduct.ProductGenericName
FROM            IMIS_tblSaleOrderDetail INNER JOIN
                         IMIS_tblProduct ON IMIS_tblSaleOrderDetail.ProductCode = IMIS_tblProduct.ProductCode
						 where IMIS_tblSaleOrderDetail.SystemDate >= CAST('" + from + "' AS DATETIME) AND IMIS_tblSaleOrderDetail.SystemDate <= CAST('" + to + "' AS DATETIME)  and IMIS_tblSaleOrderDetail.Status!='Full Returned' and IMIS_tblProduct.ProductName like N'%" + txtSearch.Text.Trim() + "%' order by IMIS_tblSaleOrderDetail.SNO ");
                    //TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["ProductGenericName"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyAveragePrice"].ToString());
                        item.SubItems.Add(dr["BaseCurrencySalePrice"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyDiscount"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyTotal"].ToString());
                        item.SubItems.Add(dr["TotalBaseCurrencyProfit"].ToString());
                        TotalSalesValue = TotalSalesValue + Decimal.Parse(dr["BaseCurrencyTotal"].ToString());
                        TotalProfitValue = TotalProfitValue + Decimal.Parse(dr["TotalBaseCurrencyProfit"].ToString());
                        TotalQty = TotalQty + Decimal.Parse(dr["Quantity"].ToString());
                        TotalDiscount = TotalDiscount + (Decimal.Parse(dr["Quantity"].ToString()) * Decimal.Parse(dr["BaseCurrencyDiscount"].ToString()));
                        lstInvoiceDetail.Items.Add(item);
                    }
                    txtTotalProfitValue.Text = TotalProfitValue.ToString();
                    txtTotalSaleValue.Text = TotalSalesValue.ToString();
                    txtTotalQty.Text = TotalQty.ToString();
                    txtTotalDiscount.Text = TotalDiscount.ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                #endregion
            }
            else if (lstSearch.SelectedItem.ToString() == "Search By Generic Name")
            {
                # region Search By Date

                string from = this.dtfrom.Value.ToString("yyyy-MM-dd");
                string to = this.dtto.Value.ToString("yyyy-MM-dd");
                try
                {
                    //TempDt = null;
                    lstInvoiceDetail.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT        IMIS_tblSaleOrderDetail.SNO, IMIS_tblSaleOrderDetail.InvoiceNo, IMIS_tblSaleOrderDetail.ProductCode, IMIS_tblSaleOrderDetail.BatchNo, IMIS_tblSaleOrderDetail.ExpiryDate, IMIS_tblSaleOrderDetail.ProductStockID, 
                         IMIS_tblSaleOrderDetail.Quantity, IMIS_tblSaleOrderDetail.BaseCurrencyAveragePrice, IMIS_tblSaleOrderDetail.SalePrice, IMIS_tblSaleOrderDetail.Discount, IMIS_tblSaleOrderDetail.CurrencyID, 
                         IMIS_tblSaleOrderDetail.ExchangeRate, IMIS_tblSaleOrderDetail.BaseCurrencySalePrice, IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, IMIS_tblSaleOrderDetail.TotalBaseCurrencyProfit, IMIS_tblSaleOrderDetail.Total, 
                         IMIS_tblSaleOrderDetail.BaseCurrencyTotal,
                         IMIS_tblSaleOrderDetail.BaseCurrencyDiscount, IMIS_tblSaleOrderDetail.QuantityReturned,convert(varchar(12), IMIS_tblSaleOrderDetail.SystemDate,107)as SystemDate, IMIS_tblProduct.ProductName, IMIS_tblProduct.ProductGenericName
FROM            IMIS_tblSaleOrderDetail INNER JOIN
                         IMIS_tblProduct ON IMIS_tblSaleOrderDetail.ProductCode = IMIS_tblProduct.ProductCode
						 where IMIS_tblSaleOrderDetail.SystemDate >= CAST('" + from + "' AS DATETIME) AND IMIS_tblSaleOrderDetail.SystemDate <= CAST('" + to + "' AS DATETIME)  and IMIS_tblSaleOrderDetail.Status!='Full Returned' and IMIS_tblProduct.ProductGenericName like N'%" + txtSearch.Text.Trim() + "%' order by IMIS_tblSaleOrderDetail.SNO ");
                    //TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["ProductGenericName"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyAveragePrice"].ToString());
                        item.SubItems.Add(dr["BaseCurrencySalePrice"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyDiscount"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyTotal"].ToString());
                        item.SubItems.Add(dr["TotalBaseCurrencyProfit"].ToString());
                        TotalSalesValue = TotalSalesValue + Decimal.Parse(dr["BaseCurrencyTotal"].ToString());
                        TotalProfitValue = TotalProfitValue + Decimal.Parse(dr["TotalBaseCurrencyProfit"].ToString());
                        TotalQty = TotalQty + Decimal.Parse(dr["Quantity"].ToString());
                        TotalDiscount = TotalDiscount + (Decimal.Parse(dr["Quantity"].ToString()) * Decimal.Parse(dr["BaseCurrencyDiscount"].ToString()));
                        lstInvoiceDetail.Items.Add(item);
                    }
                    txtTotalProfitValue.Text = TotalProfitValue.ToString();
                    txtTotalSaleValue.Text = TotalSalesValue.ToString();
                    txtTotalQty.Text = TotalQty.ToString();
                    txtTotalDiscount.Text = TotalDiscount.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                #endregion
            }
            else if (lstSearch.SelectedItem.ToString() == "By Item")
            {
                # region Search By Date

                try
                {
                    //TempDt = null;
                    lstInvoiceDetail.Items.Clear();
                    DataTable dt = new DataTable();
                    dt = Class.conclass.GetRecord(@"SELECT        IMIS_tblSaleOrderDetail.SNO, IMIS_tblSaleOrderDetail.InvoiceNo, IMIS_tblSaleOrderDetail.ProductCode, IMIS_tblSaleOrderDetail.BatchNo, IMIS_tblSaleOrderDetail.ExpiryDate, IMIS_tblSaleOrderDetail.ProductStockID, 
                         IMIS_tblSaleOrderDetail.Quantity, IMIS_tblSaleOrderDetail.BaseCurrencyAveragePrice, IMIS_tblSaleOrderDetail.SalePrice, IMIS_tblSaleOrderDetail.Discount, IMIS_tblSaleOrderDetail.CurrencyID, 
                         IMIS_tblSaleOrderDetail.ExchangeRate, IMIS_tblSaleOrderDetail.BaseCurrencySalePrice, IMIS_tblSaleOrderDetail.BaseCurrencyProfitPerUnit, IMIS_tblSaleOrderDetail.TotalBaseCurrencyProfit, IMIS_tblSaleOrderDetail.Total, 
                         IMIS_tblSaleOrderDetail.BaseCurrencyTotal,
                         IMIS_tblSaleOrderDetail.BaseCurrencyDiscount, IMIS_tblSaleOrderDetail.QuantityReturned,convert(varchar(12), IMIS_tblSaleOrderDetail.SystemDate,107)as SystemDate, IMIS_tblProduct.ProductName, IMIS_tblProduct.ProductGenericName
FROM            IMIS_tblSaleOrderDetail INNER JOIN
                         IMIS_tblProduct ON IMIS_tblSaleOrderDetail.ProductCode = IMIS_tblProduct.ProductCode
						 where  IMIS_tblSaleOrderDetail.Status!='Full Returned' and IMIS_tblProduct.ProductName like N'%" + txtSearch.Text.Trim() + "%' order by IMIS_tblSaleOrderDetail.SNO ");
                    //TempDt = dt;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["ProductCode"].ToString());
                        item.SubItems.Add(dr["ProductName"].ToString());
                        item.SubItems.Add(dr["ProductGenericName"].ToString());
                        item.SubItems.Add(dr["SystemDate"].ToString());
                        item.SubItems.Add(dr["Quantity"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyAveragePrice"].ToString());
                        item.SubItems.Add(dr["BaseCurrencySalePrice"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyDiscount"].ToString());
                        item.SubItems.Add(dr["BaseCurrencyTotal"].ToString());
                        item.SubItems.Add(dr["TotalBaseCurrencyProfit"].ToString());
                        TotalSalesValue = TotalSalesValue + Decimal.Parse(dr["BaseCurrencyTotal"].ToString());
                        TotalProfitValue = TotalProfitValue + Decimal.Parse(dr["TotalBaseCurrencyProfit"].ToString());
                        TotalQty = TotalQty + Decimal.Parse(dr["Quantity"].ToString());
                        TotalDiscount = TotalDiscount + (Decimal.Parse(dr["Quantity"].ToString()) * Decimal.Parse(dr["BaseCurrencyDiscount"].ToString()));
                        lstInvoiceDetail.Items.Add(item);
                    }
                    txtTotalProfitValue.Text = TotalProfitValue.ToString();
                    txtTotalSaleValue.Text = TotalSalesValue.ToString();
                    txtTotalQty.Text = TotalQty.ToString();
                    txtTotalDiscount.Text = TotalDiscount.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                #endregion
            }
        }
        public DataTable GetSaleAndReturnReport(DateTime startDate, DateTime endDate, string userIds, string searchBy, string searchValue)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_GetSaleAndReturnReport", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@UserIds", userIds);
                if (!string.IsNullOrEmpty(searchBy))
                    cmd.Parameters.AddWithValue("@SearchBy", searchBy);
                else
                    cmd.Parameters.AddWithValue("@SearchBy", DBNull.Value);

                if (!string.IsNullOrEmpty(searchValue))
                    cmd.Parameters.AddWithValue("@SearchValue", searchValue);
                else
                    cmd.Parameters.AddWithValue("@SearchValue", DBNull.Value);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {

            #region New Proce
            
//ALTER PROCEDURE [dbo].[usp_GetSaleAndReturnReport]
//    @StartDate DATETIME,
//    @EndDate DATETIME,
//    @UserIds VARCHAR(MAX),
//    @SearchBy NVARCHAR(50) = NULL,
//    @SearchValue NVARCHAR(100) = NULL
//AS
//BEGIN
//    SET NOCOUNT ON;
    
//    -- Adjust dates to include full day range
//    SET @StartDate = CAST(@StartDate AS DATE);
//    SET @EndDate = DATEADD(DAY, 1, CAST(@EndDate AS DATE));

//    -- Sale Section
//    SELECT 
//        SOD.SNO,
//        CONVERT(varchar(12), SOD.SystemDate, 107) AS Date,
//        CONVERT(varchar(5), SOD.SystemDate, 108) AS Time,
//        SOD.InvoiceNo,
//        PI.CustomerID,
//        PI.CustomerName,
//        SOD.ProductCode,
//        IP.ProductName,
//        IPC.CategoryName,
//        SOD.Quantity,
//        SOD.BaseCurrencyAveragePrice AS StockPrice,
//        SOD.BaseCurrencySalePrice AS SalePrice,
//        SOD.BaseCurrencyDiscount AS Discount,
//        SOD.BaseCurrencyDiscount * SOD.Quantity AS TotalDiscount,
//        SOD.BaseCurrencyTotal AS Total,
//        SOD.BaseCurrencyProfitPerUnit AS ProfitPerUnit,
//        SOD.TotalBaseCurrencyProfit AS TotalProfit,
//        'Sale' AS Status,
//        AU.UserId AS UserID,
//        AU.UserName AS UserName
//    FROM IMIS_tblSaleOrderDetail SOD
//    INNER JOIN IMIS_tblProduct IP ON SOD.ProductCode = IP.ProductCode
//    INNER JOIN IMIS_tblProductCategory IPC ON IP.ProductCategoryID = IPC.CategoryCode
//    INNER JOIN IMIS_tblSaleOrderMain SOM ON SOD.InvoiceNo = SOM.InvoiceNo
//    INNER JOIN IMIS_tblCustomer PI ON SOM.CustomerID = PI.CustomerID
//    INNER JOIN aspnet_Users AU ON SOM.UserID = AU.UserId
//    WHERE 
//        SOD.SystemDate >= @StartDate 
//        AND SOD.SystemDate < @EndDate
//        AND SOD.StoreID = 1
//        AND AU.UserId IN (SELECT value FROM dbo.SplitString(@UserIds, ','))
//        AND (
//            (@SearchBy IS NULL) OR
//            (@SearchBy = 'CustomerName' AND PI.CustomerName LIKE '%' + @SearchValue + '%') OR
//            (@SearchBy = 'ProductName' AND IP.ProductName LIKE '%' + @SearchValue + '%') OR
//            (@SearchBy = 'CategoryName' AND IPC.CategoryName LIKE '%' + @SearchValue + '%')
//        )

//    UNION ALL

//    -- Return Section
//    SELECT 
//        SRD.ID AS SNO,
//        CONVERT(varchar(12), SRD.ReturnDate, 107) AS Date,
//        CONVERT(varchar(5), SRD.ReturnDate, 108) AS Time, -- Consistent time format
//        SRD.InvoiceNo,
//        PI.CustomerID,
//        PI.CustomerName,
//        SRD.ProductCode,
//        IP.ProductName,
//        IPC.CategoryName,
//        SRD.ReturnQuantity AS Quantity,
//        SOD.BaseCurrencyAveragePrice AS StockPrice,
//        SOD.BaseCurrencySalePrice AS SalePrice,
//        SOD.BaseCurrencyDiscount AS Discount,
//        SOD.BaseCurrencyDiscount * SRD.ReturnQuantity AS TotalDiscount,
//        SRD.ReturnAmount * -1 AS Total,
//        SOD.BaseCurrencyProfitPerUnit * -1 AS ProfitPerUnit,
//        (SOD.BaseCurrencyProfitPerUnit * SRD.ReturnQuantity) * -1 AS TotalProfit,
//        'Return' AS Status,
//        AU.UserId AS UserID,
//        AU.UserName AS UserName
//    FROM SaleReturnDetail SRD
//    INNER JOIN SaleReturnMain SRM ON SRD.SaleReturnID = SRM.SaleReturnID
//    INNER JOIN IMIS_tblCustomer PI ON SRM.CustomerID = PI.CustomerID
//    INNER JOIN IMIS_tblSaleOrderDetail SOD ON SRD.RowNumber = SOD.SNO
//    INNER JOIN IMIS_tblSaleOrderMain SOM ON SRD.InvoiceNo = SOM.InvoiceNo
//    INNER JOIN IMIS_tblProduct IP ON SRD.ProductCode = IP.ProductCode
//    INNER JOIN IMIS_tblProductCategory IPC ON IP.ProductCategoryID = IPC.CategoryCode
//    INNER JOIN aspnet_Users AU ON SRM.SaleReturnBy = AU.UserId
//    WHERE 
//        SRD.ReturnDate >= @StartDate 
//        AND SRD.ReturnDate < @EndDate
//        AND SRD.StoreID = 1
//        AND AU.UserId IN (SELECT value FROM dbo.SplitString(@UserIds, ','))
//        AND (
//            (@SearchBy IS NULL) OR
//            (@SearchBy = 'CustomerName' AND PI.CustomerName LIKE '%' + @SearchValue + '%') OR
//            (@SearchBy = 'ProductName' AND IP.ProductName LIKE '%' + @SearchValue + '%') OR
//            (@SearchBy = 'CategoryName' AND IPC.CategoryName LIKE '%' + @SearchValue + '%')
//        )
//    ORDER BY Date DESC, Time DESC -- Optional: to order results
//END
            #endregion 



            #region Test the report
            //            DECLARE @StartDate DATETIME = '2025-07-24 00:00:00';
//DECLARE @EndDate DATETIME = '2025-07-24 12:00:00';
//DECLARE @UserIds VARCHAR(MAX) = 'c7b73233-a0be-406f-90db-3fc96fa7eaec,5af3b94b-43e6-4bcd-b253-407967fb1b10,185b7bcb-6346-40b3-ae8f-6b1d174570bc,7a923f01-4ee6-4288-ae9f-93a726d43a5e,7a48b42c-87ed-4f3c-90ce-d767f3da1d8e,1c7e6236-2579-4b72-bbd9-f7a9307bcfef,3953bbce-3d96-492a-94a4-f9ff6ce46c64';
//DECLARE @SearchBy NVARCHAR(50) = NULL;
//DECLARE @SearchValue NVARCHAR(100) = NULL;

//EXEC dbo.usp_GetSaleAndReturnReport
//    @StartDate = @StartDate,
//    @EndDate = @EndDate,
//    @UserIds = @UserIds,
//    @SearchBy = @SearchBy,
//    @SearchValue = @SearchValue;

            #endregion 
            Decimal TotalSalesValue = 0;
            Decimal TotalRetSalesValue = 0;
            Decimal TotalProfitValue = 0;
            Decimal TotalRetProfitValue = 0;
            Decimal TotalQty = 0;
            Decimal TotalRetQty = 0;
            Decimal TotalDiscount = 0;
            Decimal TotalRetDiscount = 0;
            string searchBy = null;
            string searchValue = null;
            // Format date with time
            //string startDate = dtfrom.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //string endDate = dtto.Value.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime fromDateTime = new DateTime(dtfrom.Value.Year, dtfrom.Value.Month, dtfrom.Value.Day, dtfrom.Value.Hour, dtfrom.Value.Minute, 0);
            DateTime toDateTime = new DateTime(dtto.Value.Year, dtto.Value.Month, dtto.Value.Day, dtto.Value.Hour, dtto.Value.Minute, 0);
            string startDate = fromDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            string endDate = toDateTime.ToString("yyyy-MM-dd HH:mm:ss");
             string userIds="";
            // Example user ID, adjust dynamically if needed
             if (IsUserInTempSession(conclass.User_ID) == true)
                 userIds = GetUserIDsByToUserID(conclass.User_ID);
             else if (conclass.IsInRole(conclass.UserName, "Admin"))
                 userIds = GetAllUsers();
             else
                 userIds = conclass.User_ID;
            // Determine search type
            string selectedSearch = lstSearch.SelectedItem.ToString();


            if (selectedSearch == "By Customer & Date")
            {
                searchBy = "CustomerName";
                searchValue = txtSearch.Text.Trim();
            }
            else if (selectedSearch == "By Product & Date")
            {
                searchBy = "ProductName";
                searchValue = txtSearch.Text.Trim();
            }
            else if (selectedSearch == "By Category & Date")
            {
                searchBy = "CategoryName";
                searchValue = txtSearch.Text.Trim();
            }
            // If "Search By Date", searchBy and searchValue remain null — only date range is used

            // Call your procedure (make sure it accepts string datetime and parses it correctly in SQL, or change method to accept DateTime)
            DataTable dt = GetSaleAndReturnReport(
                Convert.ToDateTime(startDate),
                Convert.ToDateTime(endDate),
                userIds,
                searchBy,
                searchValue
            );

            // Bind result to ListView
            lstInvoiceDetail.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["Date"].ToString());
                item.SubItems.Add(dr["Time"].ToString());
                item.SubItems.Add(dr["InvoiceNo"].ToString());
                item.SubItems.Add(dr["CustomerName"].ToString());
                item.SubItems.Add(dr["ProductName"].ToString());
                item.SubItems.Add(dr["CategoryName"].ToString());
                item.SubItems.Add(dr["Quantity"].ToString());
                item.SubItems.Add(dr["StockPrice"].ToString());
                item.SubItems.Add(dr["SalePrice"].ToString());
                item.SubItems.Add(dr["Discount"].ToString());
                item.SubItems.Add(dr["TotalDiscount"].ToString());
                item.SubItems.Add(dr["Total"].ToString());
                item.SubItems.Add(dr["ProfitPerUnit"].ToString());
                item.SubItems.Add(dr["TotalProfit"].ToString());
                item.SubItems.Add(dr["Status"].ToString());
                item.SubItems.Add(dr["Total"].ToString());
                item.SubItems.Add(dr["UserName"].ToString());
                if (dr["Status"].ToString() == "Sale")
                    TotalSalesValue = TotalSalesValue + Math.Abs(Decimal.Parse(dr["Total"].ToString()));
                if (dr["Status"].ToString() == "Return")
                TotalRetSalesValue = TotalRetSalesValue + Math.Abs(Decimal.Parse(dr["Total"].ToString()));
                if (dr["Status"].ToString() == "Sale")
                TotalProfitValue = TotalProfitValue + Math.Abs(Decimal.Parse(dr["TotalProfit"].ToString()));
                if (dr["Status"].ToString() == "Return")
                TotalRetProfitValue = TotalRetProfitValue + Math.Abs(Decimal.Parse(dr["TotalProfit"].ToString()));
                if (dr["Status"].ToString() == "Sale")
                TotalQty = TotalQty + Math.Abs(Decimal.Parse(dr["Quantity"].ToString()));
                if (dr["Status"].ToString() == "Return")
                TotalRetQty = TotalRetQty + Math.Abs(Decimal.Parse(dr["Quantity"].ToString()));
                if (dr["Status"].ToString() == "Sale")
                    TotalDiscount = TotalDiscount + Math.Abs(Decimal.Parse(dr["TotalDiscount"].ToString()));
                if (dr["Status"].ToString() == "Return")
                    TotalRetDiscount = TotalRetDiscount + Math.Abs(Decimal.Parse(dr["TotalDiscount"].ToString()));
                lstInvoiceDetail.Items.Add(item);
            }

            txtTotalSaleValue.Text = TotalSalesValue.ToString();
            txtTotalRetSaleValue.Text = TotalRetSalesValue.ToString();
            txtTotalNetSaleValue.Text = (TotalSalesValue - TotalRetSalesValue).ToString();


            txtTotalDiscount.Text = TotalDiscount.ToString();
            txtTotalRetDiscount.Text = TotalRetDiscount.ToString();
            txtTotalNetDiscount.Text = (TotalDiscount - TotalRetDiscount).ToString();

            txtTotalProfitValue.Text = TotalProfitValue.ToString();
            txtTotalRetProfitValue.Text = TotalRetProfitValue.ToString();
            txtTotalNetProfitValue.Text = (TotalProfitValue - TotalRetProfitValue).ToString();

            txtTotalQty.Text = TotalQty.ToString();
            txtTotalRetQty.Text = TotalRetQty.ToString();
            txtTotalNetQty.Text = (TotalQty - TotalRetQty).ToString();
        }


        public static string GetUserIDsByToUserID(string toUserID)
        {
            List<string> userIds = new List<string>();

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
            {
                string query = "SELECT UserID FROM TempSessionData WHERE ToUserID = @ToUserID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ToUserID", toUserID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userIds.Add(reader["UserID"].ToString());
                        }
                    }
                }
            }

            return string.Join(",", userIds.ToArray());
        }

        public static string GetAllUsers()
        {
            List<string> userIds = new List<string>();

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
            {
                string query = "SELECT   UserId FROM  aspnet_Users";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userIds.Add(reader["UserID"].ToString());
                        }
                    }
                }
            }

            return string.Join(",", userIds.ToArray());
        }
        public static bool IsUserInTempSession(string toUserId)
        {
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM TempSessionData WHERE ToUserID = @ToUserID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ToUserID", toUserId);
                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {

            Decimal TotalSalesValue = 0;
            Decimal TotalRetSalesValue = 0;
            Decimal TotalProfitValue = 0;
            Decimal TotalRetProfitValue = 0;
            Decimal TotalQty = 0;
            Decimal TotalRetQty = 0;
            Decimal TotalDiscount = 0;
            Decimal TotalRetDiscount = 0;
            string searchBy = null;
            string searchValue = null;
            // Format date with time
            string startDate = dtfrom.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string endDate = dtto.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string userIds = "";
            // Example user ID, adjust dynamically if needed
            if (IsUserInTempSession(conclass.User_ID) == true)
                userIds = GetUserIDsByToUserID(conclass.User_ID);
            else if (conclass.IsInRole(conclass.UserName, "Admin"))
                userIds = GetAllUsers();
            else
                userIds = conclass.User_ID;
            // Determine search type
            string selectedSearch = lstSearch.SelectedItem.ToString();
            if (selectedSearch == "By Customer & Date")
            {
                searchBy = "CustomerName";
                searchValue = txtSearch.Text.Trim();
            }
            else if (selectedSearch == "By Product & Date")
            {
                searchBy = "ProductName";
                searchValue = txtSearch.Text.Trim();
            }
            else if (selectedSearch == "By Category & Date")
            {
                searchBy = "CategoryName";
                searchValue = txtSearch.Text.Trim();
            }
            // If "Search By Date", searchBy and searchValue remain null — only date range is used

            // Call your procedure (make sure it accepts string datetime and parses it correctly in SQL, or change method to accept DateTime)
            DataTable dt = GetSaleAndReturnReport(
                Convert.ToDateTime(startDate),
                Convert.ToDateTime(endDate),
                userIds,
                searchBy,
                searchValue
            );
            foreach (DataRow dr in dt.Rows)
            {

                if (dr["Status"].ToString() == "Sale")
                    TotalSalesValue = TotalSalesValue + Math.Abs(Decimal.Parse(dr["Total"].ToString()));
                if (dr["Status"].ToString() == "Return")
                    TotalRetSalesValue = TotalRetSalesValue + Math.Abs(Decimal.Parse(dr["Total"].ToString()));
                if (dr["Status"].ToString() == "Sale")
                    TotalProfitValue = TotalProfitValue + Math.Abs(Decimal.Parse(dr["TotalProfit"].ToString()));
                if (dr["Status"].ToString() == "Return")
                    TotalRetProfitValue = TotalRetProfitValue + Math.Abs(Decimal.Parse(dr["TotalProfit"].ToString()));
                if (dr["Status"].ToString() == "Sale")
                    TotalQty = TotalQty + Math.Abs(Decimal.Parse(dr["Quantity"].ToString()));
                if (dr["Status"].ToString() == "Return")
                    TotalRetQty = TotalRetQty + Math.Abs(Decimal.Parse(dr["Quantity"].ToString()));
                if (dr["Status"].ToString() == "Sale")
                    TotalDiscount = TotalDiscount + Math.Abs(Decimal.Parse(dr["TotalDiscount"].ToString()));
                if (dr["Status"].ToString() == "Return")
                    TotalRetDiscount = TotalRetDiscount + Math.Abs(Decimal.Parse(dr["TotalDiscount"].ToString()));
                
            }
            // Compute and assign text values
            txtTotalSaleValue.Text = TotalSalesValue.ToString();
            txtTotalRetSaleValue.Text = TotalRetSalesValue.ToString();
            txtTotalNetSaleValue.Text = (TotalSalesValue - TotalRetSalesValue).ToString();

            txtTotalDiscount.Text = TotalDiscount.ToString();
            txtTotalRetDiscount.Text = TotalRetDiscount.ToString();
            txtTotalNetDiscount.Text = (TotalDiscount - TotalRetDiscount).ToString();

            txtTotalProfitValue.Text = TotalProfitValue.ToString();
            txtTotalRetProfitValue.Text = TotalRetProfitValue.ToString();
            txtTotalNetProfitValue.Text = (TotalProfitValue - TotalRetProfitValue).ToString();

            txtTotalQty.Text = TotalQty.ToString();
            txtTotalRetQty.Text = TotalRetQty.ToString();
            txtTotalNetQty.Text = (TotalQty - TotalRetQty).ToString();

            // ------------------------ Parameters -------------------
            ParameterFields paramFields = new ParameterFields();

            // Add sale-related parameters
            paramFields.Add(CreateParameter("TotalSaleValue", txtTotalSaleValue.Text));
            paramFields.Add(CreateParameter("TotalRetSaleValue", txtTotalRetSaleValue.Text));
            paramFields.Add(CreateParameter("TotalNetSaleValue", txtTotalNetSaleValue.Text));

            // Add discount-related parameters
            paramFields.Add(CreateParameter("TotalDiscount", txtTotalDiscount.Text));
            paramFields.Add(CreateParameter("TotalRetDiscount", txtTotalRetDiscount.Text));
            paramFields.Add(CreateParameter("NetDiscount", txtTotalNetDiscount.Text));

            // Add profit-related parameters
            paramFields.Add(CreateParameter("TotalProfitValue", txtTotalProfitValue.Text));
            paramFields.Add(CreateParameter("TotalRetProfitValue", txtTotalRetProfitValue.Text));
            paramFields.Add(CreateParameter("TotalNetProfitValue", txtTotalNetProfitValue.Text));

            // Add quantity-related parameters
            paramFields.Add(CreateParameter("TotalQty", txtTotalQty.Text));
            paramFields.Add(CreateParameter("TotalRetQty", txtTotalRetQty.Text));
            paramFields.Add(CreateParameter("TotalNetQty", txtTotalNetQty.Text));


            paramFields.Add(CreateParameter("FromDate", startDate));
            paramFields.Add(CreateParameter("ToDate", endDate));
        





            Reports.SaleAndSaleReturnDetail obj = new Stock_System.Reports.SaleAndSaleReturnDetail();
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


        

    }
}
