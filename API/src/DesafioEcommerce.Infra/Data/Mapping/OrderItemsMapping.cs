using DesafioEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEcommerce.Infra.Data.Mapping
{
    public class OrderItemsMapping : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {
            builder.ToTable("PEDIDOITEM");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .HasColumnType("int");

            builder.Property(p => p.PaymentNumber)
                .HasColumnName("NROPAGAMENTO")
                .HasColumnType("int");

            builder.Property(p => p.UnitPrice)
                .HasColumnName("VLRUNITARIO")
                .HasColumnType("decimal(15,3)");

            builder.Property(p => p.Amount)
                .HasColumnName("QUANTIDADE")
                .HasColumnType("int");

            builder.Property(p => p.Description)
                .HasColumnName("DESCRICAO")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.HasOne(p => p.Payment)
                .WithMany(p => p.Items)
                .HasForeignKey(p => p.PaymentNumber);
        }
    }
}
