using System.Xml.Linq;
using TestProject2.Helpers;
using TestProject2.Models;

namespace TestProject2.Tests
{
    public class BaseTest
    {
        protected EnvironmentModel _environment;
        string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        [SetUp]
        public virtual void Setup()
        {
            
            // Load environment from JSON
            string jsonPath = Path.Combine(projectDirectory, "Config", "environment.json");
            var environments = JsonHelper.LoadJson<dynamic>(jsonPath)["Environments"];

            // Load environment based on testrunsettings file
            string testEnvironment = LoadTestEnvironmentFromSettings();
            _environment = environments[testEnvironment].ToObject<EnvironmentModel>();

            // Optional: Print loaded environment details to TestContext output
            TestContext.Out.WriteLine($"Running tests in {testEnvironment} environment");
            TestContext.Out.WriteLine($"BaseUrl: {_environment.BaseUrl}");
            TestContext.Out.WriteLine($"ApiKey: {_environment.ApiKey}");
        }

        private string LoadTestEnvironmentFromSettings()
        {
            string settingsPath = Path.Combine(projectDirectory, "Config","testrunsettings.runsettings");
            var settings = File.ReadAllText(settingsPath);
            var doc = XDocument.Parse(settings);
            return doc.Root.Element("RunConfiguration").Element("TestEnvironment").Value;
        }

        [TearDown]
        public virtual void Teardown()
        {
            // Perform any cleanup actions if needed after each test
        }
    }
}
