using DesafioEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEcommerce.Infra.Data.Mapping
{
    class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("PEDIDO");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("NROPEDIDO")
                .HasColumnType("int");

            builder.Property(p => p.User)
                .HasColumnName("USUARIO")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.OwnsOne(address => address.Address, address =>
            {
                address.Property(p => p.City)
                    .HasColumnName("CIDADE")
                    .HasColumnType("varchar(30)")
                    .HasMaxLength(30);

                address.Property(p => p.Neighborhood)
                    .HasColumnName("BAIRRO")
                    .HasColumnType("varhcar(20)")
                    .HasMaxLength(20);

                address.Property(p => p.Number)
                    .HasColumnName("NUMERO")
                    .HasColumnType("varhcar(6)")
                    .HasMaxLength(6);

                address.Property(p => p.State)
                    .HasColumnName("ESTADO")
                    .HasColumnType("varhcar(20)")
                    .HasMaxLength(20);

                address.Property(p => p.Street)
                    .HasColumnName("RUA")
                    .HasColumnType("varhcar(60)")
                    .HasMaxLength(60);

                address.Property(p => p.ZipCode)
                    .HasColumnName("CEP")
                    .HasColumnType("varhcar(8)")
                    .HasMaxLength(8);
            });

            builder.Property(p => p.PaymentDate)
                .HasColumnName("DTAPAGAMENTO")
                .HasColumnType("datetime");

            builder.Property(p => p.Total)
                .HasColumnName("TOTAL")
                .HasColumnType("decimal(15,3)");

            builder.Property(p => p.TotalPayd)
                .HasColumnName("TOTALPAGO")
                .HasColumnType("decimal(15,3)");

            builder.OwnsOne(email => email.Email, email =>
            {
                email.Property(p => p.Address)
               .HasColumnName("EMAIL")
               .HasColumnType("varchar(50)")
               .HasMaxLength(50);
            });
        }

    }
}
