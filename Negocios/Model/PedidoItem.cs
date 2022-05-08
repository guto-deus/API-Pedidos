namespace Negocios.Model
{
    public class PedidoItem : Entity
    {
        public long PedidoId { get; set; }
        public long ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public decimal Total { get; set; }
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }
    }
}
