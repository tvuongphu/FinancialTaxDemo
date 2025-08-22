using MediatR;
using GlobalTaxCalculation.Application.Interfaces;
using GlobalTaxCalculation.Domain;
using GlobalTaxCalculation.Application.Models;

namespace GlobalTaxCalculation.Application.Commands;

public record TaxBracketCommand(string countryCode, List<TaxBracketDetail> taxBracketDetail) : IRequest<UpdateBracketResponseDto>;

public class TaxBracketCommandHandler(
     ITaxBracketsService taxBracketService) : IRequestHandler<TaxBracketCommand, UpdateBracketResponseDto>
{
    public async Task<UpdateBracketResponseDto> Handle(TaxBracketCommand request, CancellationToken cancellationToken)
    {
        return await taxBracketService.UpdateTaxBrackets(request.countryCode, request.taxBracketDetail);
    }
}