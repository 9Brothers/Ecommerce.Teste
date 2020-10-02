using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Usuarios.Domain.Entities;

namespace Usuarios.Domain.Interfaces.Repositories.SQL.Postgres
{
    public interface IPostgresSqlRepository<T> : IDisposable where T : SqlEntity
    {
        void Command(T entity);
        Task<List<T>> Query(Expression<Func<T, bool>> func, int page = 0);
        void Commit();
    }
}