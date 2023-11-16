using dotnet_jwt_authentication.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_jwt_authentication.Data
{
    public class UserContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");

            base.OnModelCreating(modelBuilder);
        }
    }
}
