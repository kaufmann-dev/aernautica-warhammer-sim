using aernautica.aircraft;
using NUnit.Framework;

namespace aernautica.unittest {
    public class WeaponUnitTest {
        
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void TestBigShoota() {
            Weapon weapon = WeaponFactory.CreateQuadBigShoota();
            
            Assert.AreEqual(8, weapon[ERangeType.SHORT]);
            Assert.AreEqual(4, weapon[ERangeType.MEDIUM]);
            Assert.AreEqual(0, weapon[ERangeType.LONG]);
            
            Assert.AreEqual(1,weapon.Directions.Count);
            Assert.AreEqual(5, weapon.Damage);
        }
        
        [Test]
        public void TestTurretBigShoota() {
            Weapon weapon = WeaponFactory.CreateTurretBigShoota();
            
            Assert.AreEqual(3, weapon[ERangeType.SHORT]);
            Assert.AreEqual(1, weapon[ERangeType.MEDIUM]);
            Assert.AreEqual(0, weapon[ERangeType.LONG]);
            
            Assert.AreEqual(4,weapon.Directions.Count);
            
            Assert.True(weapon.Directions.Contains(EFireDirection.UP));
            Assert.True(weapon.Directions.Contains(EFireDirection.REAR));
            Assert.True(weapon.Directions.Contains(EFireDirection.RIGHT_SIDE));
            Assert.True(weapon.Directions.Contains(EFireDirection.LEFT_SIDE));
            
            Assert.AreEqual(5, weapon.Damage);
        }
        
        [Test]
        public void TestTailGun() {
            Weapon weapon = WeaponFactory.CreateTailGun();
            
            Assert.AreEqual(1, weapon[ERangeType.SHORT]);
            Assert.AreEqual(0, weapon[ERangeType.MEDIUM]);
            Assert.AreEqual(0, weapon[ERangeType.LONG]);
            
            Assert.AreEqual(1,weapon.Directions.Count);
            
            Assert.True(weapon.Directions.Contains(EFireDirection.REAR));
            Assert.AreEqual(6, weapon.Damage);
        }
        
        [Test]
        public void TestPortTurret() {
            Weapon weapon = WeaponFactory.CreatePortTurret();
            
            Assert.AreEqual(2, weapon[ERangeType.SHORT]);
            Assert.AreEqual(1, weapon[ERangeType.MEDIUM]);
            Assert.AreEqual(0, weapon[ERangeType.LONG]);
            
            Assert.AreEqual(2,weapon.Directions.Count);
            
            Assert.True(weapon.Directions.Contains(EFireDirection.LEFT_SIDE));
            Assert.True(weapon.Directions.Contains(EFireDirection.UP));
            
            Assert.AreEqual(5, weapon.Damage);
        }
        
        [Test]
        public void TestStarboardTurret() {
            Weapon weapon = WeaponFactory.CreateStarboardTurret();
            
            Assert.AreEqual(2, weapon[ERangeType.SHORT]);
            Assert.AreEqual(1, weapon[ERangeType.MEDIUM]);
            Assert.AreEqual(0, weapon[ERangeType.LONG]);
            
            Assert.AreEqual(2,weapon.Directions.Count);
            
            Assert.True(weapon.Directions.Contains(EFireDirection.RIGHT_SIDE));
            Assert.True(weapon.Directions.Contains(EFireDirection.UP));
            
            Assert.AreEqual(5, weapon.Damage);
        }
        
        [Test]
        public void TestLascannon() {
            Weapon weapon = WeaponFactory.CreateLascannon();
            
            Assert.AreEqual(0, weapon[ERangeType.SHORT]);
            Assert.AreEqual(2, weapon[ERangeType.MEDIUM]);
            Assert.AreEqual(1, weapon[ERangeType.LONG]);
            
            Assert.AreEqual(1,weapon.Directions.Count);
            Assert.True(weapon.Directions.Contains(EFireDirection.FRONT));
            
            Assert.AreEqual(2, weapon.Damage);
        }
        
        [Test]
        public void TestDoraslTurret() {
            Weapon weapon = WeaponFactory.CreateDorsalTurret();
            
            Assert.AreEqual(3, weapon[ERangeType.SHORT]);
            Assert.AreEqual(2, weapon[ERangeType.MEDIUM]);
            Assert.AreEqual(0, weapon[ERangeType.LONG]);
            
            Assert.AreEqual(5,weapon.Directions.Count);
            
            Assert.True(weapon.Directions.Contains(EFireDirection.FRONT));
            Assert.True(weapon.Directions.Contains(EFireDirection.REAR));
            Assert.True(weapon.Directions.Contains(EFireDirection.LEFT_SIDE));
            Assert.True(weapon.Directions.Contains(EFireDirection.RIGHT_SIDE));
            Assert.True(weapon.Directions.Contains(EFireDirection.UP));
            
            Assert.AreEqual(5, weapon.Damage);
        }
        
        [Test]
        public void TestRearTurret() {
            Weapon weapon = WeaponFactory.CreateRearTurret();
            
            Assert.AreEqual(3, weapon[ERangeType.SHORT]);
            Assert.AreEqual(2, weapon[ERangeType.MEDIUM]);
            Assert.AreEqual(0, weapon[ERangeType.LONG]);
            
            Assert.AreEqual(1,weapon.Directions.Count);
            
            Assert.True(weapon.Directions.Contains(EFireDirection.REAR));
            Assert.AreEqual(5, weapon.Damage);
        }
        
        [Test]
        public void TestTwinMultilaser() {
            Weapon weapon = WeaponFactory.CreateTwinMultilaser();
            
            Assert.AreEqual(4, weapon[ERangeType.SHORT]);
            Assert.AreEqual(6, weapon[ERangeType.MEDIUM]);
            Assert.AreEqual(2, weapon[ERangeType.LONG]);
            
            Assert.AreEqual(1,weapon.Directions.Count);
            Assert.True(weapon.Directions.Contains(EFireDirection.FRONT));
            
            Assert.AreEqual(5, weapon.Damage);
        }
        
        [Test]
        public void TestTwinLascannon() {
            Weapon weapon = WeaponFactory.CreateTwinLascannon();
            
            Assert.AreEqual(0, weapon[ERangeType.SHORT]);
            Assert.AreEqual(2, weapon[ERangeType.MEDIUM]);
            Assert.AreEqual(1, weapon[ERangeType.LONG]);
            
            Assert.AreEqual(1,weapon.Directions.Count);
            Assert.True(weapon.Directions.Contains(EFireDirection.FRONT));
            
            Assert.AreEqual(2, weapon.Damage);
        }
        
        [Test]
        public void TestQuadAutocannon() {
            Weapon weapon = WeaponFactory.CreateQuadAutocannon();
            
            Assert.AreEqual(2, weapon[ERangeType.SHORT]);
            Assert.AreEqual(6, weapon[ERangeType.MEDIUM]);
            Assert.AreEqual(0, weapon[ERangeType.LONG]);
            
            Assert.AreEqual(1,weapon.Directions.Count);
            Assert.True(weapon.Directions.Contains(EFireDirection.FRONT));
            
            Assert.AreEqual(4, weapon.Damage);
        }

        [Test]
        public void IsHit() {
            Weapon weapon = WeaponFactory.CreateLascannon();
            
            Assert.True(weapon.isHit(4,2));
            Assert.False(weapon.isHit(2,1));
        }
        
    }
}