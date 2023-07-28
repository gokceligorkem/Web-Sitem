using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.ViewComponents.About
{
    public class AboutPage:ViewComponent
    {AboutManager aboutManager=new AboutManager(new EFAboutRepository());
        public IViewComponentResult Invoke()
        {
            var values = aboutManager.GetList();
            return View(values);
        }
    }
}
