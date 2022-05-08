using Negocios.Enums;

namespace Negocios.Model
{
    public class Produto : Entity
    {
        public string CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public ETipoProduto TipoProduto { get; set; }
        public bool Ativo { get; set; }
        public PedidoItem PedidoItem { get; set; }
    }
}