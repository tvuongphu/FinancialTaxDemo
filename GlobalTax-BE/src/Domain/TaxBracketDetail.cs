
namespace GlobalTaxCalculation.Domain;

public class TaxMaxLimit
{
    public static decimal Limit = 999999999999999.99m;
}

public class TaxBracket
{
    public int Id { get; set; }
    public string CountryCode { get; set; } = string.Empty;
    public string TaxBracketJson { get; set; } = string.Empty;
}

public class TaxBracketDetail
{
    public int Level { get; set; }  // Order of bracket
    public decimal Limit { get; set; }
    public decimal Rate { get; set; }
}