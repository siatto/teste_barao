using api.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;

namespace api.Domain.Services
{
    internal class SenhaHasher : ISenhaHasher
    {
        private readonly ILogger<SenhaHasher> _logger;

        public SenhaHasher(ILogger<SenhaHasher> logger)
        {
            _logger = logger;
        }

        public string HashSenha(string senha)
        {
            try
            {
                if (string.IsNullOrEmpty(senha))
                {
                    throw new ArgumentException("A senha não pode ser nula ou vazia.", nameof(senha));
                }

                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }

                    return builder.ToString();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao gerar hash da senha");
                throw;
            }
        }

        public bool ValidaSenha(string senhaCriptografada, string senha)
        {
            try
            {
                if (string.IsNullOrEmpty(senhaCriptografada) || string.IsNullOrEmpty(senha))
                {
                    return false;
                }

                string senhaConvertidaCriptografada = HashSenha(senha);
                return string.Compare(senhaCriptografada, senhaConvertidaCriptografada, StringComparison.OrdinalIgnoreCase) == 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao validar senha");
                throw;
            }
        }
    }
}