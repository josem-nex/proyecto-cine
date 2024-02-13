using Cine.Application.Common.Interfaces.Services;

namespace Cine.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}