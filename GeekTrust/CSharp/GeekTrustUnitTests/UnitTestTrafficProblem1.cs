using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeekTrust;
using GeekTrust.Models;
using System.Collections.Generic;
using System.Linq;

namespace GeekTrustUnitTests
{
    [TestClass]
    public class UnitTestTrafficProblem1
    {
        //Common Elements
        static Weather sunny = new Weather("Sunny", -10);
        static Weather windy = new Weather("Windy", 0);
        static Weather rainy = new Weather("Rainy", 20);

        static Destination silkDorb = new Destination("SilkDorb");
        static Destination hallitharam = new Destination("Hallitharam");

        static Orbit orbit1 = new Orbit("Orbit1", 20, 18, new List<Destination>() { silkDorb, hallitharam });
        static Orbit orbit2 = new Orbit("Orbit2", 10, 20, new List<Destination>() { silkDorb, hallitharam });

        static Vehicle superCar = new Vehicle("SuperCar", 20, 3, new HashSet<Weather>(new List<Weather>() { sunny, windy, rainy }), 1);
        static Vehicle tuktuk = new Vehicle("TukTuk", 12, 1, new HashSet<Weather>(new List<Weather>() { sunny, rainy }), 2);
        static Vehicle bike = new Vehicle("Bike", 10, 2, new HashSet<Weather>(new List<Weather>() { sunny, windy }), 3);
        Traffic traffic = new Traffic(new List<Weather>() { sunny, windy, rainy }, new List<Vehicle>() { superCar, tuktuk, bike }, new List<Orbit>() { orbit1, orbit2 });

        [TestMethod]
        public void UnitTestTrafficProblem1_Scenario1()
        {
            //arrange
            Dictionary<Orbit, int> dict = new Dictionary<Orbit, int>();
            dict[orbit1] = 12;
            dict[orbit2] = 10;
            traffic.SetCurrentState(sunny, dict);
            TrafficResult expected = new TrafficResult(tuktuk, 110, orbit1);

            //act
            List<TrafficResult> results = traffic.GetTimeOfAllVehiclesOnAllOrbits(traffic.ListOfOrbits, traffic.ListOfVehicles.Where(v => v.Weathers.Contains(traffic.CurrentWeather)).ToList());
            TrafficResult actual = traffic.DeterMineWinner(results);

            //assert
            Assert.AreEqual(actual.Vehicle, expected.Vehicle, string.Format("Expected Vehicle was {0} but is {1}",expected.Vehicle.Name,actual.Vehicle.Name));
            Assert.AreEqual(actual.Orbit, expected.Orbit, string.Format("Expected Orbit was {0} but is {1}", expected.Orbit.Name, actual.Orbit.Name));
            Assert.AreEqual(actual.TimeForTravel, expected.TimeForTravel, string.Format("Expected Time travel time was {0} but is {1}", expected.TimeForTravel, actual.TimeForTravel));
        }

        [TestMethod]
        public void UnitTestTrafficProblem1_Scenario2()
        {
            //arrange
            Dictionary<Orbit, int> dict = new Dictionary<Orbit, int>();
            dict[orbit1] = 14;
            dict[orbit2] = 20;
            traffic.SetCurrentState(windy, dict);
            TrafficResult expected = new TrafficResult(superCar, 90, orbit2);

            //act
            List<TrafficResult> results = traffic.GetTimeOfAllVehiclesOnAllOrbits(traffic.ListOfOrbits, traffic.ListOfVehicles.Where(v => v.Weathers.Contains(traffic.CurrentWeather)).ToList());
            TrafficResult actual = traffic.DeterMineWinner(results);

            //assert
            Assert.AreEqual(actual.Vehicle, expected.Vehicle, string.Format("Expected Vehicle was {0} but is {1}", expected.Vehicle.Name, actual.Vehicle.Name));
            Assert.AreEqual(actual.Orbit, expected.Orbit, string.Format("Expected Orbit was {0} but is {1}", expected.Orbit.Name, actual.Orbit.Name));
            Assert.AreEqual(actual.TimeForTravel, expected.TimeForTravel, string.Format("Expected Time travel time was {0} but is {1}", expected.TimeForTravel, actual.TimeForTravel));
        }
    }

    [TestClass]
    public class UnitTestTrafficProblem2
    {
        //Common Elements
        static Weather sunny = new Weather("Sunny", -10);
        static Weather windy = new Weather("Windy", 0);
        static Weather rainy = new Weather("Rainy", 20);

        static Destination silkDorb = new Destination("SilkDorb");
        static Destination hallitharam = new Destination("Hallitharam");
        static Destination rkPuram = new Destination("RK Puram");

        static Orbit orbit1 = new Orbit("Orbit1", 20, 18, new List<Destination>() { silkDorb, hallitharam });
        static Orbit orbit2 = new Orbit("Orbit2", 10, 20, new List<Destination>() { silkDorb, hallitharam });
        static Orbit orbit3 = new Orbit("Orbit3", 15, 30, new List<Destination>() { silkDorb, rkPuram });
        static Orbit orbit4 = new Orbit("Orbit4", 18, 15, new List<Destination>() { rkPuram, hallitharam });

        static Vehicle superCar = new Vehicle("SuperCar", 20, 3, new HashSet<Weather>(new List<Weather>() { sunny, windy, rainy }), 1);
        static Vehicle tuktuk = new Vehicle("TukTuk", 12, 1, new HashSet<Weather>(new List<Weather>() { sunny, rainy }), 2);
        static Vehicle bike = new Vehicle("Bike", 10, 2, new HashSet<Weather>(new List<Weather>() { sunny, windy }), 3);
        Traffic traffic = new Traffic(new List<Weather>() { sunny, windy, rainy }, new List<Vehicle>() { superCar, tuktuk, bike }, new List<Orbit>() { orbit1, orbit2 });

        [TestMethod]
        public void UnitTestTrafficProblem2_Scenario1()
        {
            //arrange
            Traffic traffic = new Traffic(new List<Weather>() { sunny, windy, rainy }, new List<Vehicle>() { superCar, tuktuk, bike }, new List<Orbit>() { orbit1, orbit2, orbit3, orbit4 });
            Dictionary<Orbit, int> dict = new Dictionary<Orbit, int>();
            dict[orbit1] = 20;
            dict[orbit2] = 12;
            dict[orbit3] = 15;
            dict[orbit4] = 12;
            traffic.StartingPoint = silkDorb;
            hallitharam.Order = 1;
            rkPuram.Order = 2;
            traffic.SetCurrentState(sunny, dict);
            traffic.MandatoryDestinationsInADay = new List<Destination> { hallitharam, rkPuram };
            CumulatedTrafficResult expected = new CumulatedTrafficResult(hallitharam,rkPuram, tuktuk,203,orbit1, orbit4);

            //act
            List<CumulatedTrafficResult> lists = traffic.GetAllCumulatedResults();
            CumulatedTrafficResult actual = traffic.DeterMineWinner(lists);

            // assert
            Assert.AreEqual(actual.Vehicle, expected.Vehicle, string.Format("Expected Vehicle was {0} but is {1}", expected.Vehicle.Name, actual.Vehicle.Name));
            Assert.AreEqual(actual.Orbit1, expected.Orbit1, string.Format("Expected Orbit1 was {0} but is {1}", expected.Orbit1.Name, actual.Orbit1.Name));
            Assert.AreEqual(actual.Orbit2, expected.Orbit2, string.Format("Expected Orbit2 was {0} but is {1}", expected.Orbit2.Name, actual.Orbit2.Name));
            Assert.AreEqual(actual.WayPoint1, expected.WayPoint1, string.Format("Expected WayPoint1 was {0} but is {1}", expected.WayPoint1.Name, actual.WayPoint1.Name));
            Assert.AreEqual(actual.WayPoint2, expected.WayPoint2, string.Format("Expected WayPoint2 was {0} but is {1}", expected.WayPoint2.Name, actual.WayPoint2.Name));
            Assert.AreEqual(actual.TimeForTravel, expected.TimeForTravel, string.Format("Expected Time travel time was {0} but is {1}", expected.TimeForTravel, actual.TimeForTravel));


        }

        
        [TestMethod]
        public void UnitTestTrafficProblem2_Scenario2()
        {
            //arrange
            Traffic traffic = new Traffic(new List<Weather>() { sunny, windy, rainy }, new List<Vehicle>() { superCar, tuktuk, bike }, new List<Orbit>() { orbit1, orbit2, orbit3, orbit4 });
            Dictionary<Orbit, int> dict = new Dictionary<Orbit, int>();
            dict[orbit1] = 5;
            dict[orbit2] = 10;
            dict[orbit3] = 20;
            dict[orbit4] = 20;
            traffic.StartingPoint = silkDorb;
            hallitharam.Order = 1;
            rkPuram.Order = 2;
            traffic.SetCurrentState(windy, dict);
            traffic.MandatoryDestinationsInADay = new List<Destination> { hallitharam, rkPuram };
            CumulatedTrafficResult expected = new CumulatedTrafficResult(rkPuram, hallitharam, superCar, 234, orbit3, orbit4);

            //act
            List<CumulatedTrafficResult> lists = traffic.GetAllCumulatedResults();
            CumulatedTrafficResult actual = traffic.DeterMineWinner(lists);

            // assert
            Assert.AreEqual(actual.Vehicle, expected.Vehicle, string.Format("Expected Vehicle was {0} but is {1}", expected.Vehicle.Name, actual.Vehicle.Name));
            Assert.AreEqual(actual.Orbit1, expected.Orbit1, string.Format("Expected Orbit1 was {0} but is {1}", expected.Orbit1.Name, actual.Orbit1.Name));
            Assert.AreEqual(actual.Orbit2, expected.Orbit2, string.Format("Expected Orbit2 was {0} but is {1}", expected.Orbit2.Name, actual.Orbit2.Name));
            Assert.AreEqual(actual.WayPoint1, expected.WayPoint1, string.Format("Expected WayPoint1 was {0} but is {1}", expected.WayPoint1.Name, actual.WayPoint1.Name));
            Assert.AreEqual(actual.WayPoint2, expected.WayPoint2, string.Format("Expected WayPoint2 was {0} but is {1}", expected.WayPoint2.Name, actual.WayPoint2.Name));
            Assert.AreEqual(actual.TimeForTravel, expected.TimeForTravel, string.Format("Expected Time travel time was {0} but is {1}", expected.TimeForTravel, actual.TimeForTravel));
        }
    }
}
