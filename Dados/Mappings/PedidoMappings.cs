using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Negocios.Model;

namespace Dados.Mappings
{
    public class PedidoMappings : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Pedidos");

            builder.Property(p => p.TipoFrete)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(p => p.Status)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(p => p.Observacao)
                .HasColumnType("varchar(100");

            builder.HasMany(p => p.Itens)
                .WithOne(p => p.Pedido)
                .HasForeignKey(p => p.PedidoId);
        }
    }

}
