using System.Collections.Generic;
using System.Threading.Tasks;
using Usuarios.Domain.Entities;

namespace Usuarios.Domain.Interfaces.Repositories.SQL.Postgres
{
    public interface IPostgresSqlRepository<T> where T : SqlEntity
    {
        Task<int> Command();
        Task<IEnumerable<T>> Query();
    }
}