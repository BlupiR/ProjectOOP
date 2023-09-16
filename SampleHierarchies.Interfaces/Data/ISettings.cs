using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Interfaces.Data;

namespace SampleHierarchies.Interfaces.Data;

/// <summary>
/// Settings interface.
/// </summary>
public interface ISettings
{
    #region Interface Members

    /// <summary>
    /// Gets or sets the version of settings.
    /// </summary>
    string Version { get; set; }

    /// <summary>
    /// Gets or sets the color for the main screen.
    /// </summary>
    string MainScreenColor { get; set; }

    /// <summary>
    /// Gets or sets the color for the animal screen.
    /// </summary>
    string AnimalScreenColor { get; set; }

    /// <summary>
    /// Gets or sets the color for the mammal screen.
    /// </summary>
    string MammalScreenColor { get; set; }

    /// <summary>
    /// Gets or sets the color for the dog screen.
    /// </summary>
    string DogScreenColor { get; set; }

    /// <summary>
    /// Gets or sets the color for the lion screen.
    /// </summary>
    string LionScreenColor { get; set; }

    /// <summary>
    /// Gets or sets the color for the elephant screen.
    /// </summary>
    string ElephantScreenColor { get; set; }

    /// <summary>
    /// Gets or sets the color for the polar bear screen.
    /// </summary>
    string PolarbearScreenColor { get; set; }

    #endregion // Interface Members

    /// <summary>
    /// Gets the console color for the main screen.
    /// </summary>
    ConsoleColor GetMainScreenConsoleColor();

    /// <summary>
    /// Gets the console color for the animal screen.
    /// </summary>
    ConsoleColor GetAnimalScreenConsoleColor();

    /// <summary>
    /// Gets the console color for the mammal screen.
    /// </summary>
    ConsoleColor GetMammalScreenConsoleColor();

    /// <summary>
    /// Gets the console color for the dog screen.
    /// </summary>
    ConsoleColor GetDogScreenConsoleColor();

    /// <summary>
    /// Gets the console color for the lion screen.
    /// </summary>
    ConsoleColor GetLionScreenConsoleColor();

    /// <summary>
    /// Gets the console color for the elephant screen.
    /// </summary>
    ConsoleColor GetElephantScreenConsoleColor();

    /// <summary>
    /// Gets the console color for the polar bear screen.
    /// </summary>
    ConsoleColor GetPolarbearScreenConsoleColor();
}



    


