using InventoryBrother.Application.DTOs.Reports;
using InventoryBrother.Application.Interfaces;
using InventoryBrother.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace InventoryBrother.Infrastructure.Services;

public class ReportService : IReportService
{
    private readonly InventoryBrotherDbContext _dbContext;

    public ReportService(InventoryBrotherDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<byte[]> GenerateStockReportAsync(int storeId)
    {
        // Manual join because navigation property is missing
        var stockData = await (from s in _dbContext.Stocks
                              join p in _dbContext.Products on s.ProductCode equals p.ProductCode
                              where s.StoreId == storeId && s.Quantity > 0
                              select new StockReportItem
                              {
                                  ProductCode = s.ProductCode,
                                  ProductName = p.ProductName ?? "Unknown",
                                  BatchNo = s.BatchNo,
                                  ExpiryDate = s.ExpiryDate,
                                  Quantity = (decimal)(s.Quantity ?? 0),
                                  CostPrice = (decimal)(s.StockPrice ?? 0),
                                  SalePrice = (decimal)(p.SalePrice ?? 0)
                              }).ToListAsync();

        var model = new StockReportModel
        {
            BusinessName = "InventoryBrother ERP",
            StoreName = "Main Branch",
            ReportDate = DateTime.Now,
            Items = stockData
        };

        model.TotalValuationCost = model.Items.Sum(i => i.StockValueCost);
        model.TotalValuationSale = model.Items.Sum(i => i.StockValueSale);

        return GenerateStockPdf(model);
    }

    public async Task<byte[]> GenerateSalesSummaryReportAsync(DateTime from, DateTime to, int storeId)
    {
        var sales = await _dbContext.SaleOrders
            .Where(s => s.StoreId == storeId && s.SaleOrderDate >= DateOnly.FromDateTime(from) && s.SaleOrderDate <= DateOnly.FromDateTime(to))
            .OrderBy(s => s.SaleOrderDate)
            .ToListAsync();

        var model = new SalesSummaryReportModel
        {
            BusinessName = "InventoryBrother ERP",
            StoreName = "Main Branch",
            DateFrom = from,
            DateTo = to,
            Items = sales.Select(s => new SalesSummaryItem
            {
                Date = s.SaleOrderDate?.ToDateTime(s.SaleOrderTime ?? TimeOnly.MinValue) ?? DateTime.Now,
                InvoiceNo = s.InvoiceNo,
                CustomerName = "Walk-in Customer",
                TotalAmount = (decimal)(s.TotalOrderAmount ?? 0),
                Profit = 0, // Not available in Main table
                PaymentMethod = s.PaymentMethod ?? "Cash"
            }).ToList(),
            TotalSales = (decimal)sales.Sum(s => s.TotalOrderAmount ?? 0)
        };

        return GenerateSalesPdf(model);
    }

    private byte[] GenerateStockPdf(StockReportModel model)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(1, Unit.Centimetre);
                page.DefaultTextStyle(x => x.FontSize(10).FontFamily(Fonts.Verdana));

                page.Header().Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text(model.BusinessName).FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);
                        col.Item().Text("Stock Inventory Report").FontSize(14).SemiBold();
                    });
                    row.RelativeItem().AlignRight().Column(col =>
                    {
                        col.Item().Text($"Date: {model.ReportDate:dd/MM/yyyy}");
                        col.Item().Text($"Store: {model.StoreName}");
                    });
                });

                page.Content().PaddingVertical(10).Column(col =>
                {
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(30);
                            columns.RelativeColumn();
                            columns.ConstantColumn(80);
                            columns.ConstantColumn(70);
                            columns.ConstantColumn(70);
                            columns.ConstantColumn(80);
                        });

                        table.Header(header =>
                        {
                            header.Cell().Element(HeaderStyle).Text("#");
                            header.Cell().Element(HeaderStyle).Text("Product");
                            header.Cell().Element(HeaderStyle).Text("Batch");
                            header.Cell().Element(HeaderStyle).AlignRight().Text("Qty");
                            header.Cell().Element(HeaderStyle).AlignRight().Text("Cost");
                            header.Cell().Element(HeaderStyle).AlignRight().Text("Total (Cost)");

                            static IContainer HeaderStyle(IContainer container) => container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1);
                        });

                        int i = 1;
                        foreach (var item in model.Items)
                        {
                            table.Cell().Element(RowStyle).Text(i++.ToString());
                            table.Cell().Element(RowStyle).Text(item.ProductName);
                            table.Cell().Element(RowStyle).Text(item.BatchNo ?? "-");
                            table.Cell().Element(RowStyle).AlignRight().Text(item.Quantity.ToString("N2"));
                            table.Cell().Element(RowStyle).AlignRight().Text(item.CostPrice.ToString("N2"));
                            table.Cell().Element(RowStyle).AlignRight().Text(item.StockValueCost.ToString("N2"));

                            static IContainer RowStyle(IContainer container) => container.PaddingVertical(2).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
                        }
                    });

                    col.Item().PaddingTop(10).AlignRight().Column(summary =>
                    {
                        summary.Item().Text($"Total Stock Value (Cost): {model.TotalValuationCost:N2}").SemiBold();
                        summary.Item().Text($"Total Stock Value (Sale): {model.TotalValuationSale:N2}");
                    });
                });

                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Page ");
                    x.CurrentPageNumber();
                });
            });
        });

        return document.GeneratePdf();
    }

    private byte[] GenerateSalesPdf(SalesSummaryReportModel model)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(1, Unit.Centimetre);
                page.DefaultTextStyle(x => x.FontSize(10).FontFamily(Fonts.Verdana));

                page.Header().Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text(model.BusinessName).FontSize(20).SemiBold().FontColor(Colors.Green.Medium);
                        col.Item().Text("Sales Summary Report").FontSize(14).SemiBold();
                    });
                    row.RelativeItem().AlignRight().Column(col =>
                    {
                        col.Item().Text($"Period: {model.DateFrom:dd/MM/yyyy} - {model.DateTo:dd/MM/yyyy}");
                        col.Item().Text($"Store: {model.StoreName}");
                    });
                });

                page.Content().PaddingVertical(10).Column(col =>
                {
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(80);
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        table.Header(header =>
                        {
                            header.Cell().Element(HeaderStyle).Text("Date");
                            header.Cell().Element(HeaderStyle).Text("Invoice #");
                            header.Cell().Element(HeaderStyle).Text("Customer");
                            header.Cell().Element(HeaderStyle).Text("Method");
                            header.Cell().Element(HeaderStyle).AlignRight().Text("Amount");

                            static IContainer HeaderStyle(IContainer container) => container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1);
                        });

                        foreach (var item in model.Items)
                        {
                            table.Cell().Element(RowStyle).Text(item.Date.ToString("dd/MM/yyyy"));
                            table.Cell().Element(RowStyle).Text(item.InvoiceNo);
                            table.Cell().Element(RowStyle).Text(item.CustomerName);
                            table.Cell().Element(RowStyle).Text(item.PaymentMethod);
                            table.Cell().Element(RowStyle).AlignRight().Text(item.TotalAmount.ToString("N2"));

                            static IContainer RowStyle(IContainer container) => container.PaddingVertical(2).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
                        }
                    });

                    col.Item().PaddingTop(10).AlignRight().Text($"Total Sales: {model.TotalSales:N2}").FontSize(14).SemiBold();
                });

                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Page ");
                    x.CurrentPageNumber();
                });
            });
        });

        return document.GeneratePdf();
    }
}
