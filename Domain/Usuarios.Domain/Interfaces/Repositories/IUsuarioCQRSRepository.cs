using System.Collections.Generic;
using System.Threading.Tasks;
using Usuarios.Domain.Entities;

namespace Usuarios.Domain.Interfaces.Repositories
{
    public interface IUsuarioCQRSRepository : ICQRSRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> Filter(Usuario usuario, int pagina);
        Task<IEnumerable<Usuario>> GetAll(int pagina);
    }
}