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

            Console.WriteLine("\nPress any button to return to main menu.");
            Console.ReadKey(true);

            MenuHandler.PrintMainMenu();
        }



        public static void PrintSpecificReport()
        {
            Console.Clear();
            Console.Write("Enter Employee Payroll Number to print: ");

            string stringPayRollNum = Console.ReadLine();

            //Check if payroll number is integer.
            if (Employee.ValidatePayRollNumberFormat(stringPayRollNum))
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
                    Console.WriteLine("Employee not found, please try again.");
                }
            }

            //If payroll number is not correctly formatted, integer only.
            else
            {
                Console.WriteLine("Invalid payroll number, please try again.");
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
