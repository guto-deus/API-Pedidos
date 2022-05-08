using Negocios.Interface.InterfaceNotificador;
using Negocios.Interface.InterfacePedidoItem;
using Negocios.Model;
using Negocios.Model.Validacao;
using Negocios.Service.PedidoItemService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Service.PedidoItemService
{
    public class PedidoItemService : BaseService, IPedidoItemService
    {
        private readonly IPedidoItemRepository _pedidoItemRepository;

        public PedidoItemService(IPedidoItemRepository pedidoItemRepository,
                                 INotificador notificador) : base(notificador)
        {
            _pedidoItemRepository = pedidoItemRepository;
        }

        public async Task<bool> Adicionar(PedidoItem pedidoItem)
        {
            if (!ExecutarValidacao(new PedidoItemValidacao(), pedidoItem)) return false;

            await _pedidoItemRepository.Adicionar(pedidoItem);

            return true;
        }

        public Task<bool> Atualziar(PedidoItem pedidoitem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remover(long id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _pedidoItemRepository.Dispose();
        }
    }
}
