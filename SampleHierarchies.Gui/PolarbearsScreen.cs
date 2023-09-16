using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Polarbears main screen.
/// </summary>
public sealed class PolarbearsScreen : Screen
{
    #region Properties and Ctor
    /// <summary>
    /// Data servie.
    /// </summary>
    public IDataService _dataService;

    public override string ScreenDefinitionJson { get; set; } = "PolarbearsScreenDefinition.json";
    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name ="dataServise">Data service reference</param>
    public PolarbearsScreen(IDataService dataService)
    {
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
            SetConsoleColors(settings.GetPolarbearScreenConsoleColor());
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

                PolarbearsScreenChoices choice = (PolarbearsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case PolarbearsScreenChoices.List:
                        ListPolarbears();
                        break;

                    case PolarbearsScreenChoices.Create:
                        AddPolarbear();
                        break;

                    case PolarbearsScreenChoices.Delete:
                        DeletePolarbear();
                        break;

                    case PolarbearsScreenChoices.Modify:
                        EditPolarbearMain();
                        break;

                    case PolarbearsScreenChoices.Exit:
                        ScreenDefinitionService.PrintLineEntry(ScreenDefinitionJson, 8);
                        SetConsoleColors(settings.GetMammalScreenConsoleColor());
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
    /// <summary>
    /// List all polarbears.
    /// </summary>
    private void ListPolarbears()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.Polarbears is not null &&
            _dataService.Animals.Mammals.Polarbears.Count > 0)
        {
            Console.WriteLine("Here's a list of Polarbears:");
            int i = 1;
            foreach (Polarbear polarbear in _dataService.Animals.Mammals.Polarbears)
            {
                Console.Write($"Polarbear number {i}, ");
                polarbear.Display();
                i++;
            }
        }
        else
        {
            Console.WriteLine("The list of Polarbears is empty.");
        }
    }
    /// <summary>
    /// Deletes the Polarbear.
    /// </summary>
    private void DeletePolarbear()
    {
        try
        {
            Console.Write("What is the name of the Polarbear you want to delete? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Polarbear? polarbear = (Polarbear?)(_dataService?.Animals?.Mammals?.Polarbears
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (polarbear is not null)
            {
                _dataService?.Animals?.Mammals?.Polarbears?.Remove(polarbear);
                Console.WriteLine("Polarbear with name: {0} has been deleted from a list of Polarbear", polarbear.Name);
            }
            else
            {
                Console.WriteLine("Polarbear not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }
    /// <summary>
    /// Edits an existing Polarbears after choice made.
    /// </summary>
    private void EditPolarbearMain()
    {
        try
        {
            Console.Write("What is the name of the Polarbear you want to edit? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Polarbear? polarbear = (Polarbear?)(_dataService?.Animals?.Mammals?.Polarbears
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (polarbear is not null)
            {
                Polarbear polarbearEdited = AddEditPolarbear();
                polarbear.Copy(polarbearEdited);
                Console.Write("Polarbear after edit:");
                polarbear.Display();
            }
            else
            {
                Console.WriteLine("Polarbear not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input. Try again.");
        }
    }


    /// <summary>
    /// Add the Polarbear.
    /// </summary>

    private void AddPolarbear()
    {
        try
        {
            Polarbear polarbear = AddEditPolarbear();
            _dataService?.Animals?.Mammals?.Polarbears?.Add(polarbear);
            Console.WriteLine("Polarbear with name: {0} has been added to a list of polarbears", polarbear.Name);
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }
    /// <summary>
    /// Adds/edit specific Polarbear.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private Polarbear AddEditPolarbear()
    {

        Console.Write("What a name of Polarbear?  ");
        string? name = Console.ReadLine();
        Console.Write("What is the Polarbear's age?  ");
        string? ageAsString = Console.ReadLine();
        Console.Write("How thick is Polarbear's coat?  ");
        string? Thickfurcoat = Console.ReadLine();
        Console.Write("How big are the paws of a Polarbear?  ");
        string? Largepaws = Console.ReadLine();
        Console.Write("What is a Polarbear's carnivorous diet? ");
        string? Carnivorousdiet = Console.ReadLine();
        Console.Write("What is a polar bear's sense of smell? ");
        string? Excellentsenseofsmell = Console.ReadLine();
        Console.Write("Is the polarbear Semi-aquatic? (true/false): ");
        if (bool.TryParse(Console.ReadLine(), out bool Semiaquatic))
        {
            Console.Write("");
        }
        else
        {
            Console.WriteLine("\nPlease enter 'true' or 'false' for Semi-aquatic.");
            throw new ArgumentNullException(nameof(Semiaquatic));
        }

        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (ageAsString is null)
        {
            throw new ArgumentNullException(nameof(ageAsString));
        }



        int age = Int32.Parse(ageAsString);
        Polarbear polarbear = new Polarbear(name, Thickfurcoat, age, Largepaws, Carnivorousdiet, Excellentsenseofsmell, Semiaquatic);

        return polarbear;
    }

    #endregion //Private Methods    
}








