using Negocios.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Negocios.Interface.InterfaceRepository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> BuscarTodos();
        Task<TEntity> BuscarPorId(long id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task Adicionar(TEntity entity);
        Task Atualizar(TEntity entity);
        Task Remover(long id);
        Task<int> SaveChanges();
    }
}
