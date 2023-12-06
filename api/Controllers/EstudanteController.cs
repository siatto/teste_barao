using api.Application.Estudante.Command;
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
    public class EstudanteController : ControllerBase
    {
        private readonly IMediatorService _mediator;
        private readonly ILogger<EstudanteController> _logger;

        public EstudanteController(IMediatorService mediator, ILogger<EstudanteController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstudanteModel>>> ListarTodos()
        {
            try
            {
                _logger.LogInformation("Listando todos os estudantes");
                var command = new ListarEstudantesCommand();
                return await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar todos os estudantes");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstudanteModel?>> EstudantePorId(Guid id)
        {
            try
            {
                _logger.LogInformation($"Buscando estudante por ID: {id}");
                var command = new EstudantePorIdCommand { Id = id };
                var estudante = await _mediator.Send(command);
                if (estudante == null)
                {
                    _logger.LogWarning($"Estudante com ID {id} não encontrado");
                    return NoContent();
                }
                return estudante;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao buscar estudante por ID: {id}");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("por-nome/{nome}")]
        public async Task<ActionResult<IEnumerable<EstudanteModel>>> EstudantePorNome(string nome)
        {
            try
            {
                _logger.LogInformation($"Buscando estudantes por nome: {nome}");
                var command = new EstudantePorNomeCommand { NomeCompleto = nome };
                return await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao buscar estudantes por nome: {nome}");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> SalvarEstudanteAsync(SalvarEstudanteCommand command)
        {
            try
            {
                _logger.LogInformation($"Salvando novo estudante: {command.NomeCompleto}");
                var estudante = await _mediator.Send(command);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors.Select(error => error.ErrorMessage).ToList() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao salvar novo estudante: {command.NomeCompleto}");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> AtualizarEstudante(AtualizarEstudanteCommand command)
        {
            try
            {
                _logger.LogInformation($"Atualizando estudante com ID: {command.Id}");
                var estudante = await _mediator.Send(command);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors.Select(error => error.ErrorMessage).ToList() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao atualizar estudante com ID: {command.Id}");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirEstudante(Guid id)
        {
            try
            {
                _logger.LogInformation($"Excluindo estudante com ID: {id}");
                var command = new ExcluirEstudanteCommand { Id = id };
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao excluir estudante com ID: {id}");
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}