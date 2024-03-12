﻿using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Data
{
    public class ShareSkillDataHelper
    {
        public static List<ShareSkillData> ReadShareSkillData(string jsonFileName)
        {
            string currentDirectory = TestContext.CurrentContext.TestDirectory;
            string filePath = Path.Combine(currentDirectory, "Data", jsonFileName);
            string jsonContent = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<List<ShareSkillData>>(jsonContent) ?? new List<ShareSkillData>();
        }
    }
}
