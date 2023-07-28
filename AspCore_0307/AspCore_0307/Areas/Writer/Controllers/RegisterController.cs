using AspCore_0307.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace AspCore_0307.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class RegisterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;
        private readonly RoleManager<WriteRole> _roleManager;

        public RegisterController(UserManager<WriterUser> userManager, RoleManager<WriteRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserRegisterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {
            var roleName = "Writer";
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                
                var newRole = new WriteRole
                {
                    Name = roleName
                };
                await _roleManager.CreateAsync(newRole);
            }

            WriterUser w = new WriterUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.UserName,
                ImageUrl = "Bekleniyor",
                Content = "Bekleniyor",
                Job = "Bekleniyor",
                Status = false
            };

            if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(w, p.Password);

                if (result.Succeeded)
                {
                    // Assign the "Writer" role to the user.
                    await _userManager.AddToRoleAsync(w, "Writer");
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
}
