using Dados.AppContext;
using Microsoft.EntityFrameworkCore;
using Negocios.Interface.InterfacePedidoItem;
using Negocios.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dados.Repository
{
    public class PedidoItemRepository : Repository<PedidoItem>, IPedidoItemRepository
    {
        public PedidoItemRepository(MeuDbContext db) : base(db) { }
    }
}
