using System;
using System.Linq;
using aernautica.aircraft;
using aernautica.core;
using NUnit.Framework;

namespace aernautica.unittest {
    public class LinqUnitTest {

        private Player CreatePlayer1() {
            Player p = new Player("the minister", EPlayerType.IMPERIALIS, 400);
            
            Assert.True(p.AddAircraft(AircraftFacotory.CreateBlueDevil()));
            Assert.True(p.AddAircraft(AircraftFacotory.CreateBlueDevil()));
            Assert.True(p.AddAircraft(AircraftFacotory.CreateExecutioner()));
            Assert.True(p.AddAircraft(AircraftFacotory.CreateExecutioner()));
            Assert.True(p.AddAircraft(AircraftFacotory.CreateHellion()));
            Assert.True(p.AddAircraft(AircraftFacotory.CreateHellion()));
            Assert.True(p.AddAircraft(AircraftFacotory.CreateHellion()));

            return p;
        }
        
        private Player CreatePlayer2() {
            Player p = new Player("the minister", EPlayerType.ORC, 400);
            
            Assert.True(p.AddAircraft(AircraftFacotory.CreateBigBurna()));
            Assert.True(p.AddAircraft(AircraftFacotory.CreateBigBurna()));
            Assert.True(p.AddAircraft(AircraftFacotory.CreateBigBurna()));
            Assert.True(p.AddAircraft(AircraftFacotory.CreateBigBurna()));
            Assert.True(p.AddAircraft(AircraftFacotory.CreateGrotBommer()));
            Assert.True(p.AddAircraft(AircraftFacotory.CreateGrotBommer()));
            Assert.True(p.AddAircraft(AircraftFacotory.CreateBigBurna()));

            return p;
        }

        /*
         * 1.1) Geben Sie die Namen aller Flugzeuge eines Spielers aus. Ordnen Sie das Ergebnis nach
         *      den Namen der Flugzeuge.
         */
        [Test]
        public void FleetQueries1() {
           
        }
        
        /*
         * 1.2) Finden Sie alle Flugzeuge, die eine Waffe besitzen, die nach hinten
         *      ausgerichtet sind. Geben Sie die Namen der entsprechenden Flugzeuge aus.
         */
        [Test]
        public void FleetQueries2() {
            
        }
        
        /*
         * 1.3) Geben Sie fuer jeden Flugzeugtyp (Name) die Anzahl der Flugzeuge in der Flotte an.
         *      Es soll dabei der Name des Typs zusammen mit der Anzahl der Flugzeuge ausgegeben
         *      werden.
         */
        [Test]
        public void FleetQueries3() {
           
        }
        
        /*
         * 1.4 Wie schnell ist das schnellste Flugzeug der Flotte
         */
        [Test]
        public void FleetQueries4() {
           
        }
        
        /*
         * 1.5 Geben Sie die schnellsten Flugzeuge der Flotte aus
         */
        [Test]
        public void FleetQueries5() {
            
        }


    }
}