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
    public static HeroesConfig? Load(string path = "heroes_config.json")
    {
        /*try
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<HeroesConfig>(json);
        }
        catch (ArgumentException exception)
        {
            throw new FileException(exception);
        }
        catch (DirectoryNotFoundException exception)
        {
            throw new FileException(exception);
        }
        catch (FileNotFoundException exception)
        {
            throw new FileException(exception);
        }
        catch (JsonException exception)
        {
            throw new DeserializeException(exception);
        }
        catch (NotSupportedException exception)
        {
            throw new DeserializeException(exception);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }*/

        if (!File.Exists(path))
        {
            throw new FileException(null);
        }

        string? json = null;
        try
        {
            json = File.ReadAllText(path);
        }
        catch (IOException e)
        {
            throw new FileException(e);
        }
        catch (UnauthorizedAccessException e)
        {
            throw new FileException(e);
        }

        if (json.Length == 0)
        {
            throw new FileException(null);
        }

        try
        {
            return JsonSerializer.Deserialize<HeroesConfig>(json);
        }
        catch (JsonException e)
        {
            throw new DeserializeException(e);
        }
        catch (NotSupportedException e)
        {
            throw new DeserializeException(e);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
