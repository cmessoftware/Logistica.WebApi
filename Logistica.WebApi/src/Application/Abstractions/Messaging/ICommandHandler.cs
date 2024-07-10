using Ardalis.Result;
using MediatR;

namespace Logistica.WebApi.Application.Abstractions.Messaging;

/// <summary>
/// Command handler abstraction. This abstraction wraps the MediatR's IRequestHandler.
/// </summary>
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{
}

/// <summary>
/// Command handler abstraction. This abstraction wraps the MediatR's IRequestHandler.
/// </summary>
public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}