using Microsoft.EntityFrameworkCore;
using GlobalTaxCalculation.Application.Interfaces;

namespace GlobalTaxCalculation.Persistence;

public class TaxDbContext : DbContext, ITaxDbContext
{
    public TaxDbContext() : base(new DbContextOptions<TaxDbContext>())
    {
    }

    public TaxDbContext(DbContextOptions<TaxDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Country> Countries => Set<Domain.Country>();
    public DbSet<Domain.TaxBracket> TaxBrackets => Set<Domain.TaxBracket>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaxDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }
}