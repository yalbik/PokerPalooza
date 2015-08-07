using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using pokerpalooza.domain.Repo;
using pokerpalooza.domain.Models;

namespace pokerpalooza.tests.repo
{
    [TestFixture]
    public class repotests
    {
        pokerpalooza_repo repo;

        [TestFixtureSetUp]
        public void SetShitUp()
        {
            repo = new pokerpalooza_repo(ConfigurationManager.ConnectionStrings["pokerpalooza-db"].ToString());
        }

        [Test]
        public void CanGetARepo()
        {
            Assert.IsNotNull(repo);
        }

        [Test]
        public void Crud_Blind()
        {
            Blind blind = new Blind()
            {
                ID = 0,
                BlindSetupID = 9999,
                BlindLevel = 100,
                Interval = new TimeSpan(0, 20, 0)
            };

            repo.InsertBlind(blind);
        }
    }
}
