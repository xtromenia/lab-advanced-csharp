using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced
{
    internal class MenuHandler
    {
        public static void PrintMainMenu()
        {
            //Show Main Menu = false, but we use a do while so we will need to go thru the loop atleast once.
            bool showMainMenu = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Main Menu\n1. Print General Report.\n2. Print Specific Report.\n3. Register New Data.\nESC. Quit application.");
                ConsoleKey pressedKey = Console.ReadKey(true).Key;

                switch (pressedKey)
                {
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.D1:
                        ReportHandler.PrintGeneralReport();
                        break;
                    case ConsoleKey.D2:
                        ReportHandler.PrintSpecificReport();
                        break;
                    case ConsoleKey.D3:
                        MenuHandler.PrintRegisterDataMenu();
                        break;
                    default:
                        showMainMenu = true;
                        break;
                }
            } while (showMainMenu);

        }

        private static void PrintRegisterDataMenu()
        {
            bool showRegisterMenu = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Register New Data\n1. Register New Employee.\n2. Register New Department.\nESC. Back to main menu.");
                ConsoleKey pressedKey = Console.ReadKey(true).Key;

                switch (pressedKey)
                {
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.D1:
                        MenuHandler.PrintRegisterNewEmployeeMenu();
                        break;
                    case ConsoleKey.D2:
                        MenuHandler.PrintRegisterDepartmentMenu();
                        break;
                    case ConsoleKey.D3:
                        MenuHandler.PrintMainMenu();
                        break;
                    default:
                        showRegisterMenu = true;
                        break;
                }
            } while (showRegisterMenu);
        }

        private static void PrintRegisterDepartmentMenu()
        {
            throw new NotImplementedException();
        }

        private static void PrintRegisterNewEmployeeMenu()
        {
            throw new NotImplementedException();
        }
    }
