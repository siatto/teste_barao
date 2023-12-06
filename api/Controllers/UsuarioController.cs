using api.Application.Estudante.Command;
using api.Application.Usuario.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediatorService _mediator;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IMediatorService mediator, ILogger<UsuarioController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> ListarTodos()
        {
            try
            {
                _logger.LogInformation("Obtendo todos os usuários.");
                var command = new ListarUsuarioCommand();
                return await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todos os usuários.");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel?>> UsuarioPorId(Guid id)
        {
            try
            {
                _logger.LogInformation($"Obtendo usuário por ID: {id}.");
                var command = new UsuarioPorIdCommand { Id = id };
                var usuario = await _mediator.Send(command);
                if (usuario == null)
                {
                    _logger.LogWarning($"Nenhum usuário encontrado com ID: {id}.");
                    return NoContent();
                }
                return usuario;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter usuário por ID: {id}.");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("por-login-senha")]
        public async Task<ActionResult<UsuarioModel>> UsuarioPorLoginSenha(string login, string senha)
        {
            try
            {
                _logger.LogInformation($"Obtendo usuário por login e senha: {login}.");
                var command = new UsuarioPorLoginSenhaCommand { Login = login, Senha = senha };
                var usuario = await _mediator.Send(command);
                if (usuario == null)
                {
                    _logger.LogWarning($"Nenhum usuário encontrado com login: {login}.");
                    return NoContent();
                }
                return usuario;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter usuário por login e senha: {login}.");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> SalvarUsuario(SalvarUsuarioCommand command)
        {
            try
            {
                _logger.LogInformation("Salvando usuário.");
                var estudante = await _mediator.Send(command);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors.Select(error => error.ErrorMessage).ToList() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar usuário.");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> AtualizarUsuario(AtualizarUsuarioCommand command)
        {
            try
            {
                _logger.LogInformation($"Atualizando usuário com ID: {command.Id}.");
                var estudante = await _mediator.Send(command);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors.Select(error => error.ErrorMessage).ToList() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao atualizar usuário com ID: {command.Id}.");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirUsuario(Guid id)
        {
            try
            {
                _logger.LogInformation($"Excluindo usuário com ID: {id}.");
                var command = new ExcluirUsuarioCommand { Id = id };
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao excluir usuário com ID: {id}.");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}