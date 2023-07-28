using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.ViewComponents.Experience
{
    public class ExperiencePage:ViewComponent
    {
        ExperienceManager experienceManager = new ExperienceManager(new EFExperienceRepository());
        public IViewComponentResult Invoke()
        {
            var values = experienceManager.GetList();
            return View(values);
        }

    }
}
