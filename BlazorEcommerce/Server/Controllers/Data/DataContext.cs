using BlazorEcommerce.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Controllers.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Lorem title 1",
                    Description = "Description title",
                    ImageUrl = "https://placehold.co/100",
                    Price = 9.99M
                },
                new Product
                {
                    Id = 2,
                    Title = "Lorem title 2",
                    Description = "Description title",
                    ImageUrl = "https://placehold.co/100",
                    Price = 7.99M
                },
                new Product
                {
                    Id = 3,
                    Title = "Lorem title 3",
                    Description = "Description title",
                    ImageUrl = "https://placehold.co/100",
                    Price = 6.99M
                }
            );
        }

        public DbSet<Product> Products { get; set; }
    }
}
