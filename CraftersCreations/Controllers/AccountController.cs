using CraftersCreations.Models;
using Microsoft.AspNetCore.Mvc;
using CraftersCreations.Data.Repositories;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using CraftersCreations.ViewModels;
using CraftersCreations.Data;

namespace CraftersCreations.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository userRepositroy;
        private readonly CraftDbContext dbContext;

        public AccountController(IUserRepository userRepository, CraftDbContext dbContext)
        {
            this.dbContext = dbContext;
            userRepositroy = userRepository;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "/")
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }
        public IActionResult ProcessAddUserForm (AddAccountViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
               var User = new User();
                User.Name = viewModel.Name;
                User.Email = viewModel.Email;

                dbContext.Add(User);
                dbContext.SaveChanges();

                return Redirect("/Account/");
            }

            return View("Add", viewModel);
        }
        public IActionResult Index()
        {
            List<User> events = dbContext.User.ToList();

            return View(events);
        }
        public IActionResult Add()
        {
            return View(new AddAccountViewModel());
        }
       

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> Login(LoginModel model)
        //{
        //    var user = context.GetByUsernameAndPassword(model.Username, model.Password);
        //    if (user == null)
        //        return Unauthorized();

        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Email, user.Id.ToString()),
        //    };

        //    var identity = new ClaimsIdentity(claims,
        //        CookieAuthenticationDefaults.AuthenticationScheme);
        //    var principal = new ClaimsPrincipal(identity);

        //    await HttpContext.SignInAsync(
        //        CookieAuthenticationDefaults.AuthenticationScheme,
        //        principal,
        //        new AuthenticationProperties { IsPersistent = model.RememberLogin });

        //    return LocalRedirect(model.ReturnUrl);
        //}

        [AllowAnonymous]
        public IActionResult LoginWithGoogle(string returnUrl = "/")
        {
            var props = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleLoginCallback"),
                Items =
                {
                    { "returnUrl", returnUrl }
                }
            };
            return Challenge(props, GoogleDefaults.AuthenticationScheme);
        }

        [AllowAnonymous]
        public async Task<IActionResult> GoogleLoginCallback()
        {
            // read google identity from the temporary cookie
            var result = await HttpContext.AuthenticateAsync(
             ExternalAuthenticationDefaults.AuthenticationScheme);

            var externalClaims = result.Principal.Claims.ToList();

            var subjectIdClaim = externalClaims.FirstOrDefault(
                x => x.Type == ClaimTypes.Email);
            //x => x.Type == ClaimTypes.NameIdentifier);
            var subjectValue = subjectIdClaim.Value;

            var user = userRepositroy.GetByGoogleId(subjectValue);
            if (user == null)
                return Unauthorized();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
          };

            var identity = new ClaimsIdentity(claims,
              CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            // delete temporary cookie used during google authentication
            await HttpContext.SignOutAsync(
              ExternalAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return LocalRedirect(result.Properties.Items["returnUrl"]);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
