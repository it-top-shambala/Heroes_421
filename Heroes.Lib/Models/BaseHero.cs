using System;

namespace Heroes.Lib.Models;

public abstract class BaseHero
{
    public required string Name { get; init; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public bool IsDead { get; set; }

    public BaseHero(string name, int health = 100, int damage = 10, bool isDead = false)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or empty.");
        }
        this.Name = name;
        this.Health = health;
        this.Damage = damage;
        this.IsDead = isDead;
    }
}

