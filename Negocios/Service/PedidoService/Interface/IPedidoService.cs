using Negocios.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Service.PedidoService.Interface
{
    public interface IPedidoService : IDisposable
    {
        Task<bool> Adicionar(Pedido pedido);
        Task<bool> Atualizar(Pedido pedido);
        Task<bool> Remover(long id);
    }
}
