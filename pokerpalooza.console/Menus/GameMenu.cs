using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using pokerpalooza.domain;
using pokerpalooza.domain.Models;

namespace pokerpalooza.console.Menus
{
    public static class GameMenu
    {
        public static void MainMenu(GameController Controller)
        {
            while (true)
            {
                Console.WriteLine("\n** Game menu **");
                Console.WriteLine("1. Show current game status");
                Console.WriteLine("2. Create a New Game");
                Console.WriteLine("3. Add player to current game");
                Console.WriteLine("X. Go back");
                Console.Write("--> ");

                switch (Console.ReadLine().ToLowerInvariant())
                {
                    case "x":
                        return;
                    case "1":
                        Helper.ShowGame(Controller.ActiveGame);
                        break;
                    case "2":
                        NewGame(Controller);
                        break;
                    default:
                        Console.WriteLine("what the fuck?");
                        continue;
                }
            }
        }

        public static void NewGame(GameController Controller)
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

        static void AddPlayerToCurrentGame(GameController controller)
        {
            List<Player> availablePlayers = controller.AvailablePlayersForGame().ToList();

            if (controller.AvailablePlayersForGame().Count() == 0)
            {
                Console.WriteLine("There are no available players for the current game.");
                return;
            }

            while (true)
            {
                Console.WriteLine("\nSelect player to add to current game:");
                for (int i = 0; i < availablePlayers.Count(); i++)
                    Console.WriteLine("{0}: {1}", i.ToString(), availablePlayers[i].DisplayName);

                try
                {
                    controller.AddPlayer(availablePlayers[int.Parse(Console.ReadLine())]);
                    Console.WriteLine("{0} was added to the current game.");
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("ENGLISH MOTHERFUCKER YOU SPEAK IT");
                }
            }
        }
    }
}
