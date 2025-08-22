using MediatR;
using GlobalTax.Application.Interfaces;
using GlobalTax.Application.Models;

namespace GlobalTax.Application.Queries;

public record GetAllCountryQuery() : IRequest<GetCountryResponseDto>;

public class GetAllCountryQueryHandler(
    ICountryService countryService
) : IRequestHandler<GetAllCountryQuery, GetCountryResponseDto>
{
    public async Task<GetCountryResponseDto> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
    {
        return await countryService.GetAll();
    }
}