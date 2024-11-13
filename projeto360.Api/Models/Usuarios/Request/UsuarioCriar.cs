using projeto360.Dominio.Enumeradores;

namespace projeto360.Api.Models.Request
{
    public class UsuarioCriar
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TiposUsuarioEnum TipoUsuarioId { get; set; }
    }
}
