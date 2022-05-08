using Dados.AppContext;
using Microsoft.EntityFrameworkCore;
using Negocios.Interface.InterfaceCliente;
using Negocios.Model;
using System.Threading.Tasks;

namespace Dados.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(MeuDbContext db) : base(db) { }
    }
}