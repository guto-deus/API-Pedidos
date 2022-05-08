using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Negocios.Model;

namespace Dados.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Clientes");

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.CEP)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(p => p.Cidade)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(p => p.Estado)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(p => p.Telefone)
                .HasColumnType("varchar(20)");

            builder.HasMany(p => p.Pedidos)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => p.ClienteId);
        }
    }
}