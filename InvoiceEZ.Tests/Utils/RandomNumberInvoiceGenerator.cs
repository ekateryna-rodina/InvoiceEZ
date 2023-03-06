using System;
using InvoiceEZ.Domain.Models;

namespace InvoiceEZ.Tests.Utils
{
	public static class RandomNumberInvoiceGenerator
	{
        public static List<Invoice> GenerateInvoices(int n)
        {
            var invoices = new List<Invoice>();
            var rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                var invoice = new Invoice
                {
                    Id = i + 1,
                    CreationDate = DateTime.Now.AddDays(-rnd.Next(1, 30)),
                    AcceptanceDate = DateTime.Now.AddDays(rnd.Next(1, 30)),
                };

                for (int j = 0; j < rnd.Next(1, 5); j++)
                {
                    invoice.InvoiceItems.Add(new InvoiceItem
                    {
                        Name = $"Item{j + 1}",
                        Count = (uint)rnd.Next(1, 10),
                        Price = rnd.Next(10, 50)
                    });
                }

                invoices.Add(invoice);
            }

            return invoices;
        }
    }
}

