using RepositoryUowPattern.API.Data.Repository;

namespace RepositoryUowPattern.API.Data
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        IDepartamentoRepository DepartamentoRepository { get; }
    }
}
