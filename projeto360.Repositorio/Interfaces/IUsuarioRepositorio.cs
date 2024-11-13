using projeto360.Dominio.Entidades;

public interface IUsuarioRepositorio
{
    Task<int> Salvar(Usuario usuario);
    Task Atualizar(Usuario usuario);
    Task<Usuario> Obter(int usuarioID);
    Task<Usuario> ObterPorEmail(string email);
    Task<IEnumerable<Usuario>> Listar(bool ativo);
}