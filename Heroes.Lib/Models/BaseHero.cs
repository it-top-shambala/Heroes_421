using System;

namespace Heroes.Lib.Models;

public abstract class BaseHero
{
    private readonly string _name;
    public required string Name
    {
        get => _name;
        init
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Имя не может быть пустым!");
            }
            _name = value;
        }
    }

    private int _health;
    public int Health
    {
        get => _health;
        set => _health = value < 0 ? 0 : value;
    }

    private int _damage;
    public int Damage
    {
        get => _damage;
        set => _damage = value < 0 ? 0 : value;
    }

    public bool IsDead => Health == 0;

    public virtual void Attack(BaseHero enemy)
    {
        enemy.Health -= Damage;
    }
}
