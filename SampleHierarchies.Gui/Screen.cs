using Newtonsoft.Json;
using SampleHierarchies.Data;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Abstract base class for a screen.
/// </summary>

public abstract class Screen
{
    /// <summary>
    /// Gets or sets the JSON file path for the screen definition.
    /// </summary>
    /// <remarks>
    /// This property defines the JSON file that contains the screen layout definition.
    /// </remarks>
    public virtual string ScreenDefinitionJson { get; set; } = null!;

    #region Public Methods
    /// <summary>
    /// Show the screen.
    /// </summary>
    public virtual void Show()
    {
        Console.WriteLine("Showing screen");
    }

    #endregion // Public Methods
}
