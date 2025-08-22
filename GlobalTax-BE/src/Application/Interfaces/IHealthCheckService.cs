using Refit;

namespace GlobalTax.Application.Interfaces;

public interface IHealthCheckService
{
    Task<IApiResponse> GetDownstreamServiceLivenessAsync();
}