using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VPM.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace VPM.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class;
        int Commit();
        Task<int> CommitAsync();
        Task<int> CommitAsync(bool IsClearChangeTrack);
        Task<int> CommitAsyncWithTransaction();
        Task Refresh();
        IDbContextTransaction dbContextTransaction { get; set; }
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}