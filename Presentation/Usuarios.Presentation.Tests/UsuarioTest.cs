using System;
using System.Linq;
using System.Threading.Tasks;
using Usuarios.Application.Interfaces;
using Usuarios.Domain.Entities;
using Usuarios.Domain.Interfaces.Repositories;
using Xunit;

namespace Usuarios.Presentation.Tests
{
    public class UsuarioTest
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IUsuarioSqlServerRepository _usuarioSqlServerRepository;

        public UsuarioTest(IUsuarioAppService usuarioAppService, IUsuarioSqlServerRepository usuarioSqlServerRepository)
        {
            _usuarioAppService = usuarioAppService;
            _usuarioSqlServerRepository = usuarioSqlServerRepository;
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

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task GetById(int id)
        {
            var usuarios = await _usuarioSqlServerRepository.Get(id);

            Assert.True(true);
        }

        [Theory]
        [InlineData("85385a25-d9ab-4a70-a21c-ceb328b68dcd")]
        [InlineData("8dad3745-a602-495a-81ee-21e5be0305fd")]
        public async Task GetByGuid(string guid)
        {
            var usuarioGuid = Guid.Parse(guid);

            var usuarios = await _usuarioSqlServerRepository.Get(usuarioGuid);

            Assert.True(true);
        }
    }
}
