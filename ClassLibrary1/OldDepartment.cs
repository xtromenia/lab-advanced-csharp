using HelperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced
{
    public sealed class OldDepartment: IComparable<OldDepartment>
    {
        public string Name { get; set; }
        public OldDepartment(string name)
        {
            Name = name;
            OldEmployee.oldDataDictionary.TryAdd(this, new List<OldEmployee>());
        }

        public override string ToString()
        {
            return Name;
        }

        //sort by name.
        public int CompareTo(OldDepartment? otherDepartment)
        {
            return this.Name.CompareTo(otherDepartment.Name);
        }
    }
}
