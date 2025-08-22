using GlobalTax.Application.Interfaces;
using GlobalTax.Application.Models;
using GlobalTax.Domain;
using System.Text.Json;

namespace GlobalTax.Infrastructure.Services;

public class TaxService : ITaxService
{
    private readonly ITaxBracketsService _taxBracketsService;

    public TaxService(ITaxBracketsService taxBracketsService)
    {
        _taxBracketsService = taxBracketsService;
    }

    public async Task<GetTaxBracketResponseDto> GetTaxBracket(string countryCode)
    {
        try
        {
            var bracketDb = await _taxBracketsService.GetTaxBracketByCountryCodeFromDb(countryCode);
            if (bracketDb == null)
                return new GetTaxBracketResponseDto(false, $"Cannot find Tax Brackets for {countryCode}", null);
          
            var jsonBracket = bracketDb.TaxBracketJson;
            var brackets = JsonSerializer.Deserialize<List<TaxBracketDetail>>(jsonBracket);

            return new GetTaxBracketResponseDto(true, string.Empty, brackets);
        }
        catch(Exception ex)
        {
            return new GetTaxBracketResponseDto(false, ex.Message, null);
        }
    }

    //public async Task<TaxDetailDto> CalculateTax(string countryCode, decimal income)
    //{
    //    var taxDetail = new TaxDetailDto();
    //    var taxResults = new List<TaxResult>();

    //    var response = await GetTaxBracket(countryCode);

    //    if (response.Success == false)
    //        return new TaxDetailDto();

    //    decimal prevLimit = 0m;
    //    decimal taxAmount = 0m;
    //    decimal taxOwed = 0m;
    //    string range = string.Empty;
    //    foreach (var bracket in response.Brackets.OrderBy(s => s.Level))
    //    {
    //        range = bracket.Limit == TaxMaxLimit.Limit ? $"{(prevLimit + 1).ToString()} - ∞" :  $"{(prevLimit + 1).ToString()} - {bracket.Limit.ToString()}";

    //        if (income <= bracket.Limit)
    //        {
    //            taxAmount = income - prevLimit;
    //            taxOwed = taxAmount * bracket.Rate;
    //            taxDetail.TotalTax += taxOwed;

    //            taxResults.Add(
    //                 new TaxResult()
    //                 {
    //                     Range = range,
    //                     Rate = bracket.Rate,
    //                     TaxedAmount = taxAmount,
    //                     TaxOwed = taxOwed,
    //                 }
    //            );

    //            break;
    //        }
    //        else
    //        {
    //            taxAmount = bracket.Limit - prevLimit;
    //            taxOwed = taxAmount * bracket.Rate;
    //            taxDetail.TotalTax += taxOwed;
    //            prevLimit = bracket.Limit;

    //            taxResults.Add(
    //                 new TaxResult()
    //                 {
    //                     Range = range,
    //                     Rate = bracket.Rate,
    //                     TaxedAmount = taxAmount,
    //                     TaxOwed = taxOwed,
    //                 }
    //            );
    //        }
    //    }

    //    taxDetail.NetAmount = income - taxDetail.TotalTax;
    //    taxDetail.TaxResult = taxResults;

    //    return taxDetail;
    //}
}

