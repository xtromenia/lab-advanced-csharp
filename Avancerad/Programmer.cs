using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced
{
    /*
     * Programmer class is a more specialized company employee which got some additional properties to mirror that.
     * Each programmer has a specialized language, they can have a list of disciples and they can have a mentor.
     * When i read the assignment i concluded that only programmers can have and be discpiles/mentors. Therefore the programmer data-type was selected for these variables.  
     * Using polymorphism we can calculate salary differently for Employees whom are of the programmer type. This way we can include the salary enhancement percentage in specializedlanguage and amount of disciples.
     * 
     * This class implements custom exceptions when the user tries to add or remove disciples from a programmer or trying to change a programmers specialized language.
     */
    public sealed class Programmer : Employee
    {
        public Language SpecializedLanguage { get; set; }
        public List<Programmer> Disciples { get; set; }
        public Programmer Mentor { get; set; }
        public Programmer(string firstName, string lastName, int payRollNum, int age, string adress, int salary, string title, Language specializedLanguage) : base(firstName, lastName, payRollNum, age, adress, salary, title)
        {
            Disciples = new List<Programmer>();
            SpecializedLanguage = specializedLanguage;
        }
        public Programmer(string firstName, string lastName, int payRollNum, int salary, string title, Language specializedLanguage) : base(firstName, lastName, payRollNum, salary, title)
        {
            Disciples = new List<Programmer>();
            SpecializedLanguage = specializedLanguage;
        }

        public Programmer(string firstName, string lastName, int payRollNum, int salary, string title) : base(firstName, lastName, payRollNum, salary, title)
        {
            Disciples = new List<Programmer>();
            SpecializedLanguage = null;
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

        //Returns all data, uses tostring and adds extra data.
        public override string GetAllData()
        {
            return $"{this}\nAdress: {base.Address ?? "Not Registered"}\nAge: {base.Age}\nPayroll number: {PayRollNum}\nSpecialized Language: {SpecializedLanguage}\nSalary: {this.GetSalary()}kr\nMentor: {GetMentorName()}\nDisciples: {GetDiscipleNames()} | {Disciples.Count() * 5}% salary increase";
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

        //Tostring short but descriptive, nice for debugging tool.
        public override string ToString()
        {
            return $"{GetFullName()} | {Title}";
        }

        internal void AddDisciple(Programmer programmer)
        {
            AddDisciple(programmer.PayRollNum);
        }

        internal void AddDisciple(int payRollNumber)
        {
            var discipleToAdd = GetEmployee(payRollNumber);

            //if employee is not programmer.
            if (discipleToAdd is not Programmer)
            {
                throw new Exception($"Error {discipleToAdd.GetFullName()} cannot be added as a disciple because they are not a programmer.");
            }

            //if employee is already a disciple of the programmer.
            if (Disciples.Contains(discipleToAdd))
            {
                throw new Exception($"Error cannot add {this.GetFullName()} as disciple,{this.GetFullName()} is already mentor over {discipleToAdd.GetFullName()}");
            }

            //If trying to add own's mentor as disciple.
            if (this.Mentor == discipleToAdd)
            {
                throw new Exception($"Error cannot add {discipleToAdd.GetFullName()} as a disciple because he/she is mentor over {this.GetFullName()}");
            }

            //If trying to add one self as a disciple.
            if (this == discipleToAdd)
            {
                throw new Exception($"Error {discipleToAdd.GetFullName()} cannot add themselves as a disciple.");
            }

            ((Programmer)discipleToAdd).Mentor = this;
            this.Disciples.Add((Programmer)discipleToAdd);
        }

        internal void RemoveDisciple(int payRollNumber)
        {
            Programmer discipleToRemove = (Programmer)GetEmployee(payRollNumber);

            //If the disciple to remove is one self.
            if (discipleToRemove == this)
            {
                throw new Exception($"Error {discipleToRemove.GetFullName()} cannot remove themselves from being a disciple.");
            }

            //If trying to remove an employee that is not your disciple.
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
