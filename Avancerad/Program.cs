using Advanced;


StartUpDelegate languageDelegate = new StartUpDelegate(RegisterStartupLanguages);
StartUpDelegate employeeDelegate = new StartUpDelegate(RegisterStartupEmployees);

StartUpDelegate generalDelegate = languageDelegate + employeeDelegate;

//RegisterStartupLanguages();
//RegisterStartupEmployees();

generalDelegate();
MenuHandler.PrintMainMenu();


static void RegisterStartupLanguages()
{
    Language csharp = new Language("C#", 10);
    Language java = new Language("Java");
    Language python = new Language("Python");
    Language cpp = new Language("C++");
    Language javascript = new Language("JavaScript");
    Language cobol = new Language("Cobol");
}

static void RegisterStartupEmployees()
{
    Programmer kenny = new Programmer("Kenny", "Gustavsson", 1, 30000, "Senior Programmer", Language.GetLanguage("C#"));
    Programmer lars = new Programmer("Lars", "Johnsson", 2, 30000, "Junior Programmer", Language.GetLanguage("C#"));
    Programmer bertil = new Programmer("Bertil", "Andersson", 3, 30000, "Junior Programmer", Language.GetLanguage("C#"));
    Programmer lisa = new Programmer("Lisa", "Kurtsson", 4, 30000, "Senior Programmer", Language.GetLanguage("Java"));
    Programmer anna = new Programmer("Anna", "Stensson", 5, 30000, "Senior Programmer", Language.GetLanguage("C++"));

    Employee karl = new Employee("Karl", "Bobsson", 6, 27000, "Receptionist");
    Employee stefan = new Employee("Stefan", "Arnesson", 7, 26000, "Janitor");

    kenny.AddDisciple(lars.PayRollNum);
    kenny.AddDisciple(bertil.PayRollNum);
}

public delegate void StartUpDelegate();

