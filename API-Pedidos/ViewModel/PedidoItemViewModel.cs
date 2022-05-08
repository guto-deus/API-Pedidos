using Negocios.Model;
using System.Collections;
using System.Collections.Generic;

namespace API_Pedidos.ViewModel
{
    public class PedidoItemViewModel
    {
        public long PedidoId { get; set; }
        public long ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
    }
}