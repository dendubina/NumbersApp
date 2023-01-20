using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumbersApp.WEB.EF.Entities;

namespace NumbersApp.WEB.EF.Configuration;

public class NumbersConfig : IEntityTypeConfiguration<Number>
{
    public void Configure(EntityTypeBuilder<Number> builder)
    {
        builder.HasKey(x => x.Value);
    }
}