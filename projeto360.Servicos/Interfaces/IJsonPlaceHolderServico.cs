using projeto360.Dominio.Entidades;

namespace projeto360.Servicos.Interfaces
{
    public interface IJsonPlaceHolderServico
    {
        Task<List<Tarefa>>ListarTarefas();
    }
}