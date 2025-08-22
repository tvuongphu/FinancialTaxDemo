using GlobalTax.Domain;

namespace GlobalTax.Application.Models;

// Tax
public record ValidationResponseDto(bool? Success, List<string> Response);

public record UpdateBracketResponseDto(bool? Success, string Response);

public record GetTaxBracketResponseDto(bool? Success, string Response, List<TaxBracketDetail>? Brackets);


// Country
public record GetCountryResponseDto(bool? Success, string Response, List<Country>? Country);

