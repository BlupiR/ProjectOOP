using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Elephants main screen.
/// </summary>
public sealed class ElephantsScreen : Screen
{
    #region Properties and Ctor
    /// <summary>
    /// Data servie.
    /// </summary>
    public IDataService _dataService;

    public override string ScreenDefinitionJson { get; set; } = "ElephantsScreenDefinition.json";
    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name ="dataServise">Data service reference</param>
    public ElephantsScreen(IDataService dataService)
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
            
            SetConsoleColors(settings.GetElephantScreenConsoleColor());
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

            ElephantsScreenChoices choice = (ElephantsScreenChoices)Int32.Parse(choiceAsString);
            switch (choice)
            {
                case ElephantsScreenChoices.List:
                    ListElephants();
                    break;

                case ElephantsScreenChoices.Create:
                    AddElephant();
                    break;

                case ElephantsScreenChoices.Delete:
                    DeleteElephant();
                    break;

                case ElephantsScreenChoices.Modify:
                    EditElephantMain();
                    break;

                case ElephantsScreenChoices.Exit:
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
    /// List all elephants.
    /// </summary>
    private void ListElephants()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.Elephants is not null &&
            _dataService.Animals.Mammals.Elephants.Count > 0)
        {
            Console.WriteLine("Here's a list of Elephants:");
            int i = 1;
            foreach (Elephant elephant in _dataService.Animals.Mammals.Elephants)
            {
                Console.Write($"Elephant number {i}, ");
                elephant.Display();
                i++;
            }
        }
        else
        {
            Console.WriteLine("The list of Elephants is empty.");
        }
    }
    /// <summary>
    /// Deletes an Elephant.
    /// </summary>
    private void DeleteElephant()
    {
        try
        {
            Console.Write("What is the name of the Elephant you want to delete? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Elephant? elephant = (Elephant?)(_dataService?.Animals?.Mammals?.Elephants
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (elephant is not null)
            {
                _dataService?.Animals?.Mammals?.Elephants?.Remove(elephant);
                Console.WriteLine("Elephant with name: {0} has been deleted from a list of Elephant", elephant.Name);
            }
            else
            {
                Console.WriteLine("Elephant not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }
    /// <summary>
    /// Edits an existing elephant after choice made.
    /// </summary>
    private void EditElephantMain()
    {
        try
        {
            Console.Write("What is the name of the Elephant you want to edit? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Elephant? elephant = (Elephant?)(_dataService?.Animals?.Mammals?.Elephants
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (elephant is not null)
            {
                Elephant elephantEdited = AddEditElephant();
                elephant.Copy(elephantEdited);
                Console.Write("Elephant after edit:");
                elephant.Display();
            }
            else
            {
                Console.WriteLine("Elephant not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input. Try again.");
        }
    }


    /// <summary>
    /// Add an Elephant.
    /// </summary>

    private void AddElephant()
    {
        try
        {
            Elephant elephant = AddEditElephant();
            _dataService?.Animals?.Mammals?.Elephants?.Add(elephant);
            Console.WriteLine("Elephant with name: {0} has been added to a list of elephants", elephant.Name);
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }
    /// <summary>
    /// Adds/edit specific Elephant.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private Elephant AddEditElephant()
    {

        Console.Write("What a name of Elephant?  ");
        string? name = Console.ReadLine();
        Console.Write("What is the Elephant's age?  ");
        string? ageAsString = Console.ReadLine();
        Console.Write("What is the social behavior of an elephant?  ");
        string? SocialBehavior = Console.ReadLine();
        Console.Write("What is the life expectancy of an elephant?  ");
        string? longLifespanAsString = Console.ReadLine();


        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (ageAsString is null)
        {
            throw new ArgumentNullException(nameof(ageAsString));
        }

        Console.Write("What is the height of an elephant?");
        if (float.TryParse(Console.ReadLine(), out float height))
        {

            Console.Write("");
        }
   
        else
        {
            Console.WriteLine("\n");
            throw new ArgumentNullException(nameof(height));
        }

        Console.Write("What is the weight of an elephant? ");
        if (float.TryParse(Console.ReadLine(), out float weight))
        {

            Console.Write("");
        }
        else
        {
            Console.WriteLine("\n");
            throw new ArgumentNullException(nameof(weight));
        }

        Console.Write("How long is an elephant's tusk? ");
        if (float.TryParse(Console.ReadLine(), out float tuskLenght))
        {

            Console.Write("");
        }
        else
        {
            Console.WriteLine("\n ");
            throw new ArgumentNullException(nameof(tuskLenght));
        }


        if (longLifespanAsString is null)
        {
            throw new ArgumentNullException(nameof(longLifespanAsString));
        }

        int age = Int32.Parse(ageAsString);
        int longLifespan = Int32.Parse(longLifespanAsString);
        Elephant elephant = new Elephant(name, SocialBehavior, age, height , weight, tuskLenght, longLifespan);

        return elephant;
    }

    #endregion //Private Methods    
}


    
    




