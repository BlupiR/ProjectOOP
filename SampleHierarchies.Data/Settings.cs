using SampleHierarchies.Interfaces.Data;
using Newtonsoft.Json;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Data
{
    /// <summary>
    /// Represents settings for the application, including screen colors.
    /// </summary>
    public class Settings : ISettings
    {
        /// <inheritdoc/>
        public string Version { get; set; }

        /// <inheritdoc/>
        public string MainScreenColor { get; set; }

        /// <inheritdoc/>
        public string AnimalScreenColor { get; set; }

        /// <inheritdoc/>
        public string MammalScreenColor { get; set; }

        /// <inheritdoc/>
        public string DogScreenColor { get; set; }

        /// <inheritdoc/>
        public string LionScreenColor { get; set; }

        /// <inheritdoc/>
        public string ElephantScreenColor { get; set; }

        /// <inheritdoc/>
        public string PolarbearScreenColor { get; set; }

        // Dictionary mapping color names to ConsoleColor values
        private readonly Dictionary<string, ConsoleColor> colorMappings = new Dictionary<string, ConsoleColor>
    {
        { "Green", ConsoleColor.Green },
        { "DarkBlue", ConsoleColor.DarkBlue },
        { "DarkYellow", ConsoleColor.DarkYellow },
        { "Red", ConsoleColor.Red},
        { "Blue", ConsoleColor.Blue},
        { "Yellow", ConsoleColor.Yellow },
        { "Gray", ConsoleColor.Gray },
        { "White", ConsoleColor.White },
        { "Black", ConsoleColor.Black },
        { "Cyan", ConsoleColor.Cyan },
        { "Magenta", ConsoleColor.Magenta },
        { "DarkCyan", ConsoleColor.DarkCyan},
        { "DarkGray", ConsoleColor.DarkGray },
        { "DarkGreen", ConsoleColor.DarkGreen },
        { "DarkMagenta", ConsoleColor.DarkMagenta },
        { "DarkRed", ConsoleColor.DarkRed },
    };

        /// <inheritdoc/>
        public ConsoleColor GetMainScreenConsoleColor()
        {
            return MapColor(MainScreenColor);
        }

        /// <inheritdoc/>
        public ConsoleColor GetAnimalScreenConsoleColor()
        {
            return MapColor(AnimalScreenColor);
        }

        /// <inheritdoc/>
        public ConsoleColor GetMammalScreenConsoleColor()
        {
            return MapColor(MammalScreenColor);
        }

        /// <inheritdoc/>
        public ConsoleColor GetDogScreenConsoleColor()
        {
            return MapColor(DogScreenColor);
        }

        /// <inheritdoc/>
        public ConsoleColor GetLionScreenConsoleColor()
        {
            return MapColor(LionScreenColor);
        }

        /// <inheritdoc/>
        public ConsoleColor GetElephantScreenConsoleColor()
        {
            return MapColor(ElephantScreenColor);
        }

        /// <inheritdoc/>
        public ConsoleColor GetPolarbearScreenConsoleColor()
        {
            return MapColor(PolarbearScreenColor);
        }
        /// <summary>
        /// Maps a color name to a ConsoleColor.
        /// </summary>
        /// <param name="colorName">The name of the color to map.</param>
        /// <returns>The ConsoleColor corresponding to the color name, or ConsoleColor.Black if not found.</returns>
        private ConsoleColor MapColor(string colorName)
        {
            if (colorMappings.TryGetValue(colorName, out ConsoleColor consoleColor))
            {
                return consoleColor;
            }
            // Return ConsoleColor.Black if the color name is not found in the mappings
            return ConsoleColor.Black;
        }
    }
}













