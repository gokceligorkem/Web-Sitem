using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AspCore_0307.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EFSkillRepository());
        public IActionResult Index()
        {
         
            var values = skillManager.GetList().OrderByDescending(x=>x.SkillId).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
        

            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill s)
        {
            skillManager.TAdd(s);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveSkill(int id)
        {
            var values = skillManager.TGetById(id);
            skillManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
       
            var values = skillManager.TGetById(id);
            return View(values);

        }
        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
            
            skillManager.Update(skill);

            return RedirectToAction("Index");

        }
    }
}
