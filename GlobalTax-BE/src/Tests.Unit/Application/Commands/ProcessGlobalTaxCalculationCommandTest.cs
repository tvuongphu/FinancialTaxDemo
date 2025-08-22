using System.Threading.Tasks;
using AutoFixture;
using Moq;
//using GlobalTaxCalculation.Application.Commands;
using GlobalTaxCalculation.Application.Interfaces;
using Xunit;

namespace GlobalTaxCalculation.Tests.Unit.Application.Commands;

public class ProcessGlobalTaxCalculationCommandTest
    : TestBase
{
    //private readonly IFixture _fixture;
    //private readonly ProcessGlobalTaxCalculationHandler _handler;
    //private readonly Mock<IGlobalTaxCalculationService> _mockService;

    //public ProcessGlobalTaxCalculationCommandTest()
    //{
    //    _fixture = new Fixture().Customize(new BaseFixture());
    //    _mockService = new Mock<IGlobalTaxCalculationService>();
    //    _handler = new ProcessGlobalTaxCalculationHandler(
    //        _dbContext,
    //        _mockService.Object
    //    );
    //}

    //[Fact]
    //public void Ctor_DependenciesInjected_CommandConstructed()
    //{
    //    // Arrange
    //    // Act
    //    var handler = new ProcessGlobalTaxCalculationHandler(
    //        _dbContext,
    //        _mockService.Object
    //    );

    //    // Assert
    //    Assert.NotNull(handler);
    //}

    //[Fact]
    //public async Task CreateGlobalTaxCalculation_InputValid_SaveSucess()
    //{
    //    // Arrange
    //    var globaltaxcalculation = _fixture.Build<Domain.GlobalTaxCalculation>().Create();
    //    var globaltaxcalculationModel = _fixture.Build<GlobalTaxCalculation.Application.Models.GlobalTaxCalculationDto>()
    //        .With(m => m.Property, globaltaxcalculation.Property)
    //        .Create();

    //    var command = _fixture.Build<ProcessGlobalTaxCalculationCommand>()
    //        .With(x => x.GlobalTaxCalculation, globaltaxcalculationModel)
    //        .Create();

    //    await _handler.Handle(command, default);

    //    Assert.All(_dbContext.GlobalTaxCalculations, globaltaxcalculationFromDb => Assert.Equal(globaltaxcalculation.Property, globaltaxcalculationFromDb.Property));
    //}
}