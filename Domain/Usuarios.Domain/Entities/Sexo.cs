namespace Usuarios.Domain.Entities
{
    public class Sexo : SqlEntity
    {
        public byte SexoId { get; set; }
        public string Descricao { get; set; }
    }
}