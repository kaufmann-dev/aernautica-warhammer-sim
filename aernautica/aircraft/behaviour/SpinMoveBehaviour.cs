using aernautica.core;

namespace aernautica.aircraft.behaviour {
    public class SpinMoveBehaviour : AMoveBehaviour {
        public SpinMoveBehaviour(AAircraft aircraft) : base(aircraft) {
        }

        public override void Move(Point destination, EOrientation orientation) {
            if (!_aircraft.IsDestroyed()) {
                if (_aircraft.IsHandlingTestSuccessful()) {
                    _aircraft.MoveBehaviour = new DefaultMoveBehaviour(_aircraft);
                    _aircraft.CurrentSpeed = _aircraft.MinSpeed;
                    _aircraft.CurrentManoeuver = 0;
                }
                else {
                    --_aircraft.Z;
                }
            }
        }
    }
}