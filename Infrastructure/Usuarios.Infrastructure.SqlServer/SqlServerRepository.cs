using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Usuarios.Domain.Entities;
using Usuarios.Domain.Interfaces.Repositories;

namespace Usuarios.Infrastructure.SqlServer
{
    public class SqlServerRepository<T> : ISqlServerRepository<T> where T : SqlEntity
    {
        protected readonly string _connectionString;
        protected string ProcedureName;
        protected object Params;
        
        public SqlServerRepository(IConfiguration configuration)
        {
            _connectionString = Environment.GetEnvironmentVariable("SQLSERVER_CONNECTION_STRING") ?? configuration.GetConnectionString("UsuariosDb");
        }

        public virtual async Task<int> Add(T entity)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return await db.QuerySingleAsync<int>(ProcedureName, Params, commandType: CommandType.StoredProcedure);
            }
        }
    }
}