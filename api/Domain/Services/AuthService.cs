using api.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly string _chaveSecreta;
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<AuthService> _logger;

        public AuthService(string chaveSecreta, IUsuarioService usuarioService, ILogger<AuthService> logger)
        {
            _chaveSecreta = chaveSecreta;
            _usuarioService = usuarioService;
            _logger = logger;
        }

        public string GerarToken(string login, string senha)
        {
            try
            {
                var usuario = _usuarioService.UsuarioPorLoginSenha(login, senha);

                if (usuario != null)
                {
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_chaveSecreta));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, login)
                    };

                    var token = new JwtSecurityToken(
                        issuer: "sua_issuer_aqui",
                        audience: "sua_audiencia_aqui",
                        claims: claims,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: credentials
                    );

                    return new JwtSecurityTokenHandler().WriteToken(token);
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao gerar token para o usuário {login}.");
                return string.Empty;
            }
        }
    }
}