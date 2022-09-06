using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced
{
    internal class Department
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
        public Department(string name, string description, int ID)
        {
            Name = name;
            Description = description;
            this.ID = ID;
        }
        public Department(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public Department(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
