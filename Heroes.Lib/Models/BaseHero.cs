namespace Heroes.Lib.Models;

public abstract class BaseHero
{
    public required string Name { get; init; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public bool IsDead { get; set; }

    public BaseHero(string name, int health=100, int damage=10, bool isDead=false)
    {
        Name = name;
        Health = health;
        Damage = damage;
        IsDead = isDead;
    }
}
