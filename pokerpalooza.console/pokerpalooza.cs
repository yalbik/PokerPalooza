using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokerpalooza.console
{
    class pokerpalooza
    {
        public pokerpalooza()
        {
            DatabaseCreator.CreateDatabase creator = new DatabaseCreator.CreateDatabase(@"(LocalDB)\MSSQLLocalDB");
            creator.OverwriteExisting = true;

            creator.CreatePokerpaloozaDatabase();
        }

        public static void Main(String[] args)
        {
            new pokerpalooza();
        }
    }
}
