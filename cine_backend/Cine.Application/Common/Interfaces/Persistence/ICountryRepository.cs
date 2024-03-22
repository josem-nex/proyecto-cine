using Cine.Domain.Entities.Movies;

namespace Cine.Application.Common.Interfaces.Persistence;
public interface ICountryRepository
{
    Task<Country> Add(Country country);
    Task<Country?> GetCountryById(int Id);
    Task<Country?> GetCountryByName(string name);
    Task<List<Country>> GetAllAsync();
}