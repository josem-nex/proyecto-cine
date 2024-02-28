using System;
using Microsoft.AspNetCore.Mvc;
using Cine.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Cine.Application.Authentication.Commands.Register;
using Cine.Application.Authentication.Common;
using Cine.Application.Authentication.Querys.Login;
namespace Cine.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
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
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);
            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
            );
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);
            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
            );
        }
    }
}