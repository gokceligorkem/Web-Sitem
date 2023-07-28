

using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EFExperienceRepository());


        public IActionResult Index()
        {
         
            var values = experienceManager.GetList().OrderByDescending(x=>x.ExperienceId).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(Experience e)
        {
           
            experienceManager.TAdd(e);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveExperience(int id)
        {
            var values = experienceManager.TGetById(id);
            experienceManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
       
        public IActionResult UpdateExperience(int id)
        {
    
            var values = experienceManager.TGetById(id);
            return View(values);

        }
        [HttpPost]
     
        public IActionResult UpdateExperience(Experience e)
        {

            experienceManager.Update(e);

            return RedirectToAction("Index");

        }
    }
}
