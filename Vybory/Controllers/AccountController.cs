using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vybory.Models;

namespace Vybory.Controllers
{
    public class AccountController : Controller
    {
        IUnitOfWork db;

        public AccountController(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        [HttpGet]
        public IActionResult Registrate()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrate(Registration registrationModel)
        {
            if (ModelState.IsValid)
            {
                var users = db.Users.Find(u => u.Login == registrationModel.IPN.ToString() || u.Id == registrationModel.Id);
                
                if (users.Count() == 0 )
                {
                    var user = new User
                    {
                        Id = registrationModel.Id,
                        Name = registrationModel.Name,
                        Surname = registrationModel.Surname,
                        Birthday = registrationModel.BirthDate,
                        IPN = registrationModel.IPN,
                        Login = registrationModel.IPN.ToString(),
                        Password = registrationModel.Password,
                        RoleId = 2,
                    };

                    var citizen = new Citizen
                    {
                        Id = user.Id,
                        DistrictId = 1,
                        PollingStationId = 1,
                        ElectionId = 1,
                        StatusId = 4
                    };
                    db.Citizens.Create(citizen);
                    db.Users.Create(user);
                    db.Save();

                    await Authenticate(user, "User");

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("RegistrationError", "Ідентифікаційний номер введено не вірно");
                }
            }

            return View(registrationModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login loginModel)
        {
            if (ModelState.IsValid)
            {
                var users = db.Users.Find(u => u.IPN.ToString() == loginModel.UserLogin && u.Password == loginModel.Password);
                if (users.Count() != 0)
                {
                    User user = users.First();
                    string role = db.Roles.Get((int)user.RoleId).Type;
                    await Authenticate(user, role);
                    if (user.RoleId == 1)
                    {
                        return RedirectToAction("StartAdminPage", "Admin");
                    }
                    else 
                    {
                        return RedirectToAction("Index2", "Home");
                    }
                }

                ModelState.AddModelError("", "invalid Data");
            }

            return View(loginModel);
        }

        private async Task Authenticate(User user, string role)
        {
            var claims = new List<Claim>
            {
                new Claim("userId", user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Surname),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Birthday.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.IPN.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Password),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}