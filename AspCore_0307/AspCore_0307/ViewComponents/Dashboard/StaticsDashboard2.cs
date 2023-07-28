using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.ViewComponents.Dashboard
{
    public class StaticsDashboard2:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Portfolios.Count();
            ViewBag.v2 = c.Messages.Count();
            ViewBag.v3 = c.Services.Count();
            return View();
        }
    }
}
