using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities;

namespace Cine.Infrastructure.Persistence;
public class UserRepository : IUserRepository
{
    // la lista static hace que no cree una nueva lista por cada requests
    private static readonly List<User> _users = new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}