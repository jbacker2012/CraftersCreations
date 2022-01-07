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
    public class CatagoryController : Controller
    {
        private CraftDbContext context;

        public CatagoryController(CraftDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Catagory> events = context.Catagory.ToList();

            return View(events);
        }

        public IActionResult Add()
        {
            return View(new AddCatagoryViewModel());
        }

        public IActionResult ProcessAddCatagoryForm(AddCatagoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Catagory catagory = new Catagory(viewModel.Name);


                context.Add(catagory);
                context.SaveChanges();

                return Redirect("/Catagory/");
            }

            return View("Add", viewModel);
        }
        public IActionResult About(int id)
        {
            Catagory catagory = context.Catagory.First(c => c.Id == id);
            ViewBag.Catagory = catagory;
            return View();
        }
    }
}
