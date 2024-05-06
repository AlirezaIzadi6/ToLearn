using System.Text.Json;

namespace ToLearn.Utils;

public class Config
{
    private static string appData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
    private static string _configPath = appData + @"\ToLearn\config";

    public static void Initialize()
    {
        if (!Directory.Exists(_configPath))
        {
            Directory.CreateDirectory(_configPath);
        }
    }

    public static void SaveConfig<T>(T obj)
    {
        string filePath = $"{_configPath}\\{typeof(T).Name}.json";
        string fileContent = JsonSerializer.Serialize<T>(obj);
        File.WriteAllText(filePath, fileContent);
    }

    public static T GetConfig<T>()
    {
        string filePath = $"{_configPath}\\{typeof(T).Name}.json";
        string fileContent = File.ReadAllText(filePath);
        T obj = JsonSerializer.Deserialize<T>(fileContent);
        return obj;
    }

    public static void DeleteConfig<T>()
    {
        string filePath = $"{_configPath}\\{typeof(T).Name}.json";
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}
