namespace api.Domain.Services.Interfaces
{
    public interface IAuthService
    {
        string GerarToken(string username, string password);
    }
}