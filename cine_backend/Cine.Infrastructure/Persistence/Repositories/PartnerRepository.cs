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

    public void Add(Partner Partner)
    {
        _dbContext.Partners.Add(Partner);
        _dbContext.SaveChanges();
        // _Partners.Add(Partner);
    }


    public Partner? GetPartnerByEmail(string email)
    {
        return _dbContext.Partners.SingleOrDefault(u => u.Email == email);
        // return _Partners.SingleOrDefault(u => u.Email == email);
    }
    public void Delete(string email)
    {
        // garantizar que ese usuario ya exista, revisar eso antes
        var Partner = _dbContext.Partners.SingleOrDefault(u => u.Email == email);
        _dbContext.Partners.Remove(Partner);
        _dbContext.SaveChanges();
    }

    public List<Partner> GetPartnerList()
    {
        return _dbContext.Partners.AsNoTracking().ToList();
    }

    public void Update(Partner Partner)
    {
        _dbContext.Partners.Update(Partner);
        _dbContext.SaveChanges();
    }
}