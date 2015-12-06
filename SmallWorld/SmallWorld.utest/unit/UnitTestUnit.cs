using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallWorld.Core;

namespace SmallWorld.utest
{
    [TestClass]
    public class UnitTestUnit
    {
        // TESTING AUNITS //
        [TestMethod]
        public void TestAUnitLoseHP()
        {
            UnitFactory factory = new UnitFactory();
            ElfUnit eUnit = factory.createElfUnit();
            int initialHP = eUnit.healthPt;
            eUnit.loseHP(-1);
            Assert.AreEqual(initialHP, eUnit.healthPt);

            eUnit.healthPt = 1;
            eUnit.loseHP(2);
            Assert.AreEqual(eUnit.healthPt, 0);
        }

        [TestMethod]
        public void TestAUnitEquals()
        {
            UnitFactory factory = new UnitFactory();
            ElfUnit eUnit = factory.createElfUnit();
            Assert.IsTrue(eUnit.equals(eUnit));
            AUnit copiedEUnit = factory.copyUnit(eUnit);
            Assert.IsTrue(eUnit.equals(copiedEUnit));
            HumanUnit hUnit = factory.createHumanUnit();
            Assert.IsFalse(eUnit.equals(hUnit));
            OrcUnit oUnit = factory.createOrcUnit();
            Assert.IsFalse(eUnit.equals(oUnit));
            Assert.IsFalse(hUnit.equals(oUnit));


            copiedEUnit.position = null;
            Assert.IsFalse(eUnit.equals(copiedEUnit));
            eUnit.position = null;
            Assert.IsTrue(eUnit.equals(copiedEUnit));
            copiedEUnit.position = new Position(0, 0);
            Assert.IsFalse(eUnit.equals(copiedEUnit));

            eUnit.position = new Position(0, 0);
            copiedEUnit.healthPt--;
            Assert.IsFalse(eUnit.equals(copiedEUnit));
            copiedEUnit.defencePt--;
            Assert.IsFalse(eUnit.equals(copiedEUnit));
            copiedEUnit.attackPt--;
            Assert.IsFalse(eUnit.equals(copiedEUnit));
            copiedEUnit.actionPool--;
            Assert.IsFalse(eUnit.equals(copiedEUnit));

        }

        // TESTING ELVEN UNITS //
        [TestMethod]
        public void TestElfCrossingNotWater()
        {
            ElfUnit unit = new ElfUnit();
            Plain plain = new Plain();
            Mountain mountain = new Mountain();
            Forest forest = new Forest();
            Assert.IsTrue(unit.canCrossTile(plain));
            Assert.IsTrue(unit.canCrossTile(mountain));
            Assert.IsTrue(unit.canCrossTile(forest));
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
