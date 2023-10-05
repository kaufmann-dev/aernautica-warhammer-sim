namespace aernautica {
    public class AircraftFacotory {
        public static AAircraft CreateBigBurna() {
            OrcAircraft aircraft = new OrcAircraft(
                Sequencer.GetInstance().IncrementAndGet(),
                "Big Burna", 22,3,
                3, 7, 4, 2, 4, 4);

            aircraft[EWeaponType.QUAD_BIG_SHOOTA] = WeaponFactory.CreateQuadBigShoota();
            aircraft[EWeaponType.TURRET_BIG_SHOOTA] = WeaponFactory.CreateTurretBigShoota();
            aircraft[EWeaponType.TAIL_GUN] = WeaponFactory.CreateTailGun();

            return aircraft;
        }

        public static AAircraft CreateVulture() {
            OrcAircraft aircraft = new OrcAircraft(
                Sequencer.GetInstance().IncrementAndGet(),
                "Vulture", 23,2,
                3, 8, 5, 2, 3, 4
            );

            aircraft[EWeaponType.QUAD_BIG_SHOOTA] = WeaponFactory.CreateQuadBigShoota();

            return aircraft;
        }

        public static AAircraft CreateGrotBommer() {
            OrcAircraft aircraft = new OrcAircraft(
                Sequencer.GetInstance().IncrementAndGet(),
                "Grot Bommer", 28,6, 2,
                4, 3, 1, 5, 4
            );

            aircraft[EWeaponType.QUAD_BIG_SHOOTA] = WeaponFactory.CreateQuadBigShoota();
            aircraft[EWeaponType.PORT_TURRET] = WeaponFactory.CreatePortTurret();
            aircraft[EWeaponType.STARBOARD_TURRET] = WeaponFactory.CreateStarboardTurret();

            return aircraft;
        }

        public static AAircraft CreateBlueDevil() {
            ImperialisAircraft aircraft = new ImperialisAircraft(
                Sequencer.GetInstance().IncrementAndGet(),
                "Blue Devil",26, 5,
                2, 5, 3, 1,
                3, 5
            );

            aircraft[EWeaponType.LASCANNON] = WeaponFactory.CreateLascannon();
            aircraft[EWeaponType.DORSAL_TURRET] = WeaponFactory.CreateDorsalTurret();
            aircraft[EWeaponType.REAR_TURRET] = WeaponFactory.CreateRearTurret();

            return aircraft;
        }

        public static AAircraft CreateHellion() {
            ImperialisAircraft aircraft = new ImperialisAircraft(
                Sequencer.GetInstance().IncrementAndGet(),
                "Hellion", 26, 2, 2,
                8, 7, 3, 2, 5);

            aircraft[EWeaponType.TWIN_MULIT_LASER] = WeaponFactory.CreateTwinMultilaser();

            return aircraft;
        }

        public static AAircraft CreateExecutioner() {
            ImperialisAircraft aircraft = new ImperialisAircraft(
                Sequencer.GetInstance().IncrementAndGet(),
                "Executioner", 23, 3, 2,
                7, 6, 2, 3, 5);

            aircraft[EWeaponType.QUAD_AUTOCANNON] = WeaponFactory.CreateQuadAutocannon();
            aircraft[EWeaponType.TWIN_LASCANNON] = WeaponFactory.CreateTwinLascannon();

            return aircraft;
        }
    }
}