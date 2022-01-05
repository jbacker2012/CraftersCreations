using CraftersCreations.Models;
using Microsoft.AspNetCore.Mvc;
using CraftersCreations.Data;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CraftersCreations.ViewModels;

namespace CraftersCreations.Controllers
{
    public class CraftTypeController : Controller
    {
        private CraftDbContext context;

        public CraftTypeController(CraftDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<CraftType> events = context.CraftType.ToList();

            return View(events);
        }

        public IActionResult Add()
        {
            return View(new AddCraftTypeViewModel());
        }

        public IActionResult ProcessAddCraftTypeForm(AddCraftTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                CraftType craftType = new CraftType(viewModel.Name);


                context.Add(craftType);
                context.SaveChanges();

                return Redirect("/CraftType/");
            }

            return View("Add", viewModel);
        }
        public IActionResult About(int id)
        {
            CraftType craftTypes = context.CraftType.First(t => t.Id == id);
            ViewBag.CraftType = craftTypes;
            return View();
        }
    }
}
