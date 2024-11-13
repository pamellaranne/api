using projeto360.Dominio.Enumeradores;

namespace projeto360.Api.Models.Request
{
    public class UsuarioAtualizar
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public TiposUsuarioEnum TipoUsuarioId { get; set; }
    }
}
