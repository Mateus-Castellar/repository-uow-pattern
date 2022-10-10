namespace RepositoryUowPattern.API.Data
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
