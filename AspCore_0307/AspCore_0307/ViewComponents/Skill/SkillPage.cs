using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.ViewComponents.Skill
{
    public class SkillPage:ViewComponent
    {
        SkillManager skillManager = new SkillManager(new EFSkillRepository());
        public IViewComponentResult Invoke()
        {
            var values = skillManager.GetList();
            return View(values);
        }
    }
}
