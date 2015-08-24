using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using DapperExtensions;

using pokerpalooza.domain;

namespace pokerpalooza.domain
{
    public class pokerpalooza_repo
    {
        public SqlConnection Connection { get; set; }

        public pokerpalooza_repo(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }

        public IEnumerable<Blind> GetBlindsForBlindSetup(int blindSetupId)
        {
            string query = "SELECT * FROM Blind WHERE BlindSetupID = @SetupID";
            return Connection.Query<Blind>(query, new { SetupID = blindSetupId });
        }

        public void AddBlind(Blind blind)
        {
            Connection.Insert<Blind>(blind);
        }

        public void UpdateBlind(Blind blind)
        {
            Connection.Update<Blind>(blind);
        }

        public void DeleteBlind(Blind blind)
        {
            Connection.Delete<Blind>(blind);
        }

        public IEnumerable<BlindSetup> GetBlindSetups()
        {
            return Connection.Query<BlindSetup>("SELECT * FROM BlindSetup");
        }

        public void AddBlindSetup(BlindSetup b)
        {
            Connection.Insert<BlindSetup>(b);
        }

        public void UpdateBlindSetup(BlindSetup b)
        {
            Connection.Update<BlindSetup>(b);
        }

        public void DeleteBlindSetup(BlindSetup b)
        {
            Connection.Delete<BlindSetup>(b);
        }

        public IEnumerable<Chip> GetChips()
        {
            return Connection.Query<Chip>("SELECT * FROM Chip");
        }

        public void AddChip(Chip b)
        {
            Connection.Insert<Chip>(b);
        }

        public void UpdateChip(Chip b)
        {
            Connection.Update<Chip>(b);
        }

        public void DeleteChip(Chip b)
        {
            Connection.Delete<Chip>(b);
        }

        public IEnumerable<Game> GetGames()
        {
            return Connection.Query<Game>("SELECT * FROM Game");
        }

        public void AddGame(Game b)
        {
            Connection.Insert<Game>(b);
        }

        public void UpdateGame(Game b)
        {
            Connection.Update<Game>(b);
        }

        public void DeleteGame(Game b)
        {
            Connection.Delete<Game>(b);
        }

        public IEnumerable<Player> GetPlayers()
        {
            return Connection.Query<Player>("SELECT * FROM Player");
        }

        public void AddPlayer(Player b)
        {
            Connection.Insert<Player>(b);
        }

        public void UpdatePlayer(Player b)
        {
            Connection.Update<Player>(b);
        }

        public void DeletePlayer(Player b)
        {
            Connection.Delete<Player>(b);
        }
    }
}
