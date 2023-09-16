using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

    /// <summary>
    /// Lions main screen.
    /// </summary>
public sealed class LionsScreen : Screen
{
    #region Properties And Ctor
    /// <summary>
    /// Data service.
    /// </summary>
    public IDataService _dataService;

    public override string ScreenDefinitionJson { get; set; } = "LionsScreenDefinition.json";
    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name ="dataServise">Data service reference</param>
    public LionsScreen(IDataService dataService)
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
            SetConsoleColors(settings.GetLionScreenConsoleColor());
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

                LionsScreenChoices choice = (LionsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case LionsScreenChoices.List:
                        ListLions();
                        break;

                    case LionsScreenChoices.Create:
                        AddLion();
                        break;

                    case LionsScreenChoices.Delete:
                        DeleteLion();
                        break;

                    case LionsScreenChoices.Modify:
                        EditLionMain();
                        break;

                    case LionsScreenChoices.Exit:
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
    /// List all lions.
    /// </summary>
    private void ListLions()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.Lions is not null &&
            _dataService.Animals.Mammals.Lions.Count > 0)
        {
            Console.WriteLine("Here's a list of Lions:");
            int i = 1;
            foreach (Lion lion in _dataService.Animals.Mammals.Lions)
            {
                Console.Write($"Lion number {i}, ");
                lion.Display();
                i++;
            }
        }
        else
        {
            Console.WriteLine("The list of Lions is empty.");
        }
    }
    /// <summary>
    /// Deletes a lion.
    /// </summary>
    private void DeleteLion()
    {
        try
        {
            Console.Write("What is the name of the lion you want to delete? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Lion? lion = (Lion?)(_dataService?.Animals?.Mammals?.Lions
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (lion is not null)
            {
                _dataService?.Animals?.Mammals?.Lions?.Remove(lion);
                Console.WriteLine("Lion with name: {0} has been deleted from a list of Lions", lion.Name);
            }
            else
            {
                Console.WriteLine("Lion not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }
    /// <summary>
    /// Edits an existing lion after choice made.
    /// </summary>
    private void EditLionMain()
    {
        try
        {
            Console.Write("What is the name of the Lion you want to edit? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Lion? lion = (Lion?)(_dataService?.Animals?.Mammals?.Lions
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (lion is not null)
            {
                Lion lionEdited = AddEditLion();
                lion.Copy(lionEdited);
                Console.Write("Lion after edit:");
                lion.Display();
            }
            else
            {
                Console.WriteLine("Lion not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input. Try again.");
        }
    }


    /// <summary>
    /// Add a Lion.
    /// </summary>

    private void AddLion()
    {
        try
        {
            Lion lion = AddEditLion();
            _dataService?.Animals?.Mammals?.Lions?.Add(lion);
            Console.WriteLine("Lion with name: {0} has been added to a list of lions", lion.Name);
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }
    /// <summary>
    /// Adds/edit specific Lion.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private Lion AddEditLion()
    {

        Console.Write("What a name of Lion?  ");
        string? name = Console.ReadLine();
        Console.Write("What is the Lion's age?  ");
        string? ageAsString = Console.ReadLine();
        Console.Write("How looks lions mane?  ");
        string? mane = Console.ReadLine();
        Console.Write("Is the lion an apex predator? (true/false): ");
        if (bool.TryParse(Console.ReadLine(), out bool apexPredator))
        {
            Console.Write("");
        }
        else
        {
            Console.WriteLine("\nPlease enter 'true' or 'false' for apex predator.");
            throw new ArgumentNullException(nameof(apexPredator));
        }

        Console.Write("Is the lion the packhunter? (true/false): ");
        if (bool.TryParse(Console.ReadLine(), out bool packhunter))
        {
            Console.Write("");
        }
        else
        {
            Console.WriteLine("\nPlease enter 'true' or 'false' for apex predator.");
            throw new ArgumentNullException(nameof(packhunter));
        }
        Console.Write("Has the lion Roaring communication? (true/false): ");
        if (bool.TryParse(Console.ReadLine(), out bool roaringCommunication))
        {
            Console.Write("");
        }
        else
        {
            Console.WriteLine("\nPlease enter 'true' or 'false' for apex predator.");
            throw new ArgumentNullException(nameof(roaringCommunication));
        }
        Console.Write("Does lion protect its territory? (true/false): ");
        if (bool.TryParse(Console.ReadLine(), out bool territoryDefense))
        {
            Console.Write("");
        }
        else
        {
            Console.WriteLine("\nPlease enter 'true' or 'false' for apex predator.");
            throw new ArgumentNullException(nameof(territoryDefense));
        }

        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (ageAsString is null)
        {
            throw new ArgumentNullException(nameof(ageAsString));
        }
        if (mane is null)
        {
            throw new ArgumentNullException(nameof(mane));
        }

        int age = Int32.Parse(ageAsString);
        Lion lion = new Lion(name, mane, age, apexPredator, packhunter, roaringCommunication, territoryDefense);

        return lion;
        }
    
    #endregion //Private Methods    
}
