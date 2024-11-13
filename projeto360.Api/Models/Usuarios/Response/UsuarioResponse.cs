using projeto360.Dominio.Enumeradores;

namespace projeto360.Api.Models.Response
{
    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public TiposUsuarioEnum TiposUsuarioId { get; set; }
    }
}
