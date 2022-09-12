namespace Advanced
{
    public class Employee : Person
    {
        public static readonly List<Employee> employees = new List<Employee>();
        public string Title { get; set; }
        public int PayRollNum { get; set; }
        public int BaseSalary { get; set; }

        public Employee(string firstName, string lastName, int payRollNum, int salary, string title) : base(firstName, lastName)
        {
            PayRollNum = payRollNum;
            BaseSalary = salary;
            Title = title;
            employees.Add(this);
        }

        public static Employee GetEmployee(int payRollNum)
        {
            return employees.Find(x => x.PayRollNum == payRollNum);
        }
        public override string ToString()
        {
            return $"Name: {base.GetFullName()} | {Title}\nPayroll number: {PayRollNum}\nSalary: {BaseSalary}kr";
        }

        public virtual int GetSalary()
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

        /// <summary>
        /// Can maybe use polymorphism here.
        /// </summary>
        /// <returns></returns>
        internal static int GetTotalMonthlyCost()
        {
            //Gets the total sum of salary the company has to pay each month.
            int totalCost = employees.Sum(m => m.GetSalary());

            return totalCost;
        }

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
