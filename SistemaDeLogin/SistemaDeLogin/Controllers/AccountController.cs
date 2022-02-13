using SistemaDeLogin.Models;
using SistemaDeLogin.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeLogin.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace EstudiandoIdentity.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> UserManager;
        private readonly SignInManager<IdentityUser> SignInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                SignInResult result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Tareas");
                }

                ModelState.AddModelError("", "Inicio de sesion fallido");
            }
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AccountRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                // CREAS EL USUARIO
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // INICIAS SESION A ESE USUARIO
                    await SignInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Tareas");
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Tareas");
        }
    }
}
