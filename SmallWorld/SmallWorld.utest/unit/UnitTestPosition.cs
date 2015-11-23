using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallWorld.Core;

namespace SmallWorld.utest
{
    [TestClass]
    public class UnitTestPosition
    {
        [TestMethod]
        public void TestPositionConstructor()
        {
            int x = 2;
            int y = -1;
            Position position = new Position(x, y);
            Assert.AreEqual(x, position.x);
            Assert.AreEqual(y, position.y);
        }

        [TestMethod]
        public void TestPositionMemberwiseConstructor()
        {
            int x = 2;
            int y = -1;
            Position position1 = new Position(x, y);
            Position position2 = new Position(position1);

            Assert.AreEqual(x, position2.x);
            Assert.AreEqual(y, position2.y);
            Assert.IsFalse(position1.Equals(position2));
        }

        [TestMethod]
        public void TestPositionEquals()
        {
            Position position1 = new Position(0, 1);
            Position position2 = new Position(1, 0);
            Position position3 = new Position(0, 1);
            Position position4 = new Position(position2);

            Assert.IsTrue(position1.equals(position1));
            Assert.IsTrue(position1.equals(position3));
            Assert.IsFalse(position1.equals(position2));

            Assert.IsTrue(position2.equals(position4));
        }

    }
}
