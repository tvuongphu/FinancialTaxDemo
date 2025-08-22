namespace GlobalTaxCalculation.Domain;

public class TaxResult
{
    public decimal Limit { get; set; }
    public decimal Rate { get; set; }
    public decimal TaxedAmount { get; set; }
    public decimal TaxOwed { get; set; }
    public string Range { get; set; }
}