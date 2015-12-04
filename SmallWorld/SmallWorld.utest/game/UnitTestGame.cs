﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallWorld.Core;
using System.Collections.Generic;

namespace SmallWorld.utest
{
    [TestClass]
    public class UnitTestGame
    {
        [TestMethod]
        public void TestMovingCases()
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

            // Testing the created players. //
            Assert.AreEqual(GS.nbPlayers, game.currentState.players.Count);
            foreach (Player p in game.currentState.players)
            {
                Assert.AreEqual(GS.unitLimit, p.units.Count);
                foreach (AUnit unit in p.units)
                    Assert.IsTrue(game.currentState.positionsUnits.ContainsKey(unit.position));
            }

            // We put the Elf player at index 0 and the Orc player at index 1 for convenience in testing. //
            if (game.currentState.players[0].race == Races.Orc)
            {
                Player orc = game.currentState.players[0];
                game.currentState.players[0] = game.currentState.players[1];
                game.currentState.players[1] = orc;
            }

            Position p1 = new Position(1, 2);
            Position p2 = new Position(5, 3);

            game.currentState.positionsUnits.Clear();
            game.currentState.positionsUnits.Add(p1, new List<AUnit>());
            game.currentState.positionsUnits.Add(p2, new List<AUnit>());

            foreach (AUnit unit in game.currentState.players[0].units)
            {
                unit.position = p1;
                game.currentState.positionsUnits[p1].Add(unit);
            }

            foreach (AUnit unit in game.currentState.players[1].units)
            {
                unit.position = p2;
                game.currentState.positionsUnits[p2].Add(unit);
            }

            // Player1 units are at pos (1,2). //
            // Player2 units are at pos (5,3). //
            Assert.IsTrue(game.currentState.selectedUnit == null);
            game.selectUnitAt(p1);
            for (int i = 0; i < GS.unitLimit; i++)
            {
                // Testing the selection over the units on the same tile. //
                Assert.IsTrue(game.currentState.selectedUnit.Equals(game.currentState.players[0].units[i]));
                game.selectUnitAt(p1);
            }
            // Testing the selection over the units on the same tile, from the last to the first. //
            Assert.IsTrue(game.currentState.selectedUnit.Equals(game.currentState.players[0].units[0]));

            // Testing the selection over no unit. //
            game.selectUnitAt(new Position(0, 0));
            Assert.IsTrue(game.currentState.selectedUnit == null);

            // Testing move command of a friendly unit. //
            // From (1,2) to (1,1). //
            game.selectUnitAt(p1);
            Position to = new Position(1, 1);
            game.moveSelectedUnitTo(to);
            Assert.IsTrue(game.currentState.selectedUnit.position.Equals(to));
            Assert.IsTrue(game.currentState.positionsUnits.ContainsKey(to));
            Assert.AreEqual(game.currentState.positionsUnits[to].Count, 1);
            Assert.IsTrue(game.currentState.players[0].units[0].position.Equals(to));
            Assert.AreEqual(game.currentState.selectedUnit.actionPool, (2 - game.currentState.selectedUnit.getMoveCost(game.map.getTileAtPos(to))));

            // Testing the selection of an enemy unit. //
            game.selectUnitAt(p2);
            Assert.IsTrue(game.currentState.selectedUnit.Equals(game.currentState.players[1].units[0]));

            // Testing the not moving of an enemy unit. //
            Position to2 = new Position(5, 2);
            game.moveSelectedUnitTo(to2);

            Assert.IsFalse(game.currentState.selectedUnit.position.Equals(to2));
            Assert.IsFalse(game.currentState.positionsUnits.ContainsKey(to2));
            Assert.IsFalse(game.currentState.players[1].units[0].position.Equals(to2));
            Assert.AreEqual(game.currentState.selectedUnit.actionPool, 2);

            // Testing moving a friendly unit to a tile where there is already a friendly unit. //
            game.selectUnitAt(p1);
            game.moveSelectedUnitTo(to);

            Assert.AreEqual(game.currentState.positionsUnits[to].Count, 2);

            // Testing moving to a valid tile but too far away. //
            game.selectUnitAt(p1);
            Position invalidPos0 = new Position(5, 5);
            game.moveSelectedUnitTo(invalidPos0);

            Assert.IsTrue(game.currentState.selectedUnit.position.Equals(p1));
            Assert.IsFalse(game.currentState.positionsUnits.ContainsKey(invalidPos0));
            Assert.AreEqual(game.currentState.selectedUnit.actionPool, 2);

            // Testing moving to an invalid position : OOB. //
            Position invalidPos1 = new Position(-1, 2);
            game.moveSelectedUnitTo(invalidPos1);

            Assert.IsTrue(game.currentState.selectedUnit.position.Equals(p1));
            Assert.IsFalse(game.currentState.positionsUnits.ContainsKey(invalidPos1));
            Assert.AreEqual(game.currentState.selectedUnit.actionPool, 2);

            // Testing moving to an invalid position : water tile for Elf. //
            Position invalidPos2 = new Position(2, 2);
            game.moveSelectedUnitTo(invalidPos2);

            Assert.IsTrue(game.currentState.selectedUnit.position.Equals(p1));
            Assert.IsFalse(game.currentState.positionsUnits.ContainsKey(invalidPos2));
            Assert.AreEqual(game.currentState.selectedUnit.actionPool, 2);

            // Give the hand to the second player. //
            game.endPlayerTurn();

            Assert.AreEqual(game.currentState.activePlayerIndex, 1);
            Assert.IsTrue(game.currentState.selectedUnit == null);

            // Testing moving to a far away valid location. //
            game.selectUnitAt(p2);
            Position farAway = new Position(4, 0);
            Assert.IsFalse(game.currentState.positionsUnits.ContainsKey(farAway));
            game.moveSelectedUnitTo(farAway);

            Assert.IsTrue(game.currentState.selectedUnit.position.Equals(farAway));
            Assert.IsTrue(game.currentState.positionsUnits.ContainsKey(farAway));
            Assert.AreEqual(game.currentState.positionsUnits[farAway].Count, 1);
            Assert.IsTrue(game.currentState.players[1].units[0].position.Equals(farAway));
            Assert.AreEqual(game.currentState.selectedUnit.actionPool, 0);

            // Try moving away all the units from a Tile. //
            game.selectUnitAt(p2);
            while (game.currentState.selectedUnit != null)
            {
                game.moveSelectedUnitTo(farAway);
                game.selectUnitAt(p2);
            }

            Assert.IsFalse(game.currentState.positionsUnits.ContainsKey(p2));

            // Ending player2 turn and thus game turn number 1. //
            Assert.AreEqual(game.currentState.players[0].points, 0);
            Assert.AreEqual(game.currentState.players[1].points, 0);
            int nextScoreP1 = game.currentState.players[0].countPoints(game.map);
            int nextScoreP2 = game.currentState.players[1].countPoints(game.map);

            game.endPlayerTurn();

            // Testing the points earning. //
            Assert.AreEqual(game.currentState.turnCounter, 1);
            Assert.AreEqual(nextScoreP1, game.currentState.players[0].points);
            Assert.AreEqual(nextScoreP2, game.currentState.players[1].points);

            // Teleporting elven units around the map to test battles now. //
            game.currentState.positionsUnits.Clear();
            Position newElven = new Position(4, 3);
            game.currentState.positionsUnits.Add(newElven, new List<AUnit>());
            game.currentState.positionsUnits.Add(farAway, new List<AUnit>());
            foreach (AUnit unit in game.currentState.players[0].units)
            {
                unit.position = newElven;
                game.currentState.positionsUnits[unit.position].Add(unit);
            }
            foreach (AUnit unit in game.currentState.players[1].units)
                game.currentState.positionsUnits[unit.position].Add(unit);

            // Now elvens are at position (4,3) and orcs at position (4,0). //
            int initialOrcHP = game.currentState.positionsUnits[farAway][0].healthPt;
            int initialOrcDP = game.currentState.positionsUnits[farAway][0].defencePt;
            game.selectUnitAt(newElven);
            Assert.IsFalse(game.currentState.selectedUnit == null);
            game.moveSelectedUnitTo(farAway);

            // The elven unit should be in pos (4,2), in range of the pos (4,0), and have attacked the first orc unit .//
            // The defencer can't be dead after one attack, since the elven unit deals a maximum of 4*1.3*2 = 10.4 damage .//
            // And an orc unit has 17 life points. //
            // On the other hand, the elven unit can deal a minimum of 2 points of damage, wich will be entierly absorbed by the orc defence Points. //
            // So we can't really test the damage dealt all the time. //
            // DISCLAIMER : this has been tested in the debug mode and in working as intended. //
            // The defender has to be the first orc unit on the said tile, given the context. //
            Position expected = new Position(4, 2);
            Assert.AreEqual(game.currentState.selectedUnit.position, expected);
            // The defender might have lost 1 defence point or not, if it had a lucky evade. //
            Assert.IsTrue(initialOrcDP == game.currentState.positionsUnits[farAway][0].defencePt ||
                initialOrcDP == game.currentState.positionsUnits[farAway][0].defencePt + 1);

            // Testing what happens if a melee unit kills the last unit on a tile and tries to move forward after its action. //
            AUnit doomed = game.currentState.selectedUnit;
            doomed.healthPt = 1;
            // Now the elven unit has 1 health points and will be killed if it doesn't have 4 lucky evades, ie (1/100)^4 chance of occurring. //
            // This unit test might not succeed because of that. //
            game.endPlayerTurn();
            game.selectUnitAt(farAway);
            while(game.currentState.selectedUnit != null)
            {
                game.moveSelectedUnitTo(expected);
                game.selectUnitAt(farAway);
            }
            Assert.IsFalse(game.currentState.players[0].units.Contains(doomed));
            Assert.IsTrue(game.currentState.positionsUnits[expected].Count != 0);
            Assert.AreEqual(game.currentState.positionsUnits[expected][0].actionPool, (2 - 0.5 * 2));
        }

        [TestMethod]
        public void TestVictories()
        {
            GameSettings GS = new GameSettings();
            GS.mapType = MapType.Demo;
            GS.setFieldsAccordingToMapType();
            GS.playersNames.Add("Player1");
            GS.playersRaces.Add(Races.Elf);
            GS.playersNames.Add("Player2");
            GS.playersRaces.Add(Races.Orc);

            GameBuilder gameBuilder = new GameBuilder(GS);
            Game game = gameBuilder.build();

            UnitFactory factory = new UnitFactory();

            // Now test that these scenarios are triggered both by the ending conditions, and the ending of players' turns. //
            Assert.IsTrue(game.previousGameStates.Count == 0);
            game.currentState.players[0].units.Clear();
            Assert.AreEqual(game.winner(), game.currentState.players[1]);
            game.endPlayerTurn();
            Assert.IsFalse(game.running);
            game.running = true;
            game.currentState.players[0].units.Add(factory.createUnit(game.currentState.players[0].race));
            game.currentState.players[1].units.Clear();
            Assert.AreEqual(game.winner(), game.currentState.players[0]);
            game.endPlayerTurn();
            Assert.IsFalse(game.running);
            game.running = true;
            game.currentState.players[0].units.Clear();
            Assert.IsTrue(game.winner() == null);
            game.endPlayerTurn();
            Assert.IsFalse(game.running);
        }
    }
}
