using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekTrust.Models
{
    public class Weather
    {
        private string _name;
        private int _craterIncreaseDecreasePC;

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

        public int CraterIncreaseDecreasePC
        {
            get
            {
                return _craterIncreaseDecreasePC;
            }

            set
            {
                _craterIncreaseDecreasePC = value;
            }
        }

        public Weather(string name, int craterIncreaseDecreasePC)
        {
            _name = name;
            _craterIncreaseDecreasePC = craterIncreaseDecreasePC;
        }
    }
}
