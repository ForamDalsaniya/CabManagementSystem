using CabManagementSystem.Models;
using CabManagementSystem.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CabManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, City = model.City, Name = model.Name , isDriver = false};
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password,false,  false);
                if (result.Succeeded)
                {
                        return RedirectToAction("index", "home");
                }
                ModelState.AddModelError(String.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult RegisterCabDriver()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterCabDriver(RegisterCabDriverViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, City = model.City, Name = model.Name, isDriver = true };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    //return View("Login");
                    return RedirectToAction("index", "home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
    }
}
