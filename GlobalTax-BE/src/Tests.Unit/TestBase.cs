using GlobalTaxCalculation.Application.Interfaces;

namespace GlobalTaxCalculation.Tests.Unit;

public class TestBase
{
    protected readonly ITaxDbContext _dbContext;
    protected TestBase()
    {
        _dbContext = new GlobalTaxCalculationTestDbContext();
    }
}