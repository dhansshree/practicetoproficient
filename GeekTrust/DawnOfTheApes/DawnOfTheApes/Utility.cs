using System;
using System.Collections.Generic;
using System.Linq;
using DawnOfTheApes.Models;

namespace DawnOfTheApes
{
    public static class Utility
    {
        public static void PrintName(List<Ape> apes , RelationshipType type)
        {
            if (apes.Any())
            {
                foreach (var ape in apes)
                {
                    Console.WriteLine($"\t " + ape.GetName());
                }
            }
            else
            {
                Console.WriteLine($"" +
                                  $"\t Oops no member found! with relation {type.ToString()}");
            }           
        }


        public static void PrintName(List<Ape> apes)
        {
            if (apes.Any())
            {
                foreach (var ape in apes)
                {
                    Console.WriteLine($"\t " + ape.GetName());
                }
            }
            else
            {
                Console.WriteLine($"Oops no member found!");
            }
        }

        public static void PrintName(Ape ape, RelationshipType type)
        {
            if (ape != null)
            {
                Console.WriteLine($"\t " + ape.GetName());
            }
            else
            {
                Console.WriteLine($"" +
                                  $"\t Oops no member found! with relation {type.ToString()}");
            }
        }


        public static void PrintName(RelationshipType type)
        {
            Console.WriteLine($"\t {type.ToString()}");
        }

        public static Dictionary<RelationshipLevelType, List<RelationshipType>> RelationshipLevelToTypes =
            new Dictionary<RelationshipLevelType, List<RelationshipType>>()
            {
                {RelationshipLevelType.Same , new List<RelationshipType>()
                    {
                        RelationshipType.Brother,RelationshipType.Sister,RelationshipType.BrotherInLaw,RelationshipType.SisterInLaw
                    }
                },
                {RelationshipLevelType.UpBy1 , new List<RelationshipType>()
                {
                    RelationshipType.Mother,
                    RelationshipType.Father,
                    RelationshipType.PaternalUncle,
                    RelationshipType.MaternalAunt,
                    RelationshipType.PaternalAunt,
                    RelationshipType.MaternalUncle
                }},
                {RelationshipLevelType.DownBy1 , new List<RelationshipType>()
                {
                    RelationshipType.Son,RelationshipType.Daughter,RelationshipType.Children
                }},
                {RelationshipLevelType.DownBy2 , new List<RelationshipType>()
                {
                    RelationshipType.GrandChildren,RelationshipType.GrandDaughter,RelationshipType.GrandSon
                }}
            };





    }
}
