using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallWorld.Core;

namespace SmallWorld.utest
{
    [TestClass]
    public class UnitTestMap
    {
        /// <summary>
        /// [R23_1_MAP_SIZE] Check demo map size.
        /// </summary>
        [TestMethod]
        public void TestMapDemo()
        {
            // create setup according to type
            Map demoMap = new Map(MapType.Demo);
            // setup the map
            demoMap.setupMap();

            Position topLeftCorner = new Position(0, 0);
            Position bottomRightCorner = new Position(5, 5);
            Assert.IsTrue(demoMap.inBound(topLeftCorner));
            Assert.IsTrue(demoMap.inBound(bottomRightCorner));
            Assert.IsFalse(demoMap.inBound(new Position(100, 100)));
        }

        /// <summary>
        /// [R23_1_MAP_SIZE] Check small map size.
        /// </summary>
        [TestMethod]
        public void TestMapSmall()
        {
            // create setup according to type
            Map smallMap = new Map(MapType.Small);
            // setup the map
            smallMap.setupMap();

            Position topLeftCorner = new Position(0, 0);
            Position bottomRightCorner = new Position(9, 9);
            Assert.IsTrue(smallMap.inBound(topLeftCorner));
            Assert.IsTrue(smallMap.inBound(bottomRightCorner));
            Assert.IsFalse(smallMap.inBound(new Position(100, 100)));
        }

        /// <summary>
        /// [R23_1_MAP_SIZE] Check standard map size.
        /// </summary>
        [TestMethod]
        public void TestMapStandard()
        {
            // create setup according to type
            Map standartMap = new Map(MapType.Standard);
            // setup the map
            standartMap.setupMap();

            Position topLeftCorner = new Position(0, 0);
            Position bottomRightCorner = new Position(13, 13);
            Assert.IsTrue(standartMap.inBound(topLeftCorner));
            Assert.IsTrue(standartMap.inBound(bottomRightCorner));
            Assert.IsFalse(standartMap.inBound(new Position(100, 100)));
        }
    }
}
