using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Usuarios.Domain.Entities;

namespace Usuarios.Domain.Interfaces.Repositories
{
    public interface IUsuarioCQRSRepository : ICQRSRepository<Usuario>
    {
        Task<int> Add(Usuario entity);
        Task<IEnumerable<Usuario>> Filter(Usuario usuario, int pagina = 1);
        Task<IEnumerable<Usuario>> GetAll(int pagina = 1);
        Task<Usuario> Get(int id);
        Task<Usuario> Get(Guid usuarioGuid);
    }
}