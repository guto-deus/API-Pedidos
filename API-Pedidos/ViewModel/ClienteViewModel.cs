using Negocios.Model;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Pedidos.ViewModel
{
    public class ClienteViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public long Telefone { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}