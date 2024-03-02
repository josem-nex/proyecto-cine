using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities;

namespace Cine.Infrastructure.Persistence.Repositories;
public class UserRepository : IUserRepository
{
    // private static readonly List<User> _users = new();
    private readonly CineDbContext _dbContext;

    public UserRepository(CineDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
        // _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _dbContext.Users.SingleOrDefault(u => u.Email == email);
        // return _users.SingleOrDefault(u => u.Email == email);
    }
}