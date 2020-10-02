using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Usuarios.Domain.Entities;
using Usuarios.Domain.Interfaces.Repositories;

namespace Usuarios.Infrastructure.SqlServer
{
    public class UsuarioSqlServerRepository : SqlServerRepository<Usuario>, IUsuarioSqlServerRepository
    {
        public UsuarioSqlServerRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override Task<int> Add(Usuario entity)
        {
            ProcedureName = "piUsuario";
            Params = new {
                entity.Nome,
                entity.Nascimento,
                entity.Email,
                entity.Senha,
                entity.SexoId
            };

            return base.Add(null);
        }

        public async Task<IEnumerable<Usuario>> Filter(Usuario usuario, int pagina = 1)
        {
            ProcedureName = "psUsuariosFilter";

            Params = new {
                usuario.Nome,
                usuario.Ativo,
                Pagina = pagina
            };

            return await Query();
        }

        public async Task<IEnumerable<Usuario>> GetAll(int pagina = 1)
        {
            ProcedureName = "psUsuarios";

            Params = new { Pagina = pagina };

            return await Query();
        }

        private async Task<IEnumerable<Usuario>> Query()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<Usuario, Sexo, Usuario>(ProcedureName, param: Params, commandType: CommandType.StoredProcedure, map: mapUsuario, splitOn: "Id");
            }
        }

        public async Task<Usuario> Get(int id)
        {
            ProcedureName = "psUsuario";

            Params = new {
                UsuarioId = id
            };

            var result = await Query();

            return result.FirstOrDefault();
        }

        public async Task<Usuario> Get(Guid usuarioGuid)
        {
            ProcedureName = "psUsuario";

            Params = new {
                UsuarioGuid = usuarioGuid
            };

            var result = await Query();

            return result.FirstOrDefault();
        }

        private Func<Usuario, Sexo, Usuario> mapUsuario = (Usuario usuario, Sexo sexo) =>
        {
            usuario.Sexo = sexo;
            usuario.SexoId = (byte)sexo?.SexoId;
                    
            return usuario;
        };
    }
}