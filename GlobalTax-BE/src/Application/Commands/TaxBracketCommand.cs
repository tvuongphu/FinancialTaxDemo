using MediatR;
using GlobalTax.Application.Interfaces;
using GlobalTax.Domain;
using GlobalTax.Application.Models;

namespace GlobalTax.Application.Commands;

public record TaxBracketCommand(string countryCode, List<TaxBracketDetail> taxBracketDetail) : IRequest<UpdateBracketResponseDto>;

public class TaxBracketCommandHandler(
     ITaxBracketsService taxBracketService) : IRequestHandler<TaxBracketCommand, UpdateBracketResponseDto>
{
    public async Task<UpdateBracketResponseDto> Handle(TaxBracketCommand request, CancellationToken cancellationToken)
    {
        return await taxBracketService.UpdateTaxBrackets(request.countryCode, request.taxBracketDetail);
    }
}