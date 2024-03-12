using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Data
{
    public class SkillsDataHelper
    {
        public static List<SkillsData> ReadSkillsData(string jsonFileName)
        {
            string currentDirectory = TestContext.CurrentContext.TestDirectory;
            string filePath = Path.Combine(currentDirectory, "Data", jsonFileName);
            string jsonContent = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<List<SkillsData>>(jsonContent) ?? new List<SkillsData>();
        }
    }
}
