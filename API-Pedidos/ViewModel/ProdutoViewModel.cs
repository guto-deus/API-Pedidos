namespace API_Pedidos.ViewModel
{
    public class ProdutoViewModel
    {
        public long Id { get; set; }
        public string CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int TipoProduto { get; set; }
        public bool Ativo { get; set; }
    }
}
