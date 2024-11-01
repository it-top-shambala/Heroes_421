using System.IO;
using System.Text.Json;

namespace Heroes.Lib.Config;

/// <summary>
/// Класс конфигурации героя
/// </summary>
public partial class ConfigItem
{
    /// <summary>
    /// Здоровье
    /// </summary>
    public int? Health { get; set; }

    /// <summary>
    /// Урон
    /// </summary>
    public int? Damage { get; set; }
}

/// <summary>
/// Класс конфигурации героев
/// </summary>
public partial class HeroesConfig
{
    /// <summary>
    /// Конфигурация воина
    /// </summary>
    public ConfigItem? Warrior { get; set; }

    /// <summary>
    /// Конфигурация мага
    /// </summary>
    public ConfigItem? Mage { get; set; }

    /// <summary>
    /// Загрузить конфигурацию героев
    /// </summary>
    /// <param name="path">Путь к файлу конфигурации</param>
    /// <returns>Конфигурация героев</returns>
    public static HeroesConfig? Load(string path = "heroes_config.json")
    {
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<HeroesConfig>(json);
    }
}
