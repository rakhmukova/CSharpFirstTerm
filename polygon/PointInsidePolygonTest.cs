using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PointInsidePolygon
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(new Point(-1, 1), Program.MakeVector(new Point(4, 3), new Point(3,4)));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(new Point(100, 90), Program.MakeVector(new Point(15, 10), new Point(115, 100)));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Point firstVector = new Point(0, 4);
            Point secondVector = new Point(3, 2);
            Assert.AreEqual(-1, Program.GetVectorProductSign(firstVector, secondVector));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Point firstVector = new Point(-3, -6);
            Point secondVector = new Point(-1,-2);
            Assert.AreEqual(0, Program.GetVectorProductSign(firstVector, secondVector));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Point firstVector = new Point(6, 0);
            Point secondVector = new Point(-2, 0);
            Assert.AreEqual(0, Program.GetVectorProductSign(firstVector, secondVector));
        }

        [TestMethod]
        public void TestMethod6()
        {
            Point A = new Point(2, 2);
            Point B = new Point(8, 7);
            Point C = new Point(6, 4);
            Point D = new Point(5, 8);
            Assert.AreEqual(1, Program.GetPointLocation(C, A, B));
            Assert.AreEqual(-1, Program.GetPointLocation(D, A, B));
        }

        [TestMethod]
        public void TestMethod7()
        {
            Point point = new Point(2, -1);
            Point firstBorderEnd = new Point(1, -3);
            Point secondBorderEnd = new Point(4, 3);
            Assert.AreEqual(true, Program.BelongsToBorder(point, firstBorderEnd, secondBorderEnd));
        }        

        [TestMethod]
        public void TestMethod8()
        {
            Point point = new Point(3, 0);
            Point firstBorderEnd = new Point(1, -3);
            Point secondBorderEnd = new Point(4, 3);
            Assert.AreEqual(false, Program.BelongsToBorder(point, firstBorderEnd, secondBorderEnd));
        }

        [TestMethod]
        public void TestMethod9()
        {
            Point point = new Point(2, 2);
            Point firstBorderEnd = new Point(2, 6);
            Point secondBorderEnd = new Point(2, -4);
            Assert.AreEqual(true, Program.BelongsToBorder(point, firstBorderEnd, secondBorderEnd));
        }

        [TestMethod]
        public void TestMethod10()
        {
            Point point = new Point(2, -7);
            Point firstBorderEnd = new Point(2, 6);
            Point secondBorderEnd = new Point(2, -4);
            Assert.AreEqual(false, Program.BelongsToBorder(point, firstBorderEnd, secondBorderEnd));
        }

        [TestMethod]
        public void TestMethod11()
        {
            Point startOfTheRay = new Point(2, 5);
            Point endOfTheRay = new Point(12, 5);
            Point firstBorderEnd = new Point(3, 6);
            Point secondBorderEnd = new Point(8, 9);
            Assert.AreEqual(false, Program.RayAndBorderHaveCommonPoints(startOfTheRay, endOfTheRay, firstBorderEnd, secondBorderEnd));
        }

        [TestMethod]
        public void TestMethod12()
        {
            Point startOfTheRay = new Point(2, 5);
            Point endOfTheRay = new Point(12, 5);
            Point firstBorderEnd = new Point(7, 3);
            Point secondBorderEnd = new Point(11, 8);
            Assert.AreEqual(true, Program.RayAndBorderHaveCommonPoints(startOfTheRay, endOfTheRay, firstBorderEnd, secondBorderEnd));
        }

        [TestMethod]
        public void TestMethod13()
        {
            Point startOfTheRay = new Point(2, 5);
            Point endOfTheRay = new Point(12, 5);
            Point firstBorderEnd = new Point(-3, 5);
            Point secondBorderEnd = new Point(-1,5);
            Assert.AreEqual(false, Program.RayAndBorderHaveCommonPoints(startOfTheRay, endOfTheRay, firstBorderEnd, secondBorderEnd));
        }

        [TestMethod]
        public void TestMethod14()
        {
            Point startOfTheRay = new Point(2, 5);
            Point endOfTheRay = new Point(12, 5);
            Point firstBorderEnd = new Point(5, 2);
            Point secondBorderEnd = new Point(11, 2);
            Assert.AreEqual(false, Program.RayAndBorderHaveCommonPoints(startOfTheRay, endOfTheRay, firstBorderEnd, secondBorderEnd));
        }

        [TestMethod]
        public void TestMethod15()
        {
            int[] locations = { -1, 0, 0, 1 };
            Assert.AreEqual(1, Program.GetTheNumberOfCrossings(locations, 1));
        }

        [TestMethod]
        public void TestMethod16()
        {
            int[] locations = { -1, -1, 0, 1 };
            Assert.AreEqual(1, Program.GetTheNumberOfCrossings(locations, 1));
        }

        [TestMethod]
        public void TestMethod17()
        {
            int[] locations = { -1, -1, 1, 1 };
            Assert.AreEqual(1, Program.GetTheNumberOfCrossings(locations, 1));
        }


        [TestMethod]
        public void TestMethod18()
        {
            int[] point = { 0, 1 };
            int[,] verticesCoordinates = { { 2, 2 }, { -1, -2 }, { -2, 3 } };
            Assert.IsTrue (Program.BelongsToPolygon(point, verticesCoordinates));
        }

        [TestMethod]
        public void TestMethod19()
        {
            int[] point = { 0, 0 };
            int[,] verticesCoordinates = { { 0, 4 }, { 2, 8 }, { 7, 8 }, { 10, 5 }, { 5, 5 }, { 5, 0 } };
            Assert.IsFalse (Program.BelongsToPolygon(point, verticesCoordinates));
        }

        [TestMethod]
        public void TestMethod20()
        {
            int[] point = { 6, -2};
            int[,] verticesCoordinates = { {3, 1 }, {4, 2 }, {13, 2 }, {13, -2 }, {15, 1 },
                {16, 1 }, { 12, -4}, {12, 1 }, {6, 1 }, {10, -2 }, {8, -2 }, {10, -4 }, {6, -4 },
                {6, -6 }, {4, -3 }, {4, -5 }, {1, -2 },{ 5, -2 }};

            Assert.IsTrue (Program.BelongsToPolygon(point, verticesCoordinates));
        }

        [TestMethod]
        public void TestMethod21()
        {
            int[] point = { 1, -4 };
            int[,] verticesCoordinates = { {3, 1 }, {4, 2 }, {13, 2 }, {13, -2 }, {15, 1 },
                {16, 1 }, { 12, -4}, {12, 1 }, {6, 1 }, {10, -2 }, {8, -2 }, {10, -4 }, {6, -4 },
                {6, -6 }, {4, -3 }, {4, -5 }, {1, -2 },{ 5, -2 }};

            Assert.IsFalse (Program.BelongsToPolygon(point, verticesCoordinates));
        }

        [TestMethod]
        public void TestMethod22()
        {
            int[] point = { 2, -3 };
            int[,] verticesCoordinates = { {3, 1 }, {4, 2 }, {13, 2 }, {13, -2 }, {15, 1 },
                {16, 1 }, { 12, -4}, {12, 1 }, {6, 1 }, {10, -2 }, {8, -2 }, {10, -4 }, {6, -4 },
                {6, -6 }, {4, -3 }, {4, -5 }, {1, -2 },{ 5, -2 }};

            Assert.IsTrue (Program.BelongsToPolygon(point, verticesCoordinates));
        }
    }

}
