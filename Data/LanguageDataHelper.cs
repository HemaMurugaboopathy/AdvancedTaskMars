using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Data
{
    public class LanguageDataHelper
    {
        public static List<LanguageData> ReadLanguageData(string jsonFileName)
        {
            string currentDirectory = TestContext.CurrentContext.TestDirectory;
            string filePath = Path.Combine(currentDirectory, "Data", jsonFileName);
            string jsonContent = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<List<LanguageData>>(jsonContent) ?? new List<LanguageData>();
        }
    }
}
