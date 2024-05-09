using System;
using System.Collections.Generic;
using aernautica.aircraft.behaviour;
using aernautica.core;

namespace aernautica.aircraft {
    public abstract class AAircraft : Point {
        public abstract string FieldOutput();

        private int _currentSpeed;

        private int _currentManoeuver;

        private int _throttle;

        private int _structure;

        private Player _player;

        private readonly int _id;

        private readonly EPlayerType _playerType;

        private readonly Dictionary<EOrientation, Dictionary<EOrientation, EFireDirection>> _fireArcs = null;

        private readonly string _name;

        private readonly int _pointCost;

        private readonly int _minSpeed;

        private readonly int _maxSpeed;

        private readonly int _handling;

        private readonly int _maxAltitude;

        private readonly int _manoeuver;

        private Dictionary<EFireDirection, List<Weapon>> _weapons = new Dictionary<EFireDirection, List<Weapon>>();

        private IMoveBehaviour _moveBehaviour = null;

        private EOrientation _orientation = EOrientation.NORTH;

        public List<Weapon> this[EFireDirection direction] {
            get { return _weapons[direction]; }
            set { _weapons[direction] = value; }
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
            set => _structure = Math.Max(0, value);
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

        public Player Player {
            get => _player;
            set => _player = value;
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

        protected AAircraft(int id, string name, EPlayerType playerType, int pointCost, int structure, int minSpeed,
            int maxSpeed, int manoeuver, int throttle, int handling, int maxAltitude) : base(0, 0, 0) {
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

            _fireArcs = new Dictionary<EOrientation, Dictionary<EOrientation, EFireDirection>>() {
                [EOrientation.NORTH] = new Dictionary<EOrientation, EFireDirection>() {
                    [EOrientation.NORTH] = EFireDirection.FRONT,
                    [EOrientation.EAST] = EFireDirection.RIGHT_SIDE,
                    [EOrientation.SOUTH] = EFireDirection.REAR,
                    [EOrientation.WEST] = EFireDirection.LEFT_SIDE
                },
                [EOrientation.EAST] = new Dictionary<EOrientation, EFireDirection>() {
                    [EOrientation.NORTH] = EFireDirection.LEFT_SIDE,
                    [EOrientation.EAST] = EFireDirection.FRONT,
                    [EOrientation.SOUTH] = EFireDirection.RIGHT_SIDE,
                    [EOrientation.WEST] = EFireDirection.REAR
                },
                [EOrientation.SOUTH] = new Dictionary<EOrientation, EFireDirection>() {
                    [EOrientation.NORTH] = EFireDirection.REAR,
                    [EOrientation.EAST] = EFireDirection.LEFT_SIDE,
                    [EOrientation.SOUTH] = EFireDirection.FRONT,
                    [EOrientation.WEST] = EFireDirection.RIGHT_SIDE
                },
                [EOrientation.WEST] = new Dictionary<EOrientation, EFireDirection>() {
                    [EOrientation.NORTH] = EFireDirection.RIGHT_SIDE,
                    [EOrientation.EAST] = EFireDirection.REAR,
                    [EOrientation.SOUTH] = EFireDirection.LEFT_SIDE,
                    [EOrientation.WEST] = EFireDirection.FRONT
                }
            };
        }

        public bool EntersSpin() {
            return (_currentSpeed < _minSpeed || _currentSpeed > _maxSpeed || Z > _maxAltitude ||
                    _currentManoeuver > _manoeuver);
        }

        public bool IsDestroyed() {
            return this.Z == 0 || this._structure == 0;
        }

        public void Move(Point destination, EOrientation orientation) {
            _moveBehaviour.Move(destination, orientation);
        }

        public void Attack(AAircraft target) {
            if (!HasDirectConnection(target)) {
                Logger.GetInstance().Info("no direct connection to target");
                return;
            }
            
            int distance = CalculateDistance(target);
            if (distance > Weapon.LONG_RANGE) {
                Logger.GetInstance().Info("target out of range");
            }
            
            EFireDirection fireDirection = _fireArcs[_orientation][CalculateBearing(target)];

            foreach (var weapon in _weapons[fireDirection]) {
                weapon.Fire(target, distance, Math.Abs(Z - target.Z));
            }

            if (target.IsDestroyed()) {
                Logger.GetInstance().Info("target destroyed");
                
                GameEngine.GetInstance().Fleets.Remove(target.GetPosition());
                target.Player?.Fleet.Remove(target);

                Player?.DestroyedShips.Add(target);
            }
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