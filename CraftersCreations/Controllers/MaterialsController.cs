using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftersCreations.Data;
using CraftersCreations.Models;
using CraftersCreations.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CraftersCreations.Controllers
{
    public class MaterialsController : Controller
    {
        private CraftDbContext context;

        public MaterialsController(CraftDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Materials> events = context.Materials.ToList();

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
            if (ModelState.IsValid)
            {
                Materials material = new Materials(viewModel.Name);


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
