namespace aernautica {
    public class OrcAircraft : AAircraft{
        public OrcAircraft(int id, string name, int pointCost, int structure,  int minSpeed, int maxSpeed, int manoeuver, int throttle, int handling, int maxAltitude) : 
            base(id, name, EPlayerType.ORC, pointCost, structure, minSpeed, maxSpeed,manoeuver, throttle, handling, maxAltitude) {
        }

        public override string FieldOutput() {
            return "O";
        }
    }
}