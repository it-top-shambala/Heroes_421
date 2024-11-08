using Heroes.Lib.Config;

namespace Heroes.Lib.Test;

public class HeroesConfigTest
{
    [Fact]
    public void Load_PositiveTest()
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

    [Fact]
    public void Load_FileNotFoundTest()
    {
        Assert.Throws<FileException>(() => HeroesConfig.Load("heroes_config_test_not_found.json"));
    }

    [Fact]
    public void Load_JsonNegativeTest()
    {
        Assert.Throws<DeserializeException>(() => HeroesConfig.Load("heroes_config_negative_test.json"));
    }
}
