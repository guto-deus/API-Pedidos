using API_Pedidos.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocios.Interface.InterfaceNotificador;
using Negocios.Interface.InterfacePedido;
using Negocios.Model;
using Negocios.Service.PedidoService.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Pedidos.Controllers
{
    [Authorize]
    [Route("api/pedidos")]
    [ApiController]
    public class PedidoController : MainController
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoService _pedidoService;
        private readonly IMapper _mapper;

        public PedidoController(IPedidoRepository pedidoRepository,
                                IPedidoService pedidoService,
                                INotificador notificador,
                                IMapper mapper) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoService = pedidoService;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoViewModel>>> BuscarTodos()
        {
            var pedido = _mapper.Map<IEnumerable<PedidoViewModel>>(await _pedidoRepository.BuscarTodos());

            return Ok(pedido);
        }

        [HttpGet("buscarporid")]
        public async Task<ActionResult<PedidoViewModel>> BuscarPorid(long id)
        {
            var pedido = _mapper.Map<PedidoViewModel>(await _pedidoRepository.BuscarPorId(id));

            if (pedido == null) return BadRequest("Pedido não encontrado!");

            return Ok(pedido);
        }

        [HttpGet("buscarclienteporpedidoid")]
        public async Task<ActionResult<PedidoViewModel>> BuscarPedidoPorClienteId(long id)
        {
            var pedidoCliente = _mapper.Map<PedidoViewModel>(await _pedidoRepository.BuscarPorId(id));

            if (pedidoCliente == null) return NotFound("Cliente não tem pedidos!");

            return Ok(pedidoCliente);
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult<PedidoViewModel>> Adicionar(PedidoViewModel pedidoViewModel)
        {
            if (!ModelState.IsValid) CustomResponse(ModelState);

            await _pedidoService.Adicionar(_mapper.Map<Pedido>(pedidoViewModel));

            return CustomResponse(pedidoViewModel);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<PedidoViewModel>> Atualizar(long id, PedidoViewModel pedidoViewModel)
        {
            if (id != pedidoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo passado na query!");
                return CustomResponse();
            }

            if (!ModelState.IsValid) CustomResponse(ModelState);

            var pedido = await _pedidoService.Atualizar(_mapper.Map<Pedido>(pedidoViewModel));

            return CustomResponse(pedido);
        }

        [HttpDelete("remover")]
        public async Task<ActionResult<PedidoViewModel>> Remover(long id)
        {
            var pedido = await _pedidoRepository.BuscarPorId(id);

            if (pedido == null) return NotFound("Pedido não encontrado!");

            await _pedidoService.Remover(id);

            return CustomResponse(pedido);
        }
    }
}