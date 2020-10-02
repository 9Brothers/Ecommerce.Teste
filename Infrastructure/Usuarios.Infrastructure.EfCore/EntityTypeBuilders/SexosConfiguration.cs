using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuarios.Domain.Entities;

namespace Usuarios.Infrastructure.EfCore.EntityTypeBuilders
{
    public class SexosConfiguration : IEntityTypeConfiguration<Sexo>
    {
        public void Configure(EntityTypeBuilder<Sexo> builder)
        {
            builder.ToTable("Sexos")
                .Property(u => u.CriadoEm)
                .HasDefaultValue(DateTime.Now);

            builder.Property(u => u.AtualizadoEm)
                .HasDefaultValue(DateTime.Now);
        }
    }
}