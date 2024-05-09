using aernautica.aircraft;
using aernautica.command;
using aernautica.core;
using NUnit.Framework;

namespace aernautica.unittest {
    public class CommandUnitTest {
        
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void TestBigBurna() {
            AAircraft executioner1 = AircraftFacotory.CreateExecutioner();
            Assert.NotNull(executioner1);

            AAircraft executioner2 = AircraftFacotory.CreateExecutioner();
            Assert.NotNull(executioner2);
            Assert.AreNotEqual(executioner1.Id, executioner2.Id);

            AAircraft bigBurna = AircraftFacotory.CreateBigBurna();
            Assert.NotNull(bigBurna);

            AAircraft grotBommer = AircraftFacotory.CreateGrotBommer();
            Assert.NotNull(grotBommer);
            Assert.AreNotEqual(bigBurna.Id, grotBommer);
            Assert.AreNotEqual(grotBommer.Id, executioner1.Id);
            
            GameEngine gameEngine = GameEngine.GetInstance();

            
            gameEngine.ExecuteCommand(new PlaceAircraftCommand(executioner1, new Point(2, 2, 2),
                EOrientation.NORTH));
            Assert.IsTrue(gameEngine.Fleets.ContainsKey(new Point(2,2,2)));
            Assert.AreSame(executioner1, gameEngine[new Point(2,2,2)]);
            
            gameEngine.ExecuteCommand(new PlaceAircraftCommand(executioner2, new Point(0, 2, 2),
                EOrientation.NORTH));
            Assert.IsTrue(gameEngine.Fleets.ContainsKey(new Point(0,2,2)));
            Assert.AreSame(executioner2, gameEngine[new Point(0,2,2)]);
            
            gameEngine.ExecuteCommand(new MoveAircraftCommand(executioner1, new Point(2,5,4), EOrientation.EAST));
            Assert.IsFalse(gameEngine.Fleets.ContainsKey(new Point(2,2,2)));
            Assert.IsTrue(gameEngine.Fleets.ContainsKey(new Point(2,5,4)));
            Assert.AreSame(executioner1, gameEngine[new Point(2,5,4)]);
            
            
         
        }
        
    }
}