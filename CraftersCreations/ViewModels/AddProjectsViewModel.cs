using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftersCreations.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CraftersCreations.ViewModels
{
    public class AddProjectsViewModel
    {
        [Required(ErrorMessage = "Project name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Craft Type is required")]
        public int CatagoryID { get; set; }
        public IList<SelectListItem> CatagoryOptions { get; set; }
    }
}