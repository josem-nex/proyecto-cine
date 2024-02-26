using Cine.Application.Common.Interfaces.Authentication;
using Cine.Application.Common.Interfaces.Persistence;
using Cine.Application.Services.Authentication;
using Cine.Domain.Common.Errors;
using Cine.Domain.Entities;
using ErrorOr;

namespace Cine.Contracts.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthenticationResult> Register(string firstname, string lastname, string email, string password)
        {
            //  Revisar que el correo no existe, o sea el usuario tiene que ser único a la hora de registrarse
            //  Generar un ID único, Crear el usuario y annadirlo a la BD
            //  Crear un JwT Token
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                return Errors.User.DuplicatedEmail;
            }
            var user = new User
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Password = password
            };

            _userRepository.Add(user);
            // Guid id = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }

        public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            // Validar que el usuario existe
            // Validar si la contrasenna es correcta
            // crear token jwt 
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                return Errors.User.EmailNotFound;
            }
            if (user.Password != password)
            {
                return Errors.User.InvalidPassword;
            }
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}