using ClassLibrary1;
using HelperLibrary;
using System;

namespace Advanced
{
    internal static class MenuHandler
    {
        public static void PrintMainMenu()
        {

            //Show Main Menu = false, but we use a do while so we will need to go thru the loop atleast once.
            bool showMainMenu = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Main Menu\n1. Print General Report.\n2. Print Specific Report.\n3. Register New Data.\n4. Manage Existing Data\n5. Print Old Data.\nESC. Quit application.");
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
                    case ConsoleKey.D4:
                        MenuHandler.PrintManageDataMenu();
                        break;
                    case ConsoleKey.D5:
                        MenuHandler.PrintOldEmployeeMenu();
                        break;
                    default:
                        showMainMenu = true;
                        break;
                }

            } while (showMainMenu);

        }

        private static void PrintOldEmployeeMenu()
        {
            OldDataHandler.PrintOldEmployees();
            Console.WriteLine("\nPress any key to return to main menu.");
            Console.ReadKey();
            PrintMainMenu();
        }

        private static void PrintManageDataMenu()
        {
            bool showManageMenu = false;

            do
            {
                Console.Clear();
                //Console.WriteLine("1 Manage Employees.\n2. Manage Departments.\nESC. Back to main menu.");
                Console.WriteLine("1 Manage Employees.\nESC. Back to main menu.");
                ConsoleKey pressedKey = Console.ReadKey(true).Key;

                switch (pressedKey)
                {
                    case ConsoleKey.D1:
                        PrintManageEmployeeMenu();
                        break;
                    //case ConsoleKey.D2:
                    //    PrintManageDepartmentMenu();
                    //    break;
                    case ConsoleKey.Escape:
                        PrintMainMenu();
                        break;
                    default:
                        showManageMenu = true;
                        break;
                }
            } while (showManageMenu);
        }

        private static void PrintManageDepartmentMenu()
        {
            throw new NotImplementedException();
        }

        private static void PrintManageEmployeeMenu()
        {
            bool showMenu = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Manage Employee Menu");

                PrintAllEmployees();

                Console.WriteLine("Enter payroll number for employee you want to manage.");

                string stringPayRollNumber = Console.ReadLine();

                if (Helper.ValidatePayRollNumberFormat(stringPayRollNumber))
                {
                    int payRollNumber = int.Parse(stringPayRollNumber);

                    Employee employee = Employee.GetEmployee(payRollNumber);

                    if (employee is not null)
                    {
                        PrintManageEmployeeSubMenu(employee);
                    }

                    else
                    {
                        Helper.PrintEmployeeNotFoundMessage();
                        Console.ReadKey(true);
                        showMenu = true;
                    }
                }

                else
                {
                    Helper.PrintInvalidPayRollNumberMessage();
                    Console.ReadKey(true);
                    showMenu = true;
                }
            } while (showMenu);
        }

        private static void PrintAllEmployees()
        {
            foreach (var employee in Employee.employees)
            {
                Console.WriteLine($"{employee.PayRollNum} {employee.GetFullName()}");
            }
        }

        private static void PrintAllEmployeeHighlightDisciple(Programmer mentor, bool showMentor)
        {
            foreach (var employee in Employee.employees)
            {
                Console.ForegroundColor = ConsoleColor.White;
                //If the employee we are managing is a mentor and their disciple comes up, mark them green.
                if (mentor.Disciples.Contains(employee))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                if (employee == mentor && showMentor || employee != mentor)
                {
                    Console.WriteLine($"{employee.PayRollNum} {employee.GetFullName()}");
                }
            }
        }

        private static void PrintManageEmployeeSubMenu(Employee employee)
        {
            bool showMenu = false;
            do
            {

                Console.Clear();
                Console.WriteLine(employee.GetFullName());

                //Only some choices are relevant for programmer
                if (employee is Programmer)
                {
                    Console.WriteLine($"1. Add Disciple.");
                    Console.WriteLine($"2. Remove Disciple.");
                    Console.WriteLine($"3. Change Specialized Language.");
                }

                Console.WriteLine($"4. Change Department.");
                Console.WriteLine($"ESC. Return.");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        PrintMainMenu();
                        break;
                    case ConsoleKey.D1:
                        try
                        {
                            PrintAddDiscipleMenu((Programmer)employee);
                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error {employee.GetFullName()} is not a programmer.");
                            showMenu = true;
                            Console.ReadKey(true);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.D2:
                        try
                        {
                            PrintRemoveDiscipleMenu((Programmer)employee);
                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error {employee.GetFullName()} is not a programmer.");
                            showMenu = true;
                            Console.ReadKey(true);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.D3:
                        PrintChangeSpecializedLanguageMenu((Programmer)employee);
                        break;
                    case ConsoleKey.D4:
                        PrintChangeDepartmentMenu(employee);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bad Input, try again.");
                        Console.ForegroundColor = ConsoleColor.White;
                        showMenu = true;
                        Console.ReadKey(true);
                        break;
                }


            } while (showMenu);
        }

        private static void PrintChangeDepartmentMenu(Employee employee)
        {
            throw new NotImplementedException();
        }

        private static void PrintChangeSpecializedLanguageMenu(Programmer programmer)
        {
            Console.Clear();
            Console.WriteLine("Change Specialized Language Menu");
            PrintLanguages(programmer);

            Console.WriteLine($"Enter name of language to make it {programmer.GetFullName()}s new specialized language.");
            string newLanguage = Console.ReadLine();

            if (Language.LanguageExists(newLanguage))
            {
                try
                {
                    programmer.ChangeSpecializedLanguage(Language.GetLanguage(newLanguage));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{programmer.GetFullName()}'s new specialized language is now {programmer.SpecializedLanguage.Name} with a salary increase of {programmer.SpecializedLanguage.EnhancementPercentage}.");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }

                Console.ForegroundColor = ConsoleColor.White;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Language does not exist.");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("ESC.Return to manage menu.\nPress any key to continue.");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Escape:
                    PrintManageEmployeeSubMenu(programmer);
                    break;
                default:
                    PrintChangeSpecializedLanguageMenu(programmer);
                    break;
            }
        }

        private static void PrintLanguages(Programmer programmer)
        {
            foreach (Language language in Language.languages)
            {
                Console.ForegroundColor = ConsoleColor.White;

                if (language == programmer.SpecializedLanguage)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine(language.ToString());
            }
        }
        private static void PrintLanguages()
        {
            foreach (Language language in Language.languages)
            {
                Console.WriteLine(language.ToString());
            }
        }

        private static void PrintRemoveDiscipleMenu(Programmer programmer)
        {
            Console.Clear();
            Console.WriteLine("Remove Disciple Menu\n");

            PrintProgrammersDisciples(programmer);

            Console.WriteLine($"Enter payroll number for employee to remove as disciple under {programmer.GetFullName()}.");

            string stringPayRollNumber = Console.ReadLine();

            if (Helper.ValidatePayRollNumberFormat(stringPayRollNumber))
            {
                int payRollNumber = int.Parse(stringPayRollNumber);
                if (Employee.ValidateEmployee(payRollNumber))
                {
                    Console.WriteLine();
                    try
                    {
                        programmer.RemoveDisciple(payRollNumber);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{Employee.GetEmployee(payRollNumber).GetFullName()} has been removed as a disciple from {programmer.GetFullName()}.");
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ReadKey(true);
                    }
                }

                else
                {
                    Helper.PrintEmployeeNotFoundMessage();
                    Console.ReadKey(true);
                    PrintAddDiscipleMenu(programmer);
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("ESC to return to management menu.\nPress any key to continue.");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        PrintManageEmployeeSubMenu(programmer);
                        break;
                    default:
                        PrintRemoveDiscipleMenu(programmer);
                        break;
                }
            }
            else
            {
                Helper.PrintInvalidPayRollNumberMessage();
                Console.ReadKey(true);
                PrintRemoveDiscipleMenu(programmer);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintProgrammersDisciples(Programmer programmer)
        {
            foreach (Programmer disciple in programmer.Disciples)
            {
                Console.WriteLine($"{disciple.PayRollNum} {disciple.GetFullName()}");
            }
        }

        private static void PrintAddDiscipleMenu(Programmer programmer)
        {
            Console.Clear();

            Console.WriteLine("Add Disciple Menu\n");
            PrintAllEmployeeHighlightDisciple(programmer, false);
            Console.WriteLine($"Enter payroll number for employee to assign as disciple under {programmer.GetFullName()}.");

            string stringPayRollNumber = Console.ReadLine();

            if (Helper.ValidatePayRollNumberFormat(stringPayRollNumber))
            {
                int payRollNumber = int.Parse(stringPayRollNumber);
                if (Employee.ValidateEmployee(payRollNumber))
                {
                    Console.WriteLine();
                    try
                    {
                        programmer.AddDisciple(payRollNumber);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{Employee.GetEmployee(payRollNumber).GetFullName()} added as disciple under {programmer.GetFullName()}");
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("ESC to return to management menu.\nPress any key to continue.");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Escape:
                            PrintManageEmployeeSubMenu(programmer);
                            break;
                        default:
                            PrintAddDiscipleMenu(programmer);
                            break;
                    }
                }
                else
                {
                    Helper.PrintEmployeeNotFoundMessage();
                    Console.ReadKey(true);
                    PrintAddDiscipleMenu(programmer);
                }
            }
            else
            {
                Helper.PrintInvalidPayRollNumberMessage();
                Console.ReadKey(true);
                PrintAddDiscipleMenu(programmer);
            }
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
                        MenuHandler.PrintMainMenu();
                        break;
                    case ConsoleKey.D1:
                        MenuHandler.PrintRegisterNewEmployeeMenu();
                        break;
                    case ConsoleKey.D2:
                        MenuHandler.PrintRegisterDepartmentMenu();
                        break;
                    default:
                        PrintRegisterDataMenu();
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
            bool enterPayRollNum = true;

            int payRollNum = -1;

            while (enterPayRollNum)
            {
                Console.Write("Enter employee's payroll number: ");

                string enteredPayRollNum = Console.ReadLine();

                if (Helper.ValidatePayRollNumberFormat(enteredPayRollNum))
                {
                    payRollNum = int.Parse(enteredPayRollNum);

                    //If an employee exists with the given payroll number.
                    if (Employee.ValidateEmployee(payRollNum))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"An employee with the payrollnumber {payRollNum} already exists. Please try again.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    else
                    {
                        enterPayRollNum = false;
                    }
                }

                else
                {
                    Helper.PrintInvalidPayRollNumberMessage();
                }
            }

            Console.Write("Enter employee's firstname: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter employee's surname: ");
            string lastName = Console.ReadLine();

            bool enterSalary = true;
            int salary = 0;

            while (enterSalary)
            {
                Console.Write("Enter employee's salary:");

                if (int.TryParse(Console.ReadLine(), out salary))
                {
                    enterSalary = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid salary, try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.Write("Enter employee title:");
            string title = Console.ReadLine();

            bool deciding = true;

            while (deciding)
            {

                Console.WriteLine("Do you want to register this employee as a programmer?\n1. Yes.\n2. No.");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        PrintLanguages();
                        Programmer newProgrammer = new Programmer(firstName, lastName, payRollNum, salary, title);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"New programmer {newProgrammer.GetFullName()} has been registered.");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("Press ESC to exit or any key to select a specialized language.");

                        if (Console.ReadKey().Key != ConsoleKey.Escape)
                        {
                            Console.Write("Enter Desired specialised language: ");
                            PrintLanguages();
                            string language = Console.ReadLine();
                            newProgrammer.ChangeSpecializedLanguage(Language.GetLanguage(language));
                            PrintRegisterDataMenu();
                        }

                        else
                        {
                            PrintRegisterDataMenu();
                        }

                        break;

                    case ConsoleKey.D2:
                        Employee newEmployee = new Employee(firstName, lastName, payRollNum, salary, title);
                        Console.WriteLine($"New employee {newEmployee.GetFullName()} has been registered.");
                        break;
                    default:
                        break;
                }

            }



            PrintMainMenu();
        }
    }
}
