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
        public void TestElfCrossingWater()
        {
            ElfUnit unit = new ElfUnit();
            Water water = new Water();

            Assert.IsFalse(unit.canCrossTile(water));
        }

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
        public void TestElfCountPointsForest()
        {
            ElfUnit unit = new ElfUnit();
            Forest forest = new Forest();

            Assert.AreEqual(3, unit.countPoints(forest));
        }

        [TestMethod]
        public void TestElfCountPointsMountain()
        {
            ElfUnit unit = new ElfUnit();
            Mountain mountain = new Mountain();

            Assert.AreEqual(0, unit.countPoints(mountain));
        }

        [TestMethod]
        public void TestElfCountPointsPlain()
        {
            ElfUnit unit = new ElfUnit();
            Plain plain = new Plain();

            Assert.AreEqual(1, unit.countPoints(plain));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid current tile type.")]
        public void TestElfCountPointsWater()
        {
            ElfUnit unit = new ElfUnit();
            Water water = new Water();

            unit.countPoints(water);
        }

        [TestMethod]
        public void TestElfGetAttackRange()
        {
            ElfUnit unit = new ElfUnit();
            Water water = new Water();

            Assert.AreEqual(2, unit.getAttackRange(water));
        }

        [TestMethod]
        public void TestElfMoveCostForest()
        {
            ElfUnit unit = new ElfUnit();
            Forest forest = new Forest();

            Assert.AreEqual(1, unit.getMoveCost(forest));
        }

        [TestMethod]
        public void TestElfMoveCostMountain()
        {
            ElfUnit unit = new ElfUnit();
            Mountain mountain = new Mountain();

            Assert.AreEqual(2, unit.getMoveCost(mountain));
        }

        [TestMethod]
        public void TestElfMoveCostPlain()
        {
            ElfUnit unit = new ElfUnit();
            Plain plain = new Plain();

            Assert.AreEqual(1, unit.getMoveCost(plain));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid target tile type.")]
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
            Mountain mountain = new Mountain();
            Forest forest = new Forest();
            Plain plain = new Plain();
            Water water = new Water();
            bool res = unit.canCrossTile(mountain);

            res = res && unit.canCrossTile(forest);
            res = res && unit.canCrossTile(plain);
            res = res && unit.canCrossTile(water);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestHumanCountPointsForest()
        {
            HumanUnit unit = new HumanUnit();
            Forest forest = new Forest();

            Assert.AreEqual(1, unit.countPoints(forest));
        }

        [TestMethod]
        public void TestHumanCountPointsMountain()
        {
            HumanUnit unit = new HumanUnit();
            Mountain mountain = new Mountain();

            Assert.AreEqual(1, unit.countPoints(mountain));
        }

        [TestMethod]
        public void TestHumanCountPointsPlain()
        {
            HumanUnit unit = new HumanUnit();
            Plain plain = new Plain();

            Assert.AreEqual(2, unit.countPoints(plain));
        }

        [TestMethod]
        public void TestHumanCountPointsWater()
        {
            HumanUnit unit = new HumanUnit();
            Water water = new Water();

            Assert.AreEqual(0, unit.countPoints(water));
        }

        [TestMethod]
        public void TestHumanGetAttackRange()
        {
            HumanUnit unit = new HumanUnit();
            Mountain mountain = new Mountain();
            Forest forest = new Forest();
            Plain plain = new Plain();
            Water water = new Water();
            bool res = true && unit.getAttackRange(mountain) == 1;

            res = res && unit.getAttackRange(forest) == 1;
            res = res && unit.getAttackRange(plain) == 1;
            res = res && unit.getAttackRange(water) == 1;

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestHumanMoveCostAll()
        {
            HumanUnit unit = new HumanUnit();
            Mountain mountain = new Mountain();
            Forest forest = new Forest();
            Plain plain = new Plain();
            Water water = new Water();
            bool res = true && unit.getMoveCost(mountain) == 1;

            res = res && unit.getMoveCost(forest) == 1;
            res = res && unit.getMoveCost(plain) == 1;
            res = res && unit.getMoveCost(water) == 1;

            Assert.IsTrue(res);
        }


    }
}
