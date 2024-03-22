using Cine.Application.Common.Interfaces.Persistence;
using Cine.Domain.Entities;
using Cine.Domain.Entities.Movies;
using Microsoft.EntityFrameworkCore;

namespace Cine.Infrastructure.Persistence.Repositories;
public class CountryRepository : ICountryRepository
{
    private readonly CineDbContext _dbContext;

    public CountryRepository(CineDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Country> Add(Country country)
    {
        await Task.CompletedTask;
        var cy = _dbContext.Countries.AddAsync(country);
        await _dbContext.SaveChangesAsync();
        return cy.Result.Entity;
    }

    public async Task<List<Country>> GetAllAsync()
    {
        return await _dbContext.Countries.ToListAsync();
    }

    public async Task<Country?> GetCountryById(int Id)
    {
        return await _dbContext.Countries.SingleOrDefaultAsync(u => u.Id == Id);
    }
    public async Task<Country?> GetCountryByName(string name)
    {
        return await _dbContext.Countries.SingleOrDefaultAsync(u => u.Name == name);
    }

}