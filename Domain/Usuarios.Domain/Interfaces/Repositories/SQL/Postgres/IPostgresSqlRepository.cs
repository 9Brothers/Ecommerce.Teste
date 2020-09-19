using System.Threading.Tasks;
using Usuarios.Domain.Entities;

namespace Usuarios.Domain.Interfaces.Repositories.SQL.Postgres
{
    public interface IPostgresSqlRepository<T> where T : SqlEntity
    {
        Task<int> Add(T entity);
    }
}