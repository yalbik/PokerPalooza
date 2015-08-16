using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SqlServer.Management.Smo;

namespace pokerpalooza.console.DatabaseCreator
{
    public class CreateDatabase
    {
        public Boolean OverwriteExisting { get; set; }

        Server Srv;

        Database PokerPalooza { get; set; }

        Table Blind { get; set; }
        Table BlindSetup { get; set; }

        public CreateDatabase(string serverName)
        {
            OverwriteExisting = false;
            Srv = new Server(serverName);
            Console.WriteLine("SMO created server with version {0}", Srv.Version);
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
            Blind.Create();
        }

        public void CreateTableBlindSetup()
        {
            PrepareForTableCreation("BlindSetup");
            Table BlindSetup = new Table(PokerPalooza, "BlindSetup");

            BlindSetup.Columns.Add(new Column(BlindSetup, "ID", DataType.Int));
            BlindSetup.Columns["ID"].Identity = true;

            BlindSetup.Columns.Add(new Column(BlindSetup, "Name", DataType.VarChar(256)));
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
