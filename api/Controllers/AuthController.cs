using api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("login")]
        public ActionResult<string> Login(string login, string senha)
        {
            try
            {
                _logger.LogInformation("Gerando token por login e senha");

                var token = _authService.GerarToken(login, senha);

                if (!string.IsNullOrEmpty(token))
                {
                    return Ok(new { Token = token });
                }

                return Unauthorized();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter token de acesso");

                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
