using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Data;

public class AuthDbContext: IdentityDbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
        
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Seed Roles (User, Admin, SuperAdmin)

        var adminRoleId = "92eb47a6-b957-4828-b459-fb81d619fb76";
        var superAdminRoleId = "931f0fb5-ef2b-4e97-8668-d1b544f7763c";
        var userRoleId = "0812db3e-9c2f-4423-b7b1-5a2931cf8f18";

        var roles = new List<IdentityRole>
        {
            new IdentityRole()
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Id = adminRoleId,
                ConcurrencyStamp = adminRoleId
            },
            new IdentityRole()
            {
                Name = "SuperAdmin",
                NormalizedName = "SuperAdmin",
                Id = superAdminRoleId,
                ConcurrencyStamp = superAdminRoleId
            },
            new IdentityRole()
            {
                Name = "User",
                NormalizedName = "User",
                Id = userRoleId,
                ConcurrencyStamp = userRoleId
            },
        };

        builder.Entity<IdentityRole>().HasData(roles);
        // Seed SuperAdminUser
        var superAdminId = "6d103a25-64ce-4d55-bb26-af8d534e5abc";
        var superAdminUser = new IdentityUser
        {
            UserName = "superadmin@blog.com",
            Email = "superadmin@blog.com",
            NormalizedEmail = "superadmin@blog.com".ToUpper(),
            NormalizedUserName = "superadmin@blog.com".ToUpper(),
            Id = superAdminId
        };

        superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
            .HashPassword(superAdminUser, "SuperAdmin@123");

        builder.Entity<IdentityUser>().HasData(superAdminUser);

        // Add All roles to SuperAdminUser
        var superAdminRoles = new List<IdentityUserRole<string>>
        {
            new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = superAdminId
            },
            new IdentityUserRole<string>
            {
                RoleId = superAdminRoleId,
                UserId = superAdminId
            },
            new IdentityUserRole<string>
            {
                RoleId = userRoleId,
                UserId = superAdminId
            },
        };
        builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
    }
}