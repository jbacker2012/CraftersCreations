using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftersCreations.Data;
using CraftersCreations.Models;
using CraftersCreations.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CraftersCreations.Controllers
{
    [Authorize]
    public class MaterialsController : Controller
    {
        private CraftDbContext context;

        public MaterialsController(CraftDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<CraftType> events = context.CraftType.Include(e => e.Materials).OrderBy(e => e.Name).ToList();

            return View(events);
        }

        public IActionResult Add()
        {
            List<CraftType> craftTypes = context.CraftType.ToList();

            AddMaterialViewModel materialViewModel = new AddMaterialViewModel();
            materialViewModel.CraftTypeOptions = craftTypes.Select(craftType => new SelectListItem(craftType.Name, craftType.Id.ToString())).ToList();
            return View(materialViewModel);
        }

        public IActionResult ProcessAddMaterialForm(AddMaterialViewModel viewModel)
        {
            List<CraftType> craftTypes = context.CraftType.ToList();
            viewModel.CraftTypeOptions = craftTypes.Select(craftType => new SelectListItem(craftType.Name, craftType.Id.ToString())).ToList();

            if (ModelState.IsValid)
            {
                Materials material = new Materials(viewModel.Name);
                material.CraftTypeId = viewModel.CraftTypeID; 


                context.Add(material);
                context.SaveChanges();

                return Redirect("/Materials/");
            }

            return View("Add", viewModel);
        }

        public IActionResult About(int id)
        {
            Materials material = context.Materials.First(m => m.Id == id);
            ViewBag.Material = material;
            return View();
        }
    }
}
