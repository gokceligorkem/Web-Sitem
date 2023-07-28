using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.ViewComponents.Dashboard
{
    public class FeatureStatics:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {   
            ViewBag.v1 = c.Skills.Count();
            ViewBag.v2 = c.Messages.Where(x => x.Status == false).Count();
            ViewBag.v3 = c.Messages.Where(x => x.Status == true).Count();
            ViewBag.v4 = c.Experiences.Count();
            ViewBag.v5 = c.Testimonials.Count();
            return View();
        }
    }
}
