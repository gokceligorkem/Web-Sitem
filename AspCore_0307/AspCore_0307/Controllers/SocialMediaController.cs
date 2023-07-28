using Business_Layer.Concrete;
using EntityLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace AspCore_0307.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EFSocialMediaRepository());
        public IActionResult Index()
        {var values= socialMediaManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia p)
        {
            p.Status = true;
            socialMediaManager.TAdd(p);
            return RedirectToAction("Index");

        }
        public IActionResult DeleteSocialMedia( int id)
        {
            var values=socialMediaManager.TGetById(id);
            socialMediaManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var values = socialMediaManager.TGetById(id);
            return View(values);

        }
        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia p)
        {
            socialMediaManager.Update(p);
            return RedirectToAction("Index");

        }
    }
}
