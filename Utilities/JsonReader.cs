using Newtonsoft.Json;
using NUnit.Framework;

namespace AdvancedTask.Utilities
{
    public class JsonReader
    {
        public static List<T> loadData<T>(String jsonFilename)
        {
            string currentDirectory = TestContext.CurrentContext.TestDirectory;
            string filePath = Path.Combine(currentDirectory, "Data", jsonFilename);
            using (StreamReader reader = new StreamReader(filePath))
            {
                var jsonContent = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(jsonContent);
            }
        }

    }
}
