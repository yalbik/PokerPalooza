using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using pokerpalooza.domain.Models;

namespace pokerpalooza.domain
{
    public static class Helper
    {
        public static void ShowGame(Game game)
        {
            if (game == null)
            {
                Console.WriteLine("No game to display.");
                return;
            }

            Console.WriteLine("Game Date: {0}", game.GameTime.ToShortDateString());
            Console.WriteLine("Game Time: {0}", game.GameTime.ToShortTimeString());
            Console.WriteLine("Buyin: {0}", game.Buyin.ToString());
            Console.WriteLine("Bounty: {0}", game.Bounty == null ? "None" : game.Bounty.ToString());
            Console.WriteLine("Players: {0}", game.Players.Count().ToString());
            foreach (GamePlayer p in game.Players)
                Console.WriteLine(p.Player.DisplayName);
        }
    }
}
