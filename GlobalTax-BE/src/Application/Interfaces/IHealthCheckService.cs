using Refit;

namespace GlobalTaxCalculation.Application.Interfaces;

public interface IHealthCheckService
{
    Task<IApiResponse> GetDownstreamServiceLivenessAsync();
}