using InvoiceEZ.Common.Logging;
using InvoiceEZ.Domain.Models;

namespace InvoiceEZ.Infrastructure;
public class InvoiceRepository
{
    private readonly IQueryable<Invoice> _invoices;
    private readonly ILogger _logger;
    public InvoiceRepository(IQueryable<Invoice> invoices, ILogger logger)
    {
        _invoices = invoices ?? throw new ArgumentNullException(nameof(invoices));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    public IReadOnlyDictionary<string, long> GetItemsReport(DateTime? from, DateTime? to)
    {
        if (from.HasValue && to.HasValue && from > to)
        {
            var errorMessage = $"Invalid range: from date {from} is greater than to {to}";
            _logger.LogError(errorMessage);
            throw new ArgumentException(errorMessage);
        }

        // filter invoices by creation date if from or to dates are specified
        var items = _invoices
                .Where(i => from == null || i.CreationDate >= from)
                .Where(i => to == null || i.CreationDate <= to)
                    .SelectMany(i => i.InvoiceItems);
        var result = items.GroupBy(item => item.Name)
            .ToDictionary(g => g.Key, g => g.Sum(item => item.Count));
        _logger.LogInformation($"INFRA: report is fetched successfully");
        return result;
    }
    public decimal? GetTotal(int invoiceId)
    {
        decimal? total = null;

        var invoice = _invoices.FirstOrDefault(i => i.Id == invoiceId);
        if (invoice == null)
        {
            _logger.LogWarning($"INFRA: invoice is null");
            return null;
        }

        total = invoice.InvoiceItems.Sum(item => item.Price * item.Count);
        _logger.LogInformation($"INFRA: total amount is ${total}");
        return total;
    }

    public decimal GetTotalOfUnpaid()
    {
        decimal total = 0;
        total = _invoices.Where(i => i.AcceptanceDate == null)
            .Sum(i => i.InvoiceItems.Sum(item => item.Price * item.Count));
        _logger.LogInformation($"INFRA: total of unpaid invoices is ${total}");
        return total;
    }
}

