namespace Heroes.Lib.Models;

public abstract class BaseHero
{
    public required string Name { get; init; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public bool IsDead { get; set; }
}
