using System.Collections.Generic;
using System.Linq;
using DawnOfTheApes.Models;
using DawnOfTheApes.Services;

namespace DawnOfTheApes.Services
{
    public class ApeFamilyService
    {
        private readonly List<ApeFamily> _list = null;

        private ApeService _apeService = null;

        public List<ApeFamily> GetAll()
        {
            return _list;
        }

        public List<Ape> GetMothersWithMaximumGirlApes()
        {
            Dictionary<Ape, int> familyAndGirlChildCount = new Dictionary<Ape, int>();
            List<Ape> youngMothers = _apeService.GetAll()
                .Where(a => a.GetGender() == GenderType.Female && a.GetDepthLevel() > 0).ToList();
            foreach (var ape in youngMothers)
            {
                familyAndGirlChildCount[ape] = ape.GetChildren(GenderType.Female, this).Count();
            }

            List<KeyValuePair<Ape, int>> list = familyAndGirlChildCount
                .Where(x => x.Value == familyAndGirlChildCount.Values.Max()).ToList();
            List<Ape> result = new List<Ape>();
            foreach (var kvp in list)
            {
                result.Add(kvp.Key);
            }

            return result;
        }
        

        public ApeFamilyService(ApeService apeService)
        {
            _apeService = apeService;

            if (_list == null)
            {
                _list = new List<ApeFamily>();

                ApeFamily family = new ApeFamily("0",
                    new List<Ape>() {apeService.GetElement("King Shan"), apeService.GetElement("Queen Anga")},
                    new List<Ape>()
                    {
                        apeService.GetElement("Ish"),
                        apeService.GetElement("Chit"),
                        apeService.GetElement("Vich"),
                        apeService.GetElement("Satya")
                    });
                ApeFamily family1 = new ApeFamily("1",
                    new List<Ape>() {apeService.GetElement("Chit"), apeService.GetElement("Ambi")},
                    new List<Ape>()
                    {
                        apeService.GetElement("Drita"),
                        apeService.GetElement("Vrita")
                    });
                ApeFamily family2 = new ApeFamily("2",
                    new List<Ape>() {apeService.GetElement("Vich"), apeService.GetElement("Lika")},
                    new List<Ape>()
                    {
                        apeService.GetElement("Vila"),
                        apeService.GetElement("Chika")
                    });

                ApeFamily family3 = new ApeFamily("3",
                    new List<Ape>() {apeService.GetElement("Satya"), apeService.GetElement("Vyan")},
                    new List<Ape>()
                    {
                        apeService.GetElement("Satvy"),
                        apeService.GetElement("Savya"),
                        apeService.GetElement("Saayan")
                    });

                ApeFamily family4 = new ApeFamily("4",
                    new List<Ape>() {apeService.GetElement("Drita"), apeService.GetElement("Jaya")},
                    new List<Ape>() {apeService.GetElement("Jata"), apeService.GetElement("Driya")});

                ApeFamily family5 = new ApeFamily("5",
                    new List<Ape>() {apeService.GetElement("Driya"), apeService.GetElement("Mnu")},
                    new List<Ape>() { });

                ApeFamily family6 = new ApeFamily("6",
                    new List<Ape>() {apeService.GetElement("Vila"), apeService.GetElement("Jnki")},
                    new List<Ape>() {apeService.GetElement("Lavnya")});

                ApeFamily family7 = new ApeFamily("7",
                    new List<Ape>() {apeService.GetElement("Lavnya"), apeService.GetElement("Gru")},
                    new List<Ape>() { });

                ApeFamily family8 = new ApeFamily("8",
                    new List<Ape>() {apeService.GetElement("Chika"), apeService.GetElement("Kpila")},
                    new List<Ape>() { });

                ApeFamily family9 = new ApeFamily("9",
                    new List<Ape>() {apeService.GetElement("Satvy"), apeService.GetElement("Asva")},
                    new List<Ape>() { });

                ApeFamily family10 = new ApeFamily("10",
                    new List<Ape>() {apeService.GetElement("Savya"), apeService.GetElement("Krpi")},
                    new List<Ape>() {apeService.GetElement("Kriya")});

                ApeFamily family11 = new ApeFamily("11",
                    new List<Ape>() {apeService.GetElement("Saayan"), apeService.GetElement("Mina")},
                    new List<Ape>() {apeService.GetElement("Misa")});

                _list.Add(family);
                _list.Add(family1);
                _list.Add(family2);
                _list.Add(family3);
                _list.Add(family4);
                _list.Add(family5);
                _list.Add(family6);
                _list.Add(family7);
                _list.Add(family8);
                _list.Add(family9);
                _list.Add(family10);
                _list.Add(family11);

            }
        }

    }
}