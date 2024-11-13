namespace projeto360.Api.Models.Request
{
    public class UsuarioAtualizarSenha
    {
        public int Id { get; set; }
        public string Senha { get; set; }
        public string SenhaAntiga { get; set; }
    }
}