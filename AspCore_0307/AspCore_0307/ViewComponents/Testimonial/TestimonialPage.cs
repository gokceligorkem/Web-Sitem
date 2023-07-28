using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspCore_0307.ViewComponents.Testimonial
{
    public class TestimonialPage:ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public TestimonialPage(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
          

            var writerUsers = await _userManager.Users.ToListAsync();
            return View(writerUsers);
        }
    }
}
