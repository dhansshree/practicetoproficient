using System.Collections.Generic;
using System.Linq;

namespace DawnOfTheApes.Models
{
    public class ApeFamily
    {
        public List<Ape> Partners { get ; }

        public List<Ape> Children { get; }

        public ApeFamily(List<Ape> partners, List<Ape> children)
        {
            Partners = partners;

            Ape maleApe = partners.SingleOrDefault(a => a.Gender == GenderType.Male);
            Ape femaleApe = partners.SingleOrDefault(a => a.Gender == GenderType.Female);

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