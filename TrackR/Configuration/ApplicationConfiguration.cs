using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackR.API.Entities;

namespace TrackR.Configuration;

public sealed class ApplicationConfiguration : IEntityTypeConfiguration<ApplicationEntity>
{
    void IEntityTypeConfiguration<ApplicationEntity>.Configure(EntityTypeBuilder<ApplicationEntity> builder)
    {
        builder.Property(a => a.Status)
            .HasConversion<string>();
    }
}