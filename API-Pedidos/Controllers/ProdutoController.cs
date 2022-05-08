using API_Pedidos.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocios.Interface.InterfaceNotificador;
using Negocios.Interface.InterfaceProduto;
using Negocios.Interface.InterfaceRepository;
using Negocios.Model;
using Negocios.Service.ProdutoService.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Pedidos.Controllers
{
    [Authorize]
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRepository produtoRepository,
                                 INotificador notificador,
                                 IProdutoService produtoService,
                                 IMapper mapper) : base(notificador)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> BuscarTodos()
        {
            var produto = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.BuscarTodos());

            return Ok(produto);
        }

        [HttpGet("buscarporid")]
        public async Task<ActionResult<ProdutoViewModel>> BuscarPorId(long id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.BuscarPorId(id));

            if (produto == null) return BadRequest("Produto não encontrado!");

            return Ok(produto);
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            return CustomResponse(produtoViewModel);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<ProdutoViewModel>> Atualizar(long id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id)
            {
                NotificarErro("O id fornecido na query não é o mesmo do registro para ser atualizado!");
                return CustomResponse();
            }

            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoViewModel));

            return CustomResponse(produtoViewModel);
        }
        
        [HttpDelete("remover")]
        public async Task<ActionResult<ProdutoViewModel>> Remover(long id)
        {
            var produto = await _produtoRepository.BuscarPorId(id);

            await _produtoService.Remover(id);

            return CustomResponse(produto);
        }
    }
}