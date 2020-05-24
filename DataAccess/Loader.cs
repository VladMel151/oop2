using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace DataAccess
{
    public class Loader
    {
        public List<T> LoadFromJson<T>()
        {
            var path = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //var path = @"C:\Users\admin\Desktop\z\Bagets.json";
            List<T> _List = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
            return _List;
        }
    }
}
