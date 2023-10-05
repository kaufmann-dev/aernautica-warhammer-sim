namespace aernautica {
    public abstract class AMoveBehaviour : IMoveBehaviour {

        protected AAircraft _aircraft;
        
        public abstract void Move(Point destination, EOrientation orientation);

        protected AMoveBehaviour(AAircraft aircraft) {
            _aircraft = aircraft;
        }
    }
}