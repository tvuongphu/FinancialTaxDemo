using Microsoft.EntityFrameworkCore;
namespace GlobalTaxCalculation.Application.Interfaces;

public interface ITaxDbContext
{
    DbSet<Domain.Country> Countries { get; }
    DbSet<Domain.TaxBracket> TaxBrackets { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}