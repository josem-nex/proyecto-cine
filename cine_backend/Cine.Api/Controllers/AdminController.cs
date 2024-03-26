using Cine.Application.Models.Admins.Commands;
using Cine.Application.Models.Admins.Queries.Get;
using Cine.Application.Models.Admins.Queries.GetAll;
using Cine.Application.Models.Admins.Queries.Login;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Api.Controllers;
[Route("admin")]
public class AdminController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public AdminController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpPost("add")]
    public async Task<IActionResult> AddAdmin(AddAdminRequest request)
    {
        var command = _mapper.Map<AddAdminCommand>(request);
        ErrorOr<AddAdminResult> adminResult = await _mediator.Send(command);
        return adminResult.Match(
            adminResult => Ok(_mapper.Map<GetAdminResponse>(adminResult)),
            errors => Problem(errors)
        );
    }
    [HttpPost("get")]
    public async Task<IActionResult> GetAdmin(GetAdminRequest request)
    {
        var query = _mapper.Map<GetAdminQuery>(request);
        ErrorOr<GetAdminResult> adminResult = await _mediator.Send(query);
        return adminResult.Match(
            adminResult => Ok(_mapper.Map<GetAdminResponse>(adminResult)),
            errors => Problem(errors)
        );
    }
    [HttpPost("delete")]
    public async Task<IActionResult> DeleteAdmin(DeleteAdminRequest request)
    {
        var command = _mapper.Map<DeleteAdminCommand>(request);
        ErrorOr<Unit> result = await _mediator.Send(command);
        return result.Match(
            _ => Ok(),
            errors => Problem(errors)
        );
    }
    [HttpPost("update")]
    public async Task<IActionResult> UpdateAdmin(UpdateAdminRequest request)
    {
        var command = _mapper.Map<UpdateAdminCommand>(request);
        ErrorOr<GetAdminResult> result = await _mediator.Send(command);
        return result.Match(
            result => Ok(_mapper.Map<GetAdminResponse>(result)),
            errors => Problem(errors)
        );
    }
    [HttpGet("all")]
    public async Task<IActionResult> GetAllAdmins()
    {
        var query = new GetAllAdminsQuery();
        ErrorOr<GetAllAdminResult> result = await _mediator.Send(query);
        return result.Match(
            result => Ok(result.Admins),
            errors => Problem(errors)
        );
    }
    [HttpPost("login")]
    public async Task<IActionResult> LoginAdmin(LoginAdminRequest request)
    {
        var query = _mapper.Map<LoginAdminQuery>(request);
        ErrorOr<GetAdminResult> adminResult = await _mediator.Send(query);
        return adminResult.Match(
            adminResult => Ok(_mapper.Map<GetAdminResponse>(adminResult)),
            errors => Problem(errors)
        );
    }
}
