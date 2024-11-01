namespace Heroes.Lib.Models;

public class Warrior : BaseHero
{
    private const int HEALTH = 100;
    private const int DAMAGE = 10;

    public Warrior()
    {
        Health = HEALTH;
        Damage = DAMAGE;
    }
}
