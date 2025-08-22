using System.Threading;
using System.Threading.Tasks;
using Moq;
using GlobalTaxCalculation.Application.Models;
using GlobalTaxCalculation.Application.Queries;
using GlobalTaxCalculation.Infrastructure.ApiClients.DownstreamMicroservice;
using Xunit;

namespace GlobalTaxCalculation.Tests.Unit.Application.Queries;

public class TestGetGlobalTaxCalculationQuery
    : TestBase
{
    //[Fact]
    //public async Task TestHandler_GlobalTaxCalculationExists()
    //{
    //    // Arrange
    //    var id = 123;
    //    var property = "somevalue";
    //    var anotherProperty = "somevalue2";
    //    var creator = "testuser";
    //    _dbContext.GlobalTaxCalculations.Add(new Domain.GlobalTaxCalculation()
    //    {
    //        Id = id,
    //        Property = property,
    //        AnotherProperty = anotherProperty,
    //        Creator = creator
    //    });
    //    await _dbContext.SaveChangesAsync(CancellationToken.None);

    //    // Act
    //    var handler = new GetGlobalTaxCalculationHandler(_dbContext);
    //    var result = await handler.Handle(new GetGlobalTaxCalculationQuery(id), CancellationToken.None);

    //    // Assert
    //    Assert.Equivalent(new GlobalTaxCalculationDto(property, anotherProperty), result);
    //}
    //[Fact]
    //public async Task TestHandler_GlobalTaxCalculationNotExists()
    //{
    //    // Arrange
    //    var id = 123;
    //    // Act
    //    var handler = new GetGlobalTaxCalculationHandler(_dbContext);
    //    var result = await handler.Handle(new GetGlobalTaxCalculationQuery(id), CancellationToken.None);

    //    // Assert
    //    Assert.Null(result);
    //}
}