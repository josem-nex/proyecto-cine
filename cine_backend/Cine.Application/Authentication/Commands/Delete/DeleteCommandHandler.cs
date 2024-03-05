using Cine.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace Cine.Application.Authentication.Commands.Delete;
public class DeleteCommandHandler : IRequestHandler<DeleteCommand, ErrorOr<Unit>>
{
    private readonly IUserRepository _userRepository;

    public DeleteCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        // check if user exists
        // aun no terminado
        await Task.CompletedTask;
        _userRepository.Delete(request.Email);
        return Unit.Value;
    }
}
