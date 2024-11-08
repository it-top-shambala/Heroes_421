using System;

namespace Heroes.Lib.Config;

/// <summary>
/// Исключение, возникающее при попытке открыть файл
/// </summary>
public class FileException : Exception
{
    public FileException(Exception? innerException)
        : base("Не найден файл или ошибка чтения файла", innerException)
    {
    }
}

/// <summary>
/// Исключение, возникающее при попытке десериализовать объект
/// </summary>
public class DeserializeException : Exception
{
    public DeserializeException(Exception? innerException)
        : base("Не удалось десериализовать объект", innerException)
    {
    }
}
