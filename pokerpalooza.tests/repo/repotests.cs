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

            foreach (Blind b in repo.GetBlindsForBlindSetup(9999))
                repo.DeleteBlind(b);
            Assert.AreEqual(0, repo.GetBlindsForBlindSetup(9999).Count());

            repo.AddBlind(blind);
            Assert.AreEqual(1, repo.GetBlindsForBlindSetup(9999).Count());

            blind.BlindLevel = 101;
            repo.UpdateBlind(blind);
            Assert.AreEqual(101, repo.GetBlindsForBlindSetup(9999).FirstOrDefault().BlindLevel);

            repo.DeleteBlind(blind);
            Assert.AreEqual(0, repo.GetBlindsForBlindSetup(9999).Count());
        }

        [Test]
        public void Crud_BlindSetup()
        {
            string testName = "ScooterTest123";
            string testName2 = "ScooterTest321";

            BlindSetup setup = new BlindSetup()
            {
                Name = testName
            };

            foreach (BlindSetup s in repo.GetBlindSetups().Where(x
                    => x.Name.Equals(testName)
                    || x.Name.Equals(testName2)))
                repo.DeleteBlindSetup(s);
            Assert.AreEqual(0, repo.GetBlindSetups().Where(x => x.Name.Equals(testName)).Count());

            repo.AddBlindSetup(setup);
            Assert.AreEqual(1, repo.GetBlindSetups().Where(x => x.Name.Equals(testName)).Count());

            setup.Name = testName2;
            repo.UpdateBlindSetup(setup);
            Assert.AreEqual(1, repo.GetBlindSetups().Where(x => x.Name.Equals(testName2)).Count());
            Assert.AreEqual(0, repo.GetBlindSetups().Where(x => x.Name.Equals(testName)).Count());

            repo.DeleteBlindSetup(setup);
            Assert.AreEqual(0, repo.GetBlindSetups().Where(x => x.Name.Equals(testName2)).Count());
        }
    }
}
