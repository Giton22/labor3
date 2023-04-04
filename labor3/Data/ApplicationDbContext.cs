using labor3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace labor3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
       public DbSet<SiteUser> Users;
       public DbSet<Job> Jobs;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SiteUser>()
                .HasMany(j => j.Jobs).WithMany(u => u.Users);
            base.OnModelCreating(modelBuilder);

        }
    }
}