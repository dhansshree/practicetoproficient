using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DawnOfTheApes.Models
{
    public class Ape
    {
        private readonly string _name;

        private int _depthLevel;

        private readonly GenderType _gender;

        private ApeFamily _family = null;

        private Ape _spouse = null;

        public string Name
        {
            get { return _name; }
        }

        public GenderType Gender
        {
            get { return _gender; }

        }

        public int DepthLevel
        {
            get { return _depthLevel; }
        }

        public Ape(string name, int depthLevel, GenderType gender)
        {
            _name = name;
            _depthLevel = depthLevel;
            _gender = gender;
        }

        public void SetFamily(ApeFamily family)
        {
            _family = family;
        }

        public ApeFamily GetFamily()
        {
            return _family;
        }

        public Ape GetSpouse()
        {
            return _spouse;
        }
        
        public void AddSpouse(Ape ape)
        {
            ape._depthLevel = this.DepthLevel;
            this._spouse = ape;
        }
    }


}