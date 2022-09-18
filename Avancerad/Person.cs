using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Abstract class that describes a person, you cannot create an object of this class.
/// Properties such as name, adress and age are something that ll people have in common.
/// Registering age and adress is not fully implemented in this version of the program, you can register it via code in program.cs but not via the CLI.
/// 
/// We provide code for returning a persons full name, (first + last) this is later passed down onto Employee and Programmer class.
/// We also supply an empty abstract function GetSalary() that wil be passed down and used differently with polymorphism based on what type of object calls it.
/// Even if it is not possible to create an object from this class we supply a constructor that it's sub-classes can use to populate the properties.
/// </summary>
namespace Advanced
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

        public Person(string firstName, string lastName, int age, string adress)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Address = adress;
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public abstract int GetSalary();
    }
}
