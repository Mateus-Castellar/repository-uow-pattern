using Microsoft.EntityFrameworkCore;
using RepositoryUowPattern.API.Models;

namespace RepositoryUowPattern.API.Data.Repository
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly ApplicationContext _context;

        public DepartamentoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Departamento departamento)
        {
            _context.Departamentos.Add(departamento);
        }

        public async Task<Departamento> GetByIdAsync(int id)
        {
            return await _context.Departamentos
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