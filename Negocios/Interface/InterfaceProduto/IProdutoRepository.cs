using Negocios.Interface.InterfaceRepository;
using Negocios.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Negocios.Interface.InterfaceProduto
{
    public interface IProdutoRepository : IDisposable
    {
        Task<IEnumerable<Produto>> BuscarTodos();
        Task<Produto> BuscarPorId(long id);
        Task<bool> Adicionar(Produto produto);
        Task<bool> Atualizar(Produto produto);
        Task Remover(long id);
    }
}