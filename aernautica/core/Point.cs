using System;
using System.Collections.Generic;
using aernautica.aircraft;

namespace aernautica.core {
    public class Point {
        private int _x;
        private int _y;
        private int _z;

        public int X {
            get => _x;
            set {
                if (IsValueLegal(value))
                    _x = value;
            }
        }

        public int Y {
            get => _y;
            set {
                if (IsValueLegal(value)) _y = value;
            }
        }

        public int Z {
            get => _z;
            set {
                if (IsValueLegal(value)) _z = value;
            }
        }

        public Point(int x, int y, int z) {
            X = x;
            Y = y;
            Z = z;
        }

        private bool IsValueLegal(int value) {
            if (value < 0) throw new ArgumentException("value must b positive");
            return true;
        }

        public bool IsDiagonalNeighbour(Point p) {
            return Math.Abs(_x - p.X) == 1 && Math.Abs(_y - p.Y) == 1;
        }

        public bool IsDirectNeighbour(Point p) {
            int deltaX = Math.Abs(_x - p._x);
            int deltaY = Math.Abs(_y - p._y);

            return deltaX <= 1 && deltaY <= 1 && deltaX + deltaY == 1;
        }

        public bool HasSameHeight(Point p) {
            return _z == p.Z;
        }

        public List<Point> CalculateRoute(Point destination) {
            List<Point> route = new List<Point>();

            int xStep = (_x == destination.X) ? 0 : (_x < destination.X) ? 1 : -1;
            int yStep = (_y == destination.Y) ? 0 : (_y < destination.Y) ? 1 : -1;
            int zStep = (_z == destination.Z) ? 0 : (_z < destination.Z) ? 1 : -1;

            int diffX = Math.Abs(this._x - destination.X);
            int diffY = Math.Abs(this._y - destination.Y);
            int diffZ = Math.Min(Math.Max(diffX, diffY), Math.Abs(this._z - destination.Z));

            for (int i = 1, j = 1, k = 1, step = 0; step < Math.Max(diffX, diffY); step++) {
                route.Add(new Point(_x + (i * xStep), _y + (j * yStep), _z + (k * zStep)));

                if (i < diffX) ++i;
                if (j < diffY) ++j;
                if (k < diffZ) ++k;
            }

            return route;
        }

        protected bool Equals(Point other) {
            return _x == other._x && _y == other._y && _z == other._z;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point) obj);
        }

        public override int GetHashCode() {
            return HashCode.Combine(_x, _y, _z);
        }

        public bool HasDirectConnection(Point destination) {
            return X == destination.X || Y == destination.Y;
        }

        public int CalculateDistance(Point destination) {
            return (int)Math.Sqrt(Math.Pow(destination.X - X, 2) + Math.Pow(destination.Y - Y, 2) + Math.Pow(destination.Z - Z, 2));
        }

        public EOrientation CalculateBearing(Point destination) {
            if (destination.Y > Y)
                return EOrientation.SOUTH;
            
            if (destination.Y < Y)
                return EOrientation.NORTH;

            if (destination.X > X)
                return EOrientation.WEST;
            
            if (destination.X < X)
                return EOrientation.EAST;
            
            return EOrientation.VOID;
        }

        public override string ToString() {
            return $"{nameof(_x)}: {_x}, {nameof(_y)}: {_y}, {nameof(_z)}: {_z}";
        }
    }
}