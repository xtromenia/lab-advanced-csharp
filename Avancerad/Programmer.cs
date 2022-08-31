using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avancerad
{
    public class Programmer : Employee
    {
        public Programmer(string name, int payRollNum, int salary, string specialLanguage) : base(name, payRollNum, salary)
        {
            Disciples = new List<Employee>();
            SpecialLanguage = specialLanguage;
        }
        public string SpecialLanguage { get; set; }
        public List<Employee> Disciples { get; set; }
        public Programmer Mentor { get; set; }
        public int GetCalculatedSalary()
        {
            int percantage = (base.BaseSalary / 100);
            return base.BaseSalary + (percantage * (Disciples.Count * 5));
        }
        public string GetDiscipleNames()
        {
            List<string> discipleNames = new List<string>();

            foreach (Employee disciple in Disciples)
            {
                discipleNames.Add(disciple.Name);
            }

            return string.Join(',', discipleNames);
        }
        public override string ToString()
        {
            return $"\n\n{Name}\nPayroll number: {PayRollNum}\nSpecialized Language: {SpecialLanguage}\nSalary: {GetCalculatedSalary()}kr\nDisciples: {GetDiscipleNames()}";
        }
    }
}
