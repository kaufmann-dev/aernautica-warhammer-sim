namespace aernautica {
    public class PlaceAircraftCommand : ICommand {

        private readonly AAircraft _aircraft;

        private readonly Point _destination;

        private readonly EOrientation _orientation;

        public PlaceAircraftCommand(AAircraft aircraft, Point destination, EOrientation orientation) {
            _aircraft = aircraft;
            _destination = destination;
            _orientation = orientation;
        }

        public void Execute() {
            GameEngine gameEngine = GameEngine.GetInstance();
            
            if (gameEngine.Fleets.ContainsKey(_destination)) {
                Logger.GetInstance().Info("Field already occupied: " + gameEngine[_destination].ToString());
                return;
            }
            
            _aircraft.Place(_destination,_orientation);
            gameEngine[_destination] = _aircraft;
            
            Logger.GetInstance().Info("placed aircraft: " + _aircraft.ToString());
        }
    }
}