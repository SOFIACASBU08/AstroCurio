using Microsoft.EntityFrameworkCore;
using AstroCurio.Shared.Entities;

namespace AstroCurio.Api.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Photography> Photographies { get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Article>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<Link>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<Photography>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<Comment>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<User>().HasIndex(a => a.UserId).IsUnique();
            modelBuilder.Entity<Follow>().HasIndex(a => a.Id).IsUnique();




        }
    }
}
