using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using pokerpalooza.domain;

namespace pokerpalooza.console.Menus
{
    class PlayerMenu
    {
        public static void MainMenu(GameController Controller)
        {
            while (true)
            {
                Console.WriteLine("\n* Player Menu *");
                Console.WriteLine("X. Go Back");
                Console.Write("--> ");

                switch (Console.ReadLine().ToLowerInvariant())
                {
                    case "x":
                        return;
                    default:
                        Console.WriteLine("You fell off the top of the stupid tree.");
                        continue;
                }
            }
        }
    }
}
