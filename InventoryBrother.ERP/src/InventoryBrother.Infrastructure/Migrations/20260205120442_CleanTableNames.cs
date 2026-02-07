using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryBrother.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CleanTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImisTblPurchaseReturnTransaction");

            migrationBuilder.DropTable(
                name: "ImisTblSalesReturnTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LookupTblMonth",
                table: "LookupTblMonth");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LookupTblCurrency",
                table: "LookupTblCurrency");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LookupTblCalendarType",
                table: "LookupTblCalendarType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LookupTblBusinessInformation",
                table: "LookupTblBusinessInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LookupTblArea",
                table: "LookupTblArea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImisTblUnitOfMeasurement",
                table: "ImisTblUnitOfMeasurement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImisTblSupplier",
                table: "ImisTblSupplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImisTblStore",
                table: "ImisTblStore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImisTblSize",
                table: "ImisTblSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImisTblSaleOrderMain",
                table: "ImisTblSaleOrderMain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImisTblSaleOrderDetail",
                table: "ImisTblSaleOrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImisTblReceivedLoanFromCustomer",
                table: "ImisTblReceivedLoanFromCustomer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImisTblPurchaseOrderMain",
                table: "ImisTblPurchaseOrderMain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImisTblPurchaseOrderDetail",
                table: "ImisTblPurchaseOrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImisTblProductTransfer",
                table: "ImisTblProductTransfer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImisTblProductPaking",
                table: "ImisTblProductPaking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImisTblProductLocation",
                table: "ImisTblProductLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImisTblProductGroup",
                table: "ImisTblProductGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImisTblProductCategory",
                table: "ImisTblProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImisTblProduct",
                table: "ImisTblProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImisTblManufacturer",
                table: "ImisTblManufacturer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImisTblDamageOrLost",
                table: "ImisTblDamageOrLost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImisTblCustomer",
                table: "ImisTblCustomer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImisTblColor",
                table: "ImisTblColor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImisTblBrand",
                table: "ImisTblBrand");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HrmisTblPayrollMonth",
                table: "HrmisTblPayrollMonth");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FmisTblSupplierStatement",
                table: "FmisTblSupplierStatement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FmisTblRevenueType",
                table: "FmisTblRevenueType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FmisTblRevenue",
                table: "FmisTblRevenue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FmisTblPayroll",
                table: "FmisTblPayroll");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FmisTblFinancialYearMonth",
                table: "FmisTblFinancialYearMonth");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FmisTblFinancialYear",
                table: "FmisTblFinancialYear");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FmisTblExpenseHead",
                table: "FmisTblExpenseHead");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FmisTblExpenseDetail",
                table: "FmisTblExpenseDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FmisTblEmployeeAdvanceSalary",
                table: "FmisTblEmployeeAdvanceSalary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FmisTblCustomerStatement",
                table: "FmisTblCustomerStatement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FmisTblCurrencyExchangeRate",
                table: "FmisTblCurrencyExchangeRate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FmisTblChartOfAccount",
                table: "FmisTblChartOfAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FmisTblCashierBalance",
                table: "FmisTblCashierBalance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FmisTblCashAccountsInOutDetail",
                table: "FmisTblCashAccountsInOutDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FmisTblCashAccount",
                table: "FmisTblCashAccount");

            migrationBuilder.RenameTable(
                name: "LookupTblMonth",
                newName: "Months");

            migrationBuilder.RenameTable(
                name: "LookupTblCurrency",
                newName: "Currencies");

            migrationBuilder.RenameTable(
                name: "LookupTblCalendarType",
                newName: "CalendarTypes");

            migrationBuilder.RenameTable(
                name: "LookupTblBusinessInformation",
                newName: "BusinessInformations");

            migrationBuilder.RenameTable(
                name: "LookupTblArea",
                newName: "Areas");

            migrationBuilder.RenameTable(
                name: "ImisTblUnitOfMeasurement",
                newName: "UnitOfMeasurements");

            migrationBuilder.RenameTable(
                name: "ImisTblSupplier",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "ImisTblStore",
                newName: "Stores");

            migrationBuilder.RenameTable(
                name: "ImisTblSize",
                newName: "Sizes");

            migrationBuilder.RenameTable(
                name: "ImisTblSaleOrderMain",
                newName: "SaleOrders");

            migrationBuilder.RenameTable(
                name: "ImisTblSaleOrderDetail",
                newName: "SaleOrderItems");

            migrationBuilder.RenameTable(
                name: "ImisTblReceivedLoanFromCustomer",
                newName: "CustomerLoans");

            migrationBuilder.RenameTable(
                name: "ImisTblPurchaseOrderMain",
                newName: "PurchaseOrders");

            migrationBuilder.RenameTable(
                name: "ImisTblPurchaseOrderDetail",
                newName: "PurchaseOrderItems");

            migrationBuilder.RenameTable(
                name: "ImisTblProductTransfer",
                newName: "ProductTransfers");

            migrationBuilder.RenameTable(
                name: "ImisTblProductPaking",
                newName: "ProductPackings");

            migrationBuilder.RenameTable(
                name: "ImisTblProductLocation",
                newName: "ProductLocations");

            migrationBuilder.RenameTable(
                name: "ImisTblProductGroup",
                newName: "ProductGroups");

            migrationBuilder.RenameTable(
                name: "ImisTblProductCategory",
                newName: "ProductCategories");

            migrationBuilder.RenameTable(
                name: "ImisTblProduct",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "ImisTblManufacturer",
                newName: "Manufacturers");

            migrationBuilder.RenameTable(
                name: "ImisTblDamageOrLost",
                newName: "StockDamages");

            migrationBuilder.RenameTable(
                name: "ImisTblCustomer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "ImisTblColor",
                newName: "Colors");

            migrationBuilder.RenameTable(
                name: "ImisTblBrand",
                newName: "Brands");

            migrationBuilder.RenameTable(
                name: "HrmisTblPayrollMonth",
                newName: "PayrollMonths");

            migrationBuilder.RenameTable(
                name: "FmisTblSupplierStatement",
                newName: "SupplierStatements");

            migrationBuilder.RenameTable(
                name: "FmisTblRevenueType",
                newName: "RevenueTypes");

            migrationBuilder.RenameTable(
                name: "FmisTblRevenue",
                newName: "Revenues");

            migrationBuilder.RenameTable(
                name: "FmisTblPayroll",
                newName: "Payrolls");

            migrationBuilder.RenameTable(
                name: "FmisTblFinancialYearMonth",
                newName: "FinancialYearMonths");

            migrationBuilder.RenameTable(
                name: "FmisTblFinancialYear",
                newName: "FinancialYears");

            migrationBuilder.RenameTable(
                name: "FmisTblExpenseHead",
                newName: "ExpenseHeads");

            migrationBuilder.RenameTable(
                name: "FmisTblExpenseDetail",
                newName: "ExpenseDetails");

            migrationBuilder.RenameTable(
                name: "FmisTblEmployeeAdvanceSalary",
                newName: "EmployeeAdvanceSalaries");

            migrationBuilder.RenameTable(
                name: "FmisTblCustomerStatement",
                newName: "CustomerStatements");

            migrationBuilder.RenameTable(
                name: "FmisTblCurrencyExchangeRate",
                newName: "CurrencyExchangeRates");

            migrationBuilder.RenameTable(
                name: "FmisTblChartOfAccount",
                newName: "ChartOfAccounts");

            migrationBuilder.RenameTable(
                name: "FmisTblCashierBalance",
                newName: "CashierBalances");

            migrationBuilder.RenameTable(
                name: "FmisTblCashAccountsInOutDetail",
                newName: "CashAccountTransactions");

            migrationBuilder.RenameTable(
                name: "FmisTblCashAccount",
                newName: "CashAccounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Months",
                table: "Months",
                column: "MonthId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "CurrencyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalendarTypes",
                table: "CalendarTypes",
                column: "CalendarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessInformations",
                table: "BusinessInformations",
                column: "BusinessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Areas",
                table: "Areas",
                column: "AreaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitOfMeasurements",
                table: "UnitOfMeasurements",
                column: "UnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "SupplierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stores",
                table: "Stores",
                column: "StoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "SizeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleOrders",
                table: "SaleOrders",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleOrderItems",
                table: "SaleOrderItems",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerLoans",
                table: "CustomerLoans",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseOrders",
                table: "PurchaseOrders",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseOrderItems",
                table: "PurchaseOrderItems",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTransfers",
                table: "ProductTransfers",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPackings",
                table: "ProductPackings",
                column: "PackingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductLocations",
                table: "ProductLocations",
                column: "LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductGroups",
                table: "ProductGroups",
                column: "GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                column: "CategoryCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manufacturers",
                table: "Manufacturers",
                column: "ManufacturerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockDamages",
                table: "StockDamages",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "ColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayrollMonths",
                table: "PayrollMonths",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierStatements",
                table: "SupplierStatements",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RevenueTypes",
                table: "RevenueTypes",
                column: "RevenueTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Revenues",
                table: "Revenues",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payrolls",
                table: "Payrolls",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinancialYearMonths",
                table: "FinancialYearMonths",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinancialYears",
                table: "FinancialYears",
                column: "FinancialYearId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseHeads",
                table: "ExpenseHeads",
                column: "ExpenseHeadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseDetails",
                table: "ExpenseDetails",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeAdvanceSalaries",
                table: "EmployeeAdvanceSalaries",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerStatements",
                table: "CustomerStatements",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrencyExchangeRates",
                table: "CurrencyExchangeRates",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChartOfAccounts",
                table: "ChartOfAccounts",
                column: "AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashierBalances",
                table: "CashierBalances",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashAccountTransactions",
                table: "CashAccountTransactions",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashAccounts",
                table: "CashAccounts",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitOfMeasurements",
                table: "UnitOfMeasurements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierStatements",
                table: "SupplierStatements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stores",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockDamages",
                table: "StockDamages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleOrders",
                table: "SaleOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleOrderItems",
                table: "SaleOrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RevenueTypes",
                table: "RevenueTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Revenues",
                table: "Revenues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseOrders",
                table: "PurchaseOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseOrderItems",
                table: "PurchaseOrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTransfers",
                table: "ProductTransfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPackings",
                table: "ProductPackings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductLocations",
                table: "ProductLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductGroups",
                table: "ProductGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payrolls",
                table: "Payrolls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PayrollMonths",
                table: "PayrollMonths");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Months",
                table: "Months");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manufacturers",
                table: "Manufacturers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinancialYears",
                table: "FinancialYears");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinancialYearMonths",
                table: "FinancialYearMonths");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseHeads",
                table: "ExpenseHeads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseDetails",
                table: "ExpenseDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeAdvanceSalaries",
                table: "EmployeeAdvanceSalaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerStatements",
                table: "CustomerStatements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerLoans",
                table: "CustomerLoans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrencyExchangeRates",
                table: "CurrencyExchangeRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChartOfAccounts",
                table: "ChartOfAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashierBalances",
                table: "CashierBalances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashAccountTransactions",
                table: "CashAccountTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashAccounts",
                table: "CashAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalendarTypes",
                table: "CalendarTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessInformations",
                table: "BusinessInformations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Areas",
                table: "Areas");

            migrationBuilder.RenameTable(
                name: "UnitOfMeasurements",
                newName: "ImisTblUnitOfMeasurement");

            migrationBuilder.RenameTable(
                name: "SupplierStatements",
                newName: "FmisTblSupplierStatement");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "ImisTblSupplier");

            migrationBuilder.RenameTable(
                name: "Stores",
                newName: "ImisTblStore");

            migrationBuilder.RenameTable(
                name: "StockDamages",
                newName: "ImisTblDamageOrLost");

            migrationBuilder.RenameTable(
                name: "Sizes",
                newName: "ImisTblSize");

            migrationBuilder.RenameTable(
                name: "SaleOrders",
                newName: "ImisTblSaleOrderMain");

            migrationBuilder.RenameTable(
                name: "SaleOrderItems",
                newName: "ImisTblSaleOrderDetail");

            migrationBuilder.RenameTable(
                name: "RevenueTypes",
                newName: "FmisTblRevenueType");

            migrationBuilder.RenameTable(
                name: "Revenues",
                newName: "FmisTblRevenue");

            migrationBuilder.RenameTable(
                name: "PurchaseOrders",
                newName: "ImisTblPurchaseOrderMain");

            migrationBuilder.RenameTable(
                name: "PurchaseOrderItems",
                newName: "ImisTblPurchaseOrderDetail");

            migrationBuilder.RenameTable(
                name: "ProductTransfers",
                newName: "ImisTblProductTransfer");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "ImisTblProduct");

            migrationBuilder.RenameTable(
                name: "ProductPackings",
                newName: "ImisTblProductPaking");

            migrationBuilder.RenameTable(
                name: "ProductLocations",
                newName: "ImisTblProductLocation");

            migrationBuilder.RenameTable(
                name: "ProductGroups",
                newName: "ImisTblProductGroup");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                newName: "ImisTblProductCategory");

            migrationBuilder.RenameTable(
                name: "Payrolls",
                newName: "FmisTblPayroll");

            migrationBuilder.RenameTable(
                name: "PayrollMonths",
                newName: "HrmisTblPayrollMonth");

            migrationBuilder.RenameTable(
                name: "Months",
                newName: "LookupTblMonth");

            migrationBuilder.RenameTable(
                name: "Manufacturers",
                newName: "ImisTblManufacturer");

            migrationBuilder.RenameTable(
                name: "FinancialYears",
                newName: "FmisTblFinancialYear");

            migrationBuilder.RenameTable(
                name: "FinancialYearMonths",
                newName: "FmisTblFinancialYearMonth");

            migrationBuilder.RenameTable(
                name: "ExpenseHeads",
                newName: "FmisTblExpenseHead");

            migrationBuilder.RenameTable(
                name: "ExpenseDetails",
                newName: "FmisTblExpenseDetail");

            migrationBuilder.RenameTable(
                name: "EmployeeAdvanceSalaries",
                newName: "FmisTblEmployeeAdvanceSalary");

            migrationBuilder.RenameTable(
                name: "CustomerStatements",
                newName: "FmisTblCustomerStatement");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "ImisTblCustomer");

            migrationBuilder.RenameTable(
                name: "CustomerLoans",
                newName: "ImisTblReceivedLoanFromCustomer");

            migrationBuilder.RenameTable(
                name: "CurrencyExchangeRates",
                newName: "FmisTblCurrencyExchangeRate");

            migrationBuilder.RenameTable(
                name: "Currencies",
                newName: "LookupTblCurrency");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "ImisTblColor");

            migrationBuilder.RenameTable(
                name: "ChartOfAccounts",
                newName: "FmisTblChartOfAccount");

            migrationBuilder.RenameTable(
                name: "CashierBalances",
                newName: "FmisTblCashierBalance");

            migrationBuilder.RenameTable(
                name: "CashAccountTransactions",
                newName: "FmisTblCashAccountsInOutDetail");

            migrationBuilder.RenameTable(
                name: "CashAccounts",
                newName: "FmisTblCashAccount");

            migrationBuilder.RenameTable(
                name: "CalendarTypes",
                newName: "LookupTblCalendarType");

            migrationBuilder.RenameTable(
                name: "BusinessInformations",
                newName: "LookupTblBusinessInformation");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "ImisTblBrand");

            migrationBuilder.RenameTable(
                name: "Areas",
                newName: "LookupTblArea");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImisTblUnitOfMeasurement",
                table: "ImisTblUnitOfMeasurement",
                column: "UnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FmisTblSupplierStatement",
                table: "FmisTblSupplierStatement",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImisTblSupplier",
                table: "ImisTblSupplier",
                column: "SupplierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImisTblStore",
                table: "ImisTblStore",
                column: "StoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImisTblDamageOrLost",
                table: "ImisTblDamageOrLost",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImisTblSize",
                table: "ImisTblSize",
                column: "SizeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImisTblSaleOrderMain",
                table: "ImisTblSaleOrderMain",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImisTblSaleOrderDetail",
                table: "ImisTblSaleOrderDetail",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FmisTblRevenueType",
                table: "FmisTblRevenueType",
                column: "RevenueTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FmisTblRevenue",
                table: "FmisTblRevenue",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImisTblPurchaseOrderMain",
                table: "ImisTblPurchaseOrderMain",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImisTblPurchaseOrderDetail",
                table: "ImisTblPurchaseOrderDetail",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImisTblProductTransfer",
                table: "ImisTblProductTransfer",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImisTblProduct",
                table: "ImisTblProduct",
                column: "ProductCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImisTblProductPaking",
                table: "ImisTblProductPaking",
                column: "PackingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImisTblProductLocation",
                table: "ImisTblProductLocation",
                column: "LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImisTblProductGroup",
                table: "ImisTblProductGroup",
                column: "GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImisTblProductCategory",
                table: "ImisTblProductCategory",
                column: "CategoryCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FmisTblPayroll",
                table: "FmisTblPayroll",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HrmisTblPayrollMonth",
                table: "HrmisTblPayrollMonth",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookupTblMonth",
                table: "LookupTblMonth",
                column: "MonthId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImisTblManufacturer",
                table: "ImisTblManufacturer",
                column: "ManufacturerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FmisTblFinancialYear",
                table: "FmisTblFinancialYear",
                column: "FinancialYearId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FmisTblFinancialYearMonth",
                table: "FmisTblFinancialYearMonth",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FmisTblExpenseHead",
                table: "FmisTblExpenseHead",
                column: "ExpenseHeadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FmisTblExpenseDetail",
                table: "FmisTblExpenseDetail",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FmisTblEmployeeAdvanceSalary",
                table: "FmisTblEmployeeAdvanceSalary",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FmisTblCustomerStatement",
                table: "FmisTblCustomerStatement",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImisTblCustomer",
                table: "ImisTblCustomer",
                column: "CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImisTblReceivedLoanFromCustomer",
                table: "ImisTblReceivedLoanFromCustomer",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FmisTblCurrencyExchangeRate",
                table: "FmisTblCurrencyExchangeRate",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookupTblCurrency",
                table: "LookupTblCurrency",
                column: "CurrencyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImisTblColor",
                table: "ImisTblColor",
                column: "ColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FmisTblChartOfAccount",
                table: "FmisTblChartOfAccount",
                column: "AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FmisTblCashierBalance",
                table: "FmisTblCashierBalance",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FmisTblCashAccountsInOutDetail",
                table: "FmisTblCashAccountsInOutDetail",
                column: "Sno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FmisTblCashAccount",
                table: "FmisTblCashAccount",
                column: "AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookupTblCalendarType",
                table: "LookupTblCalendarType",
                column: "CalendarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookupTblBusinessInformation",
                table: "LookupTblBusinessInformation",
                column: "BusinessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImisTblBrand",
                table: "ImisTblBrand",
                column: "BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookupTblArea",
                table: "LookupTblArea",
                column: "AreaId");

            migrationBuilder.CreateTable(
                name: "ImisTblPurchaseReturnTransaction",
                columns: table => new
                {
                    Sno = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseOrderNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturnNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImisTblPurchaseReturnTransaction", x => x.Sno);
                });

            migrationBuilder.CreateTable(
                name: "ImisTblSalesReturnTransaction",
                columns: table => new
                {
                    Sno = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturnPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    SaleOrderNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesReturnNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImisTblSalesReturnTransaction", x => x.Sno);
                });
        }
    }
}
