using Microsoft.AspNetCore.Mvc;
using projeto360.Dominio.Entidades;
using projeto360.Api.Models.Request;
using projeto360.Api.Models.Response;
using projeto360.Aplicacao;
using projeto360.Dominio.Enumeradores;

namespace projeto360.Api
{
    [ApiController]
    [Route("[controller]")]

    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAplicacao _usuarioAplicacao;

        public UsuarioController(IUsuarioAplicacao usuarioAplicacao)
        {
            _usuarioAplicacao = usuarioAplicacao;
        }

        [HttpGet]
        [Route("Obter/{usuarioId}")]
        public async Task<ActionResult> Obter([FromRoute] int usuarioId)
        {
            try
            {
                var usuarioDominio = await _usuarioAplicacao.Obter(usuarioId);

                var usuarioResposta = new UsuarioResponse()
                {
                    Id = usuarioDominio.Id,
                    Nome = usuarioDominio.Nome,
                    Email = usuarioDominio.Email,
                    TiposUsuarioId = usuarioDominio.TiposUsuarioId
                };

                return Ok(usuarioResposta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<ActionResult> Criar([FromBody] UsuarioCriar usuarioCriar)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    Nome = usuarioCriar.Nome,
                    Email = usuarioCriar.Email,
                    Senha = usuarioCriar.Senha,
                    TiposUsuarioId = usuarioCriar.TipoUsuarioId
                };

                var usuarioId = await _usuarioAplicacao.Criar(usuarioDominio);

                return Ok(usuarioId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] UsuarioAtualizar usuario)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    TiposUsuarioId = usuario.TipoUsuarioId
                };

                await _usuarioAplicacao.Atualizar(usuarioDominio);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("AtualizarSenha")]
        public async Task<ActionResult> AtualizarSenha([FromBody] UsuarioAtualizarSenha usuario)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    Id = usuario.Id,
                    Senha = usuario.Senha
                };

                await _usuarioAplicacao.AtualizarSenha(usuarioDominio, usuario.SenhaAntiga);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Deletar/{usuarioId}")]
        public async Task<ActionResult> Deletar([FromRoute] int usuarioId)
        {
            try
            {
                await _usuarioAplicacao.Deletar(usuarioId);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Restaurar/{usuarioId}")]
        public async Task<ActionResult> Restaurar([FromRoute] int usuarioId)
        {
            try
            {
                await _usuarioAplicacao.Restaurar(usuarioId);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult> List([FromQuery] bool ativos)
        {
            try
            {
                var usuariosDominio = await _usuarioAplicacao.Listar(ativos);

                var usuarios = usuariosDominio.Select(usuario => new UsuarioResponse()
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    TiposUsuarioId = usuario.TiposUsuarioId
                }).ToList();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar: {ex.Message}");
            }
        }

        [HttpGet("ListarTiposUsuario")]
        public async Task<ActionResult> ListarTiposUsuario()
        {
            try
            {
                await Task.Delay(100);

                var valores = Enum.GetValues<TiposUsuarioEnum>().Cast<int>().ToList();
                var nomes = Enum.GetNames<TiposUsuarioEnum>().ToList();
                var listaTipos = new List<object>();

                for (int i = 0; i < valores.Count(); i++)
                {
                    listaTipos.Add(new
                    {
                        id = valores[i],
                        nome = nomes[i]
                    });
                }

                return Ok(listaTipos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao listar tipos de usuário: " + ex.Message });
            }
        }
    }
}