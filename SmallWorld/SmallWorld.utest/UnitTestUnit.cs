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
    }
}
