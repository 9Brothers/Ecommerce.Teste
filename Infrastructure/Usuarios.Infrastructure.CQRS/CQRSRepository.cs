using System.Collections.Generic;
using System.Threading.Tasks;
using Usuarios.Domain.Entities;
using Usuarios.Domain.Interfaces.Repositories;
using Usuarios.Domain.Interfaces.Repositories.SQL.Postgres;

namespace Usuarios.Infrastructure.CQRS
{
    public class CQRSRepository<T> : ICQRSRepository<T> where T : SqlEntity
    {
        private readonly ISqlServerRepository<T> _sqlServerRepository;
        private readonly IPostgresSqlRepository<T> _postgresSqlRepository;
        private readonly IRedisRepository<T> _redisRepository;

        public CQRSRepository(ISqlServerRepository<T> sqlServerRepository, IRedisRepository<T> redisRepository, IPostgresSqlRepository<T> postgresSqlRepository)
        {
            _sqlServerRepository = sqlServerRepository;
            _redisRepository = redisRepository;
            _postgresSqlRepository = postgresSqlRepository;
        }

        public async Task<int> Add(T entity)
        {
            return await _postgresSqlRepository.Add(entity);
        }
    }
}