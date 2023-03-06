using System;
using InvoiceEZ.Domain.Models;

namespace InvoiceEZ.Tests.Data
{
    public static class Invoices
    {
        private static List<Invoice> _invoiceTestCases = new List<Invoice>();
        static Invoices()
        {
            InitInvoiceTestCases();
        }

        private static void InitInvoiceTestCases()
        {
            #region InitInvoiceTestCases
            var invoiceItems = new List<List<InvoiceItem>>(){
                    new List<InvoiceItem>(){
                            Shared.InvoiceItems["banana"],
                            Shared.InvoiceItems["apple"],
                        },
                        new List<InvoiceItem>(){
                            Shared.InvoiceItems["apple"],
                            Shared.InvoiceItems["yourFavoriteFruit"]
                        },
                        new List<InvoiceItem>(){
                            Shared.InvoiceItems["yourFavoriteFruit"],
                            Shared.InvoiceItems["pomegranate"]
                        },
                        new List<InvoiceItem>(){
                            Shared.InvoiceItems["yourFavoriteFruit"]
                        },
                        new List<InvoiceItem>(){
                            Shared.InvoiceItems["yourFavoriteFruit"],
                            Shared.InvoiceItems["orange"]
                        }
                };

            _invoiceTestCases = new List<Invoice> {
                    new Invoice()
                    {
                        Id = 100,
                        CreationDate = new DateTime(2018, 1, 3).AddMinutes(-30),
                        AcceptanceDate = new DateTime(2018, 1, 3).AddMinutes(-15)
                    },
                    new Invoice()
                    {
                        Id = 101,
                        CreationDate = new DateTime(2018, 1, 4),
                    },
                    new Invoice()
                    {
                        Id = 102,
                        CreationDate = new DateTime(2018, 1, 4).AddMinutes(-30),
                        AcceptanceDate = new DateTime(2018, 1, 3).AddMinutes(-12),
                    },
                    new Invoice()
                    {
                        Id = 103,
                        CreationDate = new DateTime(2018, 1, 4).AddMinutes(-30),
                        AcceptanceDate = new DateTime(2018, 1, 3).AddMinutes(-12),
                    },
                    new Invoice()
                    {
                        Id = 104,
                        CreationDate = new DateTime(2018, 1, 4).AddMinutes(-30),
                    }
                };

            _invoiceTestCases.Select((invoice, index) => new { Invoice = invoice, Index = index })
            .ToList()
            .ForEach(x => {
                var invoice = x.Invoice;
                var index = x.Index;
                ((List<InvoiceItem>)invoice.InvoiceItems).AddRange(invoiceItems[index]);
            });
        }

        #endregion
        public static List<Invoice> InitialData
        {
            get
            {
                return _invoiceTestCases;
            }
        }

        #region ResultTestCases
        public static Dictionary<int, decimal> ResultTestCases = new Dictionary<int, decimal>(){
                {100, 34400.0m},
                {101, 125000.0m},
                {102, 141000.0m },
                {103, 120000.0m },
                {104, 150000.0m }
            };
        #endregion
        public const decimal UNPAID_AMOUNT = 275000.0m;
    }
}

