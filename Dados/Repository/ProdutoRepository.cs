using Dados.AppContext;
using Negocios.Interface.InterfaceProduto;
using Negocios.Interface.InterfaceRepository;
using Negocios.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dados.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IRepository<Produto> _produtoRepository;

        public ProdutoRepository(IRepository<Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> BuscarTodos()
        {
            return await _produtoRepository.BuscarTodos();
        }

        public async Task<Produto> BuscarPorId(long id)
        {
            return await _produtoRepository.BuscarPorId(id);
        }

        public async Task<bool> Adicionar(Produto produto)
        {
            await _produtoRepository.Adicionar(produto);
            return true;
        }

        public async Task<bool> Atualizar(Produto produto)
        {
            await _produtoRepository.Atualizar(produto);
            return true;
        }

        public async Task Remover(long id)
        {
            await _produtoRepository.Remover(id);
        }
        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}