using Microsoft.EntityFrameworkCore;

namespace web1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet for the Product entity
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Price property to have the correct SQL column type with precision
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2); // Use precision and scale directly instead of conversion

            // Seed initial data into the Product table
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Sample Product",
                    Description = "Sample Description",
                    Price = 9.99m,
                    ImageUrl = "http://example.com/image.jpg"
                }
                // Add other products as needed
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
