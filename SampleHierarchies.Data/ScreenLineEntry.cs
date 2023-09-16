using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data
{
    /// <summary>
    /// Represents a line entry on a screen with background color, foreground color, and text.
    /// </summary>
    public class ScreenLineEntry
    {
        /// <summary>
        /// Gets or sets the background color for the line entry.
        /// </summary>
        public ConsoleColor BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the foreground color for the line entry.
        /// </summary>
        public ConsoleColor ForegroundColor { get; set; }

        /// <summary>
        /// Gets or sets the text to be displayed on the line entry.
        /// </summary>
        public string? Text { get; set; }
    }
}
