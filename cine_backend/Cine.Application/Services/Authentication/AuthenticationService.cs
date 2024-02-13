using Cine.Application.Common.Interfaces.Authentication;
using Cine.Application.Services.Authentication;

namespace Cine.Contracts.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthenticationResult Register(string firstname, string lastname, string email, string password)
        {
            //  Revisar que el correo no existe, o sea el usuario tiene que ser único a la hora de registrarse
            //  Generar un ID único
            //  Crear un JwT Token
            Guid id = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(id, firstname, lastname);

            return new AuthenticationResult(
                id,
                firstname,
                lastname,
                email,
                0,
                token);
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