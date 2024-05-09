using System.Collections.Generic;
using aernautica.core;

namespace aernautica.aircraft {
    public class Weapon {
        
        public const int SHORT_RANGE = 4;

        public const int MEDIUM_RANGE = 7;

        public const int LONG_RANGE = 10;

        private string _name;

        private readonly List<EFireDirection> _directions = new List<EFireDirection>();

        private readonly Dictionary<ERangeType, int> _firepower = new Dictionary<ERangeType, int>();

        private readonly int _damage;

        public int this[ERangeType type] {
            get => _firepower[type];
            set => _firepower[type] = value;
        }

        public List<EFireDirection> Directions => _directions;

        public int Damage => _damage;

        public Weapon(string name, int damage, List<EFireDirection> directions) {
            _name = name;
            _damage = damage;

            _directions.AddRange(directions);
        }

        public void Fire(AAircraft target, int distance, int heightDifference) {
            int diceAmount = _firepower[ToRangeType(distance)];
            
            Stack<int> diceRolls = Dice.GetInstance().RollDices(distance);
            int hits = 0;

            foreach (var diceRoll in diceRolls) {
                if (isHit(diceRoll, heightDifference)) ++hits;
            }

   
            target.Structure -= hits;
            Logger.GetInstance().Info($"scored hits: {hits} target structure: {target.Structure}");
        }

        public bool isHit(int diceResult, int heightDifference) {
            bool isHit = diceResult >= _damage + heightDifference;

            Logger.GetInstance()
                .Info(
                    $"isHit: {isHit}, required: {_damage + heightDifference}  diceResult: {diceResult} ");

            return isHit;
        }

        public ERangeType ToRangeType(int distance) {
            if (distance > 0 && distance <= Weapon.SHORT_RANGE)
                return ERangeType.SHORT;

            if (distance > Weapon.SHORT_RANGE && distance <= Weapon.MEDIUM_RANGE)
                return ERangeType.MEDIUM;

            if (distance > Weapon.MEDIUM_RANGE && distance <= Weapon.LONG_RANGE)
                return ERangeType.LONG;

            return ERangeType.INVALID;
        }
    }
}