using Avancerad;

RegisterStartupEmployees();
PrintMainMenu();

static void PrintGeneralReport()
{
    foreach (Employee employee in Employee.employees)
    {
        Console.WriteLine(employee.ToString());
    }

    Console.ReadKey(true);

    PrintMainMenu();
}

static void PrintSpecificReport()
{
    Console.Clear();
    Console.Write("Enter Employee Payroll Number to print: ");
    if (int.TryParse(Console.ReadLine(), out int payRollNum))
    {

        Employee employee = Employee.GetEmployee(payRollNum);

        if (employee is not null)
        {
            Console.WriteLine(employee.ToString());
        }

        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    else
    {
        Console.WriteLine("Invalid payroll number, please try again.");
        Console.ReadKey(true);
        PrintSpecificReport();
    }

}

static void PrintMainMenu()
{
    //Show Main Menu = false, but we use a do while so we will need to go thru the loop atleast once.
    bool showMainMenu = false;

    do
    {
        Console.Clear();
        Console.WriteLine("Employee Manager 2000\n1. Print General Report.\n2. Print Specific Report.\nESC. Quit application.");

        ConsoleKey pressedKey = Console.ReadKey(true).Key;

        switch (pressedKey)
        {
            case ConsoleKey.Escape:
                Environment.Exit(0);
                break;
            case ConsoleKey.D1:
                PrintGeneralReport();
                break;
            case ConsoleKey.D2:
                PrintSpecificReport();
                break;
            default:
                Console.WriteLine("Invalid Input.");
                showMainMenu = true;
                break;
        }
    } while (showMainMenu);

}

static void RegisterStartupEmployees()
{
    Programmer p = new Programmer("Kenny Gustavsson", 1337, 30000, "C#");
    Programmer p2 = new Programmer("Benny Johnsson", 12, 30000, "C#");
    Programmer p3 = new Programmer("Lenny Andersson", 112, 30000, "C#");

    p.Disciples.Add(p2);
    p.Disciples.Add(p3);
}

