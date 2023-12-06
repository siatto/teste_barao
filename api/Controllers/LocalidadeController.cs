using api.Application.Estudante.Command;
using api.Application.Localidade.Command;
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
    public class LocalidadeController : ControllerBase
    {
        private readonly IMediatorService _mediator;
        private readonly ILogger<LocalidadeController> _logger;

        public LocalidadeController(IMediatorService mediator, ILogger<LocalidadeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocalidadeModel>>> ListarTodos()
        {
            try
            {
                _logger.LogInformation("Obtendo todas as localidades.");
                var command = new ListarLocalidadeCommand();
                return await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todas as localidades.");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocalidadeModel?> > LocalidadePorId(Guid id)
        {
            try
            {
                _logger.LogInformation($"Obtendo localidade por ID: {id}.");
                var command = new LocalidadePorIdCommand { Id = id };
                var localidade = await _mediator.Send(command);
                if (localidade == null)
                {
                    _logger.LogWarning($"Nenhuma localidade encontrada com ID: {id}.");
                    return NoContent();
                }
                return localidade;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter localidade por ID: {id}.");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("por-logradouro/{logradouro}")]
        public async Task<ActionResult<IEnumerable<LocalidadeModel>>> LocalidadePorLogradouro(string logradouro)
        {
            try
            {
                _logger.LogInformation($"Obtendo localidade por logradouro: {logradouro}.");
                var command = new LocalidadePorLogradouroCommand { logradouro = logradouro };
                return await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter localidade por logradouro: {logradouro}.");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> SalvarLocalidade(SalvarLocalidadeCommand command)
        {
            try
            {
                _logger.LogInformation("Salvando localidade.");
                var localidade = await _mediator.Send(command);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors.Select(error => error.ErrorMessage).ToList() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar localidade.");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> AtualizarLocalidade(AtualizarLocalidadeCommand command)
        {
            try
            {
                _logger.LogInformation($"Atualizando localidade com ID: {command.Id}.");
                var estudante = await _mediator.Send(command);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors.Select(error => error.ErrorMessage).ToList() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao atualizar localidade com ID: {command.Id}.");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirLocalidade(Guid id)
        {
            try
            {
                _logger.LogInformation($"Excluindo localidade com ID: {id}.");
                var command = new ExcluirLocalidadeCommand { Id = id };
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao excluir localidade com ID: {id}.");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}