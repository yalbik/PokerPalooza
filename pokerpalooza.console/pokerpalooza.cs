using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using pokerpalooza.domain;
using pokerpalooza.console.Menus;

namespace pokerpalooza.console
{
    class pokerpalooza
    {
        GameController Controller;

        public pokerpalooza()
        {
            DatabaseCreator creator = new DatabaseCreator(@"(LocalDB)\MSSQLLocalDB");
            creator.OverwriteExisting = true;

            Controller = new GameController();

            menu();
        }

        void menu()
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to PokerPalooza, starring Skinz");
                Console.WriteLine("** Main Menu **");
                Console.WriteLine("1. Game Menu");
                Console.WriteLine("2. Player Menu");
                Console.WriteLine("Q. Quit this program");
                Console.Write("--> ");

                switch (Console.ReadLine().ToLowerInvariant())
                {
                    case "q":
                        return;
                    case "1":
                        GameMenu.MainMenu(Controller);
                        break;
                    case "2":
                        PlayerMenu.MainMenu(Controller);
                        break;
                    default:
                        Console.WriteLine("You straight trippin'");
                        break;
                }
            }
        }

        public static void Main(String[] args)
        {
            new pokerpalooza();
        }
    }
}
