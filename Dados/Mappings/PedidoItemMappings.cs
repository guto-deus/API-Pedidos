using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Negocios.Model;

namespace Dados.Mappings
{
    public class PedidoItemMappings : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("PedidoItens");

            builder.Property(p => p.Quantidade)
                .HasDefaultValue(1)
                .IsRequired();

            builder.Property(p => p.Valor)
                .IsRequired();

            builder.Property(p => p.Desconto)
                .IsRequired();

            builder.Property(p => p.Total)
                .IsRequired()
                .HasColumnName("Total");
        }
    }
}
