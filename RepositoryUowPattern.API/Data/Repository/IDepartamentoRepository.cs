using RepositoryUowPattern.API.Data.Repository.Base;
using RepositoryUowPattern.API.Models;

namespace RepositoryUowPattern.API.Data.Repository
{
    public interface IDepartamentoRepository : IRepository<Departamento>
    {
        //Task<Departamento> GetByIdAsync(int id);
        //void Add(Departamento departamento);

        //RESPONSABILIDADE DO UNIT OF WORK
        //bool Save();
    }
}