using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using DapperExtensions;

using pokerpalooza.domain.Models;

namespace pokerpalooza.domain.Repo
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
    }
}
