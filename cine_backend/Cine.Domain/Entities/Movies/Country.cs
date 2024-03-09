namespace Cine.Domain.Entities.Movies;
public class Country
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public List<Movie> Movies { get; private set; } = null!;

}