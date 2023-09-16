using Newtonsoft.Json.Linq;
using SampleHierarchies.Data;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;
using System.Reflection.Metadata.Ecma335;

namespace SampleHierarchies.Gui;

/// <summary>
/// Application main screen.
/// </summary>
public sealed class MainScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;
    /// <summary>
    /// Animals screen.
    /// </summary>
    private AnimalsScreen _animalsScreen;
    /// <summary>
    /// Settings service.
    /// </summary>
    private ISettingsService _settingsService;


    public override string ScreenDefinitionJson { get; set; } = "MainScreenDefinition.json";

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="animalsScreen">Animals screen</param>
    /// <param name="settingsService">Settings service reference </param>
    public MainScreen(
        IDataService dataService,
        AnimalsScreen animalsScreen,
        ISettingsService settingsService

       )
    {
        _settingsService = settingsService;
        _dataService = dataService;
        _animalsScreen = animalsScreen;
    }


    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        ISettingsService settingsService = new SettingsService();
        string FilePath = "settings.json";
        ISettings settings = settingsService.LoadSettings(FilePath);


        if (settings != null)
        {
            SetConsoleColors(settings.GetMainScreenConsoleColor());
            Console.Clear();

            while (true)
            {
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 0);
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 1);
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 2);
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 3);
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 4);
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 5);

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    if (choiceAsString is null)
                    {
                        throw new ArgumentNullException(nameof(choiceAsString));
                    }

                    MainScreenChoices choice = (MainScreenChoices)Int32.Parse(choiceAsString);
                    switch (choice)
                    {
                        case MainScreenChoices.Animals:
                            SetConsoleColors(settings.GetAnimalScreenConsoleColor());
                            _animalsScreen.Show();
                            break;

                        case MainScreenChoices.Settings:
                            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 6);
                            string screenName = Console.ReadLine();
                            _settingsService.ChangeScreenColor(settings, screenName);
                            break;

                        case MainScreenChoices.Exit:
                            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 7);
                            return;
                    }
                }
                catch
                {
                    ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 8);
                }
            }
        }
    }
    #endregion // Public Methods

    #region Private Methods 
    private void SetConsoleColors(ConsoleColor backgroundColor)
    {
        Console.BackgroundColor = backgroundColor;
    }
    #endregion // Private Methods 


}
