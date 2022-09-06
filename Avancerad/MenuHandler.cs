using ClassLibrary1;

namespace Advanced
{
    internal abstract class MenuHandler
    {
        public static void PrintMainMenu()
        {
            //Show Main Menu = false, but we use a do while so we will need to go thru the loop atleast once.
            bool showMainMenu = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Main Menu\n1. Print General Report.\n2. Print Specific Report.\n3. Register New Data.\n4. Manage Existing Data\nESC. Quit application.");
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
                    default:
                        showMainMenu = true;
                        break;
                }
            } while (showMainMenu);

        }

        private static void PrintManageDataMenu()
        {
            bool showManageMenu = false;

            do
            {
                Console.Clear();
                Console.WriteLine("1 Manage Employees.\n2. Manage Departments.\nESC. Back to main menu.");
                ConsoleKey pressedKey = Console.ReadKey(true).Key;

                switch (pressedKey)
                {
                    case ConsoleKey.D1:
                        PrintManageEmployeeMenu();
                        break;
                    case ConsoleKey.D2:
                        PrintManageDepartmentMenu();
                        break;
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
                        PrintAddDiscipleMenu((Programmer)employee);
                        break;
                    case ConsoleKey.D2:
                        PrintRemoveDiscipleMenu((Programmer)employee);
                        break;
                    case ConsoleKey.D3:
                        PrintChangeSpecializedLanguageMenu(employee);
                        break;
                    case ConsoleKey.D4:
                        PrintChangeDepartmentMenu(employee);
                        break;
                    default:
                        Console.WriteLine("Bad Input, try again.");
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

        private static void PrintChangeSpecializedLanguageMenu(Employee employee)
        {
            throw new NotImplementedException();
        }

        private static void PrintRemoveDiscipleMenu(Programmer programmer)
        {
            throw new NotImplementedException();
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
}
