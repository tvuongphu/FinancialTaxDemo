using System.Threading.Tasks;
using Moq;
using GlobalTax.Application.Interfaces;
using GlobalTax.Application.Models;
using GlobalTax.Infrastructure.Services;
using Xunit;

namespace GlobalTax.Tests.Unit.Infrastructure;

public class TestGlobalTaxService
{
    //private readonly Mock<IApiClient> mockApiClient = new(MockBehavior.Strict);

    //private IGlobalTaxService Sut => new GlobalTaxService(mockApiClient.Object);

    //[Fact]
    //public async Task TestGetAssetByAssetCode_RetrievesFromAsset()
    //{
    //    string property = "somevalue";
    //    string anotherProperty = "somevalue2";

    //    mockApiClient
    //        .Setup(c => c.PostDownstreamDataAsync(new RequestDto(property, anotherProperty)))
    //        .ReturnsAsync(1)
    //        .Verifiable();

    //    await Sut.SomeService(new GlobalTaxDto(property, anotherProperty));

    //    mockApiClient.Verify(a=> a.PostDownstreamDataAsync(new RequestDto(property, anotherProperty)), Times.Once);
    //}
}