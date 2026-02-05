using InventoryBrother.Application.DTOs.Reports;

namespace InventoryBrother.Application.Interfaces;

public interface IPrintService
{
    byte[] GenerateInvoicePdf(InvoiceModel model);
}
