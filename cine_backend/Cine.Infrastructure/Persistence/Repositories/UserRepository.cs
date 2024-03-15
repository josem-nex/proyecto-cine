using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cine.Infrastructure.Persistence.Repositories;
public class UserRepository : IUserRepository
{
    private readonly CineDbContext _dbContext;

    public UserRepository(CineDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
    }

    public async Task Delete(string email)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
    }

    public Task<List<User>> GetUserList()
    {
        return _dbContext.Users.AsNoTracking().ToListAsync();
    }

    public async Task Update(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }
}