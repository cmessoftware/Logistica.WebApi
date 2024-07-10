using Logistica.WebApi.Application.Abstractions.Clock;

namespace Logistica.WebApi.Infrastructure.Clock;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}