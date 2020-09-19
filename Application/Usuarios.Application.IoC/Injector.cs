using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Usuarios.Application.Interfaces;
using Usuarios.Domain.Interfaces.Repositories;
using Usuarios.Domain.Interfaces.Repositories.SQL.Postgres;
using Usuarios.Domain.Interfaces.Services;
using Usuarios.Domain.Services;
using Usuarios.Infrastructure.CQRS;
using Usuarios.Infrastructure.PostgresSql;
using Usuarios.Infrastructure.Redis;
using Usuarios.Infrastructure.SqlServer;

namespace Usuarios.Application.IoC
{
    public abstract class Injector
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // * Application
            services.AddTransient<IUsuarioAppService, UsuarioAppService>();

            // * Services
            services.AddTransient<IUsuarioService, UsuarioService>();

            // * Repositories
            services.AddTransient(typeof(ICQRSRepository<>), typeof(CQRSRepository<>));
            services.AddTransient(typeof(IRedisRepository<>), typeof(RedisRepository<>));
            services.AddTransient<IUsuarioSqlServerRepository, UsuarioSqlServerRepository>();
            services.AddTransient<IUsuarioCQRSRepository, UsuarioCQRSRepository>();
            services.AddTransient(typeof(IPostgresSqlRepository<>), typeof(PostgresSqlRepository<>));
            services.AddTransient<IUsuarioPostgresSqlRepository, UsuarioPostgresSqlRepository>();

            // * Redis
            services.AddDistributedRedisCache(options => {
                options.Configuration = configuration.GetConnectionString("Redis");
                options.InstanceName = "Usuarios-";                
            });            
        }
    }
}