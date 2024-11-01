using System;
using System.IO;
using System.Text.Json;

namespace Heroes.Lib.Config;

public partial class ConfigItem
{
    public int? Health { get; set; }
    public int? Damage { get; set; }
}

public partial class HeroesConfig
{
    public ConfigItem? Warrior { get; set; }
    public ConfigItem? Mage { get; set; }

    public static HeroesConfig? Load(string path = "heroes_config.json")
    {
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<HeroesConfig>(json);
    }
}
