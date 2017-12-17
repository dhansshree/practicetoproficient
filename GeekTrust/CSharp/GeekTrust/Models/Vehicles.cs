using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekTrust.Models
{
    public class Vehicle
    {
        private string _name;
        private int _speedInMegaMilesPerHour;
        private int _minutesFor1Crater;
        HashSet<Weather> _weathersSupported = new HashSet<Weather>();
        private int _order;

        public Vehicle(string Name, int SpeedInMegaMilesPerHour, int MinutesFor1Crater, HashSet<Weather> weathersSupported , int order)
        {
            _name = Name;
            _speedInMegaMilesPerHour = SpeedInMegaMilesPerHour;
            _minutesFor1Crater = MinutesFor1Crater;
            _weathersSupported = weathersSupported;
            _order = order;
        }

        public double getTimeTaken(Orbit orbit)
        {
            double craterTimeInMinutes = orbit.NoOfCraters * _minutesFor1Crater;
            int speed = _speedInMegaMilesPerHour;
            if (orbit.MaxMegaMilesPerHrAllowed <= _speedInMegaMilesPerHour)
            {
                speed = orbit.MaxMegaMilesPerHrAllowed;
            }
            double timeForRoute = orbit.TotalDistanceinMegaMiles / speed ;
            double totalTime = craterTimeInMinutes + ( timeForRoute * 60 );
            return totalTime;
        }

        public int Speed
        {
            get
            {
                return _speedInMegaMilesPerHour;
            }

            set
            {
                _speedInMegaMilesPerHour = value;
            }
        }

        public int PotHoleTime
        {
            get
            {
                return _minutesFor1Crater;
            }

            set
            {
                _minutesFor1Crater = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public HashSet<Weather> Weathers
        {
            get
            {
                return _weathersSupported;
            }

            set
            {
                _weathersSupported = value;
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
    }
   
        
}
