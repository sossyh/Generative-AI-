using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Taskmanagement.Identity.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                UserId = 7,
                RoleId = "51aa4c19-c079-4beb-b223-f3b2b6d3d71c"
            },
            new IdentityUserRole<string>
            {
                UserId = 9,
                RoleId = "a9b1000b-3331-4e6d-8777-cc1251eb68d6"
            }

        );
    }
}