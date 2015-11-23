using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallWorld.Core;
/// <summary>
/// Testing class for game units.
/// </summary>
namespace SmallWorld.utest
{
    [TestClass]
    public class UnitTestUnit
    {
        // TESTING ELVEN UNITS //
        [TestMethod]
        public void TestElfCrossingNotWater()
        {
            ElfUnit unit = new ElfUnit();
            Plain plain = new Plain();
            Mountain mountain = new Mountain();
            Forest forest = new Forest();
            bool res = unit.canCrossTile(plain);

            res = res && unit.canCrossTile(mountain);
            res = res && unit.canCrossTile(forest);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestElfCrossingWater()
        {
            ElfUnit unit = new ElfUnit();
            Water water = new Water();

            Assert.IsFalse(unit.canCrossTile(water));
        }

        [TestMethod]
        public void TestElfCountPointsNotWater()
        {
            ElfUnit unit = new ElfUnit();
            Forest forest = new Forest();
            Mountain mountain = new Mountain();
            Plain plain = new Plain();

            Assert.AreEqual(3, unit.countPoints(forest));
            Assert.AreEqual(0, unit.countPoints(mountain));
            Assert.AreEqual(1, unit.countPoints(plain));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid current tile type")]
        public void TestElfCountPointsWater()
        {
            ElfUnit unit = new ElfUnit();
            Water water = new Water();

            unit.countPoints(water);
        }

        [TestMethod]
        public void TestElfGetAttackRangeNotWater()
        {
            ElfUnit unit = new ElfUnit();
            Forest forest = new Forest();
            Mountain mountain = new Mountain();
            Plain plain = new Plain();

            Assert.AreEqual(2, unit.getAttackRange(forest));
            Assert.AreEqual(2, unit.getAttackRange(mountain));
            Assert.AreEqual(2, unit.getAttackRange(plain));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid current tile type")]
        public void TestElfGetAttackRangeWater()
        {
            ElfUnit unit = new ElfUnit();
            Water water = new Water();

            unit.getAttackRange(water);
        }

        [TestMethod]
        public void TestElfMoveCostNotWater()
        {
            ElfUnit unit = new ElfUnit();
            Forest forest = new Forest();
            Mountain mountain = new Mountain();
            Plain plain = new Plain();

            Assert.AreEqual(1, unit.getMoveCost(forest));
            Assert.AreEqual(2, unit.getMoveCost(mountain));
            Assert.AreEqual(1, unit.getMoveCost(plain));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid target tile type")]
        public void TestElfMoveCostWater()
        {
            ElfUnit unit = new ElfUnit();
            Water water = new Water();

            unit.getMoveCost(water);
        }

        // TESTING HUMAN UNITS //
        [TestMethod]
        public void TestHumanCrossingAll()
        {
            HumanUnit unit = new HumanUnit();
            Forest forest = new Forest();
            Mountain mountain = new Mountain();
            Plain plain = new Plain();
            Water water = new Water();

            Assert.IsTrue(unit.canCrossTile(forest));
            Assert.IsTrue(unit.canCrossTile(mountain));
            Assert.IsTrue(unit.canCrossTile(plain));
            Assert.IsTrue(unit.canCrossTile(water));
        }

        [TestMethod]
        public void TestHumanCountPointsAll()
        {
            HumanUnit unit = new HumanUnit();
            Forest forest = new Forest();
            Mountain mountain = new Mountain();
            Plain plain = new Plain();
            Water water = new Water();

            Assert.AreEqual(1, unit.countPoints(forest));
            Assert.AreEqual(1, unit.countPoints(mountain));
            Assert.AreEqual(2, unit.countPoints(plain));
            Assert.AreEqual(0, unit.countPoints(water));
        }

        [TestMethod]
        public void TestHumanGetAttackRangeAll()
        {
            HumanUnit unit = new HumanUnit();
            Mountain mountain = new Mountain();
            Forest forest = new Forest();
            Plain plain = new Plain();
            Water water = new Water();

            Assert.AreEqual(1, unit.getAttackRange(forest));
            Assert.AreEqual(1, unit.getAttackRange(mountain));
            Assert.AreEqual(1, unit.getAttackRange(plain));
            Assert.AreEqual(1, unit.getAttackRange(water));
        }

        [TestMethod]
        public void TestHumanMoveCostAll()
        {
            HumanUnit unit = new HumanUnit();
            Mountain mountain = new Mountain();
            Forest forest = new Forest();
            Plain plain = new Plain();
            Water water = new Water();

            Assert.AreEqual(1, unit.getMoveCost(forest));
            Assert.AreEqual(1, unit.getMoveCost(mountain));
            Assert.AreEqual(1, unit.getMoveCost(plain));
            Assert.AreEqual(1, unit.getMoveCost(water));
        }

        // TESTING ORC UNITS //
        [TestMethod]
        public void TestOrcCrossingNotWater()
        {
            OrcUnit unit = new OrcUnit();
            Mountain mountain = new Mountain();
            Forest forest = new Forest();
            Plain plain = new Plain();

            Assert.IsTrue(unit.canCrossTile(forest));
            Assert.IsTrue(unit.canCrossTile(mountain));
            Assert.IsTrue(unit.canCrossTile(plain));
        }

        [TestMethod]
        public void TestOrcCrossingWater()
        {
            OrcUnit unit = new OrcUnit();
            Water water = new Water();

            Assert.IsFalse(unit.canCrossTile(water));
        }

        [TestMethod]
        public void TestOrcCountPointsNotWater()
        {
            OrcUnit unit = new OrcUnit();
            Forest forest = new Forest();
            Mountain mountain = new Mountain();
            Plain plain = new Plain();

            Assert.AreEqual(1, unit.countPoints(forest));
            Assert.AreEqual(2, unit.countPoints(mountain));
            Assert.AreEqual(1, unit.countPoints(plain));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid current tile type")]
        public void TestOrcCountPointsWater()
        {
            OrcUnit unit = new OrcUnit();
            Water water = new Water();

            unit.countPoints(water);
        }

        [TestMethod]
        public void TestOrcGetAttackRangeNotWater()
        {
            OrcUnit unit = new OrcUnit();
            Forest forest = new Forest();
            Mountain mountain = new Mountain();
            Plain plain = new Plain();

            Assert.AreEqual(1, unit.getAttackRange(forest));
            Assert.AreEqual(2, unit.getAttackRange(mountain));
            Assert.AreEqual(1, unit.getAttackRange(plain));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid current tile type")]
        public void TestOrcGetAttackRangeWater()
        {
            OrcUnit unit = new OrcUnit();
            Water water = new Water();

            unit.getAttackRange(water);
        }

        [TestMethod]
        public void TestOrcMoveCostNotWater()
        {
            OrcUnit unit = new OrcUnit();
            Forest forest = new Forest();
            Mountain mountain = new Mountain();
            Plain plain = new Plain();

            Assert.AreEqual(1, unit.getMoveCost(forest));
            Assert.AreEqual(1, unit.getMoveCost(mountain));
            Assert.AreEqual(0.5, unit.getMoveCost(plain));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid target tile type")]
        public void TestOrcMoveCostWater()
        {
            OrcUnit unit = new OrcUnit();
            Water water = new Water();

            unit.getMoveCost(water);
        }
    }
}
