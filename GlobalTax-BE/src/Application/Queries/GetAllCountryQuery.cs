using MediatR;
using GlobalTaxCalculation.Application.Interfaces;
using GlobalTaxCalculation.Application.Models;

namespace GlobalTaxCalculation.Application.Queries;

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