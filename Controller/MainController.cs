using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class MainController
    {
        public bool Calculate()
        {
           return Manufacturing.SufficiencyCheck(Manufacturing.SummurizeMaterials());
        }
        public bool AddOrder(string Input)
        {
            string[] args = Input.Split(new char[] { ' ' });

            Manufacturing.AddOrder(args[1], args[2]);

            return true;
        }

        public Dictionary<string,int> Show()
        {
            Dictionary<string, int> Materials = new Dictionary<string, int>();
            foreach (Material M in Manufacturing.SummurizeMaterials())
            {
                Materials.Add(M.Name, M.Amount);
            }
            return Materials;
        }

        public List<string> Get()
        {
            return Manufacturing.GetBagets();
        }
        public void LoadBagets()
        {
            Manufacturing.LoadBagets();
        }
    }
}
