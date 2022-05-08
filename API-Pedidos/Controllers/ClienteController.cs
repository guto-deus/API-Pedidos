using API_Pedidos.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocios.Interface.InterfaceCliente;
using Negocios.Interface.InterfaceNotificador;
using Negocios.Model;
using Negocios.Service.ClienteService.Interface;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Pedidos.Controllers
{

    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository,
                                 IClienteService clienteService,
                                 INotificador notificador,
                                 IMapper mapper) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
            _mapper = mapper;
        }
      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteViewModel>>> BuscarTodos()
        {
            var cliente = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.BuscarTodos());

            return Ok(cliente);
        }

        [HttpGet("buscarporid")]
        public async Task<ActionResult<ClienteViewModel>> BuscarPorId(long id)
        {
            var cliente = _mapper.Map<ClienteViewModel>(await _clienteRepository.BuscarPorId(id));

            if (cliente == null) return NotFound();

            return Ok(cliente);
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult<ClienteViewModel>> Adicionar(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _clienteService.Adicionar(_mapper.Map<Cliente>(clienteViewModel));

            return CustomResponse(clienteViewModel);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<ClienteViewModel>> Atualizar(long id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id)
            {
                NotificarErro("O id fornecido na query não é o mesmo do registro para ser atualizado!");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _clienteService.Atualizar(_mapper.Map<Cliente>(clienteViewModel));

            return CustomResponse(clienteViewModel);
        }

        [HttpDelete("remover")]
        public async Task<ActionResult<ClienteViewModel>> Remover(long id)
        {
            var cliente = await _clienteRepository.BuscarPorId(id);

            if (cliente == null) return NotFound("Cliente não encontrado!");

            await _clienteService.Remover(id);

            return CustomResponse(cliente);
        }
    }
}