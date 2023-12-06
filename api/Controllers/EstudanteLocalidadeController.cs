using api.Application.Estudante.Command;
using api.Application.EstudanteLocalidade.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudanteLocalidadeController : ControllerBase
    {
        private readonly IMediatorService _mediator;
        private readonly ILogger<EstudanteLocalidadeController> _logger;

        public EstudanteLocalidadeController(IMediatorService mediator, ILogger<EstudanteLocalidadeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstudanteLocalidadeModel>>> ListarTodos()
        {
            try
            {
                _logger.LogInformation("Obtendo todos os estudantes localidades.");
                var command = new ListarEstudanteLocalidadeCommand();
                return await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todos os estudantes localidades.");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstudanteLocalidadeModel?>> EstudanteLocalidadePorId(Guid id)
        {
            try
            {
                _logger.LogInformation($"Obtendo estudante localidade por ID: {id}.");
                var command = new EstudanteLocalidadePorIdCommand { Id = id };
                var estudanteLocalidade = await _mediator.Send(command);
                if (estudanteLocalidade == null)
                {
                    _logger.LogWarning($"Nenhuma estudante localidade encontrada com ID: {id}.");
                    return NoContent();
                }
                return estudanteLocalidade;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter estudante localidade por ID: {id}.");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("por-estudante/{estudanteId}")]
        public async Task<ActionResult<EstudanteLocalidadeModel?>> EstudanteLocalidadePorEstudante(Guid estudanteId)
        {
            try
            {
                _logger.LogInformation($"Obtendo estudante localidade por estudante ID: {estudanteId}.");
                var command = new EstudanteLocalidadePorEstudanteCommand { estudanteId = estudanteId };
                var estudanteLocalidade = await _mediator.Send(command);
                if (estudanteLocalidade == null)
                {
                    _logger.LogWarning($"Nenhuma estudante localidade encontrada com estudante ID: {estudanteId}.");
                    return NoContent();
                }
                return estudanteLocalidade;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter estudante localidade por estudante ID: {estudanteId}.");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> SalvarEstudanteLocalidade(SalvarEstudanteLocalidadeCommand command)
        {
            try
            {
                _logger.LogInformation("Salvando estudante localidade.");
                var estudanteLocalidadeLocal = await _mediator.Send(new EstudanteLocalidadePorEstudanteCommand { estudanteId = command.EstudanteId });

                if (estudanteLocalidadeLocal != null)
                {
                    _logger.LogInformation($"Removendo estudante localidade existente com ID: {estudanteLocalidadeLocal.Id}.");
                    await _mediator.Send(new ExcluirEstudanteLocalidadeCommand { Id = estudanteLocalidadeLocal.Id });
                }

                var estudanteLocalidade = await _mediator.Send(command);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors.Select(error => error.ErrorMessage).ToList() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar estudante localidade.");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> AtualizarEstudanteLocalidade(AtualizarEstudanteLocalidadeCommand command)
        {
            try
            {
                _logger.LogInformation($"Atualizando estudante localidade com ID: {command.Id}.");
                var estudanteLocalidade = await _mediator.Send(command);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors.Select(error => error.ErrorMessage).ToList() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao atualizar estudante localidade com ID: {command.Id}.");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirEstudanteLocalidade(Guid id)
        {
            try
            {
                _logger.LogInformation($"Excluindo estudante localidade com ID: {id}.");
                var command = new ExcluirEstudanteLocalidadeCommand { Id = id };
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao excluir estudante localidade com ID: {id}.");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}