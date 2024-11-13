using projeto360.Dominio.Entidades;

namespace projeto360.Aplicacao
{
    public interface IUsuarioAplicacao
    {
        Task<int> Criar(Usuario usuarioDTO);
        Task AtualizarSenha(Usuario usuarioDTO, string novaSenha);
        Task Atualizar(Usuario usuarioDTO);
        Task Deletar(int usuarioId);
        Task Restaurar(int usuarioId);
        Task<IEnumerable<Usuario>> Listar (bool ativo);
        Task<Usuario> Obter(int usuarioId);
        Task<Usuario> ObterPorEmail(string email);
    }
}