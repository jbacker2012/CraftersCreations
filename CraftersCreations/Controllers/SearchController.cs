using CraftersCreations.Data;
using CraftersCreations.Models;
using CraftersCreations.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftersCreations.Controllers
{
    public class SearchController : Controller
    {
        private CraftDbContext context;

        public SearchController(CraftDbContext dbContext)
        {
            context = dbContext;
        }



        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.searchType = searchType;
            ViewBag.columns = ListController.ColumnChoices;
            if (searchType == "project")
            {
                List<Projects> projects;
                if (string.IsNullOrEmpty(searchTerm))
                {
                    projects = context.Projects
                        .Include(m => m.Catagory)
                        .ToList();
                }
                else
                {
                    projects = context.Projects.Include(m => m.Catagory).Where(m => m.Name.Contains(searchTerm)).ToList();
                }
                ViewBag.projects = projects;
            }
            else
            {
                List<Materials> materials;
                if (string.IsNullOrEmpty(searchTerm))
                {
                    materials = context.Materials
                        .Include(m => m.CraftType)
                        .ToList();
                }
                else
                {
                    materials = context.Materials.Include(m => m.CraftType).Where(m => m.Name.Contains(searchTerm)).ToList();
                }
                ViewBag.materials = materials;
            }

            return View("Index");
        }
    }
}
    
