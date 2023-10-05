using System;
using System.Collections.Generic;

namespace aernautica {
    public abstract class AAircraft : Point {

        public abstract string FieldOutput();
        
        private int _currentSpeed;

        private int _currentManoeuver;

        private int _throttle;

        private int _structure;
        
        private readonly int _id;
        
        private readonly EPlayerType _playerType;

        private readonly string _name;

        private readonly int _pointCost;
        
        private readonly int _minSpeed;

        private readonly int _maxSpeed;

        private readonly int _handling;

        private readonly int _maxAltitude;

        private readonly int _manoeuver;
        
        private Dictionary<EWeaponType, Weapon> _weapons = new Dictionary<EWeaponType, Weapon>();

        private IMoveBehaviour _moveBehaviour = null;

        private IAttackBehaviour _attackBehaviour = null;

        private EOrientation _orientation = EOrientation.NORTH;

        public Weapon this[EWeaponType type] {
            get { return _weapons[type];}
            set { _weapons[type] = value; }
        }

        public int CurrentSpeed {
            get => _currentSpeed;
            set => _currentSpeed = value;
        }

        public int Throttle {
            get => _throttle;
            set => _throttle = value;
        }

        public int Structure {
            get => _structure;
            set => _structure = value;
        }

        public int CurrentManoeuver {
            get => _currentManoeuver;
            set => _currentManoeuver = value;
        }

        public IMoveBehaviour MoveBehaviour {
            get => _moveBehaviour;
            set => _moveBehaviour = value;
        }

        public EOrientation Orientation {
            get => _orientation;
            set => _orientation = value;
        }

        public int PointCost => _pointCost;
        
        public int MinSpeed => _minSpeed;

        public int MaxSpeed => _maxSpeed;

        public int Handling => _handling;

        public string Name => _name;

        public EPlayerType PlayerType => _playerType;

        public int MaxAltitude => _maxAltitude;

        public int Manoeuver => _manoeuver;

        public int Id => _id;

        protected AAircraft(int id, string name, EPlayerType playerType, int pointCost, int structure,  int minSpeed, int maxSpeed, int manoeuver, int throttle, int handling, int maxAltitude) : base(0, 0, 0) {
            _id = id;
            _name = name;
            _pointCost = pointCost;
            _structure = structure;
            _currentSpeed = minSpeed;
            _throttle = throttle;
            _minSpeed = minSpeed;
            _maxSpeed = maxSpeed;
            _manoeuver = manoeuver;
            _handling = handling;
            _maxAltitude = maxAltitude;
            _playerType = playerType;
            
            _moveBehaviour = new DefaultMoveBehaviour(this);
            _attackBehaviour = new DefaultAttackBehaviour(this);
        }

        public bool EntersSpin() {
            return (_currentSpeed < _minSpeed || _currentSpeed > _maxSpeed || Z > _maxAltitude ||
                    _currentManoeuver > _manoeuver );
        }

        public bool IsDestroyed() {
            return this.Z == 0 || this._structure == 0;
        }

        public void Move(Point destination, EOrientation orientation) {
            _moveBehaviour.Move(destination, orientation);
        }

        public void Attack(AAircraft aircraft) {
            _attackBehaviour.Attack(aircraft);
        }

        public void Place(Point destination, EOrientation orientation) {
            X = destination.X;
            Y = destination.Y;
            Z = destination.Z;

            _orientation = orientation;
        }
        
        public bool IsHandlingTestSuccessful() {
            return _handling >= Dice.GetInstance().Roll();
        }

        public Point GetPosition() {
            return new Point(X, Y, Z);
        }

        public override string ToString() {
            return $"{nameof(_id)}: {_id}, {nameof(_name)}: {_name}, position: {X},{Y},{Z}";
        }

        protected bool Equals(AAircraft other) {
            return base.Equals(other) && _id == other._id;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AAircraft) obj);
        }

        public override int GetHashCode() {
            return HashCode.Combine(base.GetHashCode(), _id);
        }
    }
    
}