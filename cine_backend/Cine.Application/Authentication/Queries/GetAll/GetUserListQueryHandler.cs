using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace Cine.Application.Authentication.Queries.GetAll;

public class GetUserListQueryHandler :
    IRequestHandler<GetUserListQuery, ErrorOr<GetUserListResult>>
{
    private readonly IUserRepository _userRepository;
    public GetUserListQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<GetUserListResult>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var users = _userRepository.GetUserList();
        return new GetUserListResult(users);
    }
}