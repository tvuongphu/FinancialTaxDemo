using MediatR;
using GlobalTaxCalculation.Application.Interfaces;
using GlobalTaxCalculation.Application.Models;

namespace GlobalTaxCalculation.Application.Queries;

public record GetTaxBracketQuery(string country) : IRequest<GetTaxBracketResponseDto>;

public class GetTaxBracketQueryHandler(
    ITaxBracketsService taxBracketsService
) : IRequestHandler<GetTaxBracketQuery, GetTaxBracketResponseDto>
{
    public async Task<GetTaxBracketResponseDto> Handle(GetTaxBracketQuery request, CancellationToken cancellationToken)
    {
        return await taxBracketsService.GetTaxBracketByCountryCode(request.country);
    }
}