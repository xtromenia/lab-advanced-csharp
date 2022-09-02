using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced
{
    public class Programmer : Employee
    {
        public Language SpecializedLanguage { get; set; }
        public List<Employee> Disciples { get; set; }
        public Programmer? Mentor { get; set; }
        public Programmer(string firstName, string lastName, int payRollNum, int salary, string title, Language specializedLanguage) : base(firstName, lastName, payRollNum, salary, title)
        {
            Disciples = new List<Employee>();
            SpecializedLanguage = specializedLanguage;
        }
        public int GetCalculatedSalary()
        {
            //1% of salary before calculation.
            int percantage = base.BaseSalary / 100;

            //5% bonus for each disciple.
            int discipleBonus = Disciples.Count * 5 * percantage;

            //x% bonus if programmer's specialized language is in demand.
            int languageBonus = SpecializedLanguage.EnhancementPercentage * percantage;

            return base.BaseSalary + discipleBonus + languageBonus;
        }
        public string GetDiscipleNames()
        {
            List<string> discipleNames = new List<string>();

            if (Disciples.Count > 0)
            {
                foreach (Employee disciple in Disciples)
                {
                    discipleNames.Add(disciple.GetFullName());
                }
            }
            else
            {
                discipleNames.Add("None");
            }
            return string.Join(", ", discipleNames);
        }
        public string GetMentorName()
        {
            foreach (var employee in Employee.employees)
            {
                //If the employee is a programmer they can have a mentor, otherwise not.
                if (employee is Programmer && ((Programmer)employee).Disciples.Contains(this))
                {
                    return employee.GetFullName();
                }
            }

            return "None";
        }

        public override string ToString()
        {
            return $"{GetFullName()} | {Title}\nPayroll number: {PayRollNum}\nSpecialized Language: {SpecializedLanguage.ToString()}\nSalary: {GetCalculatedSalary()}kr\nMentor: {GetMentorName()}\nDisciples: {GetDiscipleNames()} | {Disciples.Count() * 5}% salary increase";
        }
    }
}
