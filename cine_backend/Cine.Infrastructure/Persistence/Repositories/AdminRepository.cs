using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cine.Infrastructure.Persistence.Repositories;
public class AdminRepository : IAdminRepository
{
    private readonly CineDbContext _dbContext;

    public AdminRepository(CineDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Admin> Add(Admin Admin)
    {
        await _dbContext.Admins.AddAsync(Admin);
        await _dbContext.SaveChangesAsync();
        return Admin;
    }

    public async Task Delete(Guid Id)
    {
        var admin = await _dbContext.Admins.FindAsync(Id);
        _dbContext.Admins.Remove(admin);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Admin?> GetAdminById(Guid Id)
    {
        var admin = await _dbContext.Admins.FindAsync(Id);
        System.Console.WriteLine(admin.User);
        return admin;
    }

    public async Task<Admin?> GetAdminByUser(string user)
    {
        var admin = await _dbContext.Admins.FirstOrDefaultAsync(a => a.User == user);
        return admin;
    }

    public Task<List<Admin>> GetAdminList()
    {
        var admins = _dbContext.Admins.ToListAsync();
        return admins;
    }

    public async Task<Admin> Update(Admin Admin)
    {
        _dbContext.Admins.Update(Admin);
        await _dbContext.SaveChangesAsync();
        return Admin;
    }
}