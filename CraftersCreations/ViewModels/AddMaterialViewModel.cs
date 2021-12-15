using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftersCreations.Models;
using System.ComponentModel.DataAnnotations;


namespace CraftersCreations.ViewModels
{
    public class AddMaterialViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

     
    }
}
