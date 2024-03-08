using Cine.Domain.Entities;

namespace Cine.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Partner partner);
}
