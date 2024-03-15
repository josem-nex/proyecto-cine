using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cine.Infrastructure.Persistence.Repositories;
public class PartnerRepository : IPartnerRepository
{
    // private static readonly List<Partner> _Partners = new();
    private readonly CineDbContext _dbContext;

    public PartnerRepository(CineDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Partner Partner)
    {
        await _dbContext.Partners.AddAsync(Partner);
        await _dbContext.SaveChangesAsync();
        // _Partners.Add(Partner);
    }


    public async Task<Partner?> GetPartnerByEmail(string email)
    {
        return await _dbContext.Partners.SingleOrDefaultAsync(u => u.Email == email);
        // return _Partners.SingleOrDefault(u => u.Email == email);
    }
    public async Task Delete(string email)
    {
        // garantizar que ese usuario ya exista, revisar eso antes
        var Partner = await _dbContext.Partners.SingleOrDefaultAsync(u => u.Email == email);
        _dbContext.Partners.Remove(Partner);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Partner>> GetPartnerList()
    {
        return await _dbContext.Partners.AsNoTracking().ToListAsync();
    }

    public async Task Update(Partner Partner)
    {
        _dbContext.Partners.Update(Partner);
        await _dbContext.SaveChangesAsync();
    }
}