using System.Collections.Generic;
using System.Linq;

namespace DawnOfTheApes.Models
{
    public class ApeFamily
    {
        public List<Ape> Partners { get ; }

        public List<Ape> Children { get; }

        public string Name { get; set;  }

        public ApeFamily(string name , List<Ape> partners, List<Ape> children)
        {
            Name = name;

            Partners = partners;

            Ape maleApe = partners.SingleOrDefault(a => a.GetGender() == GenderType.Male);
            Ape femaleApe = partners.SingleOrDefault(a => a.GetGender() == GenderType.Female);

            maleApe?.AddSpouse(femaleApe);
            femaleApe?.AddSpouse(maleApe);


            Children = children;
        }

        public Ape AddNewBorn(string babyName , int depthLevel , GenderType gender)
        {
            Ape newborn = new Ape(babyName, depthLevel, gender);
            this.Children.Add(newborn);
            return newborn;
        }

    }


}