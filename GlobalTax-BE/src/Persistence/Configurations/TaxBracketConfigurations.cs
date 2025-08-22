using GlobalTax.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlobalTax.Persistence.Configurations;

public class TaxBracketConfigurations : IEntityTypeConfiguration<TaxBracket>
{
    public void Configure(EntityTypeBuilder<TaxBracket> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.CountryCode)
            .HasMaxLength(2)
            .IsRequired();

        builder.HasData(new List<TaxBracket>
        {
            new TaxBracket {
                Id = 1,
                CountryCode = "US",
                TaxBracketJson = "[{\"Level\":1,\"Limit\":11000,\"Rate\":0.10},{\"Level\":2,\"Limit\":44725,\"Rate\":0.12},{\"Level\":3,\"Limit\":95375,\"Rate\":0.22},{\"Level\":4,\"Limit\":182100,\"Rate\":0.24},{\"Level\":5,\"Limit\":231250,\"Rate\":0.32},{\"Level\":6,\"Limit\":578125,\"Rate\":0.35},{\"Level\":7,\"Limit\":999999999999999.99,\"Rate\":0.37}]"
            }
        });
    }
}
