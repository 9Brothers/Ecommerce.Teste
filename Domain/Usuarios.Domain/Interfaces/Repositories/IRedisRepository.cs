using System.Collections.Generic;
using System.Threading.Tasks;

namespace Usuarios.Domain.Interfaces.Repositories
{
    public interface IRedisRepository<T>
    {
        Task Set(string key, T entity);
        Task Set(string key, IEnumerable<T> entity);
        Task<T> Get(string key);
        Task<IEnumerable<T>> GetAll(string key);
    }
}