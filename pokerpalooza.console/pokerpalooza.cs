using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using pokerpalooza.console.GameController;

namespace pokerpalooza.console
{
    class pokerpalooza
    {
        GameController.GameController Controller;

        public pokerpalooza()
        {
            DatabaseCreator.CreateDatabase creator = new DatabaseCreator.CreateDatabase(@"(LocalDB)\MSSQLLocalDB");
            creator.OverwriteExisting = true;

            Controller = new GameController.GameController();

            menu();
        }

        void menu()
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to PokerPalooza, starring Skinz");
                Console.WriteLine("1. View current game state");
                Console.WriteLine("Q. Quit this program");
                Console.Write("--> ");

                switch (Console.ReadLine().ToLowerInvariant())
                {
                    case "q":
                        return;
                    case "1":
                        Helper.ShowGame(Controller.ActiveGame);
                        Console.ReadLine();
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
