namespace Cine.Domain.Entities;
public class Admin
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string User { get; private set; } = null!;
    public string Password { get; private set; } = null!;
}