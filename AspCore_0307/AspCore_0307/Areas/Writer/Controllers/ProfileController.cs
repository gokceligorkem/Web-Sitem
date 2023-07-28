using AspCore_0307.Areas.Writer.Models;
using AspCore_0307.Areas.Writer.WriterValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname=values.Surname;
            model.PictureUrl = values.ImageUrl;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p )

        {
            UserEditViewModelValidator validations = new UserEditViewModelValidator();
            ValidationResult result1 = validations.Validate(p); 
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Picture != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Picture.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = Path.Combine(resource, "wwwroot/UserImage/", imagename);
                var stream = new FileStream(savelocation, FileMode.Create);
                await p.Picture.CopyToAsync(stream);
                values.ImageUrl = imagename;

            }
            if (result1.IsValid) {
            values.Name = p.Name;
            values.Surname = p.Surname;
           
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.Password);
            var result = await _userManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            }
            else
            {
                foreach (var item in result1.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
