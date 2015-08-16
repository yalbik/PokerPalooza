using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SqlServer.Management.Smo;
using NUnit.Framework;
using Microsoft.SqlServer.Management.Common;

namespace pokerpalooza.tests.schema
{
    [TestFixture]
    public class schematests
    {
        Server server;
        Database db;

        [TestFixtureSetUp]
        public void SetShitUp()
        {
            ServerConnection con = new ServerConnection(@"(LocalDB)\MSSQLLocalDB");
            server = new Server(con);
            db = server.Databases["PokerPalooza"];
        }

        [Test]
        public void DatabaseExists()
        {
            Assert.IsNotNull(db.CreateDate);
        }

        [Test]
        public void TableBlindExists()
        {
            Assert.IsNotNull(db.Tables["Blind"]);
        }

        [Test]
        public void TableBlindSetupExists()
        {
            Assert.IsNotNull(db.Tables["BlindSetup"]);
        }

        [Test]
        public void TableChipExists()
        {
            Assert.IsNotNull(db.Tables["Chip"]);
        }

        [Test]
        public void TableGameExists()
        {
            Assert.IsNotNull(db.Tables["Game"]);
        }

        [Test]
        public void TablePlayerExists()
        {
            Assert.IsNotNull(db.Tables["Player"]);
        }
    }
}
