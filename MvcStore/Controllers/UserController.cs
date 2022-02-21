using Microsoft.AspNetCore.Mvc;
using MvcStore.Interface;
using Microsoft.AspNetCore.Identity;
using MvcStore.Models.UserModels;
using System.Threading.Tasks;

namespace MvcStore.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController( SignInManager<IdentityUser> signIn, UserManager<IdentityUser> user){

            _signInManager = signIn;
            _userManager = user;
        }
        public IActionResult Register(){
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> RegisterConfirmed(RegisterUser model){
            if (ModelState.IsValid)
            {
                var user = new IdentityUser {UserName = model.UserName};
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Store");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            
            return RedirectToAction("failed");

            
            
        }
        public IActionResult failed(){
            
             return View();
            
        }
        public IActionResult Login(){
            return View();
        }

        public async Task<IActionResult> LoginConfirmed(LoginUser user){
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, user.RememberMe, false);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index","Store");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View("Login");
        }

        
        [HttpPost]
        public IActionResult Logout(){
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Store", "");
        }
    }
}