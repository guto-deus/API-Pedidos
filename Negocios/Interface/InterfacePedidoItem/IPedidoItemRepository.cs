using Negocios.Interface.InterfaceRepository;
using Negocios.Model;
using System;
using System.Threading.Tasks;

namespace Negocios.Interface.InterfacePedidoItem
{
    public interface IPedidoItemRepository : IDisposable, IRepository<PedidoItem>
    {

    }
}
