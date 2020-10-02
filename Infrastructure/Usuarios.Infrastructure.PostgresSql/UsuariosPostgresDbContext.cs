using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Usuarios.Domain.Entities;
using Usuarios.Infrastructure.EfCore;

namespace Usuarios.Infrastructure.PostgresSql
{
    public class UsuariosPostgresDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sexo> Sexos { get; set; }

        public UsuariosPostgresDbContext(DbContextOptions<UsuariosPostgresDbContext> options)
        {
            
        }

        public UsuariosPostgresDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Server=192.168.99.101;Database=usuariosdb;Port=30432;User Id=postgres;Password=mysecretpassword;
            // optionsBuilder.UseNpgsql(
            //     Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING") ?? 
            //     _configuration.GetConnectionString("Postgres_UsuariosDb"));

            optionsBuilder.UseNpgsql("Server=192.168.99.100;Database=usuariosdb;Port=30432;User Id=postgres;Password=mysecretpassword;");
        }
    }
}