using System;

namespace Usuarios.Domain.Entities
{
    public class Usuario : SqlEntity
    {
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Email { get; set; }
        // ? Se der tempo, criptografar a senha
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public byte SexoId { get; set; }
        public Sexo Sexo { get; set; }
    }
}
