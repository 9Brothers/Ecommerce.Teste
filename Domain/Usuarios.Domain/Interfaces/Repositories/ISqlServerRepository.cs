using System.Collections.Generic;
using System.Threading.Tasks;
using Usuarios.Domain.Entities;

namespace Usuarios.Domain.Interfaces.Repositories
{
    public interface ISqlServerRepository<T> where T : SqlEntity
    {
        Task<int> Add(T entity);
    }
}