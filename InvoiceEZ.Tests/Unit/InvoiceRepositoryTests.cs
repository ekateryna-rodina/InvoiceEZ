using FluentAssertions;
using InvoiceEZ.Infrastructure;
using InvoiceEZ.Domain.Models;
using InvoiceEZ.Tests.Data;
using InvoiceEZ.Tests.Utils;
using Moq;
using NUnit.Framework.Internal;
using InvoiceEZ.Common.Logging;

namespace InvoiceEZ.Tests.Unit;

public class InvoiceRepositoryTests
{
    private Mock<IQueryable<Invoice>> _mockInvoices;
    private InvoiceRepository _repository;
    private Mock<InvoiceEZ.Common.Logging.ILogger> _mockLogger;

    [SetUp]
    public void SetUp()
    {
        _mockInvoices = new Mock<IQueryable<Invoice>>();
        _mockLogger = new Mock<InvoiceEZ.Common.Logging.ILogger>();
        _repository = new InvoiceRepository(_mockInvoices.Object, _mockLogger.Object);
    }
    [Test]
    public void Constructor_NullInputInvoicesParameter_ExceptionShouldBeThrown()
    {
        // Arrange
        IQueryable<Invoice>? invoices = null;
        var errorMessage = "Value cannot be null. (Parameter 'invoices')";
        // warning is by design in this case because constuctor param is not nullable
        Action act = () => new InvoiceRepository(invoices, _mockLogger.Object);

        // Act & Assert
        act.Should().Throw<ArgumentNullException>().WithMessage(errorMessage);
    }

    [Test]
    public void Constructor_NullInputLoggerParameter_ExceptionShouldBeThrown()
    {
        // Arrange
        Common.Logging.ILogger logger = null;
        var errorMessage = "Value cannot be null. (Parameter 'logger')";
        // warning is by design in this case because constuctor param is not nullable
        Action act = () => new InvoiceRepository(_mockInvoices.Object, logger);

        // Act & Assert
        act.Should().Throw<ArgumentNullException>().WithMessage(errorMessage);
    }

    // Using TestCaseSource is a workaround to allow decimal as a parameter for TestCaseAttribute
    [Test, TestCaseSource(typeof(GetTotalTestCaseUtils), nameof(GetTotalTestCaseUtils.TotalCaseParams))]
    public void GetTotal_InvoicesExist_CorrectValueShouldBeReturned(int input, decimal output)
    {
        // Arrange
        var invoices = Invoices.InitialData;
        SeedInvoiceRepository(invoices);

        // Act
        var result = _repository.GetTotal(input);
        
        // Assert
        result.Should().Be(output);
        _mockLogger.Verify(x => x.LogInformation(It.IsAny<string>()), Times.Once);
    }

    [Test]
    [TestCase(4)]
    [TestCase(3)]
    [TestCase(Int32.MaxValue)]
    [TestCase(Int32.MinValue)]
    [TestCase(2)]
    [TestCase(1)]
    [TestCase(-1)]
    [TestCase(5)]
    // these invoices don't exist
    [TestCase(Int32.MinValue)]
    [TestCase(Int32.MaxValue)]
    [TestCase(5)]
    [TestCase(-1)]
    public void GetTotal_NoInvoices_NullShouldBeReturned(int input, decimal? output = null)
    {
        // Arrange
        SeedInvoiceRepository(new List<Invoice>());

        // Act
        var result = _repository.GetTotal(input);

        // Assert
        result.Should().BeNull();
        _mockLogger.Verify(x => x.LogWarning(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public void GetTotalOfUnpaid_NoInvoices_ZeroShouldBeReturned()
    {
        // Arrange
        var invoices = Invoices.InitialData.Where(i => i.AcceptanceDate != null);
        SeedInvoiceRepository(invoices);

        // Act
        var result = _repository.GetTotalOfUnpaid();

        // Assert
        result.Should().Be(0);
        _mockLogger.Verify(x => x.LogInformation(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public void GetTotalOfUnpaid_InvoicesExist_CorrectValueShouldBeReturned()
    {
        // Arrange
        var invoices = Invoices.InitialData;
        SeedInvoiceRepository(invoices);

        // Act
        var result = _repository.GetTotalOfUnpaid();

        // Assert
        result.Should().Be(Invoices.UNPAID_AMOUNT);
        _mockLogger.Verify(x => x.LogInformation(It.IsAny<string>()), Times.Once);
    }

    [Test, TestCaseSource(typeof(GetReportTestCaseUtils), nameof(GetReportTestCaseUtils.ItemReportsInvoiceExistCaseParams))]
    public void GetItemsReport_InvoicesExist_CorrectReportShouldBeReturned(DateTime? from, DateTime? to, List<Invoice> invoices, Dictionary<string, long> output)
    {
        // Arrange
        SeedInvoiceRepository(invoices);

        // Act
        var result = _repository.GetItemsReport(from, to);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(output);
        _mockLogger.Verify(x => x.LogInformation(It.IsAny<string>()), Times.Once);
    }

    [Test, TestCaseSource(typeof(GetReportTestCaseUtils), nameof(GetReportTestCaseUtils.ItemReportsNoInvoiceCaseParams))]
    public void GetItemsReport_NoInvoices_EmptyReportShouldBeReturned(DateTime? from, DateTime? to, List<Invoice> invoices)
    {
        // Arrange
        SeedInvoiceRepository(invoices);

        // Act
        var result = _repository.GetItemsReport(from, to);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(new Dictionary<string, long>());
        _mockLogger.Verify(x => x.LogInformation(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public void GetItemsReport_InvalidDatesRange_ExceptionShouldBeThrown()
    {
        // Arrange
        SeedInvoiceRepository(new List<Invoice>());

        // Act
        Action act = () => _repository.GetItemsReport(new DateTime(2018, 1, 5), new DateTime(2018, 1, 4));

        // Assert
        act.Should().Throw<ArgumentException>();
        _mockLogger.Verify(x => x.LogError(It.IsAny<string>()), Times.Once);
    }

    private void SeedInvoiceRepository(IEnumerable<Invoice> invoices)
    {
        _mockInvoices.Setup(i => i.GetEnumerator()).Returns(invoices.GetEnumerator());
        _mockInvoices.Setup(i => i.Provider).Returns(invoices.AsQueryable().Provider);
        _mockInvoices.Setup(i => i.Expression).Returns(invoices.AsQueryable().Expression);
        _mockInvoices.Setup(i => i.ElementType).Returns(invoices.AsQueryable().ElementType);
    }
}
