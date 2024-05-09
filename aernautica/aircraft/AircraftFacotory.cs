using System.Collections.Generic;

namespace aernautica.aircraft {
    public class AircraftFacotory {
        public static AAircraft CreateBigBurna() {
            OrcAircraft aircraft = new OrcAircraft(
                Sequencer.GetInstance().IncrementAndGet(),
                "Big Burna", 22,3,
                3, 7, 4, 2, 4, 4);

            aircraft[EFireDirection.FRONT] = new List<Weapon>(){WeaponFactory.CreateQuadBigShoota()};
            aircraft[EFireDirection.REAR] = new List<Weapon>(){WeaponFactory.CreateTurretBigShoota(), WeaponFactory.CreateTailGun()};
            aircraft[EFireDirection.LEFT_SIDE] = new List<Weapon>(){WeaponFactory.CreateTurretBigShoota()};
            aircraft[EFireDirection.RIGHT_SIDE] = new List<Weapon>(){WeaponFactory.CreateTurretBigShoota()};

            return aircraft;
        }

        public static AAircraft CreateVulture() {
            OrcAircraft aircraft = new OrcAircraft(
                Sequencer.GetInstance().IncrementAndGet(),
                "Vulture", 23,2,
                3, 8, 5, 2, 3, 4
            );

            aircraft[EFireDirection.FRONT] = new List<Weapon>(){WeaponFactory.CreateQuadBigShoota()};
            aircraft[EFireDirection.REAR] = new List<Weapon>();
            aircraft[EFireDirection.LEFT_SIDE] = new List<Weapon>();
            aircraft[EFireDirection.RIGHT_SIDE] = new List<Weapon>();

            return aircraft;
        }

        public static AAircraft CreateGrotBommer() {
            OrcAircraft aircraft = new OrcAircraft(
                Sequencer.GetInstance().IncrementAndGet(),
                "Grot Bommer", 28,6, 2,
                4, 3, 1, 5, 4
            );

            aircraft[EFireDirection.FRONT] = new List<Weapon>(){WeaponFactory.CreateQuadBigShoota()};
            aircraft[EFireDirection.REAR] = new List<Weapon>(){};
            aircraft[EFireDirection.LEFT_SIDE] = new List<Weapon>(){WeaponFactory.CreatePortTurret()};
            aircraft[EFireDirection.RIGHT_SIDE] = new List<Weapon>(){WeaponFactory.CreateStarboardTurret()};

            return aircraft;
        }

        public static AAircraft CreateBlueDevil() {
            ImperialisAircraft aircraft = new ImperialisAircraft(
                Sequencer.GetInstance().IncrementAndGet(),
                "Blue Devil",26, 5,
                2, 5, 3, 1,
                3, 5
            );

            aircraft[EFireDirection.FRONT] = new List<Weapon>(){WeaponFactory.CreateLascannon(), WeaponFactory.CreateDorsalTurret()};
            aircraft[EFireDirection.REAR] = new List<Weapon>(){WeaponFactory.CreateDorsalTurret(), WeaponFactory.CreateRearTurret()};
            aircraft[EFireDirection.LEFT_SIDE] = new List<Weapon>(){WeaponFactory.CreateDorsalTurret()};
            aircraft[EFireDirection.RIGHT_SIDE] = new List<Weapon>(){WeaponFactory.CreateDorsalTurret()};
 

            return aircraft;
        }

        public static AAircraft CreateHellion() {
            ImperialisAircraft aircraft = new ImperialisAircraft(
                Sequencer.GetInstance().IncrementAndGet(),
                "Hellion", 26, 2, 2,
                8, 7, 3, 2, 5);

            aircraft[EFireDirection.FRONT] = new List<Weapon>(){WeaponFactory.CreateTwinMultilaser()};
            aircraft[EFireDirection.REAR] = new List<Weapon>(){};
            aircraft[EFireDirection.LEFT_SIDE] = new List<Weapon>(){};
            aircraft[EFireDirection.RIGHT_SIDE] = new List<Weapon>(){};

            return aircraft;
        }

        public static AAircraft CreateExecutioner() {
            ImperialisAircraft aircraft = new ImperialisAircraft(
                Sequencer.GetInstance().IncrementAndGet(),
                "Executioner", 23, 3, 2,
                7, 6, 2, 3, 5);

            aircraft[EFireDirection.FRONT] = new List<Weapon>(){WeaponFactory.CreateQuadAutocannon(), WeaponFactory.CreateTwinLascannon()};
            aircraft[EFireDirection.REAR] = new List<Weapon>();
            aircraft[EFireDirection.LEFT_SIDE] = new List<Weapon>();
            aircraft[EFireDirection.RIGHT_SIDE] = new List<Weapon>();

            return aircraft;
        }
    }
}