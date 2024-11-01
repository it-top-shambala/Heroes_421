using System;

namespace Heroes.Lib.Config;

public partial class ConfigItem : IEquatable<ConfigItem>
{
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

public partial class HeroesConfig : IEquatable<HeroesConfig>
{
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
