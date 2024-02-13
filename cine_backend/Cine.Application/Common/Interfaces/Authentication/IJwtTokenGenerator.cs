namespace Cine.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid ID, string firstname, string lastname);
}