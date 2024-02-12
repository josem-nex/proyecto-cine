using Cine.Application.Services.Authentication;

namespace Cine.Contracts.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationResult Register(string firstname, string lastname, string email, string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                firstname,
                lastname,
                email,
                0,
                "token");
        }

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                "firstname",
                "lastname",
                email,
                0,
                "token");
        }
    }
}