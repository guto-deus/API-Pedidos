using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Negocios.Model;

namespace Dados.Mappings
{
    public class ProdutoMappings : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Produtos");

            builder.Property(p => p.CodigoBarras)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.TipoProduto)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(p => p.Valor)
                .IsRequired();
        }
    }
}
