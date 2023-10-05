namespace aernautica {
    public class MovementCost {
        
        private readonly int _speed;
        private readonly int _manoeuver;
        private readonly int _stepCount;

        public int Speed => _speed;

        public int Manoeuver => _manoeuver;

        public int StepCount => _stepCount;
        
        public MovementCost(int speed, int manoeuver, int stepCount) {
            _speed = speed;
            _manoeuver = manoeuver;
            _stepCount = stepCount;
        }
        
    }
}