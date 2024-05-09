using aernautica.aircraft;
using aernautica.core;

namespace aernautica.command {
    public class MoveAircraftCommand : ICommand {

        private AAircraft _aircraft;

        private Point _destination;

        private EOrientation _orientation;

        public MoveAircraftCommand(AAircraft aircraft, Point destination, EOrientation orientation) {
            _aircraft = aircraft;
            _destination = destination;
            _orientation = orientation;
        }

        public void Execute() {
            GameEngine gameEngine = GameEngine.GetInstance();

            if (!gameEngine.IsMoveLegal(_destination)) {
                Logger.GetInstance().Info("move not legal: " + _destination.ToString());
                return;
            }

            gameEngine.Fleets.Remove(_aircraft.GetPosition());
            _aircraft.Move(_destination, _orientation);

            gameEngine[_destination] = _aircraft;
            Logger.GetInstance().Info($"moved aircraft {_aircraft.ToString()}");
        }
    }
}