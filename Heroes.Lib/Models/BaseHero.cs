using System;

namespace Heroes.Lib.Models;

/// <summary>
/// Базовый класс героя
/// </summary>
public abstract class BaseHero
{
    private readonly string _name;
    /// <summary>
    /// Имя героя
    /// </summary>
    /// <exception cref="ArgumentException">Имя не может быть пустым</exception>
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
    /// <summary>
    /// Здоровье героя
    /// </summary>
    public int Health
    {
        get => _health;
        set => _health = value < 0 ? 0 : value;
    }

    private int _damage;
    /// <summary>
    /// Урон героя
    /// </summary>
    public int Damage
    {
        get => _damage;
        set => _damage = value < 0 ? 0 : value;
    }

    /// <summary>
    /// Герой умер?
    /// </summary>
    public bool IsDead => Health == 0;

    /// <summary>
    /// Атака героя на противника
    /// </summary>
    /// <param name="enemy">Противник</param>
    public virtual void Attack(BaseHero enemy)
    {
        enemy.Health -= Damage;
    }
}
