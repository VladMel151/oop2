using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class ConsoleGUI
    {
        public static void InitDialog(MainController Controller)
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
                Console.WriteLine(Controller.Calculate());
                Console.WriteLine();
            }

            else if (input.Contains("add"))
            {
                try
                {
                    if (Controller.AddOrder(input))
                    {
                        Console.WriteLine("------------->OK");
                    }
                }
                catch
                {
                    Console.WriteLine("------------->BAD");
                }


            }
            else if (input == "show")
            {
                Console.WriteLine();
                foreach (KeyValuePair<string, int> Pair in Controller.Show())
                {
                    Console.Write("Name: ");
                    Console.WriteLine(Pair.Key);
                    Console.Write("Int: ");
                    Console.WriteLine(Pair.Value.ToString());
                }
                Console.WriteLine();
            }
            else if (input == "get")
            {
                Console.WriteLine();

                foreach (string BagetName in Controller.Get())
                {
                    Console.WriteLine("Name: " + BagetName);
                }
                Console.WriteLine();
            }
            else if (input == "load")
            {
                Controller.LoadBagets();
                Console.WriteLine("------------->OK");
            }


        }
    }
}
