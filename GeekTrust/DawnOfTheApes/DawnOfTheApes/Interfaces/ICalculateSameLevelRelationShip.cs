using System.Collections.Generic;
using DawnOfTheApes.Models;
using DawnOfTheApes.Services;

namespace DawnOfTheApes.Interfaces
{
    public interface ICalculateSameLevelRelationShip
    {
        List<Ape> GetSisterInLawOrBrotherInLaw(GenderType gender, ApeFamilyAssociationService service);
        List<Ape> GetSiblings(GenderType gender, ApeFamilyAssociationService service);
        List<Ape> GetSiblings(ApeFamilyAssociationService service);
        List<Ape> GetCousins(ApeFamilyAssociationService service ,ApeFamilyService familyService);
    }
}