using System;
using InvoiceEZ.Common.Logging;
using InvoiceEZ.Domain.Models;

namespace InvoiceEZ.Infrastructure
{
    public class InvoiceRepository_f
    {
        private readonly IQueryable<Invoice> _invoices;
        private readonly ILogger _logger;
        public InvoiceRepository_f(IQueryable<Invoice> invoices, ILogger logger)
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

            var result = new Dictionary<string, long>();
            foreach (var invoice in _invoices.ToList())
            {
                if ((!from.HasValue|| invoice.CreationDate >= from) && (!to.HasValue || invoice.CreationDate <= to))
                {
                    foreach (var invoiceItem in invoice.InvoiceItems)
                    {
                        result[invoiceItem.Name] =
                            result.ContainsKey(invoiceItem.Name)
                                ? result[invoiceItem.Name] + invoiceItem.Count
                                : invoiceItem.Count;
                    }
                }
            }
            _logger.LogInformation($"INFRA: report is fetched successfully");
            return result;
        }
        public decimal? GetTotal(int invoiceId)
        {
            decimal total = 0;
            Invoice? invoice = null;
            foreach (var i in _invoices.ToList())
            {
                if (i.Id == invoiceId)
                {
                    invoice = i;
                    break;
                }
                continue;
            }

            if (invoice == null)
            {
                _logger.LogWarning($"INFRA: invoice is null");
                return null;
            }

            foreach (var invoiceItem in invoice.InvoiceItems)
            {
                total += invoiceItem.Price * invoiceItem.Count;
            }
            _logger.LogInformation($"INFRA: total amount is ${total}");
            return total;
        }

        public decimal GetTotalOfUnpaid()
        {
            decimal total = 0;
            foreach (var invoice in _invoices.ToList())
            {
                if (invoice.AcceptanceDate == null)
                {
                    foreach (var invoiceItem in invoice.InvoiceItems)
                    {
                        total += invoiceItem.Price * invoiceItem.Count;
                    }
                }
            }
            _logger.LogInformation($"INFRA: total of unpaid invoices is ${total}");
            return total;
        }
    }
}

