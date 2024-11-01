using Heroes.Lib.Models;

namespace Heroes.Lib.Test;

public class WarriorTest
{
    private const int HEALTH = 100;
    private const int DAMAGE = 10;

    [Fact]
    public void WarriorInit_PositiveTest()
    {
        var warrior = new Warrior()
        {
            Name = "Warrior"
        };

        Assert.Equal(HEALTH, warrior.Health);
        Assert.Equal(DAMAGE, warrior.Damage);
    }

    [Fact]
    public void WarriorInit_NegativeTest()
    {
        Assert.Throws<ArgumentException>(() => new Warrior()
        {
            Name = string.Empty
        });
    }

    [Fact]
    public void Health_Test()
    {
        var warrior = new Warrior
        {
            Name = "Warrior",
            Health = -1
        };

        Assert.Equal(0, warrior.Health);
    }

    [Fact]
    public void Damage_Test()
    {
        var warrior = new Warrior
        {
            Name = "Warrior",
            Damage = -1
        };

        Assert.Equal(0, warrior.Damage);
    }

    [Fact]
    public void IsDead_Test()
    {
        var warrior = new Warrior
        {
            Name = "Warrior",
            Health = -1
        };

        Assert.True(warrior.IsDead);
    }
}
