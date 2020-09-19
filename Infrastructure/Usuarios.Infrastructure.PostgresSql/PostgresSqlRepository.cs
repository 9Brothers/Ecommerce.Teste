using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Dapper;
using Usuarios.Domain.Entities;
using Usuarios.Domain.Interfaces.Repositories.SQL.Postgres;
using System.Data;
using System;

namespace Usuarios.Infrastructure.PostgresSql
{
    public class PostgresSqlRepository<T> : IPostgresSqlRepository<T> where T : SqlEntity
    {
        protected readonly string _connectionString;
        protected string ProcedureName;
        protected object Params;

        public PostgresSqlRepository(IConfiguration configuration)
        {
            _connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING") ?? configuration.GetConnectionString("Postgres_UsuariosDb");
        }

        public virtual async Task<int> Add(T entity)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QuerySingleAsync<int>(ProcedureName, Params, commandType: CommandType.StoredProcedure);
            }
        }
    }
}