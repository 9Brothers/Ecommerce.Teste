using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Usuarios.Domain.Interfaces.Repositories;

namespace Usuarios.Infrastructure.Redis
{
    public class RedisRepository<T> : IRedisRepository<T>
    {
        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions _cacheOptions;
        private readonly int _expirationMinutes;

        public RedisRepository(IDistributedCache cache, IConfiguration configuration)
        {
            _cache = cache;
            _expirationMinutes = configuration.GetValue<int>("Redis:ExpirationMinutes", 1);
            _cacheOptions = new DistributedCacheEntryOptions();
            _cacheOptions.SetAbsoluteExpiration(TimeSpan.FromMinutes(_expirationMinutes));
        }

        public async Task<T> Get(string key)
        {
            var json = await _cache.GetStringAsync(key);

            if (json == null) return default(T);
            
            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<IEnumerable<T>> GetAll(string key)
        {
            var json = await _cache.GetStringAsync(key);

            if (json == null) return Enumerable.Empty<T>();
                
            return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
        }

        public async Task Set(string key, T entity)
        {
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(entity), _cacheOptions);
        }

        public async Task Set(string key, IEnumerable<T> entities)
        {
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(entities), _cacheOptions);
        }
    }
}