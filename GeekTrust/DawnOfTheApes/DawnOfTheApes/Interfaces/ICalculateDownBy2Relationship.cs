using System.Collections.Generic;
using DawnOfTheApes.Models;
using DawnOfTheApes.Services;

namespace DawnOfTheApes.Interfaces
{
    public interface ICalculateDownBy2Relationship
    {
        List<Ape> GetGrandChildren(GenderType genderType, ApeFamilyService service);
        List<Ape> GetGrandChildren(ApeFamilyService service);

    }
}