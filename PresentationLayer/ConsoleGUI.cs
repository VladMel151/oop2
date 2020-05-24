using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace PresentationLayer
{
    public class ConsoleGUI
    {
        public static void InitDialog()
        {
            var input = Console.ReadLine();

            if (input == "help")
            {
                Console.WriteLine();
                Console.WriteLine("Enter 'load' To load bagets");
                Console.WriteLine("Enter 'get' To get list of bagets");
                Console.WriteLine("Enter 'add' To add order {Name Of Baget} {Amount} To add order");
                Console.WriteLine("Enter 'calculate' To check sufficiency");
                Console.WriteLine("Enter 'show' To show all materials needed for ordering");
                Console.WriteLine();
            }
            else if (input == "calculate")
            {
                Console.WriteLine();
                Console.WriteLine("------------->" + Manufacturing.SufficiencyCheck(Manufacturing.SummurizeMaterials()));
                Console.WriteLine();
            }

            else if (input.Contains("add"))
            {
                string[] args = input.Split(new char[] { ' ' });
                Manufacturing.AddOrder(args[1], args[2]);
                Console.WriteLine("------------->OK");

            }
            else if (input == "show")
            {
                Console.WriteLine();

                foreach (Material M in Manufacturing.SummurizeMaterials())
                {
                    Console.WriteLine("Name: " + M.Name);
                    Console.WriteLine("Amount: " + M.Amount);
                }
                Console.WriteLine();
            }
            else if (input == "get")
            {
                List<String> Bagets = Manufacturing.GetBagets();
                Console.WriteLine();
                foreach (string BagetName in Bagets)
                {
                    Console.WriteLine("Name: " + BagetName);
                }
                Console.WriteLine(); Manufacturing.LoadBagets();
            }
            else if (input == "load")
            {
                Manufacturing.LoadBagets();
                Console.WriteLine("------------->OK");
            }


        }
    }
}
