using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AspCore_0307.Controllers
{
    public class AjaxExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EFExperienceRepository());
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult ListExperience()
        {
            var values =JsonConvert.SerializeObject(experienceManager  .GetList());
            return Json(values);
        }
        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            experienceManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
        public IActionResult GetById(int ExperienceId)
        {
            var get= experienceManager.TGetById(ExperienceId);
            var values = JsonConvert.SerializeObject(get);
            return Json(values);
        }
       
        public IActionResult DeleteExperience(int id)
        {
            var v = experienceManager.TGetById(id);
            experienceManager.TDelete(v);
            return NoContent();
        }       
        public IActionResult UpdateExperience(Experience p)
        {
            var existingExperience = experienceManager.TGetById(p.ExperienceId);
            existingExperience.Name = p.Name;
            existingExperience.ImgUrl = p.ImgUrl;
            existingExperience.Date = p.Date;
            existingExperience.Description = p.Description;

            experienceManager.Update(existingExperience);

            var updatedValues = JsonConvert.SerializeObject(existingExperience);
            return Json(updatedValues);
        }
    }
}
