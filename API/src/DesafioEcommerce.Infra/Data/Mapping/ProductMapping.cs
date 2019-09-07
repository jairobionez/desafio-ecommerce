using DesafioEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioEcommerce.Infra.Data.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("PRODUTO");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("SKU")
                .HasColumnType("int");

            builder.Property(p => p.Description)
                .HasColumnName("DESCRICAO")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(p => p.Amount)
                .HasColumnName("QUANTIDADE")
                .HasColumnType("int");

            builder.Property(p => p.Value)
                .HasColumnName("VALOR")
                .HasColumnType("decimal(15,3)");

            builder.Property(p => p.Weight)
                .HasColumnName("PESO")
                .HasColumnType("decimal(15,3)");

            builder.Property(p => p.EanCode)
                .HasColumnName("CODEAN")
                .HasColumnType("varchar(13)");

            builder.Property(p => p.Image)
                .HasColumnName("IMAGEM")
                .HasColumnType("image");
        }
        
    }
}
