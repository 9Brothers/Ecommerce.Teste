using System.Collections.Generic;
using System.Threading.Tasks;
using Usuarios.Domain.Entities;
using Usuarios.Domain.Interfaces.Repositories;

namespace Usuarios.Infrastructure.CQRS
{
    public class CQRSRepository<T> : ICQRSRepository<T> where T : SqlEntity
    {
        private readonly ISqlServerRepository<T> _sqlServerRepository;
        private readonly IRedisRepository<T> _redisRepository;

        public CQRSRepository(ISqlServerRepository<T> sqlServerRepository, IRedisRepository<T> redisRepository)
        {
            _sqlServerRepository = sqlServerRepository;
            _redisRepository = redisRepository;
        }

        public async Task<int> Add(T entity)
        {
            return await _sqlServerRepository.Add(entity);
        }
    }
}