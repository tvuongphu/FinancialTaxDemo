using GlobalTaxCalculation.Application.Models;
using GlobalTaxCalculation.Domain;

namespace GlobalTaxCalculation.Application.Interfaces;

public interface ITaxBracketsService
{
    Task<TaxBracket> GetTaxBracketByCountryCodeFromDb(string countryCode);
    Task<GetTaxBracketResponseDto> GetTaxBracketByCountryCode(string countryCode);
    Task<UpdateBracketResponseDto> UpdateTaxBrackets(string countryCode, List<TaxBracketDetail> taxBracketDetail);
}
