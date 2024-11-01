using Heroes.Lib.Config;

namespace Heroes.Lib.Test;

public class HeroesConfigTest
{
    [Fact]
    public void Load_Test()
    {
        const string path = "heroes_config_test.json";
        var expected = new HeroesConfig
        {
            Warrior = new ConfigItem
            {
                Health = 100,
                Damage = 10
            }
        };

        var actual = HeroesConfig.Load(path);

        Assert.Equal(expected, actual);
    }
}
