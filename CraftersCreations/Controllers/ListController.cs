using CraftersCreations.Data;
using CraftersCreations.Models;
using CraftersCreations.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftersCreations.Controllers
{
    public class ListController : Controller
    {
        internal static Dictionary<string, string> ColumnChoices = new Dictionary<string, string>()
        {
           
            {"inventory", "Inventory"},
            {"project", "Project"}
        };

        internal static List<string> TableChoices = new List<string>()
        {
            "Inventory",
            "Project"
        };

        private CraftDbContext context;
        public ListController(CraftDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            ViewBag.columns = ColumnChoices;
            ViewBag.tablechoices = TableChoices;
            ViewBag.materials = context.Materials.ToList();
            ViewBag.Projects = context.Projects.ToList();
            return View();
           
        }
    }
}
