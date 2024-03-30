using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Tlis.Cms.ProgramManagement.Domain.Entities;

namespace Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Configurations;

public class ProgramEntityConfiguration : IEntityTypeConfiguration<Program>
{
    public void Configure(EntityTypeBuilder<Program> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().HasValueGenerator((_, _) => new GuidValueGenerator());

        builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Date).IsRequired();
    }
}