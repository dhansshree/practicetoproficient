using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DawnOfTheApes.Models;

namespace DawnOfTheApes.DataTests
{
    public class DataTest
    {
        [TestFixture]
        public class SampleDataTests
        {
            private ApeFamilyTree shawnFamilyTree = null;

            // RelationshipManager.Relationships[RelationshipType.Mother]
            //Utility.PrintName((Ape)RelationshipManager.Relationships[RelationshipType.Mother].DynamicInvoke(ish),RelationshipType.Mother);
            //Utility.PrintName((Ape)RelationshipManager.Relationships[RelationshipType.Father].DynamicInvoke(ish),RelationshipType.Father);
            //Utility.PrintName((List<Ape>)RelationshipManager.Relationships[RelationshipType.Sister].DynamicInvoke(ish),RelationshipType.Sister);
            //Utility.PrintName((List<Ape>)RelationshipManager.Relationships[RelationshipType.Brother].DynamicInvoke(ish),RelationshipType.Brother);
            //Ape king = shawnFamilyTree.Apes["King Shan"];
            //Utility.PrintName((Ape)RelationshipManager.Relationships[RelationshipType.Mother].DynamicInvoke(king), RelationshipType.Mother);
            //Utility.PrintName((Ape)RelationshipManager.Relationships[RelationshipType.Father].DynamicInvoke(king), RelationshipType.Father);
            //Utility.PrintName((List<Ape>)RelationshipManager.Relationships[RelationshipType.Sister].DynamicInvoke(king), RelationshipType.Sister);
            //Utility.PrintName((List<Ape>)RelationshipManager.Relationships[RelationshipType.Brother].DynamicInvoke(king), RelationshipType.Brother);
            //Utility.PrintName((List<Ape>)RelationshipManager.Relationships[RelationshipType.Children].DynamicInvoke(king,shawnFamilyTree.GetApeFamilies()), RelationshipType.Children);
            //Utility.PrintName((List<Ape>)RelationshipManager.Relationships[RelationshipType.Son].DynamicInvoke(king, shawnFamilyTree.GetApeFamilies()), RelationshipType.Son);
            //Utility.PrintName((List<Ape>)RelationshipManager.Relationships[RelationshipType.Daughter].DynamicInvoke(king, shawnFamilyTree.GetApeFamilies()), RelationshipType.Daughter);
            //Utility.PrintName((List<Ape>)RelationshipManager.Relationships[RelationshipType.PaternalUncle].DynamicInvoke(driya, shawnFamilyTree.GetApeFamilies(),shawnFamilyTree.Apes), RelationshipType.PaternalUncle);


            [SetUp]
            public void Arrange()
            {
               shawnFamilyTree = Utility.InitializeShanFamilyTreeWithGivenSampleData();
            }

            [Test]
            public void AssertBrothersOfIshAreCorrect()
            {
                Ape ish = shawnFamilyTree.Apes["Ish"];
                Ape chit = shawnFamilyTree.Apes["Chit"];
                Ape vich = shawnFamilyTree.Apes["Vich"];
                Assert.That((List<Ape>)RelationshipManager.Relationships[RelationshipType.Brother].DynamicInvoke(shawnFamilyTree,ish), Is.EqualTo(new List<Ape>() { chit,vich}));
            }

            

            [Test]
            public void AssertAbilityToFindAllMothersWithMaxGirlChildren()
            {
                Ape jaya = shawnFamilyTree.Apes["Jaya"];
                Ape jnki = shawnFamilyTree.Apes["Jnki"];
                Ape satya = shawnFamilyTree.Apes["Satya"];
                Ape lika = shawnFamilyTree.Apes["Lika"];

                List<Ape> f = shawnFamilyTree.FindApesWithMaximumGrandChildren();
                Assert.That(new List<Ape>() {lika ,satya  , jaya , jnki}, Is.EqualTo(shawnFamilyTree.FindApesWithMaximumGrandChildren()));

               

            }

            [Test]
            public void AssertAbilityToAddNewBornToLavanya()
            {
                Ape lavnya = shawnFamilyTree.Apes["Lavnya"];

                Assert.That(new List<Ape>(), Is.EqualTo((List<Ape>)RelationshipManager.Relationships[RelationshipType.Daughter].DynamicInvoke(shawnFamilyTree, lavnya)));

                shawnFamilyTree.DetermineFamilyTreeAndAddNewBorn(lavnya.Name, "Vanya", GenderType.Female.ToString());

                Ape vanya = shawnFamilyTree.Apes["Vanya"];

                Assert.That(new List<Ape>() { vanya }, Is.EqualTo((List<Ape>)RelationshipManager.Relationships[RelationshipType.Daughter].DynamicInvoke(shawnFamilyTree, lavnya)));

                Ape jnki = shawnFamilyTree.Apes["Jnki"];
                Assert.That(new List<Ape>() { vanya }, Is.EqualTo((List<Ape>)RelationshipManager.Relationships[RelationshipType.GrandChildren].DynamicInvoke(shawnFamilyTree, jnki)));

            }


            [Test]
            public void AssertPaternalUncleOfKriyaisSaayan()
            {
                Ape kriya = shawnFamilyTree.Apes["Kriya"];
                Ape saayan = shawnFamilyTree.Apes["Saayan"];
                Ape asva = shawnFamilyTree.Apes["Asva"];

                Assert.That(new List<Ape>() { saayan ,asva }, Is.EqualTo((List<Ape>)RelationshipManager.Relationships[RelationshipType.PaternalUncle].DynamicInvoke(shawnFamilyTree, kriya)));

                Assert.That(RelationshipType.PaternalUncle,
                    Is.EqualTo(
                        shawnFamilyTree.DetermineValidityAndFindRelationShipsBetweenApes(kriya.Name, saayan.Name)));
            }
        }
    }
}
