using System.Collections.Generic;

namespace Negocios.Model
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public long? Telefone { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public IEnumerable<Pedido> Pedidos { get; set; }
    }
}