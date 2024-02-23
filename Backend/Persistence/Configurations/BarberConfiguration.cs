using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class BarberConfiguration : IEntityTypeConfiguration<Barber>
{
    public void Configure(EntityTypeBuilder<Barber> builder)
    {
        builder.HasIndex(b => b.Username).IsUnique();
    }

}
