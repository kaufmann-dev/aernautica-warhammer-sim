namespace aernautica {
    public class ImperialisAircraft : AAircraft {
        public ImperialisAircraft(int id, string name, int pointCost, int structure, 
            int minSpeed, int maxSpeed, int manoeuver, int throttle, int handling, int maxAltitude) : 
            base(id, name, EPlayerType.IMPERIALIS, pointCost, structure, minSpeed, maxSpeed, manoeuver,throttle, handling, maxAltitude) {
        }

        public override string FieldOutput() {
            return "I";
        }
    }
}