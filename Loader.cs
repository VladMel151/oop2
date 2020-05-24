using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;

namespace Project_Z
{
    public class Loader
    {
        public static List<Baget> LoadBagetsFromJson()
        {
            string path = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            List<Baget> BagetsJson = JsonConvert.DeserializeObject<List<Baget>>(File.ReadAllText(path));

            return BagetsJson;
        }
    }
}
