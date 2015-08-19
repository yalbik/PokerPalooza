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
    public class Repo<T> where T : class 
    {
        SqlConnection Connection;
        string _select;

        public Repo(string connectionString, string select)
        {
            Connection = new SqlConnection(connectionString);
            _select = select;
        }

        public IEnumerable<T> Get(int id)
        {
            return Connection.Query<T>(_select, new { ID = id });
        }

        public void Add(T item)
        {
            Connection.Insert<T>(item);
        }

        public void Update(T item)
        {
            Connection.Update<T>(item);
        }

        public void Delete(T item)
        {
            Connection.Delete<T>(item);
        }

    }
}
