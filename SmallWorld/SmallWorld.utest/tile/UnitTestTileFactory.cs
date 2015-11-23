using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallWorld.Core;

namespace SmallWorld.utest.tile
{
    [TestClass]
    public class UnitTestTileFactory
    {
        [TestMethod]
        public void TestFlyweightAll()
        {
            Forest forest0 = TileFactory.INSTANCE.createForestTile();
            Forest forest1 = TileFactory.INSTANCE.createForestTile();
            Plain plain0 = TileFactory.INSTANCE.createPlainTile();
            Plain plain1 = TileFactory.INSTANCE.createPlainTile();
            Mountain mountain0 = TileFactory.INSTANCE.createMountainTile();
            Mountain mountain1 = TileFactory.INSTANCE.createMountainTile();
            Water water0 = TileFactory.INSTANCE.createWaterTile();
            Water water1 = TileFactory.INSTANCE.createWaterTile();

            Assert.AreEqual(forest0, forest1);
            Assert.AreEqual(plain0, plain1);
            Assert.AreEqual(mountain0, mountain1);
            Assert.AreEqual(water0, water1);
        }
    }
}
