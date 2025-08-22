using GlobalTax.Domain;

namespace GlobalTax.Application.Models;

public class TaxDetailDto
{
    public decimal NetAmount { get; set; }
    public decimal TotalTax { get; set; }
    public List<TaxResult> TaxResult { get; set; }
}
