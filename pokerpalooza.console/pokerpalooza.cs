using System;
using System.Collections.Generic;
using System.Configuration;
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
        pokerpalooza_repo Repo;
        DatabaseCreator Creator;

        public pokerpalooza()
        {
            Creator = new DatabaseCreator(ConfigurationManager.ConnectionStrings["pokerpalooza-db"].ConnectionString);
            Creator.OverwriteExisting = true;

            Repo = new pokerpalooza_repo(ConfigurationManager.ConnectionStrings["pokerpalooza-db"].ConnectionString);
            Controller = new GameController(Repo);

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
                Console.WriteLine("3. Database Maintenence Menu");
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
                        PlayerMenu.MainMenu(Controller, Repo);
                        break;
                    case "3":
                        DatabaseMenu.MainMenu(Creator);
                        break;
                    default:
                        Console.WriteLine("You straight trippin'");
                        continue; ;
                }
            }
        }

        public static void Main(String[] args)
        {
            new pokerpalooza();
        }
    }
}
