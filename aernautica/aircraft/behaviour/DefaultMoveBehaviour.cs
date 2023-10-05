using System.Collections.Generic;

namespace aernautica {
    public class DefaultMoveBehaviour : AMoveBehaviour {
        public DefaultMoveBehaviour(AAircraft aircraft) : base(aircraft) {
        }

        public MovementCost CalculateMovementCost(List<Point> route) {
            if (route.Count == 0)
                return new MovementCost(0, 0, 0);

            Point currentPoint = _aircraft;
            Point nextPoint = route[0];

            int speed = 0;
            int manoeuver = 0;
            int stepCount = 0;

            for (int i = 0; i < route.Count; i++) {
                if (currentPoint.IsDirectNeighbour(nextPoint))
                    ++speed;

                if (currentPoint.IsDiagonalNeighbour(nextPoint)) {
                    ++speed;
                    ++manoeuver;
                }

                if (!currentPoint.HasSameHeight(nextPoint))
                    ++speed;

                ++stepCount;

                if (i + 1 < route.Count) {
                    currentPoint = nextPoint;
                    nextPoint = route[i + 1];
                }
            }

            return new MovementCost(speed, manoeuver, stepCount);
        }

        public override void Move(Point destination, EOrientation orientation) {
            List<Point> route = _aircraft.CalculateRoute(destination);
            _aircraft.Orientation = orientation;
            
            if (route.Count > 0) {
                MovementCost movementCost = CalculateMovementCost(route);
                Point reachedPoint = route[^1];

                _aircraft.X = reachedPoint.X;
                _aircraft.Y = reachedPoint.Y;
                _aircraft.Z = reachedPoint.Z;

                _aircraft.CurrentSpeed -= movementCost.Speed;
                _aircraft.CurrentManoeuver = movementCost.Manoeuver;

                if (_aircraft.EntersSpin()) {
                    _aircraft.MoveBehaviour = new SpinMoveBehaviour(_aircraft);

                    _aircraft.CurrentSpeed = _aircraft.MinSpeed;
                    _aircraft.CurrentManoeuver = 0;
                }
            }
        }
    }
}