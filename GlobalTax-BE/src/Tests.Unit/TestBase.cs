using GlobalTax.Application.Interfaces;

namespace GlobalTax.Tests.Unit;

public class TestBase
{
    protected readonly ITaxDbContext _dbContext;
    protected TestBase()
    {
        _dbContext = new GlobalTaxTestDbContext();
    }
}