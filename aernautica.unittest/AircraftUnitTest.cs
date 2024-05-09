using aernautica.aircraft;
using aernautica.core;
using NUnit.Framework;

namespace aernautica.unittest {
    public class AircraftUnitTest {
        
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void TestBigBurna() {
            AAircraft aircraft = AircraftFacotory.CreateBigBurna();
            
            Assert.NotNull(aircraft);

            Assert.AreEqual("Big Burna", aircraft.Name);
            Assert.AreEqual(EPlayerType.ORC, aircraft.PlayerType);
            Assert.AreEqual(22, aircraft.PointCost);
            Assert.AreEqual(3, aircraft.Structure);
            Assert.AreEqual(2, aircraft.Throttle);
            Assert.AreEqual(4, aircraft.Manoeuver);
            Assert.AreEqual(4, aircraft.Handling);
            Assert.AreEqual(3, aircraft.MinSpeed);
            Assert.AreEqual(7, aircraft.MaxSpeed);
            Assert.AreEqual(4, aircraft.MaxAltitude);
        }
        
        [Test]
        public void TestVulture() {
            AAircraft aircraft = AircraftFacotory.CreateVulture();
            
            Assert.NotNull(aircraft);

            Assert.AreEqual("Vulture", aircraft.Name);
            Assert.AreEqual(EPlayerType.ORC, aircraft.PlayerType);
            Assert.AreEqual(23, aircraft.PointCost);
            Assert.AreEqual(2, aircraft.Structure);
            Assert.AreEqual(2, aircraft.Throttle);
            Assert.AreEqual(5, aircraft.Manoeuver);
            Assert.AreEqual(3, aircraft.Handling);
            Assert.AreEqual(3, aircraft.MinSpeed);
            Assert.AreEqual(8, aircraft.MaxSpeed);
            Assert.AreEqual(4, aircraft.MaxAltitude);
        }

        [Test]
        public void TestGrotBomma() {
            AAircraft aircraft = AircraftFacotory.CreateGrotBommer();
            
            Assert.NotNull(aircraft);

            Assert.AreEqual("Grot Bommer", aircraft.Name);
            Assert.AreEqual(EPlayerType.ORC, aircraft.PlayerType);
            Assert.AreEqual(28, aircraft.PointCost);
            Assert.AreEqual(6, aircraft.Structure);
            Assert.AreEqual(1, aircraft.Throttle);
            Assert.AreEqual(3, aircraft.Manoeuver);
            Assert.AreEqual(5, aircraft.Handling);
            Assert.AreEqual(2, aircraft.MinSpeed);
            Assert.AreEqual(4, aircraft.MaxSpeed);
            Assert.AreEqual(4, aircraft.MaxAltitude);
        }
        
        [Test]
        public void TestBlueDevil() {
            AAircraft aircraft = AircraftFacotory.CreateBlueDevil();
            
            Assert.NotNull(aircraft);

            Assert.AreEqual("Blue Devil", aircraft.Name);
            Assert.AreEqual(EPlayerType.IMPERIALIS, aircraft.PlayerType);
            Assert.AreEqual(26, aircraft.PointCost);
            Assert.AreEqual(5, aircraft.Structure);
            Assert.AreEqual(1, aircraft.Throttle);
            Assert.AreEqual(3, aircraft.Manoeuver);
            Assert.AreEqual(3, aircraft.Handling);
            Assert.AreEqual(2, aircraft.MinSpeed);
            Assert.AreEqual(5, aircraft.MaxSpeed);
            Assert.AreEqual(5, aircraft.MaxAltitude);
        }
        
        [Test]
        public void TestBlueHellion() {
            AAircraft aircraft = AircraftFacotory.CreateHellion();
            
            Assert.NotNull(aircraft);

            Assert.AreEqual("Hellion", aircraft.Name);
            Assert.AreEqual(EPlayerType.IMPERIALIS, aircraft.PlayerType);
            Assert.AreEqual(26, aircraft.PointCost);
            Assert.AreEqual(2, aircraft.Structure);
            Assert.AreEqual(3, aircraft.Throttle);
            Assert.AreEqual(7, aircraft.Manoeuver);
            Assert.AreEqual(2, aircraft.Handling);
            Assert.AreEqual(2, aircraft.MinSpeed);
            Assert.AreEqual(8, aircraft.MaxSpeed);
            Assert.AreEqual(5, aircraft.MaxAltitude);
        }
        
        [Test]
        public void TestBlueExecutioner() {
            AAircraft aircraft = AircraftFacotory.CreateExecutioner();
            
            Assert.NotNull(aircraft);

            Assert.AreEqual("Executioner", aircraft.Name);
            Assert.AreEqual(EPlayerType.IMPERIALIS, aircraft.PlayerType);
            Assert.AreEqual(23, aircraft.PointCost);
            Assert.AreEqual(3, aircraft.Structure);
            Assert.AreEqual(2, aircraft.Throttle);
            Assert.AreEqual(6, aircraft.Manoeuver);
            Assert.AreEqual(3, aircraft.Handling);
            Assert.AreEqual(2, aircraft.MinSpeed);
            Assert.AreEqual(7, aircraft.MaxSpeed);
            Assert.AreEqual(5, aircraft.MaxAltitude);
        }    
        
        
    }
}