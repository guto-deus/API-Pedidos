using Dados.AppContext;
using Microsoft.EntityFrameworkCore;
using Negocios.Interface.InterfaceRepository;
using Negocios.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dados.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MeuDbContext Db;
        protected readonly DbSet<TEntity> Dbset;

        public Repository(MeuDbContext db)
        {
            Db = db;
            Dbset = db.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> BuscarTodos()
        {
            return await Dbset.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> BuscarPorId(long id)
        {
            return await Dbset.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await Dbset.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            Dbset.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            Dbset.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(long id)
        {
            Dbset.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}