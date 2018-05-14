using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DawnOfTheApes.Interfaces;
using DawnOfTheApes.Services;

namespace DawnOfTheApes.Models
{
    public class Ape : ICalculateSameLevelRelationShip, ICalculateUpBy1Relationship , ICalculateDownBy1Relationship , ICalculateDownBy2Relationship , IManageRelationship
    {
        private readonly string _name;

        private int _depthLevel;

        private readonly GenderType _gender;

        private Ape _spouse;

        public Ape(string name, int depthLevel, GenderType gender)
        {
            _name = name;
            _depthLevel = depthLevel;
            _gender = gender;
        }

        public Ape GetSpouse()
        {
            return _spouse;
        }

        public int GetDepthLevel()
        {
            return _depthLevel;
        }

        public string GetName()
        {
            return _name;
        }

        public GenderType GetGender()
        {
            return _gender;
        }

        public void AddSpouse(Ape ape)
        {
            ape._depthLevel = _depthLevel;
            _spouse = ape;
        }

        public List<Ape> CalculateRelationship(RelationshipType relationshipType,
            ApeFamilyAssociationService familyAssociationService , ApeFamilyService apeFamilyService)
        {
            List<Ape> result = new List<Ape>();
            switch (relationshipType)
            {
                case RelationshipType.Brother:
                case RelationshipType.Sister:
                case RelationshipType.SisterInLaw:
                case RelationshipType.BrotherInLaw:
                case RelationshipType.Cousins:
                    result = CalculateSameLevelRelationship(relationshipType, familyAssociationService,apeFamilyService);
                    break;
                case RelationshipType.Mother:
                case RelationshipType.Father:
                case RelationshipType.PaternalUncle:
                case RelationshipType.MaternalAunt:
                case RelationshipType.PaternalAunt:
                case RelationshipType.MaternalUncle:
                    result = CalculateUpBy1LevelRelationship(relationshipType, familyAssociationService);
                    break;
                case RelationshipType.Children:
                case RelationshipType.Son:
                case RelationshipType.Daughter:
                    result = CalculateDownBy1LevelRelationship(relationshipType, apeFamilyService);
                    break;
                case RelationshipType.GrandChildren:
                case RelationshipType.GrandSon:
                case RelationshipType.GrandDaughter:
                    result = CalculateDownBy2LevelRelationship(relationshipType, apeFamilyService);
                    break;

            }

            return result;
        }

        #region DownBy2

        public List<Ape> CalculateDownBy2LevelRelationship(RelationshipType relationshipType,
            ApeFamilyService familyService)
        {
            List<Ape> result = new List<Ape>();
            switch (relationshipType)
            {
                case RelationshipType.Son:
                    result = GetGrandChildren(GenderType.Male, familyService);
                    break;
                case RelationshipType.Daughter:
                    result = GetGrandChildren(GenderType.Female, familyService);
                    break;
                default:
                    result = GetGrandChildren(familyService);
                    break;
            }

            return result;
        }

        public List<Ape> GetGrandChildren(GenderType gender, ApeFamilyService familyService)
        {
            ApeFamily family = familyService.GetAll().SingleOrDefault(p => p.Partners.Contains(this));
            List<Ape> result = new List<Ape>();
            if (family != null)
            {
                foreach (var r in family.Children.ToList())
                {
                    result.AddRange(r.GetChildren(gender,familyService));
                }
            }

            return result;
        }

        public List<Ape> GetGrandChildren(ApeFamilyService familyService)
        {
            ApeFamily family = familyService.GetAll().SingleOrDefault(p => p.Partners.Contains(this));
            List<Ape> result = new List<Ape>();
            if (family != null)
            {
                foreach (var r in family.Children.ToList())
                {
                    result.AddRange(r.GetChildren(familyService));
                }
            }

            return result;
        }

        #endregion

        #region DownBy1
        public List<Ape> CalculateDownBy1LevelRelationship(RelationshipType relationshipType,
            ApeFamilyService familyService)
        {
            List<Ape> result = new List<Ape>();

            switch (relationshipType)
            {
                case RelationshipType.Son:
                    result = GetChildren(GenderType.Male, familyService);
                    break;
                case RelationshipType.Daughter:
                    result = GetChildren(GenderType.Female, familyService);
                    break;
                default:
                    result = GetChildren(familyService);
                    break;
            }

            return result;
        }

        public List<Ape> GetChildren(GenderType gender,ApeFamilyService familyService)
        {
            ApeFamily family = familyService.GetAll().SingleOrDefault(p => p.Partners.Contains(this));
            List<Ape> result = new List<Ape>();
            if (family != null)
            {
                result = family.Children.Where(c => c.GetGender() == gender).ToList();
            }

            return result;
        }

        public List<Ape> GetChildren(ApeFamilyService familyService)
        {
            ApeFamily family = familyService.GetAll().SingleOrDefault(p => p.Partners.Contains(this));
            List<Ape> result = new List<Ape>();
            if (family != null)
            {
                result = family.Children;
            }

            return result;
        }
        #endregion

        #region UpBy1Level

        public List<Ape> CalculateUpBy1LevelRelationship(RelationshipType relationshipType,
            ApeFamilyAssociationService familyService)
        {
            List<Ape> result = new List<Ape>();

            switch (relationshipType)
            {
                case RelationshipType.Mother:
                    result = GetParent(GenderType.Female, familyService);
                    break;
                case RelationshipType.Father:
                    result = GetParent(GenderType.Male, familyService);
                    break;
                case RelationshipType.MaternalUncle:
                    result = GetUncleOrAuntOnMaternalOrPaternalSide(GenderType.Male, familyService,
                        GetParent(GenderType.Female, familyService).FirstOrDefault());
                    break;
                case RelationshipType.MaternalAunt:
                    result = GetUncleOrAuntOnMaternalOrPaternalSide(GenderType.Female, familyService,
                        GetParent(GenderType.Female, familyService).FirstOrDefault());
                    break;
                case RelationshipType.PaternalAunt:
                    result = GetUncleOrAuntOnMaternalOrPaternalSide(GenderType.Female, familyService,
                        GetParent(GenderType.Male, familyService).FirstOrDefault());
                    break;
                case RelationshipType.PaternalUncle:
                    result = GetUncleOrAuntOnMaternalOrPaternalSide(GenderType.Male, familyService,
                        GetParent(GenderType.Male, familyService).FirstOrDefault());
                    break;
           
            }

            return result;
        }

        public List<Ape> GetParent(GenderType gender, ApeFamilyAssociationService service)
        {
            ApeFamily family = service.GetElement(_name);
            List<Ape> result = new List<Ape>();
            if (family != null)
                result.Add(family.Partners.SingleOrDefault(e => e != this && e.GetGender() == gender));
            return result;
        }

        public List<Ape> GetUncleOrAuntOnMaternalOrPaternalSide(GenderType gender, ApeFamilyAssociationService service,
            Ape ape)
        {
            List<Ape> result = new List<Ape>();
            result.AddRange(ape.GetSiblings(gender, service));
            result.AddRange(ape.GetSisterInLawOrBrotherInLaw(gender, service));
            return result;
        }

        #endregion

        #region SameLevel

        public List<Ape> CalculateSameLevelRelationship(RelationshipType relationshipType,
            ApeFamilyAssociationService familyAssociationService , ApeFamilyService familyService)
        {
            List<Ape> result = new List<Ape>();
            switch (relationshipType)
            {
                case RelationshipType.Brother:
                    result = GetSiblings(GenderType.Male, familyAssociationService);
                    break;
                case RelationshipType.Sister:
                    result = GetSiblings(GenderType.Female, familyAssociationService);
                    break;
                case RelationshipType.SisterInLaw:
                    result = GetSisterInLawOrBrotherInLaw(GenderType.Female, familyAssociationService);
                    break;
                case RelationshipType.BrotherInLaw:
                    result = GetSisterInLawOrBrotherInLaw(GenderType.Male, familyAssociationService);
                    break;
                case RelationshipType.Cousins:
                    result = GetCousins(familyAssociationService,familyService);
                    break;
                default:
                    break;
            }

            return result;

        }

        public List<Ape> GetSisterInLawOrBrotherInLaw(GenderType gender, ApeFamilyAssociationService service)
        {
            List<Ape> result = new List<Ape>();

            result.AddRange(GetSpouse().GetSiblings(gender, service));
            GenderType genderToBeFound = gender == GenderType.Female ? GenderType.Male : GenderType.Female;
            List<Ape> siblings = this.GetSiblings(genderToBeFound, service);
            foreach (var sibling in siblings)
            {
                result.Add(sibling.GetSpouse());
            }

            return result;
        }

        public List<Ape> GetSiblings(GenderType gender, ApeFamilyAssociationService service)
        {
            ApeFamily family = service.GetElement(_name);
            List<Ape> siblings = new List<Ape>();

            if (family != null)
            {
                siblings = family.Children.Where(elem => elem != this && elem.GetGender() == gender).ToList();
            }

            return siblings;
        }

        public List<Ape> GetSiblings(ApeFamilyAssociationService service)
        {
            ApeFamily family = service.GetElement(_name);
            List<Ape> siblings = new List<Ape>();

            if (family != null)
            {
                siblings = family.Children.Where(elem => elem != this).ToList();
            }

            return siblings;
        }

        public List<Ape> GetCousins(ApeFamilyAssociationService service , ApeFamilyService familyService)
        {
            List<Ape> result = new List<Ape>();
            List<Ape> fatherSideCousins = new List<Ape>();
            List<Ape> motherSideCousins = new List<Ape>();

            List<Ape> father = GetParent(GenderType.Male, service);
            List<Ape> mother = GetParent(GenderType.Female, service);

            foreach (var fatherSideSibling in father.ElementAt(0).GetSiblings(service))
            {
                fatherSideCousins.AddRange(fatherSideSibling.GetChildren(familyService));
            }

            foreach (var motherSideSibling in mother.ElementAt(0).GetSiblings(service))
            {
                motherSideCousins.AddRange(motherSideSibling.GetChildren(familyService));
            }

            result.AddRange(fatherSideCousins);
            result.AddRange(motherSideCousins);
            return result;
        }


        #endregion




    }





}

