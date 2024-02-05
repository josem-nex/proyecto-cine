using Microsoft.EntityFrameworkCore;

namespace cine.api.Data
{
    public class UserRepository
    {
        private readonly AppDbContext _AppDbContext;
        public UserRepository(AppDbContext appDbContext) => _AppDbContext = appDbContext;
        public async Task AddUserAsync(User user)
        {
            await _AppDbContext.Set<User>().AddAsync(user);
            await _AppDbContext.SaveChangesAsync();
        }
        public async Task<List<User>> GetAllUsersAsync() => await _AppDbContext.Users.ToListAsync();
    }
}
