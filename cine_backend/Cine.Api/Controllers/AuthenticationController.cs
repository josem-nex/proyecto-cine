using System;
using Microsoft.AspNetCore.Mvc;
using Cine.Contracts.Authentication;
using Cine.Application.Services.Authentication;
using ErrorOr;
namespace Cine.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            var response = new AuthenticationResponse(
                                                    authResult.User.Id,
                                                    authResult.User.FirstName,
                                                    authResult.User.LastName,
                                                    authResult.User.Email,
                                                    //   authResult.Points,
                                                    authResult.Token);
            return response;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationService.Register(request.FirstName,
                                                              request.LastName,
                                                              request.Email,
                                                              request.Password);
            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
            );
        }


        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationService.Login(request.Email, request.Password);
            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
            );
        }
    }
}