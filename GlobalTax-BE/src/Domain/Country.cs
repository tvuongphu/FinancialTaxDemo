using System.ComponentModel.DataAnnotations;

namespace GlobalTax.Domain;

public class Country
{
    public int Id { get; set; }
    public string CountryCode { get; set; }
    public string CountryName { get; set; }
    public string Currency { get; set; }
}