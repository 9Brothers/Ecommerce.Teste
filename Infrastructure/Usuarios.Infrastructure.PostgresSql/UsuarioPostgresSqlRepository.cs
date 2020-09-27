using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Usuarios.Domain.Entities;
using Usuarios.Domain.Interfaces.Repositories.SQL.Postgres;

namespace Usuarios.Infrastructure.PostgresSql
{
    public class UsuarioPostgresSqlRepository : PostgresSqlRepository<Usuario>, IUsuarioPostgresSqlRepository
    {
        public UsuarioPostgresSqlRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> Add(Usuario entity)
        {
            ProcedureName = "dbo.piUsuario";

            Params = new
            {
                _nome = entity.Nome,
                _nascimento = entity.Nascimento,
                _sexoid = entity.SexoId,
                _email = entity.Email,
                _senha = entity.Senha
            };

            return await base.Command();
        }

        public async Task<IEnumerable<Usuario>> Filter(Usuario usuario, int pagina = 1)
        {
            ProcedureName = "dbo.piUsuario";
            
            Params = new
            {
                _nome = usuario.Nome,
                _nascimento = usuario.Nascimento,
                _sexoid = usuario.SexoId,
                _email = usuario.Email,
                _senha = usuario.Senha
            };

            return await base.Query();
        }

        public async Task<Usuario> Get(int id)
        {
            ProcedureName = "dbo.psUsuario";
            
            Params = new
            {
                _usuarioid = id,
                _usuarioguid = default(Guid)                
            };

            var results = await base.Query();

            return results.FirstOrDefault();
        }

        public async Task<Usuario> Get(Guid usuarioGuid)
        {
            ProcedureName = "dbo.psUsuario";
            
            Params = new
            {
                _usuarioid = 0,
                _usuarioguid = usuarioGuid
            };

            var results = await base.Query();

            return results.FirstOrDefault();
        }

        public async Task<IEnumerable<Usuario>> GetAll(int pagina = 1)
        {
            ProcedureName = "dbo.usuarios";
            
            Params = new
            {
                pagina
            };

            return await base.Query();
        }
    }
}