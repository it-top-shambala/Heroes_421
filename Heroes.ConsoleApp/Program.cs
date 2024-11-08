using System;
using System.IO;
using Heroes.Lib.Config;

HeroesConfig.Logger = SaveToFile;
HeroesConfig.Logger += Console.WriteLine;

var config = HeroesConfig.Load();

return;

void SaveToFile(string message)
{
    File.AppendAllText("log.txt", $"{message}\n");
}
