using labor3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace labor3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        DbSet<SiteUser> Users;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}