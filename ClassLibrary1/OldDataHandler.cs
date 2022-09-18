using Advanced;
using System.Collections.Generic;

namespace HelperLibrary
{
    /*
     * Similar to program.cs in the main project.
     * Initiates all the data when PrintOldEmployees is called on by Menuhandler.cs
     */
    public static class OldDataHandler
    {
        private static void RegisterEmployeesFromTXT()
        {
            //Clear the dictionary first so we don't get duplicates.
            OldEmployee.oldDataDictionary.Clear();

            OldDepartment salesDepartment = new OldDepartment("Sales");
            OldDepartment programmingDepartment = new OldDepartment("Programming");
            OldDepartment administrationDepartment = new OldDepartment("Administration");

            new OldEmployee("David", "Wilson", salesDepartment);
            new OldEmployee("Cavid", "Wilson", salesDepartment);
            new OldEmployee("Mark", "Sommers", programmingDepartment);
            new OldEmployee("Christian", "Mann", administrationDepartment);
            new OldEmployee("Salem", "Hassan", programmingDepartment);
            new OldEmployee("Susan", "Gaber", administrationDepartment);
            new OldEmployee("William", "Wilson", salesDepartment);
        }

        public static void PrintOldEmployees()
        {
            Console.Clear();
            RegisterEmployeesFromTXT();
           
            SortedDictionary<OldDepartment, List<OldEmployee>> dictionary = OldEmployee.oldDataDictionary;
            foreach (OldDepartment department in dictionary.Keys)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{department.Name}: ");
                Console.ForegroundColor = ConsoleColor.White;

                dictionary.TryGetValue(department, out List<OldEmployee> employeeList);

                //Sort the list with our own sorting function.
                employeeList.Sort();

                foreach (OldEmployee employee in employeeList)
                {
                    Console.Write($"{employee.GetFullName()}, ");
                }

                Console.WriteLine();
            }
        }
    }
}
