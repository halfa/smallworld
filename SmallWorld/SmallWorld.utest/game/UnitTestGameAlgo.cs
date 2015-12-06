using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallWorld.Core;
using System.Collections.Generic;

namespace SmallWorld.utest
{
    [TestClass]
    public class UnitTestGameAlgo
    {
        [TestMethod]
        public void TestSuggestedMoves()
        {
            GameSettings GS = new GameSettings();
            GS.mapType = MapType.Demo;
            GS.setFieldsAccordingToMapType();
            GS.playersNames.Add("Player1");
            GS.playersRaces.Add(Races.Elf);
            GS.playersNames.Add("Player2");
            GS.playersRaces.Add(Races.Orc);

            Assert.IsTrue(GS.areValid());

            GameBuilder gameBuilder = new GameBuilder(GS);
            Game game = gameBuilder.build();

            Assert.IsTrue(game.running);

            // Setup a custom map for testing purposes. //
            Map customMap = new Map(MapType.Demo);
            customMap.setupMap();

            TileFactory factory = TileFactory.INSTANCE;
            List<ATile> customTiles = new List<ATile>()
            {   factory.createTile(TileType.Forest), factory.createTile(TileType.Forest), factory.createTile(TileType.Forest), factory.createTile(TileType.Plain), factory.createTile(TileType.Plain), factory.createTile(TileType.Plain),
                factory.createTile(TileType.Forest), factory.createTile(TileType.Forest), factory.createTile(TileType.Water), factory.createTile(TileType.Plain), factory.createTile(TileType.Plain), factory.createTile(TileType.Plain),
                factory.createTile(TileType.Forest), factory.createTile(TileType.Forest), factory.createTile(TileType.Water), factory.createTile(TileType.Plain), factory.createTile(TileType.Plain), factory.createTile(TileType.Plain),
                factory.createTile(TileType.Forest), factory.createTile(TileType.Water), factory.createTile(TileType.Water), factory.createTile(TileType.Plain), factory.createTile(TileType.Plain), factory.createTile(TileType.Plain),
                factory.createTile(TileType.Forest), factory.createTile(TileType.Forest), factory.createTile(TileType.Forest), factory.createTile(TileType.Forest), factory.createTile(TileType.Forest), factory.createTile(TileType.Forest),
                factory.createTile(TileType.Forest), factory.createTile(TileType.Forest), factory.createTile(TileType.Forest), factory.createTile(TileType.Forest), factory.createTile(TileType.Forest), factory.createTile(TileType.Forest),
            };
            ////  0   1   2   3   4   5
            //0   F   F   F   P   P   P
            //1   F   F   W   P   P   P
            //2   F   F   W   P   P   P
            //3   F   W   W   P   P   P
            //4   F   F   F   F   F   F
            //5   F   F   F   F   F   F


            customMap.tiles = customTiles;
            game.map = customMap;

            // We put the Elf player at index 0 and the Orc player at index 1 for convenience in testing. //
            if (game.currentState.players[0].race == Races.Orc)
            {
                Player orc = game.currentState.players[0];
                game.currentState.players[0] = game.currentState.players[1];
                game.currentState.players[1] = orc;
            }

            game.currentState.positionsUnits.Clear();
            Position p1 = new Position(4, 3);
            Position p2 = new Position(0, 0);
            game.currentState.positionsUnits.Add(p1, new List<AUnit>());
            game.currentState.positionsUnits.Add(p2, new List<AUnit>());
            foreach(AUnit unit in game.currentState.players[0].units)
            {
                unit.position = p1;
                game.currentState.positionsUnits[p1].Add(unit);
            }
            foreach (AUnit unit in game.currentState.players[1].units)
            {
                unit.position = p2;
                game.currentState.positionsUnits[p2].Add(unit);
            }

            // Now the elven units are at position (4,3). //
            // Now the orc units are at position (0,0). //
            List<Position> suggestions = game.suggestMove();
            // No unit is selected, so the suggestions should be empty. //
            Assert.AreEqual(suggestions.Count, 0);
            game.selectUnitAt(p2);
            suggestions = game.suggestMove();
            // An enemy unit was selected, so the suggestions should be empty. //
            Assert.AreEqual(suggestions.Count, 0);

            game.selectUnitAt(p1);
            // We expect three suggested positions, all on forest tiles .//
            suggestions = game.suggestMove();
            Assert.AreEqual(suggestions.Count, 3);
            Assert.AreEqual(suggestions[0], new Position(5,4));
            Assert.AreEqual(suggestions[1], new Position(4,4));
            Assert.AreEqual(suggestions[2], new Position(3,4));

            // Testing the suggested moves for the orc unit at position (0,0). //
            game.endPlayerTurn();
            game.selectUnitAt(p2);
            suggestions = game.suggestMove();
            // We expect no good suggestions, so only the position the unit is already at. //
            Assert.AreEqual(suggestions.Count, 1);
            Assert.AreEqual(suggestions[0], p2);
        }
    }
}
