using System.Threading;
using System.Threading.Tasks;
using Moq;
using GlobalTax.Application.Models;
using GlobalTax.Application.Queries;
using Xunit;

namespace GlobalTax.Tests.Unit.Application.Queries;

public class TestGetGlobalTaxQuery
    : TestBase
{
    //[Fact]
    //public async Task TestHandler_GlobalTaxExists()
    //{
    //    // Arrange
    //    var id = 123;
    //    var property = "somevalue";
    //    var anotherProperty = "somevalue2";
    //    var creator = "testuser";
    //    _dbContext.GlobalTaxs.Add(new Domain.GlobalTax()
    //    {
    //        Id = id,
    //        Property = property,
    //        AnotherProperty = anotherProperty,
    //        Creator = creator
    //    });
    //    await _dbContext.SaveChangesAsync(CancellationToken.None);

    //    // Act
    //    var handler = new GetGlobalTaxHandler(_dbContext);
    //    var result = await handler.Handle(new GetGlobalTaxQuery(id), CancellationToken.None);

    //    // Assert
    //    Assert.Equivalent(new GlobalTaxDto(property, anotherProperty), result);
    //}
    //[Fact]
    //public async Task TestHandler_GlobalTaxNotExists()
    //{
    //    // Arrange
    //    var id = 123;
    //    // Act
    //    var handler = new GetGlobalTaxHandler(_dbContext);
    //    var result = await handler.Handle(new GetGlobalTaxQuery(id), CancellationToken.None);

    //    // Assert
    //    Assert.Null(result);
    //}
}