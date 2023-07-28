using AspCore_0307.Areas.Writer.Models;
using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Windows.Markup;
using X.PagedList;

namespace AspCore_0307.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public TestimonialController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var users = await _userManager.Users.OrderByDescending(x => x.Id).ToPagedListAsync(page, 5);

            return View(users);
        }

        [HttpGet]
        public IActionResult UpdateTestimonial(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;

            var model = new WriterReferansModel
            {
                Job = user.Job,
                Content = user.Content,
                Status = user.Status
            };

            return View(model);


        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(WriterReferansModel p, string id)
        {

            if (!ModelState.IsValid)//Model Doğru Değilse
            {
                return View(p);
            }

            var currentUser = await _userManager.FindByIdAsync(id.ToString());
            if (currentUser == null)
            {
                return NotFound();
            }

            currentUser.Job = p.Job;
            currentUser.Content = p.Content;
            currentUser.Status = p.Status;

            var result = await _userManager.UpdateAsync(currentUser);

            if (result.Succeeded)
            {
                // Güncelleme işlemi başarılı oldu.

                return RedirectToAction("Index", "Testimonial");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(p);
        }
    } 
}
