using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular_Evi_Exam_09.Models;
using Angular_Evi_Exam_09.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Angular_Evi_Exam_09.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser>  signInManager;

        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager,ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            db.Database.EnsureCreated();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Succeeded)
                {
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login attempt");
                }
            }
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.UserName };
                var result = await this.userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent:false);
                    return Redirect("/Account/Login");
                    //return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Registration Failed !!");
                }
            }
            return View(model);
        }
        public async Task<IActionResult> LogOut()
        {
            await this.signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}