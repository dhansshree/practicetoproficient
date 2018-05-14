using System.Collections.Generic;
using DawnOfTheApes.Models;
using DawnOfTheApes.Services;

namespace DawnOfTheApes.Interfaces
{
    public interface ICalculateUpBy1Relationship
    {
        List<Ape> GetParent(GenderType genderType, ApeFamilyAssociationService service);
        List<Ape> GetUncleOrAuntOnMaternalOrPaternalSide(GenderType genderType, ApeFamilyAssociationService service , Ape ape);

    }

}