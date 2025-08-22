using System;
using Microsoft.EntityFrameworkCore;
using GlobalTax.Persistence;

namespace GlobalTax.Tests.Unit;

public class GlobalTaxTestDbContext : TaxDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("GlobalTax" + Guid.NewGuid());
    }
}