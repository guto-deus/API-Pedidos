using Negocios.Enums;
using System;
using System.Collections.Generic;

namespace Negocios.Model
{
    public class Pedido : Entity
    {
        public long ClienteId { get; set; }
        public DateTime IniciadoEm { get; set; }
        public DateTime FinalizadoEm { get; set; }
        public ETipoFrete TipoFrete { get; set; }
        public EStatusPedido Status { get; set; }
        public string Observacao { get; set; }
        public Cliente Cliente { get; set; }
        public IEnumerable<PedidoItem> Itens { get; set; }

        public Pedido()
        {
            IniciadoEm = DateTime.Now;
        }
    }
}