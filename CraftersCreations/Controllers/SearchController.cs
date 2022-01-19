using CraftersCreations.Data;
using CraftersCreations.Models;
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
            return View();
        }

        //public IActionResult (string searchType, string searchTerm)
        //{
        //    List<Materials> materials;
        //    List<CraftType> displayCraft = new List<CraftType>();
           

        //    if (string.IsNullOrEmpty(searchTerm))
        //    {
        //        materials = context.Materials
        //            .Include(m => m.CraftType)
        //            .ToList();
                
        //    }

        //    return View();
        //}
    }
}
    
