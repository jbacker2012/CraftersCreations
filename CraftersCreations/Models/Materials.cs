using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftersCreations.Models
{
    public class Materials
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CraftType CraftType { get; set; }
        public int CraftTypeId { get; set; }

        public Materials()
        {            
        }

        public Materials(string name)
        {
            Name = name;
            
        }
    }  
}
