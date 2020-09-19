using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Usuarios.Application;
using Usuarios.Application.Interfaces;
using Usuarios.Application.IoC;
using Usuarios.Domain.Interfaces.Repositories;
using Usuarios.Domain.Interfaces.Services;
using Usuarios.Domain.Services;
using Usuarios.Infrastructure.SqlServer;

namespace Usuarios.Presentation.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            services.AddSingleton<IConfiguration>(s => configuration);
            
            // Configuration = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            //     .AddJsonFile("appsettings.json", false)
            //     .Build();
            
            Injector.ConfigureServices(services, configuration);
        }
    }
}