using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using pokerpalooza.domain.Models;

namespace pokerpalooza.domain
{
    public class GameController
    {
        public Game ActiveGame { get; set; }
        public pokerpalooza_repo Repo { get; set; }

        public GameController(pokerpalooza_repo repo)
        {
            Repo = repo;
        } 

        public void NewGame(DateTime date, int buyin, int? bounty, IEnumerable<Player> players)
        {
            ActiveGame = new Game { GameTime = date, Buyin = buyin, Bounty = bounty, Players = new List<GamePlayer>() };

            if (players != null)
                foreach (Player p in players)
                    ActiveGame.Players.Add(new GamePlayer { Player = p, Game = ActiveGame });
        }

        public void AddPlayer(Player player)
        {
            ActiveGame.Players.Add(new GamePlayer { Game = ActiveGame, Player = player });
        }

        public IEnumerable<Player> AvailablePlayersForGame()
        {
            List<Player> availablePlayers = new List<Player>();

            foreach (Player player in Repo.GetPlayers())
                if (!ActiveGame.Players.Contains(new GamePlayer { Game = ActiveGame, Player = player }))
                    availablePlayers.Add(player);

            return availablePlayers;
        }

    }
}
