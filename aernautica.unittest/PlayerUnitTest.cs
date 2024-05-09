using System.Collections.Generic;
using aernautica.aircraft;
using aernautica.core;
using NUnit.Framework;

namespace aernautica.unittest {
    public class PlayerUnitTest {
        
        [SetUp]
        public void Setup() {
        }


        [Test]
        public void TestAddAircraft() {
            Player imperialisPlayer = new Player("the minister", EPlayerType.IMPERIALIS, 80);
            
            Stack<AAircraft> fleet = new Stack<AAircraft>();

            for (int i = 0; i < 4; i++) {
                fleet.Push(AircraftFacotory.CreateHellion());
            }

            for (int i = 0; i < 3; i++) {
                imperialisPlayer.AddAircraft(fleet.Pop());
            }
            
            Assert.AreEqual(78, imperialisPlayer.CalculateFleetCost());
            
            imperialisPlayer.AddAircraft(AircraftFacotory.CreateHellion());
            Assert.AreEqual(78, imperialisPlayer.CalculateFleetCost());
            
        }
        
    }
}