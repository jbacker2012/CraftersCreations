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
            List<Catagory> events = context.Catagory.Include(e => e.Projects).OrderBy(e => e.Name).ToList();

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
            List<Catagory> catagory = context.Catagory.ToList();
            viewModel.CatagoryOptions = catagory.Select(catagory => new SelectListItem(catagory.Name, catagory.Id.ToString())).ToList();

            if (ModelState.IsValid)
            {
                
                Projects projects = new Projects(viewModel.Name);
                projects.CatagoryId = viewModel.CatagoryID;

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
