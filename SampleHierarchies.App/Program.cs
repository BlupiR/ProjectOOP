// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PeanutButter.TinyEventAggregator;
using SampleHierarchies.Data;
using SampleHierarchies.Enums;
using SampleHierarchies.Gui;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;
using System.Security.Cryptography.X509Certificates;

namespace ImageTagger.FrontEnd.WinForms;

/// <summary>
/// Main class for starting up program.
/// </summary>
internal static class Program
{
    #region Main Method

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    /// <param name="args">Arguments</param>
    [STAThread]

    static void Main(string[] args)
    {
        // Create an object with default settings
        var defaultSettings = new Settings
        {
            Version = "1.0",
            MainScreenColor = "Yellow",
            AnimalScreenColor = "Cyan",
            MammalScreenColor = "Green",
            DogScreenColor = "Magenta",
            LionScreenColor = "Red",
            ElephantScreenColor = "Yellow",
            PolarbearScreenColor = "DarkGreen",
        };
        // Serialize the settings to JSON
        string json = JsonConvert.SerializeObject(defaultSettings, Formatting.Indented);
        // Specify the path to the file where JSON will be written
        string filePath = "settings.json";
        // Write the JSON to the file
        File.WriteAllText(filePath, json);

        Console.WriteLine($"JSON-file with default settings: {filePath}");
        // Create a host for the application and retrieve the required service for the main screen
        var host = CreateHostBuilder().Build();
        ServiceProvider = host.Services;

        var mainScreen = ServiceProvider.GetRequiredService<MainScreen>();
        mainScreen.Show();
        

    }

    #endregion // Main Method

    #region Properties And Methods
    

    /// <summary>
    /// Service provider.
    /// </summary>
    public static IServiceProvider? ServiceProvider { get; private set; } = null;

    /// <summary>
    /// Creates a host builder.
    /// </summary>
    /// <returns></returns>
    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) => 
            {
                services.AddSingleton<ISettingsService, SettingsService>();
                services.AddSingleton<IEventAggregator, EventAggregator>();
                services.AddSingleton<IDataService, DataService>();
                services.AddSingleton<MainScreen, MainScreen>();
                services.AddSingleton<DogsScreen, DogsScreen>();
                services.AddSingleton<AnimalsScreen, AnimalsScreen>();
                services.AddSingleton<MammalsScreen, MammalsScreen>();
                services.AddSingleton<LionsScreen, LionsScreen>();
                services.AddSingleton<ElephantsScreen, ElephantsScreen>();
                services.AddSingleton<PolarbearsScreen, PolarbearsScreen>();
                services.AddScoped<ServiceCollection> ();
                services.AddSingleton<Settings, Settings> ();




            });
    }

        

    #endregion // Properties And Methods
}

