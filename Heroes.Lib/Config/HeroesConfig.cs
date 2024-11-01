using System;
using System.IO;
using System.Text.Json;

namespace Heroes.Lib.Config;

public class ConfigItem : IEquatable<ConfigItem>
{
    public int? Health { get; set; }
    public int? Damage { get; set; }

    public bool Equals(ConfigItem? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Health == other.Health && Damage == other.Damage;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((ConfigItem)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Health, Damage);
    }
}

public class HeroesConfig : IEquatable<HeroesConfig>
{
    public ConfigItem? Warrior { get; set; }
    public ConfigItem? Mage { get; set; }

    public static HeroesConfig? Load(string path = "heroes_config.json")
    {
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<HeroesConfig>(json);
    }

    public bool Equals(HeroesConfig? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Equals(Warrior, other.Warrior) && Equals(Mage, other.Mage);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((HeroesConfig)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Warrior, Mage);
    }
}
