using Microsoft.EntityFrameworkCore;
using Practice4.Entity;

namespace Practice4.Repository
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<Purchase> Purchase { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=USQROJREYESGUE1;" +
                "Database=Practice4;" +
                "Trusted_Connection=True;" +
                "TrustServerCertificate=True;");
        }
    }
}
