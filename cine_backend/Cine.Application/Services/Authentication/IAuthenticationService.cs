using ErrorOr;
namespace Cine.Application.Services.Authentication;
public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Register(string firstname,
                                  string lastname,
                                  string email,
                                  string password);
    ErrorOr<AuthenticationResult> Login(string email, string password);
}