using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using pokerpalooza.domain;

namespace pokerpalooza.console.Menus
{
    public static class DatabaseMenu
    {
        public static void MainMenu(DatabaseCreator creator)
        {
            while (true)
            {
                Console.WriteLine("* Database Maintenence *");
                Console.WriteLine("* DBCreator Overwrite Property is {0}", creator.OverwriteExisting.ToString());
                Console.WriteLine("1. Set DBCreator Overwrite Property to TRUE");
                Console.WriteLine("2. Set DBCreator Overwrite Property to FALSE");
                Console.WriteLine("3. Create/update DB schema");
                Console.WriteLine("X. Go Back");
                Console.Write("--> ");

                switch (Console.ReadLine().ToLowerInvariant())
                {
                    case "1":
                        creator.OverwriteExisting = true;
                        break;
                    case "2":
                        creator.OverwriteExisting = false;
                        break;
                    case "3":
                        creator.CreatePokerPalooza();
                        break;
                    case "x":
                        return;
                    default:
                        Console.WriteLine("gall darn you're a stupid fuck aintcha");
                        continue;
                }
            }
        }
    }
}
