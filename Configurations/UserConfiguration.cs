using CW9.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CW9.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        //PK
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();

        //Props
        builder.Property(u => u.Login).HasMaxLength(100).IsRequired();
        builder.Property(u => u.Password).HasMaxLength(200).IsRequired();
        builder.Property(u => u.RefreshToken).HasMaxLength(200).IsRequired(false);
        builder.Property(u => u.RefreshTokenExp).IsRequired(false);
    }
}