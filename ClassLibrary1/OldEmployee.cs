using Advanced;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        ///Sort by last name first, if the name is the same we sort on firstname aswell.
        public int CompareTo(OldEmployee? y)
        {
            if (this.LastName.Equals(y.LastName))
            {
                return this.FirstName.CompareTo(y.FirstName);
            }
            else
            {
                return this.LastName.CompareTo(y.LastName);
            }
        }

    }
}
