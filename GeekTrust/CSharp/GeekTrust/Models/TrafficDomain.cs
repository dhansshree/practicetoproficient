using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekTrust.Models
{
    public static class TrafficDomain
    {
        public static void InitializeForProblem1AndPrintResults()
        {
            Weather sunny = new Weather("Sunny", -10);
            Weather windy = new Weather("Windy", 0);
            Weather rainy = new Weather("Rainy", 20);
            Orbit orbit1 = new Orbit("1", 18, 20);
            Orbit orbit2 = new Orbit("1", 20, 10);
            Vehicle superCar = new Vehicle("SuperCar", 20, 3, new HashSet<Weather>(new List<Weather>() { sunny, windy, rainy }), 1);
            Vehicle tuktuk = new Vehicle("TukTuk", 12, 1, new HashSet<Weather>(new List<Weather>() { sunny, rainy }), 2);
            Vehicle bike = new Vehicle("Bike", 10, 2, new HashSet<Weather>(new List<Weather>() { sunny, windy }), 3);
            Traffic traffic = new Traffic(new List<Weather>() { sunny, windy, rainy }, new List<Vehicle>() { superCar, tuktuk, bike }, new List<Orbit>() { orbit1, orbit2 });
            Dictionary<Orbit, int> dict = new Dictionary<Orbit, int>();
            dict[orbit1] = 14;
            dict[orbit2] = 20;
            traffic.SetCurrentState(windy, dict);

            List<TrafficResult> results = traffic.GetTimeOfAllVehiclesOnAllOrbits();
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
    }
}
