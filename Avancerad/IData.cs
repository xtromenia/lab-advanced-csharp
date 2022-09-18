using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced
{
    /// <summary>
    /// Interface that is implemented on classes where we want to print alot of data, similar to tostring-method but this one will return everything.
    /// </summary>
    interface IData
    {
        abstract string GetAllData();
    }
}
