using System;
using InvoiceEZ.Tests.Data;

namespace InvoiceEZ.Tests.Utils
{
    public static class GetTotalTestCaseUtils
    {
        private static List<object[]> _getTotalCaseParams = new List<object[]>();

        static GetTotalTestCaseUtils()
        {
            InitTotalTestCasesData();
        }

        private static void InitTotalTestCasesData()
        {
            _getTotalCaseParams = Invoices.ResultTestCases
                    .Select(i => new object[] { i.Key, i.Value }).ToList();

        }

        public static IEnumerable<object[]> TotalCaseParams
        {
            get { return _getTotalCaseParams.AsEnumerable(); }
        }
    }
}

