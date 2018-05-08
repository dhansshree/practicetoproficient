using System;
using System.Collections.Generic;
using System.Linq;

namespace DawnOfTheApes.Models
{
    public static class RelationshipManager
    {
        public static Dictionary<RelationshipType, Delegate> Relationships { get; } = new Dictionary<RelationshipType, Delegate>
        {
            {RelationshipType.Mother, new Func<ApeFamilyTree, Ape, List<Ape>>(GetMother)}, 
            {RelationshipType.Father, new Func<ApeFamilyTree, Ape, List<Ape>>(GetFather)}, 
            {RelationshipType.Wife , new Func<ApeFamilyTree, Ape, List<Ape>>(GetSpouse) },
            {RelationshipType.Husband , new Func<ApeFamilyTree, Ape, List<Ape>>(GetSpouse) },
            {RelationshipType.Children , new Func<ApeFamilyTree, Ape, List<Ape>>(GetChildren) },
            {RelationshipType.Son , new Func<ApeFamilyTree, Ape, List<Ape>>(GetSons) },
            {RelationshipType.Daughter , new Func<ApeFamilyTree, Ape, List<Ape>>(GetDaughthers) }, 
            {RelationshipType.Brother, new Func<ApeFamilyTree, Ape, List<Ape>>(GetBrothers)},
            {RelationshipType.Sister, new Func<ApeFamilyTree, Ape, List<Ape>>(GetSisters)}, 
            {RelationshipType.GrandChildren , new Func<ApeFamilyTree, Ape, List<Ape>>(GetGrandChildren) }, // 2 level down
            {RelationshipType.GrandSon , new Func<ApeFamilyTree, Ape, List<Ape>>(GetGrandSons) }, // 2 level down
            {RelationshipType.GrandDaughter , new Func<ApeFamilyTree, Ape, List<Ape>>(GetGrandDaugthers) }, // 2 level down
            {RelationshipType.Cousins , new Func<ApeFamilyTree, Ape, List<Ape>>(GetCousins) }, 
            {RelationshipType.SisterInLaw , new Func<ApeFamilyTree, Ape, List<Ape>>(GetSisterInLaws) },
            {RelationshipType.BrotherInLaw , new Func<ApeFamilyTree, Ape, List<Ape>>(GetBrotherInLaws) }, 
            {RelationshipType.MaternalAunt , new Func<ApeFamilyTree, Ape, List<Ape>>(GetMaternalAunt) }, 
            {RelationshipType.MaternalUncle , new Func<ApeFamilyTree, Ape, List<Ape>>(GetMaternalUncle) }, 
            {RelationshipType.PaternalUncle , new Func<ApeFamilyTree, Ape, List<Ape>>(GetPaternalUncle) },
            {RelationshipType.PaternalAunt , new Func<ApeFamilyTree, Ape, List<Ape>>(GetPaternalAunt) } 
        };

        public static Dictionary<RelationshipLevel, List<RelationshipType>> RelationshipLevelToTypes =
            new Dictionary<RelationshipLevel, List<RelationshipType>>()
            {
                {RelationshipLevel.Same , new List<RelationshipType>()
                {
                    RelationshipType.Brother,RelationshipType.Sister,RelationshipType.SisterInLaw,RelationshipType.BrotherInLaw,RelationshipType.Cousins , RelationshipType.Husband , RelationshipType.Wife
                }
                },
                {RelationshipLevel.UpBy1 , new List<RelationshipType>()
                {
                    RelationshipType.Mother,RelationshipType.Father,RelationshipType.PaternalUncle,RelationshipType.MaternalAunt,RelationshipType.PaternalAunt,RelationshipType.MaternalUncle
                }
                },
                {RelationshipLevel.DownBy1 , new List<RelationshipType>()
                {
                    RelationshipType.Son,RelationshipType.Daughter,RelationshipType.Children
                }},
                {RelationshipLevel.DownBy2 , new List<RelationshipType>()
                {
                    RelationshipType.GrandChildren,RelationshipType.GrandDaughter,RelationshipType.GrandSon
                }}
            };


        public static List<Ape> GetMother(ApeFamilyTree familyTree, Ape ape)
        {
            ApeFamily family = ape.GetFamily();
            return new List<Ape>()
                { family?.Partners.SingleOrDefault(e => e != ape && e.Gender == GenderType.Female)};            
        }

        public static List<Ape> GetFather(ApeFamilyTree familyTree , Ape ape)
        {
            ApeFamily family = ape.GetFamily();
            return new List<Ape>()
                { family?.Partners.SingleOrDefault(e => e != ape && e.Gender == GenderType.Male)};
        }

        public static List<Ape> GetSpouse(ApeFamilyTree familyTree, Ape ape)
        {
            return new List<Ape>() {ape.GetSpouse()};
        }

        public static List<Ape> GetChildren(ApeFamilyTree familyTree, Ape ape)
        {
            ApeFamily family = familyTree.GetApeFamilies().SingleOrDefault(p => p.Partners.Contains(ape));
            if (family != null)
            {
                return family.Children.ToList();
            }
            return new List<Ape>();
        }

        public static List<Ape> GetSons(ApeFamilyTree familyTree, Ape ape)
        {
            ApeFamily family = familyTree.GetApeFamilies().SingleOrDefault(p => p.Partners.Contains(ape));
            if (family != null)
            {
                return family.Children.Where(c => c.Gender == GenderType.Male).ToList();
            }
            return new List<Ape>();
        }

        public static List<Ape> GetDaughthers(ApeFamilyTree familyTree, Ape ape)
        {
            ApeFamily family = familyTree.GetApeFamilies().SingleOrDefault(p => p.Partners.Contains(ape));
            if (family != null)
            {
                return family.Children.Where(c => c.Gender == GenderType.Female).ToList();
            }
            return new List<Ape>();
        }

        public static List<Ape> GetSiblings(ApeFamilyTree familyTree, Ape ape)
        {
            ApeFamily family = ape.GetFamily();
            if (family != null)
            {
                return family.Children.Where(elem => elem != ape).ToList();
            }
            return new List<Ape>();
        }

        public static List<Ape> GetBrothers(ApeFamilyTree familyTree, Ape ape)
        {
            ApeFamily family = ape.GetFamily();
            if (family != null)
            {
                return family.Children.Where(elem => elem != ape && elem.Gender != GenderType.Female).ToList();
            }
            return new List<Ape>();
        }




        public static List<Ape> GetSisters(ApeFamilyTree familyTree, Ape ape)
        {
            ApeFamily family = ape.GetFamily();
            if (family != null)
            {
                return family.Children.Where(elem => elem != ape && elem.Gender != GenderType.Male).ToList();
            }
            return new List<Ape>();
        }


        public static List<Ape> GetGrandChildren(ApeFamilyTree familyTree, Ape ape)
        {
            ApeFamily family = familyTree.GetApeFamilies().SingleOrDefault(p => p.Partners.Contains(ape));
            List<Ape> children = GetChildren(familyTree, ape);
            List<Ape> grandChildren = new List<Ape>();
            foreach (var child in children)
            {
                grandChildren.AddRange(GetChildren(familyTree,child));
            }

            return grandChildren;
        }

        public static List<Ape> GetGrandSons(ApeFamilyTree familyTree, Ape ape)
        {
            ApeFamily family = familyTree.GetApeFamilies().SingleOrDefault(p => p.Partners.Contains(ape));
            List<Ape> children = GetChildren(familyTree, ape);
            List<Ape> grandChildren = new List<Ape>();
            foreach (var child in children)
            {
                grandChildren.AddRange(GetChildren(familyTree, child).Where( c=> c.Gender == GenderType.Male));
            }

            return grandChildren;
        }

        public static List<Ape> GetGrandDaugthers(ApeFamilyTree familyTree, Ape ape)
        {
            ApeFamily family = familyTree.GetApeFamilies().SingleOrDefault(p => p.Partners.Contains(ape));
            List<Ape> children = GetChildren(familyTree, ape);
            List<Ape> grandChildren = new List<Ape>();
            foreach (var child in children)
            {
                grandChildren.AddRange(GetChildren(familyTree, child).Where(c => c.Gender == GenderType.Female));
            }

            return grandChildren;
        }


        public static List<Ape> GetCousins(ApeFamilyTree familyTree, Ape ape)
        {
            List<Ape> result = new List<Ape>();

            List<Ape> father = GetFather(familyTree,ape);
            List<Ape> mother = GetMother(familyTree,ape);

            List<Ape> fatherSideCousins = new List<Ape>();
            foreach (var fatherSideSibling in GetSiblings(familyTree, father.ElementAt(0)))
            {
                fatherSideCousins.AddRange(GetChildren(familyTree, fatherSideSibling));
            }

            List<Ape> motherSideCousins = new List<Ape>();
            foreach (var motherSideSibling in GetSiblings(familyTree, mother.ElementAt(0)))
            {
                motherSideCousins.AddRange(GetChildren(familyTree, motherSideSibling));
            }

            result.AddRange(fatherSideCousins);
            result.AddRange(motherSideCousins);

            return result;
        }


        public static List<Ape> GetBrotherInLaws(ApeFamilyTree familyTree, Ape ape)
        {
            List<Ape> result = new List<Ape>();
            result.AddRange(GetBrothers(familyTree, ape.GetSpouse()));
            List<Ape> sisters = GetSisters(familyTree, ape);
            foreach (var sister in sisters)
            {
                result.Add(sister.GetSpouse());
            }
            return result;
        }

        public static List<Ape> GetSisterInLaws(ApeFamilyTree familyTree, Ape ape)
        {
            List<Ape> result = new List<Ape>();
            result.AddRange(GetSisters(familyTree, ape.GetSpouse()));

            List<Ape> brothers = GetBrothers(familyTree, ape);
            foreach (var brother in brothers)
            {
                result.Add(brother.GetSpouse());
            }
            return result;
        }

        public static List<Ape> GetMaternalAunt(ApeFamilyTree familyTree, Ape ape)
        {
            List<Ape> result = new List<Ape>();
            Ape mother = GetMother(familyTree, ape).ElementAt(0);
            result.AddRange(GetSisters(familyTree, mother));
            result.AddRange(GetSisterInLaws(familyTree, mother));
            return result;
        }

        public static List<Ape> GetMaternalUncle(ApeFamilyTree familyTree, Ape ape)
        {
            List<Ape> result = new List<Ape>();
            Ape mother = GetMother(familyTree, ape).ElementAt(0);
            result.AddRange(GetBrothers(familyTree, mother));
            result.AddRange(GetBrotherInLaws(familyTree, mother));
            return result;
        }

        public static List<Ape> GetPaternalAunt(ApeFamilyTree familyTree, Ape ape)
        {
            List<Ape> result = new List<Ape>();
            Ape father = GetFather(familyTree, ape).ElementAt(0);
            result.AddRange(GetSisters(familyTree, father));
            result.AddRange(GetSisterInLaws(familyTree, father));
            return result;
        }

        public static List<Ape> GetPaternalUncle(ApeFamilyTree familyTree, Ape ape)
        {
            List<Ape> result = new List<Ape>();
            Ape father = GetFather(familyTree, ape).ElementAt(0);
            result.AddRange(GetBrothers(familyTree, father));
            result.AddRange(GetBrotherInLaws(familyTree, father));
            return result;
        }





    }
}