using MediatR;

namespace api.Domain.Services.Interfaces
{
    public interface IMediatorService
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }
}
