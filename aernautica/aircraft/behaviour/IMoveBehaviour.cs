using aernautica.core;

namespace aernautica.aircraft.behaviour {
    public interface IMoveBehaviour {

        public void Move(Point destination, EOrientation orientation);

    }
}