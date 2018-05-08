using DawnOfTheApes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DawnOfTheApes
{
    class Program
    {
        static void Main(string[] args)
        {

            ApeFamilyTree shawnFamilyTree = Utility.InitializeShanFamilyTreeWithGivenSampleData();
            int userInput = 0;
            do
            {
                userInput = DisplayMenu(shawnFamilyTree);
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("Please enter the name of the Ape you want to find relationship for:");
                        string apeName = Console.ReadLine();
                        Console.WriteLine("Enter RelationShip Type");
                        string relationShipType = Console.ReadLine();
                        
                        try
                        {
                            List<Ape> apes =
                                shawnFamilyTree.DetermineValidityAndFindRelationShips(apeName, relationShipType);

                            Models.RelationshipType relationship = Models.RelationshipType.Mother;
                            Enum.TryParse(relationShipType, true, out relationship);

                            Utility.PrintName(apes,relationship);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("We should start from all over");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Please enter the name of the parent you want add the family under");                        
                        string parent = Console.ReadLine();
                        Console.WriteLine("Enter child name:");
                        string child = Console.ReadLine();
                        Console.WriteLine("Enter child gender:");
                        string gender = Console.ReadLine();
                        try
                        {
                            Ape newBorn = shawnFamilyTree.DetermineFamilyTreeAndAddNewBorn(parent,child,gender);
                            Console.WriteLine($"New born {newBorn.Name} successfully added to family");
                        }
                        catch (Exception e)
                        {
                           Console.WriteLine(e.Message);
                           Console.WriteLine("We should start from all over");
                        }
                        break;
                    case 3:
                        Utility.PrintName(shawnFamilyTree.FindApesWithMaximumGrandChildren());
                        break;

                    case 4:
                        Console.WriteLine("Please enter the name of the ape1");
                        string ape1 = Console.ReadLine();
                        Console.WriteLine("Please enter the name of the ape1");
                        string ape2 = Console.ReadLine();
                        try
                        {
                            RelationshipType relationshipType = shawnFamilyTree.DetermineValidityAndFindRelationShipsBetweenApes(ape1, ape2);
                            Utility.PrintName(relationshipType);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("We should start from all over");
                        }
                        break;
                    default:
                        break;
                }

            } while (userInput != 5);

            Console.WriteLine();

        }

        public static int DisplayMenu(ApeFamilyTree familyTree)
        {
            Console.WriteLine("");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Welcome to Shan Family Tree");
            Console.WriteLine("These are the total list of apes , please use exact names");
            foreach (var ape in familyTree.Apes)
            {
                Console.Write(ape.Key + $"\t");
            }
            Console.WriteLine();
            Console.WriteLine("These are the total list of Relations , please use exact names");
            foreach (var relationship in Enum.GetNames(typeof(RelationshipType)))
            {
                Console.Write(relationship + $"\t");
            }

            Console.WriteLine();
            Console.WriteLine("1. Get Relations of Ape");
            Console.WriteLine("2. Add a NewBorn into Family");
            Console.WriteLine("3. Find Mother with Maximum number of Girl Childs");
            Console.WriteLine("4. Find Relation between two Apes");
            Console.WriteLine("5. Exit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }

    }
}
