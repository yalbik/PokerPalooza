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

        Table Blind { get; set; }
        Table BlindSetup { get; set; }

        public DatabaseCreator(string serverName)
        {
            OverwriteExisting = false;
            SqlConnection sqlCon = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB;AttachDbFileName=C:\codez\pokerpalooza\pokerpalooza.domain\pokerpalooza.mdf;Integrated Security=true");
            ServerConnection connection = new ServerConnection(sqlCon);
            Srv = new Server(connection);

            PokerPalooza = Srv.Databases["PokerPalooza"];
        }

        public void CreatePokerPalooza()
        {
            CreatePokerpaloozaDatabase();
        }

        public void CreatePokerpaloozaDatabase()
        {
            if (Srv.Databases.Contains("PokerPalooza"))
            {
                if (!OverwriteExisting)
                    throw new Exception("PokerPalooza database already exists and OverwriteExisting is set to false.");
                Srv.Databases["PokerPalooza"].Drop();
            }

            PokerPalooza = new Database(Srv, "PokerPalooza");
            PokerPalooza.Create();

            CreateTableBlindSetup();
            CreateTableBlind();
            CreateTableChip();
            CreateTableGame();
            CreateTablePlayer();
        }

        public void CreateTable(string name, List<Column> columns)
        {
            if (PokerPalooza.Tables.Contains(name))
            {
                if (!OverwriteExisting)
                    throw new Exception("PokerPalooza contrains the table " + name + " and OverwriteExisting is set to false.");
                PokerPalooza.Tables[name].Drop();
            }
            Table table = new Table(PokerPalooza, name);
            foreach (Column col in columns)
                table.Columns.Add(col);
            table.Create();
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
            Player.Columns.Add(new Column(Player, "Phone", DataType.VarChar(16)));

            PokerPalooza.Tables.Add(Player);
            Player.Create();
        }


        private void PrepareForTableCreation(string table)
        {
            if (PokerPalooza.Tables.Contains(table))
            {
                if (!OverwriteExisting)
                    throw new Exception("PokerPalooza contains the table " + table + " and OverwriteExisting is set to false");
                PokerPalooza.Tables[table].Drop();
            }
        }
    }
}
