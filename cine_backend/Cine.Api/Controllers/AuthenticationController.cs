using Cine.Contracts.Authentication;
using Cine.Application.Authentication.Commands.Register;
using Cine.Application.Authentication.Common;
using Cine.Application.Authentication.Querys.Login;
using Cine.Application.Authentication.Queries.GetAll;
using Cine.Application.Authentication.Commands.Delete;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MediatR;
using MapsterMapper;
using Cine.Application.Authentication.Commands.Update;
using Cine.Application.Authentication.Queries.Get;
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
            var command = _mapper.Map<RegisterPartnerCommand>(request);
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
        [HttpPost("update")]
        public async Task<IActionResult> UpdatePartner(UpdatePartnerRequest request)
        {
            var command = _mapper.Map<UpdatePartnerCommand>(request);
            ErrorOr<AuthenticationResult> result = await _mediator.Send(command);
            return result.Match(
                result => Ok(_mapper.Map<AuthenticationResponse>(result)),
                errors => Problem(errors)
            );
        }
        [HttpGet("partners")]
        public async Task<IActionResult> GetAllPartners()
        {
            var query = new GetPartnerListQuery();
            ErrorOr<GetPartnerListResult> result = await _mediator.Send(query);
            return result.Match(
                result => Ok(_mapper.Map<GetPartnerListResult>(result)),
                errors => Problem(errors)
            );
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeletePartner(DeletePartnerRequest request)
        {
            var command = _mapper.Map<DeletePartnerCommand>(request);
            ErrorOr<Unit> result = await _mediator.Send(command);
            return result.Match(
                _ => Ok(),
                errors => Problem(errors)
            );
        }
        [HttpPost("get")]
        public async Task<IActionResult> GetPartnerById(GetPartnerByIdRequest request)
        {
            var query = _mapper.Map<GetPartnerByIdQuery>(request);
            ErrorOr<AuthenticationResult> result = await _mediator.Send(query);
            return result.Match(
                result => Ok(_mapper.Map<AuthenticationResponse>(result)),
                errors => Problem(errors)
            );
        }
    }

}