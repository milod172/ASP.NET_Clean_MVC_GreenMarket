using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GreenMarket.Infrastructure.Persistence.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {

            builder.HasData(new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                   UserId = "4cb5df7e-135d-42cf-8723-f40f0c919e2c",
                   RoleId = "1"
                },

                new IdentityUserRole<string>
                {
                   UserId = "41d2d46d-6c0d-4fcc-86fe-ba65362fe40c",
                   RoleId = "2"
                }
             });
        }
    }
}
