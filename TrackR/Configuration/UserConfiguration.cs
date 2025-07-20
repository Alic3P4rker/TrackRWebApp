using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackR.API.Entities;

namespace TrackR.Configuration;

public sealed class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    void IEntityTypeConfiguration<UserEntity>.Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .HasMany<ApplicationEntity>()
            .WithOne()
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}