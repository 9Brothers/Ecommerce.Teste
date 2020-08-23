using System;

namespace Usuarios.Domain.Entities
{
    public class SqlEntity
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}