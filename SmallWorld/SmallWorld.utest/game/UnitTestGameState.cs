using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallWorld.Core;
using System.Collections.Generic;

namespace SmallWorld.utest
{
    [TestClass]
    public class UnitTestGameState
    {
        [TestMethod]
        public void TestDictionaryKeyIndependence()
        {
            GameState state = new GameState();
            UnitFactory factory = new UnitFactory();
            AUnit unit = factory.createUnit(Races.Elf);
            unit.position = new Position(0, 0);
            AUnit unit2 = factory.createUnit(Races.Elf);
            unit2.position = new Position(0, 0);

            state.positionsUnits.Add(new Position(unit.position), new List<AUnit>() { unit });
            Assert.IsTrue(state.positionsUnits.ContainsKey(new Position(0, 0)));
            Assert.IsTrue(state.positionsUnits.ContainsKey(unit2.position));
            unit.position.x = 10;
            Assert.IsFalse(state.positionsUnits.ContainsKey(unit.position));
            Assert.IsTrue(state.positionsUnits.Count == 1);
            Assert.IsTrue(state.positionsUnits.ContainsKey(unit2.position));

            // Therefore, if we add a key to the dictionary, modifying the unit's position will not modify //
            // the key object, since it's a hash of the said object. //
        }
    }
}
