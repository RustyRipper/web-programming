using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7
{
    public class Department
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public Department(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public string helloDepartment(string name, string lName)
        {
            return $"Hello {name} {lName}, Welcome to Department {Name}, Id:{Id}";
        }

        public override string ToString()
        {
            return $"{Id,2}), {Name,11}";
        }

    }
}
