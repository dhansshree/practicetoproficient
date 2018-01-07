using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekTrust.Models
{
    public class Traffic
    {
        private List<Weather> _listOfWeathers;
        private List<Vehicle> _listOfVehicles;
        private List<Orbit> _listOfOrbits;
        private Weather _currentWeather;
        private Destination _startingPoint;
        private List<Destination> _mandatoryDestinationsInADay;

        public List<Orbit> ListOfOrbits
        {
            get
            {
                return _listOfOrbits;
            }

            set
            {
                _listOfOrbits = value;
            }
        }

        public List<Vehicle> ListOfVehicles
        {
            get
            {
                return _listOfVehicles;
            }

            set
            {
                _listOfVehicles = value;
            }
        }

        public List<Weather> ListOfWeathers
        {
            get
            {
                return _listOfWeathers;
            }

            set
            {
                _listOfWeathers = value;
            }
        }

        public Weather CurrentWeather
        {
            get
            {
                return _currentWeather;
            }

            set
            {
                _currentWeather = value;
            }
        }

        public Destination StartingPoint
        {
            get
            {
                return _startingPoint;
            }

            set
            {
                _startingPoint = value;
            }
        }

        public List<Destination> MandatoryDestinationsInADay
        {
            get
            {
                return _mandatoryDestinationsInADay;
            }

            set
            {
                _mandatoryDestinationsInADay = value;
            }
        }


        public Traffic(List<Weather> weathers,List<Vehicle> vehicles, List<Orbit> orbits)
        {
            _listOfWeathers = weathers;
            _listOfOrbits = orbits;
            _listOfVehicles = vehicles;
        }

        public void SetCurrentState(Weather weather, Dictionary<Orbit,int> restrictedOrbitSpeed)
        {
            _currentWeather = weather;
            foreach (Orbit item in _listOfOrbits)
            {
                if(restrictedOrbitSpeed.ContainsKey(item))
                {
                     item.MaxMegaMilesPerHrAllowed = restrictedOrbitSpeed[item];
                }
            }
        }

        public List<TrafficResult> GetTimeOfAllVehiclesOnAllOrbits(List<Orbit> listOfEligibleOrbits,List<Vehicle> listOfEligibleVehicles)
        {
            List<TrafficResult> data = new List<TrafficResult>();
            foreach(Vehicle vehicle in listOfEligibleVehicles)
            {
                foreach (var orbit in listOfEligibleOrbits)
                {
                    data.Add(new TrafficResult(vehicle, vehicle.getTimeTaken(orbit), orbit));
                }
            }
            data = data.OrderBy(d => d.TimeForTravel).ToList();
            
            return data;
        }

        public TrafficResult DeterMineWinner(List<TrafficResult> results)
        {
            double lowestTimeTaken = results.First().TimeForTravel;
            List<TrafficResult> finalResults = results.Where(result => result.TimeForTravel == lowestTimeTaken).ToList();
            TrafficResult finalResult = null;
            if(finalResults.Count > 1)
            {
                finalResult = finalResults.OrderBy(r => r.Vehicle.Order).ElementAt(0);
            }
            else
            {
                finalResult = finalResults.Single();
            }
            return finalResult;
        }

        // This need not be the case to repeat same code. Can be converted into a generic method
        public CumulatedTrafficResult DeterMineWinner(List<CumulatedTrafficResult> results)
        {
            //var dataProperty = myObject.GetType().GetProperty("Data");
            //object data = dataProperty.GetValue(myObject, new object[] { });

            results = results.OrderBy(r => r.TimeForTravel).ToList();
            double lowestTimeTaken = results.First().TimeForTravel;
            List<CumulatedTrafficResult> finalResults = results.Where(result => result.TimeForTravel == lowestTimeTaken).ToList();
            CumulatedTrafficResult finalResult = null;
            if (finalResults.Count > 1)
            {
                finalResult = finalResults.OrderBy(r => r.Vehicle.Order).ElementAt(0);
            }
            else
            {
                finalResult = finalResults.Single();
            }
            return finalResult;
        }

        public List<CumulatedTrafficResult> GetAllCumulatedResults()
        {
            List<CumulatedTrafficResult> lists = new List<CumulatedTrafficResult>();
            lists.AddRange(_GetCumulatedResultsByOrder(Order.Ascending));
            lists.AddRange(_GetCumulatedResultsByOrder(Order.Descending));
            return lists;
        }

        private List<CumulatedTrafficResult> _GetCumulatedResultsByOrder(Order order)
        {
            Dictionary<Destination, List<TrafficResult>> trafficRoutes = new Dictionary<Destination, List<TrafficResult>>();
            Destination firstHop = null;
            Destination secondHop = null;
            switch (order)
            {
                case Order.Ascending:
                    firstHop = _mandatoryDestinationsInADay.OrderBy(o => o.Order).First();
                    secondHop = _mandatoryDestinationsInADay.Where(o => o.Name != firstHop.Name).Single(); // since we know there are 2 hops only
                    break;
                case Order.Descending:
                    firstHop = _mandatoryDestinationsInADay.OrderByDescending(o => o.Order).First();
                    secondHop = _mandatoryDestinationsInADay.Where(o => o.Name != firstHop.Name).Single(); 
                    break;
                default:
                    break;
            }
          
            List<CumulatedTrafficResult> lists = new List<CumulatedTrafficResult>();
            trafficRoutes[firstHop] = _GetAllDataOnAllOrbitsByDestinations(_startingPoint, firstHop);
            trafficRoutes[secondHop] = _GetAllDataOnAllOrbitsByDestinations(firstHop, secondHop);
            foreach (TrafficResult item in trafficRoutes[firstHop])
            {
                Vehicle currentVehicle = item.Vehicle;
                List<TrafficResult> trafficResultOfSameTypeFromOtherHop = trafficRoutes[secondHop].Where(o => o.Vehicle == currentVehicle).ToList();
                foreach (TrafficResult item1 in trafficResultOfSameTypeFromOtherHop)
                {
                    lists.Add(new CumulatedTrafficResult(firstHop, secondHop, currentVehicle, item.TimeForTravel + item1.TimeForTravel, item.Orbit, item1.Orbit));
                }
            }
            return lists;
        }

        private List<TrafficResult> _GetAllDataOnAllOrbitsByDestinations(Destination dest1,Destination dest2)
        {
            List<Orbit> o1 = _listOfOrbits.Where(o => o.ListOfDestinations.Contains(dest1)).ToList();
            List<Orbit> o2 = _listOfOrbits.Where(o => o.ListOfDestinations.Contains(dest2)).ToList();
            List<Orbit> o3 = o1.Intersect(o2).ToList(); //Short cut , better way for n destinations ?
            return GetTimeOfAllVehiclesOnAllOrbits(o3, _listOfVehicles.Where(v => v.Weathers.Contains(_currentWeather)).ToList());

        }
      
    }

    public class TrafficResult
    {
        private Vehicle _vehicle;
        private double _timeForTravel;
        private Orbit _orbit;

        

        public double TimeForTravel
        {
            get
            {
                return _timeForTravel;
            }

            set
            {
                _timeForTravel = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return _vehicle;
            }

            set
            {
                _vehicle = value;
            }
        }

        public Orbit Orbit
        {
            get
            {
                return _orbit;
            }

            set
            {
                _orbit = value;
            }
        }

        public TrafficResult(Vehicle vehicle, double timeTaken, Orbit orbit)
        {
            _vehicle = vehicle;
            _timeForTravel = timeTaken;
            _orbit = orbit;
        }
    }

    public enum Order
    {
        Ascending,
        Descending
    }

    public class CumulatedTrafficResult
    {
        private Destination _wayPoint1;
        private Destination _wayPoint2;
        private Vehicle _vehicle;
        private double _timeForTravel;
        private Orbit _orbit1;
        private Orbit _orbit2;

        public Destination WayPoint1
        {
            get
            {
                return _wayPoint1;
            }

            set
            {
                _wayPoint1 = value;
            }
        }

        public Destination WayPoint2
        {
            get
            {
                return _wayPoint2;
            }

            set
            {
                _wayPoint2 = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return _vehicle;
            }

            set
            {
                _vehicle = value;
            }
        }

        public double TimeForTravel
        {
            get
            {
                return _timeForTravel;
            }

            set
            {
                _timeForTravel = value;
            }
        }

        public Orbit Orbit1
        {
            get
            {
                return _orbit1;
            }

            set
            {
                _orbit1 = value;
            }
        }

        public Orbit Orbit2
        {
            get
            {
                return _orbit2;
            }

            set
            {
                _orbit2 = value;
            }
        }

        public CumulatedTrafficResult(Destination wayPoint1, Destination wayPoint2, Vehicle vehicle, double timeForTravel, Orbit orbit1, Orbit orbit2)
        {
            _wayPoint1 = wayPoint1;
            _wayPoint2 = wayPoint2;
            _vehicle = vehicle;
            _timeForTravel = timeForTravel;
            _orbit1 = orbit1;
            _orbit2 = orbit2;

        }
    }

    
    public class TrafficRoute
    {
        private Orbit _orbit;
        private List<TrafficResult> _lstTrafficResults;
        private Destination _wayPoint1;
        private Destination _wayPoint2;
        private int _order;

        public List<TrafficResult> LstTrafficResult
        {
            get
            {
                return _lstTrafficResults;
            }

            set
            {
                _lstTrafficResults = value;
            }
        }

        public int Order
        {
            get
            {
                return _order;
            }

            set
            {
                _order = value;
            }
        }

        public Destination WayPoint1
        {
            get
            {
                return _wayPoint1;
            }

            set
            {
                _wayPoint1 = value;
            }
        }

        public Destination WayPoint2
        {
            get
            {
                return _wayPoint2;
            }

            set
            {
                _wayPoint2 = value;
            }
        }

        public Orbit Orbit
        {
            get
            {
                return _orbit;
            }

            set
            {
                _orbit = value;
            }
        }

        public TrafficRoute(List<TrafficResult> lstTrafficResult,Destination wayPoint1,Destination wayPoint2,Orbit orbit,int order)
        {
            _lstTrafficResults = lstTrafficResult;
            _wayPoint1 = wayPoint1;
            _wayPoint2 = wayPoint2;
            _orbit = orbit;
            _order = order;
        }
    }
}
