using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using WorkerHub.Infrastructure;

namespace Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T>, IAsyncRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;

        public EfRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public T GetSingleBySpec(Expression<Func<T, bool>> spec)
        {
            return ListBySpec(spec).SingleOrDefault();
        }


        public IEnumerable<T> ListAll()
        {
            return _db.Set<T>().AsEnumerable();
        }

        public async Task<T> GetSingleBySpecAsync(Expression<Func<T, bool>> spec)
        {
            return await _db.Set<T>().SingleOrDefaultAsync(spec);
        }
        public async Task<List<T>> ListAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public IEnumerable<T> ListBySpec(Expression<Func<T, bool>> spec)
        {
            IEnumerable<T> query = _db.Set<T>().Where(spec).AsEnumerable();
            return query;
        }
        public async Task<List<T>> ListBySpecAsync(Expression<Func<T, bool>> spec)
        {
            var query = await _db.Set<T>().Where(spec).ToListAsync();
            return query;
        }

        public T Add(T entity)
        {
            _db.Set<T>().Add(entity);

            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);

            return entity;
        }
        public async Task<List<T>> AddListAsync(List<T> entity)
        {
            await _db.Set<T>().AddRangeAsync(entity);

            return entity;
        }

        public void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }
        public async Task UpdateRangeAsync(List<T> entities)
        {
            try
            {
                entities.ToList().ForEach(e =>
                {
                    _db.Entry(e).State = EntityState.Modified;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public void DeleteList(List<T> entity)
        {
            _db.Set<T>().RemoveRange(entity);
        }

        public IEnumerable<T> ExecQuery(string query, params object[] parameters)
        {
            return _db.Set<T>().FromSqlRaw(query, parameters);
        }
        public async Task<List<T>> ExecQueryAsync(string query, params object[] parameters)
        {
            return await _db.Set<T>().FromSqlRaw(query, parameters).ToListAsync();
        }

        public int ExecuteProcedureWithoutResult(string procedureName, params object[] parameters)
        {
            try
            {
                int number = 0;
                number = _db.Database.ExecuteSqlRaw(procedureName, parameters);
                return number;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                GC.SuppressFinalize(this);

            }
        }

        public async Task<int> ExecuteProcedureWithoutResultAsync(string procedureName, params object[] parameters)
        {
            try
            {
                int number = 0;
                number = await _db.Database.ExecuteSqlRawAsync(procedureName, parameters);
                return number;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                GC.SuppressFinalize(this);

            }
        }

        public async Task DeleteAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
        }
        public async Task DeleteListAsync(List<T> entity)
        {
            _db.Set<T>().RemoveRange(entity);
        }
        public IEnumerable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            DbSet<T> dbSet = _db.Set<T>();

            IQueryable<T> query = dbSet;
            //foreach (var include in includes)
            //{
            //    query = dbSet.Include(include);
            //}

            //return query ?? dbSet;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }

    }
}
