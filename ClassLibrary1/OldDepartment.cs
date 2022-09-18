using HelperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced
{
    /*
     * Class describes a department from the old data that was required for the A-requirement.
     * Impleents IComparable to create a custom sort-order.
     * When a department is created we add it to the oldDataDictionary so that we can later add employees to it.
     */
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
