using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data
{
    /// <summary>
    /// Represents the definition of a screen with a list of line entries.
    /// </summary>
    public class ScreenDefinition
    {
        /// <summary>
        /// Gets or sets the list of line entries that define the screen.
        /// </summary>
        public List<ScreenLineEntry>? LineEntries { get; set; }
    }
}
