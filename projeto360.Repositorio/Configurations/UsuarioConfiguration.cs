using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projeto360.Dominio.Entidades;

namespace projeto360.Repositorio.Configuration;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios").HasKey(u => u.Id);

        builder.Property(nameof(Usuario.Id)).HasColumnName("UsuarioID");
        builder.Property(nameof(Usuario.Nome)).HasColumnName("Nome").IsRequired(true);
        builder.Property(nameof(Usuario.Email)).HasColumnName("Email").IsRequired(true);
        builder.Property(nameof(Usuario.Senha)).HasColumnName("Senha").IsRequired(true);
        builder.Property(nameof(Usuario.Ativo)).HasColumnName("Ativo").IsRequired(true);
        builder.Property(nameof(Usuario.TiposUsuarioId)).HasColumnName("TipoUsuario").HasConversion<string>().IsRequired(true);
    }
}
