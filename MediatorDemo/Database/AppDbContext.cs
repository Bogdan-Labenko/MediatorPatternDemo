using MediatorDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatorDemo.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        private readonly IConfiguration _config;
        public AppDbContext(IConfiguration config)
        {
            _config = config;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "IPhone 12x", Price = 11341.26f },
                new Product() { Id = 2, Name = "Realme 41s", Price = 6945.63f },
                new Product() { Id = 3, Name = "Xiaomi mi mix 213", Price = 2123.12f },
                new Product() { Id = 4, Name = "Sasung 12", Price = 40023.89f }
                );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        }
    }
}
