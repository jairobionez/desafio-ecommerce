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

        public virtual DbSet<OrderItems> Items { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Product>(new ProductMapping());
            modelBuilder.ApplyConfiguration<Payment>(new PaymentMapping());
            modelBuilder.ApplyConfiguration<OrderItems>(new OrderItemsMapping());
        }
    }
}
