
using API_Pedidos.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocios.Interface.InterfaceNotificador;
using Negocios.Interface.InterfacePedidoItem;
using Negocios.Model;
using Negocios.Service.PedidoItemService.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Pedidos.Controllers
{
    [Route("api/pedidoitens")]
    [ApiController]
    public class PedidoItemController : MainController
    {
        private readonly IPedidoItemRepository _pedidoItemRepository;
        private readonly IPedidoItemService _pedidoItemService;
        private readonly IMapper _mapper;

        public PedidoItemController(IPedidoItemRepository pedidoItemRepository,
                                    IPedidoItemService pedidoItemService,
                                    INotificador notificador,
                                    IMapper mapper) : base(notificador)
        {
            _pedidoItemRepository = pedidoItemRepository;
            _pedidoItemService = pedidoItemService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoItemViewModel>>> BuscarTodos()
        {
            var pedidoItem = _mapper.Map<IEnumerable<PedidoItemViewModel>>(await _pedidoItemRepository.BuscarTodos());

            return Ok(pedidoItem);
        }

        [HttpGet("buscarporid")]
        public async Task<ActionResult<PedidoItemViewModel>> BuscarPorId(long id)
        {
            var pedidoItem = _mapper.Map<PedidoItemViewModel>(await _pedidoItemRepository.BuscarPorId(id));

            if (pedidoItem == null) return BadRequest("Item do pedido não encontrado!");

            return Ok(pedidoItem);
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult<PedidoItemViewModel>> Adicionar(PedidoItemViewModel pedidoItemViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pedidoItemService.Adicionar(_mapper.Map<PedidoItem>(pedidoItemViewModel));

            return CustomResponse(pedidoItemViewModel);
        }
    }
}
