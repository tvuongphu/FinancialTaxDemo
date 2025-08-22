using GlobalTax.Application.Interfaces;
using GlobalTax.Application.Models;

namespace GlobalTax.Infrastructure.Services;

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

