using Microsoft.EntityFrameworkCore;
using RepositoryUowPattern.API.Models;

namespace RepositoryUowPattern.API.Data.Repository
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Departamento> _dbSet;

        public DepartamentoRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<Departamento>();
        }

        public void Add(Departamento departamento)
        {
            _dbSet.Add(departamento);
        }

        public async Task<Departamento> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(lbda => lbda.Colaboradores)
                .FirstOrDefaultAsync(lbda => lbda.Id == id)
                ?? throw new ArgumentNullException("", "Não foi possível obter o fornecedor");
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}