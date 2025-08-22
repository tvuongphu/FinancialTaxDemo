using MediatR;
using GlobalTax.Application.Interfaces;
using GlobalTax.Application.Models;

namespace GlobalTax.Application.Queries;

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