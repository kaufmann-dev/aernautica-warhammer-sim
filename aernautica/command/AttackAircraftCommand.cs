using aernautica.aircraft;
using aernautica.core;

namespace aernautica.command {
    public class AttackAircraftCommand : ICommand {

        private AAircraft _aircraft;

        private AAircraft _target;
        
        public AttackAircraftCommand(AAircraft aircraft, AAircraft target) {
            _aircraft = aircraft;
            _target = target;
        }

        public void Execute() {
            if (_aircraft.PlayerType.Equals(_target.PlayerType)) {
                Logger.GetInstance().Warn("target is part of own fleet");
                return;
            }
            
            Logger.GetInstance().Info($"attacker: {_aircraft.Name} target: {_target.Name}");
            _aircraft.Attack(_target);
        }
    }
}