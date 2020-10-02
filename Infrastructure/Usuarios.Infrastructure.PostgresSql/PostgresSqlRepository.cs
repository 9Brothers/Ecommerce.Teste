using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Dapper;
using Usuarios.Domain.Entities;
using Usuarios.Domain.Interfaces.Repositories.SQL.Postgres;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Usuarios.Infrastructure.PostgresSql
{
    public class PostgresSqlRepository<T> : IPostgresSqlRepository<T> where T : SqlEntity
    {
        protected readonly UsuariosPostgresDbContext _usuariosContext;

        public PostgresSqlRepository(UsuariosPostgresDbContext context)
        {
            _usuariosContext = context;
        }

        public virtual void Command(T entity)
        {
            if (entity.CriadoEm == default(DateTime))
            {                
                entity.CriadoEm = DateTime.Now;
                entity.AtualizadoEm = entity.CriadoEm;
            }
            else
            {
                entity.AtualizadoEm = DateTime.Now;
            }

            _usuariosContext.Add<T>(entity);
        }

        public void Commit()
        {
            _usuariosContext.SaveChanges();
        }

        public void Dispose()
        {
            if (_usuariosContext != null)
            {
                _usuariosContext.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        public async Task<List<T>> Query(Expression<Func<T, bool>> func, int page = 0)
        {
            return await _usuariosContext.Set<T>()
                .Where(func)
                .Take(50)
                .Skip(page * 50)
                .ToListAsync();
        }
    }
}