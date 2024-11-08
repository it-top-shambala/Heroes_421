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
    /// Логгер
    /// </summary>
    public static Logger? Logger { get; set; }

    /// <summary>
    /// Загрузить конфигурацию героев
    /// </summary>
    /// <param name="path">Путь к файлу конфигурации</param>
    /// <returns>Конфигурация героев</returns>
    /// <exception cref="FileException">Проблемы с чтением файла</exception>
    /// <exception cref="DeserializeException">Проблемы с десериализацией</exception>
    public static HeroesConfig? Load(string path = "heroes_config.json")
    {
        /*if (Logger is not null)
        {
            Logger($"$Загрузка конфигурации героев из файла {path}");
            //Logger.Invoke($"$Загрузка конфигурации героев из файла {path}");
        }*/
        Logger?.Invoke($"[INFO] ({DateTime.Now:g}) Загрузка конфигурации героев из файла {path}");


        // Чтение файла (выбросить исключение, если не удалось)
        string GetJson(string path)
        {
            Logger?.Invoke($"[INFO] ({DateTime.Now:g}) Загрузка файла {path}");

            if (!File.Exists(path))
            {
                Logger?.Invoke($"[ERROR] ({DateTime.Now:g}) Файл {path} не найден");
                throw new FileException(null);
            }

            string? json = null;
            try
            {
                Logger?.Invoke($"[INFO] ({DateTime.Now:g}) Чтение файла {path}");
                json = File.ReadAllText(path);
            }
            catch (Exception e)
            {
                Logger?.Invoke($"[ERROR] ({DateTime.Now:g}) Проблемы с чтением файла {path}");
                throw new FileException(e);
            }

            if (json.Length == 0)
            {
                Logger?.Invoke($"[ERROR] ({DateTime.Now:g} Файл {path} пуст");
                throw new FileException(null);
            }

            return json;
        }

        var json = GetJson(path);
        try
        {
            Logger?.Invoke($"[INFO] ({DateTime.Now:g}) Десериализация конфигурации героев");
            return JsonSerializer.Deserialize<HeroesConfig>(json);
        }
        catch (Exception e)
        {
            Logger?.Invoke($"[ERROR] ({DateTime.Now:g}) Проблемы с десериализацией конфигурации героев");
            throw new DeserializeException(e);
        }
    }
}
