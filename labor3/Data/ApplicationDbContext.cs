﻿using labor3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace labor3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<SiteUser> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SiteUser>().HasMany(j => j.Jobs).WithMany(u => u.Users);

                base.OnModelCreating(builder);
        }

    }
}