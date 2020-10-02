using Usuarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Usuarios.Infrastructure.EfCore.EntityTypeBuilders
{
    public class UsuariosConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios")
                .Property(u => u.CriadoEm)
                .HasDefaultValue(DateTime.Now);

            builder.Property(u => u.AtualizadoEm)
                .HasDefaultValue(DateTime.Now);
        }
    }
}