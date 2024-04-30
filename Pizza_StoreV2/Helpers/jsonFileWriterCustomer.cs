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
    public class jsonFileWriterCustomer
    {
        public static void WriteToJson(List<Customer> Customers, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(Customers, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
    }
}
