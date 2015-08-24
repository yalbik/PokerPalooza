using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using pokerpalooza.domain;

namespace pokerpalooza.tests.GameControllerTests
{
    [TestFixture]
    class GameControllerTests
    {
        pokerpalooza_repo Repo;
        GameController Controller;

        [TestFixtureSetUp]
        public void SetUpAllTheThings()
        {
            Repo = new pokerpalooza_repo(ConfigurationManager.ConnectionStrings["pokerpalooza-db"].ConnectionString);
            Controller = new GameController(Repo);
            Controller.NewGame(DateTime.Now, 10, null, null);
        }

        [Test]
        public void GameController_CanCreateNewGame()
        {
            Assert.IsNotNull(Controller.ActiveGame);
        }

        [Test]
        public void GameController_CanGetAvailablePlayers()
        {
            Player testPlayer = new Player { DisplayName = "TestPlayer" };

            foreach (Player p in Repo.GetPlayers().Where(
                    x => x.DisplayName.Equals(testPlayer.DisplayName)))
                Repo.DeletePlayer(p);
            Repo.AddPlayer(testPlayer);

            Assert.AreEqual(1, Controller.AvailablePlayersForGame().Where(
                x => x.DisplayName.Equals(testPlayer.DisplayName))
                    .Count());
            Repo.DeletePlayer(testPlayer);
        }

        [Test]
        public void GameController_CanAddPlayerToGame()
        {
            Player testPlayer = new Player { DisplayName = "TestPlayer1" };

            Controller.AddPlayer(testPlayer);
            Assert.AreEqual(1, Controller.ActiveGame.Players.Where(
                x => x.Player.DisplayName.Equals(testPlayer.DisplayName))
                    .Count());
        }
    }
}
