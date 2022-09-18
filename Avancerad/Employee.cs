namespace Advanced
{
    /*
     * Employee.cs describes an employee in the company.
     * My reasoning for including this class as a non abstract class is because the company should be able to employ employees with roles that are not programmers.
     * 
     * Is based on the person class but includes even more properties that are more tightly connected to the company.
     * Such as title, payroll number and base salary.
     * The employee class also contains a list of all the employees registered in the company, i don't know if this is the right place for this list but it works well since it is static.
     * 
     * Implements the IData interface which includes a method-defenition for returning all data about an object.
     */
    public class Employee : Person, IData
    {
        //Instead of using list<T> we could have used a normal dictionary here where we use payrollnum as key and the Employee as value.
        //Dictionary<int, Employee> this would also be changed if i had more time but the list mechanics were already implemented.
        public static readonly List<Employee> employees = new List<Employee>();
        public string Title { get; set; }
        public int PayRollNum { get; set; }

        //Should be double or decimal, integer was picked for ease of use and would be changed if i had more time to implement it.
        public int BaseSalary { get; set; }


        //Different constructors depending on how much information we have about the Employee when initiazing it.
        public Employee(string firstName, string lastName, int payRollNum, int age, string adress,  int salary, string title) : base(firstName, lastName, age, adress)
        {
            PayRollNum = payRollNum;
            BaseSalary = salary;
            Title = title;
            employees.Add(this);
        }

        public Employee(string firstName, string lastName, int payRollNum, int salary, string title) : base(firstName, lastName)
        {
            PayRollNum = payRollNum;
            BaseSalary = salary;
            Title = title;
            employees.Add(this);
        }

        //Used broadly in the application to find a specific employee using payroll number, this is where a dictionary would be faster.
        public static Employee GetEmployee(int payRollNum)
        {
            return employees.Find(x => x.PayRollNum == payRollNum);
        }

        //Overriden tostring is useful when using the debugger tool.
        public override string ToString()
        {
            return $"Name: {base.GetFullName()} | {Title}";
        }

        //Returns all data, uses tostring and adds extra data.
        public virtual string GetAllData()
        {
            return $"{this}\nAdress: {base.Address ?? "Not Registered"}\nAge: {base.Age}\nPayroll number: {PayRollNum}\nSalary: {BaseSalary}kr";
        }

        //Employee class only returns the base salary since there's no extra calculation needed.
        public override int GetSalary()
        {
            return BaseSalary;
        }

        /// <summary>
        /// Checks if there's an employee with the provided payroll number.
        /// </summary>
        public static bool ValidateEmployee(int payRollNumber)
        {
            if (GetEmployee(payRollNumber) is not null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Gets the total sum of salary the company has to pay each month.
        //Using polymorphism we can get calculated salary for programmers by calling GetSalary.
        internal static int GetTotalMonthlyCost()
        {
            int totalCost = employees.Sum(m => m.GetSalary());

            return totalCost;
        }

        //Sorting using the IComparable interface but using a delegate.
        //In the HelperLibrary iam using IComparable interface by implementing it to the oldDepartment.cs and OldEmployee.cs.
        internal static void SortEmployeeListAscendingSalary()
        {
            employees.Sort(delegate (Employee x, Employee y)
            {
                if (x.GetSalary() == null && y.GetSalary() == null) return 0;
                else if (x.GetSalary() == null) return -1;
                else if (y.GetSalary() == null) return 1;
                else return x.GetSalary().CompareTo(y.GetSalary());
            });
        }

        internal static void SortEmployeeListAscendingLastName()
        {
            employees.Sort(delegate (Employee x, Employee y)
            {
                if (x.LastName == null && y.LastName == null) return 0;
                else if (x.LastName == null) return -1;
                else if (y.LastName == null) return 1;
                else return x.LastName.CompareTo(y.LastName);
            });
        }

        internal static void SortEmployeeListAscendingFirstName()
        {
            employees.Sort(delegate (Employee x, Employee y)
            {
                if (x.FirstName == null && y.FirstName == null) return 0;
                else if (x.FirstName == null) return -1;
                else if (y.FirstName == null) return 1;
                else return x.FirstName.CompareTo(y.FirstName);
            });
        }


    }
}
