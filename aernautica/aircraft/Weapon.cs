using System.Collections.Generic;

namespace aernautica {
    public class Weapon {

        public const int SHORT_RANGE = 4;

        public const int MEDIUM_RANGE = 7;

        public const int LONG_RANGE = 10;

        private string _name;
        
        private readonly List<EFireDirection> _directions = new List<EFireDirection>();
        
        private readonly Dictionary<ERangeType, int> _firepower = new Dictionary<ERangeType, int>();

        private readonly int _damage;

        public int this[ERangeType type] {
            get { return _firepower[type]; }
            set { _firepower[type] = value; }
        }

        public List<EFireDirection> Directions => _directions;

        public int Damage => _damage;

        public Weapon(string name, int damage, List<EFireDirection> directions) {
            _name = name;
            _damage = damage;
            
            _directions.AddRange(directions);
        }
    }
}