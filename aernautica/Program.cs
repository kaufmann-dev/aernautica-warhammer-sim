using System;
using aernautica.aircraft;
using aernautica.command;
using aernautica.core;

namespace aernautica {
    class Program {
        static void Main(string[] args) {
            AAircraft executioner = AircraftFacotory.CreateExecutioner();
            AAircraft hellion = AircraftFacotory.CreateHellion();

            AAircraft bigBurna = AircraftFacotory.CreateBigBurna();
            AAircraft grotBommer = AircraftFacotory.CreateGrotBommer();
            
            GameEngine gameEngine = GameEngine.GetInstance();

            
            gameEngine.ExecuteCommand(new PlaceAircraftCommand(executioner, new Point(2, 2, 2),
                EOrientation.NORTH));
            gameEngine.ExecuteCommand(new PlaceAircraftCommand(hellion, new Point(0, 2, 2),
                EOrientation.NORTH));
            
            gameEngine.ExecuteCommand(new PlaceAircraftCommand(bigBurna, new Point(2, 6, 2),
                EOrientation.NORTH));
            gameEngine.ExecuteCommand(new PlaceAircraftCommand(grotBommer, new Point(0, 6, 3),
                EOrientation.NORTH));

            gameEngine.DisplayPlayfield();
            
            gameEngine.ExecuteCommand(new MoveAircraftCommand(bigBurna, new Point(2,4,2), EOrientation.SOUTH));
            gameEngine.ExecuteCommand(new MoveAircraftCommand(executioner, new Point(2,3,2), EOrientation.SOUTH));
            gameEngine.DisplayPlayfield();
            
            gameEngine.ExecuteCommand(new AttackAircraftCommand(bigBurna, executioner));
            gameEngine.ExecuteCommand(new AttackAircraftCommand(executioner, bigBurna));
            
        }
    }
}