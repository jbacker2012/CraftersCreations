using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftersCreations.Models
{
    public class Projects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Catagory Catagory { get; set; }

        public Projects()
        {
        }

        public Projects(string name)
        {
            Name = name;

        }
    }
}

