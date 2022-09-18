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
    /*
     * This class describes an old employee from the assignment's A-requirement.
     * Originally the employees would automatically be created from the employees.txt file but it wasn't really good formatted on canvas so i could not find a pattern in the text-file.
     * Otherwise we could use regular expressions for getting first-, lastname and department from the file.
     * 
     * We use a SortedDictionary with department as key and a list of employees as value. Therefore we can get all employees that are bound to a specific department by using department as a key.
     * Implements the IComparable interface to give a custom sort-order.
     */
    public sealed class OldEmployee : IComparable<OldEmployee>
    {
        public static readonly SortedDictionary<OldDepartment, List<OldEmployee>> oldDataDictionary =  new SortedDictionary<OldDepartment, List<OldEmployee>>();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public OldEmployee(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public OldEmployee(string firstName, string lastName, OldDepartment department)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

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
