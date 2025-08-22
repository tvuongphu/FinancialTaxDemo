using GlobalTaxCalculation.Application.Models;
using GlobalTaxCalculation.Domain;

namespace GlobalTaxCalculation.Application.Interfaces;

public interface ITaxService
{   
    Task<GetTaxBracketResponseDto> GetTaxBracket(string country);
    //Task<TaxDetailDto> CalculateTax(string country, decimal income);
}
