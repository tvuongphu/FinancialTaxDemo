using MediatR;
using GlobalTaxCalculation.Application.Interfaces;
using GlobalTaxCalculation.Domain;
using GlobalTaxCalculation.Application.Models;

namespace GlobalTaxCalculation.Application.Commands;

public record ValidateCommand(string countryCode, List<TaxBracketDetail> taxBracketDetail) : IRequest<ValidationResponseDto>;

public class ValidateCommandHandler(
     ITaxBracketsService taxBracketService) : IRequestHandler<ValidateCommand, ValidationResponseDto>
{
    public async Task<ValidationResponseDto> Handle(ValidateCommand request, CancellationToken cancellationToken)
    {
        var errors = new List<string>();
        if (string.IsNullOrEmpty(request.countryCode))
        {
            errors.Add($"Country is mssing.");
        }

        if (request.taxBracketDetail == null || !request.taxBracketDetail.Any())
        {
            errors.Add($"Tax Brackets is empty.");
        }

        if (request.taxBracketDetail.Any(s => s.Rate <= 0 || s.Rate >= 1))
        {
            errors.Add($"Rate must be between 0.01 and 0.99");
        }

        var items = request.taxBracketDetail?.OrderBy(s => s.Level).ToList();
        for (int i = 0; i < items?.Count() - 1; i++)
        {
            if (items?[i].Limit >= items?[i + 1].Limit)
            {
                var item = items[i + 1];
                errors.Add($"Level {item.Level} - limit {item.Limit} - must be higher than previous level.");
            }

            if (items?[i].Rate >= items?[i + 1].Rate)
            {
                var item = items[i + 1];
                errors.Add($"Level {item.Level} - Rate {item.Rate} - must be higher than previous level.");
            }
        }

        if (errors.Count > 0)
        {
            return new ValidationResponseDto(false, errors);
        }

        return new ValidationResponseDto(true, new List<string>());
    }
}