using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekTrust.Models
{
    public class Destination
    {
        private string _name;
        private int _order;

        public Destination(string name)
        {
            _name = name;
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
