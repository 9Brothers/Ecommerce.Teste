using System.Collections.Generic;
using System.Threading.Tasks;

namespace Usuarios.Domain.Interfaces.Repositories
{
    public interface ICQRSRepository<T>
    {
        Task<int> Add(T entity);        
    }
}