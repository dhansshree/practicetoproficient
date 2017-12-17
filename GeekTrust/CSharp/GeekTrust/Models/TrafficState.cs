using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekTrust.Models
{
    public class Traffic
    {
        public List<Weather> _listOfWeathers;
        public List<Vehicle> _listOfVehicles;
        public List<Orbit> _listOfOrbits;

        public Weather _currentWeather;

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

        public List<TrafficResult> GetTimeOfAllVehiclesOnAllOrbits()
        {
            List<TrafficResult> data = new List<TrafficResult>();
            foreach(Vehicle vehicle in _listOfVehicles)
            {
                if(vehicle.Weathers.Contains(_currentWeather))
                {
                    foreach (var orbit in _listOfOrbits)
                    {
                        data.Add(new TrafficResult(vehicle,vehicle.getTimeTaken(orbit),orbit));
                    }
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
}
