using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace RepositoryUowPattern.API.Data.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationContext context)
        {
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.CountAsync(expression);
        }

        public async Task<T> FirstAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression)
                ?? throw new ArgumentNullException("", "Não foi possivel retornar");
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id)
                ?? throw new ArgumentNullException("", "Não foi possivel retornar");
        }

        public async Task<List<T>> GetDataAsync(Expression<Func<T, bool>>? expression = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, int? skip = null, int? take = null)
        {
            var query = _dbSet.AsQueryable();

            if (expression is not null)
                query = query.Where(expression);

            if (include is not null)
                query = include(query);

            if (skip is not null && skip.HasValue)
                query = query.Skip(skip.Value);

            if (take is not null && take.HasValue)
                query = query.Skip(take.Value);

            return await query.ToListAsync();
        }
    }
}