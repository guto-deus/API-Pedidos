using Negocios.Interface.InterfaceNotificador;
using Negocios.Interface.InterfacePedido;
using Negocios.Model;
using Negocios.Model.Validacao;
using Negocios.Service.PedidoService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Service.PedidoService
{
    public class PedidoService : BaseService, IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository,
                             INotificador notificador) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<bool> Adicionar(Pedido pedido)
        {
            if (!ExecutarValidacao(new PedidoValidacao(), pedido)) return false;

            await _pedidoRepository.Adicionar(pedido);

            return true;
        }

        public async Task<bool> Atualizar(Pedido pedido)
        {
            if (!ExecutarValidacao(new PedidoValidacao(), pedido)) return false;

            await _pedidoRepository.Atualizar(pedido);

            return true;
        }

        public async Task<bool> Remover(long id)
        {
            if (_pedidoRepository.BuscarPorId(id) != null)
                await _pedidoRepository.Remover(id);

            return true;
        }

        public void Dispose()
        {
            _pedidoRepository.Dispose();
        }
    }
}
