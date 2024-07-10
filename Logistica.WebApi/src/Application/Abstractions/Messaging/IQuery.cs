using Ardalis.Result;
using MediatR;

namespace Logistica.WebApi.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}