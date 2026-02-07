using InventoryBrother.Application.Interfaces;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBrother.Infrastructure.Services;

public class ExportService : IExportService
{
    public async Task<byte[]> ExportToExcelAsync<T>(IEnumerable<T> data, string fileName)
    {
        // For portability and simplicity without adding ClosedXML/EPPlus dependencies, 
        // we'll generate a UTF-8 CSV with BOM which Excel opens perfectly.
        
        var sb = new StringBuilder();
        var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        // Header
        for (int i = 0; i < props.Length; i++)
        {
            sb.Append(props[i].Name);
            if (i < props.Length - 1) sb.Append(",");
        }
        sb.AppendLine();

        // Rows
        foreach (var item in data)
        {
            for (int i = 0; i < props.Length; i++)
            {
                var val = props[i].GetValue(item)?.ToString() ?? "";
                if (val.Contains(",") || val.Contains("\""))
                {
                    val = $"\"{val.Replace("\"", "\"\"")}\"";
                }
                sb.Append(val);
                if (i < props.Length - 1) sb.Append(",");
            }
            sb.AppendLine();
        }

        return await Task.FromResult(Encoding.UTF8.GetPreamble().Concat(Encoding.UTF8.GetBytes(sb.ToString())).ToArray());
    }

    public async Task<byte[]> ExportToPdfAsync<T>(IEnumerable<T> data, string title)
    {
        var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(1, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(10));

                page.Header().Text(title).SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);

                page.Content().PaddingVertical(10).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        foreach (var prop in props)
                        {
                            columns.RelativeColumn();
                        }
                    });

                    table.Header(header =>
                    {
                        foreach (var prop in props)
                        {
                            header.Cell().BorderBottom(1).Padding(5).Text(prop.Name).SemiBold();
                        }
                    });

                    foreach (var item in data)
                    {
                        foreach (var prop in props)
                        {
                            table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(prop.GetValue(item)?.ToString() ?? "");
                        }
                    }
                });

                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Page ");
                    x.CurrentPageNumber();
                });
            });
        });

        return await Task.FromResult(document.GeneratePdf());
    }
}
