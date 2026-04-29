
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCLab8.Models;
using MVCLab8.ViewModels;

namespace MVCLab8.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public UserManager<AppUser> UserManager { get; }
        public SignInManager<AppUser> SignInManager { get; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                AppUser userModel = new AppUser
                {
                    UserName = newUserVM.UserName,
                    PasswordHash = newUserVM.Password,
                    FirstName = newUserVM.FirstName,
                    LastName = newUserVM.LastName,
                    nationality = newUserVM.nationality,
                    EducationLevel = newUserVM.EducationLevel

                };

                IdentityResult result =  await UserManager.CreateAsync(userModel, newUserVM.Password);

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(userModel, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {                    
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                AppUser userFromDB = await UserManager.FindByNameAsync(newUserVM.UserName);

                if (userFromDB != null)
                {
                    bool found = await UserManager.CheckPasswordAsync(userFromDB, newUserVM.Password);
                    if (found == true)
                    {
                        await SignInManager.SignInAsync(userFromDB, isPersistent: newUserVM.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }

            }
            ModelState.AddModelError("", "Invalid username or password");
            return View();
        }


        public IActionResult Logout()
        {
            SignInManager.SignOutAsync();  
            return RedirectToAction("Login", "Account");
        }
    }
}
