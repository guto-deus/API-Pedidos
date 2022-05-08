using Negocios.Model;
using System;

namespace API_Pedidos.ViewModel
{
    public class PedidoViewModel
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public DateTime IniciadoEm { get; set; }
        public DateTime FinalizadoEm { get; set; }
        public int TipoFrete { get; set; }
        public string Status { get; set; }
        public string Observacao { get; set; }
    }
}
