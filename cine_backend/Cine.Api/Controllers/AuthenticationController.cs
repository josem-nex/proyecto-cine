using System;
using Microsoft.AspNetCore.Mvc;
using Cine.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Cine.Application.Authentication.Commands.Register;
using Cine.Application.Authentication.Common;
using Cine.Application.Authentication.Querys.Login;
using MapsterMapper;
using Cine.Application.Authentication.Queries.GetAll;
namespace Cine.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);
            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
            );
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);
            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
            );
        }
        [HttpPost("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetUserListQuery();
            System.Console.WriteLine("GetAllUsers");
            ErrorOr<GetUserListResult> result = await _mediator.Send(query);
            return result.Match(
                result => Ok(_mapper.Map<GetUserListResult>(result)),
                errors => Problem(errors)
            );
        }





        // [HttpPost("delete")]
        // public async Task<IActionResult> DeleteUser(DeleteUserRequest request)
        // {
        //     var command = _mapper.Map<DeleteUserCommand>(request);
        //     ErrorOr<Unit> result = await _mediator.Send(command);
        //     return result.Match(
        //         _ => Ok(),
        //         errors => Problem(errors)
        //     );
        // }
    }
}