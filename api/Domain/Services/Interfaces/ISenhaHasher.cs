namespace api.Domain.Services.Interfaces
{
    public interface ISenhaHasher
    {
        string HashSenha(string senha);
        bool ValidaSenha(string senhaCriptografada, string senha);
    }
}
