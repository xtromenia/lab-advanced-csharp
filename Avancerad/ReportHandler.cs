using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced
{
    internal abstract class ReportHandler
    {
        public static void PrintGeneralReport()
        {
            Console.Clear();


            foreach (Employee employee in Employee.employees)
            {
                Console.WriteLine(employee.ToString());
                Console.WriteLine();
            }

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"Total monthly salary cost for company: {Employee.GetTotalMonthlyCost()}kr");

            bool showMenu = true;

            while (showMenu)
            {
                Console.WriteLine();
                Console.WriteLine("1.Sort Employee List by Ascending First Name.\n2.Sort Employee List by Ascending Last Name.\n3.Sort Employee list by Ascending Salary.\nPress ESC to return to main menu.");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        showMenu = false;
                        MenuHandler.PrintMainMenu();
                        break;
                    case ConsoleKey.D1:
                        showMenu = false;
                        Employee.SortEmployeeListAscendingFirstName();
                        PrintGeneralReport();
                        break;
                    case ConsoleKey.D2:
                        showMenu = false;
                        Employee.SortEmployeeListAscendingLastName();
                        PrintGeneralReport();
                        break;
                    case ConsoleKey.D3:
                        showMenu = false;
                        Employee.SortEmployeeListAscendingSalary();
                        PrintGeneralReport();
                        break;
                    default:
                        break;
                }

            }

        }

        //https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?view=net-6.0



        public static void PrintSpecificReport()
        {
            Console.Clear();
            Console.Write("Enter Employee Payroll Number to print: ");

            string stringPayRollNum = Console.ReadLine();

            //Check if payroll number is integer.
            if (Helper.ValidatePayRollNumberFormat(stringPayRollNum))
            {
                int payRollNumber = int.Parse(stringPayRollNum);

                //Check if there is an employee with that number.
                if (Employee.ValidateEmployee(payRollNumber))
                {
                    Console.WriteLine();
                    Console.WriteLine(Employee.GetEmployee(payRollNumber).ToString());
                }

                //If there is no employee with number ->.
                else
                {
                    Helper.PrintEmployeeNotFoundMessage();
                }
            }

            //If payroll number is not correctly formatted, integer only.
            else
            {
                Helper.PrintInvalidPayRollNumberMessage();
            }

            Console.WriteLine("\nPress enter to check again or ESC to return to main menu.");

            ConsoleKey pressedKey = Console.ReadKey(true).Key;

            switch (pressedKey)
            {
                case ConsoleKey.Escape:
                    MenuHandler.PrintMainMenu();
                    break;
                default:
                    PrintSpecificReport();
                    break;
            }
        }

    }
}
