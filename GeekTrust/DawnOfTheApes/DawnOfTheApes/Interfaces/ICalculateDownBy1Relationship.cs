using System.Collections.Generic;
using DawnOfTheApes.Models;
using DawnOfTheApes.Services;

namespace DawnOfTheApes.Interfaces
{
    public interface ICalculateDownBy1Relationship
    {
        List<Ape> GetChildren(GenderType genderType, ApeFamilyService service);
        List<Ape> GetChildren(ApeFamilyService service);
    }
}