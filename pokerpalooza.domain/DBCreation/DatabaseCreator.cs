using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace pokerpalooza.domain
{
    public class DatabaseCreator
    {
        public Boolean OverwriteExisting { get; set; }

        Server Srv;

        Database PokerPalooza { get; set; }

        public DatabaseCreator(string connectionString)
        {
            OverwriteExisting = false;

            Srv = new Server(
                new ServerConnection(
                    new SqlConnection(connectionString)));

            PokerPalooza = Srv.Databases["PokerPalooza"];
        }

        public void CreatePokerPalooza()
        {
            CreatePokerpaloozaDatabase();
            CreatePokerPaloozaTables();
            Console.WriteLine("PokerPalooza schema created.");
        }

        public void CreatePokerpaloozaDatabase()
        {
            // TODO: get this to work. Presently you gotta create the MS LocalDB by hand. I can't get SMO to do it. 
        }

        public void CreatePokerPaloozaTables()
        {
            CreateTableBlindSetup();
            CreateTableBlind();
            CreateTableChip();
            CreateTableGame();
            CreateTablePlayer();
        }

        public void CreateTableBlind()
        {
            PrepareForTableCreation("Blind");
            Table Blind = new Table(PokerPalooza, "Blind");

            Blind.Columns.Add(new Column(Blind, "ID", DataType.Int));
            Blind.Columns["ID"].Identity = true;

            Blind.Columns.Add(new Column(Blind, "BlindSetupId", DataType.Int));
            Blind.Columns.Add(new Column(Blind, "Interval", DataType.Int));
            Blind.Columns.Add(new Column(Blind, "BlindLevel", DataType.Int));

            PokerPalooza.Tables.Add(Blind);
            Blind.Create();
        }

        public void CreateTableBlindSetup()
        {
            PrepareForTableCreation("BlindSetup");
            Table BlindSetup = new Table(PokerPalooza, "BlindSetup");

            BlindSetup.Columns.Add(new Column(BlindSetup, "ID", DataType.Int));
            BlindSetup.Columns["ID"].Identity = true;

            BlindSetup.Columns.Add(new Column(BlindSetup, "Name", DataType.VarChar(256)));

            PokerPalooza.Tables.Add(BlindSetup);
            BlindSetup.Create();
        }

        public void CreateTableChip()
        {
            PrepareForTableCreation("Chip");
            Table Chip = new Table(PokerPalooza, "Chip");

            Chip.Columns.Add(new Column(Chip, "ID", DataType.Int));
            Chip.Columns["ID"].Identity = true;

            Chip.Columns.Add(new Column(Chip, "Color", DataType.VarChar(16)));
            Chip.Columns.Add(new Column(Chip, "Value", DataType.Int));

            PokerPalooza.Tables.Add(Chip);
            Chip.Create();
        }

        public void CreateTableGame()
        {
            PrepareForTableCreation("Game");
            Table Game = new Table(PokerPalooza, "Game");

            Game.Columns.Add(new Column(Game, "ID", DataType.Int));
            Game.Columns["ID"].Identity = true;

            Game.Columns.Add(new Column(Game, "GameTime", DataType.DateTime));
            Game.Columns.Add(new Column(Game, "Buyin", DataType.Int));
            Game.Columns.Add(new Column(Game, "Bounty", DataType.Int));

            PokerPalooza.Tables.Add(Game);
            Game.Create();
        }

        public void CreateTablePlayer()
        {
            PrepareForTableCreation("Player");
            Table Player = new Table(PokerPalooza, "Player");

            Player.Columns.Add(new Column(Player, "ID", DataType.Int));
            Player.Columns["ID"].Identity = true;

            Player.Columns.Add(new Column(Player, "DisplayName", DataType.VarChar(128)));
            Player.Columns.Add(new Column(Player, "FirstName", DataType.VarChar(128)));
            Player.Columns.Add(new Column(Player, "LastName", DataType.VarChar(128)));
            Player.Columns.Add(new Column(Player, "PhoneNumber", DataType.VarChar(16)));

            PokerPalooza.Tables.Add(Player);
            Player.Create();
        }

        private void PrepareForTableCreation(string table)
        {
            if (PokerPalooza.Tables == null)
                return;
            if (PokerPalooza.Tables.Contains(table))
            {
                if (!OverwriteExisting)
                    throw new Exception("PokerPalooza contains the table " + table + " and OverwriteExisting is set to false");
                PokerPalooza.Tables[table].Drop();
            }
        }
    }
}
