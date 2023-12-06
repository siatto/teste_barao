﻿using api.Domain.Services.Interfaces;
using MediatR;

namespace api.Domain.Services
{
    public class MediatorService : IMediatorService
    {
        private readonly IMediator _mediator;

        public MediatorService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            return _mediator.Send(request);
        }
    }
}
