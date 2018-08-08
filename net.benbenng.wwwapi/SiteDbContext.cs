using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using net.benbenng.wwwapi.Models;

namespace net.benbenng.wwwapi
{
    public class SiteDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Tagging> Taggings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=siteDb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>().HasData(
                new Content { ContentId = 1, Title = "First Content", Text = "Hello World!", ShownInBlogs = true, CreatedTime = DateTime.Now, LastEditedTime = DateTime.Now },
                new Content { ContentId = 2, Title = "First Content", Text = "Hello World!", ShownInBlogs = true, CreatedTime = DateTime.Now, LastEditedTime = DateTime.Now },
                new Content { ContentId = 3, Title = "First Content", Text = "Hello World!", ShownInBlogs = true, CreatedTime = DateTime.Now, LastEditedTime = DateTime.Now }
                );
        }
    }

    public class AccountDbContext : IdentityDbContext<User> {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=identityDb.db");
        }
    }
}
