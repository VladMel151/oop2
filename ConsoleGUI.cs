using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Z
{
    public class ConsoleGUI
    {
        public static void InitDialog()
        {
            var input = Console.ReadLine();

            if (input == "/help")
            {
                Console.WriteLine();
                Console.WriteLine("/get To get list of bagets");
                Console.WriteLine("/add_order {Name Of Baget} {Amount} To add order");
                Console.WriteLine("/calculate To check sufficiency");
                Console.WriteLine("/show To show all materials needed for ordering");
                Console.WriteLine();
            }
            else if (input == "/calculate")
            {
                Console.WriteLine();
                Console.WriteLine("------------->" + WorkShop.SufficiencyCheck(WorkShop.SummurizeMaterials()));
                Console.WriteLine();
            }

            else if (input.Contains("/add_order"))
            {
                string[] args = input.Split(new char[] { ' ' });
                WorkShop.AddOrder(args[1], args[2]);
                Console.WriteLine("------------->OK");

            }
            else if (input == "/show")
            {
                Console.WriteLine();

                foreach (Material M in WorkShop.SummurizeMaterials())
                {
                    Console.WriteLine("Name: " + M.Name);
                    Console.WriteLine("Amount: " + M.Amount);
                }
                Console.WriteLine();
            }
            else if (input == "/get")
            {
                WorkShop.LoadBagets();
                List<String> Bagets = WorkShop.GetBagets();
                Console.WriteLine();
                foreach (string BagetName in Bagets)
                {
                    Console.WriteLine("Name: " + BagetName);
                }
                Console.WriteLine();
            }


        }
    }
}
