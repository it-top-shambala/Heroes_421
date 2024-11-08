using System;
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
    /// <exception cref="FileException">Проблемы с чтением файла</exception>
    /// <exception cref="DeserializeException">Проблемы с десериализацией</exception>
    public static HeroesConfig? Load(string path = "heroes_config.json")
    {
        string GetJson(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileException(null);
            }

            string? json = null;
            try
            {
                json = File.ReadAllText(path);
            }
            catch (Exception e)
            {
                throw new FileException(e);
            }

            if (json.Length == 0)
            {
                throw new FileException(null);
            }

            return json;
        }

        var json = GetJson(path);
        try
        {
            return JsonSerializer.Deserialize<HeroesConfig>(json);
        }
        catch (Exception e)
        {
            throw new DeserializeException(e);
        }
    }
}
