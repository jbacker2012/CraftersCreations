using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftersCreations.Models
{
    public class Catagory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Catagory()
        {
        }

        public Catagory(string name)
        {
            Name = name;

        }
    }
}
