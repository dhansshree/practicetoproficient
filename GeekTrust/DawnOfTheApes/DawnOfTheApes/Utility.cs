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
                    Console.WriteLine($"\t " + ape.Name);
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
                    Console.WriteLine($"\t " + ape.Name);
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
                Console.WriteLine($"\t " + ape.Name);
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

        public static ApeFamilyTree InitializeShanFamilyTreeWithGivenSampleData()
        {
            Ape kingShan = new Ape("King Shan", 0, GenderType.Male);
            Ape queenAnga = new Ape("Queen Anga", 0, GenderType.Female);
            Ape ish = new Ape("Ish", 1, GenderType.Male);
            Ape chit = new Ape("Chit", 1, GenderType.Male);
            Ape vich = new Ape("Vich", 1, GenderType.Male);
            Ape satya = new Ape("Satya", 1, GenderType.Female);
            Ape ambi = new Ape("Ambi", 1, GenderType.Female);
            Ape lika = new Ape("Lika", 1, GenderType.Female);
            Ape vyan = new Ape("Vyan", 1, GenderType.Male);
            Ape drita = new Ape("Drita", 2, GenderType.Male);
            Ape vrita = new Ape("Vrita", 2, GenderType.Male);
            Ape jaya = new Ape("Jaya", 2, GenderType.Female);
            Ape vila = new Ape("Vila", 2, GenderType.Male);
            Ape jnki = new Ape("Jnki", 2, GenderType.Female);
            Ape chika = new Ape("Chika", 2, GenderType.Female);
            Ape kpila = new Ape("Kpila", 2, GenderType.Male);
            Ape satvy = new Ape("Satvy", 2, GenderType.Female);
            Ape asva = new Ape("Asva", 2, GenderType.Male);
            Ape savya = new Ape("Savya", 2, GenderType.Male);
            Ape krpi = new Ape("Krpi", 2, GenderType.Female);
            Ape saayan = new Ape("Saayan", 2, GenderType.Male);
            Ape mina = new Ape("Mina", 2, GenderType.Female);
            Ape jata = new Ape("Jata", 3, GenderType.Male);
            Ape driya = new Ape("Driya", 3, GenderType.Female);
            Ape mnu = new Ape("Mnu", 3, GenderType.Male);
            Ape lavnya = new Ape("Lavnya", 3, GenderType.Female);
            Ape gru = new Ape("Gru", 3, GenderType.Male);
            Ape kriya = new Ape("Kriya", 3, GenderType.Male);
            Ape misa = new Ape("Misa", 3, GenderType.Male);

            ApeFamily family = new ApeFamily(new List<Ape>() { kingShan, queenAnga }, new List<Ape>() { ish, chit, vich, satya });
            ish.SetFamily(family);
            chit.SetFamily(family);
            vich.SetFamily(family);
            satya.SetFamily(family);
            ApeFamily family1 = new ApeFamily(new List<Ape>() { chit, ambi }, new List<Ape>() { drita, vrita });
            drita.SetFamily(family1);
            vrita.SetFamily(family1);
            ApeFamily family2 = new ApeFamily(new List<Ape>() { vich, lika }, new List<Ape>() { vila, chika });
            vila.SetFamily(family2);
            chika.SetFamily(family2);
            ApeFamily family3 = new ApeFamily(new List<Ape>() { satya, vyan }, new List<Ape>() { satvy, savya, saayan });
            satvy.SetFamily(family3);
            savya.SetFamily(family3);
            saayan.SetFamily(family3);
            ApeFamily family4 = new ApeFamily(new List<Ape>() { drita, jaya }, new List<Ape>() { jata, driya });
            jata.SetFamily(family4);
            driya.SetFamily(family4);
            ApeFamily family5 = new ApeFamily(new List<Ape>() { driya, mnu }, new List<Ape>() { });
            ApeFamily family6 = new ApeFamily(new List<Ape>() { vila, jnki }, new List<Ape>() { lavnya });
            lavnya.SetFamily(family6);
            ApeFamily family7 = new ApeFamily(new List<Ape>() { lavnya, gru }, new List<Ape>() { });
            ApeFamily family8 = new ApeFamily(new List<Ape>() { chika, kpila }, new List<Ape>() { });
            ApeFamily family9 = new ApeFamily(new List<Ape>() { satvy, asva }, new List<Ape>() { });
            ApeFamily family10 = new ApeFamily(new List<Ape>() { savya, krpi }, new List<Ape>() { kriya });
            kriya.SetFamily(family10);
            ApeFamily family11 = new ApeFamily(new List<Ape>() { saayan, mina }, new List<Ape>() { misa });
            misa.SetFamily(family11);

            Dictionary<string, Ape> dict = new Dictionary<string, Ape>()
            {
                {kingShan.Name, kingShan},
                {queenAnga.Name, queenAnga},
                {ish.Name, ish},
                {chit.Name, chit},
                {vich.Name, vich},
                {satya.Name, satya},
                { ambi.Name, ambi},
                {lika.Name, lika},
                {vyan.Name, vyan},
                {drita.Name, drita},
                {vrita.Name, vrita},
                {jaya.Name, jaya},
                {vila.Name, vila},
                {jnki.Name, jnki},
                {chika.Name, chika},
                {kpila.Name, kpila},
                {satvy.Name, satvy},
                {asva.Name, asva},
                {savya.Name, savya},
                {krpi.Name, krpi},
                {saayan.Name, saayan},
                {mina.Name, mina},
                {jata.Name, jata},
                {driya.Name, driya},
                {mnu.Name, mnu},
                {lavnya.Name, lavnya},
                {gru.Name, gru},
                {kriya.Name, kriya},
                {misa.Name, misa},
            };

            List<ApeFamily> families = new List<ApeFamily>()
            {
                family,
                family1,
                family2,
                family3,
                family4,
                family5,
                family6,
                family7,
                family8,
                family9,
                family10,
                family11
            };

            return new ApeFamilyTree(dict, families);

        }
    }
}
