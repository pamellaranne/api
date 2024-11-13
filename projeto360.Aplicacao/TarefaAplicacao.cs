using projeto360.Dominio.Entidades;
using projeto360.Servicos.Interfaces;

namespace projeto360.Aplicacao
{
    public class TarefaAplicacao : ITarefaAplicacao
    {
        private readonly IJsonPlaceHolderServico _jsonPlaceHolderServico;

        public TarefaAplicacao(IJsonPlaceHolderServico jsonPlaceHolderServico)
        {
            _jsonPlaceHolderServico = jsonPlaceHolderServico;
        }

        public List<Tarefa> ListarTarefas()
        {
            return _jsonPlaceHolderServico.ListarTarefas().Result;
        }
    }
}