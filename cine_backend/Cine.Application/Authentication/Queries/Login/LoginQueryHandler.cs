using Cine.Application.Authentication.Common;
using Cine.Application.Common.Interfaces.Authentication;
using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Common.Errors;
using Cine.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Cine.Application.Authentication.Querys.Login;
public class LoginQueryHandler :
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Validar que el usuario existe
        // Validar si la contrasenna es correcta
        // crear token jwt 
        if (_userRepository.GetUserByEmail(request.Email) is not User user)
        {
            return Errors.User.EmailNotFound;
        }
        if (user.Password != request.Password)
        {
            return Errors.User.InvalidPassword;
        }
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}