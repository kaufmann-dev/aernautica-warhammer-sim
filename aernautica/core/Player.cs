using System.Collections.Generic;
using System.Linq;

namespace aernautica {
    public class Player {
        
        private readonly List<AAircraft> _fleet = new List<AAircraft>();

        private readonly EPlayerType _playerType;

        private readonly int _maxFleetCost;
        
        private string _name;


        public AAircraft this[int i] => _fleet[i];

        public string Name {
            get => _name;
            set => _name = value;
        }

        public Player(string name, EPlayerType playerType, int maxFleetCost) {
            _playerType = playerType;
            _maxFleetCost = maxFleetCost;
            _name = name;
        }

        public void AddAircraft(AAircraft aircraft) {
            if(aircraft != null && IsValid(aircraft: aircraft))
                _fleet.Add(aircraft);
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
    }
}