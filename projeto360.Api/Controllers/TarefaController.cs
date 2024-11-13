using Microsoft.AspNetCore.Mvc;
using projeto360.Api.Models.Response;
using projeto360.Aplicacao;

namespace projeto360.Api
{
    [ApiController]
    [Route("[controller]")]

    public class TarefaController : ControllerBase
    {
        private readonly ITarefaAplicacao _tarefaAplicacao;

        public TarefaController(ITarefaAplicacao tarefaAplicacao)
        {
            _tarefaAplicacao = tarefaAplicacao;
        }

        
        [HttpGet]
        [Route("Listar")]
        public ActionResult Get()
        {
            try
            {
                var tarefas = _tarefaAplicacao.ListarTarefas();

                var tarefasResposta = tarefas.Select(tarefa => new TarefaResponse
                {
                    Id = tarefa.Id,
                    Nome = tarefa.Nome,
                    Completa = tarefa.Completa
                    
                });

                return Ok(tarefasResposta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}