using GlobalTaxCalculation.Application.Models;

namespace GlobalTaxCalculation.Application.Interfaces;

public interface ICountryService
{   
    Task<GetCountryResponseDto> GetAll();
}
