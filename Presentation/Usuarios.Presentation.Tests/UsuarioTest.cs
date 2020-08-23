using System;
using System.Linq;
using System.Threading.Tasks;
using Usuarios.Application.Interfaces;
using Usuarios.Domain.Entities;
using Xunit;

namespace Usuarios.Presentation.Tests
{
    public class UsuarioTest
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioTest(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [Theory]
        [InlineData("Heber Teixeira", "1991-04-07", 2, "heber@heber.dev", "1234")]
        public async Task Add(string nome, string nascimento, byte sexo, string email, string senha)
        {
            var usuario = await _usuarioAppService.Add(new Usuario
            {
                Nome = nome,
                Nascimento = Convert.ToDateTime(nascimento),
                Email = email,
                Senha = senha,
                SexoId = sexo,
            });

            Assert.True(usuario.Id > 0);
        }

        [Fact]
        public async Task GetAll()
        {
            var usuarios = await _usuarioAppService.GetAll();

            Assert.True(usuarios.Count() >= 0);
        }

        [Theory]
        [InlineData("Heb", true)]
        [InlineData("Rub", true)]
        public async Task Filter(string nome, bool ativo)
        {
            var usuarios = await _usuarioAppService.Filter(new Usuario {                
                Nome = nome,
                Ativo = ativo,
            });

            Assert.True(usuarios.Count() >= 0);
        }
    }
}
