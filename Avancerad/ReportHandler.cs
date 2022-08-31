using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced
{
    internal class ReportHandler
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

            if (int.TryParse(Console.ReadLine(), out int payRollNum))
            {
                Employee employee = Employee.GetEmployee(payRollNum);

                //If the employee is found (he exists).
                if (employee is not null)
                {
                    Console.WriteLine();
                    Console.WriteLine(employee.ToString());
                }

                else
                {
                    Console.WriteLine("Employee not found, please try again.");
                }
            }

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
