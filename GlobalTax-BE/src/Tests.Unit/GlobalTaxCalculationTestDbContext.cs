using System;
using Microsoft.EntityFrameworkCore;
using GlobalTaxCalculation.Persistence;

namespace GlobalTaxCalculation.Tests.Unit;

public class GlobalTaxCalculationTestDbContext : TaxDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("globaltaxcalculation" + Guid.NewGuid());
    }
}