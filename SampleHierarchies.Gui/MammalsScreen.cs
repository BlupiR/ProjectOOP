using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class MammalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Dogs screen.
    /// </summary>
    private DogsScreen _dogsScreen;
    /// <summary>
    /// Lions screen.
    /// </summary>
    private LionsScreen _lionsScreen;
    /// <summary>
    /// Elephants screen.
    /// </summary>
    private ElephantsScreen _elephantsScreen;
    /// <summary>
    /// Polarbears screen.
    /// </summary>
    private PolarbearsScreen _polarbearsScreen;


    private IDataService _dataService;

    public override string ScreenDefinitionJson { get; set; } = "MammalsScreenDefinition.json";
    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="dogsScreen">Dogs screen</param>
    /// <param name="lionsScreen">Lions screen</param>
    public MammalsScreen(DogsScreen dogsScreen, 
        LionsScreen lionsScreen, 
        IDataService dataService,
        ElephantsScreen elephantsScreen,
        PolarbearsScreen polarbearsScreen )
    {
        _elephantsScreen = elephantsScreen;
        _dogsScreen = dogsScreen;
        _lionsScreen = lionsScreen;
        _polarbearsScreen = polarbearsScreen;
        _dataService = dataService;

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
            SetConsoleColors(settings.GetMammalScreenConsoleColor());
             Console.Clear();
        }
        while (true)
        {
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 0);
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 1);
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 2);
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 3);
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 4);
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 5);
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 6);
            ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 7);
            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MammalsScreenChoices choice = (MammalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MammalsScreenChoices.Dogs:
                        _dogsScreen.Show();
                        break;
                    /// Lions screen show
                    case MammalsScreenChoices.Lion:
                        _lionsScreen.Show();
                        break;
                    /// Elephant screen show
                    case MammalsScreenChoices.Elephant:
                        _elephantsScreen.Show();
                        break;
                    /// Polarbear screen show
                    case MammalsScreenChoices.Polarbear:
                        _polarbearsScreen.Show();
                        break;
                    case MammalsScreenChoices.Exit:
                        ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 8);
                        SetConsoleColors(settings.GetAnimalScreenConsoleColor());
                        Console.Clear();
                        return;
                }
            }
            catch
            {
                ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 9);
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
