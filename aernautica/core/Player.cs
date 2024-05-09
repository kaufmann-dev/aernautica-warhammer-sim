using System.Collections.Generic;
using System.Linq;
using aernautica.aircraft;

namespace aernautica.core {
    public class Player {
        
        private readonly List<AAircraft> _fleet = new List<AAircraft>();
        
        private readonly List<AAircraft> _destroyedShips = new List<AAircraft>();

        private readonly EPlayerType _playerType;

        private readonly int _maxFleetCost;
        
        private string _name;


        public AAircraft this[int i] => _fleet[i];

        public string Name {
            get => _name;
            set => _name = value;
        }

        public List<AAircraft> DestroyedShips => _destroyedShips;

        public List<AAircraft> Fleet => _fleet;

        public Player(string name, EPlayerType playerType, int maxFleetCost) {
            _playerType = playerType;
            _maxFleetCost = maxFleetCost;
            _name = name;
        }

        public bool AddAircraft(AAircraft aircraft) {
            if (aircraft != null && IsValid(aircraft: aircraft)) {
                aircraft.Player = this;
                _fleet.Add(aircraft);

                return true;
            }

            return false;
        }
        
        private bool IsValid(AAircraft aircraft) {
            bool isValid = _playerType.Equals(aircraft.PlayerType);
            bool isSustainable = CalculateFleetCost() + aircraft.PointCost <= _maxFleetCost;

            if (!isValid) {
                Logger.GetInstance().Warn("Invalid playertype. Aircraft can't be added to fleet.");
            }


            if(!isSustainable)
                Logger.GetInstance().Warn("aircraft unsustainable. Aircraft can't be added to fleet");
                 
            return isValid && isSustainable;
        }

        public int CalculateFleetCost() {
            return (from a in _fleet select a.PointCost).Sum();
        }

        public int CalculateVictoryPoints() {
            return (from a in _destroyedShips select a.PointCost).Sum();
        }
    }
}