using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DawnOfTheApes.Models;
using DawnOfTheApes.Services;

namespace DawnOfTheApes.DataTests
{
    public class DataTest
    {
        [TestFixture]
        public class SampleDataTests
        {
            private ApeService _apeService;
            private ApeFamilyService _apeFamilyService;
            private ApeFamilyAssociationService _apeFamilyAssociationService;

            [SetUp]
            public void Arrange()
            {
                _apeService = new ApeService();
                _apeFamilyService = new ApeFamilyService(_apeService);
                _apeFamilyAssociationService = new ApeFamilyAssociationService(_apeFamilyService);
            }


            [Test]
            public void AssertBrothersOfIshAreCorrect()
            {
                Ape ish = _apeService.GetElement("Ish");
                Ape chit = _apeService.GetElement("Chit");
                Ape vich = _apeService.GetElement("Vich");
                Assert.That(ish.GetSiblings(GenderType.Male,_apeFamilyAssociationService), Is.EqualTo(new List<Ape>() { chit,vich}));
            }

            

            [Test]
            public void AssertAbilityToFindAllMothersWithMaxGirlChildren()
            {
                Ape jaya = _apeService.GetElement("Jaya");
                Ape jnki = _apeService.GetElement("Jnki");
                Ape satya = _apeService.GetElement("Satya");
                Ape lika = _apeService.GetElement("Lika");

                Assert.That(new List<Ape>() {satya , lika , jaya , jnki}, Is.EqualTo(_apeFamilyService.GetMothersWithMaximumGirlApes()));
               

            }

            [Test]
            public void AssertAbilityToAddNewBornToLavanya()
            {
                Ape lavnya = _apeService.GetElement("Lavnya");

                Assert.That(new List<Ape>(), Is.EqualTo(lavnya.GetChildren(GenderType.Female,_apeFamilyService)));

                ApeFamily apeFamily = _apeFamilyService.GetAll().SingleOrDefault(p => p.Partners.Contains(lavnya));
                Ape newBorn = apeFamily?.AddNewBorn("Vanya", lavnya.GetDepthLevel() + 1, GenderType.Female);
                _apeFamilyAssociationService.AddElement(newBorn?.GetName(), apeFamily);
                _apeService.AddElement(newBorn?.GetName(), newBorn);

                Ape vanya = _apeService.GetElement("Vanya");

                Assert.That(new List<Ape>() { vanya }, Is.EqualTo(lavnya.GetChildren(GenderType.Female,_apeFamilyService)));

                Ape jnki = _apeService.GetElement("Jnki");

                Assert.That(new List<Ape>() { vanya },
                    Is.EqualTo(jnki.GetGrandChildren(GenderType.Female, _apeFamilyService)));

            }


            [Test]
            public void AssertPaternalUncleOfKriyaisSaayan()
            {
                Ape kriya = _apeService.GetElement("Kriya");
                Ape saayan = _apeService.GetElement("Saayan");
                Ape asva = _apeService.GetElement("Asva");

                List<Ape> parent = kriya.GetParent(GenderType.Male, _apeFamilyAssociationService);

                Assert.That(new List<Ape>() { saayan ,asva }, Is.EqualTo(kriya.GetUncleOrAuntOnMaternalOrPaternalSide(GenderType.Male,_apeFamilyAssociationService,parent.ElementAt(0))));

                Assert.That(RelationshipType.PaternalUncle,
                    Is.EqualTo(_apeFamilyAssociationService.GetRelationshipBetweenApes(kriya,saayan)));
            }
        }
    }
}
