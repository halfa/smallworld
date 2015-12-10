using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallWorld.Core;

namespace SmallWorld.utest
{
    [TestClass]
    public class UnitTestSaveLoad
    {
        [TestMethod]
        public void TestSaveLoad()
        {
            // Removing the saves directory and its content at the begining of the test. //
            if (System.IO.Directory.Exists(".\\Saves"))
                System.IO.Directory.Delete(".\\Saves", true);

            GameSettings GS = new GameSettings();
            GS.mapType = MapType.Demo;
            GS.setFieldsAccordingToMapType();
            GS.playersNames.Add("Player1");
            GS.playersRaces.Add(Races.Human);
            GS.playersNames.Add("Player2");
            GS.playersRaces.Add(Races.Human);

            GameMaster GM = new GameMaster();
            GM.newGame(GS);

            Assert.IsFalse(System.IO.Directory.Exists(".\\Saves"));
            GM.loadGame("save01");
            Assert.IsTrue(GM.loadManager.game == null);

            GM.saveGame("save01");
            Assert.IsTrue(System.IO.Directory.Exists(".\\Saves"));
            Assert.IsTrue(System.IO.File.Exists(".\\Saves\\save01.xml"));

            Assert.AreEqual(GM.game.previousGameStates.Count, 0);
            GM.game.stack();
            Assert.AreEqual(GM.game.previousGameStates.Count, 1);
            GM.saveGame("save02");

            GM.loadGame("save01");
            Assert.AreEqual(GM.game.previousGameStates.Count, 0);

            GM.loadGame("save02");
            Assert.AreEqual(GM.game.previousGameStates.Count, 1);

            // Removing the saves directory and its content at the end of the test. //
            //if (System.IO.Directory.Exists(".\\Saves"))
            //    System.IO.Directory.Delete(".\\Saves", true);
        }
    }
}
