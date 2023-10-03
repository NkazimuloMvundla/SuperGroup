using Microsoft.EntityFrameworkCore;
using SuperGroup.Data.Models;

namespace SuperGroup.Data
{
    public class SuperGroupDBContext : DbContext
    {
        public SuperGroupDBContext(DbContextOptions<SuperGroupDBContext> opts)
        : base(opts) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<CartLine>  CartLines { get; set; }
    }
}