using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace WorkerHub.Infrastructure.Data
{
    public class GenericUnitOfWork : IGenericUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public GenericUnitOfWork(ApplicationDbContext context)
        {
            _db = context;
        }

        public Dictionary<Type, object> Repositories = new Dictionary<Type, object>();

        public IRepository<T> Repository<T>() where T : class
        {
            if (Repositories.Keys.Contains(typeof(T)) == true)
            {
                return Repositories[typeof(T)] as IRepository<T>;
            }

            IRepository<T> repo = new EfRepository<T>(_db);
            Repositories.Add(typeof(T), repo);
            return repo;
        }

        public bool Commit()
        {
            try
            {
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                GC.SuppressFinalize(this);
            }
        }


        public async Task<bool> CommitAsync()
        {
            try
            {
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                GC.SuppressFinalize(this);

            }
        }

        public IAsyncRepository<T> AsyncRepository<T>() where T : class
        {
            try
            {
                if (Repositories.Keys.Contains(typeof(T)) == true)
                {
                    return Repositories[typeof(T)] as IAsyncRepository<T>;
                }
                IAsyncRepository<T> repo = new EfRepository<T>(_db);
                Repositories.Add(typeof(T), repo);
                return repo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
