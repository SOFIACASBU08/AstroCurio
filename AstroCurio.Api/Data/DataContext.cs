using Microsoft.EntityFrameworkCore;
using AstroCurio.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AstroCurio.Api.Data
{
    public class DataContext:IdentityDbContext<User> 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Photography> Photographies { get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<Category> Categories { get; set; }

        internal static Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        internal static void Update(Person person)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

      




        }
    }
}
