using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced
{
    public class Programmer : Employee
    {
        public Language SpecializedLanguage { get; set; }
        public List<Employee> Disciples { get; set; }
        public Programmer Mentor { get; set; }
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

        public override int GetSalary()
        {
            return GetCalculatedSalary();
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
            foreach (var employee in employees)
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
            return $"{GetFullName()} | {Title}\nPayroll number: {PayRollNum}\nSpecialized Language: {SpecializedLanguage.ToString()}\nSalary: {GetSalary()}kr\nMentor: {GetMentorName()}\nDisciples: {GetDiscipleNames()} | {Disciples.Count() * 5}% salary increase";
        }

        internal void AddDisciple(int payRollNumber)
        {
            var discipleToAdd = GetEmployee(payRollNumber);

            if (discipleToAdd is not Programmer)
            {
                throw new Exception($"Error {discipleToAdd.GetFullName()} cannot be added as a disciple because they are not a programmer.");
            }

            if (Disciples.Contains(discipleToAdd))
            {
                throw new Exception($"Error cannot add {this.GetFullName()} as disciple,{this.GetFullName()} is already mentor over {discipleToAdd.GetFullName()}");
            }

            if (this.Mentor == discipleToAdd)
            {
                throw new Exception($"Error cannot add {discipleToAdd.GetFullName()} as a disciple because he/she is mentor over {this.GetFullName()}");
            }

            if (this == discipleToAdd)
            {
                throw new Exception($"Error {discipleToAdd.GetFullName()} cannot add themselves as a disciple.");
            }

            ((Programmer)discipleToAdd).Mentor = this;
            this.Disciples.Add(discipleToAdd);
        }

        internal void RemoveDisciple(int payRollNumber)
        {
            Programmer discipleToRemove = (Programmer)GetEmployee(payRollNumber);

            if (discipleToRemove == this)
            {
                throw new Exception($"Error {discipleToRemove.GetFullName()} cannot remove themselves from being a disciple.");
            }
            if (discipleToRemove.Mentor != this)
            {
                throw new Exception($"Error {discipleToRemove.GetFullName()} cannot be removed as a disciple because {this.GetFullName()} is not their mentor.");
            }
            else
            {
                this.Disciples.Remove(discipleToRemove);
                discipleToRemove.Mentor = null;
            }
        }

        internal void ChangeSpecializedLanguage(Language language)
        {
            if (language == SpecializedLanguage)
            {
                throw new Exception($"Language not changed, selected language was same as {this.GetFullName()}s specialized language.");
            }
            else
            {
                SpecializedLanguage = language;
            }
        }
    }
}
