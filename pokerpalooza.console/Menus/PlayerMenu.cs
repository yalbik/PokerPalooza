﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using pokerpalooza.domain;

namespace pokerpalooza.console.Menus
{
    class PlayerMenu
    {
        public static void MainMenu(GameController Controller, pokerpalooza_repo Repo)
        {
            while (true)
            {
                Console.WriteLine("\n* Player Menu *");
                Console.WriteLine("1. View all stored players");
                Console.WriteLine("2. Add a new player");
                Console.WriteLine("3. Delete a player");
                Console.WriteLine("X. Go Back");
                Console.Write("--> ");

                switch (Console.ReadLine().ToLowerInvariant())
                {
                    case "x":
                        return;
                    case "1":
                        ShowAllPlayers(Repo);
                        break;
                    case "2":
                        AddPlayer(Repo);
                        break;
                    case "3":
                        DeletePlayer(Repo);
                        break;
                    default:
                        Console.WriteLine("You fell off the top of the stupid tree.");
                        continue;
                }
            }
        }

        public static void ShowAllPlayers(pokerpalooza_repo repo)
        {
            List<Player> players = repo.GetPlayers().ToList();

            if (players.Count() == 0)
            {
                Console.WriteLine("There are no players in the database.");
                return;
            }
            foreach (Player p in players)
            {
                Console.WriteLine("{0} {1}", p.FirstName, p.LastName);
                Console.WriteLine("\t\"{0}\"", p.DisplayName);
                Console.WriteLine("\t{0}", p.PhoneNumber);
            }
        }

        public static void ShowAllPlayersJustDisplayNames(pokerpalooza_repo repo)
        {
            List<Player> players = repo.GetPlayers().ToList();
            for (int i = 0; i < players.Count(); i++)
                Console.WriteLine("{0}: {1}", i.ToString(), players[i].DisplayName);
        }

        public static Player AddPlayer(pokerpalooza_repo repo)
        {
            Player player;
            string firstName, lastName, displayName, phone;

            while (true)
            {
                Console.Write("Enter desired display name: ");
                if ((displayName = Console.ReadLine()).Equals(""))
                    Console.WriteLine("A display name is required.");
                else
                    break;
            }

            Console.Write("First Name: ");
            firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            lastName = Console.ReadLine();
            Console.Write("Phone number: ");
            phone = Console.ReadLine();

            player = new Player { DisplayName = displayName, FirstName = firstName, LastName = lastName, PhoneNumber = phone };
            repo.AddPlayer(player);

            return player;
        }

        public static void DeletePlayer(pokerpalooza_repo repo)
        {
            while (true)
            {
                Console.WriteLine("Choose player to delete:");
                ShowAllPlayersJustDisplayNames(repo);
                Console.WriteLine("X. Go Back");
                Console.Write("--> ");

                string input = Console.ReadLine().ToLowerInvariant();
                if (input.Equals("x"))
                    return;

                try
                {
                    repo.DeletePlayer(repo.GetPlayers().ToList()[int.Parse(input)]);
                    Console.WriteLine("Player deleted.");
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Could not process request.");
                }
            }
        }
    }
}
