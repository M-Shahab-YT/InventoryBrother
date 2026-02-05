using InventoryBrother.Application.DTOs.Reports;
using InventoryBrother.Application.Interfaces;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace InventoryBrother.Infrastructure.Services;

public class PrintService : IPrintService
{
    public byte[] GenerateInvoicePdf(InvoiceModel model)
    {
        // Set QuestPDF License
        QuestPDF.Settings.License = LicenseType.Community;

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(1, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(10).FontFamily(Fonts.Verdana));

                page.Header().Element(header => ComposeHeader(header, model));
                page.Content().Element(content => ComposeContent(content, model));
                page.Footer().Element(footer => ComposeFooter(footer, model));
            });
        });

        return document.GeneratePdf();
    }

    private void ComposeHeader(IContainer container, InvoiceModel model)
    {
        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                column.Item().Text(model.BusinessName).FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);
                column.Item().Text($"{model.StoreName}").FontSize(12).SemiBold();
                column.Item().Text($"{model.Address}").FontSize(10);
                column.Item().Text($"Contact: {model.Contact}").FontSize(10);
            });

            row.RelativeItem().AlignRight().Column(column =>
            {
                column.Item().Text("INVOICE").FontSize(30).SemiBold().FontColor(Colors.Grey.Medium);
                column.Item().Text($"Invoice #: {model.InvoiceNo}").FontSize(12);
                column.Item().Text($"Date: {model.Date:dd/MM/yyyy HH:mm}").FontSize(12);
            });
        });
    }

    private void ComposeContent(IContainer container, InvoiceModel model)
    {
        container.PaddingVertical(10).Column(column =>
        {
            column.Item().PaddingBottom(5).Row(row =>
            {
                row.RelativeItem().Text(text =>
                {
                    text.Span("Customer: ").SemiBold();
                    text.Span(model.CustomerName);
                });
                row.RelativeItem().AlignRight().Text(text =>
                {
                    text.Span("Cashier: ").SemiBold();
                    text.Span(model.CashierName);
                });
            });

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(30);  // SNo
                    columns.RelativeColumn();    // Product
                    columns.ConstantColumn(60);  // Qty
                    columns.ConstantColumn(80);  // Price
                    columns.ConstantColumn(60);  // Disc
                    columns.ConstantColumn(100); // Total
                });

                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("#");
                    header.Cell().Element(CellStyle).Text("Product");
                    header.Cell().Element(CellStyle).AlignRight().Text("Qty");
                    header.Cell().Element(CellStyle).AlignRight().Text("Price");
                    header.Cell().Element(CellStyle).AlignRight().Text("Disc");
                    header.Cell().Element(CellStyle).AlignRight().Text("Total");

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                    }
                });

                foreach (var item in model.Items)
                {
                    table.Cell().Element(ItemStyle).Text(item.SNo.ToString());
                    table.Cell().Element(ItemStyle).Text(item.ProductName);
                    table.Cell().Element(ItemStyle).AlignRight().Text(item.Quantity.ToString("N2"));
                    table.Cell().Element(ItemStyle).AlignRight().Text(item.Price.ToString("N2"));
                    table.Cell().Element(ItemStyle).AlignRight().Text(item.Discount.ToString("N2"));
                    table.Cell().Element(ItemStyle).AlignRight().Text(item.Total.ToString("N2"));

                    static IContainer ItemStyle(IContainer container)
                    {
                        return container.PaddingVertical(3).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
                    }
                }
            });

            column.Item().AlignRight().PaddingTop(10).Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.Cell().AlignRight().Text("Grand Total:");
                table.Cell().AlignRight().Text(model.GrandTotal.ToString("N2"));

                table.Cell().AlignRight().Text("Discount:");
                table.Cell().AlignRight().Text(model.TotalDiscount.ToString("N2"));

                table.Cell().AlignRight().Text("Net Total:").SemiBold();
                table.Cell().AlignRight().Text(model.NetTotal.ToString("N2")).SemiBold();

                table.Cell().PaddingTop(5).AlignRight().Text("Paid:");
                table.Cell().PaddingTop(5).AlignRight().Text(model.PaidAmount.ToString("N2"));

                table.Cell().AlignRight().Text("Balance Due:").FontColor(Colors.Red.Medium);
                table.Cell().AlignRight().Text(model.BalanceDue.ToString("N2")).FontColor(Colors.Red.Medium);
            });
        });
    }

    private void ComposeFooter(IContainer container, InvoiceModel model)
    {
        container.AlignBottom().Column(column =>
        {
            column.Item().PaddingTop(20).AlignCenter().Text("Thank you for your business!");
            column.Item().Text(x =>
            {
                x.Span("Page ");
                x.CurrentPageNumber();
            });
        });
    }
}
