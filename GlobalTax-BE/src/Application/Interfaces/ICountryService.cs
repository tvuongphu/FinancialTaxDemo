using GlobalTax.Application.Models;

namespace GlobalTax.Application.Interfaces;

public interface ICountryService
{   
    Task<GetCountryResponseDto> GetAll();
}
