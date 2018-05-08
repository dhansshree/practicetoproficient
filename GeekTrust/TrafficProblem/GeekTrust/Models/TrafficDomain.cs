using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekTrust.Models
{
    public static class TrafficDomain
    {
        static Weather sunny = new Weather("Sunny", -10);
        static Weather windy = new Weather("Windy", 0);
        static Weather rainy = new Weather("Rainy", 20);

        static Destination silkDorb = new Destination("SilkDorb");
        static Destination hallitharam = new Destination("Hallitharam");
        static Destination rkPuram = new Destination("RK Puram");

        static Orbit orbit1 = new Orbit("Orbit1",20, 18, new List<Destination>() { silkDorb, hallitharam });
        static Orbit orbit2 = new Orbit("Orbit2",10, 20, new List<Destination>() { silkDorb, hallitharam });
        static Orbit orbit3 = new Orbit("Orbit3", 15, 30, new List<Destination>() { silkDorb, rkPuram });
        static Orbit orbit4 = new Orbit("Orbit4",18, 15, new List<Destination>() { rkPuram, hallitharam });

        static Vehicle superCar = new Vehicle("SuperCar", 20, 3, new HashSet<Weather>(new List<Weather>() { sunny, windy, rainy }), 1);
        static Vehicle tuktuk = new Vehicle("TukTuk", 12, 1, new HashSet<Weather>(new List<Weather>() { sunny, rainy }), 2);
        static Vehicle bike = new Vehicle("Bike", 10, 2, new HashSet<Weather>(new List<Weather>() { sunny, windy }), 3);


        public static void InitializeForProblem1Scenario1AndPrintResults()
        {
            Traffic traffic = new Traffic(new List<Weather>() { sunny, windy, rainy }, new List<Vehicle>() { superCar, tuktuk, bike }, new List<Orbit>() { orbit1, orbit2 });
            Dictionary<Orbit, int> dict = new Dictionary<Orbit, int>();
            dict[orbit1] = 12;
            dict[orbit2] = 10;
            traffic.SetCurrentState(sunny, dict);

            List<TrafficResult> results = traffic.GetTimeOfAllVehiclesOnAllOrbits(traffic.ListOfOrbits,traffic.ListOfVehicles.Where(v => v.Weathers.Contains(traffic.CurrentWeather)).ToList());
            TrafficResult finalResult = traffic.DeterMineWinner(results);
            if (finalResult !=null)
            {
                Console.WriteLine("Orbit {0} in vehicle {1} in {2} mins ", finalResult.Orbit.Name, finalResult.Vehicle.Name, finalResult.TimeForTravel);
            }
            else
            {
                Console.WriteLine("oops");
            }   
        }

        public static void InitializeForProblem1Scenario2AndPrintResults()
        {
            Traffic traffic = new Traffic(new List<Weather>() { sunny, windy, rainy }, new List<Vehicle>() { superCar, tuktuk, bike }, new List<Orbit>() { orbit1, orbit2 });
            Dictionary<Orbit, int> dict = new Dictionary<Orbit, int>();
            dict[orbit1] = 14;
            dict[orbit2] = 20;
            traffic.SetCurrentState(windy, dict);

            List<TrafficResult> results = traffic.GetTimeOfAllVehiclesOnAllOrbits(traffic.ListOfOrbits, traffic.ListOfVehicles.Where(v => v.Weathers.Contains(traffic.CurrentWeather)).ToList());
            TrafficResult finalResult = traffic.DeterMineWinner(results);
            if (finalResult != null)
            {
                Console.WriteLine("Orbit {0} in vehicle {1} in {2} mins ", finalResult.Orbit.Name, finalResult.Vehicle.Name, finalResult.TimeForTravel);
            }
            else
            {
                Console.WriteLine("oops");
            }
        }

        public static void InitializeForProblem2Scenario1AndPrintResults()
        {
            Traffic traffic = new Traffic(new List<Weather>() { sunny, windy, rainy }, new List<Vehicle>() { superCar, tuktuk, bike }, new List<Orbit>() { orbit1, orbit2 , orbit3, orbit4 });
            Dictionary<Orbit, int> dict = new Dictionary<Orbit, int>();
            dict[orbit1] = 20;
            dict[orbit2] = 12;
            dict[orbit3] = 15;
            dict[orbit4] = 12;
            traffic.SetCurrentState(sunny, dict);
            traffic.StartingPoint = silkDorb;
            hallitharam.Order = 1;
            rkPuram.Order = 2;
            traffic.MandatoryDestinationsInADay = new List<Destination> { hallitharam, rkPuram };

            List<CumulatedTrafficResult> lists = traffic.GetAllCumulatedResults();
            CumulatedTrafficResult finalResult = traffic.DeterMineWinner(lists);
            if (finalResult != null)
            {
                Console.WriteLine(string.Format("Vehicle {0} to {1} via {2} then to {3} via {4} in time {5}", finalResult.Vehicle.Name, finalResult.WayPoint1.Name, finalResult.Orbit1.Name, finalResult.WayPoint2.Name, finalResult.Orbit2.Name, finalResult.TimeForTravel.ToString()));
            }
            else
            {
                Console.WriteLine("oops");
            }
            
        }

        public static void InitializeForProblem2Scenario2AndPrintResults()
        {
            Traffic traffic = new Traffic(new List<Weather>() { sunny, windy, rainy }, new List<Vehicle>() { superCar, tuktuk, bike }, new List<Orbit>() { orbit1, orbit2, orbit3, orbit4 });
            Dictionary<Orbit, int> dict = new Dictionary<Orbit, int>();
            dict[orbit1] = 5;
            dict[orbit2] = 10;
            dict[orbit3] = 20;
            dict[orbit4] = 20;
            traffic.SetCurrentState(windy, dict);
            traffic.StartingPoint = silkDorb;
            hallitharam.Order = 1;
            rkPuram.Order = 2;
            traffic.MandatoryDestinationsInADay = new List<Destination> { hallitharam, rkPuram };

            List<CumulatedTrafficResult> lists = traffic.GetAllCumulatedResults();
            CumulatedTrafficResult finalResult = traffic.DeterMineWinner(lists);
            if (finalResult != null)
            {
                Console.WriteLine(string.Format("Vehicle {0} to {1} via {2} then to {3} via {4} in time {5}", finalResult.Vehicle.Name, finalResult.WayPoint1.Name, finalResult.Orbit1.Name, finalResult.WayPoint2.Name, finalResult.Orbit2.Name, finalResult.TimeForTravel.ToString()));
            }
            else
            {
                Console.WriteLine("oops");
            }

        }
    }
}
