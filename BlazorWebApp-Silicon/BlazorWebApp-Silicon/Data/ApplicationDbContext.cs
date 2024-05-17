using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebApp_Silicon.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<ApplicationUserProfile> AspNetUserProfiles { get; set; }
        public DbSet<ApplicationUserAddress> AspNetUserAddresses { get; set; }
    }
}
