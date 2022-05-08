using Negocios.Interface.InterfaceCliente;
using Negocios.Interface.InterfaceNotificador;
using Negocios.Model;
using Negocios.Model.Validacao;
using Negocios.Service.ClienteService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Service.ClienteService
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository,
                              INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Adicionar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidacao(), cliente)) return false;

            await _clienteRepository.Adicionar(cliente);

            return true;
        }

        public async Task<bool> Atualizar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidacao(), cliente)) return false;

            await _clienteRepository.Atualizar(cliente);

            return true;
        }

        public async Task<bool> Remover(long id)
        {
            if (_clienteRepository.BuscarPorId(id).Result.Pedidos.Any())
            {
                Notificar("Não é possível remover clientes com pedidos cadastrados!");
                return false;
            }

            await _clienteRepository.Remover(id);

            return true;
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}