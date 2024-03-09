namespace Cine.Domain.Entities.Movies;
public class Genre
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public List<Movie> Movies { get; private set; } = null!;
}