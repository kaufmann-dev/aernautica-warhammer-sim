using System.Collections.Generic;
using aernautica.aircraft;
using aernautica.core;
using NUnit.Framework;

namespace aernautica.unittest {
    public class PointTests {
        [SetUp]
        public void Setup() {
        }


        [Test]
        public void TestIsNeighbour() {
            Point p = new Point(1,1,1);
            
            Assert.True(p.IsDiagonalNeighbour(new Point(0,0,1)));
            Assert.True(p.IsDiagonalNeighbour(new Point(2,0,1)));
            Assert.True(p.IsDiagonalNeighbour(new Point(0,2,1)));
            Assert.True(p.IsDiagonalNeighbour(new Point(2,2,1)));
            
        }

        [Test]
        public void TestIsDirectNeighbour() {
            Point p = new Point(3,3,1);
            
            Assert.True(p.IsDirectNeighbour(new Point(3,2,1)));
            Assert.True(p.IsDirectNeighbour(new Point(2,3,1)));
            Assert.True(p.IsDirectNeighbour(new Point(4,3,1)));
            Assert.True(p.IsDirectNeighbour(new Point(3,4,1)));
            
            Assert.False(p.IsDirectNeighbour(new Point(4,4,1)));
        }
        
        [Test]
        public void TestCalculateRoute() {
            Point p = new Point(0, 0, 0);
            List<Point> route = p.CalculateRoute(new Point(4, 0, 0));

            List<Point> expectedRoute = new List<Point>() {
                new Point(1, 0, 0),
                new Point(2, 0, 0),
                new Point(3, 0, 0),
                new Point(4, 0, 0)
            };

            Assert.True(route.Count > 0);
            Assert.AreEqual(4, route.Count);

            for (int i = 0; i < route.Count; i++) {
                Assert.AreEqual(expectedRoute[i], route[i]);
            }

            Point p2 = new Point(3, 0, 0);
            List<Point> route2 = p2.CalculateRoute(new Point(6, 0, 0));

            List<Point> expectedRoute2 = new List<Point>() {
                new Point(4, 0, 0),
                new Point(5, 0, 0),
                new Point(6, 0, 0)
            };

            Assert.True(route2.Count > 0);
            Assert.AreEqual(route2.Count, 3);

            for (int i = 0; i < route2.Count; i++) {
                Assert.AreEqual(expectedRoute2[i], route2[i]);
            }

            List<Point> route3 = p.CalculateRoute(new Point(0, 4, 0));

            List<Point> expectedroute3 = new List<Point>() {
                new Point(0, 1, 0),
                new Point(0, 2, 0),
                new Point(0, 3, 0),
                new Point(0, 4, 0)
            };

            Assert.True(route3.Count > 0);
            Assert.AreEqual(4, route3.Count);

            for (int i = 0; i < route3.Count; i++) {
                Assert.AreEqual(expectedroute3[i], route3[i]);
            }

            Point p3 = new Point(0, 3, 0);
            List<Point> route4 = p3.CalculateRoute(new Point(0, 8, 0));

            List<Point> expectedRoute4 = new List<Point>() {
                new Point(0, 4, 0),
                new Point(0, 5, 0),
                new Point(0, 6, 0),
                new Point(0, 7, 0),
                new Point(0, 8, 0)
            };

            Assert.True(route4.Count > 0);
            Assert.AreEqual(5, route4.Count);

            for (int i = 0; i < route4.Count; i++) {
                Assert.AreEqual(expectedRoute4[i], route4[i]);
            }

            List<Point> route5 = p.CalculateRoute(new Point(3, 3, 3));
            List<Point> expectedRoute5 = new List<Point>() {
                new Point(1, 1, 1),
                new Point(2, 2, 2),
                new Point(3, 3, 3)
            };

            Assert.True(route5.Count > 0);
            for (int i = 0; i < route5.Count; i++) {
                Assert.AreEqual(expectedRoute5[i], route5[i]);
            }

            List<Point> route6 = p.CalculateRoute(new Point(2, 3, 2));
            List<Point> expectedRoute6 = new List<Point>() {
                new Point(1, 1, 1),
                new Point(2, 2, 2),
                new Point(2, 3, 2)
            };

            Assert.True(route6.Count > 0);
            Assert.AreEqual(3, route6.Count);

            for (int i = 0; i < route6.Count; i++) {
                Assert.AreEqual(expectedRoute6[i], route6[i]);
            }

            List<Point> route7 = p.CalculateRoute(new Point(3, 4, 5));
            List<Point> expectedRoute7 = new List<Point>() {
                new Point(1, 1, 1),
                new Point(2, 2, 2),
                new Point(3, 3, 3),
                new Point(3, 4, 4)
            };
            
            Assert.True(route7.Count > 0);
            Assert.AreEqual(4,route7.Count);

            for (int i = 0; i < route7.Count; i++) {
                Assert.AreEqual(expectedRoute7[i], route7[i]);
            }
        }

        [Test]
        public void HasDirectConnection() {
            Point p = new Point(3,3,3);
            
            Assert.True(p.HasDirectConnection(new Point(1,3, 5)));
            Assert.True(p.HasDirectConnection(new Point(3,1, 5)));
            Assert.True(p.HasDirectConnection(new Point(3,5, 5)));
        }

        [Test]
        public void CalculateBearing() {
            Point p = new Point(3,3,3);
            
            Assert.AreEqual(EOrientation.NORTH, p.CalculateBearing(new Point(3,1,7)));
            Assert.AreEqual(EOrientation.SOUTH, p.CalculateBearing(new Point(3,7,7)));
            Assert.AreEqual(EOrientation.WEST, p.CalculateBearing(new Point(5,3,7)));
            Assert.AreEqual(EOrientation.EAST, p.CalculateBearing(new Point(1,3,7)));
        }

        [Test]
        public void CalculateDistance() {
            Point p1 = new Point(0,0,0);
            Point p2 = new Point(10,0,0);
            
            Assert.AreEqual(10, p1.CalculateDistance(p2));
            
            Point p3 = new Point(0,5, 0);
            Assert.AreEqual(5, p3.CalculateDistance(p1));
            
            Point p4 = new Point(3,4,5);
            Assert.AreEqual(7, p1.CalculateDistance(p4));
        }
    }
}