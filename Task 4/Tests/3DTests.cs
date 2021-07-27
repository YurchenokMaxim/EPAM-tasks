using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3D;
using System;

namespace _3DTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [DataRow(1, 1, 1, 1, 1, 1, 0)]
        [DataRow(1, 1, 10, 1, 1, 8, 2)]
        public void PositiveTestOfCoordinateDifference(double firstX, double firstY, double firstZ, double secondX, double secondY, double secondZ, double result)
        {
            Coordinate firstCoordinate = new Coordinate();
            firstCoordinate.X = firstX;
            firstCoordinate.Y = firstY;
            firstCoordinate.Z = firstZ;
            Coordinate secondCoordinate = new Coordinate();
            secondCoordinate.X = secondX;
            secondCoordinate.Y = secondY;
            secondCoordinate.Z = secondZ;
            Assert.AreEqual(firstCoordinate.CountCoordinateDifference(secondCoordinate), result);
        }

        [TestMethod]
        [DataRow(1, 1, 1, 1, 1, 1)]
        [DataRow(1, 1, 1, 5, 6, 7)]
        public void PositiveTestOfFlyToByPlane(double firstX, double firstY, double firstZ, double secondX, double secondY, double secondZ)
        {
            Coordinate firstCoordinate = new Coordinate();
            firstCoordinate.X = firstX;
            firstCoordinate.Y = firstY;
            firstCoordinate.Z = firstZ;
            Coordinate secondCoordinate = new Coordinate();
            secondCoordinate.X = secondX;
            secondCoordinate.Y = secondY;
            secondCoordinate.Z = secondZ;
            Plane plane = new Plane(firstCoordinate);
            plane.FlyTo(secondCoordinate);
            Assert.AreEqual(plane.CurrentPosition, secondCoordinate);
        }

        [TestMethod]
        [DataRow(1, 1, 1, 1, 1, 1, 10)]
        [DataRow(1, 1, 1, 5, 6, 7, 10)]
        public void PositiveTestOfFlyToByDrone(double firstX, double firstY, double firstZ, double secondX, double secondY, double secondZ, double speed)
        {
            Coordinate firstCoordinate = new Coordinate();
            firstCoordinate.X = firstX;
            firstCoordinate.Y = firstY;
            firstCoordinate.Z = firstZ;
            Coordinate secondCoordinate = new Coordinate();
            secondCoordinate.X = secondX;
            secondCoordinate.Y = secondY;
            secondCoordinate.Z = secondZ;
            Drone drone = new Drone(firstCoordinate, speed);
            drone.FlyTo(secondCoordinate);
            Assert.AreEqual(drone.CurrentPosition, secondCoordinate);
        }

        [TestMethod]
        [DataRow(1, 1, 1, 1, 1, 1)]
        [DataRow(1, 1, 1, 5, 6, 7)]
        public void PositiveTestOfFlyToByBird(double firstX, double firstY, double firstZ, double secondX, double secondY, double secondZ)
        {
            Coordinate firstCoordinate = new Coordinate();
            firstCoordinate.X = firstX;
            firstCoordinate.Y = firstY;
            firstCoordinate.Z = firstZ;
            Coordinate secondCoordinate = new Coordinate();
            secondCoordinate.X = secondX;
            secondCoordinate.Y = secondY;
            secondCoordinate.Z = secondZ;
            Bird bird = new Bird(firstCoordinate);
            bird.FlyTo(secondCoordinate);
            Assert.AreEqual(bird.CurrentPosition, secondCoordinate);
        }

        [TestMethod]
        [DataRow(0.1, 0.1, 0.1, 2.1, 0.1, 0.1, 0.01)]
        [DataRow(1, 1, 1, 1, 1, 1, 0)]
        public void PositiveTestOfGetFlyTimeByPlane(double firstX, double firstY, double firstZ, double secondX, double secondY, double secondZ, double result)
        {
            Coordinate firstCoordinate = new Coordinate();
            firstCoordinate.X = firstX;
            firstCoordinate.Y = firstY;
            firstCoordinate.Z = firstZ;
            Coordinate secondCoordinate = new Coordinate();
            secondCoordinate.X = secondX;
            secondCoordinate.Y = secondY;
            secondCoordinate.Z = secondZ;
            Plane plane = new Plane(firstCoordinate);
            Assert.AreEqual(plane.GetFlyTime(secondCoordinate), result);
        }

        [TestMethod]
        [DataRow(1, 1, 1, 1, 1, 61, 1, 66)]
        [DataRow(1, 1, 1, 1, 1, 1, 100, 0)]
        public void PositiveTestOfGetFlyTimeByDrone(double firstX, double firstY, double firstZ, double secondX, double secondY, double secondZ, double speed, double result)
        {
            Coordinate firstCoordinate = new Coordinate();
            firstCoordinate.X = firstX;
            firstCoordinate.Y = firstY;
            firstCoordinate.Z = firstZ;
            Coordinate secondCoordinate = new Coordinate();
            secondCoordinate.X = secondX;
            secondCoordinate.Y = secondY;
            secondCoordinate.Z = secondZ;
            Drone drone = new Drone(firstCoordinate, speed);
            Assert.AreEqual(drone.GetFlyTime(secondCoordinate), result);
        }

        [TestMethod]
        [DataRow(1, 1, 1, 1, 1, 1)]
        [DataRow(1, 1, 1, 10, 10, 10)]
        public void PositiveTestOfGetFlyTimeByBird(double firstX, double firstY, double firstZ, double secondX, double secondY, double secondZ)
        {
            bool success = false;
            Coordinate firstCoordinate = new Coordinate();
            firstCoordinate.X = firstX;
            firstCoordinate.Y = firstY;
            firstCoordinate.Z = firstZ;
            Coordinate secondCoordinate = new Coordinate();
            secondCoordinate.X = secondX;
            secondCoordinate.Y = secondY;
            secondCoordinate.Z = secondZ;
            Bird bird = new Bird(firstCoordinate);
            double methodresult = bird.GetFlyTime(secondCoordinate);
            double result = firstCoordinate.CountCoordinateDifference(secondCoordinate) / bird.Speed;
            if (methodresult - result < double.Epsilon)
            {
                success = true;
            }
            Assert.IsTrue(success);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow(0, 0, 0, 0, 0, 7000, 0)]
        public void NegativeTestOfGetFlyTimeByPlane(double firstX, double firstY, double firstZ, double secondX, double secondY, double secondZ, double result)
        {
            Coordinate firstCoordinate = new Coordinate();
            firstCoordinate.X = firstX;
            firstCoordinate.Y = firstY;
            firstCoordinate.Z = firstZ;
            Coordinate secondCoordinate = new Coordinate();
            secondCoordinate.X = secondX;
            secondCoordinate.Y = secondY;
            secondCoordinate.Z = secondZ;
            Plane plane = new Plane(firstCoordinate);
            Assert.AreEqual(plane.GetFlyTime(secondCoordinate), result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow(0, 0, 0, 0, 0, 0, 0, 0)]
        [DataRow(0, 0, 0, 0, 1000, 0, 1, 0)]
        public void NegativeTestOfGetFlyTimeByDrone(double firstX, double firstY, double firstZ, double secondX, double secondY, double secondZ, double speed, double result)
        {
            Coordinate firstCoordinate = new Coordinate();
            firstCoordinate.X = firstX;
            firstCoordinate.Y = firstY;
            firstCoordinate.Z = firstZ;
            Coordinate secondCoordinate = new Coordinate();
            secondCoordinate.X = secondX;
            secondCoordinate.Y = secondY;
            secondCoordinate.Z = secondZ;
            Drone drone = new Drone(firstCoordinate, speed);
            Assert.AreEqual(drone.GetFlyTime(secondCoordinate), result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow(0, 0, 0, 0, 0, 4000)]
        public void NegativeTestOfGetFlyTimeByBird(double firstX, double firstY, double firstZ, double secondX, double secondY, double secondZ)
        {
            bool success = false;
            Coordinate firstCoordinate = new Coordinate();
            firstCoordinate.X = firstX;
            firstCoordinate.Y = firstY;
            firstCoordinate.Z = firstZ;
            Coordinate secondCoordinate = new Coordinate();
            secondCoordinate.X = secondX;
            secondCoordinate.Y = secondY;
            secondCoordinate.Z = secondZ;
            Bird bird = new Bird(firstCoordinate);
            double result = firstCoordinate.CountCoordinateDifference(secondCoordinate);
            double result1 = result / bird.Speed;
            if (bird.GetFlyTime(secondCoordinate) - result1 < double.Epsilon)
            {
                success = true;
            }
            Assert.IsTrue(success);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow(0, 0, 0, 0, 0, 7000)]
        public void NegativeTestOfFlyToByPlane(double firstX, double firstY, double firstZ, double secondX, double secondY, double secondZ)
        {
            Coordinate firstCoordinate = new Coordinate();
            firstCoordinate.X = firstX;
            firstCoordinate.Y = firstY;
            firstCoordinate.Z = firstZ;
            Coordinate secondCoordinate = new Coordinate();
            secondCoordinate.X = secondX;
            secondCoordinate.Y = secondY;
            secondCoordinate.Z = secondZ;
            Plane plane = new Plane(firstCoordinate);
            plane.FlyTo(secondCoordinate);
            Assert.AreEqual(plane.CurrentPosition, secondCoordinate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow(0, 0, 0, 0, 0, 0, 0)]
        [DataRow(0, 0, 0, 0, 1000, 0, 0)]
        public void NegativeTestOfFlyToByDrone(double firstX, double firstY, double firstZ, double secondX, double secondY, double secondZ, double speed)
        {
            Coordinate firstCoordinate = new Coordinate();
            firstCoordinate.X = firstX;
            firstCoordinate.Y = firstY;
            firstCoordinate.Z = firstZ;
            Coordinate secondCoordinate = new Coordinate();
            secondCoordinate.X = secondX;
            secondCoordinate.Y = secondY;
            secondCoordinate.Z = secondZ;
            Drone drone = new Drone(firstCoordinate, speed);
            drone.FlyTo(secondCoordinate);
            Assert.AreEqual(drone.CurrentPosition, secondCoordinate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow(0, 0, 0, 0, 0, 4000)]
        public void NegativeTestOfFlyToByBird(double firstX, double firstY, double firstZ, double secondX, double secondY, double secondZ)
        {
            Coordinate firstCoordinate = new Coordinate();
            firstCoordinate.X = firstX;
            firstCoordinate.Y = firstY;
            firstCoordinate.Z = firstZ;
            Coordinate secondCoordinate = new Coordinate();
            secondCoordinate.X = secondX;
            secondCoordinate.Y = secondY;
            secondCoordinate.Z = secondZ;
            Bird bird = new Bird(firstCoordinate);
            bird.FlyTo(secondCoordinate);
            Assert.AreEqual(bird.CurrentPosition, secondCoordinate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow(-1, 0, 0, 0, 0, 0, 1)]
        [DataRow(0, -1, 0, 0, 0, 0, 1)]
        [DataRow(0, 0, -1, 0, 0, 0, 1)]
        [DataRow(0, 0, 0, -1, 0, 0, 1)]
        [DataRow(0, 0, 0, 0, -1, 0, 1)]
        [DataRow(0, 0, 0, 0, 0, -1, 1)]
        public void NegativeTestOfCoordinateDifference(double firstX, double firstY, double firstZ, double secondX, double secondY, double secondZ, double result)
        {
            Coordinate firstCoordinate = new Coordinate();
            firstCoordinate.X = firstX;
            firstCoordinate.Y = firstY;
            firstCoordinate.Z = firstZ;
            Coordinate secondCoordinate = new Coordinate();
            secondCoordinate.X = secondX;
            secondCoordinate.Y = secondY;
            secondCoordinate.Z = secondZ;
            Assert.AreEqual(firstCoordinate.CountCoordinateDifference(secondCoordinate), result);
        }
    }
}
