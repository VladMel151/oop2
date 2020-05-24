using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace DataAccessLayer
{
    public class Loader
    {
        static string path = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static List<T> LoadFromJson<T>()
        {
           List<T> _List = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
           return _List;
        }
    }
}
