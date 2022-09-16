using Advanced;
using System.Collections.Generic;

namespace HelperLibrary
{
    public static class OldDataHandler
    {

        /// <summary>
        /// Lazy solution, could read the .txt´-file but it's badly formatted.
        /// </summary>
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
