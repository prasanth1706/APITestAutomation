using Newtonsoft.Json;


namespace TestProject2.Helpers
{
    public static class JsonHelper
    {
        public static T LoadJson<T>(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
