using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using NUnit.Framework;

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
        public void Schema_DatabaseExists()
        {
            Assert.IsNotNull(db.CreateDate);
        }

        [Test]
        public void Schema_TableBlindExists()
        {
            Assert.IsNotNull(db.Tables["Blind"]);
        }

        [Test]
        public void Schema_TableBlindSetupExists()
        {
            Assert.IsNotNull(db.Tables["BlindSetup"]);
        }

        [Test]
        public void Schema_TableChipExists()
        {
            Assert.IsNotNull(db.Tables["Chip"]);
        }

        [Test]
        public void Schema_TableGameExists()
        {
            Assert.IsNotNull(db.Tables["Game"]);
        }

        [Test]
        public void Schema_TablePlayerExists()
        {
            Assert.IsNotNull(db.Tables["Player"]);
        }
    }
}
