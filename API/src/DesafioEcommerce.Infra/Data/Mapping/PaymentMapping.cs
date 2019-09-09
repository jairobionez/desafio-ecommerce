using DesafioEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioEcommerce.Infra.Data.Mapping
{
    public class PaymentMapping : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("PAGAMENTO");

            builder.Property(p => p.Id)
                .HasColumnName("NROPAGAMENTO")
                .HasColumnType("int");

            builder.HasKey(p => p.Id);

            builder.OwnsOne(name => name.Name, name =>
            {
                name.Property(p => p.FirstName)
                .HasColumnName("NOME")
                .HasColumnType("varchar(30)")
                .HasMaxLength(30);

                name.Property(p => p.LastName)
                .HasColumnName("SOBRENOME")
                .HasColumnType("varchar(70)")
                .HasMaxLength(70);
            });


            builder.OwnsOne(address => address.Address, address =>
            {
                address.Property(p => p.City)
                    .HasColumnName("CIDADE")
                    .HasColumnType("varchar(30)")
                    .HasMaxLength(30);

                address.Property(p => p.Neighborhood)
                    .HasColumnName("BAIRRO")
                    .HasColumnType("varchar(20)")
                    .HasMaxLength(20);

                address.Property(p => p.Number)
                    .HasColumnName("NUMERO")
                    .HasColumnType("varchar(6)")
                    .HasMaxLength(6);

                address.Property(p => p.State)
                    .HasColumnName("ESTADO")
                    .HasColumnType("varchar(20)")
                    .HasMaxLength(20);

                address.Property(p => p.Street)
                    .HasColumnName("RUA")
                    .HasColumnType("varchar(60)")
                    .HasMaxLength(60);

                address.Property(p => p.ZipCode)
                    .HasColumnName("CEP")
                    .HasColumnType("varchar(8)")
                    .HasMaxLength(8);
            });

            builder.Property(p => p.Total)
                .HasColumnName("TOTAL")
                .HasColumnType("decimal(15,3)");

            builder.Property(p => p.TotalPaid)
                .HasColumnName("TOTALPAGO")
                .HasColumnType("decimal(15,3)");

            builder.Property(p => p.PaidDate)
                        .HasColumnName("DTAPAGAMENTO")
                        .HasColumnType("datetime");

            builder.OwnsOne(document => document.Document, document =>
            {
                document.Property(p => p.Number)
                .HasColumnName("DOCUMENTO")
                .HasColumnType("varchar(14)")
                .HasMaxLength(14);

                document 
                    .Property(p => p.Type)
                    .HasColumnName("TIPODOCUMENTO")
                    .HasColumnType("varchar(4)")
                    .HasMaxLength(4);
            });

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
