using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    interface ICloneable<T> : ICloneable
    {
        T CloneObject();
    }
}
