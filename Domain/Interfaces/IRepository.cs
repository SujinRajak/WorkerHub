using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepository<T>
    {
        T GetSingleBySpec(Expression<Func<T, bool>> spec);
        IEnumerable<T> ListAll();
        IEnumerable<T> ListBySpec(Expression<Func<T, bool>> spec);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteList(List<T> entity);

        IEnumerable<T> ExecQuery(string query, params object[] parameters);
        //void ExecNonQuery(string query, params object[] parameters);
        //bool Commit();
        IEnumerable<T> Include(params Expression<Func<T, object>>[] includes);
        int ExecuteProcedureWithoutResult(string procedureName, params object[] parameters);

    }
}
