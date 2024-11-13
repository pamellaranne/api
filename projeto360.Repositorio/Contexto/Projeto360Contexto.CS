using Microsoft.EntityFrameworkCore;
using projeto360.Dominio.Entidades;
using projeto360.Repositorio.Configuration;

public class Projeto360Contexto : DbContext
{
    private readonly DbContextOptions _options;

    public DbSet<Usuario> Usuarios { get; set; }

    public Projeto360Contexto(){}
    public Projeto360Contexto(DbContextOptions options) : base(options)
    {
        _options = options;
    }

    /// <summary>
    /// Configura as opções de conexão com o banco de dados.
    /// </summary>

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(_options == null)
            optionsBuilder.UseSqlite(@"Filename=./projeto360.sqlite;");
    }

    /// <summary>
    /// Aplica as configurações de entidade para o modelo do banco de dados.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
    }
}