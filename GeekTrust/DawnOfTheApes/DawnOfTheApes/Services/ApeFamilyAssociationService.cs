using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DawnOfTheApes.Interfaces;
using DawnOfTheApes.Models;

namespace DawnOfTheApes.Services
{
    public class ApeFamilyAssociationService : IService<ApeFamily>
    {
        private readonly Dictionary<string, ApeFamily> _dict = null;

        private ApeFamilyService _apeFamilyService = null;

        public ApeFamilyAssociationService(ApeFamilyService apeFamilyService)
        {
            _apeFamilyService = apeFamilyService;

            if (_dict == null)
            {
                _dict = new Dictionary<string, ApeFamily>
                {
                    ["Ish"] = apeFamilyService.GetAll().SingleOrDefault(f => f.Name == "0"),
                    ["Chit"] = apeFamilyService.GetAll().SingleOrDefault(f => f.Name == "0"),
                    ["Vich"] = apeFamilyService.GetAll().SingleOrDefault(f => f.Name == "0"),
                    ["Satya"] = apeFamilyService.GetAll().SingleOrDefault(f => f.Name == "0"),
                    ["Drita"] = apeFamilyService.GetAll().SingleOrDefault(f => f.Name == "1"),
                    ["Vrita"] = apeFamilyService.GetAll().SingleOrDefault(f => f.Name == "1"),
                    ["Vila"] = apeFamilyService.GetAll().SingleOrDefault(f => f.Name == "2"),
                    ["Chika"] = apeFamilyService.GetAll().SingleOrDefault(f => f.Name == "2"),
                    ["Satvy"] = apeFamilyService.GetAll().SingleOrDefault(f => f.Name == "3"),
                    ["Savya"] = apeFamilyService.GetAll().SingleOrDefault(f => f.Name == "3"),
                    ["Saayan"] = apeFamilyService.GetAll().SingleOrDefault(f => f.Name == "3"),
                    ["Jaya"] = apeFamilyService.GetAll().SingleOrDefault(f => f.Name == "4"),
                    ["Driya"] = apeFamilyService.GetAll().SingleOrDefault(f => f.Name == "4"),
                    ["Lavnya"] = apeFamilyService.GetAll().SingleOrDefault(f => f.Name == "6"),
                    ["Kriya"] = apeFamilyService.GetAll().SingleOrDefault(f => f.Name == "10"),
                    ["Misa"] = apeFamilyService.GetAll().SingleOrDefault(f => f.Name == "11")
                };
            }
        }

        public void AddElement(string key , ApeFamily family)
        {
            if (_dict.ContainsKey(key))
                throw new Exception("Ape already associated to a family");

            _dict[key] = family;
        }

        public ApeFamily GetElement(string key)
        {
            if (!_dict.ContainsKey(key))
                return null;

            return _dict[key];
        }

        public RelationshipType GetRelationshipBetweenApes(Ape ape1 , Ape ape2)
        {
            if (ape1.GetDepthLevel() == ape2.GetDepthLevel())
            {
                List<RelationshipType> types = Utility.RelationshipLevelToTypes[RelationshipLevelType.Same];
                foreach (var type in types)
                {
                    if (ape1.CalculateSameLevelRelationship(type, this,
                        _apeFamilyService).Contains(ape2))
                    {
                        return type;
                    }
                }
            }

            if (ape1.GetDepthLevel() > ape2.GetDepthLevel())
            {
                List<RelationshipType> types = Utility.RelationshipLevelToTypes[RelationshipLevelType.UpBy1];
                foreach (var type in types)
                {
                    if (ape1.CalculateUpBy1LevelRelationship(type,this).Contains(ape2))
                    {
                        return type;
                    }
                }
            }

            if (ape1.GetDepthLevel() < ape2.GetDepthLevel())
            {
                if (Math.Abs(ape1.GetDepthLevel() - ape2.GetDepthLevel()) == 1)
                {
                    List<RelationshipType> types =
                        Utility.RelationshipLevelToTypes[RelationshipLevelType.DownBy1];
                    foreach (var type in types)
                    {
                        if (ape1.CalculateDownBy1LevelRelationship(type, _apeFamilyService).Contains(ape2))
                        {
                            return type;
                        }
                    }
                }

                if (Math.Abs(ape1.GetDepthLevel() - ape2.GetDepthLevel()) == 2)
                {
                    List<RelationshipType> types =
                        Utility.RelationshipLevelToTypes[RelationshipLevelType.DownBy2];
                    foreach (var type in types)
                    {
                        if (ape1.CalculateDownBy2LevelRelationship(type, _apeFamilyService).Contains(ape2))
                        {
                            return type;
                        }
                    }
                }
            }

            throw  new Exception("Err");
        }

    }
}
