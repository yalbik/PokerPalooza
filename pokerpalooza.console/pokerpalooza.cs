using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using pokerpalooza.domain;

namespace pokerpalooza.console
{
    class pokerpalooza
    {
        GameController Controller;

        public pokerpalooza()
        {
            DatabaseCreator.CreateDatabase creator = new DatabaseCreator.CreateDatabase(@"(LocalDB)\MSSQLLocalDB");
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
                        GameMenu();
                        break;
                    case "2":
                        Console.WriteLine("not implemented.");
                        break;
                    default:
                        Console.WriteLine("You straight trippin'");
                        break;
                }
            }
        }

        public void GameMenu()
        {
            while (true)
            {
                Console.WriteLine("\n** Game menu **");
                Console.WriteLine("1. Show current game status");
                Console.WriteLine("2. Create a New Game");
                Console.WriteLine("X. Go back");
                Console.Write("--> ");

                switch(Console.ReadLine().ToLowerInvariant())
                {
                    case "x":
                        return;
                    case "1":
                        Helper.ShowGame(Controller.ActiveGame);
                        break;
                    case "2":
                        NewGame();
                        break; 
                    default:
                        Console.WriteLine("what the fuck?");
                        break;
                }
            }
        }

        public void NewGame()
        {
            int buyin, bounty;
            DateTime gameDate;

            while (true)
            {
                Console.Write("Enter game date: ");
                try
                {
                    gameDate = DateTime.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Jesus Christ, enter a fucking date.");
                    continue;
                }
                break;
            }

            gameDate = gameDate.AddHours(19);

            while (true)
            {
                Console.Write("Enter Buyin: ");
                try
                {
                    buyin = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Are you tarded?");
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.Write("Enter Bounty (default 0): ");
                string input = Console.ReadLine();

                try
                {
                    bounty = input.Equals("") ? 0 : int.Parse(input);
                }
                catch (Exception)
                {
                    Console.WriteLine("I said bounty fucktwat");
                    continue;
                }
                break;
            }

            Controller.NewGame(gameDate, buyin, bounty == 0 ? (int?)null : bounty, null);
        }

        public static void Main(String[] args)
        {
            new pokerpalooza();
        }
    }
}
