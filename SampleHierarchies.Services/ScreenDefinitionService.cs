using Newtonsoft.Json;
using SampleHierarchies.Data;
using SampleHierarchies.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Services
{
    public static class ScreenDefinitionService 
    {
        public static ScreenDefinition Load(string jsonFileName)
        {
            string jsonContent = File.ReadAllText(jsonFileName);
            return JsonConvert.DeserializeObject<ScreenDefinition>(jsonContent);
        }

        public static void PrintLineEntry(string FileName, int numberOfLine)
        {
            var screenDefinition = ScreenDefinitionService.Load(FileName);
            var lineEntry = screenDefinition.LineEntries.ElementAtOrDefault(numberOfLine);

            if (lineEntry != null)
            {
                Console.BackgroundColor = lineEntry.BackgroundColor;
                Console.ForegroundColor = lineEntry.ForegroundColor;
                Console.WriteLine(lineEntry.Text);
            }
            else
            {
                Console.WriteLine("Line not found.");
            }
        }
    }
}
