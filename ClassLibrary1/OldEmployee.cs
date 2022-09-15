using Advanced;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary
{
    public class OldEmployee : IComparable<OldEmployee>
    {
        public static SortedDictionary<OldDepartment, List<OldEmployee>> oldDataDictionary =  new SortedDictionary<OldDepartment, List<OldEmployee>>();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        OldDepartment Department { get; set; }

        public OldEmployee(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public OldEmployee(string firstName, string lastName, OldDepartment department)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Department = department;

            oldDataDictionary.TryGetValue(department, out List<OldEmployee> employeeList);
            employeeList.Add(this);
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public int Compare(OldEmployee? x, OldEmployee? y)
        {
            return x.FirstName.CompareTo(y.FirstName);
        }

        public int CompareTo(OldEmployee? y)
        {
            return this.FirstName.CompareTo(y.FirstName);
        }
    }
}
