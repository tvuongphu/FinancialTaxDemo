using GlobalTax.Application.Models;
using GlobalTax.Domain;

namespace GlobalTax.Application.Interfaces;

public interface ITaxService
{   
    Task<GetTaxBracketResponseDto> GetTaxBracket(string country);
    //Task<TaxDetailDto> CalculateTax(string country, decimal income);
}
