using GlobalTax.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlobalTax.Persistence.Configurations;

public class CountryConfigurations : IEntityTypeConfiguration<Domain.Country>
{
    public void Configure(EntityTypeBuilder<Domain.Country> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.CountryCode).HasMaxLength(2);
        builder.Property(e => e.CountryName).HasMaxLength(200);

        builder.HasData(new List<Country>
        {
            new Country
            {
                Id = 1,
                CountryCode = "US",
                CountryName = "The United States of America"
            },
            new Country
            {
                Id = 2,
                CountryCode = "VN",
                CountryName = "Viet Nam"
            },
        });
    }
}