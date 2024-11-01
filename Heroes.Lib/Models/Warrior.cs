namespace Heroes.Lib.Models;

/// <summary>
/// Воин
/// </summary>
public class Warrior : BaseHero
{
    private const int HEALTH = 100;
    private const int DAMAGE = 10;

    /// <summary>
    /// Конструктор война
    /// </summary>
    public Warrior()
    {
        Health = HEALTH;
        Damage = DAMAGE;
    }
}
