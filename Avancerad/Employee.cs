namespace Avancerad
{
    public class Employee
    {
        public static List<Employee> employees = new List<Employee>();
        public string Name { get; set; }
        public int PayRollNum { get; set; }
        public int BaseSalary { get; set; }
        public Employee(string name, int payRollNum, int salary)
        {
            Name = name;
            PayRollNum = payRollNum;
            BaseSalary = salary;
            employees.Add(this);
        }
        public static Employee GetEmployee(int payRollNum)
        {
            return employees.Find(x => x.PayRollNum == payRollNum);
        }
        public override string ToString()
        {
            return $"Name: {Name}\n\nPayroll number {PayRollNum}\nSalary: {BaseSalary}";
        }
    }
}
