using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;

namespace GlobalTaxCalculation.Tests.Unit;

public class BaseFixture : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize(new AutoMoqCustomization());
        fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => fixture.Behaviors.Remove(b));
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }
}