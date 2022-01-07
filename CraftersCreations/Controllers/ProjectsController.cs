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
    public class ProjectsController : Controller
    {
        private CraftDbContext context;

        public ProjectsController(CraftDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Projects> events = context.Projects.ToList();

            return View(events);
        }

        public IActionResult Add()
        {
            List<Catagory> catagory = context.Catagory.ToList();

            AddProjectsViewModel projectsViewModel = new AddProjectsViewModel();
            projectsViewModel.CatagoryOptions = catagory.Select(catagory => new SelectListItem(catagory.Name, catagory.Id.ToString())).ToList();
            return View(projectsViewModel);
        }

        public IActionResult ProcessAddProjectsForm(AddProjectsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Projects projects = new Projects(viewModel.Name);


                context.Add(projects);
                context.SaveChanges();

                return Redirect("/Projects/");
            }

            return View("Add", viewModel);
        }

        public IActionResult About(int id)
        {
            Projects projects = context.Projects.First(p => p.Id == id);
            ViewBag.Projects = projects;
            return View();
        }
    }
}
