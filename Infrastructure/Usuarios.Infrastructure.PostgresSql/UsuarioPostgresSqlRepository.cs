using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Usuarios.Domain.Entities;
using Usuarios.Domain.Interfaces.Repositories.SQL.Postgres;

namespace Usuarios.Infrastructure.PostgresSql
{
    public class UsuarioPostgresSqlRepository : PostgresSqlRepository<Usuario>, IUsuarioPostgresSqlRepository
    {
        public UsuarioPostgresSqlRepository(IConfiguration configuration) : base(configuration)
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

        public Task<IEnumerable<Usuario>> Filter(Usuario usuario, int pagina = 1)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Get(Guid usuarioGuid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetAll(int pagina = 1)
        {
            throw new NotImplementedException();
        }
    }
}