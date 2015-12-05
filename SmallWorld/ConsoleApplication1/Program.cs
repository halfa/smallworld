using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallWorld.Core;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            GameSettings GS = new GameSettings();
            GS.mapType = MapType.Demo;
            GS.setFieldsAccordingToMapType();
            GS.playersNames.Add("Player1");
            GS.playersRaces.Add(Races.Human);
            GS.playersNames.Add("Player2");
            GS.playersRaces.Add(Races.Human);

            GameMaster GM = new GameMaster();
            GM.newGame(GS);

            GM.loadGame("save01");
            System.Console.WriteLine(GM.game.previousGameStates.Count);
            GM.saveGame("save01");

            GM.game.stack();
            System.Console.WriteLine(GM.game.previousGameStates.Count);
            GM.saveGame("save02");

            GM.loadGame("save01");
            System.Console.WriteLine(GM.game.previousGameStates.Count);

            System.Console.WriteLine("success??");
            System.Console.Read();
        }
    }
}
