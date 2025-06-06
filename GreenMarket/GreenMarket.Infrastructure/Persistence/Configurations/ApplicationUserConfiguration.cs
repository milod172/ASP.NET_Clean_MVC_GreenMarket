using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GreenMarket.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace GreenMarket.Infrastructure.Persistence.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.FirstName)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = "4cb5df7e-135d-42cf-8723-f40f0c919e2c",
                    FirstName = "System",
                    LastName = "Admin",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "0932100437",
                    PasswordHash = hasher.HashPassword(new(), "1"),
                    LockoutEnabled = true,
                 },
                new ApplicationUser
                {
                    Id = "41d2d46d-6c0d-4fcc-86fe-ba65362fe40c",
                    FirstName = "Nguyễn",
                    LastName = "Xuân Dũng",
                    UserName = "milod",
                    NormalizedUserName = "MILOD",
                    Email = "ngxdung172@gmail.com",
                    NormalizedEmail = "NGXDUNG172@GMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "0932100437",
                    PasswordHash = hasher.HashPassword(new(), "1"),
                    LockoutEnabled = true,
                }
             });
        }
    }
}