using System.Collections.Generic;
using aernautica.aircraft;
using aernautica.aircraft.behaviour;
using aernautica.core;
using NUnit.Framework;

namespace aernautica.unittest {
    public class MoveBehaviourTest {
        
        [SetUp]
        public void Setup() {
        }


        [Test]
        public void TestCalculateMoveCost() {
            AAircraft aircraft = AircraftFacotory.CreateExecutioner();
            Assert.NotNull(aircraft);
            
            DefaultMoveBehaviour moveBehaviour = new DefaultMoveBehaviour(aircraft);
            List<Point> route = aircraft.CalculateRoute(new Point(1, 1, 1));
            
            Assert.AreEqual(0, aircraft.X);
            Assert.AreEqual(0, aircraft.Y);
            Assert.AreEqual(0, aircraft.Z);
            
            MovementCost movementCost = moveBehaviour.CalculateMovementCost(route);

            Assert.AreEqual(2,movementCost.Speed);
            Assert.AreEqual(1,movementCost.Manoeuver);
            Assert.AreEqual(1,movementCost.StepCount);

            List<Point> route2 = aircraft.CalculateRoute(new Point(3, 3, 5));
            MovementCost movementCost2 = moveBehaviour.CalculateMovementCost(route2);

            Assert.AreEqual(6,movementCost2.Speed);
            Assert.AreEqual(3,movementCost2.Manoeuver);
            Assert.AreEqual(3,movementCost2.StepCount);
            
            MovementCost movementCost3 = moveBehaviour.CalculateMovementCost(new List<Point>());
            
            Assert.AreEqual(0,movementCost3.Speed);
            Assert.AreEqual(0,movementCost3.Manoeuver);
            Assert.AreEqual(0,movementCost3.StepCount);
        }

        [Test]
        public void TestAircraftMove() {
            AAircraft aircraft = AircraftFacotory.CreateHellion();
            
            Assert.NotNull(aircraft);
            
            Assert.AreEqual(0, aircraft.X);
            Assert.AreEqual(0, aircraft.Y);
            Assert.AreEqual(0, aircraft.Z);
            
            aircraft.CurrentSpeed = 5;
            aircraft.Z = 3;
            
            Assert.True(aircraft.CurrentSpeed >= aircraft.MinSpeed);
            Assert.True(aircraft.CurrentSpeed <= aircraft.MaxSpeed);
            Assert.True(aircraft.Z <= aircraft.MaxAltitude);
            Assert.True(aircraft.CurrentManoeuver < aircraft.Manoeuver);
            
            Assert.False(aircraft.EntersSpin());
            aircraft.Move(new Point(2,2,2), EOrientation.WEST);
            
            Assert.True(aircraft.CurrentSpeed >= aircraft.MinSpeed);
            Assert.True(aircraft.CurrentSpeed <= aircraft.MaxSpeed);
            Assert.True(aircraft.Z <= aircraft.MaxAltitude);
            Assert.True(aircraft.CurrentManoeuver <= aircraft.Manoeuver);
            
            Assert.AreEqual(2, aircraft.X);
            Assert.AreEqual(2, aircraft.Y);
            Assert.AreEqual(2, aircraft.Z);
            Assert.AreEqual(2, aircraft.CurrentSpeed);
            
            Assert.False(aircraft.EntersSpin());

        }
        
    }
}