using Negocios.Interface.InterfaceRepository;
using Negocios.Model;
using System;
using System.Threading.Tasks;

namespace Negocios.Interface.InterfaceCliente
{
    public interface IClienteRepository : IDisposable, IRepository<Cliente>
    {
    }
}
