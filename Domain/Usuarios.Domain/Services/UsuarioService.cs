using System.Collections.Generic;
using System.Threading.Tasks;
using Usuarios.Domain.Entities;
using Usuarios.Domain.Interfaces.Repositories;
using Usuarios.Domain.Interfaces.Services;

namespace Usuarios.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioCQRSRepository _usuarioRepository;

        public UsuarioService(IUsuarioCQRSRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> Add(Usuario usuario)
        {
            usuario.Id = await _usuarioRepository.Add(usuario);

            return usuario;
        }

        public async Task<IEnumerable<Usuario>> Filter(Usuario usuario, int pagina = 0)
        {
            return await _usuarioRepository.Filter(usuario, pagina);
        }

        public async Task<IEnumerable<Usuario>> GetAll(int pagina = 0)
        {
            return await _usuarioRepository.GetAll(pagina);
        }
    }
}