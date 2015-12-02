using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallWorld.Core;

namespace SmallWorld.utest
{
    [TestClass]
    public class UnitTestMap
    {
        /// <summary>
        /// [R23_1_MAP_SIZE] Check demo map size
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

        [TestMethod]
        public void TestMapSmall()
        {
            //
        }

        [TestMethod]
        public void TestMapStandard()
        {
            //
        }


    }
}
