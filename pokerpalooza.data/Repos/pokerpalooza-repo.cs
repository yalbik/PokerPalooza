using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using DapperExtensions;

using pokerpalooza.domain.Models;

namespace pokerpalooza.data.Repos
{
    public class pokerpalooza_repo
    {
        public SqlConnection _con { get; set; }
        
        public pokerpalooza_repo(SqlConnection con)
        {
            _con = con;
        }

        public void Save<T>(IEnumerable<T> obj)
        {
            //_con.Insert<T>(obj);
        }
    }
}
