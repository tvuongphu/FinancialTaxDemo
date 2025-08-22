using System.Threading.Tasks;
using AutoFixture;
using Moq;
//using GlobalTax.Application.Commands;
using GlobalTax.Application.Interfaces;
using Xunit;

namespace GlobalTax.Tests.Unit.Application.Commands;

public class ProcessGlobalTaxCommandTest
    : TestBase
{
    //private readonly IFixture _fixture;
    //private readonly ProcessGlobalTaxHandler _handler;
    //private readonly Mock<IGlobalTaxService> _mockService;

    //public ProcessGlobalTaxCommandTest()
    //{
    //    _fixture = new Fixture().Customize(new BaseFixture());
    //    _mockService = new Mock<IGlobalTaxService>();
    //    _handler = new ProcessGlobalTaxHandler(
    //        _dbContext,
    //        _mockService.Object
    //    );
    //}

    //[Fact]
    //public void Ctor_DependenciesInjected_CommandConstructed()
    //{
    //    // Arrange
    //    // Act
    //    var handler = new ProcessGlobalTaxHandler(
    //        _dbContext,
    //        _mockService.Object
    //    );

    //    // Assert
    //    Assert.NotNull(handler);
    //}

    //[Fact]
    //public async Task CreateGlobalTax_InputValid_SaveSucess()
    //{
    //    // Arrange
    //    var GlobalTax = _fixture.Build<Domain.GlobalTax>().Create();
    //    var GlobalTaxModel = _fixture.Build<GlobalTax.Application.Models.GlobalTaxDto>()
    //        .With(m => m.Property, GlobalTax.Property)
    //        .Create();

    //    var command = _fixture.Build<ProcessGlobalTaxCommand>()
    //        .With(x => x.GlobalTax, GlobalTaxModel)
    //        .Create();

    //    await _handler.Handle(command, default);

    //    Assert.All(_dbContext.GlobalTaxs, GlobalTaxFromDb => Assert.Equal(GlobalTax.Property, GlobalTaxFromDb.Property));
    //}
}