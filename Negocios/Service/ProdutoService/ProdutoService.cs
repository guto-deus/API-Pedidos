using Negocios.Interface.InterfaceNotificador;
using Negocios.Interface.InterfaceProduto;
using Negocios.Model;
using Negocios.Model.Validacao;
using Negocios.Service.ProdutoService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Service.ProdutoService
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository,
                              INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidacao(), produto)) return false;

            await _produtoRepository.Adicionar(produto);

            return true;
        }

        public async Task<bool> Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidacao(), produto)) return false;

            await _produtoRepository.Atualizar(produto);

            return true;
        }

        public Task<bool> Remover(long id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}
