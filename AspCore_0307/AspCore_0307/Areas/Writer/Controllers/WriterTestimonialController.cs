using AspCore_0307.Areas.Writer.Models;
using Business_Layer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspCore_0307.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/WriterTestimonial")]
    public class WriterTestimonialController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public WriterTestimonialController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            if (currentUser == null)
            {
                return RedirectToAction("Index", "Login");
            }

            Context _context = new Context();
            var userMessages = _context.Users.Where(u => u.Id == currentUser.Id).ToList();
            return View(userMessages);

        }
        [HttpGet]
        [Route("UpdateTestimonial/{id}")]
        public async Task<IActionResult> UpdateTestimonial()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            WriterReferansModel model = new WriterReferansModel();
            model.Job = values.Job;
            model.Content = values.Content;
            model.Status = values.Status;
            return View(model);
        }

        [HttpPost]
        [Route("UpdateTestimonial/{id}")]
        public async Task<IActionResult> UpdateTestimonial(WriterReferansModel p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (values == null)
            {
                return NotFound();
            }

            values.Job = p.Job;
            values.Content = p.Content;
            if (p.Status == true)
            {
                values.Status = true;
            }
            else
            {
                values.Status = false;
            }

            var result = await _userManager.UpdateAsync(values);
            if (result.Succeeded)
            {

                return RedirectToAction("Index", "WriterTestimonial");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            
            return View();
        }

    }
}
