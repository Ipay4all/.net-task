
namespace VPM.Infrastructure.Repository
{
    public interface IRepositoryFactory
    {
        IRepositoryAsync<T> RepositoryAsync<T>() where T : class;
    }
}