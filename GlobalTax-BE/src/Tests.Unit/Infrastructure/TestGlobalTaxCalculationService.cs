using System.Threading.Tasks;
using Moq;
using GlobalTaxCalculation.Application.Interfaces;
using GlobalTaxCalculation.Application.Models;
using GlobalTaxCalculation.Infrastructure.ApiClients.DownstreamMicroservice;
using GlobalTaxCalculation.Infrastructure.Services;
using Xunit;

namespace GlobalTaxCalculation.Tests.Unit.Infrastructure;

public class TestGlobalTaxCalculationService
{
    //private readonly Mock<IApiClient> mockApiClient = new(MockBehavior.Strict);

    //private IGlobalTaxCalculationService Sut => new GlobalTaxCalculationService(mockApiClient.Object);

    //[Fact]
    //public async Task TestGetAssetByAssetCode_RetrievesFromAsset()
    //{
    //    string property = "somevalue";
    //    string anotherProperty = "somevalue2";

    //    mockApiClient
    //        .Setup(c => c.PostDownstreamDataAsync(new RequestDto(property, anotherProperty)))
    //        .ReturnsAsync(1)
    //        .Verifiable();

    //    await Sut.SomeService(new GlobalTaxCalculationDto(property, anotherProperty));

    //    mockApiClient.Verify(a=> a.PostDownstreamDataAsync(new RequestDto(property, anotherProperty)), Times.Once);
    //}
}