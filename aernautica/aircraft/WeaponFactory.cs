using System.Collections.Generic;

namespace aernautica.aircraft {
    public class WeaponFactory {

        
        public static Weapon CreateQuadBigShoota() {
            Weapon weapon = new Weapon("QuadBigShoota", 5, new List<EFireDirection>() {EFireDirection.FRONT}) {
                [ERangeType.SHORT] = 8, [ERangeType.MEDIUM] = 4, [ERangeType.LONG] = 0
            };

            return weapon;
        }

        public static Weapon CreateTurretBigShoota() {
            Weapon weapon = new Weapon("TurretBigShoota", 5,
                new List<EFireDirection>() {
                    EFireDirection.UP,
                    EFireDirection.REAR,
                    EFireDirection.LEFT_SIDE,
                    EFireDirection.RIGHT_SIDE
                }) {[ERangeType.SHORT] = 3, [ERangeType.MEDIUM] = 1, [ERangeType.LONG] = 0};

            return weapon;
        }

        public static Weapon CreateTailGun() {
            Weapon weapon = new Weapon("TailGun", 6, new List<EFireDirection>() {EFireDirection.REAR}) {
                [ERangeType.SHORT] = 1, [ERangeType.MEDIUM] = 0, [ERangeType.LONG] = 0
            };

            return weapon;
        }

        public static Weapon CreatePortTurret() {
            Weapon weapon = new Weapon("PortTurret", 5,
                new List<EFireDirection>() {EFireDirection.UP, EFireDirection.LEFT_SIDE}) {
                [ERangeType.SHORT] = 2, [ERangeType.MEDIUM] = 1, [ERangeType.LONG] = 0
            };

            return weapon;
        }

        public static Weapon CreateStarboardTurret() {
            Weapon weapon = new Weapon("PortTurret", 5,
                new List<EFireDirection>() {EFireDirection.UP, EFireDirection.RIGHT_SIDE}) {
                [ERangeType.SHORT] = 2, [ERangeType.MEDIUM] = 1, [ERangeType.LONG] = 0
            };

            return weapon;
        }

        public static Weapon CreateLascannon() {
            Weapon weapon = new Weapon("Lascannon", 2, new List<EFireDirection>() {EFireDirection.FRONT}) {
                [ERangeType.SHORT] = 0, [ERangeType.MEDIUM] = 2, [ERangeType.LONG] = 1
            };

            return weapon;
        }

        public static Weapon CreateDorsalTurret() {
            Weapon weapon = new Weapon("Dorsal Turret", 5,
                new List<EFireDirection>() {
                    EFireDirection.REAR, EFireDirection.FRONT, EFireDirection.LEFT_SIDE, EFireDirection.RIGHT_SIDE,
                    EFireDirection.UP
                }) {[ERangeType.SHORT] = 3, [ERangeType.MEDIUM] = 2, [ERangeType.LONG] = 0};

            return weapon;
        }

        public static Weapon CreateRearTurret() {
            Weapon weapon = new Weapon("Rear Turret", 5, new List<EFireDirection>() {EFireDirection.REAR})
                {[ERangeType.SHORT] = 3, [ERangeType.MEDIUM] = 2, [ERangeType.LONG] = 0};

            return weapon;
        }

        public static Weapon CreateTwinMultilaser() {
            Weapon weapon = new Weapon("Twin Multilaser", 5, new List<EFireDirection>() {EFireDirection.FRONT})
                {[ERangeType.SHORT] = 4, [ERangeType.MEDIUM] = 6, [ERangeType.LONG] = 2};

            return weapon;
        }

        public static Weapon CreateTwinLascannon() {
            Weapon weapon = new Weapon("Twin Lascannon", 2, new List<EFireDirection>() {EFireDirection.FRONT}) {
                [ERangeType.SHORT] = 0, [ERangeType.MEDIUM] = 2, [ERangeType.LONG] = 1
            };

            return weapon;
        }

        public static Weapon CreateQuadAutocannon() {
            Weapon weapon = new Weapon("Quad Autocannon", 4, new List<EFireDirection>() {EFireDirection.FRONT})
                {[ERangeType.SHORT] = 2, [ERangeType.MEDIUM] = 6, [ERangeType.LONG] = 0};

            return weapon;
        }
    }
}