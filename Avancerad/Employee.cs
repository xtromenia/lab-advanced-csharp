namespace Advanced
{
    public class Employee : Person
    {
        public static List<Employee> employees = new List<Employee>();
        public string Title { get; set; }
        public int PayRollNum { get; set; }
        public int BaseSalary { get; set; }

        public delegate void NotifyValidationResult(string result);

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

        /// <summary>
        /// Checks if the provided string input is a valid payroll number.
        /// </summary>
        public static bool ValidatePayRollNumberFormat(string stringInput)
        {
            return int.TryParse(stringInput, out int intOutput);
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

    }
}
