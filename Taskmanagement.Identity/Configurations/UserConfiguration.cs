using Taskmanagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Taskmanagement.Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var hasher = new PasswordHasher<User>();
        builder.HasData(
            new User
            {
                Id = 3,
                Email = "Admin@TM.com",
                NormalizedEmail = "ADMIN@TM.COM",
                UserName = "Admin@TM.com",
                NormalizedUserName = "ADMIN@TM.COM",
                PasswordHash = hasher.HashPassword(null, "P1"),
                EmailConfirmed = false
            },

            new User
            {
                Id = 4,
                Email = "User@TM.com",
                NormalizedEmail = "USER@TM.COM",
                UserName = "User@TM.com",
                NormalizedUserName = "USER@TM.COM",
                PasswordHash = hasher.HashPassword(null, "P2"),
                EmailConfirmed = false
            }
        );
    }
}