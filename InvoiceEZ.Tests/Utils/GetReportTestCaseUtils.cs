using System;
using InvoiceEZ.Tests.Data;

namespace InvoiceEZ.Tests.Utils
{
    public static class GetReportTestCaseUtils
    {
        private static List<object?[]> _invoiceExistTestParams = new List<object?[]>();
        private static List<object?[]> _noInvoiceTestParams = new List<object?[]>();
        static GetReportTestCaseUtils()
        {
            InitReportWithInvoicesTestCases();
            InitReportWithNoInvoicesTestCases();
        }
        private static void InitReportWithInvoicesTestCases()
        {
            for (var i = 0; i < ItemsReport.RangeInvoiceExistCases.Count; i++)
            {
                var testCase = new object?[]{
                    ItemsReport.RangeInvoiceExistCases[i].Item1,
                    ItemsReport.RangeInvoiceExistCases[i].Item2,
                    ItemsReport.InvoicesInTheRangeTestCases[i],
                    ItemsReport.ResultInvoceExistTestCases[i]
                 };
                _invoiceExistTestParams.Add(testCase);
            }
        }

        private static void InitReportWithNoInvoicesTestCases()
        {
            for (var i = 0; i < ItemsReport.RangeNoInvoiceCases.Count; i++)
            {
                var testCase = new object?[]{
                    ItemsReport.RangeNoInvoiceCases[i].Item1,
                    ItemsReport.RangeNoInvoiceCases[i].Item2,
                    ItemsReport.InvoicesOutOfRangeTestCases[i],
                 };
                _noInvoiceTestParams.Add(testCase);
            }
        }

        public static IEnumerable<object?[]> ItemReportsInvoiceExistCaseParams
        {
            get { return _invoiceExistTestParams.AsEnumerable(); }
        }

        public static IEnumerable<object?[]> ItemReportsNoInvoiceCaseParams
        {
            get { return _noInvoiceTestParams.AsEnumerable(); }
        }
    }
}

