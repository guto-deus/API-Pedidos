using Negocios.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Service.PedidoItemService.Interface
{
    public interface IPedidoItemService : IDisposable
    {
        Task<bool> Adicionar(PedidoItem pedidoItem);
        Task<bool> Atualziar(PedidoItem pedidoitem);
        Task<bool> Remover(long id);
    }
}