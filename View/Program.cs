using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    class Program
    {
        static void Main(string[] args)
        {
            MainController GUIMainContoller = new MainController();
            while (true)
            {
                ConsoleGUI.InitDialog(GUIMainContoller);
            }
        }
    }
}
