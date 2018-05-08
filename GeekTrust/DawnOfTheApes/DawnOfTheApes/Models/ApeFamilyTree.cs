using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DawnOfTheApes.Models
{
    public class ApeFamilyTree
    {
        public Dictionary<string, Ape> Apes { get; }

        public static List<ApeFamily> ApeFamilies { get; set; }

        public List<ApeFamily> GetApeFamilies()
        {
            return ApeFamilies;
        }

        public ApeFamilyTree(Dictionary<string,Ape> apes,List<ApeFamily> families)
        {
            Apes = apes;
            ApeFamilies = families;
        }

        public Ape DetermineFamilyTreeAndAddNewBorn(string apeName, string babyName , string genderType)
        {
            if(!Apes.ContainsKey(apeName))
                throw  new Exception("There is no such Ape found with that name");
            if(Apes.ContainsKey(babyName))
                throw new Exception("We are of a more creative mind.");
            Models.GenderType gender = Models.GenderType.Female;
            if (!Enum.TryParse(genderType,true,out  gender))
                throw new Exception("We are not aware of such a gender!!");

            Ape parent = Apes[apeName];
            ApeFamily apeFamily = ApeFamilies.SingleOrDefault(p => p.Partners.Contains(parent));

            if (apeFamily == null)
                throw new Exception("That would be incorrect. Apes are not Godzillas.");

            Ape newBorn = apeFamily.AddNewBorn(babyName,parent.DepthLevel + 1 , gender);
            newBorn.SetFamily(apeFamily);
            Apes[newBorn.Name] = newBorn;

            return newBorn;

        }

        public List<Ape> DetermineValidityAndFindRelationShips(string apeName, string relationship)
        {
            if (!Apes.ContainsKey(apeName))
                throw new Exception("There is no such Ape found with that name");
            Models.RelationshipType relationshipType = Models.RelationshipType.Mother;
            if (!Enum.TryParse(relationship, true, out relationshipType))
                throw new Exception("We are not aware of such a relationship!!");

            return (List<Ape>)RelationshipManager.Relationships[relationshipType].DynamicInvoke(this, Apes[apeName]);

        }

        public RelationshipType DetermineValidityAndFindRelationShipsBetweenApes(string ape1Name, string ape2Name)
        {
            if (!Apes.ContainsKey(ape1Name))
                throw new Exception("There is no such Ape found with that name");
            if (!Apes.ContainsKey(ape2Name))
                throw new Exception("There is no such Ape found with that name");

            Ape ape1 = Apes[ape1Name];
            Ape ape2 = Apes[ape2Name];

            int diff = ape1.DepthLevel - ape2.DepthLevel;
            
            if (ape1.DepthLevel == ape2.DepthLevel)
            {
                List<RelationshipType> types = RelationshipManager.RelationshipLevelToTypes[RelationshipLevel.Same];
                foreach (var type in types)
                {
                    List<Ape> apes = DetermineValidityAndFindRelationShips(ape1.Name, type.ToString());
                    if (apes.Contains(ape2))
                        return type;
                }
            }

            if (ape1.DepthLevel > ape2.DepthLevel)
            {
                List<RelationshipType> types = RelationshipManager.RelationshipLevelToTypes[RelationshipLevel.UpBy1];
                foreach (var type in types)
                {
                    List<Ape> apes = DetermineValidityAndFindRelationShips(ape1.Name, type.ToString());
                    if (apes.Contains(ape2))
                        return type;
                }
            }

            if (ape1.DepthLevel < ape2.DepthLevel)
            {
                if (Math.Abs(ape1.DepthLevel - ape2.DepthLevel) == 1)
                {
                    List<RelationshipType> types =
                        RelationshipManager.RelationshipLevelToTypes[RelationshipLevel.DownBy1];
                    foreach (var type in types)
                    {
                        List<Ape> apes = DetermineValidityAndFindRelationShips(ape1.Name, type.ToString());
                        if (apes.Contains(ape2))
                            return type;
                    }
                }

                if (Math.Abs(ape1.DepthLevel - ape2.DepthLevel) == 2)
                {
                    List<RelationshipType> types =
                        RelationshipManager.RelationshipLevelToTypes[RelationshipLevel.DownBy2];
                    foreach (var type in types)
                    {
                        List<Ape> apes = DetermineValidityAndFindRelationShips(ape1.Name, type.ToString());
                        if (apes.Contains(ape2))
                            return type;
                    }
                }
            }

            throw new Exception("Err");
        }



        public List<Ape> FindApesWithMaximumGrandChildren()
        {
            List<Ape> result = new List<Ape>();
            List<ApeFamily> familywithGirlChildren = ApeFamilies.Where(c => c.Children.Any(g => g.Gender == GenderType.Female)).ToList();
            Dictionary<ApeFamily,int> familyAndGirlChildCount = new Dictionary<ApeFamily, int>();
            foreach (ApeFamily family in familywithGirlChildren)
            {
                familyAndGirlChildCount[family] = family.Children.Count(g => g.Gender == GenderType.Female);
            }
            List<KeyValuePair<ApeFamily,int>> apefamily = familyAndGirlChildCount.Where(x => x.Value == familyAndGirlChildCount.Values.Max()).ToList();
            foreach (var kvp in apefamily)
            {
                result.Add(kvp.Key.Partners.SingleOrDefault(g => g.Gender == GenderType.Female && g.DepthLevel > 0));
            }

            return result.Where(r => r!= null).ToList();
        }

    }
}