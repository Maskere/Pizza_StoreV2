using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Schema;
using Pizza_StoreV2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace Pizza_StoreV2.Helpers
{
    public class jsonFileReaderPizza
    {
        public static List<Pizza>ReadJson(string JsonFileName) 
        {
            string jsonString = File.ReadAllText(JsonFileName);
            using (var jsonFileReader = File.OpenText(JsonFileName)) { return JsonConvert.DeserializeObject<List<Pizza>>(jsonString); }
        }
    }
}
