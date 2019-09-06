using DesafioEcommerce.Domain.Entities;
using DesafioEcommerce.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DesafioEcommerce.Infra.Data.Context
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderItems> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Product>(new ProductMapping());
            modelBuilder.ApplyConfiguration<Order>(new OrderMapping());
            modelBuilder.ApplyConfiguration<OrderItems>(new OrderItemsMapping());
        }
    }
}
