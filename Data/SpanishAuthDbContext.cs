using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorSpanyol.Data;

public class SpanishAuthDbContext : IdentityDbContext<IdentityUser>
{
    public SpanishAuthDbContext(DbContextOptions<SpanishAuthDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //seeding roles USER ADMIN MANAGER


        var adminRoleId = "f07f938d-6ad3-4ed9-1179-08da6959dddd";
        var managerRoleId = "d4e5f678-90ab-cdef-1234-567890abcd12";
        var userRoleId = "b2c3d4e5-f678-90ab-cdef-1234567890ab";

        var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Id = adminRoleId,
                ConcurrencyStamp = adminRoleId
            },
            new IdentityRole
            {
                Name = "Manager",
                NormalizedName = "Manager",
                Id = managerRoleId,
                ConcurrencyStamp = managerRoleId
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "User",
                Id = userRoleId,
                ConcurrencyStamp = userRoleId
            }
        };

        builder.Entity<IdentityRole>().HasData(roles);
        //seeding ADMINUSER
        var adminId = "e5f67890-abcd-ef12-3456-7890abcdef12";
        var adminUser = new IdentityUser
        {
            UserName = "admin@spanyolmvc.com",
            Email = "admin@spanyolmvc.com",
            NormalizedEmail = "admin@spanyolmvc.com".ToUpper(),
            NormalizedUserName = "admin@spanyolmvc.com".ToUpper(),
            Id = adminId
        };
        adminUser.PasswordHash = new PasswordHasher<IdentityUser>()
            .HashPassword(adminUser, "12345");

        builder.Entity<IdentityUser>().HasData(adminUser);


        //add all roles to superadmin
        var superAdminRoles = new List<IdentityUserRole<string>>
        {
            new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminId
            },
            new IdentityUserRole<string>
            {
                RoleId = managerRoleId,
                UserId = adminId
            },
            new IdentityUserRole<string>
            {
                RoleId = userRoleId,
                UserId = adminId
            }
        };
        builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);

    }
}