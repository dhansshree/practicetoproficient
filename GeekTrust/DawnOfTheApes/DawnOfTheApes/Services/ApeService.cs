using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DawnOfTheApes.Interfaces;
using DawnOfTheApes.Models;

namespace DawnOfTheApes.Services
{
    public  class ApeService : IService<Ape>
    {
        private readonly Dictionary<string, Ape> _dict = null;

        public void AddElement(string key ,Ape ape)
        {
            if (_dict.ContainsKey(key))
                throw new Exception("Ape already exisits with this name.");

            _dict[key] = ape;
        }

        public Ape GetElement(string key)
        {
            if (!_dict.ContainsKey(key))
                throw new Exception("No Ape found in Family Tree");

            return _dict[key];
        }

        public List<Ape> GetAll()
        {
            return _dict.Values.ToList();
        }

        public ApeService()
        {
            if (_dict == null)
            {
                List<Ape> apes = new List<Ape>()
                {
                    new Ape("King Shan", 0, GenderType.Male),
                    new Ape("Queen Anga", 0, GenderType.Female),
                    new Ape("Ish",
                        1,
                        GenderType.Male),
                    new Ape("Chit",
                        1,
                        GenderType.Male),
                    new Ape("Vich",
                        1,
                        GenderType.Male),
                    new Ape("Satya",
                        1,
                        GenderType.Female),
                    new Ape("Ambi",
                        1,
                        GenderType.Female),
                    new Ape("Lika",
                        1,
                        GenderType.Female),
                    new Ape("Vyan",
                        1,
                        GenderType.Male),
                    new Ape("Drita",
                        2,
                        GenderType.Male),
                    new Ape("Vrita",
                        2,
                        GenderType.Male),
                    new Ape("Jaya",
                        2,
                        GenderType.Female),
                    new Ape("Vila",
                        2,
                        GenderType.Male),
                    new Ape("Jnki",
                        2,
                        GenderType.Female),
                    new Ape("Chika",
                        2,
                        GenderType.Female),
                    new Ape("Kpila",
                        2,
                        GenderType.Male),
                    new Ape("Satvy",
                        2,
                        GenderType.Female),
                    new Ape("Asva",
                        2,
                        GenderType.Male),
                    new Ape("Savya",
                        2,
                        GenderType.Male),
                    new Ape("Krpi",
                        2,
                        GenderType.Female),
                    new Ape("Saayan",
                        2,
                        GenderType.Male),
                    new Ape("Mina",
                        2,
                        GenderType.Female),
                    new Ape("Jata",
                        3,
                        GenderType.Male),
                    new Ape("Driya",
                        3,
                        GenderType.Female),
                    new Ape("Mnu",
                        3,
                        GenderType.Male),
                    new Ape("Lavnya",
                        3,
                        GenderType.Female),
                    new Ape("Gru",
                        3,
                        GenderType.Male),
                    new Ape("Kriya",
                        3,
                        GenderType.Male),
                    new Ape("Misa",
                        3,
                        GenderType.Male)
            };

            _dict = apes.ToDictionary(a => a.GetName(), a => a);

            }

        }
    }
}
