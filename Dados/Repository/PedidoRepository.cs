using Dados.AppContext;
using Microsoft.EntityFrameworkCore;
using Negocios.Interface.InterfacePedido;
using Negocios.Model;
using System.Threading.Tasks;

namespace Dados.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(MeuDbContext db) : base(db) { }

        public override async Task<Pedido> BuscarPorId(long id)
        {
            return await Dbset.AsNoTracking().Include(p => p.Cliente)
                              .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
