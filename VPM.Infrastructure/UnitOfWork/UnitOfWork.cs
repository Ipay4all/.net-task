using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VPM.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.Storage;
using VPM.Common;
using Microsoft.AspNetCore.Http;

namespace VPM.Infrastructure.UnitOfWork
{
    public class UnitOfWork<TContext> : IRepositoryFactory, IUnitOfWork<TContext>
        where TContext : DbContext, IDisposable
    {
        private Dictionary<(Type type, string name), object> _repositories;

        public UnitOfWork(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class
        {
            return (IRepositoryAsync<TEntity>) GetOrAddRepository(typeof(TEntity),
                new RepositoryAsync<TEntity>(Context));
        }
      
        public TContext Context { get; }
        public IDbContextTransaction dbContextTransaction { get; set; }
        public int Commit()
        {
            
            return Context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            try
            {
                return await Context.SaveChangesAsync(); 

            }
            catch (Exception ex)
            {
                throw new HttpStatusCodeException(StatusCodes.Status400BadRequest, "Error in qruery " + ex.Message);
            }
            
        }
        public async Task<int> CommitAsync(bool IsClearChangeTrack)
        {
            try
            {
                var res = await Context.SaveChangesAsync();
                if (IsClearChangeTrack)
                {
                    Context.ChangeTracker.Clear();
                }
                return res;

            }
            catch (Exception ex)
            {
                throw new HttpStatusCodeException(StatusCodes.Status400BadRequest, "Error in qruery " + ex.Message);
            }

        }


        public async Task<int> CommitAsyncWithTransaction()
        {
            try
            {
                // var transaction = Context.Database.BeginTransaction();
                //using (var transaction = Context.Database.BeginTransaction())
                // {
                try
                {

                    if (dbContextTransaction == null)
                        dbContextTransaction = Context.Database.BeginTransaction();
                    // else
                    //  transaction = dbContextTransaction;

                    int result = await Context.SaveChangesAsync();
                    //  transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    // transaction.Rollback();
                    throw new HttpStatusCodeException(StatusCodes.Status400BadRequest, "Error in qruery " + ex.Message);
                }
                //  }

            }
            catch (Exception ex)
            {
                throw new HttpStatusCodeException(StatusCodes.Status400BadRequest, "Error in qruery " + ex.Message);
            }

        }

        public async Task Refresh()
        {
            try
            {
                Context.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
            }
            catch (Exception ex)
            {
                throw new HttpStatusCodeException(StatusCodes.Status400BadRequest, "Error in qruery " + ex.Message);
            }

        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        internal object GetOrAddRepository(Type type, object repo)
        {
            _repositories ??= new Dictionary<(Type type, string Name), object>();

            if (_repositories.TryGetValue((type, repo.GetType().FullName), out var repository)) return repository;
            _repositories.Add((type, repo.GetType().FullName), repo);
            return repo;
        }

    }
}