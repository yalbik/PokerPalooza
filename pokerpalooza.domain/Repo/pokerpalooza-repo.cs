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

        public void InsertBlind(Blind blind)
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
    }
}
