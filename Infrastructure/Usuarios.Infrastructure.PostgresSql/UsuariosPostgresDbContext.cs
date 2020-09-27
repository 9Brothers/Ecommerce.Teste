using Microsoft.EntityFrameworkCore;
using Usuarios.Domain.Entities;

namespace Usuarios.Infrastructure.PostgresSql
{
    public class UsuariosPostgresDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
    }
}