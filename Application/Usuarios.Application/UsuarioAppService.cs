using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Usuarios.Application.Interfaces;
using Usuarios.Domain.Entities;
using Usuarios.Domain.Interfaces.Services;

namespace Usuarios.Application
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<Usuario> Add(Usuario usuario)
        {
            if (usuario == null) throw new Exception("Informe o usuário.");
            
            else if (string.IsNullOrEmpty(usuario?.Nome.Trim())) throw new Exception("O campo \"Nome\" é obrigatório.");
            else if (usuario.Nome.Trim().Length < 3) throw new Exception("O campo \"Nome\" precisa ter no mínimo 3 caracteres.");

            else if (usuario.Nascimento.Equals(default(DateTime))) throw new Exception("O campo \"Nascimento\" é obrigatório.");

            else if (usuario.SexoId <= 0 && usuario.SexoId > 2) throw new Exception("Informe um \"Sexo\". (Feminino ou Masculino).");
            
            return await _usuarioService.Add(usuario);
        }

        public async Task<IEnumerable<Usuario>> Filter(Usuario usuario, int pagina = 0)
        {
            return await _usuarioService.Filter(usuario, pagina);
        }

        public async Task<IEnumerable<Usuario>> GetAll(int pagina = 0)
        {
            return await _usuarioService.GetAll(pagina);
        }
    }
}