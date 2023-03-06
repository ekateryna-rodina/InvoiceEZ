using System;
using System.Diagnostics;
using FluentAssertions;
using InvoiceEZ.Domain.Models;
using InvoiceEZ.Infrastructure;
using InvoiceEZ.Tests.Utils;
using Moq;

namespace InvoiceEZ.Tests.StressLoading
{
	public class InvoiceRepositoryTests
	{
        private Mock<IQueryable<Invoice>> _mockInvoices;
        private Mock<IQueryable<Invoice>> _mockInvoices_f;

        private InvoiceRepository _repository;
        private InvoiceRepository_f _repository_f;
        private Mock<InvoiceEZ.Common.Logging.ILogger> _mockLogger;

        [SetUp]
        public void SetUp()
        {
            _mockInvoices = new Mock<IQueryable<Invoice>>();
            _mockInvoices_f = new Mock<IQueryable<Invoice>>();

            _mockLogger = new Mock<InvoiceEZ.Common.Logging.ILogger>();

            _repository = new InvoiceRepository(_mockInvoices.Object, _mockLogger.Object);
            _repository_f = new InvoiceRepository_f(_mockInvoices_f.Object, _mockLogger.Object);
        }

        [Test]
        public void GetTotal_100Invoices_LINQ() {
            // Arrange
            var invoices = RandomNumberInvoiceGenerator.GenerateInvoices(100);
            SeedInvoiceRepository(invoices);

            // Act
            Stopwatch sw = new Stopwatch();
            sw.Start();
            _repository.GetTotal(99);
            sw.Stop();

            // Assert
            Console.WriteLine($"GetTotal_100Invoices_L {sw.Elapsed.ToString()}: ");
            Assert.Pass();
        }

        [Test]
        public void GetTotal_100Invoices_Vanilla()
        {
            // Arrange
            var invoices = RandomNumberInvoiceGenerator.GenerateInvoices(100);
            SeedInvoiceRepository_f(invoices);

            // Act
            Stopwatch sw = new Stopwatch();
            sw.Start();
            _repository_f.GetTotal(99);
            sw.Stop();

            // Assert
            Console.WriteLine($"GetTotal_100Invoices_V {sw.Elapsed.ToString()}: ");
            Assert.Pass();
        }

        [Test]
        public void GetTotalUnpaid_100Invoices_LINQ()
        {
            // Arrange
            var invoices = RandomNumberInvoiceGenerator.GenerateInvoices(100);
            SeedInvoiceRepository(invoices);

            // Act
            Stopwatch sw = new Stopwatch();
            sw.Start();
            _repository.GetTotalOfUnpaid();
            sw.Stop();

            // Assert
            Console.WriteLine($"GetTotalUnpaid_100Invoices_L {sw.Elapsed.ToString()}: ");
            Assert.Pass();
        }

        [Test]
        public void GetTotalUnpaid_100Invoices_Vanilla()
        {
            // Arrange
            var invoices = RandomNumberInvoiceGenerator.GenerateInvoices(100);
            SeedInvoiceRepository_f(invoices);

            // Act
            Stopwatch sw = new Stopwatch();
            sw.Start();
            _repository_f.GetTotalOfUnpaid();
            sw.Stop();

            // Assert
            Console.WriteLine($"GetTotalUnpaid_100Invoices_V {sw.Elapsed.ToString()}: ");
            Assert.Pass();
        }

        [Test]
        public void GetItemsReport_100Invoices_LINQ()
        {
            // Arrange
            var invoices = RandomNumberInvoiceGenerator.GenerateInvoices(100);
            SeedInvoiceRepository(invoices);

            // Act
            Stopwatch sw = new Stopwatch();
            sw.Start();
            _repository.GetItemsReport(null, null);
            sw.Stop();

            // Assert
            Console.WriteLine($"GetItemsReport_100Invoices_L {sw.Elapsed.ToString()}: ");
            Assert.Pass();
        }

        [Test]
        public void GetItemsReport_100Invoices_Vanilla()
        {
            // Arrange
            var invoices = RandomNumberInvoiceGenerator.GenerateInvoices(100);
            SeedInvoiceRepository_f(invoices);

            // Act
            Stopwatch sw = new Stopwatch();
            sw.Start();
            _repository_f.GetItemsReport(null, null);
            sw.Stop();

            // Assert
            Console.WriteLine($"GetItemsReport_100Invoices_V {sw.Elapsed.ToString()}: ");
            Assert.Pass();
        }


        [Test]
        public void GetTotal_1000Invoices_LINQ()
        {
            // Arrange
            var invoices = RandomNumberInvoiceGenerator.GenerateInvoices(1000);
            SeedInvoiceRepository(invoices);

            // Act
            Stopwatch sw = new Stopwatch();
            sw.Start();
            _repository.GetTotal(999);
            sw.Stop();

            // Assert
            Console.WriteLine($"GetTotal_1000Invoices_L {sw.Elapsed.ToString()}: ");
            Assert.Pass();
        }

        [Test]
        public void GetTotal_1000Invoices_Vanilla()
        {
            // Arrange
            var invoices = RandomNumberInvoiceGenerator.GenerateInvoices(1000);
            SeedInvoiceRepository_f(invoices);

            // Act
            Stopwatch sw = new Stopwatch();
            sw.Start();
            _repository_f.GetTotal(999);
            sw.Stop();

            // Assert
            Console.WriteLine($"GetTotal_1000Invoices_V {sw.Elapsed.ToString()}: ");
            Assert.Pass();
        }

        [Test]
        public void GetTotalUnpaid_1000Invoices_LINQ()
        {
            // Arrange
            var invoices = RandomNumberInvoiceGenerator.GenerateInvoices(1000);
            SeedInvoiceRepository(invoices);

            // Act
            Stopwatch sw = new Stopwatch();
            sw.Start();
            _repository.GetTotalOfUnpaid();
            sw.Stop();

            // Assert
            Console.WriteLine($"GetTotalUnpaid_1000Invoices_L {sw.Elapsed.ToString()}: ");
            Assert.Pass();
        }

        [Test]
        public void GetTotalUnpaid_1000Invoices_Vanilla()
        {
            // Arrange
            var invoices = RandomNumberInvoiceGenerator.GenerateInvoices(1000);
            SeedInvoiceRepository_f(invoices);

            // Act
            Stopwatch sw = new Stopwatch();
            sw.Start();
            _repository_f.GetTotalOfUnpaid();
            sw.Stop();

            // Assert
            Console.WriteLine($"GetTotalUnpaid_1000Invoices_V {sw.Elapsed.ToString()}: ");
            Assert.Pass();
        }

        [Test]
        public void GetItemsReport_1000Invoices_LINQ()
        {
            // Arrange
            var invoices = RandomNumberInvoiceGenerator.GenerateInvoices(1000);
            SeedInvoiceRepository(invoices);

            // Act
            Stopwatch sw = new Stopwatch();
            sw.Start();
            _repository.GetItemsReport(null, null);
            sw.Stop();

            // Assert
            Console.WriteLine($"GetItemsReport_1000Invoices_L {sw.Elapsed.ToString()}: ");
            Assert.Pass();
        }

        [Test]
        public void GetItemsReport_1000Invoices_Vanilla()
        {
            // Arrange
            var invoices = RandomNumberInvoiceGenerator.GenerateInvoices(1000);
            SeedInvoiceRepository_f(invoices);

            // Act
            Stopwatch sw = new Stopwatch();
            sw.Start();
            _repository_f.GetItemsReport(null, null);
            sw.Stop();

            // Assert
            Console.WriteLine($"GetItemsReport_1000Invoices_V {sw.Elapsed.ToString()}: ");
            Assert.Pass();
        }

        private void SeedInvoiceRepository(IEnumerable<Invoice> invoices)
        {
            _mockInvoices.Setup(i => i.GetEnumerator()).Returns(invoices.GetEnumerator());
            _mockInvoices.Setup(i => i.Provider).Returns(invoices.AsQueryable().Provider);
            _mockInvoices.Setup(i => i.Expression).Returns(invoices.AsQueryable().Expression);
            _mockInvoices.Setup(i => i.ElementType).Returns(invoices.AsQueryable().ElementType);
        }

        private void SeedInvoiceRepository_f(IEnumerable<Invoice> invoices)
        {
            _mockInvoices_f.Setup(i => i.GetEnumerator()).Returns(invoices.GetEnumerator());
            _mockInvoices_f.Setup(i => i.Provider).Returns(invoices.AsQueryable().Provider);
            _mockInvoices_f.Setup(i => i.Expression).Returns(invoices.AsQueryable().Expression);
            _mockInvoices_f.Setup(i => i.ElementType).Returns(invoices.AsQueryable().ElementType);
        }
    }
}

