using SampleHierarchies.Data;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq.Expressions;

namespace SampleHierarchies.Services;

/// <summary>
/// Settings service.
/// </summary>
public class SettingsService : ISettingsService
{
    #region ISettings Implementation

    public ISettings LoadSettings(string fileName)
    {
        if (File.Exists(fileName))
        {
            var json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<Settings>(json);
        }
        else
        {
            // If the file does not exist, you can return a new settings object with default values ​​or handle the case in another way.
            return new Settings();
        }
    }

    public void SaveSettings(ISettings settings, string fileName)
    {
        string json = JsonConvert.SerializeObject(settings);
        File.WriteAllText(fileName, json);
    }
    public void ChangeScreenColor(ISettings settings, string screenName)
    {
        Console.WriteLine($"Enter the new screen color for {screenName}:");
        string newColor = Console.ReadLine();

        // Depending on the screen name, sets the corresponding color field in the settings
        switch (screenName)
        {
            case "Main Screen":
                settings.MainScreenColor = newColor;
                Console.Clear();
                Console.BackgroundColor = settings.GetMainScreenConsoleColor();

                break;
            case "Animals Screen":
                if (screenName is not null) 
                settings.AnimalScreenColor = newColor;

                break;
            case "Mammals Screen":
                settings.MammalScreenColor = newColor;

                break;
            case "Dogs Screen":
                settings.DogScreenColor = newColor;

                break;
            case "Lions Screen":
                settings.LionScreenColor = newColor;

                break;
            case "Elephants Screen":
                settings.ElephantScreenColor = newColor;

                break;
            case "Polarbears Screen":
                settings.PolarbearScreenColor = newColor;

                break;
            default:
                Console.WriteLine($"Screen '{screenName}' not found in settings.");
                return;
        }

        // Saves updated settings
        ISettingsService settingsService = new SettingsService();
        string FilePath = "settings.json";
        settingsService.SaveSettings(settings, FilePath);
        Console.WriteLine($"Color for '{screenName}' has been updated to: {newColor}");

    }


}





#endregion // ISettings Implementation
