using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GlobalTaxCalculation.Application.Models;
using GlobalTaxCalculation.Application.Queries;
using GlobalTaxCalculation.Domain;
using GlobalTaxCalculation.Application.Commands;

namespace GlobalTaxCalculation.Api.V1.Controllers;

[ApiVersion(1.0)]
public class TaxController(IMediator mediator) : NwController
{
    [HttpPost("Validate")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ValidationResponseDto), 200)]
    public async Task<IActionResult> Validate(string countryCode, List<TaxBracketDetail> taxBracketDetail)
    {
        if (taxBracketDetail == null || !taxBracketDetail.Any())
        {
            return BadRequest("No Tax Brackets provided.");
        }

        var result = await mediator.Send(new ValidateCommand(countryCode, taxBracketDetail));

        return new JsonResult(result);
    }

    [HttpPost("UpdateTaxBrackets")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(UpdateBracketResponseDto), 200)]
    public async Task<IActionResult> Update(string countryCode, List<TaxBracketDetail> taxBracketDetail)
    {
        if (taxBracketDetail == null || !taxBracketDetail.Any())
        {
            return BadRequest("No Tax Brackets provided.");
        }

        var result = await mediator.Send(new TaxBracketCommand(countryCode, taxBracketDetail));

        return new JsonResult(result);
    }

    [HttpGet("GetTaxBracketByCountry/{country}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(GetTaxBracketResponseDto), 200)]
    public async Task<IActionResult> GetTaxBracketByCountry(string country)
    {
        var result = await mediator.Send(new GetTaxBracketQuery(country));
        return new JsonResult(result);
    }

    //[HttpGet("GetTaxDetails/{country}/{income}")]
    //[Produces("application/json")]
    //[ProducesResponseType(typeof(TaxDetailDto), 200)]
    //public async Task<IActionResult> GetTaxCalculationByCountry(string country, decimal income)
    //{
    //    var result = await mediator.Send(new GetTaxCalculationQuery(country, income));
    //    if (result.NetAmount > 0)
    //    {
    //        return Ok(result);
    //    }

    //    return new JsonResult(null);
    //}   
}