using Cine.Application.Common.Errors;
using Cine.Application.Common.Interfaces.Authentication;
using Cine.Application.Common.Interfaces.Persistence;
using Cine.Application.Services.Authentication;
using Cine.Domain.Entities;

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

        public AuthenticationResult Register(string firstname, string lastname, string email, string password)
        {
            //  Revisar que el correo no existe, o sea el usuario tiene que ser único a la hora de registrarse
            //  Generar un ID único, Crear el usuario y annadirlo a la BD
            //  Crear un JwT Token
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new DuplicateEmailException();
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

        public AuthenticationResult Login(string email, string password)
        {
            // Validar que el usuario existe
            // Validar si la contrasenna es correcta
            // crear token jwt 
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given email does not exist");
            }
            if (user.Password != password)
            {
                throw new Exception("Invalid Password");
            }
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}