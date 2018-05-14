using System.Collections.Generic;
using DawnOfTheApes.Models;
using DawnOfTheApes.Services;

namespace DawnOfTheApes.Interfaces
{
    public interface IManageRelationship
    {
        List<Ape> CalculateSameLevelRelationship(RelationshipType relationshipType, ApeFamilyAssociationService service , ApeFamilyService family );
        List<Ape> CalculateUpBy1LevelRelationship(RelationshipType relationshipType, ApeFamilyAssociationService service );
        List<Ape> CalculateDownBy1LevelRelationship(RelationshipType relationshipType, ApeFamilyService service);
        List<Ape> CalculateDownBy2LevelRelationship(RelationshipType relationshipType, ApeFamilyService service);
    }
}