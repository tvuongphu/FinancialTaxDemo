using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GlobalTaxCalculation.Application.Models;
using GlobalTaxCalculation.Application.Queries;

namespace GlobalTaxCalculation.Api.V1.Controllers;

[ApiVersion(1.0)]
public class CountryController(IMediator mediator) : NwController
{
    [HttpGet("GetAll")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(GetCountryResponseDto), 200)]
    public async Task<IActionResult> GetAllCountries()
    {
        var result = await mediator.Send(new GetAllCountryQuery());

        return new JsonResult(result);
    }
}