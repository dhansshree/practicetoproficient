using DawnOfTheApes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DawnOfTheApes.Services;

namespace DawnOfTheApes
{
    class Program
    {
        static void Main(string[] args)
        {

            ApeService apeService = new ApeService();
            ApeFamilyService apeFamilyService = new ApeFamilyService(apeService);
            ApeFamilyAssociationService apeFamilyAssociationService = new ApeFamilyAssociationService(apeFamilyService);

            int userInput = 0;
            do
            {
                userInput = DisplayMenu(apeService);
                switch (userInput)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Please enter the name of the Ape you want to find relationship for:");
                            string apeName = Console.ReadLine();
                            Console.WriteLine("Enter RelationShip Type");
                            string relationShipType = Console.ReadLine();

                            Ape ape = apeService.GetElement(apeName);

                            Models.RelationshipType relationship;

                            if(!Enum.TryParse(relationShipType, true, out relationship))
                                throw new Exception("Invalid Relationship");

                            List<Ape> apes = ape.CalculateRelationship(relationship, apeFamilyAssociationService, apeFamilyService);

                            Utility.PrintName(apes);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("We should start from all over");
                        }

                        break;
                    case 2:
                        
                        try
                        {
                            Console.WriteLine("Please enter the name of the parent you want add the family under");
                            string parent = Console.ReadLine();
                            Console.WriteLine("Enter child name:");
                            string child = Console.ReadLine();
                            Console.WriteLine("Enter child gender:");
                            string genderType = Console.ReadLine();

                            Ape parentApe = apeService.GetElement(parent);
                            Models.GenderType gender;
                            if (!Enum.TryParse(genderType, true, out gender))
                                throw new Exception("We are not aware of such a gender!!");

                            ApeFamily apeFamily = apeFamilyService.GetAll().SingleOrDefault(p => p.Partners.Contains(parentApe));

                            if (apeFamily == null)
                                throw new Exception("That would be incorrect. Apes are not Godzillas.");

                            Ape newBorn = apeFamily.AddNewBorn(child, parentApe.GetDepthLevel() + 1, gender);
                            apeFamilyAssociationService.AddElement(child,apeFamily);
                            apeService.AddElement(newBorn.GetName(),newBorn);

                            Console.WriteLine($"New born {newBorn.GetName()} successfully added to family");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("We should start from all over");
                        }

                       break;
                    case 3:
                       
                        Utility.PrintName(apeFamilyService.GetMothersWithMaximumGirlApes());

                        break;

                    case 4:
                      
                        try
                        {
                            Console.WriteLine("Please enter the name of the ape1");
                            string ape1Name = Console.ReadLine();
                            Console.WriteLine("Please enter the name of the ape1");
                            string ape2Name = Console.ReadLine();

                            Ape ape1 = apeService.GetElement(ape1Name);
                            Ape ape2 = apeService.GetElement(ape2Name);

                            Utility.PrintName(apeFamilyAssociationService.GetRelationshipBetweenApes(ape1, ape2));

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("We should start from all over");
                        }
                        break;
                }

            } while (userInput != 5);

            Console.WriteLine();

        }

        public static int DisplayMenu(ApeService apeService)
        {
            Console.WriteLine("");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Welcome to Shan Family Tree");
            Console.WriteLine("These are the total list of apes , please use exact names");
            foreach (Ape ape in apeService.GetAll())
            {
                Console.Write(ape.GetName() + $"\t");
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
            int input;
            if (Int32.TryParse(result, out input))
                return input;
            return 5;
        }

    }
}
