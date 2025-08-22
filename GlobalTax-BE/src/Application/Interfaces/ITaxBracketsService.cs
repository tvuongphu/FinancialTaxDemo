using GlobalTax.Application.Models;
using GlobalTax.Domain;

namespace GlobalTax.Application.Interfaces;

public interface ITaxBracketsService
{
    Task<TaxBracket> GetTaxBracketByCountryCodeFromDb(string countryCode);
    Task<GetTaxBracketResponseDto> GetTaxBracketByCountryCode(string countryCode);
    Task<UpdateBracketResponseDto> UpdateTaxBrackets(string countryCode, List<TaxBracketDetail> taxBracketDetail);
}
