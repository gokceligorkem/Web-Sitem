using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.ViewComponents.Service
{
    public class ServicePage:ViewComponent
    {
        ServiceManager serviceManager =new ServiceManager(new EFServiceRepository());
        public IViewComponentResult Invoke()
        {
            var values = serviceManager.GetList();
            return View(values);
        }
    }
}
