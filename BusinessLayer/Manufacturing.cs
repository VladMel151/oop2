using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class Manufacturing
    {
        public static List<Order> Orders = new List<Order>();
        public static List<Baget> Bagets = new List<Baget>();
        public static List<Material> StoredMaterials = new List<Material>();

        public static void LoadBagets()
        {

           List<Baget> BagetsJson = Loader.LoadFromJson<Baget>();

            foreach (Baget B in BagetsJson)
            {
                Manufacturing.Bagets.Add(B);
            }

        }
        public static List<String> GetBagets()
        {
            List<String> Bagets = new List<String>();

            foreach (Baget B in Manufacturing.Bagets)
            {
                Bagets.Add(B.Name);
            }
            return Bagets;
        }
        public static void AddOrder(string BagetName, string Amount)
        {
            foreach (Baget B in Manufacturing.Bagets)
            {
                if (B.Name == BagetName)
                {
                    Order Order_N = new Order();
                    Order_N.Baget = B;
                    Order_N.Amount = Int32.Parse(Amount);

                    Manufacturing.Orders.Add(Order_N);

                    break;
                }
            }
        }

        public static List<Material> SummurizeMaterials()
        {
            List<Material> SummurizedMaterials = new List<Material>();

            foreach(Order O in Orders)
            {
                foreach(Material M in O.Baget.Materials)
                {
                    if(!NameInSummurizedMaterials(M.Name, SummurizedMaterials))
                    {
                        Material Material_N = new Material();
                        Material_N.Name = M.Name;
                        Material_N.Amount = 0;
                        SummurizedMaterials.Add(Material_N);
                    }

                    foreach(Material SumM in SummurizedMaterials)
                    {
                        if (SumM.Name == M.Name)
                        {
                            SumM.Amount += O.Amount * M.Amount;
                        }
                    }
                }
            }
            return SummurizedMaterials;
        }

        static bool NameInSummurizedMaterials(string Name, List<Material> Materials)
        {
            foreach(Material M in Materials)
            {
                if (Name == M.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool SufficiencyCheck(List<Material> SummurizedMaterials)
        {
            foreach(Material SumM in SummurizedMaterials)
            {
                foreach(Material StoredM in StoredMaterials)
                {
                    if (SumM.Amount > StoredM.Amount)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
