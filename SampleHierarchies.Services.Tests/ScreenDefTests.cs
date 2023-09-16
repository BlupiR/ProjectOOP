
using Microsoft.VisualStudio.TestPlatform.Utilities;
using SampleHierarchies.Services;
using Newtonsoft.Json;
using SampleHierarchies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Services.Tests
    {
        [TestClass]
        public class ScreenDefinitionServiceTests
        {
        // Directory for storing test JSON files
        private string testJsonDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestJsonFiles");

            [TestInitialize]
            public void Initialize()
            {
            // Create a directory for test JSON files if it does not exist
            if (!Directory.Exists(testJsonDirectory))
                {
                    Directory.CreateDirectory(testJsonDirectory);
                }
            }

            [TestMethod]
            public void Load_ValidJsonFile_ShouldLoadScreenDefinition()
            {
                // Arrange
                string jsonFileName = CreateValidJsonFile(); // Create a test JSON file and get its path

            try
                {
                    // Act
                    var screenDefinition = ScreenDefinitionService.Load(jsonFileName);

                    // Assert
                    Assert.IsNotNull(screenDefinition);
                    Assert.IsInstanceOfType(screenDefinition, typeof(ScreenDefinition));
                }
                finally
                {
                // Delete test JSON file after test completes
                File.Delete(jsonFileName);
                }
            }

            [TestMethod]
            public void Load_InvalidJsonFile_ShouldThrowException()
            {
                // Arrange
                string jsonFileName = CreateInvalidJsonFile(); // Ñreate an incorrect test JSON file and get its path

            try
                {
                // Act & Assert
                Assert.ThrowsException<JsonReaderException>(() => ScreenDefinitionService.Load(jsonFileName));
                }
                
                finally
                {
                // Delete test JSON file after test completes
                File.Delete(jsonFileName);
                }
            }

            [TestMethod]
            public void PrintLineEntry_ValidInput_ShouldPrintLine()
            {
                // Arrange
                string fileName = CreateValidJsonFile();
                int lineNumber = 0; // Line number to check
                string output = CaptureConsoleOutput(() =>
                {
                    // Act
                    ScreenDefinitionService.PrintLineEntry(fileName, lineNumber);
                });

                // Assert
                StringAssert.Contains(output, "ExpectedLine0"); 
            }

            [TestMethod]
            public void PrintLineEntry_LineNotFound_ShouldPrintErrorMessage()
            {
                // Arrange
                string fileName = CreateValidJsonFile(); 
                int lineNumber = 99; // Line number that is not in the file
                string output = CaptureConsoleOutput(() =>
                {
                    // Act
                    ScreenDefinitionService.PrintLineEntry(fileName, lineNumber);
                });

                // Assert
                StringAssert.Contains(output, "Line not found.");
            }

            // Method for creating a test JSON file with the correct structure
            private string CreateValidJsonFile()
            {
                string jsonFileName = Path.Combine(testJsonDirectory, "valid-screen-definition.json");
                File.WriteAllText(jsonFileName, "{\"LineEntries\": [{\"Text\": \"ExpectedLine0\", \"BackgroundColor\": \"Black\", \"ForegroundColor\": \"White\"}]}");
                return jsonFileName;
            }

            // Method for creating a test JSON file with an incorrect structure
            private string CreateInvalidJsonFile()
            {
                string jsonFileName = Path.Combine(testJsonDirectory, "invalid-screen-definition.json");
                File.WriteAllText(jsonFileName, "Invalid JSON");
                return jsonFileName;
            }

            // Method for intercepting console output
            private string CaptureConsoleOutput(Action action)
            {
                StringWriter stringWriter = new StringWriter();
                Console.SetOut(stringWriter);

                action.Invoke();

                string output = stringWriter.ToString();
                stringWriter.Dispose();

                return output;
            }
        }    
}


