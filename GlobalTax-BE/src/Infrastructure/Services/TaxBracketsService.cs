using GlobalTax.Application.Interfaces;
using GlobalTax.Application.Models;
using GlobalTax.Domain;
using System.Text.Json;

namespace GlobalTax.Infrastructure.Services;

public class TaxBracketsService(ITaxDbContext TaxDbContext) : ITaxBracketsService
{
    public async Task<TaxBracket> GetTaxBracketByCountryCodeFromDb(string countryCode)
    {
        return TaxDbContext.TaxBrackets.FirstOrDefault(x => x.CountryCode == countryCode);
    }

    public async Task<GetTaxBracketResponseDto> GetTaxBracketByCountryCode(string countryCode)
    {
        try
        {
            var bracketDb = await GetTaxBracketByCountryCodeFromDb(countryCode);
            if (bracketDb == null)
                return new GetTaxBracketResponseDto(false, $"Cannot find Tax Brackets for {countryCode}", null);

            var jsonBracket = bracketDb.TaxBracketJson;
            var brackets = JsonSerializer.Deserialize<List<TaxBracketDetail>>(jsonBracket);

            return new GetTaxBracketResponseDto(true, string.Empty, brackets);
        }
        catch (Exception ex)
        {
            return new GetTaxBracketResponseDto(false, ex.Message, null);
        }
    }

    public async Task<UpdateBracketResponseDto> UpdateTaxBrackets(string countryCode, List<TaxBracketDetail> taxBracketDetail)
    {
        try
        {
            var bracketDb = await GetTaxBracketByCountryCodeFromDb(countryCode);
            if (bracketDb != null)
            {
                bracketDb.TaxBracketJson = JsonSerializer.Serialize(taxBracketDetail);
                TaxDbContext.TaxBrackets.Update(bracketDb);
            }
            else
            {
                var taxBracket = new TaxBracket()
                {
                    CountryCode = countryCode,
                    TaxBracketJson = JsonSerializer.Serialize(taxBracketDetail)
                };

                TaxDbContext.TaxBrackets.Add(taxBracket);
            }

            await TaxDbContext.SaveChangesAsync(default);

            return new UpdateBracketResponseDto(true, string.Empty);
        }
        catch (Exception ex)
        {
            return new UpdateBracketResponseDto(false, ex.Message);
        }
    }
}