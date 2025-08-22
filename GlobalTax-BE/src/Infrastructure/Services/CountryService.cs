using GlobalTaxCalculation.Application.Interfaces;
using GlobalTaxCalculation.Application.Models;

namespace GlobalTaxCalculation.Infrastructure.Services;

public class CountryService(ITaxDbContext TaxDbContext) : ICountryService
{
    public async Task<GetCountryResponseDto> GetAll()
    {
        try
        {
            var countries = TaxDbContext.Countries.ToList();
            return new GetCountryResponseDto(true, string.Empty, countries);
        }
        catch (Exception ex)
        {
            return new GetCountryResponseDto(false, ex.Message, null);
        }
    }
}

