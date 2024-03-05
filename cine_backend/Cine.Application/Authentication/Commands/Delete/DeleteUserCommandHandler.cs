using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using Cine.Domain.Common.Errors;
using Cine.Domain.Entities;

namespace Cine.Application.Authentication.Commands.Delete;
public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ErrorOr<Unit>>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.GetUserByEmail(request.Email) is not User user)
        {
            return Errors.User.EmailNotFound;
        }
        if (user.Password != request.Password)
        {
            return Errors.User.InvalidPassword;
        }
        _userRepository.Delete(request.Email);
        return Unit.Value;
    }
}
