using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekTrust.Models
{
    public class Orbit
    {
        private string _name;
        private int _maxMegaMilesPerHrAllowed;
        private int _noOfCraters;
        private int _totalDistanceinMegaMiles;
        private List<Destination> _listOfDestionations;
        

        public int NoOfCraters
        {
            get
            {
                return _noOfCraters;
            }

            set
            {
                _noOfCraters = value;
            }
        }

        public int TotalDistanceinMegaMiles
        {
            get
            {
                return _totalDistanceinMegaMiles;
            }

            set
            {
                _totalDistanceinMegaMiles = value;
            }
        }

        public int MaxMegaMilesPerHrAllowed
        {
            get
            {
                return _maxMegaMilesPerHrAllowed;
            }

            set
            {
                _maxMegaMilesPerHrAllowed = value;
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

        public List<Destination> ListOfDestinations
        {
            get
            {
                return _listOfDestionations;
            }

            set
            {
                _listOfDestionations = value;
            }
        }

        public Orbit(string name,int noOfCraters, int totalDistanceinMegaMiles,List<Destination> listOfDestinations)
        {
            _name = name;
            _noOfCraters = noOfCraters;
            _totalDistanceinMegaMiles = totalDistanceinMegaMiles;
            //Initially both are same
            _maxMegaMilesPerHrAllowed = totalDistanceinMegaMiles;
            _listOfDestionations = listOfDestinations;
            
        }

        public void AlterNoOfCraters(Weather weather)
        {
            double percentage = (double)weather.CraterIncreaseDecreasePC / 100.0;
            _noOfCraters = Convert.ToInt32(_noOfCraters + (_noOfCraters * percentage));
        }


    }
}
