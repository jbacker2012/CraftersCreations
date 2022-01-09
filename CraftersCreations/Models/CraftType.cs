using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftersCreations.Models
{
    public class CraftType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Materials> Materials { get; set; }

        public CraftType()
        {
        }

        public CraftType(string name)
        {
            Name = name;

        }
    }
}
