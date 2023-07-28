using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EFAboutRepository());
        public IActionResult Index()
        {
          
            var values = aboutManager.TGetById(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateAbout(About ab)
        {

            aboutManager.Update(ab);

            return RedirectToAction("Index", "Default");

        }
    }
}



 