using Microsoft.EntityFrameworkCore;
using projeto360.Dominio.Entidades;

namespace DataAccess.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
    {
        public UsuarioRepositorio(Projeto360Contexto contexto) : base(contexto)
        {

        }
        
        public async Task<int> Salvar(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            await _contexto.SaveChangesAsync();

            return usuario.Id;
        }
        public async Task Atualizar(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            await _contexto.SaveChangesAsync();
        }
        public async Task<Usuario> Obter(int usuarioId)
        {
            return await _contexto.Usuarios
                        .Where(u => u.Id == usuarioId)
                        .Where(u => u.Ativo)
                        .FirstOrDefaultAsync();
        }

        public async Task<Usuario> ObterPorEmail(string email)
        {
            return await _contexto.Usuarios
                        .Where(u => u.Email == email)
                        .Where(u => u.Ativo)
                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> Listar(bool ativo)
        {
            return await _contexto.Usuarios.Where(u => u.Ativo == ativo).ToListAsync();
        }
    }
}