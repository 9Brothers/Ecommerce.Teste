using System.Collections.Generic;
using System.Threading.Tasks;
using Usuarios.Domain.Entities;

namespace Usuarios.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> Add(Usuario usuario);
        Task<IEnumerable<Usuario>> GetAll(int pagina = 0);
        Task<IEnumerable<Usuario>> Filter(Usuario usuario, int pagina = 0);
    }
}