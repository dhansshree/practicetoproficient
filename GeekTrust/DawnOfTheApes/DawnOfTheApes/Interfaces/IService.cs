using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DawnOfTheApes.Interfaces
{

    public interface IService<T>
    {
        void AddElement(string key, T value);
        T GetElement(string key);
    }

}
